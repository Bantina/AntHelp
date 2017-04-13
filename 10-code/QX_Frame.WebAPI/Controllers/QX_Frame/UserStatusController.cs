using QX_Frame.App.Web;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
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
    /// time:2017-04-13 11:09:34
    /// </summary>

    /// <summary>
    ///class UserStatusController
    /// </summary>
    [LimitsAttribute_DG(RoleLevel = 1)]//administrator least
    public class UserStatusController:WebApiControllerBase
	{
        // GET: api/UserStatus
        public IHttpActionResult Get(int pageIndex, int pageSize, bool isDesc)
        {
            using (var fact = Wcf<UserStatusService>())
            {
                var channel = fact.CreateChannel();
                int count;
                List<tb_UserStatus> userStatusList = channel.QueryAllPaging<tb_UserStatus, int>(new tb_UserStatusQueryObject { PageIndex = pageIndex, PageSize = pageSize, IsDESC = isDesc }, t => t.statusLevel).Cast<List<tb_UserStatus>>(out count);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("user status list", userStatusList, count));
            }
        }

        // GET: api/UserStatus/id
        public IHttpActionResult Get(string id)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}

		// POST: api/UserStatus
		public IHttpActionResult Post([FromBody]dynamic query)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}

        // PUT: api/UserStatus
        public IHttpActionResult Put([FromBody]dynamic query)
        {
            Guid uid;
            string loginId = query.loginId;
            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();
                uid = channel.GetUserAccountByLoginId(loginId).uid;
            }

            using (var fact = Wcf<UserStatusService>())
            {
                var channel = fact.CreateChannel();
                tb_UserStatus userStatus = channel.QuerySingle(new tb_UserStatusQueryObject { QueryCondition = t => t.uid == uid }).Cast<tb_UserStatus>();
                userStatus.statusLevel = query.statusLevel;
                if (channel.Update(userStatus))
                {
                    return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("update user status success"));
                }
            }
            throw new Exception_DG("update faild", 3014);
        }
        // DELETE: api/UserStatus
        public IHttpActionResult Delete([FromBody]dynamic query)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}
        /// <summary>
        /// Get User Status By Uid
        /// </summary>
        /// <param name="uid">uid</param>
        /// <returns></returns>
        public static tb_UserStatus GetUserStatusByUid(Guid uid)
        {
            using (var fact = Wcf<UserStatusService>())
            {
                var channel = fact.CreateChannel();
                tb_UserStatus userStatus = channel.QuerySingle(new tb_UserStatusQueryObject { QueryCondition = t => t.uid == uid }).Cast<tb_UserStatus>();
                if (userStatus == null)
                {
                    throw new Exception_DG("no user account found by uid", 3016);
                }
                return userStatus;
            }
        }

    }
}
