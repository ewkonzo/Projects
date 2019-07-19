using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
namespace Rice.Reports
{
    public partial class Inputsgrn : DevExpress.XtraReports.UI.XtraReport
    {
        public Item_Movement_Header i = null;
        public Inputsgrn()
        {
            InitializeComponent();
        }

        private void Sales_Receipt_DataSourceDemanded(object sender, EventArgs e)
        {
            using (var db = new RiceEntities(rice.ConnectionString()))
            {
                CompanybindingSource2.DataSource = db.Companies.FirstOrDefault();
                settingbindingSource3.DataSource = db.Settings.FirstOrDefault();
                itemsbindingSource1.DataSource = i;
            }
        }

    }
}
