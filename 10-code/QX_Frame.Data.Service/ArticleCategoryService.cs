using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:22:23
	/// </summary>

	/// <summary>
	/// class ArticleCategoryService
	/// </summary>
	public class ArticleCategoryService:WcfService, IArticleCategoryService
	{
		private tb_ArticleCategory _tb_ArticleCategory;
		/// <summary>
		/// construction method
		/// </summary>
		public ArticleCategoryService()
		{}

		public ArticleCategoryService(tb_ArticleCategory tb_ArticleCategory)
		{
			this._tb_ArticleCategory = tb_ArticleCategory;
		}
		public bool Add(tb_ArticleCategory tb_ArticleCategory)
		{
			return tb_ArticleCategory.Add(tb_ArticleCategory);
		}
		public bool Update(tb_ArticleCategory tb_ArticleCategory)
		{
			return tb_ArticleCategory.Update(tb_ArticleCategory);
		}
		public bool Delete(tb_ArticleCategory tb_ArticleCategory)
		{
			return tb_ArticleCategory.Delete(tb_ArticleCategory);
		}
	}
}
