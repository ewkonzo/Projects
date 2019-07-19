using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Coffee.Reports
{
    public partial class Collections : DevExpress.XtraReports.UI.XtraReport
    {
        private BindingSource f;
        public Collections()
        {
            InitializeComponent();
        }
        public Collections(BindingSource ff)
        {
            InitializeComponent();
            this.f = ff;
        }
        private void Collections_DataSourceDemanded(object sender, EventArgs e)
        {

            bindingSource1.DataSource = f.DataSource;
            bindingSource1.Filter = f.Filter;
            this.DataSource = bindingSource1.DataSource;
            this.FilterString = bindingSource1.Filter;
            criteria.Text = bindingSource1.Filter;
        }

    }
}
