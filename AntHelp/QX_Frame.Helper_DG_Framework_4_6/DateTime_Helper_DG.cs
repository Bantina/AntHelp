using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Helper_DG_Framework_4_6
{
    /*time:2016-10-30 21:07:41 author:qixiao*/
    public abstract class DateTime_Helper_DG
    {
        public static string Get_DateTime_Now_24HourType()
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
                () =>
                {
                    DateTime dt;
                    DateTime.TryParseExact(DateTime.Now.ToString(), "dd/M/yyyy tt hh:mm:ss", new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out dt);
                    dt = DateTime.Now;
                    return dt.ToString("yyyyMMdd HH:mm:ss");
                }, "DateTime_Helper_DG Get_DateTime_Now_24HourType");
        }
    }
}
