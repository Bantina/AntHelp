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
	/// time:2017-04-12 01:28:42
	/// </summary>

	/// <summary>
	///class tb_UserRelationQueryObject
	/// </summary>
	public class tb_UserRelationQueryObject:WcfQueryObject<db_AntHelp,tb_UserRelation>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_UserRelationQueryObject()
		{}

		// PK（identity）  
		public Guid relationUid { get;set; }

		// 
		public Guid myUid { get;set; }

		// 
		public Guid friendUid { get;set; }

		// 
		public DateTime relationTime { get;set; }

		// 
		//query condition // null default
		public override Expression<Func<tb_UserRelation, bool>> QueryCondition {get { return base.QueryCondition; } set { base.QueryCondition = value; } }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_UserRelation, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_UserRelation, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

            func = func.And(t => t.myUid == this.myUid);

			return func;
		}
	}
}
