using QX_Frame.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.DTO
{
    public class MessagePushViewModel
    {
        public Guid messageUid { get; set; }
        // 
        public String messageContent { get; set; }
        // 
        public String messagePusher { get; set; }
        // 
        public DateTime messagePushTime { get; set; }
        // 
        public Int32 messageCategoryId { get; set; }

        public tb_MessagePushCategory messagePushCategory { get; set; }
        //
        public Int32 messagePushStatusId { get; set; }

        public tb_MessagePushStatus messagePushStatus{get;set;}
        // 
        public Guid pushToUserUid { get; set; }

    }
}
