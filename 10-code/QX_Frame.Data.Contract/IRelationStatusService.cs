using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:16:58
	/// </summary>

	/// <summary>
	/// interface IRelationStatusService
	/// </summary>
	public interface IRelationStatusService
	{
		bool Add(tb_RelationStatus tb_RelationStatus);
		bool Update(tb_RelationStatus tb_RelationStatus);
		bool Delete(tb_RelationStatus tb_RelationStatus);
	}
}
