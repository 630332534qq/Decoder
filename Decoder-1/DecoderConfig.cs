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
    public partial class DecoderConfig : MetroForm
    {
        public DecoderConfig()
        {
            InitializeComponent();
            LoadDecoders();
        }

        private void LoadDecoders()
        {
            decoderView.Rows.Clear();
            List<Decoder> list = FileOperation<Decoder>.ReadFile();
             foreach (Decoder d in list)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(decoderView);
                r.Cells[0].Value = "";
                r.Cells[1].Value = d.name;
                r.Cells[2].Value = d.ipaddr;
                r.Cells[3].Value = d.username;
                r.Cells[4].Value = d.password;
                r.Cells[5].Value = d.serialNo;
                decoderView.Rows.Add(r);
            }
            decoderView.Refresh();
            foreach (DataGridViewRow dr in decoderView.Rows)
            {
                dr.Cells[0].Value = dr.Index + 1;
            }
        }
        private void btnResume_Click(object sender, EventArgs e)
        {
            LoadDecoders();
        }
        private void decoderView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = !WindowOperation.ConfirmDiag("确认要删除该行数据吗？", "删除确认");
        }

        private void decoderView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow dr in decoderView.Rows)
            {
                dr.Cells[0].Value = dr.Index + 1;
            }
        }

        private void decoderView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            foreach (DataGridViewRow dr in decoderView.Rows)
            {
                dr.Cells[0].Value = dr.Index + 1;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Decoder> list = new List<Decoder>();
            foreach (DataGridViewRow dr in decoderView.Rows)
            {
                if (dr.IsNewRow) break;
                Decoder d = new Decoder();
                d.name = dr.Cells[1].Value.ToString();
                d.ipaddr = dr.Cells[2].Value.ToString();
                d.username = dr.Cells[3].Value.ToString();
                d.password = dr.Cells[4].Value.ToString();
                d.serialNo = dr.Cells[5].Value.ToString();
                list.Add(d);
            }
            FileOperation<Decoder>.WriteFile(list);
        }

        /// <summary>
        /// 逻辑要清晰
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void decoderView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow drg = decoderView.Rows[e.RowIndex];
            drg.ErrorText = "";
            if (drg.IsNewRow) return;
            if (drg.Cells[1].FormattedValue.ToString() == "")
            {
                e.Cancel = true;
                drg.ErrorText = "解码器名称不得为空";
                return;
            }
            if (drg.Cells[2].FormattedValue.ToString() == "")
            {
                e.Cancel = true;
                drg.ErrorText = "解码器IP地址不得为空";
                return;
            }
            if (drg.Cells[5].FormattedValue.ToString() == "")
            {
                e.Cancel = true;
                drg.ErrorText = "解码器的序列号不得不为空，可通过在浏览器地址栏输入如下命令查询：\n http://DecoderIP/axis-cgi/admin/param.cgi?action=list&group=root.Properties.System.SerialNumber ";
                return;
            }
            if (!WindowOperation.IPCheck(drg.Cells[2].FormattedValue.ToString()))
            {
                e.Cancel = true;
                drg.ErrorText = "IP地址格式错误";
                return;
            }
            foreach (DataGridViewRow dr in decoderView.Rows)
            {
                if (e.RowIndex != dr.Index && drg.Cells[1].FormattedValue.ToString() == dr.Cells[1].FormattedValue.ToString())
                {
                    e.Cancel = true;
                    drg.ErrorText = "解码器名称重复";
                    return;
                }
                if (e.RowIndex != dr.Index && drg.Cells[2].FormattedValue.ToString() == dr.Cells[2].FormattedValue.ToString())
                {
                    e.Cancel = true;
                    drg.ErrorText = "IP地址重复";
                    return;
                }
                if (e.RowIndex != dr.Index && drg.Cells[5].FormattedValue.ToString() == dr.Cells[5].FormattedValue.ToString())
                {
                    e.Cancel = true;
                    drg.ErrorText = "解码器序列号重复";
                    return;
                }
            }
        }


    }
}
