using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using log4net;
using System.Reflection;

namespace Decoder
{
    public partial class CameraConfig : Form
    {
        static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public CameraConfig()
        {
            InitializeComponent();
            InitializeCameraTree();
            tvCameras.ExpandAll();
        }

        private void InitializeCameraTree()
        {
            TreeNode tn = new TreeNode();
            tn.ToolTipText = "右键增加分组";
            tn.Text = "摄像机树";
            tn.ContextMenuStrip = FNodeStrip;
            tvCameras.Nodes.Add(tn); 
            foreach (Camera c in FileOperation<Camera>.ReadFile())
            {
                AddNodes(c);
            }
             log.Info("摄像机树初始化完成");
        }

        private void AddNodes(Camera c)
        {
            TreeNode tn = new TreeNode(c.name);
            tn.ToolTipText = c.name+"—"+c.ipaddr;
            tn.Tag = c;
            tn.ContextMenuStrip = CMS;
            tvCameras.Nodes[0].Nodes.Add(tn);
        }
        private bool ExistName(string name)
        {
            foreach (TreeNode tn in tvCameras.Nodes[0].Nodes)
            {
                if (tn.Text == name) return true;
            }
            return false;
        }
        private bool ExistTooltips(string tooltips)
        {
            foreach (TreeNode tn in tvCameras.Nodes[0].Nodes)
            {
                if (tn.ToolTipText.Substring(tn.ToolTipText.LastIndexOf("—")+1) == tooltips) return true;
            }
            return false;
        }

        private bool CheckCameraInfo()
        {
            if (txtCameraName.Text.Trim() == "" || txtIPAddress.Text.Trim() == "")
            {
                MessageBox.Show("摄像机名称和IP地址均不可为空");
                return false;
            }

            if (!WindowOperation.IPCheck(txtIPAddress.Text))
            {
                MessageBox.Show("摄像机IP地址不正确，请重新输入");
                return false;
            }
            if (ExistName(txtCameraName.Text))
            {
                MessageBox.Show("摄像机名称已存在，请重新输入");
                txtCameraName.Select(0, txtCameraName.Text.Length);
                return false;
            }
            if (ExistTooltips(txtIPAddress.Text))
            {
                MessageBox.Show("摄像机IP地址已存在，请重新输入");
                txtIPAddress.Select(0, txtIPAddress.Text.Length);
                return false;
            }
            return true;
        }

        private void btnAddCamera_Click(object sender, EventArgs e)
        {
            if (CheckCameraInfo())
            {
                IPAddress ip;
                IPAddress.TryParse(txtIPAddress.Text, out ip);
                Camera c = new Camera(txtCameraName.Text, ip.ToString (), txtUsername.Text.Trim() == "" ? "root" : txtUsername.Text.Trim(), txtPasssword.Text.Trim() == "" ? "pass" : txtPasssword.Text.Trim());
                AddNodes(c);
            }
        }



        private void tvCameras_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{ CMS.Show(e.X,e.Y); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Camera> clist = new List<Camera>();
            foreach (TreeNode tn in tvCameras.Nodes[0].Nodes)
            {
                Camera c = tn.Tag as Camera;
                if (c != null) clist.Add(c);
            }
            FileOperation<Camera>.WriteFile(clist);
            log.Info("摄像机树写入到文件");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            InitializeCameraTree();
            log.Info("摄像机重新读取并恢复");
        } 
    }
}
