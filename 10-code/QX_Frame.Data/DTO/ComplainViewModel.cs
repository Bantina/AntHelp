using QX_Frame.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.DTO
{
    public class ComplainViewModel
    {
        public Guid complainUid { get; set; }
        // 
        public String complainContent { get; set; }
        // 
        public Guid complainUserUid { get; set; }
        // 
        public DateTime complainTime { get; set; }
        // 
        public Int32 complainStatusId { get; set; }

        public tb_ComplainStatus complainStatus { get; set; }
    }
}
