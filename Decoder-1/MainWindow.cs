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
            InitializePictureBoxClickAction();
            InitializePictureBoxImage();
        }

        #region 初始化电视墙内容窗口

        public RectList rli = null;
        public List<Rectangle> rlist = null;
        public List<Button> blist = new List<Button>();
        int xstep = 0;
        int ystep = 0;
        private void InitializePictureBoxImage()
        {
            rli = FileOperation<RectList>.ReadFile().First();
            rlist = rli.GetRectangleList();
            xstep = (int)((pictureBox1.Width / rli.N) * ((float)pictureBox1.Height / (float)pictureBox1.Width));
            ystep = pictureBox1.Height / rli.N;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // AddCamerasLabels();
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            BufferedGraphics myBuffer = currentContext.Allocate(e.Graphics, e.ClipRectangle);
            Graphics g = myBuffer.Graphics;
            if (g == null) return;
            g.Clear(this.BackColor);
            DrawBackgroundTable(g);
            DrawRects(g);
            ///渲染到picturebox上；
            myBuffer.Render(e.Graphics);
            myBuffer.Dispose();
            g.Dispose();
        }

        private void AddCamerasLabels()
        {
            foreach (Control c in pictureBox1.Controls)
            {
                Panel pnl = c as Panel;
                if (pnl != null)
                {
                    Point p = (Point)pnl.Tag;
                    pnl.Location = new Point(p.X * xstep, p.Y * ystep);
                    pnl.SendToBack();
                    foreach (Control cc in pnl.Controls) // pnl.Controls
                    {
                        Button btn = cc as Button;
                        if (btn != null)
                        {
                            Point pp = (Point)btn.Tag;
                            if (pp != null)
                            {
                                btn.Location = new Point(pp.X * xstep, pp.Y * ystep);
                                btn.BringToFront(); 
                            }
                        }
                    }                    
                }
            }
        }

        private void DrawRects(Graphics g)
        {
            Pen penInside, penOutside;
            penInside = new Pen(Color.Black);
            penInside.Width = 1;
            penOutside = new Pen(Color.White);
            penOutside.Width = 2;
            //实时的画之前已经画好的矩形  
            foreach (Rectangle rec in rlist)
            {
                g.FillRectangle(penInside.Brush, rec.X * xstep + 1, rec.Y * ystep + 1, rec.Width * xstep - 1, rec.Height * ystep - 1);
                g.DrawRectangle(penOutside, rec.X * xstep, rec.Y * ystep, rec.Width * xstep, rec.Height * ystep);
            }
            penInside.Dispose();
            penOutside.Dispose();
        }

        private void DrawBackgroundTable(Graphics g)
        {
            Pen pen0 = new Pen(Color.LightBlue, 1);  //设置背景表格画笔颜色和大小
            pen0.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            //横向
            for (int x = 0; x <= pictureBox1.Width;)
            {
                g.DrawLine(pen0, x, 0, x, pictureBox1.Height);
                x += xstep;
            }
            //纵向
            for (int y = 0; y <= pictureBox1.Height;)
            {
                g.DrawLine(pen0, 0, y, pictureBox1.Width, y);
                y += ystep;
            }
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            xstep = (int)((pictureBox1.Width / rli.N) * ((float)pictureBox1.Height / (float)pictureBox1.Width));
            ystep = pictureBox1.Height / rli.N;
           // AddCamerasLabels();
            pictureBox1.Refresh();
        }
        #endregion

     

        #region 拖放树节点
        private void TVCamera_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = TVCamera.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                TVCamera.SelectedNode = node;
            }
        }

        /// <summary>
        /// 还存在bug，特别是拖动分组时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void InitializePictureBoxClickAction()
        {
            this.pictureBox1.AllowDrop = true;
            this.pictureBox1.DragOver += new DragEventHandler(pictureBox1_DragOver);
            this.pictureBox1.DragDrop += new DragEventHandler(pictureBox1_DragDrop);
            this.pictureBox1.DragEnter += new DragEventHandler(pictureBox1_DragEnter);
        }
        //这个基本上没用到
        private void pictureBox1_DragOver(object sender, DragEventArgs e)
        {

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
                // MessageBox.Show(c.ToString());
                // Invalidate();
            }

            Point pt = pictureBox1.PointToClient(new Point(e.X, e.Y));
            // Rectangle rec = new Rectangle((int)Math.Floor(e.X / (float)xstep), (int)Math.Floor(e.Y / (float)ystep), 1, 1);
            Rectangle rec = new Rectangle((int)Math.Floor(pt.X / (float)xstep), (int)Math.Floor(pt.Y / (float)ystep), 1, 1);
            foreach (Rectangle r in rlist)
            {
                if (rec.IntersectsWith(r))
                {
                    //重合区域，需做两个操作，一先检查该区域是否已经有按钮占据该位置，有则删除；二保存该区域内的按钮坐标，用于更新；
                    //另外，还需调用相应的编码器以更新播放视频的要求；
                    //每个画面还能多分屏
                    //  Panel pnl = new Panel();
                    //  pnl.Location = new Point(r.X * xstep, r.Y * ystep);
                    //  pnl.Height = r.Height * xstep;
                    //  pnl.Width = r.Width * ystep;
                    //  pnl.Tag = new Point(r.X, r.Y);
                    //  pnl.BackColor = Color.Green;
                    //  pnl.ForeColor = Color.Yellow;
                    ////  pnl.AutoSize = true;

                    //  Button btn = new Button();
                    //  btn.Text = c.Name.ToString();
                    //  btn.Location = new Point(r.X * xstep, r.Y * ystep);
                    //  btn.Height = r.Height * xstep;
                    //  btn.Width = r.Width * ystep;
                    //  //将该按钮的坐标保存到tag内，size的变更会导致step变化，因此在picturebox的size变化时需刷新button的位置
                    //  btn.Tag = new Point(r.X, r.Y);
                    //  btn.BackColor = Color.Gray;
                    //  btn.ForeColor = Color.White;
                    //  btn.ContextMenuStrip = btnMenu;
                    //  btn.Margin = new Padding(2);
                    //  btn.AutoEllipsis = true;
                    // // btn.AutoSize = true;
                    //  btn.FlatAppearance.BorderSize = 2;
                    //  btn.FlatAppearance.MouseOverBackColor = Color.Yellow;
                    //  btn.FlatAppearance.BorderColor = Color.Red;
                    //  btn.Visible = true;
                    //  btn.Dock = DockStyle.Fill; 
                    //  blist.Add(btn);

                    //  pnl.Controls.Add(btn); 
                    //  pictureBox1.Controls.Add(pnl);
                    // Basic_4PannelButtons pb4 = new Basic_4PannelButtons();
                    UserControl pb4 = new Basic_4Panels();
                    pb4.Location = new Point(r.X * xstep+1, r.Y * ystep+1);
                    pb4.Size = new Size(r.Width * ystep-1,r.Height*xstep-1);
                    pictureBox1.Controls.Add(pb4);
                    Invalidate();
                    return;
                }
            }
        }
        #endregion


    }
}
