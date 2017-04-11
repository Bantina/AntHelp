using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:22:34
	/// </summary>

	/// <summary>
	/// class CommentReplyService
	/// </summary>
	public class CommentReplyService:WcfService, ICommentReplyService
	{
		private tb_CommentReply _tb_CommentReply;
		/// <summary>
		/// construction method
		/// </summary>
		public CommentReplyService()
		{}

		public CommentReplyService(tb_CommentReply tb_CommentReply)
		{
			this._tb_CommentReply = tb_CommentReply;
		}
		public bool Add(tb_CommentReply tb_CommentReply)
		{
			return tb_CommentReply.Add(tb_CommentReply);
		}
		public bool Update(tb_CommentReply tb_CommentReply)
		{
			return tb_CommentReply.Update(tb_CommentReply);
		}
		public bool Delete(tb_CommentReply tb_CommentReply)
		{
			return tb_CommentReply.Delete(tb_CommentReply);
		}
	}
}
