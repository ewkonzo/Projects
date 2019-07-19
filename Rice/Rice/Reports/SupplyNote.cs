using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
namespace Rice.Reports
{
    public partial class SupplyNote : DevExpress.XtraReports.UI.XtraReport
    {
        public Items_Header ith = null;

        public SupplyNote()
        {
            InitializeComponent();
            
        }

        private void SupplyNote_DataSourceDemanded(object sender, EventArgs e)
        {
           
          bindingSource2.DataSource = new RiceEntities(rice.ConnectionString()).Companies.FirstOrDefault   ();
            bindingSource1.DataSource = ith;
        }

    }
}
