using QX_Frame.Data.Entities.QX_Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.DTO
{
    public class CommentReplyViewModel
    {
        public Guid commentUid { get; set; }
        // 
        public Guid articleIdOrCommentId { get; set; }
        // 
        public String commentUserLoginId { get; set; }

        // 
        public String commentContent { get; set; }
        // 
        public string commentTime { get; set; }

        public List<CommentReplyViewModel> commentReplyList { get; set; }
    }
}
