using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using log4net;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

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
        private int paneId;
        private float left = 0.0f;
        private float right = 1.0f;
        private float top = 0.0f;
        private float bottom = 1.0f;

        public int PaneId
        {
            get { return paneId; }
            set { paneId = value; }
        }
        public float Left
        {
            get { return left; }
            set { left = value; }
        }
        public float Right
        {
            get { return right; }
            set { right = value; }
        }
        public float Top
        {
            get { return top; }
            set { top = value; }
        }
        public float Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }
        public panes(int id, float l, float r, float t, float b)
        {
            PaneId = id;
            Left = l;
            Right = r;
            Top = t;
            Bottom = b;
        }
    }

    public class segments
    {
        private int stream;
        private int pane;

        public int Stream
        {
            get { return stream; }
            set { stream = value; }
        }
        public int Pane
        {
            get { return pane; }
            set { pane = value; }
        }

        public segments(panes p, Camera c)
        {
            Stream = BasicOperation.GetStreamID(c.Ipaddr);
            Pane = p.PaneId;
        }
    }

    public class views
    {
        private int viewId;
        private int duration = 0;
        public List<segments> segments = new List<segments>();

        public int ViewId
        {
            get { return viewId; }
            set { viewId = value; }
        }
        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public views(int dur, segments s)
        {
            ViewId = GetID.ID;
            Duration = dur;
            segments.Add(s);
        }
    }

    public class Decoder
    {
        private string ipaddr;
        private string decoderName;
        private string username;
        private string password;
        private string serialNo;
        private string configuration;

        public string Ipaddr
        {
            get { return ipaddr; }
            set { ipaddr = value; }
        }
        public string DecoderName
        {
            get { return decoderName; }
            set { decoderName = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string SerialNo
        {
            get { return serialNo; }
            set { serialNo = value; }
        }
        public string Configuration
        {
            get { return configuration; }
            set { configuration = value; }
        }

        public override string ToString()
        {
            return PrintInfo.Print(this);
        }
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

        #region 成员属性
        [JsonIgnore]
        private Guid cameraID = Guid.NewGuid();
        [JsonProperty]
        public Guid CameraID
        {
            get { return cameraID; }
            set { cameraID = value; }
        }
        /// <summary>
        /// Camera's name
        /// </summary> 
        [JsonIgnore]
        private string name;
        [JsonProperty]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Camera's ipAddress
        /// </summary> 
        [JsonIgnore]
        private string ipaddr;
        [JsonProperty]
        public string Ipaddr
        {
            get { return ipaddr; }
            set { ipaddr = value; }
        }
        [JsonIgnore]
        private int streamId;
        [JsonProperty]
        public int StreamId
        {
            get
            {
                if (Ipaddr != null) return StreamId = BasicOperation.GetStreamID(Ipaddr);
                else return 0;
            }
            set { streamId = value; }
        }
        [JsonIgnore]
        private string url;
        [JsonProperty]
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        [JsonIgnore]
        private string videoCodec = global::Decoder.VideoCodec.H264.ToString();
        [JsonProperty]
        public string VideoCodec
        {
            get { return videoCodec; }
            set { videoCodec = value; }
        }
        [JsonIgnore]
        private string audioCodec = "";
        [JsonProperty]
        public string AudioCodec
        {
            get { return audioCodec; }
            set { audioCodec = value; }
        }
        [JsonIgnore]
        private string username = "root";
        [JsonProperty]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        [JsonIgnore]
        private string password = "pass";
        [JsonProperty]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [JsonIgnore]
        private string fps = "15";
        [JsonProperty]
        public string Fps
        {
            get { return fps; }
            set { fps = value; }
        }
        #endregion

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

        #region basicData
        public static List<Camera> cList = new List<Camera>
            {
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.8"),
                new Camera("P1365-MKII","192.168.0.6"),
                new Camera("M119-3045-V","192.168.0.119"),
                new Camera("P185635-E","192.168.0.18"),
                new Camera("P161365-MKII","192.168.0.16"),
                new Camera("M129-3045-V","192.168.0.129"),
                new Camera("P285635-E","192.168.0.28"),
                new Camera("P261365-MKII","192.168.0.26"),
                new Camera("M1393045-V","192.168.0.139"),
                new Camera("P385635-E","192.168.0.38"),
                new Camera("P361365-MKII","192.168.0.36"),
                new Camera("M1493045-V","192.168.0.149"),
                new Camera("P485635-E","192.168.0.48"),
                new Camera("P461365-MKII","192.168.0.46"),
                new Camera("M1593045-V","192.168.0.159"),
                new Camera("P585635-E","192.168.0.58"),
                new Camera("P561365-MKII","192.168.0.56"),
                new Camera("M1693045-V","192.168.0.169"),
                new Camera("P685635-E","192.168.0.68"),
                new Camera("P661365-MKII","192.168.0.66"),
                new Camera("M1793045-V","192.168.0.179"),
                new Camera("P785635-E","192.168.0.78"),
                new Camera("P761365-MKII","192.168.0.76"),
                new Camera("M1893045-V","192.168.0.189"),
                new Camera("P885635-E","192.168.0.88"),
                new Camera("P861365-MKII","192.168.0.86"),
                new Camera("M1993045-V","192.168.0.199"),
                new Camera("P985635-E","192.168.0.98"),
                new Camera("P961365-MKII","192.168.0.96"),
                new Camera("M2093045-V","192.168.0.209"),
                new Camera("P1085635-E","192.168.0.108"),
                new Camera("P1061365-MKII","192.168.0.106"),
                new Camera("M2193045-V","192.168.0.219"),
                new Camera("P1185635-E","192.168.0.118"),
                new Camera("P1161365-MKII","192.168.0.116")
            };

        #endregion

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
            url = url + "&fps=" + Fps;
            return url;
            //  return "{\"streamId\":" + BasicOperation.GetStreamID(this.ipaddr) + ",\"url\":\"" + url + "\",\"videoCodec\":\"" + videoCodec + "\",\"audioCodec\":" + "\"\"" + ",\"username\":\"" + username + "\",\"password\":\"" + password + "\"}";
        }

        public override string ToString()
        {
            return PrintInfo.Print(this);
            //return "摄像机名称" + this.name + " 摄像机IP "+this.Ipaddr+"streamID:"+streamId+"url:"+url+"CameraID"+cameraID+"username"+username+"password:"+password;
        }
    }

    /// <summary>
    /// 摄像机分组
    /// </summary>
    public class CameraGroups
    {
        private List<Camera> list = new List<Camera>();
        private string groupName = "";
        private string groupID = "";

        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }

        public string GroupID
        {
            get { return groupID; }
            set { groupID = value; }
        }

        public List<Camera> List
        {
            get
            {
                return list;
            }

            set
            {
                list = value;
            }
        }

        public override string ToString()
        {
            return PrintInfo.Print(this);
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
            foreach (PropertyInfo p in t.GetType().GetProperties())
            {
                sb.Append("第（" + i++ + "）项属性 :" + p.Name + ",值为:" + p.GetValue(t, null) + "\n");
            }
            return sb.ToString();
        }
    }

    public class RectList
    {
        int xsteps = 0;
        int ysteps = 0;
        int n = 0;

        private List<RectItem> rlist = new List<RectItem>();
        [JsonProperty]
        public int Xsteps
        {
            get { return xsteps; }
            set { xsteps = value; }
        }
        [JsonProperty]
        public int Ysteps
        {
            get { return ysteps; }

            set { ysteps = value; }
        }
        [JsonProperty]
        public int N
        {
            get { return n; }
            set { n = value; }
        }
        [JsonProperty]
        public List<RectItem> Rlist
        {
            get { return rlist; }
            set { rlist = value; }
        }

        public RectList()
        { }

        public RectList(int xstep, int ystep, int n)
        {
            Xsteps = xstep;
            Ysteps = ystep;
            N = n;
        }

        public List<Rectangle> GetRectangleList()
        {
            List<Rectangle> rlistRec = new List<Rectangle>();
            foreach (RectItem r in rlist)
            {
                Rectangle rt = new Rectangle(r.X, r.Y, r.Width, r.Height);
                rlistRec.Add(rt);
            }
            return rlistRec;
        }

        public void SaveRectangleList(List<Rectangle> list)
        {
            foreach (Rectangle r in list)
            {
                Rlist.Add(new RectItem(r.X, r.Y, r.Width, r.Height));
            }
        }
    }

    public class RectItem
    {
        int x = 0;
        int y = 0;
        int width = 0;
        int height = 0;
        [JsonProperty]
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        [JsonProperty]
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        [JsonProperty]
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        [JsonProperty]
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public RectItem(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
        }
    }

    public class PackageOfPB
    {
        private RectItem rectitem = null;
        private Camera cam = null;
        private CameraGroups cg = null;
        private NodeType current;
        private Basic_UIPanels bui;
        private TreeNode treenode;
        private PictureBox pbx;
        public RectItem Rectitem
        {
            get { return rectitem; }
            set { rectitem = value; }
        }

        public Camera Cam
        {
            get { return cam; }
            set { cam = value; }
        }

        public CameraGroups Cg
        {
            get { return cg; }
            set { cg = value; }
        }

        public NodeType Current
        {
            get { return current; }
            set { current = value; }
        }

        public Basic_UIPanels Bui
        {
            get { return bui; }
            set { bui = value; }
        }

        public TreeNode Treenode
        {
            get { return treenode; }
            set { treenode = value; }
        }

        public PictureBox Pbx
        {
            get { return pbx; }
            set { pbx = value; }
        }
    }
}

