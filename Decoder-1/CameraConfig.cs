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
using Microsoft.VisualBasic;

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
        public Camera beUpdatingCamera = null;
        public CameraConfig()
        {
            InitializeComponent();
            InitializeCameraTree();
            tvCameras.ExpandAll();
        }
        #region 
        internal class NodeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;
                return (int)Enum.Parse(typeof(NodeType), tx.Name) - (int)Enum.Parse(typeof(NodeType), ty.Name);
            }
        }

        private void ReArrangeTree()
        {
            tvCameras.TreeViewNodeSorter = new NodeSorter();
            tvCameras.Sort();
        }
        private void InitializeCameraTree()
        {
            tvCameras.Nodes.Clear();
            AddFirstNode();
            AddAllGroupNodes();
            AddAllCamerasNodes();
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
        private void AddAllGroupNodes()
        {
            log.Info("摄像机分组加载完毕");
        }
        private void AddAllCamerasNodes()
        {
            foreach (Camera c in Camera.cList)
            {
                AddOneCameraNode(c);
            }
            log.Info("摄像机加载完毕");
        }
        #endregion

        #region

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
        private void AddGroupNode_Click(object sender, EventArgs e)
        {
            AddOneGroupNode();
            ReArrangeTree();
        }

        private void deleteGroupNode_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvCameras.SelectedNode;
            if (tn != null && tn.Name == NodeType.Group.ToString())
            {
                //删除子节点
                tn.Nodes.Clear();
                CameraGroups cg = tn.Tag as CameraGroups;
                log.Info("删除该分组" + cg.ToString());
                tn.Remove();
            }
            log.Info("删除该分组成功");
        }

        private void EditGroupName_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvCameras.SelectedNode;
            string str = Interaction.InputBox("请输入分组名称", "编辑分组名称", tn.Text, -1, -1);
            CameraGroups cg = tn.Tag as CameraGroups;
            cg.groupName = str;
            tn.Text = str;
        }

        private void AddCameraToGroup_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvCameras.SelectedNode;
            CameraGroupUI cg = new CameraGroupUI(tvCameras, tn);
            cg.returnParent += Cg_returnParent;
            cg.ShowDialog();
            log.Info("跳转到摄像机分组编辑界面");
        }

        private void Cg_returnParent()
        {
            tvCameras.Refresh();
            //对组内的摄像机右键菜单进行修正
            log.Info("配置摄像机分组窗口关闭并返回");
        }
        #endregion

        #region 
        private void btnAddCamera_Click(object sender, EventArgs e)
        {
            if (CheckCameraInfo())
            {
                Camera c = new Camera(txtCameraName.Text, txtIPAddress.Text, txtUsername.Text.Trim() == "" ? "root" : txtUsername.Text.Trim(), txtPasssword.Text.Trim() == "" ? "pass" : txtPasssword.Text.Trim());

                if (btnAddCamera.Text == "添加")
                {
                    AddOneCameraNode(c);
                    MessageBox.Show("添加成功！");
                }

                if (btnAddCamera.Text == "更新")
                {
                    c.cameraID = beUpdatingCamera.cameraID;//更新时，需首先把目标的CameraID与新的Camera的cameraID统一起来
                    UpdateOneCameraNode(c);
                    MessageBox.Show("更新成功!");
                }
                tvCameras.Refresh();
                btnAddCamera.Text = "添加";
                beUpdatingCamera = null;
                SetNull();
            }
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
        private void deleteCamera_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvCameras.SelectedNode;
            Camera selectedToDelete = tn.Tag as Camera;
            Camera cameraInTree;
            if (tn.Name.ToString() == NodeType.Root.ToString())
            {
                MessageBox.Show("根节点不可删除");
                return;
            }
            //如果删除一个摄像机，则连带各个分组内的有该摄像机的也要删除
            if (tn.Name == NodeType.Camera.ToString())
            {
                //对每一个分组
                foreach (TreeNode tngroup in tvCameras.Nodes[0].Nodes)
                {
                    if (tngroup.Name == NodeType.Group.ToString())
                    {
                        //轮询分组内的所有节点摄像机，标注出来哪个需要删除
                        TreeNode tDelete = null;
                        foreach (TreeNode tnCamerainGroup in tngroup.Nodes)
                        {
                            // 删除的依据是判断CameraID是否一致  if (tnCamerainGroup.ToolTipText == tn.ToolTipText)
                            cameraInTree = tnCamerainGroup.Tag as Camera;
                            if (cameraInTree.cameraID == selectedToDelete.cameraID)
                            {
                                tDelete = tnCamerainGroup;
                            }
                        }
                        if (tDelete != null) tDelete.Remove();
                    }
                }
                tn.Remove();
            }
            if (tn.Name == NodeType.CameraAtGroup.ToString())
            {
                tn.Remove();
            }
            tvCameras.Refresh();
        }

        /// <summary>
        /// 更新摄像机信息触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beUpdatingCamera = null;
            beUpdatingCamera = tvCameras.SelectedNode.Tag as Camera;
            if (beUpdatingCamera == null)
            {
                MessageBox.Show("未选中有效更新节点，请重试");
                return;
            }
            txtCameraName.Text = beUpdatingCamera.name;
            txtIPAddress.Text = beUpdatingCamera.ipaddr;
            txtPasssword.Text = beUpdatingCamera.password;
            txtUsername.Text = beUpdatingCamera.username;
            btnAddCamera.Text = "更新";
        }

        /// <summary>
        /// 注意，此时若是更新分组下的摄像机节点，得更新全部节点
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool UpdateOneCameraNode(Camera c)
        { 
            UpdateAllCameras(c, tvCameras.Nodes[0]);
            tvCameras.Refresh();
            log.Info("更新摄像机信息，原摄像机信息:" + beUpdatingCamera.ToString() + "新信息" + c.ToString());
            return true;
        }
        private void UpdateAllCameras(Camera c, TreeNode tn)
        {
            Camera treeNode = null;
            foreach (TreeNode tnn in tn.Nodes)
            {
                if (tnn.Name != NodeType.Group.ToString())
                {
                    treeNode = tnn.Tag as Camera;
                    if (treeNode.cameraID == c.cameraID)
                    {
                        tnn.Text = c.name;
                        tnn.ToolTipText = c.name + "——" + c.ipaddr;
                        tnn.Tag = c;
                    }
                }
                else
                {
                    UpdateAllCameras(c, tnn);
                }
            }
        }


        #endregion

        #region 
        private bool ExistName(string newName)
        {
            //一种是已经存在的名字；
            //另一种是当前正在更新的摄像机的名称
            if (beUpdatingCamera != null)
            {
                foreach (TreeNode tn in tvCameras.Nodes[0].Nodes)
                { if (Text == newName && tn.Name == NodeType.Camera.ToString() && newName != beUpdatingCamera.name) return true; }
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
                    if (tn.Name == NodeType.Camera.ToString() && tn.ToolTipText.Substring(tn.ToolTipText.LastIndexOf("——") + 2) == newIPAddress && newIPAddress != beUpdatingCamera.ipaddr) return true;
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
        private void SetNull()
        {
            txtCameraName.Text = null;
            txtIPAddress.Text = null;
            txtPasssword.Text = null;
            txtUsername.Text = null;
        }
        /// <summary>
        /// 有的时候，右键并未选中节点，会比较容易出错；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvCameras_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (tvCameras.GetNodeAt(e.X, e.Y) != null)
                {
                    tvCameras.SelectedNode = tvCameras.GetNodeAt(e.X, e.Y);
                }
                else
                {
                    return;
                }
            }
        }
        #endregion 

        #region 
        /// <summary>
        /// 保存整颗树到文件，分摄像机和分组分别存储到两个文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Camera> clist = new List<Camera>();
            List<CameraGroups> cgsList = new List<CameraGroups>();
            foreach (TreeNode tn in tvCameras.Nodes[0].Nodes)
            {
                if (tn.Name == NodeType.Camera.ToString())
                {
                    Camera c = tn.Tag as Camera;
                    if (c != null) clist.Add(c);
                }
                if (tn.Name == NodeType.Group.ToString())
                {
                    CameraGroups cg = tn.Tag as CameraGroups;
                    foreach (TreeNode tnCameraInGroup in tn.Nodes)
                    {
                        if (tnCameraInGroup.Name == NodeType.CameraAtGroup.ToString())
                        {
                            Camera cameraInG = tnCameraInGroup.Tag as Camera;
                            if (cameraInG != null) cg.list.Add(cameraInG);
                        }
                    }
                    if (cg != null) cgsList.Add(cg);
                }
            }
            log.Info("摄像机树写入到文件");
            FileOperation<Camera>.WriteFile(clist);
            log.Info("摄像机写入完成");
            FileOperation<CameraGroups>.WriteFile(cgsList);
            log.Info("摄像机分组写入完成");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            InitializeCameraTree();
            log.Info("摄像机重新读取并恢复");
        }
        #endregion

    }
}
