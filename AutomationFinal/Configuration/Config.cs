using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AutomationFinal.Configuration
{
    public class Config
    {
        public static string GetEnviroment()
        {
            return GetConfigValue("Enviroment");
        }
        public static string GetBrowser()
        {
            return GetConfigValue("Browser");
        }
        public static string GetUrl()
        {
            string key = "SST-classesURL." + GetEnviroment();
            return GetConfigValue(key);
        }
        public static string GetConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

    }
}
