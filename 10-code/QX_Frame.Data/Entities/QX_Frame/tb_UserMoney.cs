
    using global::QX_Frame.App.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    namespace QX_Frame.Data.Entities.QX_Frame
{
    public class tb_UserMoney : Entity<db_qx_frame, tb_UserMoney>
    {
        [Key]
        public Guid uid { get; set; }

        public int  money { get; set; }
    }
}
