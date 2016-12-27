using System;
using System.IO;

namespace QX_Frame.Helper_DG_Framework
{
    /// <summary>
    /// 20161030 14:27:23 qixiao
    /// </summary>
    public abstract class Log_Helper_DG
    {
        public static void Log(string logText, string logTitle = "QX_Frame General", Boolean isAppend = true)
        {
            try
            {
                string LogLocation_DG = @"Log_QX_Frame/Log_QX_Frame_General/";
                try
                {
                    LogLocation_DG = Config_Helper_DG.AppSetting_Get("Log_Location_General_DG");
                }
                catch (Exception)
                {
                    LogLocation_DG = @"Log_QX_Frame/Log_QX_Frame_General/";
                }
                if (!Directory.Exists(LogLocation_DG))
                {
                    Directory.CreateDirectory(LogLocation_DG);
                }
                using (StreamWriter log = new StreamWriter($"{LogLocation_DG}Log_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}.Log", isAppend))
                {
                    log.WriteLine();
                    log.WriteLine($"{DateTime_Helper_DG.Get_DateTime_Now_24HourType()}   ---- {logTitle} Log !------");
                    log.WriteLine(logText);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void Log_Error(string logText, string logTitle = "QX_Frame Error", Boolean isAppend = true)
        {
            try
            {
                string LogLocation_DG = @"Log_QX_Frame/Log_QX_Frame_Error/";
                try
                {
                    LogLocation_DG = Config_Helper_DG.AppSetting_Get("Log_Location_Error_DG");
                }
                catch (Exception)
                {
                    LogLocation_DG = @"Log_QX_Frame/Log_QX_Frame_Error/";
                }
                if (!Directory.Exists(LogLocation_DG))
                {
                    Directory.CreateDirectory(LogLocation_DG);
                }
                using (StreamWriter log = new StreamWriter($"{LogLocation_DG}Log_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}.Log", isAppend))
                {
                    log.WriteLine();
                    log.WriteLine($"{DateTime_Helper_DG.Get_DateTime_Now_24HourType()}   ---- {logTitle} Log !------");
                    log.WriteLine(logText);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void Log_Use(string logText, string logTitle = "QX_Frame USE", Boolean isAppend = true)
        {
            try
            {
                string LogLocation_DG = @"Log_QX_Frame/Log_QX_Frame_Use/";
                try
                {
                    LogLocation_DG = Config_Helper_DG.AppSetting_Get("Log_Location_Use_DG");
                }
                catch (Exception)
                {
                    LogLocation_DG = @"Log_QX_Frame/Log_QX_Frame_Use/";
                }
                if (!Directory.Exists(LogLocation_DG))
                {
                    Directory.CreateDirectory(LogLocation_DG);
                }
                using (StreamWriter log = new StreamWriter($"{LogLocation_DG}Log_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}.Log", isAppend))
                {
                    log.WriteLine();
                    log.WriteLine($"{DateTime_Helper_DG.Get_DateTime_Now_24HourType()}   ---- {logTitle} Log !------");
                    log.WriteLine(logText);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
