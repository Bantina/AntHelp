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
	/// time:2017-04-04 16:44:02
	/// </summary>

	/// <summary>
	/// class BloodTypeService
	/// </summary>
	public class BloodTypeService:WcfService, IBloodTypeService
	{
		private tb_BloodType _tb_BloodType;
		/// <summary>
		/// construction method
		/// </summary>
		public BloodTypeService()
		{}

		public BloodTypeService(tb_BloodType tb_BloodType)
		{
			this._tb_BloodType = tb_BloodType;
		}
		public bool Add(tb_BloodType tb_BloodType)
		{
			return tb_BloodType.Add();
		}
		public bool Update(tb_BloodType tb_BloodType)
		{
			return tb_BloodType.Update();
		}
		public bool Delete(tb_BloodType tb_BloodType)
		{
			return tb_BloodType.Delete();
		}
	}
}
