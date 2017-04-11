using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:15:17
	/// </summary>

	/// <summary>
	/// interface ICommentReplyService
	/// </summary>
	public interface ICommentReplyService
	{
		bool Add(tb_CommentReply tb_CommentReply);
		bool Update(tb_CommentReply tb_CommentReply);
		bool Delete(tb_CommentReply tb_CommentReply);
	}
}
