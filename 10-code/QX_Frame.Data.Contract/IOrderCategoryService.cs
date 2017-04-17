using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-14 10:23:35
	/// </summary>

	/// <summary>
	/// interface IOrderCategoryService
	/// </summary>
	public interface IOrderCategoryService
	{
		bool Add(tb_OrderCategory tb_OrderCategory);
		bool Update(tb_OrderCategory tb_OrderCategory);
		bool Delete(tb_OrderCategory tb_OrderCategory);
	}
}
