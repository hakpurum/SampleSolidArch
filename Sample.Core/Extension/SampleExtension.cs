using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Extension
{
    public static class SampleExtension
    {

    }

    public static class ObjectExtension
    {
        /// <summary>
        ///     NameValueCollection olarak gelen verinin içerisindeki değerleri Gönderilen objeye set eder
        /// </summary>
        /// <typeparam name="T">Nesne Örn : User</typeparam>
        /// <param name="FormDataResponse">NameValueCollection objesi</param>
        /// <returns></returns>
        public static T FormParse<T>(this object FormDataResponse) where T : new()
        {
            var FormDataResponseConv = FormDataResponse as NameValueCollection;
            var tObjects = new T();
            foreach (string key in FormDataResponseConv)
            {
                var value = FormDataResponseConv[key];
                value = (value == "true,false") ? "true" : value;

                var pInfo = tObjects.GetType().GetProperty(key);

                object convertedValue = null;

                if (pInfo != null && !string.IsNullOrEmpty(value))
                {
                    var targetType = IsNullableType(pInfo.PropertyType)
                        ? Nullable.GetUnderlyingType(pInfo.PropertyType)
                        : pInfo.PropertyType;
                    convertedValue = Convert.ChangeType(value, targetType);

                    tObjects.GetType().GetProperty(key).SetValue(tObjects, convertedValue, null);
                }
            }
            return tObjects;
        }

        public static T1 FormParse<T1>(this object obj, T1 otherObject)
            where T1 : class
        {
            var FormDataResponseConv = obj as NameValueCollection;
            foreach (string key in FormDataResponseConv)
            {
                var value = FormDataResponseConv[key];
                value = (value == "true,false") ? "true" : value;
                var pInfo = otherObject.GetType().GetProperty(key);

                object convertedValue = null;

                if (pInfo != null && !string.IsNullOrEmpty(value))
                {
                    var targetType = IsNullableType(pInfo.PropertyType)
                        ? Nullable.GetUnderlyingType(pInfo.PropertyType)
                        : pInfo.PropertyType;
                    convertedValue = Convert.ChangeType(value, targetType);

                    otherObject.GetType().GetProperty(key).SetValue(otherObject, convertedValue, null);
                }
            }

            return otherObject;
        }

        //Nullable property çözümü
        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }

        /// <summary>
        ///     Gönderilen string değerini split eder ve gönderilen Nesneye değerleri set eder
        /// </summary>
        /// <typeparam name="T">Nesne Örn : User</typeparam>
        /// <param name="strValue">String değeri Örn : "hasan,ahmet,osman"</param>
        /// <param name="PropertyName">Değerlerin Set edileceği Property adı</param>
        /// <param name="Seperator">Split edilecek ayrıştırıcı Örn : ","</param>
        /// <returns></returns>
        public static List<T> SplitToList<T>(this object strValue, string PropertyName, char Seperator = ',')
            where T : new()
        {
            var arry = strValue.ToString().Split(Seperator);
            var tObjects = new List<T>();

            for (var i = 0; i < arry.Count(); i++)
            {
                var Object = new T();
                var pInfo = tObjects.GetType().GetProperty(PropertyName);
                if (pInfo != null)
                {
                    pInfo.SetValue(Object, arry[i], null);
                    tObjects.Add(Object);
                }
            }

            return tObjects;
        }

        /// <summary>
        ///     Gönderdiğiniz Objenin Property ve değerlerini string olarak birleştirerek size geri döner
        /// </summary>
        /// <param name="FormDataResponse">Object</param>
        /// <returns></returns>
        public static string ObjectToString(this object FormDataResponse)
        {
            var builder = new StringBuilder();

            foreach (var key in FormDataResponse.GetType().GetProperties())
            {
                builder.Append(key.Name + " => " + key.GetValue(FormDataResponse, null) + ",");
            }

            return builder.ToString().TrimEnd(',');
        }

        /// <summary>
        ///     Gönderdiğiniz Dictionary Datasının  Property ve değerlerini string olarak birleştirerek size geri döner
        /// </summary>
        /// <param name="DataResponse">IDictionary<string, object></param>
        /// <returns></returns>
        public static string DictionaryToString(this IDictionary<string, object> DataResponse)
        {
            var builder = string.Join(";", DataResponse.Select(x => x.Key + "=" + x.Value).ToArray());
            return builder.TrimEnd(';');
        }

        /// <summary>
        ///     Nesneyi gönderilen nesneye Cast eder
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="TObject">Cast edilecek sınıf</param>
        /// <returns></returns>
        public static T1 ToCast<T1>(this object TObject) where T1 : new()
        {
            var tObjects = new T1();

            foreach (var key in TObject.GetType().GetProperties())
            {
                if (key.CanWrite)
                {

                    if (tObjects.GetType().GetProperty(key.Name) != null)
                    {
                        tObjects.GetType().GetProperty(key.Name).SetValue(tObjects, key.GetValue(TObject, null), null);
                    }

                }
            }
            return tObjects;
        }

        /// <summary>
        ///     Sınıfın propertysinde [Key] attribute ü olarak tanımlanmış primarykey olaran property' i getirir
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static PropertyInfo GetPrimaryKeyName<T>(this T obj) where T : class
        {
            return
                typeof(T).GetProperties()
                    .FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Length > 0);
        }

        public static void SetDefaultDateTime<T>(this T obj, string propertyName) where T : class
        {
            var getProperty = typeof(T).GetProperties().FirstOrDefault(p => p.Name == propertyName);
            if (getProperty != null)
            {
                object convertedValue = null;

                var targetType = IsNullableType(getProperty.PropertyType)
                    ? Nullable.GetUnderlyingType(getProperty.PropertyType)
                    : getProperty.PropertyType;
                convertedValue = Convert.ChangeType(DateTime.Now, targetType);

                getProperty.SetValue(obj, convertedValue, null);
            }
        }
    }

    public static class ConvertExtension
    {
        public static int ToInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static double ToDouble(this object obj)
        {
            return Convert.ToDouble(obj);
        }

        public static decimal ToDecimal(this object obj)
        {
            return Convert.ToDecimal(obj);
        }

        public static bool ToBoolean(this object obj)
        {
            return Convert.ToBoolean(obj);
        }

        public static long ToLong(this object obj)
        {
            return Convert.ToInt64(obj);
        }
    }

}
