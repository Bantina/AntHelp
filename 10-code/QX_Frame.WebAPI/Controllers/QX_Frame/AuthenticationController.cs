using QX_Frame.App.Web;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG;
using System;

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
                    throw new Exception_DG("appKey", "appKey error,cannot find any info by this appKey", 2004);
                }
            }
            return authentication;
        }

        /// <summary>
        /// Get Token Info
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Tuple<Guid, string, long, string, tb_Authentication> GetTokenInfoByAppKeyToken(int? appKey, string token)
        {
            if (appKey == null)
            {
                throw new Exception_DG("appKey must be provide", 1010);
            }
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception_DG("token must be provide", 1011);
            }
            tb_Authentication authentication;
            using (var fact = Wcf<AuthenticationService>())
            {
                var channel = fact.CreateChannel();
                authentication = channel.QuerySingle(new tb_AuthenticationQueryObject { QueryCondition = t => t.appkey == appKey }).Cast<tb_Authentication>();
                if (authentication == null)
                {
                    throw new Exception_DG("appKey", "appKey error,cannot find any info by this appKey", 2004);
                }
            }
            //get token array from decrypt token string 
            string[] tokenArray = Encrypt_Helper_DG.RSA_Decrypt(token, authentication.rsa_privateKey).Split('&');
            //$"{userAccount.uid}&{userAccount.loginId}&{expireTimeStamp}&{authentication.tokensign}"
            Guid uid = Guid.Parse(tokenArray[0]);
            string loginId = tokenArray[1];
            long expireTimeStamp = tokenArray[2].ToInt64();
            string tokenSign = tokenArray[3];
            return new Tuple<Guid, string, long, string, tb_Authentication>(uid, loginId, expireTimeStamp, tokenSign, authentication);
        }
    }
}
