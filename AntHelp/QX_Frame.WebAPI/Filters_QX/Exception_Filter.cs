using QX_Frame.Helper_DG_Framework_4_6;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace QX_Frame.WebAPI.Filters_QX
{
    /*2016-11-17 20:44:09 author:qixiao*/
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]//use multiple
    public class Exception_Filter :ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Log_Helper_DG.Log_Error($"{actionExecutedContext.Exception.Message} -- error : {actionExecutedContext.Exception.StackTrace} ", $"{actionExecutedContext.Exception.GetType().ToString()}");

            object ErrorObject = Return_Helper_DG.Object_TF_Msg_Code(false, "InternalServerErrorException", HttpStatusCode.InternalServerError);

            if (actionExecutedContext.Exception is NotImplementedException)
            {
                ErrorObject=Return_Helper_DG.Object_TF_Msg_Code(false, "NotImplementedException", HttpStatusCode.NotImplemented);
            }
            else if (actionExecutedContext.Exception is TimeoutException)
            {
                ErrorObject = Return_Helper_DG.Object_TF_Msg_Code(false, "RequestTimeoutException", HttpStatusCode.RequestTimeout);
            }
            else if (actionExecutedContext.Exception is ArgumentException)
            {
                ErrorObject=Return_Helper_DG.Object_TF_Msg_Code(false, "ArgumentException", HttpStatusCode.InternalServerError);
            }

            //.....

            else
            {
                ErrorObject=Return_Helper_DG.Object_TF_Msg_Code(false, "InternalServerErrorException", HttpStatusCode.InternalServerError);
            }

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, ErrorObject);

            base.OnException(actionExecutedContext);
        }
    }
}