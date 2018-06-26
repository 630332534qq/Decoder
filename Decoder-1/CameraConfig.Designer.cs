namespace Decoder_1
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("M3005-V");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("P1365-E");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("P5635-E");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("摄像机树", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddCamera = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCName = new System.Windows.Forms.Label();
            this.tvCameras = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.CMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnAddCamera);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblCName);
            this.panel1.Controls.Add(this.tvCameras);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 410);
            this.panel1.TabIndex = 0;
            // 
            // btnAddCamera
            // 
            this.btnAddCamera.Location = new System.Drawing.Point(267, 111);
            this.btnAddCamera.Name = "btnAddCamera";
            this.btnAddCamera.Size = new System.Drawing.Size(75, 23);
            this.btnAddCamera.TabIndex = 2;
            this.btnAddCamera.Text = "添加";
            this.btnAddCamera.UseVisualStyleBackColor = true;
            this.btnAddCamera.Click += new System.EventHandler(this.btnAddCamera_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "摄像机IP：";
            // 
            // lblCName
            // 
            this.lblCName.AutoSize = true;
            this.lblCName.Location = new System.Drawing.Point(209, 42);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(77, 12);
            this.lblCName.TabIndex = 1;
            this.lblCName.Text = "摄像机名称：";
            // 
            // tvCameras
            // 
            this.tvCameras.Location = new System.Drawing.Point(4, 4);
            this.tvCameras.Name = "tvCameras";
            treeNode1.Name = "节点1";
            treeNode1.Text = "M3005-V";
            treeNode2.Name = "节点3";
            treeNode2.Text = "P1365-E";
            treeNode3.Name = "节点6";
            treeNode3.Text = "P5635-E";
            treeNode4.Name = "节点0";
            treeNode4.Text = "摄像机树";
            this.tvCameras.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.tvCameras.Size = new System.Drawing.Size(180, 400);
            this.tvCameras.TabIndex = 0;
            this.tvCameras.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvCameras_MouseDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(293, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(293, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 4;
            // 
            // CMS
            // 
            this.CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.上移ToolStripMenuItem,
            this.下移ToolStripMenuItem});
            this.CMS.Name = "CMS";
            this.CMS.Size = new System.Drawing.Size(101, 70);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
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
            // CameraConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(469, 435);
            this.Controls.Add(this.panel1);
            this.Name = "CameraConfig";
            this.Text = "摄像机配置";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddCamera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCName;
        private System.Windows.Forms.TreeView tvCameras;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上移ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下移ToolStripMenuItem;
    }
}