using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:21:51
	/// </summary>

	/// <summary>
	/// class ArticleService
	/// </summary>
	public class ArticleService:WcfService, IArticleService
	{
		private tb_Article _tb_Article;
		/// <summary>
		/// construction method
		/// </summary>
		public ArticleService()
		{}

		public ArticleService(tb_Article tb_Article)
		{
			this._tb_Article = tb_Article;
		}
		public bool Add(tb_Article tb_Article)
		{
			return tb_Article.Add(tb_Article);
		}
		public bool Update(tb_Article tb_Article)
		{
			return tb_Article.Update(tb_Article);
		}
		public bool Delete(tb_Article tb_Article)
		{
			return tb_Article.Delete(tb_Article);
		}
	}
}
