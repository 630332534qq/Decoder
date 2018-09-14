using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Decoder
{
    public static class Basic_TreeViewInit
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static TreeNode root = null;
        public static TreeNode InitializeCameraTree(TreeView tv)
        {
            tv.Nodes.Clear();
            AddFirstNode(tv);
            AddAllGroupNodes();
            AddAllCamerasNodes();
            return root;
        }

        public static void AddFirstNode(TreeView tv)
        {
            TreeNode tn = new TreeNode();
            tn.ForeColor = System.Drawing.Color.Red;
            tn.Text = "摄像机树";
            tn.Name = NodeType.Root.ToString();
            tv.Nodes.Add(tn);
            root = tn;
            log.Info("初始化-创建根节点");
        }

        public static void AddAllGroupNodes()
        {
            List<CameraGroups> cgsList = FileOperation<CameraGroups>.ReadFile();
            foreach (CameraGroups cg in cgsList)
            {
                TreeNode tn = AddOneGroupNode(cg);
                foreach (Camera c in cg.list)
                {
                    AddOneCameraUnderGroup(tn, c);
                }
            }
            log.Info("初始化-摄像机分组加载完毕");
        }

        public static TreeNode AddOneGroupNode(CameraGroups cg)
        {
            TreeNode tn = new TreeNode();
            tn.ForeColor = System.Drawing.Color.Blue;
            tn.Text = cg.GroupName;
            tn.Name = NodeType.Group.ToString();
            tn.Tag = cg;
            tn.ToolTipText = cg.GroupName;
            root.Nodes.Add(tn);
            log.Info("初始化-加载摄像机分组节点:" + cg.ToString());
            return tn;
        }

        public static void AddOneCameraUnderGroup(TreeNode tn, Camera c)
        {
            TreeNode tnnew = new TreeNode(c.Name);
            tnnew.ForeColor = System.Drawing.Color.Brown;
            tnnew.ToolTipText = c.Name + "——" + c.Ipaddr;
            tnnew.Tag = c;
            tnnew.Name = NodeType.CameraAtGroup.ToString();
            tn.Nodes.Add(tnnew);
            log.Info("初始化-加载分组下的一个摄像机," + c.ToString());
        }

        public static void AddAllCamerasNodes()
        {
            List<Camera> cList = FileOperation<Camera>.ReadFile();
            foreach (Camera c in cList)
            {
                AddOneCameraNode(c);
            }
            log.Info("初始化-所有摄像机加载完毕");
        }

        public static void AddOneCameraNode(Camera c)
        {
            TreeNode tn = new TreeNode(c.Name);
            tn.ForeColor = System.Drawing.Color.Green;
            tn.ToolTipText = c.Name + "——" + c.Ipaddr;
            tn.Tag = c;
            tn.Name = NodeType.Camera.ToString();
            root.Nodes.Add(tn);
            log.Info("初始化-加载一个摄像机," + c.ToString());
        }
    }
}
