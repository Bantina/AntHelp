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
	/// time:2017-04-05 10:41:13
	/// </summary>

	/// <summary>
	///class tb_AuthenticationQueryObject
	/// </summary>
	public class tb_AuthenticationQueryObject:WcfQueryObject<db_qx_frame, tb_Authentication>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_AuthenticationQueryObject()
		{}

		// PK（identity）  
		public Int32 appkey { get;set; }

		// 
		public String secretkey { get;set; }

		// 
		public String rsa_publicKey { get;set; }

		// 
		public String rsa_privateKey { get;set; }

		// 
		public String loginId { get;set; }

		// 
		public String tokensign { get;set; }

		//query condition // null default
		public override Expression<Func<tb_Authentication, bool>> QueryCondition { get { return base.QueryCondition; } set { base.QueryCondition = value; } }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_Authentication, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_Authentication, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
