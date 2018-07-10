namespace Decoder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new System.Windows.Forms.Button();
            this.decoderView = new System.Windows.Forms.DataGridView();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnResume = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.decoderView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(757, 37);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(43, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // decoderView
            // 
            this.decoderView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.decoderView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.decoderView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmID,
            this.clmName,
            this.clmIP,
            this.clmUserName,
            this.clmPassword,
            this.clmSerialNo});
            this.decoderView.Location = new System.Drawing.Point(12, 82);
            this.decoderView.Name = "decoderView";
            this.decoderView.RowTemplate.Height = 23;
            this.decoderView.Size = new System.Drawing.Size(829, 368);
            this.decoderView.TabIndex = 4;
            this.decoderView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.decoderView_RowsAdded);
            this.decoderView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.decoderView_RowsRemoved);
            this.decoderView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.decoderView_RowValidating);
            this.decoderView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.decoderView_UserDeletingRow);
            // 
            // clmID
            // 
            this.clmID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmID.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmID.HeaderText = "ID";
            this.clmID.Name = "clmID";
            this.clmID.ReadOnly = true;
            // 
            // clmName
            // 
            this.clmName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmName.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmName.HeaderText = "解码器名称";
            this.clmName.Name = "clmName";
            // 
            // clmIP
            // 
            this.clmIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmIP.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmIP.HeaderText = "IP地址";
            this.clmIP.Name = "clmIP";
            // 
            // clmUserName
            // 
            this.clmUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmUserName.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmUserName.HeaderText = "用户名";
            this.clmUserName.Name = "clmUserName";
            // 
            // clmPassword
            // 
            this.clmPassword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmPassword.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmPassword.HeaderText = "密码";
            this.clmPassword.Name = "clmPassword";
            // 
            // clmSerialNo
            // 
            this.clmSerialNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmSerialNo.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmSerialNo.HeaderText = "序列号";
            this.clmSerialNo.Name = "clmSerialNo";
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(699, 37);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(43, 23);
            this.btnResume.TabIndex = 5;
            this.btnResume.Text = "恢复";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(33, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 56);
            this.label1.TabIndex = 6;
            this.label1.Text = "注：\r\n1、两次单击单元格进行编辑；\r\n2、选中该行，按DEL键删除；\r\n3、序列号选填，在生成注册文件时系统自动获取；";
            // 
            // DecoderConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 462);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSerialNo;
    }
}