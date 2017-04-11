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
	/// time:2017-04-05 10:41:46
	/// </summary>

	/// <summary>
	///class tb_UserFunctionQueryObject
	/// </summary>
	public class tb_UserFunctionQueryObject:WcfQueryObject<db_qx_frame,tb_UserFunction>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_UserFunctionQueryObject()
		{}

		// PK（identity）  
		public Guid functionId { get;set; }

		// 
		public Guid uid { get;set; }

		// 
		public String functionRoute { get;set; }

		// 
		public String functionName { get;set; }

		// 
		public String description { get;set; }

		//query condition // null default
		public override Expression<Func<tb_UserFunction, bool>> QueryCondition { get { return base.QueryCondition; } set { base.QueryCondition = value; } }

        //query condition func // true default //if QueryCondition != null this will be override !!!
        protected override Expression<Func<tb_UserFunction, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_UserFunction, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
