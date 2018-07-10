using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using log4net; 

namespace Decoder
{
    public class DecoderOperation
    {
        static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static bool GetSerialNoFromDecoder(Decoder d)
        {
            bool flag = true;
            try
            {
                string paramList = "http://" + d.ipaddr + "/axis-cgi/admin/param.cgi?action=list&group=root.Properties.System.SerialNumber";
                NetworkCredential networkCredential = new NetworkCredential(d.username, d.password);
                WebRequest request = WebRequest.Create(paramList);
                request.Credentials = networkCredential;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse); 
               string allSerial=  streamRead.ReadLine();
                d.serialNo = allSerial.Substring(allSerial.IndexOf("=") + 1);
                streamRead.Close();
                streamResponse.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "\nError Message");
                log.Error("读取解码器序列号出错:"+ex.ToString());
                flag = false;
            }
            return flag;
        }

        public static void GetSerialNos()
        {
            List<Decoder> dlist = FileOperation<Decoder>.ReadFile();
            List<string> slist = new List<string>();
            foreach (Decoder d in dlist)
            {
                GetSerialNoFromDecoder(d);
                slist.Add(d.serialNo);
            }
            FileOperation<Decoder>.WriteFile(dlist);
            FileOperation<string>.WriteFile(slist,"Register.reg");
        } 
    }
}
