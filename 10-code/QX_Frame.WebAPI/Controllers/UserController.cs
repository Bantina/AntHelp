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
            if (query==null)
            {
                throw new ArgumentNullException("uid/loginid", "uid or loginid must be provide");
            }

            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();

                tb_UserAccountInfo userAccountInfoQuery = tb_UserAccountInfo.Build();
                userAccountInfoQuery.uid = query.uid;
                userAccountInfoQuery.loginId = query.loginid;


                Expression<Func<tb_UserAccountInfo, bool>> func = t => false;

                if (userAccountInfoQuery.uid!=null)
                {
                    func = func.Or(t => t.uid.Equals(userAccountInfoQuery.uid));
                }
                if (string.IsNullOrEmpty(userAccountInfoQuery.loginId))
                {
                    func = func.Or(t => t.loginId.Equals(userAccountInfoQuery.loginId));
                }

                int totalCount=0;
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

                return Json(Return_Helper_DG.Success_Desc_Data_DCount_HttpCode("get user by loginid or uid", userAccountInfoViewModel, totalCount));
            }
        }

        // POST: api/User
        public IHttpActionResult Post(dynamic query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("loginid/pwd", "loginid and pwd must be provide");
            }

            bool addSuccess = true;

            tb_UserAccount userAccount = tb_UserAccount.Build();
            userAccount.uid = Guid.NewGuid();
            userAccount.loginId = query.loginid;
            userAccount.pwd = query.pwd;

            //add tb_UserAccount
            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();
                int userAccountCountByLoginId = channel.QueryCount(new tb_UserAccountQueryObject { QueryCondition = t => t.loginId == userAccount.loginId });
                if (userAccountCountByLoginId > 0)
                {
                    return Json(Return_Helper_DG.Error_EMsg_Ecode_Elevel_HttpCode("the loginid has been exist!"));
                }
                addSuccess = addSuccess && channel.Add(userAccount);
            }
            //add tb_UserAccountInfo
            using (var fact = Wcf<UserAccountInfoService>())
            {
                var channel = fact.CreateChannel();
                addSuccess = addSuccess && channel.Add(new tb_UserAccountInfo { uid = userAccount.uid,loginId=userAccount.loginId });
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

            if (addSuccess)
            {
                return Json(Return_Helper_DG.Success_Desc_Data_DCount_HttpCode("register user succeed!", new { loginid = userAccount.loginId }));
            }
            return Json(Return_Helper_DG.Error_EMsg_Ecode_Elevel_HttpCode("register error!"));
        }

        // PUT: api/User
        public IHttpActionResult Put()
        {
            return null;
        }

        // DELETE: api/User
        public IHttpActionResult Delete(dynamic query)
        {
            tb_UserAccountInfo userAccountInfoQuery = tb_UserAccountInfo.Build();
            userAccountInfoQuery.loginId = query.loginid;
            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();
                tb_UserAccount userAccount = channel.QuerySingle(new tb_UserAccountQueryObject { QueryCondition = t => t.loginId.Equals(userAccountInfoQuery.loginId) }).Cast<tb_UserAccount>();
                bool isSucceed = channel.Delete(userAccount);
                if (isSucceed)
                {
                    return Json(Return_Helper_DG.Success_Desc_Data_DCount_HttpCode("delete succeed !"));
                }
            }
            return Json(Return_Helper_DG.Error_EMsg_Ecode_Elevel_HttpCode("delete faild !"));
        }

        /**
         * author:qixiao
         * time:2017-4-4 21:58:14
         * User Account Helper
         **/
        /// <summary>
        /// get userAccount by login id
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static tb_UserAccount GetUserByLoginId(string loginId)
        {
            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();
                return channel.QuerySingle(new tb_UserAccountQueryObject { QueryCondition = t => t.loginId.Equals(loginId) }).Cast<tb_UserAccount>();
            }
        }
    }
}
