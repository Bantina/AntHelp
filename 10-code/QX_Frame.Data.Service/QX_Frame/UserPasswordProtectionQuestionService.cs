using QX_Frame.App.Base;
using QX_Frame.Data.Contract.QX_Frame;
using QX_Frame.Data.Entities.QX_Frame;
using System;

namespace QX_Frame.Data.Service.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:44:51
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
			return tb_UserPasswordProtectionQuestion.Add();
		}
		public bool Update(tb_UserPasswordProtectionQuestion tb_UserPasswordProtectionQuestion)
		{
			return tb_UserPasswordProtectionQuestion.Update();
		}
		public bool Delete(tb_UserPasswordProtectionQuestion tb_UserPasswordProtectionQuestion)
		{
			return tb_UserPasswordProtectionQuestion.Delete();
		}
	}
}
