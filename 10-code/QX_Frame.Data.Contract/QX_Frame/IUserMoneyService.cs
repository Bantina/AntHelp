using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-05-07 16:11:49
	/// </summary>

	/// <summary>
	/// interface IUserMoneyService
	/// </summary>
	public interface IUserMoneyService
	{
		bool Add(tb_UserMoney tb_UserMoney);
		bool Update(tb_UserMoney tb_UserMoney);
		bool Delete(tb_UserMoney tb_UserMoney);
	}
}
