using QX_Frame.WebAPI.Filters_DG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QX_Frame.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services
            //跨域配置
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            // Web API routes

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //if config the global filter input there need not write the attributes
            config.Filters.Add(new Exception_Filter());
        }
    }
}
