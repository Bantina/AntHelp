namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Voucher : Entity<db_AntHelp, tb_Voucher>
    {
        [Key]
        public Guid voucherUid { get; set; }

        [Required]
        [StringLength(200)]
        public string voucherDescription { get; set; }

        public int voucherValueOfMoney { get; set; }

        public Guid userUid { get; set; }
    }
}
