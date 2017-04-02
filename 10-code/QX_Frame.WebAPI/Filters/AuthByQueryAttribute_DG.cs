using QX_Frame.Helper_DG_Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace QX_Frame.WebAPI.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]//use multiple
    public class AuthByQueryAttribute_DG : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
             ProcessFlow_Helper_DG.channel_Exception_Log(
                () =>
                {
                    string token = null;
                    dynamic query = actionContext.ActionArguments["query"];
                    HttpContextWrapper httpContext = (actionContext.Request.Properties["MS_HttpContext"] as HttpContextWrapper);
                    if (actionContext.Request.Method == HttpMethod.Get)
                    {
                        if (!string.IsNullOrEmpty(httpContext.Request.QueryString["_token"]))
                            token = httpContext.Request.QueryString["_token"];
                        else if (!string.IsNullOrEmpty(query._token.ToString()))
                            token = query._token.ToString();
                        else
                            token = default(string);
                    }
                    else
                    {
                        token = query._token.ToString() ?? null;
                    }
                    // token= Convert_Helper_DG.Json_To_T<dynamic>(String_Helper_DG.get_String_By_Stream(httpContext.Request.InputStream)).token;

                    //if (new QX_Frame_Token_Service().IsTokenPass(token, out errorMsg))
                    //    base.OnActionExecuting(actionContext);
                    //else
                    //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Redirect, Return_Helper_DG.Object_TF_Msg_Code_Uri(false, errorMsg, HttpStatusCode.Redirect, "/QX_User/Login"));
                },
                () =>
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Redirect, Return_Helper_DG.Error_EMsg_Ecode_Elevel_HttpCode("Invalid Token !",1));
                }, "Filter_AuthAuth_By_query_Filter");
        }
    }
}