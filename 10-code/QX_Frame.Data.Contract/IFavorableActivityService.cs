using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Contract
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:15:26
	/// </summary>

	/// <summary>
	/// interface IFavorableActivityService
	/// </summary>
	public interface IFavorableActivityService
	{
		bool Add(tb_FavorableActivity tb_FavorableActivity);
		bool Update(tb_FavorableActivity tb_FavorableActivity);
		bool Delete(tb_FavorableActivity tb_FavorableActivity);
	}
}
