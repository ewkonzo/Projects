using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using System.Linq;
namespace Rice.Reports.Pos
{
    public partial class Sales : DevExpress.XtraReports.UI.XtraReport
    {
       public BindingSource items = null;
        public Sales()
        {
            InitializeComponent();
           
        }

        private void Sales_DataSourceDemanded(object sender, EventArgs e)
        {
            bindingSource3.DataSource = items.DataSource;
            bindingSource3.Filter = items.Filter;
            this.DataSource = bindingSource3.DataSource;
            this.FilterString = bindingSource3.Filter;
        }
        

    }
}
