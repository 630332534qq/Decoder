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
    public partial class Basic_4PannelButtons : UserControl
    {
        public Basic_4PannelButtons()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            foreach (Control btn in tableLayoutPanel1.Controls)
            {
                btn.AllowDrop = true;
                btn.DragEnter += Btn_DragEnter;
            }
        }

        private void Btn_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        public void Basic_4PannelButtons_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        public void 单画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("单画面");
        }

        public void Four画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("4画面");
        }

        public void Nine画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("9画面");
        }

        public void Sixteen画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("16画面");
        }

        public void button1_DragDrop(object sender, DragEventArgs e)
        {
            Btn_DragDrop(sender, e);
        }

        public void Btn_DragDrop(object sender, DragEventArgs e)
        {
            //Button btn = sender as Button;
            //if (btn != null)
            //{
            //    MessageBox.Show("定位于" + btn.Name + ",坐标X是" + e.X.ToString() + ",坐标Y是" + e.Y.ToString());
            //}
            Array file = (System.Array)e.Data.GetData(DataFormats.FileDrop);
            string fileText = null;
            foreach (object I in file)
            {
                fileText += I.ToString();
                fileText += "\n";
            }
            button1.Text = fileText;
        }
    }
}


