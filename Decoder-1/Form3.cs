using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Decoder
{
    public partial class Form3 : Form
    {
        public Form3()
        {
           InitializeComponent();
            Init(); 
        }

        private void Init()
        {
            //Panel p = new Panel();
            //p.Location = new Point(100, 100);
            //Button b1 = new Button();
            //b1.Text = "1234567890";
            //Button b2 = new Button();
            //b2.Text = "asdfasdfasdf";
            //p.Controls.Add(b1);
            //p.Controls.Add(b2); 
            //p.PerformLayout();
            //p.Show();
            Basic_UIPanels pb4 = new Basic_UIPanels();
            pb4.Location = new Point(100, 100);
            pb4.Size = new Size(400, 300); 
            //Basic_9PannelButtons pb9 = new Basic_9PannelButtons();
            //pb9.Location = new Point(400, 400);
            //pb9.Size = new Size(300, 300);
            this.Controls.Add(pb4);
            //this.Controls.Add(pb9);
        }

       
    }
}
