using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:15:38
	/// </summary>

	/// <summary>
	/// interface IMessagePushStatusService
	/// </summary>
	public interface IMessagePushStatusService
	{
		bool Add(tb_MessagePushStatus tb_MessagePushStatus);
		bool Update(tb_MessagePushStatus tb_MessagePushStatus);
		bool Delete(tb_MessagePushStatus tb_MessagePushStatus);
	}
}
