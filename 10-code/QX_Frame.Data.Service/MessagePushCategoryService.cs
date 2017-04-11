using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:23:14
	/// </summary>

	/// <summary>
	/// class MessagePushCategoryService
	/// </summary>
	public class MessagePushCategoryService:WcfService, IMessagePushCategoryService
	{
		private tb_MessagePushCategory _tb_MessagePushCategory;
		/// <summary>
		/// construction method
		/// </summary>
		public MessagePushCategoryService()
		{}

		public MessagePushCategoryService(tb_MessagePushCategory tb_MessagePushCategory)
		{
			this._tb_MessagePushCategory = tb_MessagePushCategory;
		}
		public bool Add(tb_MessagePushCategory tb_MessagePushCategory)
		{
			return tb_MessagePushCategory.Add(tb_MessagePushCategory);
		}
		public bool Update(tb_MessagePushCategory tb_MessagePushCategory)
		{
			return tb_MessagePushCategory.Update(tb_MessagePushCategory);
		}
		public bool Delete(tb_MessagePushCategory tb_MessagePushCategory)
		{
			return tb_MessagePushCategory.Delete(tb_MessagePushCategory);
		}
	}
}
