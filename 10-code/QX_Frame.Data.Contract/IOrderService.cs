using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:15:43
	/// </summary>

	/// <summary>
	/// interface IOrderService
	/// </summary>
	public interface IOrderService
	{
		bool Add(tb_Order tb_Order);
		bool Update(tb_Order tb_Order);
		bool Delete(tb_Order tb_Order);
	}
}
