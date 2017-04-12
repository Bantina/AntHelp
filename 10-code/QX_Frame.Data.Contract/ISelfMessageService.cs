using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:16:13
	/// </summary>

	/// <summary>
	/// interface ISelfMessageService
	/// </summary>
	public interface ISelfMessageService
	{
		bool Add(tb_SelfMessage tb_SelfMessage);
		bool Update(tb_SelfMessage tb_SelfMessage);
		bool Delete(tb_SelfMessage tb_SelfMessage);
	}
}
