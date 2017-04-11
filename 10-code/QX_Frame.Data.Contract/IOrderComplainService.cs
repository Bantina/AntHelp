using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:15:48
	/// </summary>

	/// <summary>
	/// interface IOrderComplainService
	/// </summary>
	public interface IOrderComplainService
	{
		bool Add(tb_OrderComplain tb_OrderComplain);
		bool Update(tb_OrderComplain tb_OrderComplain);
		bool Delete(tb_OrderComplain tb_OrderComplain);
	}
}
