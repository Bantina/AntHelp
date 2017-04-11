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
	/// time:2017-04-12 01:28:37
	/// </summary>

	/// <summary>
	///class tb_SelfMessageQueryObject
	/// </summary>
	public class tb_SelfMessageQueryObject:WcfQueryObject<db_AntHelp,tb_SelfMessage>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_SelfMessageQueryObject()
		{}

		// PK（identity）  
		public Guid selfMessageUid { get;set; }

		// 
		public String selfMessageContent { get;set; }

		// 
		public DateTime publishTime { get;set; }

		// 
		public Guid publisherUid { get;set; }

		// 
		public Int32 clickCount { get;set; }

		// 
		public Int32 praiseCount { get;set; }

		// 
		public String imagesUrls { get;set; }

		//query condition // null default
		public override Expression<Func<tb_SelfMessage, bool>> QueryCondition {get { return base.QueryCondition; } set { base.QueryCondition = value; } }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_SelfMessage, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_SelfMessage, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
