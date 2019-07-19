using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Coffee.Reports
{
    public partial class Farmers : DevExpress.XtraReports.UI.XtraReport
    {
        private BindingSource f;
        public Farmers()
        {
            InitializeComponent();
        }
        public Farmers(BindingSource ff)
        {
            InitializeComponent();
            this.f = ff;
        }
        public void loaddata(object o)
        {


        }
        private void Farmers_DataSourceDemanded(object sender, EventArgs e)
        {
            bindingSource1.DataSource = f.DataSource;
            bindingSource1.Filter = f.Filter;
            this.DataSource = bindingSource1.DataSource;
            this.FilterString = bindingSource1.Filter;
        }

    }
}
