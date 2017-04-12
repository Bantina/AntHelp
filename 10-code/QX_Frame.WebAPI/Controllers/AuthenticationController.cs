using QX_Frame.App.Web;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG_Framework.Extends;

namespace QX_Frame.WebAPI.Controllers
{
    /**
     * author:qixiao
     * create:2017-4-11 11:22:51
     * */
    public class AuthenticationController : WebApiControllerBase
    {
        /// <summary>
        /// Get Authentication By AppKey
        /// </summary>
        /// <param name="appKey">appKey</param>
        /// <returns></returns>
        public static tb_Authentication GetAuthenticationByAppKey(int appKey)
        {
            tb_Authentication authentication;
            using (var fact = Wcf<AuthenticationService>())
            {
                var channel = fact.CreateChannel();
                authentication = channel.QuerySingle(new tb_AuthenticationQueryObject
                {
                    QueryCondition = t => t.appkey == appKey
                }).Cast<tb_Authentication>();
                if (authentication == null)
                {
                    throw new Exception_DG("appKey","appKey error,cannot find any info by this appKey", 2004);
                }
            }
            return authentication;
        }
    }
}
