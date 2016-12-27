using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace QX_Frame.Helper_DG_Framework
{
    /*2016-11-3 11:50:08 author:qixiao*/
    public abstract class Convert_Helper_DG
    {
        //public static T Json_TO_T<T>(string json)
        //{
        //    try
        //    {
        //        return new JavaScriptSerializer().Deserialize<T>(json);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log_Helper_DG.Log_Error(ex.ToString(), "Json Convert Error ");
        //        return default(T);
        //    }
        //}

        /// <summary>
        /// Json_To_T
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="jsonText">string jsonText</param>
        /// <returns></returns>
        public static T Json_To_T<T>(string jsonText)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(() => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonText), "Convert_Helper_DG Json_To_T");
        }

        public static string T_To_Json<T>(T t)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(() => Newtonsoft.Json.JsonConvert.SerializeObject(t), "Convert_Helper_DG Object_To_Json");
        }

        public static string Object_To_Json<T>(object obj)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(() => Newtonsoft.Json.JsonConvert.SerializeObject(obj), "Convert_Helper_DG Object_To_Json");
        }

        
    }
}
