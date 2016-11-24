using System;
using System.Text;

namespace QX_Frame.Helper_DG_Framework_4_6
{
    /*2016-11-2 15:13:28 author:qixiao*/
    public abstract class String_Helper_DG
    {
        /// <summary>
        /// get Random String
        /// </summary>
        /// <param name="length">string length</param>
        /// <returns></returns>
        public static string Get_RandomString(int length)
            => ProcessFlow_Helper_DG.channel_Exception_Log(
                () =>
                {
                    string str = string.Empty;
                    long num2 = DateTime.Now.Ticks;
                    Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> 1)));
                    for (int i = 0; i < length; i++)
                    {
                        char ch;
                        int num = random.Next();
                        if ((num % 2) == 0)
                        {
                            ch = (char)(0x30 + ((ushort)(num % 10)));
                        }
                        else
                        {
                            ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                        }
                        str = str + ch.ToString();
                    }
                    return str;
                }, "String_Helper_DG Get_RandomString");

        /// <summary>
        /// get_String_By_Stream
        /// </summary>
        /// <param name="inputStream">inputStream</param>
        /// <param name="encoding">encoding="UTF-8"</param>
        /// <returns></returns>
        public static string get_String_By_Stream(System.IO.Stream inputStream, string encoding = "UTF-8")
            => ProcessFlow_Helper_DG.channel_Exception_Log(
                () =>
                {
                    int count = 0;
                    int byteRead = 0;
                    StringBuilder strBuilder = new StringBuilder();
                    {
                        byte[] buffer = new byte[1024];
                        byteRead = inputStream.Read(buffer, count, buffer.Length);
                        count += byteRead;
                        strBuilder.Append(Encoding.GetEncoding(encoding).GetString(buffer));
                    } while (byteRead > 0) ;
                    return strBuilder.ToString();
                }, "String_Helper_DG get_String_By_Stream");

        /// <summary>
        /// get_String_By_Stream
        /// </summary>
        /// <param name="inputStream">inputStream</param>
        /// <param name="count">out count has read</param>
        /// <param name="encoding">encoding="UTF-8"</param>
        /// <returns></returns>
        public static string get_String_By_Stream(System.IO.Stream inputStream, out int count, string encoding = "UTF-8")
        {
            try
            {
                count = 0;
                int byteRead = 0;
                StringBuilder strBuilder = new StringBuilder();
                {
                    byte[] buffer = new byte[1024];
                    byteRead = inputStream.Read(buffer, count, buffer.Length);
                    count += byteRead;
                    strBuilder.Append(Encoding.GetEncoding(encoding).GetString(buffer));
                } while (byteRead > 0) ;
                return strBuilder.ToString();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "String_Helper_DG get_String_By_Stream");
                count = default(int);
                return default(string);
            }
        }
    }
}
