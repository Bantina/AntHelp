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
    /// time:2017-04-13 11:00:29
    /// </summary>

    /// <summary>
    ///class UserRoleController
    /// </summary>
    ///
    [LimitsAttribute_DG(RoleLevel =1)]//administrator
	public class UserRoleController:WebApiControllerBase
	{
		// GET: api/UserRole
		public IHttpActionResult Get(int pageIndex, int pageSize, bool isDesc)
		{
            using (var fact=Wcf<UserRoleService>())
            {
                var channel = fact.CreateChannel();
                int count;
                List<tb_UserRole> userRoleList = channel.QueryAllPaging<tb_UserRole, int>(new tb_UserRoleQueryObject { PageIndex = pageIndex, PageSize = pageSize, IsDESC = isDesc }, t => t.roleLevel).Cast<List<tb_UserRole>>(out count);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("user role list", userRoleList, count));
            }
		}

		// GET: api/UserRole/id
		public IHttpActionResult Get(string id)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}

		// POST: api/UserRole
		public IHttpActionResult Post([FromBody]dynamic query)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}

		// PUT: api/UserRole
		public IHttpActionResult Put([FromBody]dynamic query)
		{
            Guid uid ;
            string loginId = query.loginId;
            using (var fact=Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();
                uid = channel.GetUserAccountByLoginId(loginId).uid;
            }

            using (var fact = Wcf<UserRoleService>())
            {
                var channel = fact.CreateChannel();
                tb_UserRole userRole = channel.QuerySingle(new tb_UserRoleQueryObject { QueryCondition = t => t.uid == uid }).Cast<tb_UserRole>();
                userRole.roleLevel = query.roleLevel;
                if (channel.Update(userRole))
                {
                    return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("update user Role success"));
                }
            }
            throw new Exception_DG("update faild",3014);
		}

		// DELETE: api/UserRole
		public IHttpActionResult Delete([FromBody]dynamic query)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}

        /// <summary>
        /// Get User Role By Uid
        /// </summary>
        /// <param name="uid">uid</param>
        /// <returns></returns>
        public static tb_UserRole GetUserRoleByUid(Guid uid)
        { 
            using (var fact=Wcf<UserRoleService>())
            {
                var channel = fact.CreateChannel();
                tb_UserRole userRole = channel.QuerySingle(new tb_UserRoleQueryObject { QueryCondition = t => t.uid == uid }).Cast<tb_UserRole>();
                if (userRole==null)
                {
                    throw new Exception_DG("no user account found by uid",3016);
                }
                return userRole;
            }
        }
	}
}
