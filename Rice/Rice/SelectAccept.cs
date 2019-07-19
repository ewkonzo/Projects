using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rice
{
    public partial class SelectAccept : UserControl
    {
        public SelectAccept()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ((Form)this.Parent).Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
           
        }
    }
}
