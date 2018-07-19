namespace Decoder
{
    partial class CameraGroup
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
            this.ltbAll = new System.Windows.Forms.ListBox();
            this.ltbSelected = new System.Windows.Forms.ListBox();
            this.btnAdd = new MetroFramework.Controls.MetroButton();
            this.btnRemove = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // ltbAll
            // 
            this.ltbAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ltbAll.FormattingEnabled = true;
            this.ltbAll.ItemHeight = 12;
            this.ltbAll.Location = new System.Drawing.Point(13, 74);
            this.ltbAll.Name = "ltbAll";
            this.ltbAll.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ltbAll.Size = new System.Drawing.Size(158, 520);
            this.ltbAll.TabIndex = 0;
            // 
            // ltbSelected
            // 
            this.ltbSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ltbSelected.FormattingEnabled = true;
            this.ltbSelected.ItemHeight = 12;
            this.ltbSelected.Location = new System.Drawing.Point(368, 74);
            this.ltbSelected.Name = "ltbSelected";
            this.ltbSelected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ltbSelected.Size = new System.Drawing.Size(187, 520);
            this.ltbSelected.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(233, 94);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "->";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(233, 123);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "<-";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(233, 319);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存并返回";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CameraGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 611);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.ltbSelected);
            this.Controls.Add(this.ltbAll);
            this.Name = "CameraGroup";
            this.Text = "自定义摄像机分组";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ltbAll;
        private System.Windows.Forms.ListBox ltbSelected;
        private MetroFramework.Controls.MetroButton btnAdd;
        private MetroFramework.Controls.MetroButton btnRemove;
        private MetroFramework.Controls.MetroButton btnSave;
    }
}