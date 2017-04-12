namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_ArticleCategory : Entity<db_AntHelp, tb_ArticleCategory>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_ArticleCategory()
        {
            tb_Article = new HashSet<tb_Article>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArticleCategoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Article> tb_Article { get; set; }
    }
}
