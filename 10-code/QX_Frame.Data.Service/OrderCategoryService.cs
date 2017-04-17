using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-14 10:25:03
	/// </summary>

	/// <summary>
	/// class OrderCategoryService
	/// </summary>
	public class OrderCategoryService:WcfService, IOrderCategoryService
	{
		private tb_OrderCategory _tb_OrderCategory;
		/// <summary>
		/// construction method
		/// </summary>
		public OrderCategoryService()
		{}

		public OrderCategoryService(tb_OrderCategory tb_OrderCategory)
		{
			this._tb_OrderCategory = tb_OrderCategory;
		}
		public bool Add(tb_OrderCategory tb_OrderCategory)
		{
			return tb_OrderCategory.Add(tb_OrderCategory);
		}
		public bool Update(tb_OrderCategory tb_OrderCategory)
		{
			return tb_OrderCategory.Update(tb_OrderCategory);
		}
		public bool Delete(tb_OrderCategory tb_OrderCategory)
		{
			return tb_OrderCategory.Delete(tb_OrderCategory);
		}
	}
}
