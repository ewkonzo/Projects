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
    public partial class Statusbar : UserControl
    {
        public Statusbar()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

      
        private void txtstatus_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }
        delegate void SetTextCallback(string text);
        public void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            //if (statusStrip1.InvokeRequired)
            //{
            //    SetTextCallback d = new SetTextCallback(SetText);

            //    this.Invoke(d, new object[] { text });
            //}
            //else
            //{
            //    this.txtstatus.Text = text;

            //}
        }

        private void Statusbar_Load(object sender, EventArgs e)
        {
          
        }
    }
}
