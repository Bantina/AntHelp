using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.1.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:29:24
	/// </summary>

	/// <summary>
	/// interface ISexService
	/// </summary>
	public interface ISexService
	{
		bool Add(tb_Sex tb_Sex);
		bool Update(tb_Sex tb_Sex);
		bool Delete(tb_Sex tb_Sex);
	}
}
