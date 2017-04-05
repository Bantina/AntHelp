namespace QX_Frame.Data.Entities.QX_Frame
{
    using global::QX_Frame.App.Base;
    using System.ComponentModel.DataAnnotations;

    public partial class tb_Authentication:Entity<db_qx_frame, tb_Authentication>
    {
        [Key]
        public int appkey { get; set; }

        [Required]
        [StringLength(32)]
        public string secretkey { get; set; }

        [Required]
        [StringLength(2048)]
        public string rsa_publicKey { get; set; }

        [Required]
        [StringLength(2048)]
        public string rsa_privateKey { get; set; }

        [Required]
        [StringLength(20)]
        public string loginId { get; set; }

        [Required]
        [StringLength(32)]
        public string tokensign { get; set; }
    }
}
