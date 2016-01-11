using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace F8YL.BLL
{
    public static class JsonHelper
    {
        /// <summary>
        /// 将对象序列化为JSON格式
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>json字符串</returns>
        public static string SerializeObject(object o)
        {
            string json = JsonConvert.SerializeObject(o);
            return json;
        }

        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串(eg.{"ID":"112","Name":"石子儿"})</param>
        /// <returns>对象实体</returns>
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            T t = o as T;
            return t;
        }

        /// <summary>
        /// 解析JSON数组生成对象实体集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json数组字符串(eg.[{"ID":"112","Name":"石子儿"}])</param>
        /// <returns>对象实体集合</returns>
        public static List<T> DeserializeJsonToList<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            List<T> list = o as List<T>;
            return list;
        }

        /// <summary>
        /// 反序列化JSON到给定的匿名对象.
        /// </summary>
        /// <typeparam name="T">匿名对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <param name="anonymousTypeObject">匿名对象</param>
        /// <returns>匿名对象</returns>
        public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject)
        {
            T t = JsonConvert.DeserializeAnonymousType(json, anonymousTypeObject);
            return t;
        }

        /// <summary>     
        /// 对象集合转换Json     
        /// </summary>     
        /// <param name="obj">泛型</param>     
        /// <returns>Json字符串</returns>     
        //public static string ToJson(IEnumerable array)  
        public static string ToJson(List<object> obj)
        {
            string jsonString = "[";
            foreach (object item in obj)
            {
                jsonString += ToJson(item) + ",";
            }
            return jsonString.Substring(0, jsonString.Length - 1) + "]";
        }

        #region //对象转换成json
        public static string ToJson(object jsonObject)
        {
            string jsonString = "{";
            PropertyInfo[] propertyInfo = jsonObject.GetType().GetProperties();
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                //得到Value值
                object objectValue = propertyInfo[i].GetGetMethod().Invoke(jsonObject, null);

                string value = string.Empty;

                //判断Value类型
                if (objectValue is DateTime || objectValue is Guid || objectValue is TimeSpan)
                {
                    value = objectValue.ToString();
                }
                else if (objectValue is string)
                {
                    value = objectValue.ToString();
                }
                else
                {
                    value = objectValue.ToString();
                }
                jsonString += "\"" + propertyInfo[i].Name + "\":" + "\"" + value + "\"" + ",";
            }
            return jsonString.Substring(0, jsonString.Length - 1) + "}";
        }

        #endregion

    }
}
