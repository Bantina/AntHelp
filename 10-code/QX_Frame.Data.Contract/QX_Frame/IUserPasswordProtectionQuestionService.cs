using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.1.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:30:12
	/// </summary>

	/// <summary>
	/// interface IUserPasswordProtectionQuestionService
	/// </summary>
	public interface IUserPasswordProtectionQuestionService
	{
		bool Add(tb_UserPasswordProtectionQuestion tb_UserPasswordProtectionQuestion);
		bool Update(tb_UserPasswordProtectionQuestion tb_UserPasswordProtectionQuestion);
		bool Delete(tb_UserPasswordProtectionQuestion tb_UserPasswordProtectionQuestion);
	}
}
