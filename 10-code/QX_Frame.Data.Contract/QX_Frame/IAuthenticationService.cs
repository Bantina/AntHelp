using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.1.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:28:54
	/// </summary>

	/// <summary>
	/// interface IAuthenticationService
	/// </summary>
	public interface IAuthenticationService
	{
		bool Add(tb_Authentication tb_Authentication);
		bool Update(tb_Authentication tb_Authentication);
		bool Delete(tb_Authentication tb_Authentication);
	}
}
