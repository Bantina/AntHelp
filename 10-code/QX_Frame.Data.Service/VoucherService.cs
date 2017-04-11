using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:24:35
	/// </summary>

	/// <summary>
	/// class VoucherService
	/// </summary>
	public class VoucherService:WcfService, IVoucherService
	{
		private tb_Voucher _tb_Voucher;
		/// <summary>
		/// construction method
		/// </summary>
		public VoucherService()
		{}

		public VoucherService(tb_Voucher tb_Voucher)
		{
			this._tb_Voucher = tb_Voucher;
		}
		public bool Add(tb_Voucher tb_Voucher)
		{
			return tb_Voucher.Add(tb_Voucher);
		}
		public bool Update(tb_Voucher tb_Voucher)
		{
			return tb_Voucher.Update(tb_Voucher);
		}
		public bool Delete(tb_Voucher tb_Voucher)
		{
			return tb_Voucher.Delete(tb_Voucher);
		}
	}
}
