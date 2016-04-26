using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Extension
{
    public static class SampleExtension
    {
        public static T FormParse<T>(this object FormDataResponse) where T : new()
        {
            NameValueCollection _collection = FormDataResponse as NameValueCollection;
            T Objects = new T();

            foreach (string key in _collection)
            {
                var value = _collection[key];
                value = (value == "true,false") ? "true" : value;

                PropertyInfo pInfo = Objects.GetType().GetProperty(key);
                object convertedValue = null;
                if (pInfo != null && !string.IsNullOrEmpty(value))
                {
                    var targetType = IsNullableType(pInfo.PropertyType) ? Nullable.GetUnderlyingType(pInfo.PropertyType) : pInfo.PropertyType;

                    convertedValue = Convert.ChangeType(value, targetType);

                    Objects.GetType().GetProperty(key).SetValue(Objects, convertedValue, null);

                }

            }

            return Objects;
        }

        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }

        public static string ObjectToString(this object Data)
        {
            StringBuilder _builder = new StringBuilder();
            foreach (var key in Data.GetType().GetProperties())
            {
                _builder.Append(key.Name + " => " + key.GetValue(Data, null) + ",");
            }

            return _builder.ToString();

        }

    }
}
