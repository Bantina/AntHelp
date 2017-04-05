namespace QX_Frame.Data.Entities.QX_Frame
{
    using global::QX_Frame.App.Base;
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class tb_UserAccount : Entity<db_qx_frame, tb_UserAccount>
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
