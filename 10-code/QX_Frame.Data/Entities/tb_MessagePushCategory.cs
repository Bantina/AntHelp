namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MessagePushCategory : Entity<db_AntHelp, tb_MessagePushCategory>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_MessagePushCategory()
        {
            tb_MessagePush = new HashSet<tb_MessagePush>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int messageCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string messageCategoryName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_MessagePush> tb_MessagePush { get; set; }
    }
}
