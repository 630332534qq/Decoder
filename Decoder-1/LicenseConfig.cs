using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Decoder
{
    public partial class LicenseConfig : Form
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LicenseConfig()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DecoderOperation.GetSerialNos();
        } 
        private void btnImport_Click(object sender, EventArgs e)
        {
            verify();
        }

        public bool verify()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string publickey = config.AppSettings.Settings["PublicKey"].Value;
            try
            {
                RSACryptoServiceProvider cryptor = new RSACryptoServiceProvider();
                cryptor.FromXmlString(publickey);
                string regdata = LicenseFile.ReadRegFile();
                byte[] signedData = Convert.FromBase64String(LicenseFile.ReadLicense());
                bool forever = cryptor.VerifyData(Encoding.UTF8.GetBytes(String.Format("[{0}][{1}]", regdata, DateTime.MaxValue)), "SHA1", signedData);
                return forever;
            }
            catch (Exception ex)
            {
                log.Error("注册验证出错，请查看" + ex.Message.ToString());
                return false;
            }
        }
    }
}
