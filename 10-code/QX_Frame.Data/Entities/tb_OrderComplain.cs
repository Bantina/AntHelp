namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_OrderComplain : Entity<db_AntHelp, tb_OrderComplain>
    {
        [Key]
        public Guid complainUid { get; set; }

        [Required]
        [StringLength(50)]
        public string complainContent { get; set; }

        public Guid complainUserUid { get; set; }

        public DateTime complainTime { get; set; }

        public int complainStatusId { get; set; }

        public virtual tb_ComplainStatus tb_ComplainStatus { get; set; }
    }
}
