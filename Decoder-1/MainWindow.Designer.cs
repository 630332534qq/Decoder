namespace Decoder
{
    partial class MainWindow
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TVCamera = new System.Windows.Forms.TreeView();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.摄像机配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解码器配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.许可证配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.布局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载布局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除布局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建新布局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mST = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mST.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 29);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TVCamera);
            this.splitContainer1.Size = new System.Drawing.Size(760, 510);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 1;
            // 
            // TVCamera
            // 
            this.TVCamera.Location = new System.Drawing.Point(16, 13);
            this.TVCamera.Name = "TVCamera";
            this.TVCamera.Size = new System.Drawing.Size(211, 480);
            this.TVCamera.TabIndex = 0;
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录ToolStripMenuItem,
            this.注销ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 登录ToolStripMenuItem
            // 
            this.登录ToolStripMenuItem.Name = "登录ToolStripMenuItem";
            this.登录ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.登录ToolStripMenuItem.Text = "登录";
            // 
            // 注销ToolStripMenuItem
            // 
            this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
            this.注销ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.注销ToolStripMenuItem.Text = "注销";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户配置ToolStripMenuItem,
            this.摄像机配置ToolStripMenuItem,
            this.解码器配置ToolStripMenuItem,
            this.许可证配置ToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.配置ToolStripMenuItem.Text = "配置";
            // 
            // 用户配置ToolStripMenuItem
            // 
            this.用户配置ToolStripMenuItem.Name = "用户配置ToolStripMenuItem";
            this.用户配置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.用户配置ToolStripMenuItem.Text = "用户配置";
            // 
            // 摄像机配置ToolStripMenuItem
            // 
            this.摄像机配置ToolStripMenuItem.Name = "摄像机配置ToolStripMenuItem";
            this.摄像机配置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.摄像机配置ToolStripMenuItem.Text = "摄像机配置";
            this.摄像机配置ToolStripMenuItem.Click += new System.EventHandler(this.摄像机配置ToolStripMenuItem_Click);
            // 
            // 解码器配置ToolStripMenuItem
            // 
            this.解码器配置ToolStripMenuItem.Name = "解码器配置ToolStripMenuItem";
            this.解码器配置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.解码器配置ToolStripMenuItem.Text = "解码器配置";
            this.解码器配置ToolStripMenuItem.Click += new System.EventHandler(this.解码器配置ToolStripMenuItem_Click);
            // 
            // 许可证配置ToolStripMenuItem
            // 
            this.许可证配置ToolStripMenuItem.Name = "许可证配置ToolStripMenuItem";
            this.许可证配置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.许可证配置ToolStripMenuItem.Text = "许可证配置";
            // 
            // 布局ToolStripMenuItem
            // 
            this.布局ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载布局ToolStripMenuItem,
            this.删除布局ToolStripMenuItem,
            this.创建新布局ToolStripMenuItem});
            this.布局ToolStripMenuItem.Name = "布局ToolStripMenuItem";
            this.布局ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.布局ToolStripMenuItem.Text = "布局";
            // 
            // 加载布局ToolStripMenuItem
            // 
            this.加载布局ToolStripMenuItem.Name = "加载布局ToolStripMenuItem";
            this.加载布局ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.加载布局ToolStripMenuItem.Text = "加载布局";
            // 
            // 删除布局ToolStripMenuItem
            // 
            this.删除布局ToolStripMenuItem.Name = "删除布局ToolStripMenuItem";
            this.删除布局ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除布局ToolStripMenuItem.Text = "删除布局";
            // 
            // 创建新布局ToolStripMenuItem
            // 
            this.创建新布局ToolStripMenuItem.Name = "创建新布局ToolStripMenuItem";
            this.创建新布局ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.创建新布局ToolStripMenuItem.Text = "创建新布局";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem1,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.帮助ToolStripMenuItem1.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // mST
            // 
            this.mST.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.配置ToolStripMenuItem,
            this.布局ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.mST.Location = new System.Drawing.Point(0, 0);
            this.mST.Name = "mST";
            this.mST.Size = new System.Drawing.Size(784, 25);
            this.mST.TabIndex = 3;
            this.mST.Text = "主菜单";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 682);
            this.Controls.Add(this.mST);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.mST;
            this.Name = "MainWindow";
            this.Text = "解码器控制";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.mST.ResumeLayout(false);
            this.mST.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView TVCamera;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 摄像机配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 解码器配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 许可证配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 布局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载布局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除布局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建新布局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mST;
    }
}