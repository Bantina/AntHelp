using QX_Frame.Data.Entities.QX_Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.DTO
{
    public class SelfMessageViewModel
    {
        public Guid selfMessageUid { get; set; }
        // 
        public String selfMessageContent { get; set; }
        // 
        public DateTime publishTime { get; set; }
        public string publishTimeString { get; set; }
        // 
        public Guid publisherUid { get; set; }

        public tb_UserAccountInfo userAccountInfo { get; set; }
        // 
        public Int32 clickCount { get; set; }
        // 
        public Int32 praiseCount { get; set; }
        // 
        public String imagesUrls { get; set; }

    }
}
