using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
namespace Rice.Reports
{
    public partial class Weighslipcustomer : DevExpress.XtraReports.UI.XtraReport
    {
       public  Paddy_Detail p = null;
       public Weighslipcustomer()
        {
            InitializeComponent();
        }

        private void Weighslip_DataSourceDemanded(object sender, EventArgs e)
        {
            bindingSource2.DataSource = new RiceEntities(rice.ConnectionString()).Companies.FirstOrDefault();
            bindingSource1.DataSource = p;
            bindingSource3.DataSource = p.BagsWeighed.ToList();
        }

    }
}
