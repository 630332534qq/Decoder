namespace Decoder
{
    partial class CameraConfig
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
            this.components = new System.ComponentModel.Container();
            this.CameraNodeStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.上移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.FNodeStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMUAddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupNodeStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteGroupNode = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCameraToGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReset = new MetroFramework.Controls.MetroButton();
            this.tvCameras = new System.Windows.Forms.TreeView();
            this.lblCName = new MetroFramework.Controls.MetroLabel();
            this.lblCIP = new MetroFramework.Controls.MetroLabel();
            this.btnAddCamera = new MetroFramework.Controls.MetroButton();
            this.lblUsername = new MetroFramework.Controls.MetroLabel();
            this.txtCameraName = new MetroFramework.Controls.MetroTextBox();
            this.lblPassword = new MetroFramework.Controls.MetroLabel();
            this.txtIPAddress = new MetroFramework.Controls.MetroTextBox();
            this.txtUsername = new MetroFramework.Controls.MetroTextBox();
            this.txtPasssword = new MetroFramework.Controls.MetroTextBox();
            this.txtHelp = new MetroFramework.Controls.MetroTextBox();
            this.gpBHelp = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CameraNodeStrip.SuspendLayout();
            this.FNodeStrip.SuspendLayout();
            this.GroupNodeStrip.SuspendLayout();
            this.gpBHelp.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CameraNodeStrip
            // 
            this.CameraNodeStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteCamera,
            this.上移ToolStripMenuItem,
            this.下移ToolStripMenuItem});
            this.CameraNodeStrip.Name = "CMS";
            this.CameraNodeStrip.Size = new System.Drawing.Size(101, 70);
            // 
            // deleteCamera
            // 
            this.deleteCamera.Name = "deleteCamera";
            this.deleteCamera.Size = new System.Drawing.Size(100, 22);
            this.deleteCamera.Text = "删除";
            this.deleteCamera.Click += new System.EventHandler(this.deleteCamera_Click);
            // 
            // 上移ToolStripMenuItem
            // 
            this.上移ToolStripMenuItem.Name = "上移ToolStripMenuItem";
            this.上移ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.上移ToolStripMenuItem.Text = "上移";
            // 
            // 下移ToolStripMenuItem
            // 
            this.下移ToolStripMenuItem.Name = "下移ToolStripMenuItem";
            this.下移ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.下移ToolStripMenuItem.Text = "下移";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(531, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存更改";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FNodeStrip
            // 
            this.FNodeStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMUAddGroup});
            this.FNodeStrip.Name = "FNodeStrip";
            this.FNodeStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // tsMUAddGroup
            // 
            this.tsMUAddGroup.Name = "tsMUAddGroup";
            this.tsMUAddGroup.Size = new System.Drawing.Size(124, 22);
            this.tsMUAddGroup.Text = "新建分组";
            this.tsMUAddGroup.Click += new System.EventHandler(this.AddGroupNode_Click);
            // 
            // GroupNodeStrip
            // 
            this.GroupNodeStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteGroupNode,
            this.AddCameraToGroup});
            this.GroupNodeStrip.Name = "GroupNodeStrip";
            this.GroupNodeStrip.Size = new System.Drawing.Size(137, 48);
            // 
            // deleteGroupNode
            // 
            this.deleteGroupNode.Name = "deleteGroupNode";
            this.deleteGroupNode.Size = new System.Drawing.Size(136, 22);
            this.deleteGroupNode.Text = "删除该分组";
            this.deleteGroupNode.Click += new System.EventHandler(this.deleteGroupNode_Click);
            // 
            // AddCameraToGroup
            // 
            this.AddCameraToGroup.Name = "AddCameraToGroup";
            this.AddCameraToGroup.Size = new System.Drawing.Size(136, 22);
            this.AddCameraToGroup.Text = "添加摄像机";
            this.AddCameraToGroup.Click += new System.EventHandler(this.AddCameraToGroup_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(450, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "恢复";
            this.btnReset.UseSelectable = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tvCameras
            // 
            this.tvCameras.AllowDrop = true;
            this.tvCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCameras.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvCameras.HideSelection = false;
            this.tvCameras.Indent = 19;
            this.tvCameras.ItemHeight = 22;
            this.tvCameras.LabelEdit = true;
            this.tvCameras.Location = new System.Drawing.Point(3, 33);
            this.tvCameras.Name = "tvCameras";
            this.tableLayoutPanel1.SetRowSpan(this.tvCameras, 9);
            this.tvCameras.ShowNodeToolTips = true;
            this.tvCameras.Size = new System.Drawing.Size(208, 346);
            this.tvCameras.TabIndex = 12;
            // 
            // lblCName
            // 
            this.lblCName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCName.AutoSize = true;
            this.lblCName.Location = new System.Drawing.Point(275, 30);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(93, 19);
            this.lblCName.TabIndex = 25;
            this.lblCName.Text = "摄像机名称：";
            // 
            // lblCIP
            // 
            this.lblCIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCIP.AutoSize = true;
            this.lblCIP.Location = new System.Drawing.Point(292, 60);
            this.lblCIP.Name = "lblCIP";
            this.lblCIP.Size = new System.Drawing.Size(76, 19);
            this.lblCIP.TabIndex = 24;
            this.lblCIP.Text = "摄像机IP：";
            // 
            // btnAddCamera
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnAddCamera, 2);
            this.btnAddCamera.Location = new System.Drawing.Point(374, 153);
            this.btnAddCamera.Name = "btnAddCamera";
            this.btnAddCamera.Size = new System.Drawing.Size(125, 23);
            this.btnAddCamera.TabIndex = 30;
            this.btnAddCamera.Text = "添加";
            this.btnAddCamera.UseSelectable = true;
            this.btnAddCamera.Click += new System.EventHandler(this.btnAddCamera_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(261, 90);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(107, 19);
            this.lblUsername.TabIndex = 23;
            this.lblUsername.Text = "摄像机用户名：";
            // 
            // txtCameraName
            // 
            // 
            // 
            // 
            this.txtCameraName.CustomButton.Image = null;
            this.txtCameraName.CustomButton.Location = new System.Drawing.Point(131, 1);
            this.txtCameraName.CustomButton.Name = "";
            this.txtCameraName.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtCameraName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCameraName.CustomButton.TabIndex = 1;
            this.txtCameraName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCameraName.CustomButton.UseSelectable = true;
            this.txtCameraName.CustomButton.Visible = false;
            this.txtCameraName.Lines = new string[0];
            this.txtCameraName.Location = new System.Drawing.Point(374, 33);
            this.txtCameraName.MaxLength = 32767;
            this.txtCameraName.Name = "txtCameraName";
            this.txtCameraName.PasswordChar = '\0';
            this.txtCameraName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCameraName.SelectedText = "";
            this.txtCameraName.SelectionLength = 0;
            this.txtCameraName.SelectionStart = 0;
            this.txtCameraName.ShortcutsEnabled = true;
            this.txtCameraName.Size = new System.Drawing.Size(151, 21);
            this.txtCameraName.TabIndex = 26;
            this.txtCameraName.UseSelectable = true;
            this.txtCameraName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCameraName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(275, 120);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(93, 19);
            this.lblPassword.TabIndex = 22;
            this.lblPassword.Text = "摄像机密码：";
            // 
            // txtIPAddress
            // 
            // 
            // 
            // 
            this.txtIPAddress.CustomButton.Image = null;
            this.txtIPAddress.CustomButton.Location = new System.Drawing.Point(131, 1);
            this.txtIPAddress.CustomButton.Name = "";
            this.txtIPAddress.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtIPAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtIPAddress.CustomButton.TabIndex = 1;
            this.txtIPAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtIPAddress.CustomButton.UseSelectable = true;
            this.txtIPAddress.CustomButton.Visible = false;
            this.txtIPAddress.Lines = new string[0];
            this.txtIPAddress.Location = new System.Drawing.Point(374, 63);
            this.txtIPAddress.MaxLength = 32767;
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.PasswordChar = '\0';
            this.txtIPAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIPAddress.SelectedText = "";
            this.txtIPAddress.SelectionLength = 0;
            this.txtIPAddress.SelectionStart = 0;
            this.txtIPAddress.ShortcutsEnabled = true;
            this.txtIPAddress.Size = new System.Drawing.Size(151, 21);
            this.txtIPAddress.TabIndex = 27;
            this.txtIPAddress.UseSelectable = true;
            this.txtIPAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtIPAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtUsername
            // 
            // 
            // 
            // 
            this.txtUsername.CustomButton.Image = null;
            this.txtUsername.CustomButton.Location = new System.Drawing.Point(131, 1);
            this.txtUsername.CustomButton.Name = "";
            this.txtUsername.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsername.CustomButton.TabIndex = 1;
            this.txtUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsername.CustomButton.UseSelectable = true;
            this.txtUsername.CustomButton.Visible = false;
            this.txtUsername.Lines = new string[0];
            this.txtUsername.Location = new System.Drawing.Point(374, 93);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.ShortcutsEnabled = true;
            this.txtUsername.Size = new System.Drawing.Size(151, 21);
            this.txtUsername.TabIndex = 28;
            this.txtUsername.UseSelectable = true;
            this.txtUsername.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsername.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPasssword
            // 
            // 
            // 
            // 
            this.txtPasssword.CustomButton.Image = null;
            this.txtPasssword.CustomButton.Location = new System.Drawing.Point(131, 1);
            this.txtPasssword.CustomButton.Name = "";
            this.txtPasssword.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtPasssword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPasssword.CustomButton.TabIndex = 1;
            this.txtPasssword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPasssword.CustomButton.UseSelectable = true;
            this.txtPasssword.CustomButton.Visible = false;
            this.txtPasssword.Lines = new string[0];
            this.txtPasssword.Location = new System.Drawing.Point(374, 123);
            this.txtPasssword.MaxLength = 32767;
            this.txtPasssword.Name = "txtPasssword";
            this.txtPasssword.PasswordChar = '\0';
            this.txtPasssword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPasssword.SelectedText = "";
            this.txtPasssword.SelectionLength = 0;
            this.txtPasssword.SelectionStart = 0;
            this.txtPasssword.ShortcutsEnabled = true;
            this.txtPasssword.Size = new System.Drawing.Size(151, 21);
            this.txtPasssword.TabIndex = 29;
            this.txtPasssword.UseSelectable = true;
            this.txtPasssword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPasssword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtHelp
            // 
            // 
            // 
            // 
            this.txtHelp.CustomButton.Image = null;
            this.txtHelp.CustomButton.Location = new System.Drawing.Point(165, 2);
            this.txtHelp.CustomButton.Name = "";
            this.txtHelp.CustomButton.Size = new System.Drawing.Size(69, 69);
            this.txtHelp.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtHelp.CustomButton.TabIndex = 1;
            this.txtHelp.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtHelp.CustomButton.UseSelectable = true;
            this.txtHelp.CustomButton.Visible = false;
            this.txtHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHelp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtHelp.Lines = new string[] {
        "1、用户名密码可留空，默认为root/pass",
        "2、摄像机名称和IP地址不可重复；",
        "3、可在根节点右键自定义分组，并将其他节点拖到该分组用于轮播"};
            this.txtHelp.Location = new System.Drawing.Point(3, 17);
            this.txtHelp.MaxLength = 32767;
            this.txtHelp.Multiline = true;
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.PasswordChar = '\0';
            this.txtHelp.ReadOnly = true;
            this.txtHelp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHelp.SelectedText = "";
            this.txtHelp.SelectionLength = 0;
            this.txtHelp.SelectionStart = 0;
            this.txtHelp.ShortcutsEnabled = true;
            this.txtHelp.Size = new System.Drawing.Size(394, 74);
            this.txtHelp.TabIndex = 12;
            this.txtHelp.Text = "1、用户名密码可留空，默认为root/pass\r\n2、摄像机名称和IP地址不可重复；\r\n3、可在根节点右键自定义分组，并将其他节点拖到该分组用于轮播";
            this.txtHelp.UseSelectable = true;
            this.txtHelp.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtHelp.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // gpBHelp
            // 
            this.gpBHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.gpBHelp, 3);
            this.gpBHelp.Controls.Add(this.txtHelp);
            this.gpBHelp.Location = new System.Drawing.Point(217, 183);
            this.gpBHelp.Name = "gpBHelp";
            this.tableLayoutPanel1.SetRowSpan(this.gpBHelp, 2);
            this.gpBHelp.Size = new System.Drawing.Size(400, 94);
            this.gpBHelp.TabIndex = 31;
            this.gpBHelp.TabStop = false;
            this.gpBHelp.Text = "说明：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.Controls.Add(this.tvCameras, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPassword, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPasssword, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblUsername, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUsername, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCameraName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCIP, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.gpBHelp, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnAddCamera, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtIPAddress, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnReset, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(714, 382);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // CameraConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CameraConfig";
            this.Text = "摄像机配置";
            this.CameraNodeStrip.ResumeLayout(false);
            this.FNodeStrip.ResumeLayout(false);
            this.GroupNodeStrip.ResumeLayout(false);
            this.gpBHelp.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip CameraNodeStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteCamera;
        private System.Windows.Forms.ToolStripMenuItem 上移ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下移ToolStripMenuItem;
        private MetroFramework.Controls.MetroButton btnSave;
        private System.Windows.Forms.ContextMenuStrip FNodeStrip;
        private System.Windows.Forms.ToolStripMenuItem tsMUAddGroup;
        private System.Windows.Forms.ContextMenuStrip GroupNodeStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteGroupNode;
        private System.Windows.Forms.ToolStripMenuItem AddCameraToGroup;
        private MetroFramework.Controls.MetroButton btnReset;
        private System.Windows.Forms.TreeView tvCameras;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroLabel lblPassword;
        private MetroFramework.Controls.MetroTextBox txtPasssword;
        private MetroFramework.Controls.MetroButton btnAddCamera;
        private MetroFramework.Controls.MetroLabel lblUsername;
        private MetroFramework.Controls.MetroTextBox txtUsername;
        private MetroFramework.Controls.MetroTextBox txtCameraName;
        private MetroFramework.Controls.MetroTextBox txtIPAddress;
        private MetroFramework.Controls.MetroLabel lblCName;
        private MetroFramework.Controls.MetroLabel lblCIP;
        private System.Windows.Forms.GroupBox gpBHelp;
        private MetroFramework.Controls.MetroTextBox txtHelp;
    }
}