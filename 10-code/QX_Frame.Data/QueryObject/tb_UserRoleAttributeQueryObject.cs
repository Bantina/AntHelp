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
	/// time:2017-04-05 10:42:06
	/// </summary>

	/// <summary>
	///class tb_UserRoleAttributeQueryObject
	/// </summary>
	public class tb_UserRoleAttributeQueryObject:WcfQueryObject<db_qx_frame,tb_UserRoleAttribute>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_UserRoleAttributeQueryObject()
		{}

		// PK（identity）  
		public Int32 roleLevel { get;set; }

		// 
		public String roleName { get;set; }

		// 
		public String description { get;set; }

		//query condition // null default
		public override Expression<Func<tb_UserRoleAttribute, bool>> QueryCondition { get => base.QueryCondition; set => base.QueryCondition = value; }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_UserRoleAttribute, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_UserRoleAttribute, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
