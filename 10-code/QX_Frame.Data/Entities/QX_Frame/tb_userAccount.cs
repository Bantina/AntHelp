namespace QX_Frame.Data.Entities.QX_Frame
{
    using App.Base;
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class tb_userAccount:Entity<db_qx_frame,tb_userAccount>
    {
        [Key]
        public Guid uid { get; set; }

        [Required]
        [StringLength(20)]
        public string loginId { get; set; }

        [Required]
        [StringLength(50)]
        public string pwd { get; set; }
    }
}
