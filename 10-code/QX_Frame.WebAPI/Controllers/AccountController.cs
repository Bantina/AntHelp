using QX_Frame.App.Web;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.WebAPI.config;
using QX_Frame.WebAPI.Helpers;
using System;
using System.Web;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-05 14:01:53
	/// </summary>

	/// <summary>
	///class AccountController
	/// </summary>
	public class AccountController:WebApiControllerBase
	{
		// GET: api/Account
		public IHttpActionResult Get([FromBody]dynamic query)
		{
			return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode(""));
		}

		// GET: api/Account/5
		public IHttpActionResult Get(string id, [FromBody]dynamic query)
		{
			return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode(""));
		}

		// POST: api/Account    //account register api
		public IHttpActionResult Post([FromBody]dynamic query)
		{
            if (query == null)
            {
                throw new ArgumentNullException("loginId/pwd", "loginId and pwd must be provide");
            }
            if (query.loginId==null)
            {
                throw new ArgumentNullException("loginId","loginId must be provide");
            }
            if (query.pwd==null)
            {
                throw new ArgumentNullException("pwd", "pwd must be provide");
            }
            if (query.email==null)
            {
                throw new ArgumentNullException("email", "email must be provide");
            }

            string loginId = query.loginId;
            string pwd = query.pwd; //pwd must be MD5 encrypt
            string email = query.email;

            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();
                int userAccountCountByloginId = channel.QueryCount(new tb_UserAccountQueryObject { QueryCondition = t => t.loginId.Equals(loginId) });
                if (userAccountCountByloginId > 0)
                {
                    throw new MemberAccessException("the loginId has been exist!");
                }
            }

            Cache_Helper_DG.Cache_Add($"{loginId}", $"{pwd},{email}", null, DateTime.Now.AddMinutes(10));   //add loginId pwd into cache 10 minutes later expired

            
            Mail_Helper.SendMail(email,$"{ControllerConfigs.AppDomain}api/User?loginId={loginId}");

            /**
             * 页面输入点击 请求到本地址，然后本接口发送邮件， 用户点击邮件内链接跳转到 站内页面
             * 站内页面初始化时候获取链接上的参数，带着参数请求注册地址，然后返回结果展示注册结果
             * */

            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("注册邮件已发送到您的邮箱，请查收并点击邮箱中的连接完成注册！"));
		}

		// PUT: api/Account
		public IHttpActionResult Put([FromBody]dynamic query)
		{
			return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode(""));
		}

		// DELETE: api/Account
		public IHttpActionResult Delete([FromBody]dynamic query)
		{
			return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode(""));
		}
	}
}
