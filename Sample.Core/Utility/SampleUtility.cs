using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Utility
{
    public class SampleUtility
    {
        public static T GetAppSetting<T>(string key, T defaultValue)
        {
            if (string.IsNullOrEmpty(key)) return defaultValue;
            var value = ConfigurationManager.AppSettings[key];
            try
            {
                if (value == null) return default(T);
                var theType = typeof(T);
                if (theType.IsEnum)
                    return (T)Enum.Parse(theType, value, true);

                return (T)Convert.ChangeType(value, theType);
            }
            catch (Exception)
            {
                // ignored
            }

            return defaultValue;
        }
    }
}
