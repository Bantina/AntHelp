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
	/// time:2017-04-05 10:42:00
	/// </summary>

	/// <summary>
	///class tb_UserRoleQueryObject
	/// </summary>
	public class tb_UserRoleQueryObject:WcfQueryObject<db_qx_frame,tb_UserRole>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_UserRoleQueryObject()
		{}

		// PK（identity）  
		public Guid uid { get;set; }

		// 
		public Int32 roleLevel { get;set; }

		//query condition // null default
		public override Expression<Func<tb_UserRole, bool>> QueryCondition { get => base.QueryCondition; set => base.QueryCondition = value; }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_UserRole, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_UserRole, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
