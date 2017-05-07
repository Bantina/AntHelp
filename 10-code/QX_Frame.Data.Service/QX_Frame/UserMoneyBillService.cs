using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities.QX_Frame;
namespace QX_Frame.Data.Service.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-05-07 16:13:00
	/// </summary>

	/// <summary>
	/// class UserMoneyBillService
	/// </summary>
	public class UserMoneyBillService:WcfService, IUserMoneyBillService
	{
		private tb_UserMoneyBill _tb_UserMoneyBill;
		/// <summary>
		/// construction method
		/// </summary>
		public UserMoneyBillService()
		{}

		public UserMoneyBillService(tb_UserMoneyBill tb_UserMoneyBill)
		{
			this._tb_UserMoneyBill = tb_UserMoneyBill;
		}
		public bool Add(tb_UserMoneyBill tb_UserMoneyBill)
		{
			return tb_UserMoneyBill.Add(tb_UserMoneyBill);
		}
		public bool Update(tb_UserMoneyBill tb_UserMoneyBill)
		{
			return tb_UserMoneyBill.Update(tb_UserMoneyBill);
		}
		public bool Delete(tb_UserMoneyBill tb_UserMoneyBill)
		{
			return tb_UserMoneyBill.Delete(tb_UserMoneyBill);
		}
	}
}
