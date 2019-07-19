using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Coffee.Reports
{
    public partial class Receipt : DevExpress.XtraReports.UI.XtraReport
    {
        Daily_Collections_Detail c = null;
        public Receipt(Daily_Collections_Detail cc)
        {
            InitializeComponent();
            c = cc;
        }
        private void Receipt_DataSourceDemanded(object sender, EventArgs e)
        {
            lsociety.Text = coffee.Factory_Name;
            lfactory.Text =coffee.UppercaseFirst( coffee.setup.Branch.ToLower());
            bindingSource1.DataSource = c;
            xrLabel13.Text = coffee.setup.Motto;
            lblemail.Text = coffee.setup.Email;
        }
    }
}
