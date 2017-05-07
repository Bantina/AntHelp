using QX_Frame.App.Base;
using QX_Frame.Data.Entities;
using QX_Frame.Data.Entities.QX_Frame;
using System;
using System.Linq.Expressions;

namespace QX_Frame.Data.QueryObject
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-05-07 16:09:19
	/// </summary>

	/// <summary>
	///class tb_UserMoneyQueryObject
	/// </summary>
	public class tb_UserMoneyQueryObject:WcfQueryObject<db_qx_frame, tb_UserMoney>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_UserMoneyQueryObject()
		{}

		// PK（identity）  
		public Guid uid { get;set; }

		// 
		public Int32 money { get;set; }

		//query condition // null default
		public override Expression<Func<tb_UserMoney, bool>> QueryCondition {get { return base.QueryCondition; } set { base.QueryCondition = value; } }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_UserMoney, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_UserMoney, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
