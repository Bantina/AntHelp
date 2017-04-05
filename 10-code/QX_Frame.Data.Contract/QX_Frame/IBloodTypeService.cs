using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract.QX_Frame
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.1.0
	/// author:qixiao(柒小)
	/// time:2017-04-04 16:29:28
	/// </summary>

	/// <summary>
	/// interface IBloodTypeService
	/// </summary>
	public interface IBloodTypeService
	{
		bool Add(tb_BloodType tb_BloodType);
		bool Update(tb_BloodType tb_BloodType);
		bool Delete(tb_BloodType tb_BloodType);
	}
}
