namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Order : Entity<db_AntHelp, tb_Order>
    {
        [Key]
        public Guid orderUid { get; set; }

        public Guid publisherUid { get; set; }

        public DateTime publishTime { get; set; }

        [Required]
        [StringLength(200)]
        public string orderDescription { get; set; }

        public int orderCategoryId { get; set; }

        public Guid receiverUid { get; set; }

        public int orderStatusId { get; set; }

        public int orderValue { get; set; }

        public int allowVoucher { get; set; }

        public int voucherMax { get; set; }

        public int evaluateId { get; set; }

        public virtual tb_OrderEvaluate tb_OrderEvaluate { get; set; }

        public virtual tb_OrderStatus tb_OrderStatus { get; set; }
    }
}
