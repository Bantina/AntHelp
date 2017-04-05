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
	/// time:2017-04-05 10:41:37
	/// </summary>

	/// <summary>
	///class tb_UserAccountInfoQueryObject
	/// </summary>
	public class tb_UserAccountInfoQueryObject:WcfQueryObject<db_qx_frame,tb_UserAccountInfo>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_UserAccountInfoQueryObject()
		{}

		// PK（identity）  
		public Guid uid { get;set; }

		// 
		public String loginId { get;set; }

		// 
		public String nickName { get;set; }

		// 
		public String email { get;set; }

		// 
		public String phone { get;set; }

		// 
		public String headImageUrl { get;set; }

		// 
		public Int32 age { get;set; }

		// 
		public Int32 sexId { get;set; }

		// 
		public String birthday { get;set; }

		// 
		public Int32 bloodTypeId { get;set; }

		// 
		public String position { get;set; }

		// 
		public String school { get;set; }

		// 
		public String location { get;set; }

		// 
		public String company { get;set; }

		// 星座
		public String constellation { get;set; }

		// 生肖
		public String chineseZodiac { get;set; }

		// 个性签名
		public String personalizedSignature { get;set; }

		// 个人说明
		public String personalizedDescription { get;set; }

		//query condition // null default
		public override Expression<Func<tb_UserAccountInfo, bool>> QueryCondition { get => base.QueryCondition; set => base.QueryCondition = value; }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_UserAccountInfo, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_UserAccountInfo, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
