using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.1.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:30:34
	/// </summary>

	/// <summary>
	/// interface IUserStatusAttributeService
	/// </summary>
	public interface IUserStatusAttributeService
	{
		bool Add(tb_UserStatusAttribute tb_UserStatusAttribute);
		bool Update(tb_UserStatusAttribute tb_UserStatusAttribute);
		bool Delete(tb_UserStatusAttribute tb_UserStatusAttribute);
	}
}
