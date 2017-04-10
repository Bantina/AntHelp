using System.Web.Http;
using WebActivatorEx;
using QX_Frame.Web.Srv;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace QX_Frame.Web.Srv
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            config.EnableSwagger(
                c =>
                 {
                     c.SingleApiVersion("v1", "SwaggerApiDemo");
                    // c.IncludeXmlComments(GetXmlCommentsPath());
                 })
                .EnableSwaggerUi(c =>
                {
                });
        }
        private static string GetXmlCommentsPath()
        {
            return string.Format("{0}/SwaggerApiDemo.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
