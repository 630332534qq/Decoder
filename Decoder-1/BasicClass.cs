using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using log4net;
using System.Reflection;

namespace Decoder
{
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


    }

    public class segments
    {
        public int stream;
        public int pane;

        public segments(panes p, Camera c)
        {
            stream = BasicOperation.GetStreamID(c.ipaddr);
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
        public string ipaddr;
        public string name;
        public string username;
        public string password;
        public string serialNo;
        public string configuration;
    }

    public enum Resolution
    {
        LOW = 0,
        MIDDLE = 1,
        HIGH = 2
    }

    public enum Duration
    {
        Multiview = 0,
        SeqQuick = 10,
        SeqMiddle = 30,
        SeqSlow = 60
    }

    public enum VideoCodec
    {
        H264 = 0,
        MJPEG = 1,
        MPEG = 2,
        MP4 = 3
    }

    public static class BasicOperation
    {
        public static int GetStreamID(string ip)
        {
            string[] ips = ip.Split('.');
            string s = ips[0].ToString() + ips[1].ToString() + ips[2].ToString() + ips[3].ToString();
            return s.Length < 9 ? int.Parse(s) : int.Parse(s.Substring(s.Length - 9, 9));
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


    public class Camera
    {
       
        static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Camera's name
        /// </summary> 
        [JsonProperty]
        public string name;
        /// <summary>
        /// Camera's ipAddress
        /// </summary> 
        [JsonProperty]
        public string ipaddr;
        [JsonProperty]
        public int streamId;
        [JsonProperty]
        public string url;
        [JsonProperty]
        public string videoCodec = VideoCodec.H264.ToString();
        public string audioCodec = "";
        [JsonProperty]
        public string username = "root";
        [JsonProperty]
        public string password = "pass";
       
        public string fps = "15";

        public Camera()
        { }
        public Camera(string cname, string cipaddr, string cusername = "root", string cpassword = "pass", string crtsp = "", string cfps = "15", Resolution cres = Resolution.LOW)
        {
            name = cname;
            ipaddr = cipaddr;
            username = cusername;
            password = cpassword;
            if (crtsp == "") url = GetRTSPUrlFromCameraParameter(cres);
            else url = crtsp; 
            streamId = BasicOperation.GetStreamID(ipaddr);
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static List<Camera> cList = new List<Camera>
            {
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6"),
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6"),
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6"),
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6"),
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6"),
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6"),
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6"),
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6"),
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6"),
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6"),
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6"),
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6")
            };
        public string GetRTSPUrlFromCameraParameter(Resolution res)
        {
            string url = "rtsp://" + ipaddr + "/axis-media/media.amp?resolution=";
            switch (res)
            {
                case Resolution.HIGH:
                    url = url + "1920x1080";
                    break;
                case Resolution.MIDDLE:
                    url = url + "1024x768";
                    break;
                case Resolution.LOW:
                    url = url + "704x576";
                    break;
                default:
                    url = url + "704x576";
                    break;
            }
            url = url + "&fps=" + fps;
            return url;
            //  return "{\"streamId\":" + BasicOperation.GetStreamID(this.ipaddr) + ",\"url\":\"" + url + "\",\"videoCodec\":\"" + videoCodec + "\",\"audioCodec\":" + "\"\"" + ",\"username\":\"" + username + "\",\"password\":\"" + password + "\"}";
        }
    }


}

