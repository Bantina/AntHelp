namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_OrderEvaluate : Entity<db_AntHelp, tb_OrderEvaluate>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_OrderEvaluate()
        {
            tb_Order = new HashSet<tb_Order>();
        }

        [Key]
        public Guid evaluateUid { get; set; }

        public int publisherScore { get; set; }

        public int receiveScore { get; set; }
        //解决json循环引用问题
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Order> tb_Order { get; set; }
    }
}
