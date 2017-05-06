using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Helper_DG;
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
     * create:2017-4-11 12:10:24 
     * */
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class TokenAttribute_DG : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            /* //WebApi Type
            int appKey = 0;
            string token = string.Empty;
            dynamic query = actionContext.ActionArguments["query"];
            HttpContextWrapper httpContext = (actionContext.Request.Properties["MS_HttpContext"] as HttpContextWrapper);
            if (actionContext.Request.Method == HttpMethod.Get)
            {
                if (!string.IsNullOrEmpty(httpContext.Request.QueryString["token"]))
                {
                    appKey = httpContext.Request.QueryString["appKey"].ToInt();
                    token = httpContext.Request.QueryString["token"];
                }
                else if (!string.IsNullOrEmpty(httpContext.Request.Form["token"]))
                {
                    token = httpContext.Request.Form["token"];
                    appKey = httpContext.Request.Form["appKey"].ToInt();
                }
                else
                {
                    throw new Exception_DG("appKey and token must be provide", 1013);
                }
            }
            else
            {
                token = query.token;
                appKey = query.appKey;
            }
            */

            //Owin Type
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

            if (appKey==0)
            {
                throw new Exception_DG("appKey","appKey must be provide", 1010);
            }

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception_DG("token","token must be provide", 1011);
            }


            //timeStamp verification
            //bool isTimeStampValid = (DateTime_Helper_DG.GetCurrentTimeStamp() - timeStamp / 1000) <= Config_Helper_DG.AppSetting_Get("RequestExpireTime").ToInt() * 60;
            //if (!isTimeStampValid)
            //{
            //    throw new Exception_DG("request expired", 3006);
            //}
            ////[random+timestamp] can be find in cache?
            //if (Cache_Helper_DG.Cache_Get($"{random}{timeStamp}") != null)
            //{
            //    throw new Exception_DG("request multiple", 3007);
            //}
            //Cache_Helper_DG.Cache_Add($"{random}{timeStamp}", 1);//add [random+timestamp] into cache


            var tokenInfo = AuthenticationController.GetTokenInfoByAppKeyToken(appKey, token);
            long expireTimeStamp = tokenInfo.Item3;
            string tokenSign = tokenInfo.Item4;

            if (expireTimeStamp<DateTime_Helper_DG.GetCurrentTimeStamp())
            {
                throw new Exception_DG("login info expired please login renew", 3011);
            }

            if (!tokenSign.Equals(tokenInfo.Item5.tokensign))
            {
                throw new Exception_DG("account login elsewhere,please login renew", 3012);
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}