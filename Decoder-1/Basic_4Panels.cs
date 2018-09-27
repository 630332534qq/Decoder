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
    public partial class Basic_4Panels : UserControl
    {
        public Basic_4Panels()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                PictureBox pb = c as PictureBox;
                if (pb != null)
                {
                    pb.AllowDrop = true;
                    pb.DragOver += new DragEventHandler(PB_DragOver);
                    pb.DragDrop += new DragEventHandler(PB_DragDrop);
                    pb.DragEnter += new DragEventHandler(PB_DragEnter);
                }
            }
        }

        private void PB_DragEnter(object sender, DragEventArgs e)
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

        private void PB_DragDrop(object sender, DragEventArgs e)
        {
            Camera c = (Camera)(e.Data.GetData(typeof(Camera)));
            if (c != null)
            {
                MessageBox.Show(c.ToString());
                Invalidate();
            }
        }

        private void PB_DragOver(object sender, DragEventArgs e)
        {
             
        }

        public void 单画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("单画面" + GetPictureboxName(sender));

        }

        private string GetPictureboxName(object sender)
        {
            ToolStripMenuItem tsm = sender as ToolStripMenuItem;
            ContextMenuStrip cmsip = tsm.Owner as ContextMenuStrip;
            PictureBox pb = cmsip.SourceControl as PictureBox;
            if (pb != null)
            {
                return pb.Name;
            }
            return "";
        }

        public void Four画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("4画面" + GetPictureboxName(sender));
        }

        public void Nine画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("9画面" + GetPictureboxName(sender));
        }

        public void Sixteen画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("16画面" + GetPictureboxName(sender));
        }
    }
}
