using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class Convertstock : Form
    {
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        Navigation navigation;
        public Convertstock()
        {
            InitializeComponent();
            navigation = new Navigation(item_Movement_HeaderBindingSource, null, db, true, false);
            this.Controls.Add(navigation);
            navigation.navigationribbon.Pages[0].Groups.Insert(0, ribbonControl1.Pages[0].Groups[0]);// .MergeRibbon(ribbonControl1);
            ribbonControl1.Visible = false;
            //this.ribbonControl1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ribbonControl1_ItemClick);

            loadata();
        }
        private void loadata()
        {
            //Task task = Task.Factory.StartNew(() =>
            //{
                outletBindingSource.DataSource = db.Outlets.ToArray();
                variantBindingSource.DataSource = db.Variants.ToList();
                itemConversionMatrixBindingSource.DataSource = db.Item_Conversion_Matrices.ToList();
                item_Movement_HeaderBindingSource.DataSource = db.Item_Movement_Headers.Where(o => (o.Posted == 0 || string.IsNullOrEmpty(o.Posted.ToString())) && o.Movement_Type == (int)ItemMovementHeader.Movement_Type.Convert && o.Created_By == rice.user.Name).ToList();
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
                sh.Reference = String.Format("{0}{1}{2}{3}{4}{5}{6}",rice.setup.POS_Outlet, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                sh.Time = DateTime.Now;
                sh.Movement_Type = (int)ItemMovementHeader.Movement_Type.Convert;
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

                    case "btnpost":
                        post();

                        break;

                    case "btnconvert":
                        try
                        {
                            if (item_Movement_HeaderBindingSource.Current != null)
                            {
                                Item_Movement_Header ih = ((Item_Movement_Header)item_Movement_HeaderBindingSource.Current);
                                if (ih.Converted == true)
                                    throw new Exception("This item is already converted");
                                if (qtyTextBox.Text == string.Empty)
                                    throw new Exception("Enter the quantity to convert.");
                                var matrix = db.Item_Conversion_Matrices.FirstOrDefault(o => o.Item == itemLookUpEdit1.EditValue.ToString());
                                Item_Movement sh = new Item_Movement();
                                sh.Reference = ih.Reference;
                                sh.Date = ih.Date;
                                sh.User = rice.user.Name;
                                sh.Time = DateTime.Now;
                                sh.Season = rice.setup.Current_crop;
                                sh.Location = ih.Location;
                                sh.Recid = DateTime.Now.Ticks;
                                sh.Sent = false;
                                sh.Posted = 0;
                                sh.Movement_Type = ih.Movement_Type;
                                sh.Item = ih.Item;
                                sh.Variant = ih.Variant;
                                sh.Qty = (ih.Qty) * -1;

                                db.Item_Movements.Add(sh);
                                item_MovementBindingSource.Add(sh);

                                sh = new Item_Movement();
                                sh.Reference = ih.Reference;
                                sh.Date = ih.Date;
                                sh.User = rice.user.Name;
                                sh.Time = DateTime.Now;
                                sh.Season = rice.setup.Current_crop;
                                sh.Location = ih.Location;
                                sh.Recid = DateTime.Now.Ticks;
                                sh.Sent = false;
                                sh.Posted = 0;
                                sh.Movement_Type = ih.Movement_Type;
                                sh.Item = ih.To_Item;
                                sh.Variant = ih.To_Variant;
                                sh.Qty = ih.Qty * matrix.Units;

                                db.Item_Movements.Add(sh);
                                item_MovementBindingSource.Add(sh);

                                ih.Converted = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            Logging.Logging.ReportError(ex);

                        }
                        break;
                }
           
        }
        private void post()
        { try
            {
                if (((Item_Movement_Header)item_Movement_HeaderBindingSource.Current).Converted != true
                   ){
                   MessageBox.Show("Item is not converted, please click convert");
                       return;
                   }
                if (gridView1.PostEditor() && gridView1.UpdateCurrentRow())
                {
                    ((Item_Movement_Header)item_Movement_HeaderBindingSource.Current).Posted = 1;
                    db.SaveChanges(savetype: RiceEntities.Savetype.None);
                    Task task = Task.Factory.StartNew(() =>
                {
                    Reports.Convert s = new Reports.Convert();
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
           // panelControl1.Enabled = item_Movement_HeaderBindingSource.Current != null;

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
                    {post();
                    e.Cancel = true;
                    }
                }
           
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnpost_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void movement_TypeImageComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void variantLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void itemLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (item_Movement_HeaderBindingSource.Current != null)
                {
                    Item_Movement_Header ih = ((Item_Movement_Header)item_Movement_HeaderBindingSource.Current);
                    if (ih.Converted == true)
                        throw new Exception("This item is already converted");
                    if (qtyTextBox.Text == string.Empty)
                        throw new Exception("Enter the quantity to convert.");
                    if (ih.Balance < Convert.ToDouble(qtyTextBox.Text))
                        throw new Exception("Quantiy to convert is more than available stock.");
                                     var matrix = db.Item_Conversion_Matrices.FirstOrDefault(o => o.Item ==ih.Item && o.Variant == ih.Variant);
                  
                    Item_Movement sh = new Item_Movement();
                    sh.Reference = ih.Reference;
                    sh.Date = ih.Date;
                    sh.User = rice.user.Name;
                    sh.Time = DateTime.Now;
                    sh.Recid = DateTime.Now.Ticks;
                    var r = sh.Recid;
                    sh.Season = rice.setup.Current_crop;
                    sh.Location = ih.Location;
                    sh.Sent = false;
                    sh.Posted = 0;
                    sh.Movement_Type = ih.Movement_Type;
                    sh.Item = ih.Item;
                    sh.Variant = ih.Variant;
                    sh.Qty = (ih.Qty) * -1;

                    sh.Balance =(double)  (((int)rice.Itembalance(ih.Item, ih.Variant, locationLookUpEdit.EditValue.ToString())) + sh.Qty);
                                      db.Item_Movements.Add(sh);
                    item_MovementBindingSource.Add(sh);

                    sh = new Item_Movement();
                    sh.Reference = ih.Reference;
                    sh.Date = ih.Date;
                    sh.Recid = DateTime.Now.AddSeconds(10).Ticks;
                    sh.User = rice.user.Name;
                    sh.Time = DateTime.Now;
                    sh.Season = rice.setup.Current_crop;
                    sh.Location = ih.Location;
                    sh.Sent = false;
                    sh.Posted = 0;
                    sh.Movement_Type = ih.Movement_Type;
                    sh.Item = ih.To_Item;
                    sh.Variant = ih.To_Variant;
                    sh.Qty = ih.Qty * matrix.Units;
                    sh.Balance = (double)(((int)rice.Itembalance(ih.To_Item, ih.To_Variant, locationLookUpEdit.EditValue.ToString())) + sh.Qty);
                    db.Item_Movements.Add(sh);
                    item_MovementBindingSource.Add(sh);
                    ih.Converted = true;
                    //panelControl1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logging.Logging.ReportError(ex);

            }
        }

        private void item_MovementGridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                view.DeleteSelectedRows();
                e.Handled = true;
            }
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            db.Item_Movements.Remove((Item_Movement)e.Row);
     
        }

        private void itemLookUpEdit_Properties_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            
            if (e.Value != null)
            {
                if (locationLookUpEdit.EditValue.ToString() == string.Empty)
                {
                    locationLookUpEdit.Focus();
                    e.AcceptValue = false;
                    MessageBox.Show("Please select the outlet");
                    return;
                }
                if (e.Value.ToString() != string.Empty)
                {

                    var matrix =  db.Item_Conversion_Matrices.FirstOrDefault(o => o.Entry == (int)e.Value);
                    //itemLookUpEdit.Properties.ValueMember = "Item";
                   // e.Value = matrix.Item;
                    e.AcceptValue = true;
                   
                    if (item_Movement_HeaderBindingSource.Current != null)
                    {
                        var ih = (Item_Movement_Header)item_Movement_HeaderBindingSource.Current;
                        ih.Item = matrix.Item;
                        ih.Variant = matrix.Variant;
                        ih.To_Item = matrix.To_Item;
                        ih.To_Variant = matrix.To_Variant;
                        ih.Balance = (int)rice.Itembalance(ih.Item, ih.Variant, locationLookUpEdit.EditValue.ToString());
                        ih.Balance_2 = (int)rice.Itembalance(ih.To_Item, ih.To_Variant, locationLookUpEdit.EditValue.ToString());
                        item_Movement_HeaderBindingSource.EndEdit();
                        item_Movement_HeaderBindingSource.ResetBindings(false);
                       
                    }
                }
            }
         
        }

        private void itemLookUpEdit_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            
        }
    }
}
