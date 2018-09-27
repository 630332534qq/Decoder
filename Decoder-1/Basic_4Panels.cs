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
