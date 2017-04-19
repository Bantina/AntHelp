using QX_Frame.App.Web;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.Helper_DG_Framework.Extends;
using QX_Frame.WebAPI.config;
using QX_Frame.WebAPI.Helpers;
using System;
using System.Text.RegularExpressions;
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
    public class AccountController : WebApiControllerBase
    {
        // GET: api/Account
        public IHttpActionResult Get()
        {
            throw new Exception_DG("The interface is not available", 9999);
        }

        // GET: api/Account/5
        public IHttpActionResult Get(string id)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }

        // POST: api/Account    //account register api
        /// <summary>
        /// account register api
        /// </summary>
        /// <param name="query">{loginId:"",pwd:"",email:""}</param>
        /// <returns>return json{}</returns>
        public IHttpActionResult Post([FromBody]dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }
            if (query.loginId == null)
            {
                throw new Exception_DG("loginId", "loginId must be provide", 1002);
            }
            if (query.pwd == null)
            {
                throw new Exception_DG("pwd", "pwd must be provide", 1003);
            }
            if (query.email == null)
            {
                throw new Exception_DG("email", "email must be provide", 1004);
            }
            if (query.emailHtmlRoute == null)
            {
                throw new Exception_DG("emailHtmlRoute", "emailHtmlRoute must be provide", 1005);
            }

            string loginId = query.loginId;
            string pwd = query.pwd; //pwd must be MD5 encrypt
            string email = query.email;

            if (string.IsNullOrEmpty(loginId))
            {
                throw new Exception_DG("loginId", "loginId must be provide", 1002);
            }
            if (loginId.Length < 3)
            {
                throw new Exception_DG("loginId", "loginId cannot be less than three", 2003);
            }

            if (pwd.Length < 32)
            {
                throw new Exception_DG("pwd", "pwd must be encrypt By Md5", 2001);
            }

            Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");//email match
            if (!r.IsMatch(email))
            {
                throw new Exception_DG("email", "email format error", 2002);
            }

            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();
                int userAccountCountByloginId = channel.QueryCount(new tb_UserAccountQueryObject { QueryCondition = t => t.loginId.Equals(loginId) });
                if (userAccountCountByloginId > 0)
                {
                    throw new Exception_DG("the loginId has been exist!", 3002);
                }
            }

            Cache_Helper_DG.Cache_Add($"{loginId}", $"{pwd},{email}", null, DateTime.Now.AddMinutes(10));   //add loginId pwd into cache 10 minutes later expired

            string _link = $"{ControllerConfigs.WebAppDomain}{query.emailHtmlRoute}?loginId=" + loginId;
            Mail_Helper.SendMail(email, _link);  //send mail

            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("注册邮件已发送到您的邮箱，请查收并点击邮箱中的连接完成注册！"));
        }

        // PUT: api/Account
        public IHttpActionResult Put([FromBody]dynamic query)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }

        // DELETE: api/Account
        public IHttpActionResult Delete([FromBody]dynamic query)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }
    }
}
