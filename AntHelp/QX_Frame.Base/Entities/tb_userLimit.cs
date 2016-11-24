namespace QX_Frame.Base.Entities
{
    using Options;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_userLimit
    {
        [Key]
        public Guid uid { get; set; }

        public int limitLevel { get; set; } = (int)AccountLimits.ALL;

        public virtual tb_userLimitName tb_userLimitName { get; set; }
    }
}
