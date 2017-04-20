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
    public class tb_OrderQueryObject : WcfQueryObject<db_AntHelp, tb_Order>
    {
        /// <summary>
        /// construction method
        /// </summary>
        public tb_OrderQueryObject()
        { }

        // PK（identity）  
        public Guid orderUid { get; set; }

        public Guid publisherUid { get; set; }

        public DateTime publishTime { get; set; }

        public string orderDescription { get; set; }

        public int orderCategoryId { get; set; }

        public Guid receiverUid { get; set; }

        public DateTime receiveTime { get; set; }


        public int orderStatusId { get; set; }

        public int orderValue { get; set; }

        public int allowVoucher { get; set; }

        public int voucherMax { get; set; }

        public Guid evaluateUid { get; set; }

        public string address { get; set; }

        public int phone { get; set; }

        public string imageUrls { get; set; }

        public int queryId { get; set; }

        //query condition // null default
        public override Expression<Func<tb_Order, bool>> QueryCondition { get { return base.QueryCondition; } set { base.QueryCondition = value; } }

        //query condition func // true default //if QueryCondition != null this will be override !!!
        protected override Expression<Func<tb_Order, bool>> QueryConditionFunc()
        {
            Expression<Func<tb_Order, bool>> func = t => true;

            if (!string.IsNullOrEmpty(this.orderDescription))
            {
                func = func.And(t => t.orderDescription.Contains(this.orderDescription));
            }

            if (this.orderCategoryId != -1)
            {
                func = func.And(t => t.orderCategoryId == this.orderCategoryId);
            }

            if (this.queryId == 0)
            {
                func = func.And(t => t.publisherUid == this.publisherUid || t.receiverUid == this.receiverUid);
            }

            if (this.queryId == 1)
            {
                func = func.And(t => t.publisherUid == this.publisherUid);
            }
            else if (this.queryId == 2)
            {
                func = func.And(t => t.receiverUid == this.receiverUid);
            }

            if (this.orderStatusId!=-1)
            {
                func = func.And(t => t.orderStatusId == this.orderStatusId);
            }

            return func;
        }
    }
}
