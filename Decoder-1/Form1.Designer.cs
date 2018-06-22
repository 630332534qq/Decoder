using System;

namespace Decoder_1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.GetParas = new System.Windows.Forms.Button();
            this.rtxReturn = new System.Windows.Forms.RichTextBox();
            this.btn_ChangeCamera = new System.Windows.Forms.Button();
            this.btnChangeView = new System.Windows.Forms.Button();
            this.cbxCameras = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // GetParas
            // 
            this.GetParas.Location = new System.Drawing.Point(13, 13);
            this.GetParas.Name = "GetParas";
            this.GetParas.Size = new System.Drawing.Size(135, 23);
            this.GetParas.TabIndex = 0;
            this.GetParas.Text = "GetParas-UserPass";
            this.GetParas.UseVisualStyleBackColor = true;
            this.GetParas.Click += new System.EventHandler(this.GetParas_Click);
            // 
            // rtxReturn
            // 
            this.rtxReturn.Location = new System.Drawing.Point(13, 151);
            this.rtxReturn.Name = "rtxReturn";
            this.rtxReturn.Size = new System.Drawing.Size(712, 367);
            this.rtxReturn.TabIndex = 1;
            this.rtxReturn.Text = "";
            // 
            // btn_ChangeCamera
            // 
            this.btn_ChangeCamera.Location = new System.Drawing.Point(263, 13);
            this.btn_ChangeCamera.Name = "btn_ChangeCamera";
            this.btn_ChangeCamera.Size = new System.Drawing.Size(196, 23);
            this.btn_ChangeCamera.TabIndex = 2;
            this.btn_ChangeCamera.Text = "PostJson-ChangeCamera";
            this.btn_ChangeCamera.UseVisualStyleBackColor = true;
            this.btn_ChangeCamera.Click += new System.EventHandler(this.btn_ChangeCamera_Click);
            // 
            // btnChangeView
            // 
            this.btnChangeView.Location = new System.Drawing.Point(529, 13);
            this.btnChangeView.Name = "btnChangeView";
            this.btnChangeView.Size = new System.Drawing.Size(196, 23);
            this.btnChangeView.TabIndex = 2;
            this.btnChangeView.Text = "PostJson-ChangeView";
            this.btnChangeView.UseVisualStyleBackColor = true;
            this.btnChangeView.Click += new System.EventHandler(this.btnChangeView_Click);
            // 
            // cbxCameras
            // 
            this.cbxCameras.FormattingEnabled = true;
            this.cbxCameras.Items.AddRange(new object[] {
            "M3045-V",
            "P5635-E",
            "P1365-MKII"});
            this.cbxCameras.Location = new System.Drawing.Point(263, 63);
            this.cbxCameras.Name = "cbxCameras";
            this.cbxCameras.Size = new System.Drawing.Size(196, 20);
            this.cbxCameras.TabIndex = 3;
            this.cbxCameras.SelectedIndexChanged += new System.EventHandler(this.cbxCameras_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 530);
            this.Controls.Add(this.cbxCameras);
            this.Controls.Add(this.btnChangeView);
            this.Controls.Add(this.btn_ChangeCamera);
            this.Controls.Add(this.rtxReturn);
            this.Controls.Add(this.GetParas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        } 
        #endregion

        private System.Windows.Forms.Button GetParas;
        private System.Windows.Forms.RichTextBox rtxReturn;
        private System.Windows.Forms.Button btn_ChangeCamera;
        private System.Windows.Forms.Button btnChangeView;
        private System.Windows.Forms.ComboBox cbxCameras;
    }
}

