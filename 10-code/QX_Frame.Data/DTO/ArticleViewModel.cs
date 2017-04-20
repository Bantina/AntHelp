using QX_Frame.Data.Entities;
using QX_Frame.Data.Entities.QX_Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.DTO
{
   public class ArticleViewModel
    {
        public Guid articleUid { get; set; }
        // 
        public String articleTitle { get; set; }
        // 
        public String articleContent { get; set; }
        // 
        public Guid publisherUid { get; set; }

        public tb_UserAccountInfo publisherInfo { get; set; }
        // 
        public string publishTime { get; set; }
        // 
        public Int32 clickCount { get; set; }
        // 
        public Int32 praiseCount { get; set; }
        // 
        public Int32 ArticleCategoryId { get; set; }

        public tb_ArticleCategory articleCategory { get; set; }
        // 
        public String imagesUrls { get; set; }

        public string[] imageDatas { get; set; }

    }
}
