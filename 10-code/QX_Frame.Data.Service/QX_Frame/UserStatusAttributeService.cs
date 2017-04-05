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
	/// time:2017-04-04 16:45:29
	/// </summary>

	/// <summary>
	/// class UserStatusAttributeService
	/// </summary>
	public class UserStatusAttributeService:WcfService, IUserStatusAttributeService
	{
		private tb_UserStatusAttribute _tb_UserStatusAttribute;
		/// <summary>
		/// construction method
		/// </summary>
		public UserStatusAttributeService()
		{}

		public UserStatusAttributeService(tb_UserStatusAttribute tb_UserStatusAttribute)
		{
			this._tb_UserStatusAttribute = tb_UserStatusAttribute;
		}
		public bool Add(tb_UserStatusAttribute tb_UserStatusAttribute)
		{
			return tb_UserStatusAttribute.Add();
		}
		public bool Update(tb_UserStatusAttribute tb_UserStatusAttribute)
		{
			return tb_UserStatusAttribute.Update();
		}
		public bool Delete(tb_UserStatusAttribute tb_UserStatusAttribute)
		{
			return tb_UserStatusAttribute.Delete();
		}
	}
}
