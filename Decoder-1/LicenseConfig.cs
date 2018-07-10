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
    public partial class LicenseConfig : Form
    {
        public LicenseConfig()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DecoderOperation.GetSerialNos(); 
        }
         

        private void GetSeriaNoFromDecoder()
        {
          
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }
    }
}
