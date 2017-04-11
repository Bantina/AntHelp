using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:24:27
	/// </summary>

	/// <summary>
	/// class UserRelationService
	/// </summary>
	public class UserRelationService:WcfService, IUserRelationService
	{
		private tb_UserRelation _tb_UserRelation;
		/// <summary>
		/// construction method
		/// </summary>
		public UserRelationService()
		{}

		public UserRelationService(tb_UserRelation tb_UserRelation)
		{
			this._tb_UserRelation = tb_UserRelation;
		}
		public bool Add(tb_UserRelation tb_UserRelation)
		{
			return tb_UserRelation.Add(tb_UserRelation);
		}
		public bool Update(tb_UserRelation tb_UserRelation)
		{
			return tb_UserRelation.Update(tb_UserRelation);
		}
		public bool Delete(tb_UserRelation tb_UserRelation)
		{
			return tb_UserRelation.Delete(tb_UserRelation);
		}
	}
}
