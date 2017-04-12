using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:23:05
	/// </summary>

	/// <summary>
	/// class MessagePushService
	/// </summary>
	public class MessagePushService:WcfService, IMessagePushService
	{
		private tb_MessagePush _tb_MessagePush;
		/// <summary>
		/// construction method
		/// </summary>
		public MessagePushService()
		{}

		public MessagePushService(tb_MessagePush tb_MessagePush)
		{
			this._tb_MessagePush = tb_MessagePush;
		}
		public bool Add(tb_MessagePush tb_MessagePush)
		{
			return tb_MessagePush.Add(tb_MessagePush);
		}
		public bool Update(tb_MessagePush tb_MessagePush)
		{
			return tb_MessagePush.Update(tb_MessagePush);
		}
		public bool Delete(tb_MessagePush tb_MessagePush)
		{
			return tb_MessagePush.Delete(tb_MessagePush);
		}
	}
}
