using QX_Frame.App.Base;
using QX_Frame.Data.Entities;
using System;
using System.Linq.Expressions;

namespace QX_Frame.Data.QueryObject
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:27:15
	/// </summary>

	/// <summary>
	///class tb_ArticleQueryObject
	/// </summary>
	public class tb_ArticleQueryObject:WcfQueryObject<db_AntHelp, tb_Article>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_ArticleQueryObject()
		{}

		// PK（identity）  
		public Guid articleUid { get;set; }

		// 
		public String articleTitle { get;set; }

		// 
		public String articleContent { get;set; }

		// 
		public Guid publisherUid { get;set; }

		// 
		public DateTime publishTime { get;set; }

		// 
		public Int32 clickCount { get;set; }

		// 
		public Int32 praiseCount { get;set; }

        // 
        public Int32 ArticleCategoryId { get; set; } = 0;

		// 
		public String imagesUrls { get;set; }

		//query condition // null default
		public override Expression<Func<tb_Article, bool>> QueryCondition {get { return base.QueryCondition; } set { base.QueryCondition = value; } }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_Article, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_Article, bool>> func = t => true;

			if (!string.IsNullOrEmpty(this.articleTitle))
			{
				func = func.And(t => t.articleTitle.Contains(this.articleTitle));
			}

            if (this.ArticleCategoryId!=-1)
            {
                func = func.And(t => t.ArticleCategoryId == this.ArticleCategoryId);
            }

			return func;
		}
	}
}
