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
            Decoder d = new Decoder();
            d.ipaddr = "192.168.0.220";
            d.username = "root";
            d.password = "passpass";
            rtxReturn.Text = DecodeVideo(d, new List<Camera>());
        }

        private static string DecodeVideo(Decoder d, List<Camera> clist)
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
            List<panes> list = panes.GeneratePanels(1);
            StringBuilder sb = new StringBuilder();
            foreach (panes px in list)
            {
                sb.Append(px.paneId + "--LEFT：" + px.left + " --TOP:" + px.top + "    --RIGHT:" + px.right + " --:BOTTOM:" + px.bottom);
                sb.Append("\n");
            }
            rtxReturn.Text = sb.ToString();
        }
    }

    public class Camera
    {
        public string name;
        public string ipaddr;
        public string username = "root";
        public string password = "pass";
        public string videoCodec = "H264";
        public Camera(string name, string ipaddr)
        {
            this.name = name;
            this.ipaddr = ipaddr;
        }
        public string LowRTSP()
        {
            return "rtsp://" + ipaddr + "/axis-media/media.amp?camera=1&videocodec=h264&resolution=640x360&fps=15";
        }

        public string MediaRTSP()
        {
            return "rtsp://" + ipaddr + "/axis-media/media.amp?camera=1&videocodec=h264&resolution=1280x720&fps=15";
        }

        public string HighRTSP()
        {
            return "rtsp://" + ipaddr + "/axis-media/media.amp?camera=1&videocodec=h264&resolution=1920x1080&fps=25";
        }
        public static List<Camera> c = new List<Camera>
            {
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6")
            };
    }

    public static class GetID
    {
        private static int globalID = 0;

        public static int ID
        {
            get
            {
                return globalID++;
            }
        }
    }

    public class streams
    {
        public int streamId;
        public Uri url = null;
        public string videoCodec = null;
        public string audioCodec = null;
        public string username = "root";
        public string password = "pass";

        public streams(Camera c)
        {
            streamId = GetID.ID;
            url = new Uri(c.LowRTSP());
            videoCodec = "H264";
            username = c.username;
            password = c.password;
        }
    }

    public class panes
    {
        public int paneId;
        public float left = 0.0f;
        public float right = 1.0f;
        public float top = 0.0f;
        public float bottom = 1.0f;

        public panes(int id, float l, float r, float t, float b)
        {
            paneId = id;
            left = l;
            right = r;
            top = t;
            bottom = b;
        }

        public static List<panes> GeneratePanels(int N)
        {
            List<panes> list = new List<panes>();
            int ID = 1;
            //步进为1/N
            float K = (float)Math.Round((float)1 / N, 3);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    panes padd = new panes(ID, (float)Math.Round((float)j / N, 3), (float)Math.Round((float)j / N, 3) + K, (float)Math.Round((float)i / N, 3), (float)Math.Round((float)i / N, 3) + K);
                    ++ID;
                    list.Add(padd);
                }
            }
            return list;
        }
    }

    public class segments
    {
        public int stream;
        public int pane;

        public segments(panes p, streams s)
        {
            stream = s.streamId;
            pane = p.paneId;
        }
    }

    public class views
    {
        public int viewId;
        public int duration = 0;
        public List<segments> segments = new List<segments>();

        public views(int dur, segments s)
        {
            viewId = GetID.ID;
            duration = dur;
            segments.Add(s);
        }
    }

    public class Decoder
    {
        public List<Decoder> deocders = new List<Decoder>();
        public string ipaddr;
        public string name;
        public string username;
        public string password;
        public string serialNo;
    }


    public class buildJson
    {
        public List<panes> panes = new List<panes>();
        public List<streams> streams = new List<streams>();
        public List<views> views = new List<views>();

        public buildJson()
        {
            panes.Add(new panes(0, 0, 1.0f, 0, 1.0f));
            streams.Add(new streams(Camera.c.First()));
            views.Add(new views(10, new segments(panes.First(), streams.First())));
        }

    }
}
