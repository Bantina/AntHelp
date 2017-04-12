namespace QX_Frame.Data.Entities.QX_Frame
{
    using global::QX_Frame.App.Base;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_UserRole : Entity<db_qx_frame, tb_UserRole>
    {
        [Key]
        public Guid uid { get; set; }

        public int roleLevel { get; set; }

        //解决json循环引用问题
        [JsonIgnore]
        public virtual tb_UserRoleAttribute tb_UserRoleAttribute { get; set; }
    }
}
