using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
namespace Rice.Reports
{
    public partial class Delivery : DevExpress.XtraReports.UI.XtraReport
    {
       public Paddy_Detail p = null;
        public Delivery()
        {
            InitializeComponent();
        }

        private void Delivery_DataSourceDemanded(object sender, EventArgs e)
        {
            bindingSource2.DataSource = new RiceEntities(rice.ConnectionString()).Companies.FirstOrDefault();
            bindingSource1.DataSource = p; 
         
        }

    }
}
