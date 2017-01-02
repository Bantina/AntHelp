namespace QX_Frame.Data.Entities.QX_Frame
{
    using App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class example:Entity<example>
    {
        [Key]
        public Guid uid { get; set; }

        public long timeStamp { get; set; }

        [Required]
        [StringLength(32)]
        public string token { get; set; }

        public DateTime tokenExpiring { get; set; }
    }
}
