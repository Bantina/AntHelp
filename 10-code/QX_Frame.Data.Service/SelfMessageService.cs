using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:24:19
	/// </summary>

	/// <summary>
	/// class SelfMessageService
	/// </summary>
	public class SelfMessageService:WcfService, ISelfMessageService
	{
		private tb_SelfMessage _tb_SelfMessage;
		/// <summary>
		/// construction method
		/// </summary>
		public SelfMessageService()
		{}

		public SelfMessageService(tb_SelfMessage tb_SelfMessage)
		{
			this._tb_SelfMessage = tb_SelfMessage;
		}
		public bool Add(tb_SelfMessage tb_SelfMessage)
		{
			return tb_SelfMessage.Add(tb_SelfMessage);
		}
		public bool Update(tb_SelfMessage tb_SelfMessage)
		{
			return tb_SelfMessage.Update(tb_SelfMessage);
		}
		public bool Delete(tb_SelfMessage tb_SelfMessage)
		{
			return tb_SelfMessage.Delete(tb_SelfMessage);
		}
	}
}
