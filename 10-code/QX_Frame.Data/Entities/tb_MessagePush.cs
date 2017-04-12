namespace QX_Frame.Data.Entities
{
    using global::QX_Frame.App.Base;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MessagePush : Entity<db_AntHelp, tb_MessagePush>
    {
        [Key]
        public Guid messageUid { get; set; }

        [Required]
        [StringLength(50)]
        public string messageTitle { get; set; }

        [Required]
        [StringLength(50)]
        public string messagePusher { get; set; }

        public DateTime messagePushTime { get; set; }

        public int messageCategoryId { get; set; }

        public int messagePushStatusId { get; set; }

        public Guid pushToUserUid { get; set; }
        //解决json循环引用问题
        [JsonIgnore]
        public virtual tb_MessagePushStatus tb_MessagePushStatus { get; set; }
        //解决json循环引用问题
        [JsonIgnore]

        public virtual tb_MessagePushCategory tb_MessagePushCategory { get; set; }
    }
}
