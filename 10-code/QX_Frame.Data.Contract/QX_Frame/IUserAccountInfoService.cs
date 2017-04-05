using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.1.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:29:58
	/// </summary>

	/// <summary>
	/// interface IUserAccountInfoService
	/// </summary>
	public interface IUserAccountInfoService
	{
		bool Add(tb_UserAccountInfo tb_UserAccountInfo);
		bool Update(tb_UserAccountInfo tb_UserAccountInfo);
		bool Delete(tb_UserAccountInfo tb_UserAccountInfo);
	}
}
