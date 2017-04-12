using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:24:10
	/// </summary>

	/// <summary>
	/// class RelationStatusService
	/// </summary>
	public class RelationStatusService:WcfService, IRelationStatusService
	{
		private tb_RelationStatus _tb_RelationStatus;
		/// <summary>
		/// construction method
		/// </summary>
		public RelationStatusService()
		{}

		public RelationStatusService(tb_RelationStatus tb_RelationStatus)
		{
			this._tb_RelationStatus = tb_RelationStatus;
		}
		public bool Add(tb_RelationStatus tb_RelationStatus)
		{
			return tb_RelationStatus.Add(tb_RelationStatus);
		}
		public bool Update(tb_RelationStatus tb_RelationStatus)
		{
			return tb_RelationStatus.Update(tb_RelationStatus);
		}
		public bool Delete(tb_RelationStatus tb_RelationStatus)
		{
			return tb_RelationStatus.Delete(tb_RelationStatus);
		}
	}
}
