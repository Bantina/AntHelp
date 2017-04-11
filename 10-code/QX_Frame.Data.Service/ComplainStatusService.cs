using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:22:44
	/// </summary>

	/// <summary>
	/// class ComplainStatusService
	/// </summary>
	public class ComplainStatusService:WcfService, IComplainStatusService
	{
		private tb_ComplainStatus _tb_ComplainStatus;
		/// <summary>
		/// construction method
		/// </summary>
		public ComplainStatusService()
		{}

		public ComplainStatusService(tb_ComplainStatus tb_ComplainStatus)
		{
			this._tb_ComplainStatus = tb_ComplainStatus;
		}
		public bool Add(tb_ComplainStatus tb_ComplainStatus)
		{
			return tb_ComplainStatus.Add(tb_ComplainStatus);
		}
		public bool Update(tb_ComplainStatus tb_ComplainStatus)
		{
			return tb_ComplainStatus.Update(tb_ComplainStatus);
		}
		public bool Delete(tb_ComplainStatus tb_ComplainStatus)
		{
			return tb_ComplainStatus.Delete(tb_ComplainStatus);
		}
	}
}
