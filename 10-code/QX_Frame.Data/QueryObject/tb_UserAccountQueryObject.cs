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
	/// time:2017-04-05 10:41:30
	/// </summary>

	/// <summary>
	///class tb_UserAccountQueryObject
	/// </summary>
	public class tb_UserAccountQueryObject:WcfQueryObject<db_qx_frame,tb_UserAccount>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_UserAccountQueryObject()
		{}

		// PK（identity）  
		public Guid uid { get;set; }

		// 
		public String loginId { get;set; }

		// 
		public String pwd { get;set; }

		//query condition // null default
		public override Expression<Func<tb_UserAccount, bool>> QueryCondition { get => base.QueryCondition; set => base.QueryCondition = value; }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_UserAccount, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_UserAccount, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
