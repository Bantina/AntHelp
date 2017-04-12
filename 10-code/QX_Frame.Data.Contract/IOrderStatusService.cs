using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:15:58
	/// </summary>

	/// <summary>
	/// interface IOrderStatusService
	/// </summary>
	public interface IOrderStatusService
	{
		bool Add(tb_OrderStatus tb_OrderStatus);
		bool Update(tb_OrderStatus tb_OrderStatus);
		bool Delete(tb_OrderStatus tb_OrderStatus);
	}
}
