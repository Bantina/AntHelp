using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:15:02
	/// </summary>

	/// <summary>
	/// interface IArticleService
	/// </summary>
	public interface IArticleService
	{
		bool Add(tb_Article tb_Article);
		bool Update(tb_Article tb_Article);
		bool Delete(tb_Article tb_Article);
	}
}
