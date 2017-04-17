namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using Newtonsoft.Json;
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
        [ForeignKey("tb_OrderCategory")]

        public int orderCategoryId { get; set; }

        public Guid receiverUid { get; set; }

        public DateTime receiveTime { get; set; }

        public int orderStatusId { get; set; }

        public int orderValue { get; set; }

        public int allowVoucher { get; set; }

        public int voucherMax { get; set; }

        public Guid evaluateUid { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        public int phone { get; set; }

        [StringLength(500)]
        public string imageUrls { get; set; }
        //解决json循环引用问题
        [JsonIgnore]
        public virtual tb_OrderEvaluate tb_OrderEvaluate { get; set; }
        //解决json循环引用问题
        [JsonIgnore]
        public virtual tb_OrderCategory tb_OrderCategory { get; set; }
        //解决json循环引用问题
        [JsonIgnore]
        public virtual tb_OrderStatus tb_OrderStatus { get; set; }
    }
}
