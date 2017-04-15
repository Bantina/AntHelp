using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.Options
{
    /**
     * author:qixiao
     * create:2017-4-14 10:49:17
     * */
    public enum opt_OrderStatus : int
    {
        待接单 = 1,
        未支付 = 2,
        已支付 = 3,
        已接单 = 4,
        完成确认 = 5,
        已完成 = 6,
        投诉流程 = 7,
        订单结束 = 8,
        发布者取消=9,
        接单人取消=10
    }
}
