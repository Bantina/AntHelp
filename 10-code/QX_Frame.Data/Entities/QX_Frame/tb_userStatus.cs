namespace QX_Frame.Data.Entities.QX_Frame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_userStatus
    {
        [Key]
        public Guid uid { get; set; }

        public int statusLevel { get; set; }

        public virtual tb_userStatusAttribute tb_userStatusAttribute { get; set; }
    }
}
