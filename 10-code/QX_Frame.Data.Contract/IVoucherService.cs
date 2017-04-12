using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:16:38
	/// </summary>

	/// <summary>
	/// interface IVoucherService
	/// </summary>
	public interface IVoucherService
	{
		bool Add(tb_Voucher tb_Voucher);
		bool Update(tb_Voucher tb_Voucher);
		bool Delete(tb_Voucher tb_Voucher);
	}
}
