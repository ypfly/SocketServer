using System.Data;
using System.IO;
using System.Runtime.Serialization.Json;
//using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    public class JsonHelper
    {

        /// <summary>
        /// 普通加密JSON
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(object obj)
        {
            if (obj == null) return "";
            return JsonConvert.SerializeObject(obj, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
        }
        /// <summary>
        /// 时间高精度的json数据
        /// </summary>
        /// <param name="ojb"></param>
        /// <returns></returns>
        public static string ToTimePrecisionJson(object obj)
        {
            return (null == obj) ? "" : JsonConvert.SerializeObject(obj, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff" });
        }
        /// <summary>
        /// 时间高精度普通解密JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static T FromJsonTimePrecision<T>(string jsonStr)
        {
            if (string.IsNullOrWhiteSpace(jsonStr)) return default(T);
            else
            {
                var jSetting = new JsonSerializerSettings();
                jSetting.NullValueHandling = NullValueHandling.Ignore;
                jSetting.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff" });
                return JsonConvert.DeserializeObject<T>(jsonStr, jSetting);
            }
        }
        /// <summary>
        /// 普通解密JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static T FromJson<T>(string jsonStr)
        {
            if (string.IsNullOrWhiteSpace(jsonStr)) return default(T);
            else
            {
                var jSetting = new JsonSerializerSettings();
                jSetting.NullValueHandling = NullValueHandling.Ignore;
                jSetting.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                return JsonConvert.DeserializeObject<T>(jsonStr, jSetting);
            }
        }

        /// <summary> 
        /// Json序列化 
        /// </summary> 
        public static string JsonSerializer<T>(T obj)
        {
            string jsonString = string.Empty;
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, obj);
                    jsonString = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch
            {
                jsonString = string.Empty;
            }
            return jsonString;
        }

        /// <summary> 
        /// Json反序列化
        /// </summary> 
        public static T JsonDeserialize<T>(string jsonString)
        {
            T obj = Activator.CreateInstance<T>();
            try
            {
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(obj.GetType());//typeof(T)
                    T jsonObject = (T)ser.ReadObject(ms);
                    ms.Close();

                    return jsonObject;
                }
            }
            catch(Exception ex)
            {
             //   Log4NetHelper.Error(ex.Message);
                return default(T);
            }
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

    //    // 将 DataTable 序列化成 json 字符串
    //    public static string DataTableToJson(DataTable dt)
    //    {
    //        if (dt == null || dt.Rows.Count == 0)
    //        {
    //            return "\"\"";
    //        }
    //        JavaScriptSerializer myJson = new JavaScriptSerializer();

    //        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

    //        foreach (DataRow dr in dt.Rows)
    //        {
    //            Dictionary<string, object> result = new Dictionary<string, object>();
    //            foreach (DataColumn dc in dt.Columns)
    //            {
    //                result.Add(dc.ColumnName, dr[dc].ToString());
    //            }
    //            list.Add(result);
    //        }
    //        return myJson.Serialize(list);
    //    }

    //    // 将对象序列化成 json 字符串
    //    public static string ObjectToJson(object obj)
    //    {
    //        if (obj == null)
    //        {
    //            return string.Empty;
    //        }
    //        JavaScriptSerializer myJson = new JavaScriptSerializer();

    //        return myJson.Serialize(obj);
    //    }
    //    /// <summary>把字符串转换成对象
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="jsonValue"></param>
    //    /// <returns></returns>
    //    public static T GetObjFromJson<T>(string jsonValue, T obj)
    //    {
    //        try
    //        {
    //            return JsonConvert.DeserializeAnonymousType(jsonValue, obj);
    //        }
    //        catch (Exception ex)
    //        {
    //            return default(T);
    //        }
    //    }
    //    // 将 json 字符串反序列化成对象
    //    public static object JsonToObject(string json)
    //    {
    //        if (string.IsNullOrEmpty(json))
    //        {
    //            return null;
    //        }
    //        JavaScriptSerializer myJson = new JavaScriptSerializer();

    //        return myJson.DeserializeObject(json);
    //    }

    //    // 将 json 字符串反序列化成对象
    //    public static T JsonToObject<T>(string json)
    //    {
    //        if (string.IsNullOrEmpty(json))
    //        {
    //            return default(T);
    //        }
    //        JavaScriptSerializer myJson = new JavaScriptSerializer();

    //        return myJson.Deserialize<T>(json);
    //    }
    }
}
