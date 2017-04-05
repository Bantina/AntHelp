namespace QX_Frame.Data.Entities.QX_Frame
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_UserFunction : Entity<db_qx_frame, tb_UserFunction>
    {
        [Key]
        public Guid functionId { get; set; }

        public Guid uid { get; set; }

        [Required]
        [StringLength(100)]
        public string functionRoute { get; set; }

        [Required]
        [StringLength(50)]
        public string functionName { get; set; }

        [Required]
        [StringLength(200)]
        public string description { get; set; }
    }
}
