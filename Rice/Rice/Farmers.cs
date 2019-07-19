using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using System.Threading.Tasks;

namespace Rice
{
    public partial class Farmers : Form
    {      
      RiceEntities db = new RiceEntities(rice.ConnectionString());
      public  Navigation navigation1;
      RibbonControl mainribbon;
        public Farmers()
        {
            InitializeComponent();
            navigation1 = new Navigation(farmerBindingSource, farmerGridControl, db, false);
            this.Controls.Add(navigation1);

            foreach (RibbonPageGroup g in ribbonControl1.Pages[0].Groups)
            {
                navigation1.navigationribbon.Pages[0].Groups.Insert(0, g);
            }
            ribbonControl1.Visible = false;


            foreach (var item in Enum.GetValues(typeof(NewContact.Account_Types)))
                categoryrepos.Items.Add(item.ToString(), (int)item, -1);
            foreach (var item in Enum.GetValues(typeof(NewContact.Gender)))
                genderrepos.Items.Add(item.ToString(), (int)item, -1);
            foreach (var item in Enum.GetValues(typeof(NewContact.Marital_Status)))
                maritalrepository.Items.Add(item.ToString(), (int)item, -1);
            foreach (var item in Enum.GetValues(typeof(NewContact.Membership_Class)))
                Classrepo.Items.Add(item.ToString(), (int)item, -1);
            foreach (var item in rice.sections())
                Sectionrepo.Items.Add(item.Name, item.Code, -1);
            var b = db.Bank_Accounts.ToList();
            foreach (var item in b)
                bankrepos.Items.Add(item.Name, item.No_, -1);
            var units = db.Units.ToList();
            foreach (var item in units)
                unitrepos.Items.Add(item.Name, item.Code, -1);
            farmerBindingSource.DataSource = db.Farmers.Where(o => (Members.Status) o.Status == Members.Status.Active) .ToList();

        }
     
        public  DialogResult ShowDialog(bool list)
        {
           
            navigation1.selectgroup.Visible = true;
         return   base.ShowDialog();


        }
   
        private void Farmers_Load(object sender, EventArgs e)
        {

        }

        private void Farmers_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
           
        }

        private void filterWithThisValueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                cellcontext.Show(farmerGridControl, e.Location);
            }
        }

        private void cellcontext_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        
        }

        private void cellcontext_Opening(object sender, CancelEventArgs e)
        {

        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
           
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
           
        }

        private void gridView1_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
           
        }

        private void farmerGridControl_Click(object sender, EventArgs e)
        {

        }

        private void farmerBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            var dd = "";
        }

        private void farmerBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Farmer sh = new Farmer();
                sh.New = true;
                e.NewObject = sh;
                db.Farmers.Add(sh);
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void Sectionrepo_SelectedValueChanged(object sender, EventArgs e)
        {
            ImageComboBoxEdit d = sender as ImageComboBoxEdit;
           if (d!= null){
               string v = d.EditValue.ToString();
            if (v!=string.Empty){
                
            var units = db.Units.Where(o => o.Section == v).ToList();
            unitrepos.Items.Clear();
            foreach (var item in units)
                unitrepos.Items.Add(item.Name, item.Code, -1);
            }}
        }

        private void btnfarmer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var form = new Contacts())
            {
                form.contactBindingSource.AddNew();
                form.ShowDialog();

            }
        }

        private void btnservice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var f = new Reportfilters(reports.source.Farmers,reports.report.farmers))
            {
                f.MdiParent = this.Parent.Parent as Form;
                f.WindowState = FormWindowState.Maximized;
                f.BringToFront();
                f.Show();
            }
        }
    }
}
