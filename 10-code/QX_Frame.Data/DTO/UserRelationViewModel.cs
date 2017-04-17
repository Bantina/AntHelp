using QX_Frame.Data.Entities.QX_Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.DTO
{
    public class UserRelationViewModel
    {
        public Guid relationUid { get; set; }
        // 
        public Guid myUid { get; set; }

        public tb_UserAccountInfo myUserAccountInfo { get; set; }
        // 
        public Guid friendUid { get; set; }

        public tb_UserAccountInfo friendUserAccountInfo { get; set; }
        // 
        public DateTime relationTime { get; set; }

        
    }
}
