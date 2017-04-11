using QX_Frame.Data.Entities.QX_Frame;
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
     * create:2017-4-11 12:10:24 
     * */
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class TokenAttribute_DG : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            int appKey = 0;
            int random = 0;
            long timeStamp = 0;
            string token = string.Empty;
            dynamic query = actionContext.ActionArguments["query"];
            HttpContextWrapper httpContext = (actionContext.Request.Properties["MS_HttpContext"] as HttpContextWrapper);
            if (actionContext.Request.Method == HttpMethod.Get)
            {
                if (!string.IsNullOrEmpty(httpContext.Request.QueryString["token"]))
                {
                    appKey = httpContext.Request.QueryString["appKey"].ToInt();
                    random = httpContext.Request.QueryString["random"].ToInt();
                    timeStamp = httpContext.Request.QueryString["timeStamp"].ToInt64();
                    token = httpContext.Request.QueryString["token"];
                }
                else
                {
                    token = query.token;
                    appKey = query.appKey;
                    random = query.random;
                    timeStamp = query.timeStamp;
                }
            }
            else
            {
                token = query.token;
                appKey = query.appKey;
                random = query.random;
                timeStamp = query.timeStamp;
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
            bool isTimeStampValid = (DateTime_Helper_DG.GetCurrentTimeStamp() - timeStamp / 1000) <= Config_Helper_DG.AppSetting_Get("RequestExpireTime").ToInt() * 60;
            if (!isTimeStampValid)
            {
                throw new Exception_DG("request expired", 3006);
            }
            //[random+timestamp] can be find in cache?
            if (Cache_Helper_DG.Cache_Get($"{random}{timeStamp}") != null)
            {
                throw new Exception_DG("request multiple", 3007);
            }
            Cache_Helper_DG.Cache_Add($"{random}{timeStamp}", 1);//add [random+timestamp] into cache


            tb_Authentication authentication = AuthenticationController.GetAuthenticationByAppKey(appKey);
            
            //get token array from decrypt token string 
            string[] tokenArray = Encrypt_Helper_DG.RSA_Decrypt(token, authentication.rsa_privateKey).Split('$');
            //$"{userAccount.uid}&{userAccount.loginId}&{expireTimeStamp}&{authentication.tokensign}"
            long expireTimeStamp = tokenArray[2].ToInt64();
            string tokenSign = tokenArray[3];

            if (expireTimeStamp<DateTime_Helper_DG.GetCurrentTimeStamp())
            {
                throw new Exception_DG("login info expired please login renew", 3011);
            }

            if (!tokenSign.Equals(authentication.tokensign))
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