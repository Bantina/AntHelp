using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:24:02
	/// </summary>

	/// <summary>
	/// class OrderStatusService
	/// </summary>
	public class OrderStatusService:WcfService, IOrderStatusService
	{
		private tb_OrderStatus _tb_OrderStatus;
		/// <summary>
		/// construction method
		/// </summary>
		public OrderStatusService()
		{}

		public OrderStatusService(tb_OrderStatus tb_OrderStatus)
		{
			this._tb_OrderStatus = tb_OrderStatus;
		}
		public bool Add(tb_OrderStatus tb_OrderStatus)
		{
			return tb_OrderStatus.Add(tb_OrderStatus);
		}
		public bool Update(tb_OrderStatus tb_OrderStatus)
		{
			return tb_OrderStatus.Update(tb_OrderStatus);
		}
		public bool Delete(tb_OrderStatus tb_OrderStatus)
		{
			return tb_OrderStatus.Delete(tb_OrderStatus);
		}
	}
}
