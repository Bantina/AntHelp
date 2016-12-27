namespace QX_Frame.Data.Entities.QX_Frame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_userInfo
    {
        [Key]
        public Guid uid { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string phone { get; set; }

        [Required]
        [StringLength(20)]
        public string nickName { get; set; }

        [Required]
        [StringLength(200)]
        public string headImageUrl { get; set; }
    }
}
