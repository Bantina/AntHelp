using QX_Frame.App.Web;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.Helper_DG_Framework.Extends;
using QX_Frame.WebAPI.Filters;
using System;
using System.Web.Http;
using static QX_Frame.Helper_DG_Framework.Encrypt_Helper_DG;

namespace QX_Frame.WebAPI.Controllers
{
    /// <summary>
    /// copyright qixiao code builder ->
    /// version:4.2.0
    /// author:qixiao(柒小)
    /// time:2017-04-10 11:08:30
    /// </summary>

    /// <summary>
    ///class LoginController
    /// </summary>
    public class LoginController : WebApiControllerBase
    {
        // GET: api/Login
        public IHttpActionResult Get([FromBody]dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }
            if (query.appKey ==null)
            {
                throw new Exception_DG("appKey", "appKey must be provide", 1010);
            }
            if (query.random == null)
            {
                throw new Exception_DG("random must be provide", 1006);
            }
            if (query.timeStamp == null)
            {
                throw new Exception_DG("timeStamp must be provide", 1007);
            }
            if (query.token==null)
            {
                throw new Exception_DG("token", "token must be provide", 1011);
            }

            int random = query.random;
            long timeStamp = query.timeStamp;
            string token = query.token;
            int appKey = query.appKey;

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
            string[] tokenArray = Encrypt_Helper_DG.RSA_Decrypt(token, authentication.rsa_privateKey).Split('&');
            //$"{userAccount.uid}&{userAccount.loginId}&{expireTimeStamp}&{authentication.tokensign}"
            long expireTimeStamp = tokenArray[2].ToInt64();
            string tokenSign = tokenArray[3];

            if (expireTimeStamp < DateTime_Helper_DG.GetCurrentTimeStamp())
            {
                throw new Exception_DG("login info expired please login renew", 3011);
            }

            if (!tokenSign.Equals(authentication.tokensign))
            {
                throw new Exception_DG("account login elsewhere,please login renew", 3012);
            }

            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("account has been login",new { loginId=authentication.loginId},1));
        }

        // GET: api/Login/5
        public IHttpActionResult Get(string id, [FromBody]dynamic query)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }

        // POST: api/Login
        public IHttpActionResult Post([FromBody]dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }
            if (query.loginId == null)
            {
                throw new Exception_DG("loginId must be provide", 1002);
            }
            if (query.random == null)
            {
                throw new Exception_DG("random must be provide", 1006);
            }
            if (query.timeStamp == null)
            {
                throw new Exception_DG("timeStamp must be provide", 1007);
            }
            if (query.secretString == null)
            {
                throw new Exception_DG("secretString must be provide", 1009);
            }

            string loginId = query.loginId;
            int random = query.random;
            long timeStamp = query.timeStamp;
            string secretString = query.secretString;

            //timeStamp verification
            bool isTimeStampValid =( DateTime_Helper_DG.GetCurrentTimeStamp() - timeStamp / 1000)<= Config_Helper_DG.AppSetting_Get("RequestExpireTime").ToInt() * 60;
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

            //get MD5[pwd] from database
            tb_UserAccount userAccount;
            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();
                userAccount = channel.QuerySingle(new tb_UserAccountQueryObject { QueryCondition = t => t.loginId.Equals(loginId.Trim()) }).Cast<tb_UserAccount>();
            }

            if (userAccount == null)
            {
                throw new Exception_DG("no user account found by loginId", 3001);
            }

            //MD5[loginid+MD5[pwd]+ramdom+timestamp]==MD5[secretMessage]?
            bool secretStringMatched = MD5_Encrypt($"{loginId}{userAccount.pwd}{random}{timeStamp}").Equals(secretString);
            if (!secretStringMatched)
            {
                throw new Exception_DG("the request has been tampered also mains account or pwd error", 3008);
            }

            //get rsa keys
            RSA_Keys rsa_Keys = RSA_GetKeys();

            tb_Authentication authentication;
            using (var fact = Wcf<AuthenticationService>())
            {
                var channel = fact.CreateChannel();

                authentication = channel.QuerySingle(new tb_AuthenticationQueryObject { QueryCondition = t => t.loginId.Equals(loginId) }).Cast<tb_Authentication>();

                if (authentication==null)
                {
                    authentication =tb_Authentication.Build();
                    //secretKey=MD5[loginid+MD5[pwd]+timestamp]
                    authentication.secretkey = MD5_Encrypt($"{loginId}{userAccount.pwd}{timeStamp}");
                    authentication.rsa_publicKey = rsa_Keys.publicKey;
                    authentication.rsa_privateKey = rsa_Keys.privateKey;
                    authentication.loginId = loginId;
                    //tokenSign=MD5[loginid+logintimestamp+random]
                    authentication.tokensign = MD5_Encrypt($"{loginId}{timeStamp}{random}");
                    if (channel.Add(authentication))
                    {
                        authentication = channel.QuerySingle(new tb_AuthenticationQueryObject { QueryCondition = t => t.loginId.Equals(loginId) }).Cast<tb_Authentication>();
                    }
                }
                else
                {
                    //secretKey=MD5[loginid+MD5[pwd]+timestamp]
                    authentication.secretkey = MD5_Encrypt($"{loginId}{userAccount.pwd}{timeStamp}");
                    authentication.rsa_publicKey = rsa_Keys.publicKey;
                    authentication.rsa_privateKey = rsa_Keys.privateKey;
                    authentication.loginId = loginId;
                    //tokenSign=MD5[loginid+logintimestamp+random]
                    authentication.tokensign = MD5_Encrypt($"{loginId}{timeStamp}{random}");
                    channel.Update(authentication);
                }
            }

            int Auth_Token_ExpireTime_days = Config_Helper_DG.AppSetting_Get("Auth_Token_ExpireTime_days").ToInt();
            int Auth_Token_ExpireTime_hours = Config_Helper_DG.AppSetting_Get("Auth_Token_ExpireTime_hours").ToInt();
            int Auth_Token_ExpireTime_minutes = Config_Helper_DG.AppSetting_Get("Auth_Token_ExpireTime_minutes").ToInt();
            long expireTimeStamp = DateTime_Helper_DG.GetTimeStampByDateTimeUtc(DateTime.UtcNow.AddDays(Auth_Token_ExpireTime_days).AddHours(Auth_Token_ExpireTime_hours).AddMinutes(Auth_Token_ExpireTime_minutes));
            //token=RSA_publicKey[uid+loginid+expiretimestamp+tokensign]
            string token = RSA_Encrypt($"{userAccount.uid}&{userAccount.loginId}&{expireTimeStamp}&{authentication.tokensign}", authentication.rsa_publicKey);
            //send appkey,secretkey,token,userInfo to client
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("login succeed", new { loginId = loginId, appKey = authentication.appkey, secretKey = authentication.secretkey, token = token }, 1));
        }

        // PUT: api/Login
        public IHttpActionResult Put([FromBody]dynamic query)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }

        // DELETE: api/Login
        public IHttpActionResult Delete([FromBody]dynamic query)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }
    }
}
