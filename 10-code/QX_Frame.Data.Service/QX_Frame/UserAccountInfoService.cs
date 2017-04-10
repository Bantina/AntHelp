using QX_Frame.App.Base;
using QX_Frame.Data.Contract.QX_Frame;
using QX_Frame.Data.Entities.QX_Frame;

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
	public class UserAccountInfoService:WcfService, IUserAccountInfoService
	{
		private tb_UserAccountInfo _tb_UserAccountInfo;
		/// <summary>
		/// construction method
		/// </summary>
		public UserAccountInfoService()
		{}

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
	}
}
