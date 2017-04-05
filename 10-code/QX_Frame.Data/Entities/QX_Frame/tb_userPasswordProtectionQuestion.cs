namespace QX_Frame.Data.Entities.QX_Frame
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_UserPasswordProtectionQuestion : Entity<db_qx_frame, tb_UserPasswordProtectionQuestion>
    {
        [Key]
        public Guid questionId { get; set; }

        public Guid uid { get; set; }

        [Required]
        [StringLength(50)]
        public string question { get; set; }

        [Required]
        [StringLength(50)]
        public string answer { get; set; }
    }
}
