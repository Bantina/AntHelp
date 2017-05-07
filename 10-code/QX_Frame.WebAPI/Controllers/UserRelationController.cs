using QX_Frame.App.Web;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG;
using QX_Frame.Helper_DG.Extends;
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
    ///class UserRelationController
    /// </summary>
    public class UserRelationController : WebApiControllerBase
    {
        // GET: api/UserRelation
        public IHttpActionResult Get(string loginId,int pageIndex, int pageSize, bool isDesc)
        {
            tb_UserRelationQueryObject queryObject = new tb_UserRelationQueryObject();

            queryObject.myUid = UserController.GetUserAccountInfoByLoginId(loginId).uid;
            queryObject.PageIndex = pageIndex;
            queryObject.PageSize = pageSize;
            queryObject.IsDESC = true;

            using (var fact = Wcf<UserRelationService>())
            {
                int count = 0;
                var channel = fact.CreateChannel();
                List<tb_UserRelation> userRelationList = channel.QueryAllPaging<tb_UserRelation, DateTime>(queryObject, t => t.relationTime).Cast<List<tb_UserRelation>>(out count);
                List<UserRelationViewModel> userRelationViewModelList = new List<UserRelationViewModel>();
                foreach (var item in userRelationList)
                {
                    UserRelationViewModel userRelationViewModel = new UserRelationViewModel();
                    tb_UserRelation userRelation = new tb_UserRelation();
                    userRelationViewModel.relationUid = userRelation.relationUid;
                    userRelationViewModel.myUid = userRelation.myUid;
                    userRelationViewModel.myUserAccountInfo = UserController.GetUserAccountInfoByUidAllowNull(userRelation.myUid);
                    userRelationViewModel.friendUid = userRelation.friendUid;
                    userRelationViewModel.friendUserAccountInfo = UserController.GetUserAccountInfoByUidAllowNull(userRelation.friendUid);
                    userRelationViewModel.relationTime = userRelation.relationTime;

                    userRelationViewModelList.Add(userRelationViewModel);
                }

                userRelationViewModelList.OrderBy(t => t.friendUserAccountInfo.nickName);//order by nick name

                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get UserRelation fuzzy query by userRelationTitle", userRelationViewModelList, count));
            }
        }

        // GET: api/UserRelation/5
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception_DG("id must be provide", 1012);
            }

            Guid relationUid = Guid.Parse(id);

            using (var fact = Wcf<UserRelationService>())
            {
                var channel = fact.CreateChannel();
                tb_UserRelation userRelation = channel.QuerySingle(new tb_UserRelationQueryObject { QueryCondition = t => t.relationUid == relationUid }).Cast<tb_UserRelation>();
                if (userRelation == null)
                {
                    throw new Exception_DG("no userRelation found by userRelationUid", 3013);
                }
                UserRelationViewModel userRelationViewModel = new UserRelationViewModel();
                userRelationViewModel.relationUid = userRelation.relationUid;
                userRelationViewModel.myUid = userRelation.myUid;
                userRelationViewModel.myUserAccountInfo = UserController.GetUserAccountInfoByUidAllowNull(userRelation.myUid);
                userRelationViewModel.friendUid = userRelation.friendUid;
                userRelationViewModel.friendUserAccountInfo = UserController.GetUserAccountInfoByUidAllowNull(userRelation.friendUid);
                userRelationViewModel.relationTime = userRelation.relationTime;

                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get UserRelation by userRelationUid", userRelationViewModel, 1));
            }
        }
        // POST: api/UserRelation
        public IHttpActionResult Post([FromBody]dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }

            tb_UserRelation userRelation = tb_UserRelation.Build();
            userRelation.relationUid = Guid.NewGuid();
            int appKey = query.appKey;
            string token = query.Token;
            userRelation.myUid = AuthenticationController.GetTokenInfoByAppKeyToken(appKey,token).Item1;
            userRelation.friendUid = query.friendUid;
            userRelation.relationTime =DateTime.Now;

            using (var fact2 = Wcf<UserRelationService>())
            {
                var channel2 = fact2.CreateChannel();
                bool isAdd = channel2.Add(userRelation);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("userRelation publish succeed", userRelation, 1));
            }
        }

        // PUT: api/UserRelation/id 2 = add clickCount , 3 = praiseCount
        public IHttpActionResult Put(int id, [FromBody]dynamic query)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }

        // DELETE: api/UserRelation
        public IHttpActionResult Delete([FromBody]dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }
            Guid relationUid = query.relationUid;
            using (var fact = Wcf<UserRelationService>())
            {
                var channel = fact.CreateChannel();
                tb_UserRelation userRelation = channel.QuerySingle(new tb_UserRelationQueryObject { QueryCondition = t => t.relationUid == relationUid }).Cast<tb_UserRelation>();
                if (userRelation == null)
                {
                    throw new Exception_DG("no userRelation found by userRelationUid", 3013);
                }
                if (!channel.Delete(userRelation))
                {
                    throw new Exception_DG("delete faild", 3005);
                }
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("delete userRelation succeed", userRelation, 1));
            }
        }
    }
}
