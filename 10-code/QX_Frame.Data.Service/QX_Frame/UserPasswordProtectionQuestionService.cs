using QX_Frame.App.Base;
using QX_Frame.Data.Contract.QX_Frame;
using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Service.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-08 18:46:05
	/// </summary>

	/// <summary>
	/// class UserPasswordProtectionQuestionService
	/// </summary>
	public class UserPasswordProtectionQuestionService:WcfService, IUserPasswordProtectionQuestionService
	{
		private tb_UserPasswordProtectionQuestion _tb_UserPasswordProtectionQuestion;
		/// <summary>
		/// construction method
		/// </summary>
		public UserPasswordProtectionQuestionService()
		{}

		public UserPasswordProtectionQuestionService(tb_UserPasswordProtectionQuestion tb_UserPasswordProtectionQuestion)
		{
			this._tb_UserPasswordProtectionQuestion = tb_UserPasswordProtectionQuestion;
		}
		public bool Add(tb_UserPasswordProtectionQuestion tb_UserPasswordProtectionQuestion)
		{
			return tb_UserPasswordProtectionQuestion.Add(tb_UserPasswordProtectionQuestion);
		}
		public bool Update(tb_UserPasswordProtectionQuestion tb_UserPasswordProtectionQuestion)
		{
			return tb_UserPasswordProtectionQuestion.Update(tb_UserPasswordProtectionQuestion);
		}
		public bool Delete(tb_UserPasswordProtectionQuestion tb_UserPasswordProtectionQuestion)
		{
			return tb_UserPasswordProtectionQuestion.Delete(tb_UserPasswordProtectionQuestion);
		}
	}
}
