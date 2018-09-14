using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
namespace Decoder
{
    public partial class CameraGroupUI : MetroForm
    {
        //子窗口以委托形式调用父窗口，实现刷新
        public delegate void ReturnValue();
        public event ReturnValue returnParent;
        TreeNode tnGroup = null;
        TreeView tvAll = null;
        public CameraGroupUI(TreeView tv, TreeNode _tnGroup)
        {
            InitializeComponent();
            tnGroup = _tnGroup;
            tvAll = tv;
            foreach (TreeNode tn in tv.Nodes[0].Nodes)
            {
                if (tn.Name == NodeType.Camera.ToString())
                    ltbAll.Items.Add(item: tn.Text);
            }

            foreach (TreeNode tnn in tnGroup.Nodes)
            {
                ltbSelected.Items.Add(item: tnn.Text);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TreeNode toBeAddtoGroup;
            tnGroup.Nodes.Clear();
            foreach (TreeNode tn in tvAll.Nodes[0].Nodes)
            {
                if (tn.Name == NodeType.Camera.ToString())
                {
                    foreach (string sc in ltbSelected.Items)
                    {
                        if (sc == tn.Text&&tn.Name==NodeType.Camera.ToString())
                        {
                            //将摄像机增加到分组，此时该摄像机类型为CameraAtGroup
                            toBeAddtoGroup = tn.Clone() as TreeNode;
                            toBeAddtoGroup.Name = NodeType.CameraAtGroup.ToString();
                            toBeAddtoGroup.ForeColor = Color.Brown;
                            tnGroup.Nodes.Add(toBeAddtoGroup);
                        }
                    }
                }
            }
            this.Close();
            returnParent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ltbAll.SelectedItem == null)
            {
                MessageBox.Show("请先选中待加入的摄像机");
                return;
            }
            foreach (string sc in ltbAll.SelectedItems)
            {
                if (!ltbSelected.Items.Contains(sc))
                    ltbSelected.Items.Add(sc);
            }
            ltbSelected.ClearSelected();
        }

        /// <summary>
        /// 从前往后删除，每删除后索引会变化；因此需要从后往前删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (ltbSelected.SelectedItem == null)
            {
                MessageBox.Show("请先选中待删除的摄像机");
                return;
            }
            for (int i = ltbSelected.Items.Count - 1; i >= 0; i--)
            {
                ltbSelected.Items.Remove(ltbSelected.SelectedItem);
            }
        }
    }
}
