namespace QX_Frame.Data.Entities.QX_Frame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_userAccount
    {
        [Key]
        public Guid uid { get; set; }

        [Required]
        [StringLength(20)]
        public string loginId { get; set; }

        [Required]
        [StringLength(50)]
        public string pwd { get; set; }
    }
}
