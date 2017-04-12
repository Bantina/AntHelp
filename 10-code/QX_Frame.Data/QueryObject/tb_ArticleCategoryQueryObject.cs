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
	/// time:2017-04-12 01:27:24
	/// </summary>

	/// <summary>
	///class tb_ArticleCategoryQueryObject
	/// </summary>
	public class tb_ArticleCategoryQueryObject:WcfQueryObject<db_AntHelp, tb_ArticleCategory>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_ArticleCategoryQueryObject()
		{}

		// PK（identity）  
		public Int32 ArticleCategoryId { get;set; }

		// 
		public String CategoryName { get;set; }

		//query condition // null default
		public override Expression<Func<tb_ArticleCategory, bool>> QueryCondition {get { return base.QueryCondition; } set { base.QueryCondition = value; } }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_ArticleCategory, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_ArticleCategory, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
