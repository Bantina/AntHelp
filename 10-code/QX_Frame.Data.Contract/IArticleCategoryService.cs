using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:15:12
	/// </summary>

	/// <summary>
	/// interface IArticleCategoryService
	/// </summary>
	public interface IArticleCategoryService
	{
		bool Add(tb_ArticleCategory tb_ArticleCategory);
		bool Update(tb_ArticleCategory tb_ArticleCategory);
		bool Delete(tb_ArticleCategory tb_ArticleCategory);
	}
}
