using QX_Frame.App.Base;
using QX_Frame.Data.Contract.QX_Frame;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Helper_DG;
using System;

namespace QX_Frame.Data.Service.QX_Frame
{
    /// <summary>
    /// copyright qixiao code builder ->
    /// version:4.2.0
    /// author:qixiao(柒小)
    /// time:2017-04-08 18:45:48
    /// </summary>

    /// <summary>
    /// class UserAccountInfoService
    /// </summary>
    public class UserAccountInfoService : WcfService, IUserAccountInfoService
    {
        private tb_UserAccountInfo _tb_UserAccountInfo;
        /// <summary>
        /// construction method
        /// </summary>
        public UserAccountInfoService()
        { }

        public UserAccountInfoService(tb_UserAccountInfo tb_UserAccountInfo)
        {
            this._tb_UserAccountInfo = tb_UserAccountInfo;
        }
        public bool Add(tb_UserAccountInfo tb_UserAccountInfo)
        {
            return tb_UserAccountInfo.Add(tb_UserAccountInfo);
        }
        public bool Update(tb_UserAccountInfo tb_UserAccountInfo)
        {
            return tb_UserAccountInfo.Update(tb_UserAccountInfo);
        }
        public bool Delete(tb_UserAccountInfo tb_UserAccountInfo)
        {
            return tb_UserAccountInfo.Delete(tb_UserAccountInfo);
        }
        /// <summary>
        /// Get UserAccountInfo By Uid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public tb_UserAccountInfo GetUserAccountInfoByUid(Guid uid)
        {
            tb_UserAccountInfo userAccountInfo = Cache_Helper_DG.Cache_Get(uid.ToString()) as tb_UserAccountInfo;
            if (userAccountInfo != null)
            {
                return userAccountInfo;
            }
            userAccountInfo = QuerySingle(new tb_UserAccountInfoQueryObject { QueryCondition = t => t.uid == uid }).Cast<tb_UserAccountInfo>();
            if (userAccountInfo == null)
            {
                throw new Exception_DG("no user account found by uid , account not exist", 3001);
            }
            Cache_Helper_DG.Cache_Add(uid.ToString(), userAccountInfo);
            return userAccountInfo;
        }

        public tb_UserAccountInfo GetUserAccountInfoByUidAllowNull(Guid uid)
        {
            tb_UserAccountInfo userAccountInfo = Cache_Helper_DG.Cache_Get(uid.ToString()) as tb_UserAccountInfo;
            if (userAccountInfo != null)
            {
                return userAccountInfo;
            }
            userAccountInfo = QuerySingle(new tb_UserAccountInfoQueryObject { QueryCondition = t => t.uid == uid }).Cast<tb_UserAccountInfo>();
            return userAccountInfo;
        }
        public tb_UserAccountInfo GetUserAccountInfoByLoginId(string loginId)
        {
            if (string.IsNullOrEmpty(loginId))
            {
                throw new Exception_DG("loginId must be provide", 1002);
            }
            tb_UserAccountInfo userAccountInfo = Cache_Helper_DG.Cache_Get(loginId + "Info") as tb_UserAccountInfo;
            if (userAccountInfo != null)
            {
                return userAccountInfo;
            }
            userAccountInfo = QuerySingle(new tb_UserAccountInfoQueryObject { QueryCondition = t => t.loginId.Equals(loginId) }).Cast<tb_UserAccountInfo>();
            if (userAccountInfo == null)
            {
                throw new Exception_DG("no user account found by loginId , account not exist", 3001);
            }
            Cache_Helper_DG.Cache_Add(loginId + "Info", userAccountInfo);
            return userAccountInfo;
        }

        public tb_UserAccountInfo GetUserAccountInfoByLoginIdAllowNull(string loginId)
        {
            if (string.IsNullOrEmpty(loginId))
            {
                throw new Exception_DG("loginId must be provide", 1002);
            }
            tb_UserAccountInfo userAccountInfo = Cache_Helper_DG.Cache_Get(loginId + "Info") as tb_UserAccountInfo;
            if (userAccountInfo != null)
            {
                return userAccountInfo;
            }
            userAccountInfo = QuerySingle(new tb_UserAccountInfoQueryObject { QueryCondition = t => t.loginId.Equals(loginId) }).Cast<tb_UserAccountInfo>();
            if (userAccountInfo != null)
            {
                Cache_Helper_DG.Cache_Add(loginId + "Info", userAccountInfo);
            }
            return userAccountInfo;
        }
    }
}
