using QX_Frame.App.Web;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities;
using QX_Frame.Data.Options;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.Helper_DG_Framework.Extends;
using QX_Frame.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
    /// <summary>
    /// copyright qixiao code builder ->
    /// version:4.2.0
    /// author:qixiao(柒小)
    /// time:2017-04-14 10:27:14
    /// </summary>

    /// <summary>
    ///class OrderController
    /// </summary>
    public class OrderController : WebApiControllerBase
    {
        private readonly static object lockObj = new object();
        // GET: api/Order
        public IHttpActionResult Get(string orderDescription, int pageIndex, int pageSize, bool isDesc)
        {
            tb_OrderQueryObject queryObject = new tb_OrderQueryObject();

            queryObject.orderDescription = orderDescription;//fuzzy query
            queryObject.PageIndex = pageIndex;
            queryObject.PageSize = pageSize;
            queryObject.IsDESC = isDesc;

            using (var fact = Wcf<OrderService>())
            {
                int count = 0;
                var channel = fact.CreateChannel();
                List<tb_Order> orderList = channel.QueryAllPaging<tb_Order, DateTime>(queryObject, t => t.publishTime).Cast<List<tb_Order>>(out count);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get order list fuzzy query by orderDescription", orderList, count));
            }
        }

        // GET: api/Order/id
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception_DG("id must be provide", 1012);
            }

            Guid orderUid = Guid.Parse(id);

            using (var fact = Wcf<OrderService>())
            {
                using (var fact_user = Wcf<UserAccountInfoService>())
                {
                    var channel = fact.CreateChannel();
                    var channel_user = fact_user.CreateChannel();
                    tb_Order Order = channel.QuerySingle(new tb_OrderQueryObject { QueryCondition = t => t.orderUid == orderUid }).Cast<tb_Order>();
                    if (Order == null)
                    {
                        throw new Exception_DG("no Order found by OrderUid", 3013);
                    }
                    OrderViewModel orderViewModel = new OrderViewModel();
                    orderViewModel.orderUid = Order.orderUid;
                    orderViewModel.publisherUid = Order.publisherUid;
                    orderViewModel.publisherInfo = channel_user.GetUserAccountInfoByUidAllowNull(Order.publisherUid);
                    orderViewModel.publishTime = Order.publishTime.ToDateTimeString_24HourType();
                    orderViewModel.orderDescription = Order.orderDescription;
                    orderViewModel.orderCategoryId = Order.orderCategoryId;
                    orderViewModel.orderCategory = Order.tb_OrderCategory;
                    orderViewModel.receiverUid = Order.receiverUid;
                    orderViewModel.receiverInfo = channel_user.GetUserAccountInfoByUidAllowNull(Order.receiverUid);
                    orderViewModel.receiveTime = Order.receiveTime.ToDateTimeString_24HourType();
                    orderViewModel.orderStatusId = Order.orderStatusId;
                    orderViewModel.orderStatus = Order.tb_OrderStatus;
                    orderViewModel.orderValue = Order.orderValue;
                    orderViewModel.allowVoucher = Order.allowVoucher;
                    orderViewModel.voucherMax = Order.voucherMax;
                    orderViewModel.evaluateUid = Order.evaluateUid;
                    orderViewModel.orderEvaluate = Order.tb_OrderEvaluate;
                    orderViewModel.address = Order.address;
                    orderViewModel.phone = Order.phone;
                    orderViewModel.imageUrls = Order.imageUrls;

                    return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get Order by OrderUid", orderViewModel, 1));
                }
            }
        }

        // POST: api/Order
        [LimitsAttribute_DG(RoleLevel = 0)]//user
        public IHttpActionResult Post([FromBody]dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }

            Transaction_Helper_DG.Transaction(() =>
            {
                tb_Order order = tb_Order.Build();
                order.orderUid = Guid.NewGuid();

                string loginId = query.publisherLoginId;
                using (var fact2 = Wcf<UserAccountService>())
                {
                    var channel2 = fact2.CreateChannel();
                    order.publisherUid = channel2.GetUserAccountByLoginId(loginId).uid;
                }

                order.publishTime = DateTime.Now;
                order.orderDescription = query.orderDescription;
                order.orderCategoryId = query.orderCategoryId;
                order.receiverUid = default(Guid);
                order.receiveTime = DateTime.Now;
                order.orderStatusId = opt_OrderStatus.待接单.ToInt();
                order.orderValue = query.orderValue;
                order.allowVoucher = 1;
                order.voucherMax = 5;

                tb_OrderEvaluate orderEvaluate = tb_OrderEvaluate.Build();
                orderEvaluate.evaluateUid = Guid.NewGuid();
                orderEvaluate.publisherScore = 3;
                orderEvaluate.receiveScore = 3;
                using (var fact = Wcf<OrderEvaluateService>())
                {
                    var channel = fact.CreateChannel();
                    channel.Add(orderEvaluate);
                }

                order.evaluateUid = orderEvaluate.evaluateUid;
                order.address = query.address;
                order.phone = query.phone;
                order.imageUrls = query.imageUrls;

                using (var fact2 = Wcf<OrderService>())
                {
                    var channel2 = fact2.CreateChannel();
                    bool isAdd = channel2.Add(order);
                }
            });

            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("order publish succeed"));
        }

        // PUT: api/Order/id    //id=1 orderStatusId and receiverLoginId id=2 orderStatusId
        [LimitsAttribute_DG(RoleLevel = 0)]//user
        public IHttpActionResult Put(int id, [FromBody]dynamic query)
        {
            lock (lockObj)
            {
                Guid orderUid = query.orderUid;//argument

                using (var fact = Wcf<OrderService>())
                {
                    var channel = fact.CreateChannel();
                    tb_Order order = channel.QuerySingle(new tb_OrderQueryObject { QueryCondition = t => t.orderUid == orderUid }).Cast<tb_Order>();
                    if (order == null)
                    {
                        throw new Exception_DG("no result found by this query condition", 3021);
                    }
                    if (id == 1)
                    {
                        if (order.orderStatusId == opt_OrderStatus.待接单.ToInt())
                        {
                            string loginId = query.receiverLoginId;//argument
                            order.receiverUid = UserController.GetUserAccountInfoByLoginId(loginId.Trim()).uid;
                            order.receiveTime = DateTime.Now;
                            order.orderStatusId = query.orderStatusId;//argument
                        }
                        else
                        {
                            throw new Exception_DG("the order has been received", 3022);
                        }
                    }
                    else if (id==2)
                    {
                        order.orderStatusId = query.orderStatusId;//argument
                    }
                    channel.Update(order);
                }
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("update succeed"));
            }
        }

        // DELETE: api/Order
        [LimitsAttribute_DG(RoleLevel = 0)]//user
        public IHttpActionResult Delete([FromBody]dynamic query)
        {
            Guid orderUid = query.orderUid;
            using (var fact = Wcf<OrderService>())
            {
                var channel = fact.CreateChannel();
                tb_Order order = channel.QuerySingle(new tb_OrderQueryObject { QueryCondition = t => t.orderUid == orderUid }).Cast<tb_Order>();
                if (order == null)
                {
                    throw new Exception_DG("no result found by this query condition", 3021);
                }
                channel.Delete(order);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("delete succeed"));
            }
        }
    }
}
