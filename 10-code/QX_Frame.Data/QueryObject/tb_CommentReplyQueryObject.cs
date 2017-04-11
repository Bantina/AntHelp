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
	/// time:2017-04-12 01:27:30
	/// </summary>

	/// <summary>
	///class tb_CommentReplyQueryObject
	/// </summary>
	public class tb_CommentReplyQueryObject:WcfQueryObject<db_AntHelp, tb_CommentReply>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_CommentReplyQueryObject()
		{}

		// PK（identity）  
		public Guid commentUid { get;set; }

		// 
		public Guid articleIdOrCommentId { get;set; }

		// 
		public String commentUserLoginId { get;set; }

		// 
		public String commentContent { get;set; }

		// 
		public DateTime commentTime { get;set; }

		//query condition // null default
		public override Expression<Func<tb_CommentReply, bool>> QueryCondition {get { return base.QueryCondition; } set { base.QueryCondition = value; } }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_CommentReply, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_CommentReply, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
