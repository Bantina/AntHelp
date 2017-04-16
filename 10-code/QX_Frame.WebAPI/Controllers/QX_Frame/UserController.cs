using QX_Frame.App.Web;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.Helper_DG_Framework.Extends;
using System.Collections.Generic;
using System;
using System.Web.Http;
using static QX_Frame.Helper_DG_Framework.Encrypt_Helper_DG;
using QX_Frame.Data.Options;
using QX_Frame.WebAPI.Filters;

namespace QX_Frame.WebAPI.Controllers
{
    /**
     * author:qixiao
     * time:2017-4-4 21:58:32
     * */
    public class UserController : WebApiControllerBase
    {
        // GET: api/User
        [LimitsAttribute_DG(RoleLevel = 0)]
        public IHttpActionResult Get(string loginId, int pageIndex, int pageSize, bool isDesc)
        {
            tb_UserAccountInfoQueryObject queryObject = new tb_UserAccountInfoQueryObject();

            queryObject.loginId = loginId;
            queryObject.PageIndex = pageIndex;
            queryObject.PageSize = pageSize;
            queryObject.IsDESC = isDesc;

            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();

                int count;
                List<tb_UserAccountInfo> userAccountInfoList = channel.QueryAllPaging<tb_UserAccountInfo, string>(queryObject, t => t.loginId).Cast<List<tb_UserAccountInfo>>(out count);
                List<UserAccountInfoViewModel> userAccountInfoViewModelList = new List<UserAccountInfoViewModel>();
                foreach (var item in userAccountInfoList)
                {
                    userAccountInfoViewModelList.Add(
                        new UserAccountInfoViewModel
                        {
                            uid = item.uid,
                            loginId = item.loginId,
                            nickName = item.nickName,
                            email = item.email,
                            phone = item.phone,
                            headImageUrl = item.headImageUrl,
                            age = item.age,
                            sexId = item.tb_Sex.sexId,
                            sexName = item.tb_Sex.sexName.Trim(),
                            birthday = item.birthday,
                            bloodTypeId = item.tb_BloodType.bloodTypeId,
                            bloodTypeName = item.tb_BloodType.bloodTypeName.Trim(),
                            position = item.position,
                            school = item.school,
                            location = item.location,
                            company = item.company,
                            constellation = item.constellation,
                            chineseZodiac = item.chineseZodiac,
                            personalizedSignature = item.personalizedSignature,
                            personalizedDescription = item.personalizedDescription,
                            registerTime = item.registerTime
                        });
                }
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get user info must paging by pageindex=num,pagesize=num,isdesc=1/0", userAccountInfoViewModelList, count));
            }
        }

        // GET: api/User/id
        [LimitsAttribute_DG(RoleLevel = 0)]
        public IHttpActionResult Get(string id)
        {
            string loginId = id;

            if (string.IsNullOrEmpty(loginId))
            {
                throw new Exception_DG("loginId must be provide", 1002);
            }

            tb_UserAccountInfo userAccountInfo = Cache_Helper_DG.Cache_Get(loginId + "Info") as tb_UserAccountInfo;

            if (userAccountInfo == null)
            {
                using (var fact = Wcf<UserAccountService>())
                {
                    var channel = fact.CreateChannel();

                    userAccountInfo = channel.QuerySingle(new tb_UserAccountInfoQueryObject { QueryCondition = t => t.loginId.Equals(loginId) }).Cast<tb_UserAccountInfo>();
                }
            }

            if (userAccountInfo == null)
            {
                throw new Exception_DG("no user account found by loginId", 3001);
            }

            UserAccountInfoViewModel userAccountInfoViewModel = new UserAccountInfoViewModel
            {
                uid = userAccountInfo.uid,
                loginId = userAccountInfo.loginId,
                nickName = userAccountInfo.nickName,
                email = userAccountInfo.email,
                phone = userAccountInfo.phone,
                headImageUrl = userAccountInfo.headImageUrl,
                age = userAccountInfo.age,
                sexId = userAccountInfo.tb_Sex.sexId,
                sexName = userAccountInfo.tb_Sex.sexName.Trim(),
                birthday = userAccountInfo.birthday,
                bloodTypeId = userAccountInfo.tb_BloodType.bloodTypeId,
                bloodTypeName = userAccountInfo.tb_BloodType.bloodTypeName.Trim(),
                position = userAccountInfo.position,
                school = userAccountInfo.school,
                location = userAccountInfo.location,
                company = userAccountInfo.company,
                constellation = userAccountInfo.constellation,
                chineseZodiac = userAccountInfo.chineseZodiac,
                personalizedSignature = userAccountInfo.personalizedSignature,
                personalizedDescription = userAccountInfo.personalizedDescription,
                registerTime = userAccountInfo.registerTime
            };

            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get user by loginId", userAccountInfoViewModel, 1));
        }

        // POST: api/User/loginId  mail click register api
        public IHttpActionResult Post(string loginId)
        {
            if (string.IsNullOrEmpty(loginId))
            {
                throw new Exception_DG("loginId", "loginId must be provide.", 1002);
            }

            bool addSuccess = true;

            tb_UserAccount userAccount = tb_UserAccount.Build();
            userAccount.uid = Guid.NewGuid();
            userAccount.loginId = loginId;

            object pwd_mail_cache = Cache_Helper_DG.Cache_Get(loginId);//get pwd and mail from cache

            if (pwd_mail_cache == null)
            {
                throw new Exception_DG("register info expired,please register renew.", 3003);
            }

            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();
                int userAccountCountByloginId = channel.QueryCount(new tb_UserAccountQueryObject { QueryCondition = t => t.loginId.Equals(loginId) });
                if (userAccountCountByloginId > 0)
                {
                    throw new Exception_DG("the loginId has been exist!", 3002);
                }
            }


            userAccount.pwd = pwd_mail_cache.ToString().Split(',')[0];

            Transaction_Helper_DG.Transaction((Action)(() =>
            {
                //add tb_UserAccount
                using (var fact = Wcf<UserAccountService>())
                {
                    var channel = fact.CreateChannel();
                    addSuccess = addSuccess && channel.Add(userAccount);
                }
                //add tb_UserAccountInfo
                using (var fact = Wcf<UserAccountInfoService>())
                {
                    var channel = fact.CreateChannel();
                    addSuccess = addSuccess && channel.Add(new tb_UserAccountInfo { uid = userAccount.uid, loginId = userAccount.loginId, nickName = loginId, email = pwd_mail_cache.ToString().Split(',')[1], registerTime = DateTime.Now, birthday = DateTime.Now });
                }
                //add tb_UserStatus
                using (var fact = Wcf<UserRoleService>())
                {
                    var channel = fact.CreateChannel();
                    addSuccess = addSuccess && channel.Add(new tb_UserRole { uid = userAccount.uid, roleLevel = 0 });
                }
                //add tb_UserStatus
                using (var fact = Wcf<UserStatusService>())
                {
                    var channel = fact.CreateChannel();
                    addSuccess = addSuccess && channel.Add(new tb_UserStatus { uid = userAccount.uid, statusLevel = 0 });
                }
            }));

            if (!addSuccess)
            {
                throw new Exception_DG("register error.", 3004);
            }

            long timeStamp = DateTime_Helper_DG.GetCurrentTimeStamp() * 1000;
            int random = new Random().Next(100, 999);
            //get rsa keys
            RSA_Keys rsa_Keys = RSA_GetKeys();

            tb_Authentication authentication;
            using (var fact = Wcf<AuthenticationService>())
            {
                var channel = fact.CreateChannel();

                authentication = channel.QuerySingle(new tb_AuthenticationQueryObject { QueryCondition = t => t.loginId.Equals(loginId) }).Cast<tb_Authentication>();

                if (authentication == null)
                {
                    authentication = tb_Authentication.Build();
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
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("register user succeed , login succeed", new { loginId = userAccount.loginId, appKey = authentication.appkey, secretKey = authentication.secretkey, token = token }, 1));
        }

        // PUT: api/User
        [LimitsAttribute_DG(RoleLevel = 0)]
        public IHttpActionResult Put(dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }

            string loginId = query.loginId;

            if (string.IsNullOrEmpty(loginId))
            {
                throw new Exception_DG("loginId must be provide", 1002);
            }

            //-------- permission check
            int appKey = query.appKey;
            string token = query.token;

            var tokenInfo = AuthenticationController.GetTokenInfoByAppKeyToken(appKey, token);
            Guid uid = tokenInfo.Item1;
            string currentLoginId = tokenInfo.Item2;
            tb_UserRole userRole = UserRoleController.GetUserRoleByUid(uid);
            if (!currentLoginId.Equals(loginId))
            {
                throw new Exception_DG("do not have enough of permission", 3020);
            }
            //--------------

            using (var fact = Wcf<UserAccountInfoService>())
            {
                var channel = fact.CreateChannel();
                tb_UserAccountInfo userAccountInfo = channel.QuerySingle(new tb_UserAccountInfoQueryObject { QueryCondition = t => t.loginId.Equals(loginId) }).Cast<tb_UserAccountInfo>();

                if (userAccountInfo == null)
                {
                    throw new Exception_DG("no user account found by loginId", 3001);
                }

                userAccountInfo.nickName = query.nickName;
                userAccountInfo.phone = query.phone;
                userAccountInfo.headImageUrl = query.headImageUrl;
                userAccountInfo.age = Convert.ToInt32(query.age);
                userAccountInfo.sexId = Convert.ToInt32(query.sexId);
                userAccountInfo.birthday = query.birthday;
                userAccountInfo.bloodTypeId = Convert.ToInt32(query.bloodTypeId);
                userAccountInfo.position = query.position;
                userAccountInfo.school = query.school;
                userAccountInfo.location = query.location;
                userAccountInfo.company = query.company;
                userAccountInfo.constellation = query.constellation;
                userAccountInfo.chineseZodiac = query.chineseZodiac;
                userAccountInfo.personalizedSignature = query.personalizedSignature;
                userAccountInfo.personalizedDescription = query.personalizedDescription;

                channel.Update(userAccountInfo);

                Cache_Helper_DG.Cache_Add(loginId + "Info", userAccountInfo);
            }

            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("update user account info secceed"));
        }

        // DELETE: api/User
        [LimitsAttribute_DG(RoleLevel = 0)]
        public IHttpActionResult Delete(dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }

            string loginId = query.loginId;
            if (string.IsNullOrEmpty(loginId))
            {
                throw new Exception_DG("loginId must be provide", 1002);
            }

            //-------- permission check
            int appKey = query.appKey;
            string token = query.Token;

            var tokenInfo = AuthenticationController.GetTokenInfoByAppKeyToken(appKey, token);
            Guid uid = tokenInfo.Item1;
            string currentLoginId = tokenInfo.Item2;
            tb_UserRole currentUserRole = UserRoleController.GetUserRoleByUid(uid);
            if ((currentUserRole.roleLevel < opt_AccountRoleLevel.ADMINISTRATOR.ToInt()) && (!currentLoginId.Equals(loginId)))
            {
                throw new Exception_DG("do not have enough of permission", 3020);
            }
            //--------------

            bool isSucceed = true;

            //transaction delete multiple tb
            Transaction_Helper_DG.Transaction((Action)(() =>
            {
                tb_UserAccount userAccount;
                using (var fact = Wcf<UserAccountService>())
                {
                    var channel = fact.CreateChannel();
                    userAccount = channel.QuerySingle(new tb_UserAccountQueryObject { QueryCondition = t => t.loginId.Equals(loginId) }).Cast<tb_UserAccount>();
                    isSucceed = isSucceed && channel.Delete(userAccount);
                }
                using (var fact = Wcf<UserAccountInfoService>())
                {
                    var channel = fact.CreateChannel();
                    tb_UserAccountInfo userAccountInfo = channel.QuerySingle(new tb_UserAccountInfoQueryObject { QueryCondition = t => t.uid == userAccount.uid }).Cast<tb_UserAccountInfo>();
                    isSucceed = isSucceed && channel.Delete(userAccountInfo);
                }
                using (var fact = Wcf<UserRoleService>())
                {
                    var channel = fact.CreateChannel();
                    tb_UserRole userRole = channel.QuerySingle(new tb_UserRoleQueryObject { QueryCondition = t => t.uid == userAccount.uid }).Cast<tb_UserRole>();
                    isSucceed = isSucceed && channel.Delete(userRole);
                }
                using (var fact = Wcf<UserStatusService>())
                {
                    var channel = fact.CreateChannel();
                    tb_UserStatus userStatus = channel.QuerySingle(new tb_UserStatusQueryObject { QueryCondition = t => t.uid == userAccount.uid }).Cast<tb_UserStatus>();
                    isSucceed = isSucceed && channel.Delete(userStatus);
                }
            }));

            if (!isSucceed)
            {
                throw new Exception_DG("delete faild.", 3005);
            }
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("delete succeed !"));
        }

        public static tb_UserAccountInfo GetUserAccountInfoByUid(Guid uid)
        {
            using (var fact = Wcf<UserAccountInfoService>())
            {
                var channel = fact.CreateChannel();
                return channel.GetUserAccountInfoByUid(uid);
            }
        }

        public static tb_UserAccountInfo GetUserAccountInfoByUidAllowNull(Guid uid)
        {
            using (var fact = Wcf<UserAccountInfoService>())
            {
                var channel = fact.CreateChannel();
                return channel.GetUserAccountInfoByUidAllowNull(uid);
            }
        }

        public static tb_UserAccountInfo GetUserAccountInfoByLoginId(string loginId)
        {
            using (var fact=Wcf<UserAccountInfoService>())
            {
                var channel = fact.CreateChannel();
                return channel.GetUserAccountInfoByLoginId(loginId);
            }
        }

        public static tb_UserAccountInfo GetUserAccountInfoByLoginIdAllowNull(string loginId)
        {
            using (var fact = Wcf<UserAccountInfoService>())
            {
                var channel = fact.CreateChannel();
                return channel.GetUserAccountInfoByLoginIdAllowNull(loginId);
            }
        }

    }
}
