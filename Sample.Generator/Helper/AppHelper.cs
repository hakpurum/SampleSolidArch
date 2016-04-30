using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Generator.Helper
{
    public static class AppHelper
    {
        public static string GetApp(string KeyName)
        {
            return ConfigurationSettings.AppSettings.Get(KeyName);
        }

        public static string[] GetTables()
        {
            return GetApp("DbTables").Split(',');
        }
    }
}
