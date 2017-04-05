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
	/// time:2017-04-04 16:43:49
	/// </summary>

	/// <summary>
	/// class AuthenticationService
	/// </summary>
	public class AuthenticationService:WcfService, IAuthenticationService
	{
		private tb_Authentication _tb_Authentication;
		/// <summary>
		/// construction method
		/// </summary>
		public AuthenticationService()
		{}

		public AuthenticationService(tb_Authentication tb_Authentication)
		{
			this._tb_Authentication = tb_Authentication;
		}
		public bool Add(tb_Authentication tb_Authentication)
		{
			return tb_Authentication.Add();
		}
		public bool Update(tb_Authentication tb_Authentication)
		{
			return tb_Authentication.Update();
		}
		public bool Delete(tb_Authentication tb_Authentication)
		{
			return tb_Authentication.Delete();
		}
	}
}
