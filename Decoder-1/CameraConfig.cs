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
using System.Collections;

namespace Decoder
{
    public partial class CameraConfig : Form
    {
        static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CameraConfig()
        {
            InitializeComponent();
            InitializeCameraTree();
            tvCameras.ExpandAll();
        }
        /// <summary>
        /// Tree Node Process
        /// </summary>
        #region


        private void InitializeCameraTree()
        {
            tvCameras.Nodes.Clear();
            AddFirstNode();
            AddGroupNodes();
            AddCamerasNodes();
        }

        private void AddGroupNodes()
        {

        }

        private void AddCamerasNodes()
        {
            foreach (Camera c in FileOperation<Camera>.ReadFile())
            {
                AddOneCameraNode(c);
            }
            log.Info("摄像机树初始化完成");
        }

        private void AddOneGroupNode()
        {
            TreeNode tn = new TreeNode();
            tn.Text = "新建分组";
            tn.ContextMenuStrip = GroupNodeStrip;
            tn.Name = NodeType.Group.ToString();
            CameraGroups cg = new CameraGroups();
            cg.groupID = Guid.NewGuid().ToString();
            cg.groupName = tn.Text;
            tn.Tag = cg;
            tvCameras.Nodes[0].Nodes.Add(tn);
        }

        private void AddFirstNode()
        {
            TreeNode tn = new TreeNode();
            tn.ToolTipText = "右键增加分组";
            tn.Text = "摄像机树";
            tn.Name = NodeType.Root.ToString();
            tn.ContextMenuStrip = FNodeStrip;
            tvCameras.Nodes.Add(tn);
        }

        private void AddOneCameraNode(Camera c)
        {
            TreeNode tn = new TreeNode(c.name);
            tn.ToolTipText = c.name + "—" + c.ipaddr;
            tn.Tag = c;
            tn.Name = NodeType.Camera.ToString();
            tn.ContextMenuStrip = CameraNodeStrip;
            tvCameras.Nodes[0].Nodes.Add(tn);
        }

        private void DeleteOneCameraNode(TreeNode tnDest, TreeNode tndelete)
        {

            foreach (TreeNode tn in tnDest.Nodes)
            {
                if (tn == null) return;
                DeleteOneCameraNode(tn, tndelete);

            }
        }

        private void ReArrangeTree()
        {
            tvCameras.TreeViewNodeSorter = new NodeSorter();
        }

        internal class NodeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;
                return (int)Enum.Parse(typeof(NodeType), tx.Name) - (int)Enum.Parse(typeof(NodeType), ty.Name);
            }
        }
        #endregion

        /// <summary>
        /// Check Values
        /// </summary> 
        /// <returns></returns>
        #region 
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
                if (tn.ToolTipText.Substring(tn.ToolTipText.LastIndexOf("—") + 1) == tooltips) return true;
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
        #endregion


        /// <summary>
        /// UI process
        /// </summary> 
        #region
        private void btnAddCamera_Click(object sender, EventArgs e)
        {
            if (CheckCameraInfo())
            {
                IPAddress ip;
                IPAddress.TryParse(txtIPAddress.Text, out ip);
                Camera c = new Camera(txtCameraName.Text, ip.ToString(), txtUsername.Text.Trim() == "" ? "root" : txtUsername.Text.Trim(), txtPasssword.Text.Trim() == "" ? "pass" : txtPasssword.Text.Trim());
                AddOneCameraNode(c);
            }
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

        private void AddGroupNode_Click(object sender, EventArgs e)
        {
            AddOneGroupNode();
            ReArrangeTree();
        }

        private void deleteGroupNode_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvCameras.SelectedNode;
            tn.Remove();
        }
        #endregion

        private void AddCameraToGroup_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvCameras.SelectedNode;
            CameraGroup cg = new CameraGroup(tvCameras, tn);
            cg.Show();
        }

        private void deleteCamera_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvCameras.SelectedNode;
            if (tn.Name.ToString() == NodeType.Root.ToString())
            {
                MessageBox.Show("根节点不可删除");
                return;
            }
            foreach (TreeNode tng in tvCameras.Nodes[0].Nodes)
            {
                if (tng == null) continue;
                if (tng.Name == NodeType.Group.ToString())
                {
                    foreach (TreeNode tnc in tng.Nodes)
                    {
                        if (tnc.Text == tn.Text && tnc.ToolTipText == tn.ToolTipText)
                        {
                            tnc.Remove();
                        }
                    }
                }
                else
                {
                    if (tng.Text == tn.Text && tng.ToolTipText == tn.ToolTipText)
                    {
                        tng.Remove(); 
                    }
                }
            } 
        }
    }


}
