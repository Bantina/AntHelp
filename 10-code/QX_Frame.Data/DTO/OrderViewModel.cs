using QX_Frame.Data.Entities;
using QX_Frame.Data.Entities.QX_Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.DTO
{
    public class OrderViewModel
    {
        // PK（identity）  
        public Guid orderUid { get; set; }
        // 
        public Guid publisherUid { get; set; }

        public tb_UserAccountInfo publisherInfo { get; set; }
        // 
        public string publishTime { get; set; }
        // 
        public String orderDescription { get; set; }
        // 
        public Int32 orderCategoryId { get; set; }

        public tb_OrderCategory orderCategory { get; set; }
        // 
        public Guid receiverUid { get; set; }
        // 
        public tb_UserAccountInfo receiverInfo { get; set; }

        public string receiveTime { get; set; }
        // 
        public Int32 orderStatusId { get; set; }

        public tb_OrderStatus orderStatus { get; set; }
        // 
        public Int32 orderValue { get; set; }
        // 
        public Int32 allowVoucher { get; set; }
        // 
        public Int32 voucherMax { get; set; }
        // 
        public Guid evaluateUid { get; set; }

        public tb_OrderEvaluate orderEvaluate { get; set; }
        // 
        public String address { get; set; }
        // 
        public int phone { get; set; }
        // 
        public String imageUrls { get; set; }

    }
}
