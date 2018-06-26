using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Decoder_1
{
    public partial class CameraConfig : Form
    {
        public CameraConfig()
        {
            InitializeComponent();
            InitializeCameraTree();
        }

        private void InitializeCameraTree()
        {
            for (int i = 0; i < tvCameras.Nodes[0].GetNodeCount(true); i++)
            {
                tvCameras.Nodes[0].Nodes[i].ContextMenuStrip = CMS;
            }

        }

        private void btnAddCamera_Click(object sender, EventArgs e)
        {

        }

        private void tvCameras_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{ CMS.Show(e.X,e.Y); }
        }
    }
}
