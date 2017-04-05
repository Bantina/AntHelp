using QX_Frame.App.Base;
using QX_Frame.Data.Contract.QX_Frame;
using QX_Frame.Data.Entities.QX_Frame;
using System;

namespace QX_Frame.Data.Service.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:45:20
	/// </summary>

	/// <summary>
	/// class UserStatusService
	/// </summary>
	public class UserStatusService:WcfService, IUserStatusService
	{
		private tb_UserStatus _tb_UserStatus;
		/// <summary>
		/// construction method
		/// </summary>
		public UserStatusService()
		{}

		public UserStatusService(tb_UserStatus tb_UserStatus)
		{
			this._tb_UserStatus = tb_UserStatus;
		}
		public bool Add(tb_UserStatus tb_UserStatus)
		{
			return tb_UserStatus.Add();
		}
		public bool Update(tb_UserStatus tb_UserStatus)
		{
			return tb_UserStatus.Update();
		}
		public bool Delete(tb_UserStatus tb_UserStatus)
		{
			return tb_UserStatus.Delete();
		}
	}
}
