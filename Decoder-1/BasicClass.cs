using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decoder_1
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

    public  enum Resolution
    {
        LOW = 0,
        MIDDLE = 1,
        HIGH = 2
    }
    public static class BasicOperation
    {
        public static int GetStreamID(string ip)
        {
            string[] ips = ip.Split('.');
            string s = ips[0].ToString() + ips[1].ToString() + ips[2].ToString() + ips[3].ToString();
            return s.Length < 9 ? int.Parse(s) : int.Parse(s.Substring(s.Length - 9, 9));
        }
    }


    public class Camera
    {
        public string name;
        public string ipaddr;
        public string username = "root";
        public string password = "pass";
        public string videoCodec = "H264";
        public string fps = "15";
        public Camera(string name, string ipaddr)
        {
            this.name = name;
            this.ipaddr = ipaddr;
        }
        public Camera(string name, string ipaddr, string username, string password)
        {
            this.name = name;
            this.ipaddr = ipaddr;
            this.username = username;
            this.password = password;
        }
      
        public static List<Camera> c = new List<Camera>
            {
                new Camera("M3045-V","192.168.0.109"),
                new Camera("P5635-E","192.168.0.88"),
                new Camera("P1365-MKII","192.168.0.6")
            };
        public string getStreams(Resolution res)
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
            return "{\"streamId\":" + BasicOperation.GetStreamID(this.ipaddr) + ",\"url\":\"" + url + "\",\"videoCodec\":\"" + videoCodec + "\",\"audioCodec\":" + "\"\"" + ",\"username\":\"" + username + "\",\"password\":\"" + password + "\"}";
        }
    }

}

