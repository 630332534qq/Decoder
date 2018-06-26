using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using System.Xml;
using System.Collections;

namespace Decoder_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetParas_Click(object sender, EventArgs e)
        {
            rtxReturn.Text = "";
            string ParamList = "http://192.168.0.220/axis-cgi/admin/param.cgi?action=list";
            try
            {
                NetworkCredential networkCredential = new NetworkCredential("root", "passpass");
                WebRequest request = WebRequest.Create(ParamList);
                request.Credentials = networkCredential;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);
                Char[] readBuff = new Char[256000];
                int count = streamRead.Read(readBuff, 0, 256000);
                rtxReturn.Text += String.Format("\n AXIS PARAMETERS LIST: \n");
                while (count > 0)
                {
                    String outputData = new String(readBuff, 0, count);
                    rtxReturn.Text += String.Format("{0}", outputData);
                    count = streamRead.Read(readBuff, 0, 256000);
                }
                streamRead.Close();
                streamResponse.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "\nError Message");
            }
        }

        private void btn_ChangeCamera_Click(object sender, EventArgs e)
        {
            rtxReturn.Text = "";
            Camera c = new Camera("Test", "192.168.77.208");
 
            rtxReturn.Text = c.GetJson();
        }

        private string DecodeVideo(Decoder d, List<Camera> clist)
        {
            string result = "";
            NetworkCredential networkCredential = new NetworkCredential(d.username, d.password);
            string strDecoderURL = "http://" + d.ipaddr + "/axis-cgi/decoder.cgi";
            string jsonDeocder = "{\"params\": {\"panes\": [{\"paneId\": 0,\"left\": 1.0,\"right\": 1.0,\"top\": 0.0,\"bottom\": 1.0}],\"streams\": [{\"streamId\": 0,\"url\": \"rtsp://192.168.0.88/axis-media/media.amp?camera=1&videocodec=h264&resolution=640x360&fps=5\",\"videoCodec\": \"H264\",\"audioCodec\": null,\"username\": \"root\",\"password\": \"pass\"}],\"views\": [{\"viewId\": 0,\"duration\": 0,\"segments\": [{\"stream\": 0,\"pane\": 0}]}]},\"apiVersion\": \"1.0\",\"context\": \"Camera\",\"method\": \"setViewConfiguration\"}";
            Camera selected = clist.First();
            if (selected != null)
            {
                jsonDeocder = "{\"params\": {\"panes\": [{\"paneId\": 1,\"left\": 0.5,\"right\": 1.0,\"top\": 0.5,\"bottom\": 1.0}],\"streams\": [{\"streamId\": 0,\"url\": \"rtsp://" + selected.ipaddr + "/axis-media/media.amp?camera=1&videocodec=h264&resolution=1920x1080&fps=15\",\"videoCodec\": \"H264\",\"audioCodec\": null,\"username\": \"root\",\"password\": \"pass\"}],\"views\": [{\"viewId\": 0,\"duration\": 0,\"segments\": [{\"stream\": 0,\"pane\": 1}]}]},\"apiVersion\": \"1.0\",\"context\": \"Camera\",\"method\": \"setViewConfiguration\"}";
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strDecoderURL);
            req.Method = "POST";
            req.Credentials = networkCredential;
            req.ContentType = "application/json";
            byte[] data = Encoding.UTF8.GetBytes(jsonDeocder);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        private void cbxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            Camera finder = Camera.c.Find(x => x.name == cbxCameras.SelectedItem.ToString());
            if (finder == null)
            {
                MessageBox.Show("没有发现此摄像机");
                return;
            }
            btn_ChangeCamera_Click(finder, new EventArgs());
        }

        private void btnChangeView_Click(object sender, EventArgs e)
        {
            List<panes> list = BasicOperation.GeneratePanels(4);
            rtxReturn.Text = JsonConvert.SerializeObject(list);
            //StringBuilder sb = new StringBuilder();
            //foreach (panes px in list)
            //{
            //    sb.Append(px.paneId + "--LEFT：" + px.left + " --TOP:" + px.top + "    --RIGHT:" + px.right + " --:BOTTOM:" + px.bottom);
            //    sb.Append("\n");
            //}
            //rtxReturn.Text = sb.ToString();
        }
    }
}

