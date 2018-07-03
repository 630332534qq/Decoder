namespace Decoder_1
{
    partial class DecoderConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new System.Windows.Forms.Button();
            this.decoderView = new System.Windows.Forms.DataGridView();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnResume = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.decoderView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(582, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(43, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // decoderView
            // 
            this.decoderView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.decoderView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmID,
            this.clmName,
            this.clmIP,
            this.clmUserName,
            this.clmPassword});
            this.decoderView.Location = new System.Drawing.Point(12, 31);
            this.decoderView.Name = "decoderView";
            this.decoderView.RowTemplate.Height = 23;
            this.decoderView.Size = new System.Drawing.Size(613, 419);
            this.decoderView.TabIndex = 4;
            this.decoderView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.decoderView_RowsAdded);
            this.decoderView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.decoderView_RowsRemoved);
            this.decoderView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.decoderView_RowValidating);
            this.decoderView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.decoderView_UserDeletingRow);
            // 
            // clmID
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmID.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmID.HeaderText = "ID";
            this.clmID.Name = "clmID";
            this.clmID.ReadOnly = true;
            this.clmID.Width = 30;
            // 
            // clmName
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmName.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmName.HeaderText = "解码器名称";
            this.clmName.Name = "clmName";
            this.clmName.Width = 150;
            // 
            // clmIP
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmIP.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmIP.HeaderText = "IP地址";
            this.clmIP.Name = "clmIP";
            this.clmIP.Width = 150;
            // 
            // clmUserName
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmUserName.DefaultCellStyle = dataGridViewCellStyle9;
            this.clmUserName.HeaderText = "用户名";
            this.clmUserName.Name = "clmUserName";
            this.clmUserName.Width = 120;
            // 
            // clmPassword
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmPassword.DefaultCellStyle = dataGridViewCellStyle10;
            this.clmPassword.HeaderText = "密码";
            this.clmPassword.Name = "clmPassword";
            this.clmPassword.Width = 120;
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(533, 2);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(43, 23);
            this.btnResume.TabIndex = 5;
            this.btnResume.Text = "恢复";
            this.btnResume.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(33, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "注：两次单击单元格进行编辑；DEL键删除";
            // 
            // DecoderConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 462);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.decoderView);
            this.Controls.Add(this.btnSave);
            this.Name = "DecoderConfig";
            this.Text = "解码器配置";
            ((System.ComponentModel.ISupportInitialize)(this.decoderView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView decoderView;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPassword;
    }
}