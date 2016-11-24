namespace QX_Frame.Base.Entities
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
        [StringLength(20)]
        public string loginId { get; set; } = default(string);

        [Required]
        [StringLength(200)]
        public string headImageUrl { get; set; } = "http:localhost:3998/Files/images/userHeadImages/xxx";

        [Required]
        [StringLength(20)]
        public string nickName { get; set; } = default(string);
    }
}
