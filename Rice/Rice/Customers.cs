using DevExpress.XtraBars.Ribbon;
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
    public partial class Customers : Form
    {
      
        RiceEntities db = new RiceEntities(rice.ConnectionString());
      public  Navigation navigation1;
     
        public Customers()
        {
            InitializeComponent();
            navigation1 = new Navigation(customerBindingSource, customerGridControl, db);
            this.Controls.Add(navigation1);
           
            customerBindingSource.DataSource = db.Customers.ToList();
        }
        private void customerBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Customer sh = new Customer();
                e.NewObject = sh;
                db.Customers.Add(sh);
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void customerGridControl_Click(object sender, EventArgs e)
        {
         
        }
        private void customerGridControl_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }
        public DialogResult ShowDialog(bool list)
        {
            navigation1.selectgroup.Visible = true;
            return base.ShowDialog();


        }
      
    }
}
