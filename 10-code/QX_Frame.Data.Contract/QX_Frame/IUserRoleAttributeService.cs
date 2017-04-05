using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.1.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:30:23
	/// </summary>

	/// <summary>
	/// interface IUserRoleAttributeService
	/// </summary>
	public interface IUserRoleAttributeService
	{
		bool Add(tb_UserRoleAttribute tb_UserRoleAttribute);
		bool Update(tb_UserRoleAttribute tb_UserRoleAttribute);
		bool Delete(tb_UserRoleAttribute tb_UserRoleAttribute);
	}
}
