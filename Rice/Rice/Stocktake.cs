using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rice
{
    public partial class Stocktake : Form
    {
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        Navigation navigation;
        public Stocktake()
        {
            InitializeComponent();
            navigation = new Navigation(item_Movement_HeaderBindingSource, null, db, true, false);
            this.Controls.Add(navigation);
            navigation.navigationribbon.Pages[0].Groups.Insert(0, ribbonControl1.Pages[0].Groups[0]);// .MergeRibbon(ribbonControl1);
            ribbonControl1.Visible = false;
           // this.ribbonControl1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ribbonControl1_ItemClick);

            loadata();
        }
        private void loadata()
        {
            //Task task = Task.Factory.StartNew(() =>
            //{
                outletBindingSource.DataSource = db.Outlets.ToArray();
                variantBindingSource.DataSource = db.Variants.ToList();
                item_Movement_HeaderBindingSource.DataSource = db.Item_Movement_Headers.Where(o => (o.Posted == 0 || string.IsNullOrEmpty(o.Posted.ToString())) && o.Movement_Type == (int)ItemMovementHeader.Movement_Type.Stock_Take && o.Created_By == rice.user.Name).ToList(); 
            if (item_Movement_HeaderBindingSource.Count > 0)

                    item_Movement_HeaderBindingSource.Position = item_Movement_HeaderBindingSource.Count;
            //}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void Receivestock_Load(object sender, EventArgs e)
        {
             if (item_Movement_HeaderBindingSource.Count == 0)

           item_Movement_HeaderBindingSource.AddNew();
        }

        private void item_Movement_HeaderBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Item_Movement_Header sh = new Item_Movement_Header();
                
                sh.Date = DateTime.Now.Date;
                sh.Movement_Type = (int)ItemMovementHeader.Movement_Type.Stock_Take;
                sh.Reference = String.Format("{0}{1}{2}{3}{4}{5}{6}",rice.setup.POS_Outlet, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                sh.Time = DateTime.Now;
                sh.Season = rice.setup.Current_crop;
                sh.Created_By = rice.user.Name;
                sh.Posted = 0;
                sh.Location = rice.setup.POS_Outlet;
                e.NewObject = sh;

                db.Item_Movement_Headers.Add(sh);
                var outitems = db.Category_locations.Where(o => o.Location == sh.Location).Select(u => u.Category).ToArray();

                itemsServicesBindingSource.DataSource = db.Items_Services.Where(o => outitems.Contains(o.Category)).ToList();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void item_MovementBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Item_Movement sh = new Item_Movement();
                if (item_Movement_HeaderBindingSource.Current != null)
                {
                    Item_Movement_Header ih = ((Item_Movement_Header)item_Movement_HeaderBindingSource.Current);
                    sh.Reference  = ih.Reference;
                    sh.Date = ih.Date;
                    sh.User = rice.user.Name;
                    sh.Time = DateTime.Now;
                    sh.Recid = DateTime.Now.Ticks;
                    sh.Season = rice.setup.Current_crop;
                    sh.Location = ih.Location;
                    sh.Movement_Type = ih.Movement_Type;
                    sh.Sent = false;
                    sh.Posted = 0;
                    e.NewObject = sh;
                    db.Item_Movements.Add(sh);
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void locationLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (locationLookUpEdit.EditValue.ToString() != string.Empty) { 
             Task task = Task.Factory.StartNew(() =>
            {
                string location = locationLookUpEdit.EditValue.ToString();
                var outitems = db.Category_locations.Where(o => o.Location == location).Select(u => u.Category).ToArray();

                itemsServicesBindingSource.DataSource = db.Items_Services.Where(o => outitems.Contains(o.Category)).ToList();
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            
            }
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            ColumnView view = (ColumnView)sender;
            if (view.FocusedColumn.Name == "colVariant")
            {
                GridLookUpEdit edit = (GridLookUpEdit)view.ActiveEditor;
                string item = (string)view.GetFocusedRowCellValue(colItem);
                //  (string)gridView1.GetFocusedRowCellValue("colItem");
                // itemVariantBindingSource.DataSource= db.Item_Variants.Where(o => o.No == item).ToArray();
                edit.Properties.DataSource = rice.variants.Where(o => o.Item_Code == item).ToList();
                //edit.Properties.DisplayMember = "Description";
                //edit.Properties.ValueMember = "Code";

                //var variant = rice.variants.Where(o => o.Item_Code == item).ToArray();
                //if (variant.Count() == 1)
                //{

                //    view.SetRowCellValue(view.FocusedRowHandle, colVariant, variant[0].Code);
                //}

            }
        }
        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
                switch (e.Item.Name)
                {
                    case "btnprint":
                        post();
                        db.SaveChanges();
                        Reports.Inputsgrn s = new Reports.Inputsgrn();
                        s.i = (Item_Movement_Header)item_Movement_HeaderBindingSource.Current;
                        using (ReportPrintTool printTool = new ReportPrintTool(s))
                            printTool.Print();
                        break;
                    case "btnpost":
                        post();
                      
                        
                        break;
                }
          
        }
        private void post()
        {
            try
            {

                ((Item_Movement_Header)item_Movement_HeaderBindingSource.Current).Posted = 1;
                gridView1.PostEditor(); gridView1.UpdateCurrentRow();
                if (locationLookUpEdit.EditValue.ToString() == string.Empty)
                {
                    locationLookUpEdit.Focus();
                    throw new Exception("Please select the outlet.");
                }
                db.SaveChanges(savetype: RiceEntities.Savetype.None);
                Task task = Task.Factory.StartNew(() =>
                {
                    Reports.Inputsgrn s = new Reports.Inputsgrn();
                    s.i = (Item_Movement_Header)item_Movement_HeaderBindingSource.Current;
                    using (ReportPrintTool printTool = new ReportPrintTool(s))
                    {
                        if (!string.IsNullOrEmpty(rice.setup.Sales_receipt_Printer))
                            printTool.PrinterSettings.PrinterName = rice.setup.Sales_receipt_Printer;

                        printTool.Print();
                    }
                });
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logging.Logging.ReportError(ex);

            }
        }
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
              DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                var c = (Item_Movement)view.GetFocusedRow();
                switch (e.Column.Name)
                {
                    case "colVariant":
                    
                        break;
                    case "colQty":
               
                        break;
                    case "colPurchase_Price":
                  
                        break;
                }
        }

        private void supplierLabel_Click(object sender, EventArgs e)
        {

        }

        private void item_Movement_HeaderBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            panelControl1.Enabled = item_Movement_HeaderBindingSource.Current != null;

            if (item_Movement_HeaderBindingSource.Current !=null)
            {
                item_MovementBindingSource.DataSource = db.Item_Movements.Where(o => o.Reference == ((Item_Movement_Header)item_Movement_HeaderBindingSource.Current).Reference).ToList();

            }
            else
            item_MovementBindingSource.DataSource = null;
        }

        private void Receivestock_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                if (db.ChangeTracker.Entries().Any(ee => ee.State == EntityState.Added
                                                        || ee.State == EntityState.Modified
                                                        || ee.State == EntityState.Deleted))
                {
                    DialogResult result1 = MessageBox.Show("Your have unsaved items, Do you want to save them?", "Save Changes", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        post();
                        e.Cancel= true;}
                }
           
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnpost_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view.GetFocusedRowCellValue(colItem) == null)
            {
                e.Valid = false;
                e.ErrorText = "Stock item cannot be Empty";
                view.SetColumnError(colItem, e.ErrorText);
                return;
            }
            if (view.GetFocusedRowCellValue(colVariant) == null)
            {
                e.Valid = false;
                e.ErrorText = "Variant cannot be Empty";
                view.SetColumnError(colVariant, e.ErrorText);
                return;
            }
            if (view.GetFocusedRowCellValue(colQty) == null)
            {
                e.Valid = false;
                e.ErrorText = "Qty cannot be Empty";
                view.SetColumnError(colQty, e.ErrorText);
                return;
            } if (Convert.ToInt32(view.GetFocusedRowCellValue(colQty)) == 0)
            {
                e.Valid = false;
                e.ErrorText = "Qty cannot be Zero";
                view.SetColumnError(colQty, e.ErrorText);
                return;
            }
        }

        
    }
}
