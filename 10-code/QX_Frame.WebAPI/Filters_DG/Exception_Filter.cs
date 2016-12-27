using QX_Frame.Helper_DG_Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace QX_Frame.WebAPI.Filters_DG
{
    /*2016-11-17 20:44:09 author:qixiao*/
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]//use multiple
    public class Exception_Filter :ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Log_Helper_DG.Log_Error($"{actionExecutedContext.Exception.Message} -- error : {actionExecutedContext.Exception.StackTrace} ", $"{actionExecutedContext.Exception.GetType().ToString()}");

            HttpStatusCode HttpCode = HttpStatusCode.OK;//the default HttpStatusCode

            if (actionExecutedContext.Exception is NotImplementedException)
            {
                HttpCode=HttpStatusCode.NotImplemented;
            }
            else if (actionExecutedContext.Exception is TimeoutException)
            {
                HttpCode = HttpStatusCode.NotImplemented;
            }
            else if (actionExecutedContext.Exception is ArgumentException)
            {
                HttpCode = HttpStatusCode.NotImplemented;
            }

            //.....

            else
            {
                HttpCode = HttpStatusCode.NotImplemented;
            }

            object ErrorObject = Return_Helper_DG.Object_TF_Msg_Code(false, $"{actionExecutedContext.Exception.Message}", HttpCode);

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpCode, ErrorObject);

            base.OnException(actionExecutedContext);
        }
    }
}