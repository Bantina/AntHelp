using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:23:36
	/// </summary>

	/// <summary>
	/// class OrderService
	/// </summary>
	public class OrderService:WcfService, IOrderService
	{
		private tb_Order _tb_Order;
		/// <summary>
		/// construction method
		/// </summary>
		public OrderService()
		{}

		public OrderService(tb_Order tb_Order)
		{
			this._tb_Order = tb_Order;
		}
		public bool Add(tb_Order tb_Order)
		{
			return tb_Order.Add(tb_Order);
		}
		public bool Update(tb_Order tb_Order)
		{
			return tb_Order.Update(tb_Order);
		}
		public bool Delete(tb_Order tb_Order)
		{
			return tb_Order.Delete(tb_Order);
		}
	}
}
