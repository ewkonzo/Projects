using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Coffee
{
    public partial class CollectEntries : Form
    {
        AutoweighEntities db = new AutoweighEntities(coffee.ConnectionString());
        public CollectEntries(Daily_Collections_Detail d )
        {
            InitializeComponent();
            farmerBindingSource.DataSource = db.Farmers.ToList();
            daily_Collections_DetailBindingSource.DataSource = d;
        }
        private void btnok_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (farmerlookup.EditValue != null)
                if (daily_Collections_DetailBindingSource.Current != null)
                {
                    var f = db.Farmers.FirstOrDefault(o => o.No == farmerlookup.EditValue);
                    if (f != null)
                    {
                        var d = (Daily_Collections_Detail)daily_Collections_DetailBindingSource.Current;
                        DialogResult corr =
                            MessageBox.Show(String.Format("Are you sure you want to move {0} Kgs from {1}({2}) to {3}({4})", d.Kg__Collected, d.Farmers_Name, d.Farmers_Number, f.Name, f.No), "Correct Collections", MessageBoxButtons.YesNo);
                        if (corr == DialogResult.Yes)
                        {
                            using (var form = new Authorize())
                            {
                                DialogResult a = form.ShowDialog();
                                if (a == System.Windows.Forms.DialogResult.OK)
                                {
                                    if (form.authorized)
                                    {
                                        var c = d;
                                        c.Collection_Number = c.Collection_Number + "-1";
                                        c.User = form.user.Name;
                                        c.Collection_time = DateTime.Now;
                                        c.Cancelled = "Yes";
                                        db.Daily_Collections_Details.Add(c);
                                        db.SaveChanges();
                                        var cn = string.Format("{0}{1}", f.No, DateTime.Now.ToString("yyMMddmmss"));

                                        var nc = d;
                                        nc.Farmers_Number = f.No;
                                        nc.Farmers_Name = f.Name;
                                        nc.Cancelled = "No";
                                        nc.Collection_time = DateTime.Now;
                                        nc.Collection_Number = cn;
                                        db.Daily_Collections_Details.Add(nc);
                                        db.SaveChanges();
                                        d.Cancelled = "Yes";
                                        db.SaveChanges();
                                        this.Close();
                                    }
                                   }
                            }
                        }
                    }
                    else
                        new ErrorProvider().SetError(farmerlookup, "Farmer Number not Found");
                }
                else
                {
                    new ErrorProvider().SetError(farmerlookup, "Please select farmer");
                }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
