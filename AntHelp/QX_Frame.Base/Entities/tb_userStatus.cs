namespace QX_Frame.Base.Entities
{
    using Options;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_userStatus
    {
        [Key]
        public Guid uid { get; set; }

        public int statusLevel { get; set; } = (int)AccountStatus.NORMAL;

        public virtual tb_userStatusName tb_userStatusName { get; set; }
    }
}
