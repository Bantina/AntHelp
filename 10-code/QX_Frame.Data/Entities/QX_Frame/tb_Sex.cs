namespace QX_Frame.Data.Entities.QX_Frame
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Sex : Entity<db_qx_frame, tb_Sex>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Sex()
        {
            tb_UserAccountInfo = new HashSet<tb_UserAccountInfo>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sexId { get; set; }

        [Required]
        [StringLength(10)]
        public string sexName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_UserAccountInfo> tb_UserAccountInfo { get; set; }
    }
}
