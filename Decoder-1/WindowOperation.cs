using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Decoder
{
   public static class WindowOperation
    {
        public static bool ConfirmDiag(string question, string title)
        {
            DialogResult dr = MessageBox.Show(question, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IPCheck(string IP)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(IP, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
    }
}
