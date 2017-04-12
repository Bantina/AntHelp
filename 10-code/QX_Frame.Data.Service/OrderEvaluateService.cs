using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:23:53
	/// </summary>

	/// <summary>
	/// class OrderEvaluateService
	/// </summary>
	public class OrderEvaluateService:WcfService, IOrderEvaluateService
	{
		private tb_OrderEvaluate _tb_OrderEvaluate;
		/// <summary>
		/// construction method
		/// </summary>
		public OrderEvaluateService()
		{}

		public OrderEvaluateService(tb_OrderEvaluate tb_OrderEvaluate)
		{
			this._tb_OrderEvaluate = tb_OrderEvaluate;
		}
		public bool Add(tb_OrderEvaluate tb_OrderEvaluate)
		{
			return tb_OrderEvaluate.Add(tb_OrderEvaluate);
		}
		public bool Update(tb_OrderEvaluate tb_OrderEvaluate)
		{
			return tb_OrderEvaluate.Update(tb_OrderEvaluate);
		}
		public bool Delete(tb_OrderEvaluate tb_OrderEvaluate)
		{
			return tb_OrderEvaluate.Delete(tb_OrderEvaluate);
		}
	}
}
