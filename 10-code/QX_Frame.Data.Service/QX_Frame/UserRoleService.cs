using QX_Frame.App.Base;
using QX_Frame.Data.Contract.QX_Frame;
using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Service.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-08 18:46:17
	/// </summary>

	/// <summary>
	/// class UserRoleService
	/// </summary>
	public class UserRoleService:WcfService, IUserRoleService
	{
		private tb_UserRole _tb_UserRole;
		/// <summary>
		/// construction method
		/// </summary>
		public UserRoleService()
		{}

		public UserRoleService(tb_UserRole tb_UserRole)
		{
			this._tb_UserRole = tb_UserRole;
		}
		public bool Add(tb_UserRole tb_UserRole)
		{
			return tb_UserRole.Add(tb_UserRole);
		}
		public bool Update(tb_UserRole tb_UserRole)
		{
			return tb_UserRole.Update(tb_UserRole);
		}
		public bool Delete(tb_UserRole tb_UserRole)
		{
			return tb_UserRole.Delete(tb_UserRole);
		}
	}
}
