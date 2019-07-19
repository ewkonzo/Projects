using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
namespace Coffee.Reports
{
    public partial class Daily_summary : DevExpress.XtraReports.UI.XtraReport
    {
        public Daily_summary()
        {
            InitializeComponent();
        }

        private void Daily_summary_DataSourceDemanded(object sender, EventArgs e)
        {
            lsociety.Text = coffee.Factory_Name;
            lfactory.Text = coffee.setup.Branch;
            this.DataSource = new AutoweighEntities(coffee.ConnectionString()).Daily_Collections_Details.ToList();
        }

    }
}
