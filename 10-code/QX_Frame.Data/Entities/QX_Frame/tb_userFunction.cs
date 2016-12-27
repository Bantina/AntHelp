namespace QX_Frame.Data.Entities.QX_Frame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_userFunction
    {
        [Key]
        public Guid functionId { get; set; }

        public Guid uid { get; set; }

        [Required]
        [StringLength(100)]
        public string functionRoute { get; set; }

        [StringLength(200)]
        public string description { get; set; }

        public virtual tb_userFunctionAttribute tb_userFunctionAttribute { get; set; }
    }
}
