using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-05-07 16:11:56
	/// </summary>

	/// <summary>
	/// interface IUserMoneyBillService
	/// </summary>
	public interface IUserMoneyBillService
	{
		bool Add(tb_UserMoneyBill tb_UserMoneyBill);
		bool Update(tb_UserMoneyBill tb_UserMoneyBill);
		bool Delete(tb_UserMoneyBill tb_UserMoneyBill);
	}
}
