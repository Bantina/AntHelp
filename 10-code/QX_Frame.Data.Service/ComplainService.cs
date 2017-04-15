using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:23:45
	/// </summary>

	/// <summary>
	/// class OrderComplainService
	/// </summary>
	public class ComplainService:WcfService, IComplainService
	{
		private tb_Complain _tb_OrderComplain;
		/// <summary>
		/// construction method
		/// </summary>
		public ComplainService()
		{}

		public ComplainService(tb_Complain tb_OrderComplain)
		{
			this._tb_OrderComplain = tb_OrderComplain;
		}
		public bool Add(tb_Complain tb_OrderComplain)
		{
			return tb_OrderComplain.Add(tb_OrderComplain);
		}
		public bool Update(tb_Complain tb_OrderComplain)
		{
			return tb_OrderComplain.Update(tb_OrderComplain);
		}
		public bool Delete(tb_Complain tb_OrderComplain)
		{
			return tb_OrderComplain.Delete(tb_OrderComplain);
		}
	}
}
