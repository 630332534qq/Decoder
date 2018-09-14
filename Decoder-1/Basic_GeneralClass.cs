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
            stream = BasicOperation.GetStreamID(c.Ipaddr);
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
            if (ip == null) return 0;
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

        [JsonProperty]
        private Guid cameraID = Guid.NewGuid();
        public Guid CameraID
        {
            get { return cameraID; }
            set { cameraID = value; }
        }
        /// <summary>
        /// Camera's name
        /// </summary> 
        [JsonProperty]
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Camera's ipAddress
        /// </summary> 
        [JsonProperty]
        private string ipaddr;
        [JsonIgnore]
        public string Ipaddr
        {
            get { return ipaddr; }
            set { ipaddr = value; }
        }
        [JsonProperty]
        private int streamId;
        public int StreamId
        {
            get
            {
                if (Ipaddr != null) return StreamId = BasicOperation.GetStreamID(Ipaddr);
                else return 0;
            }
            set { streamId = value; }
        }
        [JsonProperty]
        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        [JsonProperty]
        private string videoCodec = global::Decoder.VideoCodec.H264.ToString();
        public string VideoCodec
        {
            get { return videoCodec; }
            set { videoCodec = value; }
        }
        private string audioCodec = "";
        public string AudioCodec
        {
            get { return audioCodec; }
            set { audioCodec = value; }
        }
        [JsonProperty]
        private string username = "root";
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        [JsonProperty]
        private string password = "pass";
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string fps = "15";

        public Camera(string cname, string cipaddr, string cusername = "root", string cpassword = "pass", string crtsp = "", string cfps = "15", Resolution cres = Resolution.LOW)
        {
            Name = cname;
            Ipaddr = cipaddr;
            Username = cusername;
            Password = cpassword;
            if (crtsp == "") Url = GetRTSPUrlFromCameraParameter(cres);
            else Url = crtsp;
            StreamId = BasicOperation.GetStreamID(Ipaddr);
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static List<Camera> cList = new List<Camera>
            {
                //new Camera("M3045-V","192.168.0.109"),
                //new Camera("P5635-E","192.168.0.8"),
                //new Camera("P1365-MKII","192.168.0.6"),
                //new Camera("M119-3045-V","192.168.0.119"),
                //new Camera("P185635-E","192.168.0.18"),
                //new Camera("P161365-MKII","192.168.0.16"),
                //new Camera("M129-3045-V","192.168.0.129"),
                //new Camera("P285635-E","192.168.0.28"),
                //new Camera("P261365-MKII","192.168.0.26"),
                //new Camera("M1393045-V","192.168.0.139"),
                //new Camera("P385635-E","192.168.0.38"),
                //new Camera("P361365-MKII","192.168.0.36"),
                //new Camera("M1493045-V","192.168.0.149"),
                //new Camera("P485635-E","192.168.0.48"),
                //new Camera("P461365-MKII","192.168.0.46"),
                //new Camera("M1593045-V","192.168.0.159"),
                //new Camera("P585635-E","192.168.0.58"),
                //new Camera("P561365-MKII","192.168.0.56"),
                //new Camera("M1693045-V","192.168.0.169"),
                //new Camera("P685635-E","192.168.0.68"),
                //new Camera("P661365-MKII","192.168.0.66"),
                //new Camera("M1793045-V","192.168.0.179"),
                //new Camera("P785635-E","192.168.0.78"),
                //new Camera("P761365-MKII","192.168.0.76"),
                //new Camera("M1893045-V","192.168.0.189"),
                //new Camera("P885635-E","192.168.0.88"),
                //new Camera("P861365-MKII","192.168.0.86"),
                //new Camera("M1993045-V","192.168.0.199"),
                //new Camera("P985635-E","192.168.0.98"),
                //new Camera("P961365-MKII","192.168.0.96"),
                //new Camera("M2093045-V","192.168.0.209"),
                //new Camera("P1085635-E","192.168.0.108"),
                //new Camera("P1061365-MKII","192.168.0.106"),
                //new Camera("M2193045-V","192.168.0.219"),
                //new Camera("P1185635-E","192.168.0.118"),
                new Camera("P1161365-MKII","192.168.0.116")
            };



        public string GetRTSPUrlFromCameraParameter(Resolution res)
        {
            string url = "rtsp://" + Ipaddr + "/axis-media/media.amp?resolution=";
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

        public override string ToString()
        {
            return PrintInfo.Print<Camera>(this);
            //return "摄像机名称" + this.name + " 摄像机IP "+this.Ipaddr+"streamID:"+streamId+"url:"+url+"CameraID"+cameraID+"username"+username+"password:"+password;
        }
    }

    public class CameraGroups
    {
        public List<Camera> list = new List<Camera>();
        public string groupName = "";
        public string groupID = "";
        public override string ToString()
        {
            return "分组名称 " + groupName + "分组ID:" + groupID;
        }
    }

    public enum NodeType
    {
        Root = 0,
        Group = 1,
        Camera = 2,
        CameraAtGroup = 3
    }

    public static class PrintInfo
    {
        public static string Print<T>(T t)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("该实例所述对象:" + t.GetType().ToString() + "\n");
            int i = 0;
            foreach (System.Reflection.PropertyInfo p in t.GetType().GetProperties())
            {
                sb.Append("第（" + i++ + "）项属性 :" + p.Name + ",值为:" + p.GetValue(t, null) + "\n");
            }
            return sb.ToString();
        }
    }
}

