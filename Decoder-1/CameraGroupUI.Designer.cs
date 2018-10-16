namespace Decoder
{
    partial class CameraGroupUI
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new MetroFramework.Controls.MetroButton();
            this.ltbAll = new System.Windows.Forms.ListBox();
            this.ltbSelected = new System.Windows.Forms.ListBox();
            this.btnRemove = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.5212F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.84289F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.63591F));
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ltbAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ltbSelected, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRemove, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(802, 531);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnAdd.Location = new System.Drawing.Point(343, 215);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "->";
            this.btnAdd.UseSelectable = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ltbAll
            // 
            this.ltbAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ltbAll.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ltbAll.ItemHeight = 21;
            this.ltbAll.Location = new System.Drawing.Point(27, 3);
            this.ltbAll.Name = "ltbAll";
            this.tableLayoutPanel1.SetRowSpan(this.ltbAll, 4);
            this.ltbAll.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ltbAll.Size = new System.Drawing.Size(278, 508);
            this.ltbAll.Sorted = true;
            this.ltbAll.TabIndex = 4;
            // 
            // ltbSelected
            // 
            this.ltbSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ltbSelected.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ltbSelected.ItemHeight = 21;
            this.ltbSelected.Location = new System.Drawing.Point(479, 3);
            this.ltbSelected.Name = "ltbSelected";
            this.tableLayoutPanel1.SetRowSpan(this.ltbSelected, 4);
            this.ltbSelected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ltbSelected.Size = new System.Drawing.Size(278, 508);
            this.ltbSelected.Sorted = true;
            this.ltbSelected.TabIndex = 3;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemove.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnRemove.Location = new System.Drawing.Point(343, 183);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(82, 26);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "<-";
            this.btnRemove.UseSelectable = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSave.Location = new System.Drawing.Point(337, 268);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存并返回";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CameraGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 611);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CameraGroup";
            this.Text = "自定义摄像机分组";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton btnAdd;
        private System.Windows.Forms.ListBox ltbAll;
        private System.Windows.Forms.ListBox ltbSelected;
        private MetroFramework.Controls.MetroButton btnRemove;
        private MetroFramework.Controls.MetroButton btnSave;
    }
}