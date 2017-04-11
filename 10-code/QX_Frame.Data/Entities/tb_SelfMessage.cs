namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_SelfMessage : Entity<db_AntHelp, tb_SelfMessage>
    {
        [Key]
        public Guid selfMessageUid { get; set; }

        [Required]
        [StringLength(500)]
        public string selfMessageContent { get; set; }

        public DateTime publishTime { get; set; }

        public Guid publisherUid { get; set; }

        public int clickCount { get; set; }

        public int praiseCount { get; set; }

        [Required]
        [StringLength(1000)]
        public string imagesUrls { get; set; }
    }
}
