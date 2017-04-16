using QX_Frame.App.Web;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.Helper_DG_Framework.Extends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
    /// <summary>
    /// copyright qixiao code builder ->
    /// version:4.2.0
    /// author:qixiao(柒小)
    /// time:2017-04-12 11:05:17
    /// </summary>

    /// <summary>
    ///class SelfMessageController
    /// </summary>
    public class SelfMessageController : WebApiControllerBase
    {
        // GET: api/SelfMessage
        public IHttpActionResult Get(int appKey, string token, int pageIndex, int pageSize, bool isDesc)
        {
            tb_SelfMessageQueryObject queryObject = new tb_SelfMessageQueryObject();

            Guid myUid = AuthenticationController.GetTokenInfoByAppKeyToken(appKey, token).Item1;
            List<Guid> friendUidList = new List<Guid>();
            using (var fact = Wcf<UserRelationService>())
            {
                var channel = fact.CreateChannel();
                List<tb_UserRelation> userRelationList = channel.QueryAll(new tb_UserRelationQueryObject { QueryCondition = t => t.myUid == myUid }).Cast<List<tb_UserRelation>>();
                friendUidList = userRelationList.Select(t => t.friendUid).ToList<Guid>();
            }

            queryObject.friendUidList = friendUidList;
            queryObject.PageIndex = pageIndex;
            queryObject.PageSize = pageSize;
            queryObject.IsDESC = true;

            using (var fact = Wcf<SelfMessageService>())
            {
                int count = 0;
                var channel = fact.CreateChannel();
                List<tb_SelfMessage> selfMessageList = channel.QueryAllPaging<tb_SelfMessage, DateTime>(queryObject, t => t.publishTime).Cast<List<tb_SelfMessage>>(out count);
                List<SelfMessageViewModel> selfMessageViewModelList = new List<SelfMessageViewModel>();
                foreach (var item in selfMessageList)
                {
                    SelfMessageViewModel selfMessageViewModel = new SelfMessageViewModel();
                    tb_SelfMessage selfMessage = new tb_SelfMessage();
                    selfMessageViewModel.selfMessageUid = item.selfMessageUid;
                    selfMessageViewModel.selfMessageContent = item.selfMessageContent;
                    selfMessageViewModel.publishTime = item.publishTime;
                    selfMessageViewModel.publishTimeString = item.publishTime.ToDateTimeString_24HourType();
                    selfMessageViewModel.publisherUid = item.publisherUid;
                    selfMessageViewModel.userAccountInfo = UserController.GetUserAccountInfoByUidAllowNull(item.publisherUid);
                    selfMessageViewModel.clickCount = item.clickCount;
                    selfMessageViewModel.praiseCount = item.praiseCount;
                    selfMessageViewModel.imagesUrls = item.imagesUrls;

                    selfMessageViewModelList.Add(selfMessageViewModel);
                }

                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get SelfMessage fuzzy query by selfMessageTitle", selfMessageViewModelList, count));
            }
        }

        // GET: api/SelfMessage/5
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception_DG("id must be provide", 1012);
            }

            Guid selfMessageUid = Guid.Parse(id);

            using (var fact = Wcf<SelfMessageService>())
            {
                var channel = fact.CreateChannel();
                tb_SelfMessage selfMessage = channel.QuerySingle(new tb_SelfMessageQueryObject { QueryCondition = t => t.selfMessageUid == selfMessageUid }).Cast<tb_SelfMessage>();
                if (selfMessage == null)
                {
                    throw new Exception_DG("no selfMessage found by selfMessageUid", 3013);
                }
                SelfMessageViewModel selfMessageViewModel = new SelfMessageViewModel();
                selfMessageViewModel.selfMessageUid = selfMessage.selfMessageUid;
                selfMessageViewModel.selfMessageContent = selfMessage.selfMessageContent;
                selfMessageViewModel.publishTime = selfMessage.publishTime;
                selfMessageViewModel.publishTimeString = selfMessage.publishTime.ToDateTimeString_24HourType();
                selfMessageViewModel.publisherUid = selfMessage.publisherUid;
                selfMessageViewModel.userAccountInfo = UserController.GetUserAccountInfoByUidAllowNull(selfMessage.publisherUid);
                selfMessageViewModel.clickCount = selfMessage.clickCount;
                selfMessageViewModel.praiseCount = selfMessage.praiseCount;
                selfMessageViewModel.imagesUrls = selfMessage.imagesUrls;
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get SelfMessage by selfMessageUid", selfMessageViewModel, 1));
            }
        }
        // POST: api/SelfMessage
        public IHttpActionResult Post([FromBody]dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }

            tb_SelfMessage selfMessage = tb_SelfMessage.Build();
            selfMessage.selfMessageUid = Guid.NewGuid();
            selfMessage.selfMessageContent = query.selfMessageContent;
            selfMessage.publishTime = DateTime.Now;
            string loginId = query.loginId;
            selfMessage.imagesUrls = query.imagesUrls;

            using (var fact2 = Wcf<UserAccountService>())
            {
                var channel2 = fact2.CreateChannel();
                selfMessage.publisherUid = channel2.GetUserAccountByLoginId(loginId).uid;
            }

            using (var fact2 = Wcf<SelfMessageService>())
            {
                var channel2 = fact2.CreateChannel();
                bool isAdd = channel2.Add(selfMessage);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("selfMessage publish succeed", selfMessage, 1));
            }
        }

        // PUT: api/SelfMessage/id 2 = add clickCount , 3 = praiseCount
        public IHttpActionResult Put(int id, [FromBody]dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }

            Guid selfMessageUid = query.selfMessageUid;

            using (var fact = Wcf<SelfMessageService>())
            {
                var channel = fact.CreateChannel();
                tb_SelfMessage selfMessage = channel.QuerySingle(new tb_SelfMessageQueryObject { QueryCondition = t => t.selfMessageUid == selfMessageUid }).Cast<tb_SelfMessage>();
                if (selfMessage == null)
                {
                    throw new Exception_DG("no selfMessage found by selfMessageUid", 3013);
                }
                if (id == 2)
                {
                    selfMessage.clickCount++;
                }
                else if (id == 3)
                {
                    selfMessage.praiseCount++;
                }
                else
                {
                    throw new Exception_DG("the error id provid", 3015);
                }

                if (!channel.Update(selfMessage))
                {
                    throw new Exception_DG("update selfMessage faild", 3014);
                }
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("update selfMessage succeed", selfMessage, 1));
            }
        }

        // DELETE: api/SelfMessage
        public IHttpActionResult Delete([FromBody]dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }
            Guid selfMessageUid = query.selfMessageUid;
            using (var fact = Wcf<SelfMessageService>())
            {
                var channel = fact.CreateChannel();
                tb_SelfMessage selfMessage = channel.QuerySingle(new tb_SelfMessageQueryObject { QueryCondition = t => t.selfMessageUid == selfMessageUid }).Cast<tb_SelfMessage>();
                if (selfMessage == null)
                {
                    throw new Exception_DG("no selfMessage found by selfMessageUid", 3013);
                }
                if (!channel.Delete(selfMessage))
                {
                    throw new Exception_DG("delete faild", 3005);
                }
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("delete selfMessage succeed", selfMessage, 1));
            }
        }
    }
}
