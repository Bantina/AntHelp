using System.Net;

namespace QX_Frame.Helper_DG_Framework
{
    /*2016-11-3 00:19:31 author:qixiao*/
    public abstract class Return_Helper_DG
    {
        public static object Object_TF_Msg_Code(bool tfmark, string msg, HttpStatusCode statuscode = HttpStatusCode.OK)
        {
            return new { tfmark = tfmark, msg = msg, statuscode = statuscode };
        }

        public static object Object_TF_Msg_Code_Uri(bool tfmark, string msg, HttpStatusCode statuscode = HttpStatusCode.OK, string uri = "")
        {
            return new { tfmark = tfmark, msg = msg, statuscode = statuscode, uri = uri };
        }

        public static object Object_TF_Msg_Data_Count(bool tfmark, string msg, dynamic data = null, int count = 0)
        {
            return new { tfmark = tfmark, msg = msg, data = data, count = count };
        }

        public static object Object_TF_Msg_Data_Count_Code(bool tfmark, string msg, dynamic data = null, int count = 0, HttpStatusCode statuscode = HttpStatusCode.OK)
        {
            return new { tfmark = tfmark, msg = msg, data = data, count = count, statuscode = statuscode };
        }

        public static object Object_TF_Msg_Data_Count_Code_Uri(bool tfmark, string msg, dynamic data = null, int count = 0, HttpStatusCode statuscode = HttpStatusCode.OK, string uri = "")
        {
            return new { tfmark = tfmark, msg = msg, data = data, count = count, statuscode = statuscode, uri = uri };
        }
    }
}
