using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Decoder
{
    public partial class Basic_UIPanels : UserControl
    {
        private IContainer components = null;
        private ContextMenuStrip cms = null;
        private TableLayoutPanel tlp = null;
        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public Basic_UIPanels()
        {
            InitTableLayoutPanel(1);
        }

        public Basic_UIPanels(int panelCount)
        {
            InitTableLayoutPanel(panelCount);
        }
         
        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="panelNo"></param>
        public void InitTableLayoutPanel(int panelCount)
        {
            this.DoubleBuffered = true;
            components = new Container();
            cms = InitCMS();
            tlp = new TableLayoutPanel();
            tlp.Name = Guid.NewGuid().ToString();
            tlp.AutoSize = true;
            tlp.BackColor = Color.Gray;
            tlp.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlp.Dock = DockStyle.Fill;
            InitializeComponentsByme(panelCount);
        }

        public void InitializeComponentsByme(int panelCount)
        {
            tlp.Controls.Clear();
            DynamicLayout(panelCount);
            for (int i = 0; i < tlp.ColumnCount; i++)
            {
                for (int j = 0; j < tlp.RowCount; j++)
                {
                    PictureBox p = new PictureBox();
                    tlp.Controls.Add(p, i, j);
                    p.Name = (j * tlp.RowCount + i).ToString();
                    p.Dock = DockStyle.Fill;
                    p.ContextMenuStrip = cms;
                    p.Margin = new Padding(0);
                    p.BackColor = SystemColors.GrayText;
                    p.Tag = tlp;
                    InitPictureBoxAction(p);
                }
            }
            Controls.Add(tlp);
        }
        /// <summary>
        ///   初始化行与列，并均分各行、列占比；
        ///   初始化完成后，再塞入picturebox，否则容易撑大首行首列
        /// </summary>
        /// <param name="layoutPanel"></param>
        /// <param name="rowcolcountl"></param>
        private void DynamicLayout(int rowcolcountl)
        {
            tlp.RowCount = (int)Math.Sqrt(rowcolcountl);    //设置分成几行  
            for (int i = 0; i < tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            }
            tlp.ColumnCount = (int)Math.Sqrt(rowcolcountl);    //设置分成几列  
            for (int i = 0; i < tlp.ColumnCount; i++)
            {
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            }
        }

        #region 注册右键菜单并实现右键菜单功能
        public ContextMenuStrip InitCMS()
        {
            ContextMenuStrip cms = new ContextMenuStrip(components);
            ToolStripMenuItem 单画面ToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem Four画面ToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem Nine画面ToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem Sixteen画面ToolStripMenuItem = new ToolStripMenuItem();
            cms.Items.AddRange(new ToolStripItem[] {
            单画面ToolStripMenuItem,
            Four画面ToolStripMenuItem,
            Nine画面ToolStripMenuItem,
            Sixteen画面ToolStripMenuItem});
            cms.Name = "cms";
            cms.Size = new Size(153, 114);
            // 单画面ToolStripMenuItem 
            单画面ToolStripMenuItem.Name = "单画面ToolStripMenuItem";
            单画面ToolStripMenuItem.Size = new Size(152, 22);
            单画面ToolStripMenuItem.Text = "单画面";
            单画面ToolStripMenuItem.Click += new EventHandler(单画面ToolStripMenuItem_Click);
            // Four画面ToolStripMenuItem 
            Four画面ToolStripMenuItem.Name = "Four画面ToolStripMenuItem";
            Four画面ToolStripMenuItem.Size = new Size(152, 22);
            Four画面ToolStripMenuItem.Text = "4画面";
            Four画面ToolStripMenuItem.Click += new EventHandler(Four画面ToolStripMenuItem_Click);
            // Nine画面ToolStripMenuItem 
            Nine画面ToolStripMenuItem.Name = "Nine画面ToolStripMenuItem";
            Nine画面ToolStripMenuItem.Size = new Size(152, 22);
            Nine画面ToolStripMenuItem.Text = "9画面";
            Nine画面ToolStripMenuItem.Click += new EventHandler(Nine画面ToolStripMenuItem_Click);
            // Sixteen画面ToolStripMenuItem 
            Sixteen画面ToolStripMenuItem.Name = "Sixteen画面ToolStripMenuItem";
            Sixteen画面ToolStripMenuItem.Size = new Size(152, 22);
            Sixteen画面ToolStripMenuItem.Text = "16画面";
            Sixteen画面ToolStripMenuItem.Click += new EventHandler(Sixteen画面ToolStripMenuItem_Click);
            return cms;
        }

        public void 单画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePanel(1);
            // MessageBox.Show("单画面" + GetPictureboxName(sender));
        }

        public void Four画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePanel(4);
            //MessageBox.Show("4画面" + GetPictureboxName(sender));
        }

        public void Nine画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePanel(9);
            //MessageBox.Show("9画面" + GetPictureboxName(sender));
        }

        public void Sixteen画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePanel(16);
            //MessageBox.Show("16画面" + GetPictureboxName(sender));
        }

        public void ChangePanel(int panelNo)
        {
            //Controls.Clear(); 
            InitializeComponentsByme(panelNo);
            //  tlp.Invalidate(); --强制引发重绘，会导致闪屏一次；
        }

        private string GetPictureboxName(object sender)
        {
            ToolStripMenuItem tsm = sender as ToolStripMenuItem;
            ContextMenuStrip cmsip = tsm.Owner as ContextMenuStrip;
            PictureBox p = cmsip.SourceControl as PictureBox;
            if (p != null)
            {
                Graphics g = p.CreateGraphics();
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawString("TextTest ", new Font("Arial ", 10, FontStyle.Bold), Brushes.White, new PointF(20, 30));
                return p.Name;
            }
            return "";
        }

        #endregion

        #region 注册并实现各picturebox的拖动事件

        /// <summary>
        /// 注册各个picturebox的拖动事件
        /// </summary>
        /// <param name="pb"></param>
        private void InitPictureBoxAction(PictureBox pb)
        {
            pb.AllowDrop = true;
            pb.DragOver += new DragEventHandler(PB_DragOver);
            pb.DragDrop += new DragEventHandler(PB_DragDrop);
            pb.DragEnter += new DragEventHandler(PB_DragEnter);
           // pb.SizeChanged += Pb_SizeChanged;
        }

        private void Pb_SizeChanged(object sender, EventArgs e)
        {

        }

        private void PB_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)) == true)
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PB_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode c = (TreeNode)(e.Data.GetData(typeof(TreeNode)));
            ProcessPbData(sender,c); 
        }
        
        private void ProcessPbData(object sender,TreeNode c)
        {
            PictureBox pbx = sender as PictureBox;
            if (c != null)
            {
                PackageOfPB ppb = new PackageOfPB();
                ppb.Current = (NodeType)Enum.Parse(typeof(NodeType), c.Name);
                ppb.Pbx = pbx;
                switch (ppb.Current)
                {
                    case NodeType.Camera:
                        ppb.Cam = c.Tag as Camera;
                        ppb.Cg = null;
                        break;
                    case NodeType.Group:
                        ppb.Cg = c.Tag as CameraGroups;
                        ppb.Cam = null;
                        break;
                    case NodeType.CameraAtGroup:
                        ppb.Cam = c.Tag as Camera;
                        ppb.Cg = null;
                        break;
                }
                if (ppb.Current == NodeType.Camera) 
                    //MessageBox.Show(c.ToString());
                Invalidate();
            }
        }

        private void PB_DragOver(object sender, DragEventArgs e)
        {

        }
        #endregion 
    }
}
