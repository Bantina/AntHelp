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
	/// time:2017-04-05 10:41:52
	/// </summary>

	/// <summary>
	///class tb_UserPasswordProtectionQuestionQueryObject
	/// </summary>
	public class tb_UserPasswordProtectionQuestionQueryObject:WcfQueryObject<db_qx_frame,tb_UserPasswordProtectionQuestion>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_UserPasswordProtectionQuestionQueryObject()
		{}

		// PK（identity）  
		public Guid questionId { get;set; }

		// 
		public Guid uid { get;set; }

		// 
		public String question { get;set; }

		// 
		public String answer { get;set; }

		//query condition // null default
		public override Expression<Func<tb_UserPasswordProtectionQuestion, bool>> QueryCondition { get { return base.QueryCondition; } set { base.QueryCondition = value; } }

        //query condition func // true default //if QueryCondition != null this will be override !!!
        protected override Expression<Func<tb_UserPasswordProtectionQuestion, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_UserPasswordProtectionQuestion, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
