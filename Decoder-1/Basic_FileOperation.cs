using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using log4net;

namespace Decoder
{
    /// <summary>
    /// 基本数组读写类，数据存放在程序根目录下data子目录中
    /// </summary>
    /// <typeparam name="T">设备类型，以类名作为文件名</typeparam>
    public static class FileOperation<T>
    {
        static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static string dataPath = Directory.GetCurrentDirectory() + "//data//";
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="list">含有数据的数组</param>
        /// <param name="fileNameOption">可选，是否自定义文件名</param>
        /// <returns></returns>
        public static bool WriteFile(List<T> list, string fileNameOption = "")
        {
            bool success = true;
            string filename = dataPath + typeof(T).ToString().Substring(typeof(T).ToString().IndexOf(".") + 1) + ".json";
            if (fileNameOption != "")
            {
                filename = fileNameOption;
            }
            File.Create(filename).Close();
            using (StreamWriter sw = new StreamWriter(filename, false))
            {
                try
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serializer.Converters.Add(new JavaScriptDateTimeConverter());
                    serializer.NullValueHandling = NullValueHandling.Include;
                    JsonWriter writer = new JsonTextWriter(sw);
                    serializer.Serialize(writer, list);
                    writer.Close();
                    sw.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return success;
        }

        /// <summary>
        /// 数组数据读取类
        /// </summary>
        /// <returns></returns>
        public static List<T> ReadFile()
        {
            List<T> tlist = new List<T>();
            string filename = dataPath + typeof(T).ToString().Substring(typeof(T).ToString().IndexOf(".") + 1) + ".json";
            using (StreamReader sr = new StreamReader(filename))
            {
                try
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serializer.Converters.Add(new JavaScriptDateTimeConverter());
                    serializer.NullValueHandling = NullValueHandling.Include;
                    JsonReader reader = new JsonTextReader(sr);
                    //tlist.AddRange(serializer.Deserialize<List<T>>(reader));
                    tlist.AddRange(JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd()));//优化加载速度
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return tlist;
                }
            }
            return tlist;
        }
    }

    /// <summary>
    /// license处理器类
    /// </summary>
    public static class LicenseFile
    {
        static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static string licensePath = System.IO.Directory.GetCurrentDirectory() + "//license//";
        /// <summary>
        /// 读取license注册文件
        /// </summary>
        /// <returns></returns>
        public static string ReadLicense()
        {
            using (StreamReader sr = new StreamReader(licensePath + "License.lic2", false))
            {
                return sr.ReadToEnd();
            }
        }
        /// <summary>
        /// 读取序列号文件
        /// </summary>
        /// <returns></returns>
        public static string ReadRegFile()
        {
            List<string> tlist = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(licensePath + "DecoderInfo.ini"))
                {
                    try
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Include;
                        JsonReader reader = new JsonTextReader(sr);
                        tlist.AddRange(serializer.Deserialize<List<string>>(reader));
                    }
                    catch (Exception ex)
                    {
                        log.Error("读取注册文件失败" + ex.Message.ToString());
                        return "";
                    }
                }
            }
            catch (Exception e)
            {
                log.Error("读取注册文件失败" + e.Message.ToString());
                return "";
            }
            StringBuilder sb = new StringBuilder();
            foreach (string s in tlist)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }
    }

}
