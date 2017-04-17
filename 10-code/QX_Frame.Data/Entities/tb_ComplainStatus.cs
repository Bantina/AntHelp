namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_ComplainStatus : Entity<db_AntHelp, tb_ComplainStatus>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_ComplainStatus()
        {
            tb_OrderComplain = new HashSet<tb_Complain>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int complainStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string complainStatusName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Complain> tb_OrderComplain { get; set; }
    }
}
