using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.1.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:30:29
	/// </summary>

	/// <summary>
	/// interface IUserStatusService
	/// </summary>
	public interface IUserStatusService
	{
		bool Add(tb_UserStatus tb_UserStatus);
		bool Update(tb_UserStatus tb_UserStatus);
		bool Delete(tb_UserStatus tb_UserStatus);
	}
}
