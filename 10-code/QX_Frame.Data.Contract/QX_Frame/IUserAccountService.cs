using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.1.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:29:53
	/// </summary>

	/// <summary>
	/// interface IUserAccountService
	/// </summary>
	public interface IUserAccountService
	{
		bool Add(tb_UserAccount tb_UserAccount);
		bool Update(tb_UserAccount tb_UserAccount);
		bool Delete(tb_UserAccount tb_UserAccount);
	}
}
