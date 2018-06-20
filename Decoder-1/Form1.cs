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
                NetworkCredential networkCredential = new NetworkCredential("root", "pass");
                WebRequest request = WebRequest.Create(ParamList);
                request.Credentials = networkCredential;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);
                Char[] readBuff = new Char[256000];
                int count = streamRead.Read(readBuff, 0, 256000);
                rtxReturn.Text += String.Format("\nAXIS PARAMETERS LIST:\n");
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
           // string codeJson = "{\"params\":" + JsonConvert.SerializeObject(new buildJson()) + ",\"apiVersion\": \"1.0\",\"context\": \"Camera\",\"method\": \"setViewConfiguration\"}";



            rtxReturn.Text = "";
            NetworkCredential networkCredential = new NetworkCredential("root", "passpass");
            string strURL = "http://192.168.0.220/axis-cgi/decoder.cgi";
            //string jsonParas = "[{\"inputType\": \"grid\", \"seqtime\": \"10\",\"view\": \"2x2\",\"gridcol\": \"2\",\"gridrow\": \"2\",\"gridrowmax\": \"4\",\"gridcolmax\": \"4\",\"inputReso\": \"720x480x60\"]";
            string jsonDeocder = "{\"params\": {\"panes\": [{\"paneId\": 0,\"left\": 1.0,\"right\": 1.0,\"top\": 0.0,\"bottom\": 1.0}],\"streams\": [{\"streamId\": 0,\"url\": \"rtsp://192.168.0.88/axis-media/media.amp?camera=1&videocodec=h264&resolution=640x360&fps=5\",\"videoCodec\": \"H264\",\"audioCodec\": null,\"username\": \"root\",\"password\": \"pass\"}],\"views\": [{\"viewId\": 0,\"duration\": 0,\"segments\": [{\"stream\": 0,\"pane\": 0}]}]},\"apiVersion\": \"1.0\",\"context\": \"Camera\",\"method\": \"setViewConfiguration\"}";
            Camera selected = sender as Camera;
            if (selected != null)
            {
                jsonDeocder = "{\"params\": {\"panes\": [{\"paneId\": 1,\"left\": 1.0,\"right\": 0.0,\"top\": 0.0,\"bottom\": 1.0}],\"streams\": [{\"streamId\": 0,\"url\": \"rtsp://" + selected.ipaddr + "/axis-media/media.amp?camera=1&videocodec=h264&resolution=640x360&fps=5\",\"videoCodec\": \"H264\",\"audioCodec\": null,\"username\": \"root\",\"password\": \"pass\"}],\"views\": [{\"viewId\": 0,\"duration\": 0,\"segments\": [{\"stream\": 0,\"pane\": 1}]}]},\"apiVersion\": \"1.0\",\"context\": \"Camera\",\"method\": \"setViewConfiguration\"}";
            }

           // jsonDeocder = codeJson;
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strURL);
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
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            rtxReturn.Text = result.ToString();
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
            rtxReturn.Text = "";
            NetworkCredential networkCredential = new NetworkCredential("root", "passpass");
            string strURL = "http://192.168.0.220/monitor";
            //string jsonParas = "[{\"inputType\": \"grid\", \"seqtime\": \"10\",\"view\": \"2x2\",\"gridcol\": \"2\",\"gridrow\": \"2\",\"gridrowmax\": \"4\",\"gridcolmax\": \"4\",\"inputReso\": \"720x480x60\"]";
            string jsonDeocder = "{\"_xsrf\":\"2%7Cc77f3120%7Cebe74338881e87a0e4e4e7eee59a122a%7C28900\",\"inputType\": \"grid\",\"seqtime\": 10,\"view\": \"1x1\",\"gridcol\": 1,\"gridrow\": 1,\"gridrowmax\": 4,\"gridcolmax\": 4,\"inputReso\": \"1920x1080x60\"}";
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strURL);
            req.CookieContainer = new CookieContainer();
            CookieContainer cookie = req.CookieContainer;
            req.AllowAutoRedirect = false;
            // req.CookieContainer.Add(new Cookie("_xsrf", "2|ba7eaca6|96e6debef51f1a2699e57a68989b8fac|28900"));
            // req.CookieContainer.Add(new Cookie("user", "2|1:0|5:28904|4:user|8:InJvb3Qi|149aa3d80189a92a64371e64e856dd50487a2574395f763438e75f62e0253f4d"));
            req.Referer = strURL;
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            req.Headers["Accept-Language"] = "en-US,en;q=0.9,zh-CN;q=0.8,zh;q=0.7";
            req.Headers["Accept-Encoding"] = "gzip, deflate";
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
            req.Method = "POST";
            req.KeepAlive = true;
            req.Credentials = networkCredential;
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] data = Encoding.UTF8.GetBytes(jsonDeocder);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                if (resp.StatusCode == HttpStatusCode.Redirect || resp.StatusCode == HttpStatusCode.MovedPermanently)
                {//发生重定向就重新获取  
                    btnChangeView_Click(new object(), new EventArgs());
                }
                Stream stream = resp.GetResponseStream();
                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            rtxReturn.Text = result.ToString();
        }

        private void btn_Page_ChangeView_Click(object sender, EventArgs e)
        {
            WebBrowser wb = new WebBrowser();
            Uri url = new Uri("http://192.168.0.220/login");
            wb.Navigate(url);
            //wb.Refresh();
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
        }
        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;
            HtmlElement tbUserid = wb.Document.GetElementById("user");
            HtmlElement tbPasswd = wb.Document.GetElementById("password");
            HtmlElement btnSubmit = wb.Document.GetElementById("submit");
            tbUserid.SetAttribute("value", "root");
            tbPasswd.SetAttribute("value", "passpass");
            btnSubmit.InvokeMember("click");
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

    public class streams
    {
        public Guid streamId = Guid.NewGuid();
        public Uri url = null;
        public string videoCodec = null;
        public string audioCodec = null;
        public string username = "root";
        public string password = "pass";

        public streams(Camera c)
        {
            url = new Uri(c.LowRTSP());
            videoCodec = "H264";
            username = c.username;
            password = c.password;
        }
    }

    public class panes
    {
        public Guid paneId = Guid.NewGuid();
        public float left = 0.0f;
        public float right = 1.0f;
        public float top = 0.0f;
        public float bottom = 1.0f;

        public panes(float l, float r, float t, float b)
        {
            left = l;
            right = r;
            top = t;
            bottom = b;
        }
    }

    public class segments
    {
        public Guid stream;
        public Guid pane;

        public segments(panes p, streams s)
        {
            stream = s.streamId;
            pane = p.paneId;
        }
    }

    public class views
    {
        public Guid viewId = Guid.NewGuid();
        public int duration = 0;
        public List<segments> segments = new List<segments> ();

        public views(int dur, segments s)
        {
            duration = dur;
            segments.Add(s);
        }
    }

    public class buildJson
    {
        public List<panes> panes = new List<panes>();
        public List<streams> streams = new List<streams>();
        public List<views> views = new List<views>();

        public buildJson()
        {
            panes.Add(new panes(0, 1.0f, 0, 1.0f));
            streams.Add(new streams(Camera.c.First()));
            views.Add(new views(10, new segments(panes.First(), streams.First())));
        }

    }
}
