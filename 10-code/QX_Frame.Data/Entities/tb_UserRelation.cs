namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_UserRelation : Entity<db_AntHelp, tb_UserRelation>
    {
        [Key]
        public Guid relationUid { get; set; }

        public Guid myUid { get; set; }

        public Guid friendUid { get; set; }

        public DateTime relationTime { get; set; }

        public int relationStatusId { get; set; }

        public virtual tb_RelationStatus tb_RelationStatus { get; set; }
    }
}
