using QX_Frame.App.Base;
using QX_Frame.Data.Entities.QX_Frame;
using System;
using System.Linq.Expressions;

namespace QX_Frame.Data.QueryObject
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-05 10:41:19
	/// </summary>

	/// <summary>
	///class tb_BloodTypeQueryObject
	/// </summary>
	public class tb_BloodTypeQueryObject:WcfQueryObject<db_qx_frame,tb_BloodType>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_BloodTypeQueryObject()
		{}

		// PK（identity）  
		public Int32 bloodTypeId { get;set; }

		// 
		public String bloodTypeName { get;set; }

		//query condition // null default
		public override Expression<Func<tb_BloodType, bool>> QueryCondition { get => base.QueryCondition; set => base.QueryCondition = value; }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_BloodType, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_BloodType, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
