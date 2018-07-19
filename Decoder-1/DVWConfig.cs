using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Decoder
{
    public partial class DVWConfig: MetroForm
    {
        public const int N = 20;
        bool bDrawStart = false;
        Point pointStart = Point.Empty;
        Point pointContinue = Point.Empty;
        List<Rectangle> rlist = new List<Rectangle>();
        int xstep = 0;
        int ystep = 0;

        public DVWConfig()
        {
            InitializeComponent();
            xstep = (int)((pictureBox1.Width / N) * ((float)pictureBox1.Height / (float)pictureBox1.Width));
            ystep = pictureBox1.Height / N;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            ///双缓冲绘图，先绘到上下文环境中
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            BufferedGraphics myBuffer = currentContext.Allocate(e.Graphics, e.ClipRectangle);
            Graphics g = myBuffer.Graphics;
            if (g == null) return;
            g.Clear(this.BackColor);
            DrawBackgroundTable(g);
            Pen penInside = new Pen(Color.Red);
            penInside.Width = 1;
            Pen penOutside = new Pen(Color.Yellow);
            penOutside.Width = 2;
            if (bDrawStart)
            {
                //实时的画矩形   
                g.FillRectangle(penInside.Brush, pointStart.X + 1, pointStart.Y + 1, pointContinue.X - pointStart.X - 1, pointContinue.Y - pointStart.Y - 1);
                g.DrawRectangle(penInside, pointStart.X, pointStart.Y, pointContinue.X - pointStart.X, pointContinue.Y - pointStart.Y);
            }
            //实时的画之前已经画好的矩形  
            foreach (Rectangle rec in rlist)
            {
                g.FillRectangle(penInside.Brush, rec.X * xstep + 1, rec.Y * ystep + 1, rec.Width * xstep - 1, rec.Height * ystep - 1);
                g.DrawRectangle(penOutside, rec.X * xstep, rec.Y * ystep, rec.Width * xstep, rec.Height * ystep);
            }
            penInside.Dispose();
            ///渲染到picturebox上；
            myBuffer.Render(e.Graphics);
            myBuffer.Dispose();
            g.Dispose();
        }

        private void DrawBackgroundTable(Graphics g)
        {
            Pen pen0 = new Pen(Color.LightBlue, 1);  //设置背景表格画笔颜色和大小
            pen0.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            xstep = (int)((pictureBox1.Width / N) * ((float)pictureBox1.Height / (float)pictureBox1.Width));
            ystep = pictureBox1.Height / N;
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

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                PictureBox _PictureBox = (PictureBox)sender;
                Bitmap _Bitmap = new Bitmap(_PictureBox.Width, _PictureBox.Height);
                _PictureBox.DrawToBitmap(_Bitmap, new Rectangle(0, 0, _PictureBox.Width, _PictureBox.Height));
                Color c = _Bitmap.GetPixel(e.X, e.Y);
                _Bitmap.Dispose();
                if (c.ToArgb() == _PictureBox.BackColor.ToArgb() || c.ToArgb() == Color.LightBlue.ToArgb())
                {
                    contextMenuStrip1.Enabled = false;
                    return;
                }
                contextMenuStrip1.Enabled = true;
                return;
            }
            if (bDrawStart)
            {
                bDrawStart = false;
            }
            else
            {
                bDrawStart = true;
                pointStart = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bDrawStart)
            {
                pointContinue = e.Location;
                Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (bDrawStart)
            {
                Rectangle rec = new Rectangle((int)Math.Floor(pointStart.X / (float)xstep), (int)Math.Floor(pointStart.Y / (float)ystep), (int)Math.Ceiling((pointContinue.X - pointStart.X) / (float)xstep), (int)Math.Ceiling((pointContinue.Y - pointStart.Y) / (float)ystep));
                foreach (Rectangle r in rlist)
                {
                    if (rec.IntersectsWith(r))
                    {
                        MessageBox.Show("电视墙画面不可重叠！");
                        InitialMouseForNextDrawing();
                        return;
                    }
                }
                rlist.Add(rec);
            }
            InitialMouseForNextDrawing();
        }

        private void InitialMouseForNextDrawing()
        {
            pointStart = Point.Empty;
            pointContinue = Point.Empty;
            bDrawStart = false;
            Refresh();
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            Refresh();
        } 

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point selectedRec = pictureBox1.PointToClient(删除ToolStripMenuItem.GetCurrentParent().Bounds.Location);
            DialogResult dr = MessageBox.Show("确定要删除吗？", "删除画面", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                Rectangle recDelete = new Rectangle(0, 0, 0, 0);
                foreach (Rectangle rec in rlist)
                {
                    if (selectedRec.X >= rec.X * xstep && selectedRec.Y >= rec.Y * ystep && selectedRec.X <= (rec.X + rec.Width) * xstep && selectedRec.Y <= (rec.Y + rec.Height) * ystep)
                    {
                        recDelete = rec;
                    }
                }
                rlist.Remove(recDelete);
                Refresh();
            }
        }
    }
}

