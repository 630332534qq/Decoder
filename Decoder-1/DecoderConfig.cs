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
    public partial class DecoderConfig : Form
    {
        public DecoderConfig()
        {
            InitializeComponent();
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
            }
        }
    }
}
