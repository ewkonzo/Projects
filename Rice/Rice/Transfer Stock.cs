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
    public partial class Transferstock : Form
    {
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        Navigation navigation;
        public Transferstock()
        {
            InitializeComponent();
            navigation = new Navigation(item_Movement_HeaderBindingSource, null, db, true, false);
            this.Controls.Add(navigation);
            navigation.navigationribbon.Pages[0].Groups.Insert(0, ribbonControl1.Pages[0].Groups[0]);
            ribbonControl1.Visible = false;
           
            loadata ();
        }
        private void loadata()
        {
            //Task task = Task.Factory.StartNew(() =>
            //    {                    
                    outletBindingSource.DataSource = db.Outlets.ToArray();
                    vendorBindingSource.DataSource = db.Vendors.ToArray();
                    variantBindingSource.DataSource = db.Variants.ToList();
                    item_Movement_HeaderBindingSource.DataSource = db.Item_Movement_Headers.Where(o => (o.Posted == 0 || string.IsNullOrEmpty(o.Posted.ToString())) && o.Movement_Type == (int)ItemMovementHeader.Movement_Type.Transfer && o.Created_By == rice.user.Name).ToList();
                    if (item_Movement_HeaderBindingSource.Count > 0)
                        item_Movement_HeaderBindingSource.Position = item_Movement_HeaderBindingSource.Count;

                //}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void Receivestock_Load(object sender, EventArgs e)
        {
            if (item_Movement_HeaderBindingSource.Count == 0) item_Movement_HeaderBindingSource.AddNew();
        }

        private void item_Movement_HeaderBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Item_Movement_Header sh = new Item_Movement_Header();

                sh.Date = DateTime.Now.Date;
                sh.Reference = String.Format("{0}{1}{2}{3}{4}{5}{6}",rice.setup.POS_Outlet, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                sh.Time = DateTime.Now;
                sh.Movement_Type = (int)ItemMovementHeader.Movement_Type.Transfer;
                sh.Season = rice.setup.Current_crop;
                sh.Created_By = rice.user.Name;
                sh.Posted = 0;
                sh.Location = rice.setup.POS_Outlet;
                e.NewObject = sh;

                //db.Item_Movement_Headers.Add(sh);
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
                    sh.Reference = ih.Reference;
                    sh.Date = ih.Date;
                    sh.User = rice.user.Name;
                    sh.Time = DateTime.Now;
                    sh.Season = rice.setup.Current_crop;
                    sh.Location = ih.Location;
                    sh.Movement_Type = ih.Movement_Type;
                    sh.Location_To = ih.Location_To;
                    sh.Sent = false;
                    sh.Posted = 0;
                    e.NewObject = sh;
                    //db.Item_Movements.Add(sh);
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void locationLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (locationLookUpEdit.EditValue.ToString() != string.Empty)
            {
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
            switch (view.FocusedColumn.Name)
            {
                case "colVariant":
                    {
                        GridLookUpEdit edit = (GridLookUpEdit)view.ActiveEditor;
                        string item = (string)view.GetFocusedRowCellValue(colItem);
                      
                        edit.Properties.DataSource = rice.variants.Where(o => o.Item_Code == item).ToList();
                       
                    }
                    break;
            }
        } private void gridView3_ShownEditor(object sender, EventArgs e)
        {
            ColumnView view = (ColumnView)sender;
            switch (view.FocusedColumn.Name)
            {case "colVariant1":
               
                    {
                        GridLookUpEdit edit = (GridLookUpEdit)view.ActiveEditor;
                        string item = (string)view.GetFocusedRowCellValue(colItem);
                      
                        edit.Properties.DataSource = rice.variants.Where(o => o.Item_Code == item).ToList();
                       
                    }
                    break;
            }
        }
        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            switch (e.Item.Name)
            {
                case "btnprint":
                    post();
                    db.SaveChanges();
                    Task task = Task.Factory.StartNew(() =>
                    {
                        Reports.Transfer s = new Reports.Transfer();
                        s.i = db.Item_Movement_Headers.FirstOrDefault(o => o.Reference == ((Item_Movement_Header)item_Movement_HeaderBindingSource.Current).Reference);
                        using (ReportPrintTool printTool = new ReportPrintTool(s))
                        {
                            if (!string.IsNullOrEmpty(rice.setup.Sales_receipt_Printer))
                                printTool.PrinterSettings.PrinterName = rice.setup.Sales_receipt_Printer;
                            for (int i = 1; i <= rice.setup.Transfer_copies; i++)
                            {
                                printTool.Print();
                            }
                        }
                    });
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
                    throw new Exception("Please select the Outlet.");
                }

                if (location_ToLookUpEdit.EditValue.ToString() == string.Empty)
                {
                    location_ToLookUpEdit.Focus();
                    throw new Exception("Please Select transfer to:");

                }

                if (location_ToLookUpEdit.EditValue.ToString().Equals(locationLookUpEdit.EditValue.ToString()))
                {
                    location_ToLookUpEdit.Focus();
                    throw new Exception("You cannot transfer to the same location");
                }
                Item_Movement_Header ih = (Item_Movement_Header)item_Movement_HeaderBindingSource.Current;

                bool lines = false;
                List<Item_Movement> items = new List<Item_Movement>();
                for (int j = 0; j < gridView1.RowCount; j++)
                {
                    int rowHandle = gridView1.GetVisibleRowHandle(j);
                    if (gridView1.IsDataRow(rowHandle))
                    {
                        lines = true;
                        var i = (Item_Movement)gridView1.GetRow(rowHandle);
                        i.Posted = 1;
                        i.Sent = false;
                        items.Add(i);
                    }
                }
                if (lines == false)
                { throw new Exception("Please Click on transfer"); }
                db.Item_Movements.AddRange(items);
                db.Item_Movement_Headers.Add(ih);
                db.SaveChanges(savetype: RiceEntities.Savetype.None);
                Reports.Transfer s = new Reports.Transfer();
                s.i = (Item_Movement_Header)item_Movement_HeaderBindingSource.Current;
                using (ReportPrintTool printTool = new ReportPrintTool(s))
                    printTool.Print();
                item_Movement_HeaderBindingSource.DataSource = db.Item_Movement_Headers.Where(o => (o.Posted == 0 || string.IsNullOrEmpty(o.Posted.ToString())) && o.Movement_Type == (int)ItemMovementHeader.Movement_Type.Transfer && o.Created_By == rice.user.Name).ToList();
                item_Movement_HeaderBindingSource.AddNew();
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
            //panelControl1.Enabled = item_Movement_HeaderBindingSource.Current != null;

            if (item_Movement_HeaderBindingSource.Current != null)
            {
                var itemh = ((Item_Movement_Header)item_Movement_HeaderBindingSource.Current);
                item_MovementBindingSource.DataSource = db.Item_Movements.Where(o => o.Reference == itemh.Reference).ToList();
                transferredItemBindingSource.DataSource = db.Transferred_Items.Where(o => o.Reference == itemh.Reference).ToList();
            }
            else
            {
                item_MovementBindingSource.DataSource = null;
                transferredItemBindingSource.DataSource = null;
            }
        }

        private void Receivestock_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (db.ChangeTracker.Entries().Any(ee => ee.State == EntityState.Added
                                                        || ee.State == EntityState.Modified
                                                        || ee.State == EntityState.Deleted))
                {
                    DialogResult result1 = MessageBox.Show("Your have unsaved items, Do you want to save them?", "Save Changes", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        post();
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnpost_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void referenceLabel2_Click(object sender, EventArgs e)
        {

        }

        private void location_ToLabel_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
            Item_Movement_Header header = (Item_Movement_Header)item_Movement_HeaderBindingSource.Current;
            if (header.Converted == true)
            {
                MessageBox.Show("This item is already Transferred, Please post");
             return;
            }

            if (locationLookUpEdit.EditValue.ToString().Equals(location_ToLookUpEdit.EditValue.ToString()))
            {
                MessageBox.Show("You cannot move items within the same location.");
                locationLookUpEdit.Focus();
                return;
            }
            if ((gridView3.PostEditor() && gridView3.UpdateCurrentRow()))
            {

                //Transferred_Item[] items = (Transferred_Item[])transferredItemBindingSource.DataSource;
                //foreach (var item in items)
                //{
                int c = 10;
                for (int j = 0; j < gridView3.RowCount; j++)
                {
                    int rowHandle = gridView3.GetVisibleRowHandle(j);
                    if (gridView3.IsDataRow(rowHandle))
                    {
                        var item = (Transferred_Item)gridView3.GetRow(rowHandle);
                        Item_Movement mov = new Item_Movement();
                        mov.Movement_Type = header.Movement_Type;
                        mov.Location = header.Location;
                        mov.Item = item.Item;
                        mov.Recid = DateTime.Now.AddSeconds(c).Ticks;
                        mov.Variant = item.Variant;
                        mov.Location_To = header.Location_To;
                        mov.User = header.Created_By;
                        mov.Qty =(decimal) (item.Qty * -1);
                        mov.Reference = item.Reference;
                        mov.Date = header.Date;
                        mov.Time = header.Time;
                        mov.Season = header.Season;
                        db.Item_Movements.Add(mov);
                        item_MovementBindingSource.Add(mov);
                        c += 10;
                        mov = new Item_Movement();
                        mov.Movement_Type = header.Movement_Type;
                        mov.Location = header.Location_To;
                        mov.Location_To = header.Location;
                        mov.Item = item.Item;
                        mov.Recid = DateTime.Now.AddMinutes(c).Ticks;
                        mov.Variant = item.Variant;
                        mov.User = header.Created_By;
                        mov.Qty =(decimal) item.Qty;
                        mov.Reference = item.Reference;
                        mov.Date = header.Date;
                        mov.Time = header.Time;
                        mov.Season = header.Season;
                        db.Item_Movements.Add(mov);
                        item_MovementBindingSource.Add(mov);
                        header.Converted = true;
                    }
                    c += 10;
                }
            }
        }

        private void gridView3_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view.GetFocusedRowCellValue(colItem1) == null)
            {
                e.Valid = false;
                e.ErrorText = "Stock item cannot be Empty";
                view.SetColumnError(colItem1, e.ErrorText);
                return;
            }
            if (view.GetFocusedRowCellValue(colVariant1) == null)
            {
                e.Valid = false;
                e.ErrorText = "Variant cannot be Empty";
                view.SetColumnError(colVariant1, e.ErrorText);
                return;
            }
            if (view.GetFocusedRowCellValue(colQty1) == null)
            {
                e.Valid = false;
                e.ErrorText = "Qty cannot be Empty";
                view.SetColumnError(colQty1, e.ErrorText);
                return;
            } if (Convert.ToDouble(view.GetFocusedRowCellValue(colQty1)) == 0)
            {
                e.Valid = false;
                e.ErrorText = "Qty cannot be Zero";
                view.SetColumnError(colQty1, e.ErrorText);
                return;
            }
            if (t != null)
                if (t.Qty > t.Balance)
                { 
                e.Valid = false;
                e.ErrorText = "Qty entered is more than the stock balance";
                view.SetColumnError(colQty1, e.ErrorText);
                return;
                }
        }

        private void item_MovementGridControl_Click(object sender, EventArgs e)
        {

        }
        Transferred_Item t;
        private void gridView3_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //try
            //{
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            t = (Transferred_Item)view.GetFocusedRow();
            Item_Movement_Header ih = ((Item_Movement_Header)item_Movement_HeaderBindingSource.Current);
            
            switch (e.Column.Name)
            { 
             case "colVariant1":
                    if (t != null)
                    {
                        t.Balance =(int) rice.Itembalance(t.Item, e.Value.ToString(), ih.Location);

                    }
                    break;
            }
        }
        private void gridView3_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Missing Data";
            e.ErrorText = e.Exception.Message;
            gridView3.HideEditor();

        }

        private void transferred_ItemGridControl_Click(object sender, EventArgs e)
        {

        }

        private void transferredItemBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Transferred_Item sh = new Transferred_Item();
                if (item_Movement_HeaderBindingSource.Current != null)
                {
                    Item_Movement_Header ih = ((Item_Movement_Header)item_Movement_HeaderBindingSource.Current);
                    sh.Reference = ih.Reference;
                   
                    e.NewObject = sh;
                    db.Transferred_Items.Add(sh);
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
       
        }

      
    }
}
