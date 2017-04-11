using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:23:24
	/// </summary>

	/// <summary>
	/// class MessagePushStatusService
	/// </summary>
	public class MessagePushStatusService:WcfService, IMessagePushStatusService
	{
		private tb_MessagePushStatus _tb_MessagePushStatus;
		/// <summary>
		/// construction method
		/// </summary>
		public MessagePushStatusService()
		{}

		public MessagePushStatusService(tb_MessagePushStatus tb_MessagePushStatus)
		{
			this._tb_MessagePushStatus = tb_MessagePushStatus;
		}
		public bool Add(tb_MessagePushStatus tb_MessagePushStatus)
		{
			return tb_MessagePushStatus.Add(tb_MessagePushStatus);
		}
		public bool Update(tb_MessagePushStatus tb_MessagePushStatus)
		{
			return tb_MessagePushStatus.Update(tb_MessagePushStatus);
		}
		public bool Delete(tb_MessagePushStatus tb_MessagePushStatus)
		{
			return tb_MessagePushStatus.Delete(tb_MessagePushStatus);
		}
	}
}
