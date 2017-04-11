using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:22:53
	/// </summary>

	/// <summary>
	/// class FavorableActivityService
	/// </summary>
	public class FavorableActivityService:WcfService, IFavorableActivityService
	{
		private tb_FavorableActivity _tb_FavorableActivity;
		/// <summary>
		/// construction method
		/// </summary>
		public FavorableActivityService()
		{}

		public FavorableActivityService(tb_FavorableActivity tb_FavorableActivity)
		{
			this._tb_FavorableActivity = tb_FavorableActivity;
		}
		public bool Add(tb_FavorableActivity tb_FavorableActivity)
		{
			return tb_FavorableActivity.Add(tb_FavorableActivity);
		}
		public bool Update(tb_FavorableActivity tb_FavorableActivity)
		{
			return tb_FavorableActivity.Update(tb_FavorableActivity);
		}
		public bool Delete(tb_FavorableActivity tb_FavorableActivity)
		{
			return tb_FavorableActivity.Delete(tb_FavorableActivity);
		}
	}
}
