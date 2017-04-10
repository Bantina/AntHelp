using QX_Frame.App.Web;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.Helper_DG_Framework.Extends;
using System;
using System.Linq.Expressions;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
    /**
     * author:qixiao
     * time:2017-4-4 21:58:32
     * */
    public class UserController : WebApiControllerBase
    {
        // GET: api/User
        public IHttpActionResult Get(dynamic query)
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

            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();

                int totalCount = 0;
                tb_UserAccountInfo userAccountInfo = channel.QuerySingle(new tb_UserAccountInfoQueryObject { QueryCondition = t => t.loginId.Equals(loginId) }).Cast<tb_UserAccountInfo>(out totalCount);
                UserAccountInfoViewModel userAccountInfoViewModel = new UserAccountInfoViewModel
                {
                    uid = userAccountInfo.uid,
                    loginId = userAccountInfo.loginId,
                    nickName = userAccountInfo.nickName,
                    email = userAccountInfo.email,
                    phone = userAccountInfo.phone,
                    headImageUrl = userAccountInfo.headImageUrl,
                    age = userAccountInfo.age,
                    sexName = userAccountInfo.tb_Sex.sexName.Trim(),
                    birthday = userAccountInfo.birthday,
                    bloodTypeName = userAccountInfo.tb_BloodType.bloodTypeName.Trim(),
                    position = userAccountInfo.position,
                    school = userAccountInfo.school,
                    location = userAccountInfo.location,
                    company = userAccountInfo.company,
                    constellation = userAccountInfo.constellation,
                    chineseZodiac = userAccountInfo.chineseZodiac,
                    personalizedSignature = userAccountInfo.personalizedSignature,
                    personalizedDescription = userAccountInfo.personalizedDescription,
                    registerTime=userAccountInfo.registerTime
                };

                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get user by loginId", userAccountInfoViewModel, totalCount));
            }
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

            userAccount.pwd = pwd_mail_cache.ToString().Split(',')[0];

            Transaction_Helper_DG.Transaction(() =>
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
                    addSuccess = addSuccess && channel.Add(new tb_UserAccountInfo { uid = userAccount.uid, loginId = userAccount.loginId, email = pwd_mail_cache.ToString().Split(',')[1] ,registerTime=DateTime.Now});
                }
                //add tb_UserRole
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
            });

            if (!addSuccess)
            {
                throw new Exception_DG("register error.", 3004);
            }

            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("register user succeed!", new { loginId = userAccount.loginId }));
        }

        // PUT: api/User
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

            using (var fact=Wcf<UserAccountInfoService>())
            {
                var channel = fact.CreateChannel();
                tb_UserAccountInfo userAccountInfo = channel.QuerySingle(new tb_UserAccountInfoQueryObject { QueryCondition = t => t.location.Equals(loginId) }).Cast<tb_UserAccountInfo>();

                if (userAccountInfo==null)
                {
                    throw new Exception_DG("no user account found by loginId",3001);
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
            }

            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("update user account info secceed"));
        }

        // DELETE: api/User
        public IHttpActionResult Delete(dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }

            tb_UserAccountInfo userAccountInfoQuery = tb_UserAccountInfo.Build();

            if (query.loginId != null)
            {
                userAccountInfoQuery.loginId = query.loginId;
            }
            if (query.uid != null)
            {
                userAccountInfoQuery.uid =Guid.Parse(query.uid);
            }

            bool isSucceed = true;

            //transaction delete multiple tb
            Transaction_Helper_DG.Transaction(() =>
            {
                tb_UserAccount userAccount;
                using (var fact = Wcf<UserAccountService>())
                {
                    var channel = fact.CreateChannel();
                    userAccount = channel.QuerySingle(new tb_UserAccountQueryObject { QueryCondition = t => t.loginId.Equals(userAccountInfoQuery.loginId) || t.uid == userAccountInfoQuery.uid }).Cast<tb_UserAccount>();
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
            });

            if (!isSucceed)
            {
                throw new Exception_DG("delete faild.", 3005);
            }
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("delete succeed !"));
        }
    }
}
