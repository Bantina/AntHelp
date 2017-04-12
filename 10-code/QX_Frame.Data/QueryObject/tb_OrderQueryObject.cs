using QX_Frame.App.Base;
using QX_Frame.Data.Entities;
using System;
using System.Linq.Expressions;

namespace QX_Frame.Data.QueryObject
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-12 01:28:09
	/// </summary>

	/// <summary>
	///class tb_OrderQueryObject
	/// </summary>
	public class tb_OrderQueryObject:WcfQueryObject<db_AntHelp,tb_Order>
	{
		/// <summary>
		/// construction method
		/// </summary>
		public tb_OrderQueryObject()
		{}

		// PK（identity）  
		public Guid orderUid { get;set; }

		// 
		public Guid publisherUid { get;set; }

		// 
		public DateTime publishTime { get;set; }

		// 
		public String orderDescription { get;set; }

		// 
		public Int32 orderCategoryId { get;set; }

		// 
		public Guid receiverUid { get;set; }

		// 
		public Int32 orderStatusId { get;set; }

		// 
		public Int32 orderValue { get;set; }

		// 
		public Int32 allowVoucher { get;set; }

		// 
		public Int32 voucherMax { get;set; }

		// 
		public Int32 evaluateId { get;set; }

		//query condition // null default
		public override Expression<Func<tb_Order, bool>> QueryCondition {get { return base.QueryCondition; } set { base.QueryCondition = value; } }

		//query condition func // true default //if QueryCondition != null this will be override !!!
		protected override Expression<Func<tb_Order, bool>> QueryConditionFunc()
		{
			Expression<Func<tb_Order, bool>> func = t => true;

			if (!string.IsNullOrEmpty(""))
			{
				func = func.And(t => true);
			}

			return func;
		}
	}
}
