using QX_Frame.App.Base;
using QX_Frame.Data.Contract.QX_Frame;
using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Service.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-08 18:46:25
	/// </summary>

	/// <summary>
	/// class UserRoleAttributeService
	/// </summary>
	public class UserRoleAttributeService:WcfService, IUserRoleAttributeService
	{
		private tb_UserRoleAttribute _tb_UserRoleAttribute;
		/// <summary>
		/// construction method
		/// </summary>
		public UserRoleAttributeService()
		{}

		public UserRoleAttributeService(tb_UserRoleAttribute tb_UserRoleAttribute)
		{
			this._tb_UserRoleAttribute = tb_UserRoleAttribute;
		}
		public bool Add(tb_UserRoleAttribute tb_UserRoleAttribute)
		{
			return tb_UserRoleAttribute.Add(tb_UserRoleAttribute);
		}
		public bool Update(tb_UserRoleAttribute tb_UserRoleAttribute)
		{
			return tb_UserRoleAttribute.Update(tb_UserRoleAttribute);
		}
		public bool Delete(tb_UserRoleAttribute tb_UserRoleAttribute)
		{
			return tb_UserRoleAttribute.Delete(tb_UserRoleAttribute);
		}
	}
}
