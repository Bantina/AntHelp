using QX_Frame.App.Base;
using QX_Frame.Data.Entities.QX_Frame;
using System;
using System.Linq.Expressions;

namespace QX_Frame.Data.QueryObject
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-05 10:42:17
	/// </summary>

	/// <summary>
	///class tb_UserStatusAttributeQueryObject
	/// </summary>
	public class tb_UserStatusAttributeQueryObject:WcfQueryObject<db_qx_frame,tb_UserStatusAttribute>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_UserStatusAttributeQueryObject()
		{}

		// PK（identity）  
		public Int32 statusLevel { get;set; }

		// 
		public String statusName { get;set; }

		// 
		public String description { get;set; }

		//query condition // null default
		public override Expression<Func<tb_UserStatusAttribute, bool>> QueryCondition { get { return base.QueryCondition; } set { base.QueryCondition = value; } }

        //query condition func // true default //if QueryCondition != null this will be override !!!
        protected override Expression<Func<tb_UserStatusAttribute, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_UserStatusAttribute, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
