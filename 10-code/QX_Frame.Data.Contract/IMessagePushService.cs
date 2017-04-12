using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:15:30
	/// </summary>

	/// <summary>
	/// interface IMessagePushService
	/// </summary>
	public interface IMessagePushService
	{
		bool Add(tb_MessagePush tb_MessagePush);
		bool Update(tb_MessagePush tb_MessagePush);
		bool Delete(tb_MessagePush tb_MessagePush);
	}
}
