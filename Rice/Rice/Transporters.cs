using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rice
{
    public partial class Transporters : Form
    {
      public  Navigation navigation1;
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        public Transporters()
        {
            InitializeComponent();
            navigation1 = new Navigation(transporterBindingSource, transporterGridControl, db);
            this.Controls.Add(navigation1);
            transporterBindingSource.DataSource = db.Transporters.ToList();
        }

        private void transporterGridControl_Click(object sender, EventArgs e)
        {

        }
        public DialogResult ShowDialog(bool list)
        {
            navigation1.selectgroup.Visible = true;

            return base.ShowDialog();


        }
        private void transporterBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Transporter sh = new Transporter();

                e.NewObject = sh;
                db.Transporters.Add(sh);
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }
    }
}
