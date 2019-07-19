using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
namespace Rice.Reports
{
    public partial class Sales_Receipt : DevExpress.XtraReports.UI.XtraReport
    {
        public Items_Header i = null;
        public Sales_Receipt()
        {
            InitializeComponent();
        }

        private void Sales_Receipt_DataSourceDemanded(object sender, EventArgs e)
        {
            CompanybindingSource2.DataSource = new RiceEntities(rice.ConnectionString()).Companies.FirstOrDefault();
            settingbindingSource3.DataSource = new RiceEntities(rice.ConnectionString()).Settings.FirstOrDefault();
            itemsbindingSource1.DataSource = i;
        }

    }
}
