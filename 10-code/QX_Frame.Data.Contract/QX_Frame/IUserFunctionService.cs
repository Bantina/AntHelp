using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.1.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:30:07
	/// </summary>

	/// <summary>
	/// interface IUserFunctionService
	/// </summary>
	public interface IUserFunctionService
	{
		bool Add(tb_UserFunction tb_UserFunction);
		bool Update(tb_UserFunction tb_UserFunction);
		bool Delete(tb_UserFunction tb_UserFunction);
	}
}
