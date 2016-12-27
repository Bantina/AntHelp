namespace QX_Frame.Data.Entities.QX_Frame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_userFunctionAttribute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_userFunctionAttribute()
        {
            tb_userFunction = new HashSet<tb_userFunction>();
        }

        [Key]
        [StringLength(100)]
        public string functionNo { get; set; }

        [Required]
        [StringLength(50)]
        public string functionName { get; set; }

        [Required]
        [StringLength(200)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_userFunction> tb_userFunction { get; set; }
    }
}
