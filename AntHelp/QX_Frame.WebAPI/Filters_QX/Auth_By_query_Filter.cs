using QX_Frame.Base.Services;
using QX_Frame.Helper_DG_Framework;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace QX_Frame.WebAPI.Filters_QX
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]//use multiple
    public class Auth_By_query_Filter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
             ProcessFlow_Helper_DG.channel_Exception_Log(
                () =>
                {
                    string token = null, errorMsg;
                    dynamic query = actionContext.ActionArguments["query"];
                    HttpContextWrapper httpContext = (actionContext.Request.Properties["MS_HttpContext"] as HttpContextWrapper);
                    if (actionContext.Request.Method == HttpMethod.Get)
                    {
                        if (!string.IsNullOrEmpty(httpContext.Request.QueryString["token"]))
                            token = httpContext.Request.QueryString["token"];
                        else if (!string.IsNullOrEmpty(query.token.ToString()))
                            token = query.token.ToString();
                        else
                            token = default(string);
                    }
                    else
                    {
                        token = query.token.ToString() ?? null;
                    }
                    // token= Convert_Helper_DG.Json_To_T<dynamic>(String_Helper_DG.get_String_By_Stream(httpContext.Request.InputStream)).token;

                    if (new QX_Frame_Token_Service().IsTokenPass(token, out errorMsg))
                        base.OnActionExecuting(actionContext);
                    else
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Redirect, Return_Helper_DG.Object_TF_Msg_Code_Uri(false, errorMsg, HttpStatusCode.Redirect, "/QX_User/Login"));
                },
                () =>
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Redirect, Return_Helper_DG.Object_TF_Msg_Code_Uri(false, "Invalid Token !", HttpStatusCode.Redirect, "/QX_User/Login"));
                }, "Filter_AuthAuth_By_query_Filter");
        }
    }

    //cross site
    public class CrossSiteAttribute : ActionFilterAttribute
    {
        private const string Origin = "Origin";
        private const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        private const string originHeaderdefault = "*";
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.Add(AccessControlAllowOrigin, originHeaderdefault);
        }
    }
}