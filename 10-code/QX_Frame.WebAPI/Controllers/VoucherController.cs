using QX_Frame.App.Web;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities;
using QX_Frame.Data.Options;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG;
using QX_Frame.Helper_DG.Extends;
using QX_Frame.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
	/// <summary>query
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-14 18:09:04
	/// </summary>

	/// <summary>
	///class VoucherController
	/// </summary>
	public class VoucherController:WebApiControllerBase
    {
        // GET: api/Voucher
        public IHttpActionResult Get(string loginId, int pageIndex, int pageSize, bool isDesc)
        {
            tb_VoucherQueryObject queryObject = new tb_VoucherQueryObject();
            var userInfo = UserController.GetUserAccountInfoByLoginIdAllowNull(loginId);
            if (userInfo==null)
            {
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get voucher list query by loginId", null, 0));
            }

            queryObject.userUid = userInfo.uid;
            queryObject.PageIndex = pageIndex;
            queryObject.PageSize = pageSize;
            queryObject.IsDESC = isDesc;

            using (var fact = Wcf<VoucherService>())
            {
                int count = 0;
                var channel = fact.CreateChannel();
                List<tb_Voucher> resultList = channel.QueryAllPaging<tb_Voucher, int>(queryObject, t => t.voucherValueOfMoney).Cast<List<tb_Voucher>>(out count);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get voucher list query by loginId", resultList, count));
            }
        }

        // GET: api/Voucher/id
        public IHttpActionResult Get(string id)
        {
            using (var fact = Wcf<VoucherService>())
            {
                Guid uid = Guid.Parse(id);
                var channel = fact.CreateChannel();

                tb_Voucher favorableActivity = channel.QuerySingle(new tb_VoucherQueryObject { QueryCondition = t => t.voucherUid == uid }).Cast<tb_Voucher>();
                if (favorableActivity == null)
                {
                    throw new Exception_DG("no result found by this query condition", 3021);
                }
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get Voucher by id=voucherUid", favorableActivity, 1));
            }
        }

        // POST: api/Voucher
        public IHttpActionResult Post([FromBody]dynamic query)
        {
            using (var fact = Wcf<VoucherService>())
            {
                var channel = fact.CreateChannel();

                tb_Voucher voucher = new tb_Voucher();
                voucher.voucherUid = Guid.NewGuid();
                voucher.voucherDescription = query.voucherDescription;
                voucher.voucherValueOfMoney = query.voucherValueOfMoney;
                string loginId = query.loginId;
                voucher.userUid = UserController.GetUserAccountInfoByLoginId(loginId).uid;

                channel.Add(voucher);
            }
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("add succeed"));
        }

        // PUT: api/Voucher
        public IHttpActionResult Put([FromBody]dynamic query)
        {
            using (var fact = Wcf<VoucherService>())
            {
                Guid uid = Guid.Parse(query.voucherUid);
                var channel = fact.CreateChannel();

                tb_Voucher favorableActivity = channel.QuerySingle(new tb_VoucherQueryObject { QueryCondition = t => t.voucherUid == uid }).Cast<tb_Voucher>();
                if (favorableActivity == null)
                {
                    throw new Exception_DG("no result found by this query condition", 3021);
                }

                favorableActivity.voucherDescription = query.voucherDescription;
                favorableActivity.voucherValueOfMoney = query.voucherValueOfMoney;

                channel.Update(favorableActivity);
            }
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("update succeed"));
        }

        // DELETE: api/Voucher
        public IHttpActionResult Delete([FromBody]dynamic query)
        {
            using (var fact = Wcf<VoucherService>())
            {
                Guid uid = Guid.Parse(query.voucherUid);
                var channel = fact.CreateChannel();

                tb_Voucher favorableActivity = channel.QuerySingle(new tb_VoucherQueryObject { QueryCondition = t => t.voucherUid == uid }).Cast<tb_Voucher>();
                if (favorableActivity == null)
                {
                    throw new Exception_DG("no result found by this query condition", 3021);
                }

                channel.Delete(favorableActivity);
            }
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("update succeed"));
        }
    }
}
