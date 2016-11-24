namespace QX_Frame.Base.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_token
    {
        [Key]
        public Guid uid { get; set; }

        public DateTime timeStamp { get; set; } = DateTime.Now;

        [Required]
        [StringLength(32)]
        public string token { get; set; } = default(string);

        public DateTime tokenExpiring { get; set; } = DateTime.Now;
    }
}
