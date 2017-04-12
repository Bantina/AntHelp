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
	/// time:2017-04-12 01:27:47
	/// </summary>

	/// <summary>
	///class tb_MessagePushQueryObject
	/// </summary>
	public class tb_MessagePushQueryObject:WcfQueryObject<db_AntHelp, tb_MessagePush>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_MessagePushQueryObject()
		{}

		// PK（identity）  
		public Guid messageUid { get;set; }

		// 
		public String messageTitle { get;set; }

		// 
		public String messagePusher { get;set; }

		// 
		public DateTime messagePushTime { get;set; }

		// 
		public Int32 messageCategoryId { get;set; }

		// 
		public Int32 messagePushStatusId { get;set; }

		// 
		public Guid pushToUserUid { get;set; }

		//query condition // null default
		public override Expression<Func<tb_MessagePush, bool>> QueryCondition {get { return base.QueryCondition; } set { base.QueryCondition = value; } }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_MessagePush, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_MessagePush, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
