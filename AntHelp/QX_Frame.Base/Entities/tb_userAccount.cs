namespace QX_Frame.Base.Entities
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
        public string loginId { get; set; } = default(string);

        [Required]
        [StringLength(32)]
        public string pwd { get; set; } = default(string);

        [Required]
        [StringLength(50)]
        public string email { get; set; } = default(string);

        [Required]
        [StringLength(50)]
        public string phone { get; set; } = default(string);
    }
}
