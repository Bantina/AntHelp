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
	/// time:2017-04-12 01:27:40
	/// </summary>

	/// <summary>
	///class tb_FavorableActivityQueryObject
	/// </summary>
	public class tb_FavorableActivityQueryObject:WcfQueryObject<db_AntHelp, tb_FavorableActivity>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_FavorableActivityQueryObject()
		{}

		// PK（identity）  
		public Guid actUid { get;set; }

		// 
		public String actTitle { get;set; }

		// 
		public String actDescription { get;set; }

		// 
		public DateTime actStartTime { get;set; }

		// 
		public DateTime actEndTime { get;set; }

		// 
		public DateTime actPublishTime { get;set; }

		// 
		public String actPublisher { get;set; }

		//query condition // null default
		public override Expression<Func<tb_FavorableActivity, bool>> QueryCondition {get { return base.QueryCondition; } set { base.QueryCondition = value; } }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_FavorableActivity, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_FavorableActivity, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
