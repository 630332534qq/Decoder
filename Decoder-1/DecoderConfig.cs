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

        private void decoderView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decoderView.Rows[e.RowIndex].ErrorText = "";
            // Don't try to validate the 'new row' until finished 
            // editing since there is not any point in validating its initial value.
            if (decoderView.Rows[e.RowIndex].IsNewRow) { return; }
            if (e.ColumnIndex == 1)
            {
                foreach (DataGridViewRow dr in decoderView.Rows)
                {
                    if (e.RowIndex != dr.Index && e.FormattedValue.ToString() == dr.Cells[1].FormattedValue.ToString())
                    {
                        e.Cancel = true;
                        decoderView.Rows[e.RowIndex].ErrorText = "解码器名称重复";
                        return;
                    }
                }
            }
            if (e.ColumnIndex == 2)
            {
                if (!WindowOperation.IPCheck(e.FormattedValue.ToString()))
                {
                    e.Cancel = true;
                    decoderView.Rows[e.RowIndex].ErrorText = "IP地址格式错误";
                    return;
                }
                foreach (DataGridViewRow dr in decoderView.Rows)
                {
                    if (e.RowIndex != dr.Index && e.FormattedValue.ToString() == dr.Cells[2].FormattedValue.ToString())
                    {
                        e.Cancel = true;
                        decoderView.Rows[e.RowIndex].ErrorText = "IP地址重复";
                        return;
                    }
                }
            }

        }

        private void decoderView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow dr in decoderView.Rows)
            {
                dr.Cells[0].Value = dr.Index + 1;
                if (dr.Cells[1].FormattedValue.ToString() == "")
                {
                    dr.ErrorText = "解码器名称不可为空";
                    return;
                }
                if (dr.Cells[2].FormattedValue.ToString() == "")
                {
                    dr.ErrorText = "解码器IP地址不可为空";
                    return;
                }
            }
        }

        private void decoderView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            foreach (DataGridViewRow dr in decoderView.Rows)
            {
                dr.Cells[0].Value = dr.Index + 1;
            }
        }
    }
}
