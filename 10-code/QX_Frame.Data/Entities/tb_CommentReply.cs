namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_CommentReply : Entity<db_AntHelp, tb_CommentReply>
    {
        [Key]
        public Guid commentUid { get; set; }

        public Guid articleIdOrCommentId { get; set; }

        [Required]
        [StringLength(20)]
        public string commentUserLoginId { get; set; }

        [Required]
        [StringLength(1000)]
        public string commentContent { get; set; }

        public DateTime commentTime { get; set; }
    }
}
