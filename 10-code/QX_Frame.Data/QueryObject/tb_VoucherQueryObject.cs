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
    /// time:2017-04-12 01:28:48
    /// </summary>

    /// <summary>
    ///class tb_VoucherQueryObject
    /// </summary>
    public class tb_VoucherQueryObject : WcfQueryObject<db_AntHelp, tb_Voucher>
    {
        /// <summary>
        /// construction method
        /// </summary>
        public tb_VoucherQueryObject()
        { }

        // PK（identity）  
        public Guid voucherUid { get; set; }

        // 
        public String voucherDescription { get; set; }

        // 
        public Int32 voucherValueOfMoney { get; set; }

        // 
        public Guid userUid { get; set; }

        //query condition // null default
        public override Expression<Func<tb_Voucher, bool>> QueryCondition { get { return base.QueryCondition; } set { base.QueryCondition = value; } }

        //query condition func // true default //if QueryCondition != null this will be override !!!
        protected override Expression<Func<tb_Voucher, bool>> QueryConditionFunc()
        {
            Expression<Func<tb_Voucher, bool>> func = t => true;

            func = func.And(t => t.userUid == this.userUid);

            return func;
        }
    }
}
