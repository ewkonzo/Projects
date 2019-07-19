using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Coffee
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        public Report(DevExpress.XtraReports.UI.XtraReport f)
        {
            InitializeComponent();

            this.documentViewer1.DocumentSource = f;
        }
    }
}
