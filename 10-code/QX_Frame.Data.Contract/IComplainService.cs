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
	public interface IComplainService
	{
		bool Add(tb_Complain tb_OrderComplain);
		bool Update(tb_Complain tb_OrderComplain);
		bool Delete(tb_Complain tb_OrderComplain);
	}
}
