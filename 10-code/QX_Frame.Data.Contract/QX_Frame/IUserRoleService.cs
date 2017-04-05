using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.1.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:30:18
	/// </summary>

	/// <summary>
	/// interface IUserRoleService
	/// </summary>
	public interface IUserRoleService
	{
		bool Add(tb_UserRole tb_UserRole);
		bool Update(tb_UserRole tb_UserRole);
		bool Delete(tb_UserRole tb_UserRole);
	}
}
