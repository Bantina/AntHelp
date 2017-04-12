namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_FavorableActivity : Entity<db_AntHelp, tb_FavorableActivity>
    {
        [Key]
        public Guid actUid { get; set; }

        [Required]
        [StringLength(50)]
        public string actTitle { get; set; }

        [Required]
        [StringLength(200)]
        public string actDescription { get; set; }

        public DateTime actStartTime { get; set; }

        public DateTime actEndTime { get; set; }

        public DateTime actPublishTime { get; set; }

        [Required]
        [StringLength(50)]
        public string actPublisher { get; set; }
    }
}
