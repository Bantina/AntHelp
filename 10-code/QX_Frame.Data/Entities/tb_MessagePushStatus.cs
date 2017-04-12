namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MessagePushStatus : Entity<db_AntHelp, tb_MessagePushStatus>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_MessagePushStatus()
        {
            tb_MessagePush = new HashSet<tb_MessagePush>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int messageStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_MessagePush> tb_MessagePush { get; set; }
    }
}
