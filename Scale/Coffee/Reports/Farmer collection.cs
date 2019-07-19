using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Coffee.Reports
{
    public partial class Farmer_collection : DevExpress.XtraReports.UI.XtraReport
    {
        Farmer f = null;
        public Farmer_collection(Farmer ff)
        {
            InitializeComponent();
            f = ff;
           
        }

        private void Farmer_collection_DataSourceDemanded(object sender, EventArgs e)
        {
            lsociety.Text = coffee.Factory_Name;
            lfactory.Text = coffee.setup.Branch;
            
            bindingSource2.DataSource = f;
          
        }

    }
}
