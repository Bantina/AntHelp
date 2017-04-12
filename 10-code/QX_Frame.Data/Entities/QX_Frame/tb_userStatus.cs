namespace QX_Frame.Data.Entities.QX_Frame
{
    using global::QX_Frame.App.Base;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class tb_UserStatus : Entity<db_qx_frame, tb_UserStatus>
    {
        [Key]
        public Guid uid { get; set; }

        public int statusLevel { get; set; }

        //���jsonѭ����������
        [JsonIgnore]
        public virtual tb_UserStatusAttribute tb_UserStatusAttribute { get; set; }
    }
}
