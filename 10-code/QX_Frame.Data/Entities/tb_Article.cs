namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Article:Entity<db_AntHelp,tb_Article>
    {
        [Key]
        public Guid articleUid { get; set; }

        [Required]
        [StringLength(50)]
        public string articleTitle { get; set; }

        [Required]
        [StringLength(2000)]
        public string articleContent { get; set; }

        public Guid publisherUid { get; set; }

        public DateTime publishTime { get; set; } = DateTime.Now.ToLocalTime();

        public int clickCount { get; set; } = 0;

        public int praiseCount { get; set; } = 0;

        public int ArticleCategoryId { get; set; }

        [Required]
        [StringLength(1000)]
        public string imagesUrls { get; set; }
        //解决json循环引用问题
        [JsonIgnore]
        public virtual tb_ArticleCategory tb_ArticleCategory { get; set; }
    }
}
