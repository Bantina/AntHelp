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
	/// time:2017-04-12 01:28:03
	/// </summary>

	/// <summary>
	///class tb_MessagePushStatusQueryObject
	/// </summary>
	public class tb_MessagePushStatusQueryObject:WcfQueryObject<db_AntHelp,tb_MessagePushStatus>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_MessagePushStatusQueryObject()
		{}

		// PK（identity）  
		public Int32 messageStatusId { get;set; }

		// 
		public String StatusName { get;set; }

		//query condition // null default
		public override Expression<Func<tb_MessagePushStatus, bool>> QueryCondition {get { return base.QueryCondition; } set { base.QueryCondition = value; } }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_MessagePushStatus, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_MessagePushStatus, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
