namespace QX_Frame.Data.Entities.QX_Frame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_userRoleAttribute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_userRoleAttribute()
        {
            tb_userRole = new HashSet<tb_userRole>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int roleId { get; set; }

        [Required]
        [StringLength(50)]
        public string roleName { get; set; }

        [Required]
        [StringLength(200)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_userRole> tb_userRole { get; set; }
    }
}
