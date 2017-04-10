using QX_Frame.App.Base;
using QX_Frame.Data.Contract.QX_Frame;
using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Service.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-08 18:45:57
	/// </summary>

	/// <summary>
	/// class UserFunctionService
	/// </summary>
	public class UserFunctionService:WcfService, IUserFunctionService
	{
		private tb_UserFunction _tb_UserFunction;
		/// <summary>
		/// construction method
		/// </summary>
		public UserFunctionService()
		{}

		public UserFunctionService(tb_UserFunction tb_UserFunction)
		{
			this._tb_UserFunction = tb_UserFunction;
		}
		public bool Add(tb_UserFunction tb_UserFunction)
		{
			return tb_UserFunction.Add(tb_UserFunction);
		}
		public bool Update(tb_UserFunction tb_UserFunction)
		{
			return tb_UserFunction.Update(tb_UserFunction);
		}
		public bool Delete(tb_UserFunction tb_UserFunction)
		{
			return tb_UserFunction.Delete(tb_UserFunction);
		}
	}
}
