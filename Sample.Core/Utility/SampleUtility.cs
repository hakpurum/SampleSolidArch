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
            if (!string.IsNullOrEmpty(key))
            {
                var value = ConfigurationManager.AppSettings[key];
                try
                {
                    if (value != null)
                    {
                        var theType = typeof(T);
                        if (theType.IsEnum)
                            return (T)Enum.Parse(theType, value, true);

                        return (T)Convert.ChangeType(value, theType);
                    }

                    return default(T);
                }
                catch
                {
                }
            }

            return defaultValue;
        }
    }
}
