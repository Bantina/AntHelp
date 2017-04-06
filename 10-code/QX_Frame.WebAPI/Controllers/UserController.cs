using QX_Frame.App.Web;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG_Framework;
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
                throw new ArgumentNullException("uid/loginId", "uid or loginId must be provide");
            }

            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();

                tb_UserAccountInfo userAccountInfoQuery = tb_UserAccountInfo.Build();
                userAccountInfoQuery.uid = query.uid;
                userAccountInfoQuery.loginId = query.loginId;


                Expression<Func<tb_UserAccountInfo, bool>> func = t => false;

                if (userAccountInfoQuery.uid != null)
                {
                    func = func.Or(t => t.uid.Equals(userAccountInfoQuery.uid));
                }
                if (string.IsNullOrEmpty(userAccountInfoQuery.loginId))
                {
                    func = func.Or(t => t.loginId.Equals(userAccountInfoQuery.loginId));
                }

                int totalCount = 0;
                tb_UserAccountInfo userAccountInfo = channel.QuerySingle(new tb_UserAccountInfoQueryObject { QueryCondition = func }).Cast<tb_UserAccountInfo>(out totalCount);
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
                    personalizedDescription = userAccountInfo.personalizedDescription
                };

                return Json(Return_Helper_DG.Success_Desc_Data_DCount_HttpCode("get user by loginId or uid", userAccountInfoViewModel, totalCount));
            }
        }

        // POST: api/User/loginId  mail click register api
        public IHttpActionResult Post(string loginId)
        {
            if (string.IsNullOrEmpty(loginId))
            {
                throw new ArgumentNullException("loginId", "loginId must be provide");
            }

            bool addSuccess = true;

            tb_UserAccount userAccount = tb_UserAccount.Build();
            userAccount.uid = Guid.NewGuid();
            userAccount.loginId = loginId;

            object pwd_mail_cache = Cache_Helper_DG.Cache_Get(loginId);//get pwd and mail from cache

            if (pwd_mail_cache==null)
            {
                throw new NullReferenceException("register info expired ! please register renew !");
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
                    addSuccess = addSuccess && channel.Add(new tb_UserAccountInfo { uid = userAccount.uid, loginId = userAccount.loginId,email=pwd_mail_cache.ToString().Split(',')[1]});
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
                throw new Exception("register error!");
            }
            
            return Json(Return_Helper_DG.Success_Desc_Data_DCount_HttpCode("register user succeed!", new { loginId = userAccount.loginId }));
        }

        // PUT: api/User
        public IHttpActionResult Put()
        {
            return null;
        }

        // DELETE: api/User
        public IHttpActionResult Delete(dynamic query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("loginId/uid", "uid or loginId must be provide");
            }

            tb_UserAccountInfo userAccountInfoQuery = tb_UserAccountInfo.Build();

            if (query.loginId != null)
            {
                userAccountInfoQuery.loginId = query.loginId;
            }
            if (query.uid != null)
            {
                userAccountInfoQuery.uid = query.uid;
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
                    tb_UserAccountInfo userAccountInfo = channel.QuerySingle(new tb_UserAccountInfoQueryObject { QueryCondition = t => t.uid ==userAccount.uid }).Cast<tb_UserAccountInfo>();
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
                throw new Exception("delete faild !");
            }
            return Json(Return_Helper_DG.Success_Desc_Data_DCount_HttpCode("delete succeed !"));
        }
    }
}
