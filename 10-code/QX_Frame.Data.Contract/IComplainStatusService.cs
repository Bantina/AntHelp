using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:15:21
	/// </summary>

	/// <summary>
	/// interface IComplainStatusService
	/// </summary>
	public interface IComplainStatusService
	{
		bool Add(tb_ComplainStatus tb_ComplainStatus);
		bool Update(tb_ComplainStatus tb_ComplainStatus);
		bool Delete(tb_ComplainStatus tb_ComplainStatus);
	}
}
