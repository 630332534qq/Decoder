using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Decoder
{
    public partial class MainWindow : MetroForm
    {
        #region 跳转菜单
        private void 摄像机配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraConfig ccfg = new CameraConfig();
            ccfg.ShowDialog(this);
        }

        private void 解码器配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DecoderConfig dcfg = new DecoderConfig();
            dcfg.ShowDialog(this);
        }

        private void 许可证配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseConfig lcc = new LicenseConfig();
            lcc.ShowDialog(this);
        }

        private void 电视墙配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DVWConfig dvwcfg = new DVWConfig();
            dvwcfg.ShowDialog(this);
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            Basic_TreeViewInit.InitializeCameraTree(TVCamera);
           // InitializeTreeview();
            InitializePictureBox();
        }
        private void InitializeTreeview()
        {
            if (!TVCamera.Nodes.ContainsKey("分组1"))
            {
                TreeNode groupNode1 = new TreeNode("分组1");
                groupNode1.Name = "分组1";
                TreeNode rootNode = TVCamera.Nodes.Add("分组1");

                if (!rootNode.Nodes.ContainsKey("节点1"))
                {
                    TreeNode TerminalNode1 = new TreeNode();
                    TerminalNode1.Text = "节点1";

                    rootNode.Nodes.Add(TerminalNode1);
                    string filePath1 = @"F:\Project\2018-07\藏书楼\微信图片_20180810085803.jpg";
                    TerminalNode1.Tag = filePath1;
                }

                if (!rootNode.Nodes.ContainsKey("节点2"))
                {
                    TreeNode TerminalNode2 = new TreeNode("节点2");
                    TerminalNode2.Name = "节点2";
                    rootNode.Nodes.Add(TerminalNode2);
                    string filePath2 = @"F:\Project\2018-07\藏书楼\微信图片_201808100858033.jpg";
                    TerminalNode2.Tag = filePath2;
                }
            }
            TVCamera.ExpandAll();
        }

        private void InitializePictureBox()
        {
            this.pictureBox1.AllowDrop = true;
            this.pictureBox1.DragOver += new DragEventHandler(pictureBox1_DragOver);
            this.pictureBox1.DragDrop += new DragEventHandler(pictureBox1_DragDrop);
            this.pictureBox1.DragEnter += new DragEventHandler(pictureBox1_DragEnter);
        } 

        #region 拖放树节点
        private void TVCamera_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = TVCamera.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                TVCamera.SelectedNode = node;
            }
        }

        private void TVCamera_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TreeNode node = TVCamera.SelectedNode;
                if (node != null)
                {
                    Camera c = (node.Tag as Camera);
                    DoDragDrop(c, DragDropEffects.All);
                }
            }
        }

        private void TVCamera_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Camera)) == true)
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            } 
        }

        private void TVCamera_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            //根据鼠标坐标确定要移动到的目标节点
            Point pt;
            TreeNode targeNode;
            pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
            targeNode = this.TVCamera.GetNodeAt(pt);
        }
        #endregion

        #region 拖放pictureBox节点

        //这个基本上没用到
        private void pictureBox1_DragOver(object sender, DragEventArgs e)
        {
            //if ((e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
            //{
            //    e.Effect = DragDropEffects.Link;
            //}
        }
        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Camera)) == true)
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            } 
        }
        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            Camera c = (Camera)(e.Data.GetData(typeof(Camera)));
            if (c != null)
            {
                //Image showImage = Image.FromFile(imagePath);
                //pictureBox1.Image = showImage;
                MessageBox.Show(c.ToString());
                Invalidate();
            }
        }
        #endregion 
    }
}
