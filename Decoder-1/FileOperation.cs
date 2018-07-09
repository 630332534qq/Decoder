using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decoder
{
    public static class FileOperation<T>
    {
        public static bool WriteFile(List<T> list)
        {
            bool success = true; 
            string filename = typeof(T).ToString().Substring(typeof(T).ToString().IndexOf(".") + 1) + ".json";
            if (!File.Exists(filename))
            {
                File.Create(filename);                
            }
            using (StreamWriter sw = new StreamWriter(filename,false))
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
            string filename = typeof(T).ToString().Substring(typeof(T).ToString().IndexOf(".") + 1) + ".json";
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
}
