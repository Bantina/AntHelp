using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:15:53
	/// </summary>

	/// <summary>
	/// interface IOrderEvaluateService
	/// </summary>
	public interface IOrderEvaluateService
	{
		bool Add(tb_OrderEvaluate tb_OrderEvaluate);
		bool Update(tb_OrderEvaluate tb_OrderEvaluate);
		bool Delete(tb_OrderEvaluate tb_OrderEvaluate);
	}
}
