using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rice
{
    public partial class Report_Preview : DevExpress.XtraEditors.XtraForm
    {
        public Report_Preview()
        {
            InitializeComponent();
        }

        private void documentViewer1_DocumentChanged(object sender, EventArgs e)
        {
            
        }
    }
}
