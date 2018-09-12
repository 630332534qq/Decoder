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
using MetroFramework.Forms;
namespace Decoder
{
    public partial class CameraConfig : MetroForm
    {
        //Treevew定义：
        //name代表类型
        //tag代表该对象
        //text代表对象名称
        //tootips代表IP地址等

        static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public TreeNode tnSelected = null;
        public Camera beUpdatingCamera = null;
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
            foreach (Camera c in Camera.cList)
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

        private bool AddOneCameraNode(Camera c)
        {
            TreeNode tn = new TreeNode(c.name);
            tn.ToolTipText = c.name + "——" + c.ipaddr;
            tn.Tag = c;
            tn.Name = NodeType.Camera.ToString();
            tn.ContextMenuStrip = CameraNodeStrip;
            tvCameras.Nodes[0].Nodes.Add(tn);
            log.Info("增加一个摄像机," + c.ToString());
            return true;
        }

        private bool UpdateOneCameraNode(Camera c)
        {
            TreeNode tn = tvCameras.SelectedNode;
            tn.Text = c.name;
            tn.ToolTipText = c.name + "——" + c.ipaddr;
            tn.Tag = c;
            tn.Name = NodeType.Camera.ToString();
            tn.ContextMenuStrip = CameraNodeStrip;
            log.Info("更新摄像机，原摄像机数据:" + beUpdatingCamera.ToString() + "新数据" + c.ToString());
            return true;
        }
        private void DeleteOneCameraNode(TreeNode tnDest, TreeNode tndelete)
        {
            log.Info("即将删除一个摄像机," + tndelete.Text.ToString());
            foreach (TreeNode tn in tnDest.Nodes)
            {
                if (tn == null) return;
                DeleteOneCameraNode(tn, tndelete);
            }
        }
        private void ReArrangeTree()
        {
            tvCameras.TreeViewNodeSorter = new NodeSorter();
            tvCameras.Sort();
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
        private bool ExistName(string newName)
        {
            //一种是已经存在的名字；
            //另一种是当前正在更新的摄像机的名称
            if (beUpdatingCamera != null)
            {
                foreach (TreeNode tn in tvCameras.Nodes[0].Nodes)
                { if ( Text == newName && tn.Name == NodeType.Camera.ToString() && newName != beUpdatingCamera.name) return true; }
            }
            else
            {
                foreach (TreeNode tn in tvCameras.Nodes[0].Nodes)
                { if (tn.Text == newName && tn.Name == NodeType.Camera.ToString()) return true; }
            }
            return false;
        }
        private bool ExistIPAddress(string newIPAddress)
        {  //tooltips 存储摄像机的IP地址，且节点类型是Camera
            if (beUpdatingCamera != null)
            {
                foreach (TreeNode tn in tvCameras.Nodes[0].Nodes)
                {
                    if (tn.Name == NodeType.Camera.ToString() && tn.ToolTipText.Substring(tn.ToolTipText.LastIndexOf("——") + 2) == newIPAddress &&  newIPAddress != beUpdatingCamera.ipaddr) return true;
                }
            }
            else
            {
                foreach (TreeNode tn in tvCameras.Nodes[0].Nodes)
                {
                    //string s = NodeType.Camera.ToString();
                    //string sub = tn.ToolTipText.Substring(tn.ToolTipText.LastIndexOf("——") + 1);
                    if (tn.Name == NodeType.Camera.ToString() && tn.ToolTipText.Substring(tn.ToolTipText.LastIndexOf("——") + 2) == newIPAddress) return true;
                }
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
                MessageBox.Show("摄像机IP地址格式不正确，请修正");
                return false;
            }
            if (ExistName(txtCameraName.Text))
            {
                MessageBox.Show("摄像机名称已存在，请修正");
                txtCameraName.Select(0, txtCameraName.Text.Length);
                return false;
            }
            if (ExistIPAddress(txtIPAddress.Text))
            {
                MessageBox.Show("摄像机IP地址已存在，请修正");
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
                Camera c = new Camera(txtCameraName.Text,txtIPAddress.Text, txtUsername.Text.Trim() == "" ? "root" : txtUsername.Text.Trim(), txtPasssword.Text.Trim() == "" ? "pass" : txtPasssword.Text.Trim());

                if (btnAddCamera.Text == "添加" && AddOneCameraNode(c))
                {
                    MessageBox.Show("添加成功！");
                }

                if (btnAddCamera.Text == "更新" && UpdateOneCameraNode(c))
                {
                    MessageBox.Show("更新成功!");
                }
                tvCameras.Refresh();
                btnAddCamera.Text = "添加";
                tnSelected = null;
                SetNull();
            }
        }

        private void SetNull()
        {
            txtCameraName.Text = null;
            txtIPAddress.Text = null;
            txtPasssword.Text = null;
            txtUsername.Text = null;
        }
        private void UpdateCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beUpdatingCamera = null;
            tnSelected = tvCameras.SelectedNode;
            beUpdatingCamera = tnSelected.Tag as Camera;
            txtCameraName.Text = beUpdatingCamera.name;
            txtIPAddress.Text = beUpdatingCamera.ipaddr;
            txtPasssword.Text = beUpdatingCamera.password;
            txtUsername.Text = beUpdatingCamera.username;
            btnAddCamera.Text = "更新";
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
            if (tn.Name == NodeType.Group.ToString())
            {
                tn.Remove();
            }
            log.Info("删除该分组");
        }
        #endregion

        private void AddCameraToGroup_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvCameras.SelectedNode;
            CameraGroup cg = new CameraGroup(tvCameras, tn);
            cg.returnParent += Cg_returnParent;
            cg.ShowDialog();
            log.Info("增加摄像机到分组内");
        }

        private void Cg_returnParent()
        {
            tvCameras.Refresh();
            log.Info("配置摄像机分组窗口关闭并返回");
        }


        /// <summary>
        /// 删除摄像机会报错
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteCamera_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvCameras.SelectedNode;
            if (tn.Name.ToString() == NodeType.Root.ToString())
            {
                MessageBox.Show("根节点不可删除");
                return;
            }
            tn.Remove();
            tvCameras.Refresh();
            //foreach (TreeNode tng in tvCameras.Nodes[0].Nodes)
            //{
            //    if (tng == null) continue;
            //    if (tng.Name == NodeType.Group.ToString())
            //    {
            //        foreach (TreeNode tnc in tng.Nodes)
            //        {
            //            if (tnc.Text == tn.Text && tnc.ToolTipText == tn.ToolTipText)
            //            {
            //                tnc.Remove();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (tng.Text == tn.Text && tng.ToolTipText == tn.ToolTipText)
            //        {
            //            tng.Remove();
            //        }
            //    }
            //}
        }


    }


}
