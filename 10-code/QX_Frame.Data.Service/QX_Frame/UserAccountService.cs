using QX_Frame.App.Base;
using QX_Frame.Data.Contract.QX_Frame;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.Helper_DG_Framework.Extends;

namespace QX_Frame.Data.Service.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-08 18:45:37
	/// </summary>

	/// <summary>
	/// class UserAccountService
	/// </summary>
	public class UserAccountService:WcfService, IUserAccountService
	{
		private tb_UserAccount _tb_UserAccount;
		/// <summary>
		/// construction method
		/// </summary>
		public UserAccountService()
		{}

		public UserAccountService(tb_UserAccount tb_UserAccount)
		{
			this._tb_UserAccount = tb_UserAccount;
		}
		public bool Add(tb_UserAccount tb_UserAccount)
		{
			return tb_UserAccount.Add(tb_UserAccount);
		}
		public bool Update(tb_UserAccount tb_UserAccount)
		{
			return tb_UserAccount.Update(tb_UserAccount);
		}
		public bool Delete(tb_UserAccount tb_UserAccount)
		{
			return tb_UserAccount.Delete(tb_UserAccount);
		}
        /// <summary>
        /// Get UserAccount By LoginId
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <returns></returns>
        public tb_UserAccount GetUserAccountByLoginId(string loginId)
        {
            if (string.IsNullOrEmpty(loginId))
            {
                throw new Exception_DG("loginId must be provide", 1002);
            }

            tb_UserAccount userAccount = Cache_Helper_DG.Cache_Get(loginId) as tb_UserAccount;

            if (userAccount != null)
            {
                return userAccount;
            }

            userAccount = QuerySingle(new tb_UserAccountQueryObject { QueryCondition = t => t.loginId.Equals(loginId.Trim()) }).Cast<tb_UserAccount>();
            if (userAccount == null)
            {
                throw new Exception_DG("no user account found by loginId , account not exist", 3001);
            }
            Cache_Helper_DG.Cache_Add(loginId, userAccount);
            return userAccount;
        }

    }
}
