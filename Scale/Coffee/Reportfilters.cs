using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Collections.Generic;
using System.Data.Entity;
namespace Coffee
{
    public partial class Reportfilters : Form
    {
        DevExpress.XtraReports.UI.XtraReport x;
        object Data;
        object f;
        BindingSource bs= new BindingSource();
        public Reportfilters()
        {
            InitializeComponent();
        }
        public Reportfilters(Type data)
        {
            InitializeComponent();
            Data = data;
            if (data == typeof(Farmer))
            {
                using (var db = new AutoweighEntities(coffee.ConnectionString()))
                {
                    db.Farmers.Load();
                    f = db.Farmers.Local.ToBindingList();
                    bs.DataSource = f;
                    filterEditorControl1.SourceControl = bs;
                }
            }
            if (data == typeof(Daily_Collections_Detail))
            {
 using (var db = new AutoweighEntities(coffee.ConnectionString()))
                {
                    db.Daily_Collections_Details.Load();
                    f = db.Daily_Collections_Details.Local.ToBindingList();
                    bs.DataSource = f;
                    filterEditorControl1.SourceControl = bs;
                }

            }

        }

      

        private void filterEditorControl1_FilterChanged(object sender, DevExpress.XtraEditors.FilterChangedEventArgs e)
        {
            if (Data == typeof(Farmer))
            {
                 using (var db = new AutoweighEntities(coffee.ConnectionString()))
                {
                    db.Farmers.Load();
             //    var d = db.Farmers
                 
                 }
               

            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
                filterEditorControl1.ApplyFilter();
               if (Data == typeof(Farmer))
                {
                x = new Reports.Farmers(bs);
               }
             if (Data == typeof(Daily_Collections_Detail))
                {
                x = new Reports.Collections(bs);
               }
                var r = new Report(x);
                r.MdiParent = this.MdiParent;
                r.Show();
                this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    
    }
}
