using QX_Frame.App.Base;
using QX_Frame.Data.Contract.QX_Frame;
using QX_Frame.Data.Entities.QX_Frame;
using System;

namespace QX_Frame.Data.Service.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:44:11
	/// </summary>

	/// <summary>
	/// class SexService
	/// </summary>
	public class SexService:WcfService, ISexService
	{
		private tb_Sex _tb_Sex;
		/// <summary>
		/// construction method
		/// </summary>
		public SexService()
		{}

		public SexService(tb_Sex tb_Sex)
		{
			this._tb_Sex = tb_Sex;
		}
		public bool Add(tb_Sex tb_Sex)
		{
			return tb_Sex.Add();
		}
		public bool Update(tb_Sex tb_Sex)
		{
			return tb_Sex.Update();
		}
		public bool Delete(tb_Sex tb_Sex)
		{
			return tb_Sex.Delete();
		}
	}
}
