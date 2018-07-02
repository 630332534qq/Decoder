using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Decoder_1
{
    public partial class CameraConfig : Form
    {
        public CameraConfig()
        {
            InitializeComponent();
            InitializeCameraTree();
            tvCameras.ExpandAll();
        }

        private void InitializeCameraTree()
        {
            tvCameras.Nodes.Add(new TreeNode("摄像机树"));
            foreach (Camera c in Camera.cList)
            {
                AddNodes(c.name, c.ipaddr);
            }
        }

        private void AddNodes(string name, string tooltips)
        {
            TreeNode tn = new TreeNode(name);
            tn.ToolTipText = tooltips;
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
                if (tn.ToolTipText == tooltips) return true;
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
                AddNodes(txtCameraName.Text, ip.ToString());
            }
        }

       

        private void tvCameras_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{ CMS.Show(e.X,e.Y); }
        }
    }
}
