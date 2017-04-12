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
	/// time:2017-04-12 01:28:32
	/// </summary>

	/// <summary>
	///class tb_RelationStatusQueryObject
	/// </summary>
	public class tb_RelationStatusQueryObject:WcfQueryObject<db_AntHelp,tb_RelationStatus>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_RelationStatusQueryObject()
		{}

		// PK（identity）  
		public Int32 relationStatusId { get;set; }

		// 
		public String statusName { get;set; }

		//query condition // null default
		public override Expression<Func<tb_RelationStatus, bool>> QueryCondition {get { return base.QueryCondition; } set { base.QueryCondition = value; } }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_RelationStatus, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_RelationStatus, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
