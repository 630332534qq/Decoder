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
    public static class FileOperation<T>
    {
        static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static string dataPath = System.IO.Directory.GetCurrentDirectory()+"//data//";
        public static bool WriteFile(List<T> list, string fileNameOption = "")
        {
            bool success = true;
            string filename = dataPath+ typeof(T).ToString().Substring(typeof(T).ToString().IndexOf(".") + 1) + ".json";
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
                    tlist.AddRange(serializer.Deserialize<List<T>>(reader));
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

    public static class LicenseFile
    {
        static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static string licensePath = System.IO.Directory.GetCurrentDirectory() + "//license//";
        public static string ReadLicense()
        {
            using (StreamReader sr = new StreamReader(licensePath + "License.lic2", false))
            {
                return sr.ReadToEnd();
            }              
        }

        public static string ReadRegFile()
        {
            List<string> tlist = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(licensePath+"DecoderInfo.ini"))
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
