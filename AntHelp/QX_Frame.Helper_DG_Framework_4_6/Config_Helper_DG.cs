using System;
using System.Configuration;

namespace QX_Frame.Helper_DG_Framework_4_6
{
    /*2016-11-12 20:40:50 author:qixiao*/
    public abstract class Config_Helper_DG
    {
        public static string AppSetting_Get(string appSettingKey)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Ignore(
                () =>
                {
                    Configuration configuration = null;
                    if (System.Web.HttpContext.Current != null)
                    {
                        configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                    }
                    else
                    {
                        configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    }
                    return configuration.AppSettings.Settings[appSettingKey].Value.Trim();
                });
        }

        public static Boolean AppSetting_Add(string appSettingKey, string appSettingValue)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
                () =>
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Add(appSettingKey, appSettingValue);
                    config.Save(ConfigurationSaveMode.Modified);            // must save
                    ConfigurationManager.RefreshSection("appSettings");     //must refresh
                    return true;
                }, "AppSetting_Add");
        }

        public static Boolean AppSetting_Update(string appSettingKey, string appSettingValue)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
                () =>
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings[appSettingKey].Value = appSettingValue; //set value
                    config.Save(ConfigurationSaveMode.Modified);            // must save
                    ConfigurationManager.RefreshSection("appSettings");     //must refresh
                    return true;
                }, "AppSetting_Update");
        }

        public static Boolean AppSetting_Delete(string appSettingKey)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
                () =>
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Remove(appSettingKey);
                    config.Save(ConfigurationSaveMode.Modified);            // must save
                    ConfigurationManager.RefreshSection("appSettings");     //must refresh
                    return true;
                }, "AppSetting_Delete");
        }
    }
}
