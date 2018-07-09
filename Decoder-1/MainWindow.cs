using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Decoder
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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
    }
}
