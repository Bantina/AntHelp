namespace QX_Frame.Data.Entities.QX_Frame
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_UserAccountInfo : Entity<db_qx_frame, tb_UserAccountInfo>
    {
        [Key]
        public Guid uid { get; set; }

        [StringLength(20)]
        public string loginId { get; set; }

        [StringLength(20)]
        public string nickName { get; set; } = "NIKE" + new Random().Next(10000, 99999).ToString();

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(200)]
        public string headImageUrl { get; set; }

        public int age { get; set; } = 0;

        public int sexId { get; set; } = 0;

        [StringLength(50)]
        public string birthday { get; set; }

        public int bloodTypeId { get; set; } = 0;

        [StringLength(20)]
        public string position { get; set; }

        [StringLength(50)]
        public string school { get; set; }

        [StringLength(50)]
        public string location { get; set; }

        [StringLength(50)]
        public string company { get; set; }

        [StringLength(10)]
        public string constellation { get; set; }

        [StringLength(10)]
        public string chineseZodiac { get; set; }

        [StringLength(50)]
        public string personalizedSignature { get; set; }

        [StringLength(200)]
        public string personalizedDescription { get; set; }

        public virtual tb_BloodType tb_BloodType { get; set; }

        public virtual tb_Sex tb_Sex { get; set; }
    }
}
