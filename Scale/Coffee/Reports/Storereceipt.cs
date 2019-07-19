using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Coffee.Reports
{
    public partial class Storereceipt : DevExpress.XtraReports.UI.XtraReport
    {
        Stores_header sh = null;
        public Storereceipt( Stores_header s)
        {
            InitializeComponent();
            sh = s; 
        }

        private void Storereceipt_DataSourceDemanded(object sender, EventArgs e)
        {
            lsociety.Text = coffee.Factory_Name;
            lfactory.Text = coffee.setup.Branch;
            bindingSource2.DataSource = sh;
        }

    }
}
