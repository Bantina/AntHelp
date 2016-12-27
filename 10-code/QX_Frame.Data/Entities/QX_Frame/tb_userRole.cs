namespace QX_Frame.Data.Entities.QX_Frame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_userRole
    {
        [Key]
        public Guid uid { get; set; }

        public int roleId { get; set; }

        public virtual tb_userRoleAttribute tb_userRoleAttribute { get; set; }
    }
}
