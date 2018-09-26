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

            pictureBox1.Controls.Clear();
            foreach (Button btn in blist)
            {
                pictureBox1.Controls.Add(btn);
                btn.Show();
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
            pictureBox1.Refresh();
        }
        #endregion

        private void InitializePictureBoxClickAction()
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
                    Button btn = new Button();
                    btn.Text = c.Name.ToString();
                    btn.Location = new Point((r.X+r.Width/4)*xstep,(r.Y+r.Height/2)*ystep);
                    blist.Add(btn);
                    return;
                }
            }
        } 
        #endregion 
    }
}
