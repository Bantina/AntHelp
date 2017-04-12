using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:15:34
	/// </summary>

	/// <summary>
	/// interface IMessagePushCategoryService
	/// </summary>
	public interface IMessagePushCategoryService
	{
		bool Add(tb_MessagePushCategory tb_MessagePushCategory);
		bool Update(tb_MessagePushCategory tb_MessagePushCategory);
		bool Delete(tb_MessagePushCategory tb_MessagePushCategory);
	}
}
