using global::QX_Frame.App.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace QX_Frame.Data.Entities.QX_Frame
{
   public  class tb_UserMoneyBill : Entity<db_qx_frame, tb_UserMoneyBill>
    {
        [Key]
        public Guid billUid { get; set; }

        public Guid uid { get; set; }

        public int money { get; set; }

        public DateTime billTime { get; set; }

        [Required]
        [StringLength(50)]
        public string aimOrSource { get; set; }

        [Required]
        [StringLength(200)]
        public string description { get; set; }
    }
}
