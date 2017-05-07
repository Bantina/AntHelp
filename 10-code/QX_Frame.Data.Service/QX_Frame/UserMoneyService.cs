using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities.QX_Frame;
namespace QX_Frame.Data.Service.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-05-07 16:13:18
	/// </summary>

	/// <summary>
	/// class UserMoneyService
	/// </summary>
	public class UserMoneyService:WcfService, IUserMoneyService
	{
		private tb_UserMoney _tb_UserMoney;
		/// <summary>
		/// construction method
		/// </summary>
		public UserMoneyService()
		{}

		public UserMoneyService(tb_UserMoney tb_UserMoney)
		{
			this._tb_UserMoney = tb_UserMoney;
		}
		public bool Add(tb_UserMoney tb_UserMoney)
		{
			return tb_UserMoney.Add(tb_UserMoney);
		}
		public bool Update(tb_UserMoney tb_UserMoney)
		{
			return tb_UserMoney.Update(tb_UserMoney);
		}
		public bool Delete(tb_UserMoney tb_UserMoney)
		{
			return tb_UserMoney.Delete(tb_UserMoney);
		}
	}
}
