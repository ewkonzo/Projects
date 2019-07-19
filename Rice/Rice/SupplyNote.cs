using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
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
    public partial class SupplyNote : DevExpress.XtraEditors.XtraForm
    {
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        Navigation navigation;
        public SupplyNote()
        {
            InitializeComponent();
            navigation = new Navigation(items_HeaderBindingSource, null, db, true, false);
            this.Controls.Add(navigation);
            navigation.navigationribbon.Pages[0].Groups.Insert(0, ribbonControl1.Pages[0].Groups[0]);// .MergeRibbon(ribbonControl1);
            ribbonControl1.Visible = false;
            foreach (var item in Enum.GetValues(typeof(ItemHeader.Machine_Cagegory)))
                machine_CagegoryImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);

            loadata();
        }
        List<Resource> res = new List<Resource>();
        private void loadata()
        {
            //Task task = Task.Factory.StartNew(() =>
            //{
            outletBindingSource.DataSource = db.Outlets.ToArray();
            variantBindingSource.DataSource = db.Variants.ToList();
            vendorBindingSource.DataSource = db.Vendors.ToList();
            res = db.Resources.ToList();
            resourceBindingSource.DataSource = res.Where(o => o.Type == (int)Resources.Type.Machine).ToList();
            operatorbindingsource.DataSource = res.Where(o => o.Type == (int)Resources.Type.Person).ToList();
            items_HeaderBindingSource.DataSource = db.Items_Headers.Where(o => (o.Posted == false || string.IsNullOrEmpty(o.Posted.ToString()))).ToList();
            if (items_HeaderBindingSource.Count > 0)
                items_HeaderBindingSource.Position = items_HeaderBindingSource.Count;

            var outitems = db.Category_locations.Where(o => o.Location == rice.setup.POS_Outlet).Select(u => u.Category).ToArray();

            itemsServicesBindingSource.DataSource = db.Items_Services.Where(o => outitems.Contains(o.Category)).ToList();


            //}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void Receivestock_Load(object sender, EventArgs e)
        {
            if (items_HeaderBindingSource.Count == 0)
                items_HeaderBindingSource.AddNew();
        }

        private void item_Movement_HeaderBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void item_MovementBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {


            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
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
            }

        }
        private void post()
        {
            try
            {
                if (gridView1.PostEditor() && gridView1.UpdateCurrentRow())
                {
                    if (referenceTextBox.Text.ToString() == string.Empty)
                    {
                        referenceTextBox.Focus();
                        throw new Exception("Please Enter Document No.");
                    }
                    if (machineImageComboBoxEdit.EditValue == null)
                    {
                        machineImageComboBoxEdit.Focus();
                        throw new Exception("Please select the Machine");
                    }
                    if (operatorImageComboBoxEdit.EditValue == null)
                    {
                        operatorImageComboBoxEdit.Focus();
                        throw new Exception("Please select operator.");
                    }
                    var h = (Items_Header)items_HeaderBindingSource.Current;
                    db.Items_Headers.Add(h);
                    List<Items_Services_List> items = new List<Items_Services_List>();
                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        int rowHandle = gridView1.GetVisibleRowHandle(j);
                        if (gridView1.IsDataRow(rowHandle))
                        {
                            var i = (Items_Services_List)gridView1.GetRow(rowHandle);
                            i.Reference = h.Reference;
                            i.Machine = h.Machine;
                            i.Machine_Cagegory = h.Machine_Cagegory;
                            i.Operator = h.Operator;
                            i.Date = h.Date;
                            i.Posted = 1;
                            items.Add(i);
                        }
                    }
                    db.Items_Services_List.AddRange(items);

                    h.Posted = true;

                    db.SaveChanges();


                    //var ih = ((Items_Header)items_HeaderBindingSource.Current);
                    //ih.Posted = true;
                    //db.SaveChanges(savetype: RiceEntities.Savetype.None);

                    items_HeaderBindingSource.AddNew();
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
            var c = (Items_Services_List)view.GetFocusedRow();
            switch (e.Column.Name)
            {
                case "colVariant":
                    if (!string.IsNullOrEmpty(c.Item))
                    {
                        var prices = rice.prices.FirstOrDefault(o => o.Item_No_ == c.Item && o.Variant_Code == e.Value.ToString() && o.Sales_Type == c.Sales_Type);
                        double price = 0;
                        if (prices != null)
                            price = (double)prices.Unit_Price;
                        c.Unit_Cost = (decimal)price;
                        c.Balance = rice.Itembalance(c.Item, e.Value.ToString(), c.Outlet);
                    }
                    break;
                case "colQty":
                    if ((!string.IsNullOrEmpty(c.Item)) && (!string.IsNullOrEmpty(c.Unit_Cost.ToString())) && (!string.IsNullOrEmpty(e.Value.ToString())))
                        c.Total_Cost = c.Unit_Cost * (decimal)e.Value;

                    break;

            }
        }

        private void supplierLabel_Click(object sender, EventArgs e)
        {

        }

        private void item_Movement_HeaderBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //panelControl1.Enabled = item_Movement_HeaderBindingSource.Current != null;


        }

        private void Receivestock_FormClosing(object sender, FormClosingEventArgs e)
        {

            //if (db.ChangeTracker.Entries().Any(ee => ee.State == EntityState.Added
            //                                        || ee.State == EntityState.Modified
            //                                        || ee.State == EntityState.Deleted))
            //{
            //    DialogResult result1 = MessageBox.Show("Your have unsaved items, Do you want to save them?", "Save Changes", MessageBoxButtons.YesNo);
            //    if (result1 == DialogResult.Yes)
            //    {
            //        post();
            //        e.Cancel = true;
            //    }
            //}
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
            }
            if (Convert.ToDouble(view.GetFocusedRowCellValue(colQty)) == 0)
            {
                e.Valid = false;
                e.ErrorText = "Qty cannot be Zero";
                view.SetColumnError(colQty, e.ErrorText);
                return;
            }
        }
        private void gridView3_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Missing Data";
            e.ErrorText = e.Exception.Message;

            gridView1.HideEditor();


        }

        private void collection_NoLabel_Click(object sender, EventArgs e)
        {

        }

        private void items_HeaderBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            Items_Header sh = new Items_Header();
            sh.Type = (int)ItemHeader.Type.Garage;
            sh.Date = DateTime.Now.Date;
            sh.Collection_No = String.Format("{0}{1}{2}{3}{4}{5}{6}", rice.setup.POS_Outlet, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            sh.Outlet = rice.setup.POS_Outlet;
            sh.Season = rice.setup.Current_crop;
            sh.User_Name = rice.user.Name;
            sh.Posted = false;
            sh.Sales_Type = (int)ItemHeader.Sales_Type.Garage;
            e.NewObject = sh;
           // db.Items_Headers.Add(sh);
        }

        private void items_HeaderBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (items_HeaderBindingSource.Current != null)
            {
                items_Services_ListBindingSource.DataSource = db.Items_Services_List.Where(o => o.Reference == ((Items_Header)items_HeaderBindingSource.Current).Collection_No).ToList();
            }
            else
                items_Services_ListBindingSource.DataSource = null;
        }
        private void items_Services_ListBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            Items_Services_List sh = new Items_Services_List();
            if (items_HeaderBindingSource.Current != null)
            {
                Items_Header ih = ((Items_Header)items_HeaderBindingSource.Current);
                sh.Reference = ih.Collection_No;
                sh.Date = ih.Date;
                sh.User = rice.user.Name;
                sh.Time = DateTime.Now;
                sh.Recid = DateTime.Now.Ticks;
                sh.Season = rice.setup.Current_crop;
                sh.Outlet = ih.Outlet;
                sh.Type = ih.Type;
                sh.Sent = false;
                sh.Operator = ih.Operator;
                sh.Machine_Cagegory = ih.Machine_Cagegory;
                ih.Machine = ih.Machine;
                sh.Posted = 0;
                sh.Sales_Type = (int)ItemList.Sales_Type.Garage;
                e.NewObject = sh;
              //  db.Items_Services_List.Add(sh);
            }
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column = view.FocusedColumn;
            var c = (Items_Services_List)view.GetFocusedRow();
            switch (column.Name)
            {
                case "colQty":
                    if (string.IsNullOrEmpty(view.GetFocusedRowCellValue(colVariant).ToString()))
                    {
                        e.Valid = false;
                        e.ErrorText = "Please select the variant. ";
                        view.SetColumnError(colVariant, e.ErrorText);
                        return;
                    }

                    if (e.Value.ToString() == string.Empty)
                    {
                        e.Valid = false;
                        e.ErrorText = "Quantity required. ";
                        view.SetColumnError(column, e.ErrorText);
                        return;
                    }
                    if (c.Balance < Convert.ToDouble(e.Value))
                    {
                        e.Valid = false;
                        e.ErrorText = string.Format("{0} in stock is less that qty entered. ", c.Item_Description);
                        view.SetColumnError(column, e.ErrorText);
                        e.Value = "";
                        //db.Items_Services_List.Remove((Items_Services_List)gridView1.GetFocusedRow());    items_Services_ListBindingSource.RemoveCurrent();

                        //gridView1.CancelUpdateCurrentRow();
                        return;
                    }

                    c.Total_Cost = (decimal)((double)c.Unit_Cost * Convert.ToDouble(e.Value));

                    view.SetColumnError(column, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);


                    break;
            }
        }

        private void machine_CagegoryImageComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty( machine_CagegoryImageComboBoxEdit.EditValue .ToString())) 
            {
                resourceBindingSource.DataSource = res.Where(o => o.Type == (int)Resources.Type.Machine && o.Category == (int)machine_CagegoryImageComboBoxEdit.EditValue).ToList();
            }
        }
    }
}
