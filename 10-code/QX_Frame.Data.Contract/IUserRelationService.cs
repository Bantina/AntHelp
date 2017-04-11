using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:16:34
	/// </summary>

	/// <summary>
	/// interface IUserRelationService
	/// </summary>
	public interface IUserRelationService
	{
		bool Add(tb_UserRelation tb_UserRelation);
		bool Update(tb_UserRelation tb_UserRelation);
		bool Delete(tb_UserRelation tb_UserRelation);
	}
}
