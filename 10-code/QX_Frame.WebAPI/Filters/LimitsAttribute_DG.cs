using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.Options;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.Helper_DG_Framework.Extends;
using QX_Frame.WebAPI.Controllers;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace QX_Frame.WebAPI.Filters
{
    /**
     * author:qixiao
     * create:2017-4-13 10:46:17
     * */
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]//多次调用
    public class LimitsAttribute_DG : ActionFilterAttribute
    {
        public int RoleLevel { get; set; } = 0;
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            int appKey = 0;
            string token = string.Empty;
            Microsoft.Owin.OwinContext httpContext = actionContext.Request.Properties["MS_OwinContext"] as Microsoft.Owin.OwinContext;
            if (actionContext.Request.Method == HttpMethod.Get)
            {
                if (!string.IsNullOrEmpty(httpContext.Request.Query["token"]))
                {
                    appKey = httpContext.Request.Query["appKey"].ToInt();
                    token = httpContext.Request.Query["token"];
                }
                else
                {
                    throw new Exception_DG("appKey and token must be provide", 1013);
                }
            }
            else
            {
                dynamic query = actionContext.ActionArguments["query"];
                token = query.token;
                appKey = query.appKey;
            }

            if (appKey == 0)
            {
                throw new Exception_DG("appKey", "appKey must be provide", 1010);
            }

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception_DG("token", "token must be provide", 1011);
            }

            var tokenInfo = AuthenticationController.GetTokenInfoByAppKeyToken(appKey, token);
            Guid uid = tokenInfo.Item1;
            string loginId = tokenInfo.Item2;
            long expireTimeStamp = tokenInfo.Item3;
            string tokenSign = tokenInfo.Item4;

            if (expireTimeStamp < DateTime_Helper_DG.GetCurrentTimeStamp())
            {
                throw new Exception_DG("login info expired please login renew", 3011);
            }
            //token->tokenSign match db->tokenSign
            if (!tokenSign.Equals(tokenInfo.Item5.tokensign))
            {
                throw new Exception_DG("account login elsewhere,please login renew", 3012);
            }

            //Limit validate
            tb_UserRole userRole = UserRoleController.GetUserRoleByUid(uid);
            if (userRole.roleLevel < this.RoleLevel)
            {
                throw new Exception_DG("do not have enough of permission", 3020);
            }

            tb_UserStatus userStatus = UserStatusController.GetUserStatusByUid(uid);
            if (userStatus.statusLevel == opt_AccountStatusLevel.NORMAL.ToInt())
            {
                // continue
            }
            else if (userStatus.statusLevel == opt_AccountStatusLevel.ABANDON.ToInt())
            {
                throw new Exception_DG("account abandoned", 3017);
            }
            else if (userStatus.statusLevel == opt_AccountStatusLevel.FREEZE.ToInt())
            {
                throw new Exception_DG("account has been frozen", 3018);
            }
            else if (userStatus.statusLevel == opt_AccountStatusLevel.STOP.ToInt())
            {
                throw new Exception_DG("account disabled", 3019);
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}