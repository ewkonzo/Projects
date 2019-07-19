using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
namespace Rice.Reports
{
    public partial class Header : DevExpress.XtraReports.UI.XtraReport
    {
       public static Company c = null;
       public Header()
        {
            InitializeComponent();

            //bindingSource2.DataSource = new RiceEntities(rice.ConnectionString()).Companies.FirstOrDefault();
        }

        private void Delivery_DataSourceDemanded(object sender, EventArgs e)
        {
            
            bindingSource2.DataSource = c;
           
        }

    }
}
