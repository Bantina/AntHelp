using QX_Frame.Helper_DG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QX_Frame.WebAPI.config
{
    /**
     * author:qixiao
     * time:2017-4-5 17:50:22
     * */
    public class ControllerConfigs
    {
        //the webapi app domain
        public static readonly string AppDomain = Config_Helper_DG.AppSetting_Get("AppDomain");
        //the web app domain
        public static readonly string WebAppDomain = Config_Helper_DG.AppSetting_Get("WebAppDomain");
    }
}