using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors.Controls;

using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rice
{
    public partial class POS : Form
    {
        public string outlet;
        Navigation navigation;
        public RiceEntities db = new RiceEntities(rice.ConnectionString());
        public POS()
        {
            InitializeComponent();
            navigation = new Navigation(items_HeaderBindingSource, null, db,false,false);
            this.Controls.Add(navigation);
            navigation.navigationribbon.Pages[0].Groups.Insert(0, ribbonControl1.Pages[0].Groups[0]);// .MergeRibbon(ribbonControl1);
            ribbonControl1.Visible = false;
            Task task = Task.Factory.StartNew(() =>
            {
                foreach (var item in Enum.GetValues(typeof(ItemList.Sales_Type)))
                    sales_TypeImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);

                foreach (var item in db.Outlets.ToList())
                    outletImageComboBoxEdit.Properties.Items.Add(item.Name, item.Code, -1);

               // itemsServicesBindingSource.DataSource = db.Items_Services.ToList();
                variantBindingSource.DataSource = db.Variants.ToList();
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            
            //repositoryItemTextEditFeature.Click += (sender, args) =>
            //{
            //    var textEdit = sender as TextEdit;
            //    if (textEdit != null) textEdit.SelectAll();
            //};
        }
        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnprint":
                    Reports.Sales_Receipt s = new Reports.Sales_Receipt();
                    s.i = (Items_Header)items_HeaderBindingSource.Current;
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
            if (items_HeaderBindingSource.Current != null)
            {
                Items_Header i = (Items_Header)items_HeaderBindingSource.Current;
                if (i.Posted != true)
                {
                    List<Items_Services_List> items = new List<Items_Services_List>();
                   
                    if ((gridView1.PostEditor() && gridView1.UpdateCurrentRow()))
                    { for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        int rowHandle = gridView1.GetVisibleRowHandle(j);
                        if (gridView1.IsDataRow(rowHandle))
                            items.Add((Items_Services_List)gridView1.GetRow(rowHandle));

                    } 
                        i.Amount = Convert.ToDouble(colTotal_Cost.SummaryItem.SummaryValue);
                        using (var f = new PosCash(items, i, db))
                        {

                            f.StartPosition = FormStartPosition.CenterParent;
                            f.ShowDialog(i);
                            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                            {
                                items_HeaderBindingSource.DataSource = typeof(Items_Header);
                                items_HeaderBindingSource.AddNew();
                            }
                        }
                    }
                }
            }
        }
        private void items_HeaderBindingSource_AddingNew(object sender, AddingNewEventArgs e)
      {
            try
            {
                Items_Header sh = null;
                sh = new Items_Header();
                sh.Date = DateTime.Now.Date;
                sh.Collection_No = String.Format("{0}{1}{2}{3}{4}{5}{6}",rice.setup.POS_Outlet, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                sh.Posted = false;
                sh.Season = rice.setup.Current_crop;
                sh.User_Name = rice.user.Name;
                sh.Customer = "Cash Sale";
                sh.Sales_Type = (int)ItemList.Sales_Type.All_Customers;
                if (rice.setup.outlet != null)
                    if (!String.IsNullOrEmpty(rice.setup.outlet.Price.ToString()))
                        sh.Sales_Type = rice.setup.outlet.Price;
                sh.Payment_Mode = (int)ItemList.Payment_Mode.Cash;
                sh.Reference = sh.Collection_No;
                sh.Outlet = rice.setup.POS_Outlet;
                sh.Type = (int)ItemList.Type.POS;
               // if (outlet != string.Empty)
                   // sh.Outlet = outlet;
                e.NewObject = sh;
                var outitems = db.Category_locations.Where(o => o.Location == sh.Outlet).Select(u => u.Category).ToArray();
                var ds = db.Items_Services.Where(o => outitems.Contains(o.Category)).ToArray();
               if (rice.setup.Load_item_with_stock== true )
                itemsServicesBindingSource.DataSource =ds.Where(o=> o.TotalBal>0) ;
               else
                   itemsServicesBindingSource.DataSource = ds;
               // db.Items_Headers.Add(sh);
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {
        }
        //private void payment_ModeImageComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (((ItemList.Payment_Mode)payment_ModeImageComboBoxEdit.EditValue) == ItemList.Payment_Mode.Credit) {
        //            customerTextEdit.EditValue = "Credit";
        //        }
        //    }
        //    catch (Exception ex) { 

        //    }
        //}

        private void items_Services_ListBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Items_Services_List sh = new Items_Services_List();
                if (items_HeaderBindingSource.Current != null)
                {
                    Items_Header ih = ((Items_Header)items_HeaderBindingSource.Current);
                    sh.Recid = DateTime.Now.Ticks;
                    sh.Receipt_No = ih.Collection_No;
                    sh.Source_no = (int)ih.Entry;
                    sh.Receipt_No = ih.Collection_No;
                    sh.Recid = DateTime.Now.Ticks;
                    sh.Date = ih.Date;
                    sh.User = rice.user.Name;
                    sh.Time = DateTime.Now;
                    sh.Season = rice.setup.Current_crop;
                    sh.Entry_Type = (int)ItemList.Type.POS;
                    sh.Payment_Mode = ih.Payment_Mode;
                    sh.Customer = ih.Customer;
                    sh.Reference = ih.Reference;
                    sh.Phone_No = ih.Phone_No;
                    sh.Sales_Type = ih.Sales_Type;
                    sh.Outlet = ih.Outlet;
                    sh.Sent = false;
                    e.NewObject = sh;
                 //   db.Items_Services_List.Add(sh);
                   
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }
        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            //try
            //{
            
           

                ColumnView view = (ColumnView)sender;


               switch (view.FocusedColumn.Name )
                {
                   case  "colVariant":
                    GridLookUpEdit edit = (GridLookUpEdit)view.ActiveEditor;
                    
                    string item = (string)view.GetFocusedRowCellValue(colItem);
                    //  (string)gridView1.GetFocusedRowCellValue("colItem");
                    // itemVariantBindingSource.DataSource= db.Item_Variants.Where(o => o.No == item).ToArray();
                    edit.Properties.DataSource = rice.variants.Where(o => o.Item_Code == item).ToArray();
                    //edit.Properties.DisplayMember = "Description";
                    //edit.Properties.ValueMember = "Code";

                    var variant = rice.variants.Where(o => o.Item_Code == item).ToArray();
                    if (variant.Count() == 1)
                    {
                        view.SetRowCellValue(view.FocusedRowHandle, colVariant, variant[0].Code);
                    }
                    break;
                   case "colQty":
                    DevExpress.XtraEditors.TextEdit editq = (DevExpress.XtraEditors.TextEdit)view.ActiveEditor;
                    editq.Click += (sende, args) =>
                    {
                        var textEdit = sende as TextEdit;
                        if (textEdit != null) textEdit.SelectAll();
                    };
                       break;

                }

            //}
            //catch (Exception ex) { 
            //    Logging.Logging.ReportError(ex); 
            //}
        }
        double q;
      
        private void referenceTextEdit_EditValueChanged(object sender, EventArgs e)
        {
        }
        private void sales_TypeImageComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
       private void phone_NoTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void customerTextEdit_EditValueChanged(object sender, EventArgs e)
        {
        }
        private void items_Services_ListGridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                if (((Items_Header)items_HeaderBindingSource.Current).Posted != true)
                    {
                        string message = "Are you sure you want to delete the current sales line?";
                        string caption = "Remove sales line";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        // Displays the MessageBox.
                        result = MessageBox.Show(this, message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign);
                        if (result == DialogResult.Yes)
                        {
                            view.DeleteRow(view.FocusedRowHandle);
                            //items_Services_ListBindingSource();
                            //var d = db.Items_Services_List.FirstOrDefault(o => o.Recid == c.Recid);
                            //                    if (d!=null)
                            //db.Items_Services_List.Remove(d);
                            e.Handled = true;
                        }
                    }
            }
        }
        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            //var d = (Items_Services_List)e.Row;
            //var del = db.Items_Services_List.FirstOrDefault(o => o.Entry == d.Entry);
            //    if (del !=null)
            //db.Items_Services_List.Remove((Items_Services_List)e.Row);
        }
        private void items_Services_ListBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                //db.SaveChanges(RiceEntities.Savetype.Itemlist);
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void items_Services_ListGridControl_Click(object sender, EventArgs e)
        {
        }
        private void items_HeaderBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            groupControl1.Enabled = items_HeaderBindingSource.Current != null;
            groupControl2.Enabled = items_HeaderBindingSource.Current != null;
            if (items_HeaderBindingSource.Current != null)
            {
                gridView1.OptionsBehavior.Editable = (bool)!((Items_Header)items_HeaderBindingSource.Current).Posted;
                if (gridView1.Editable)
                    gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                else
                    gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                items_Services_ListBindingSource.DataSource = db.Items_Services_List.Where(o => o.Receipt_No == ((Items_Header)items_HeaderBindingSource.Current).Collection_No).ToList();
            }
            else
                items_Services_ListBindingSource.DataSource = null;
        }
        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (outletImageComboBoxEdit.EditValue.ToString() == string.Empty)
            {
                MessageBox.Show("Please select the Outlet");
                gridView1.CancelUpdateCurrentRow();
                outletImageComboBoxEdit.Focus();
            }
        }
        private void POS_Load(object sender, EventArgs e)
        {
            items_HeaderBindingSource.AddNew();
        }
        private void POS_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void POS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                post();
                e.Handled = true;
            }
        }

        private void outletImageComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outletImageComboBoxEdit.EditValue.ToString() != string.Empty)
            {
                string location = outletImageComboBoxEdit.EditValue.ToString();
                var outitems = db.Category_locations.Where(o => o.Location == location).Select(u => u.Category).ToArray();

                itemsServicesBindingSource.DataSource = db.Items_Services.Where(o => outitems.Contains(o.Category)).ToList();
                outlet = outletImageComboBoxEdit.EditValue.ToString();
            }
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
                e.Valid = false; e.ErrorText = "Qty cannot be Empty";
                view.SetColumnError(colQty, e.ErrorText);
                return;
            }
            if (Convert.ToDouble(view.GetFocusedRowCellValue(colQty)) <= 0)
            {
                e.Valid = false; e.ErrorText = "Qty cannot be zero or Negative";
                view.SetColumnError(colQty, e.ErrorText);
                return;
            }

            if (view.GetRowCellValue(e.RowHandle, colUnit_Cost) == null)
            {
                e.Valid = false; e.ErrorText = "Price cannot be Empty";
                view.SetColumnError(colUnit_Cost, e.ErrorText);
                return;

            }
            if (Convert.ToDouble(view.GetFocusedRowCellValue(colUnit_Cost)) <= 0)
            {
                e.Valid = false; e.ErrorText = "Price cannot be zero or Negative";
                view.SetColumnError(colUnit_Cost, e.ErrorText);
                return;
            }
        }

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Missing Data";
            e.ErrorText = e.Exception.Message;
           
            gridView1.HideEditor();


        }

        private void repositoryItemTextEdit1_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }

        private void repositoryItemGridLookUpEdit1_Popup(object sender, EventArgs e)
        {
            
        }

        private void repositoryItemGridLookUpEdit1_BeforePopup(object sender, EventArgs e)
        {
             }

        private void repositoryItemGridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (outletImageComboBoxEdit.EditValue.ToString() == String.Empty)
            {
                e.Cancel = true;
                MessageBox.Show("Please select the Outlet");
   
            }
        }

        Items_Services_List c;
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //try
            //{
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
             c = (Items_Services_List)view.GetFocusedRow();
            Items_Header ih = ((Items_Header)items_HeaderBindingSource.Current);
            c.Outlet = ih.Outlet;
            switch (e.Column.Name)
            {
                case "colItem":
                    if (c != null)
                    {
                        var its = db.Items_Services.FirstOrDefault(o => o.Code == c.Item);
                        if (its != null && its.Type != null)
                        {
                            c.Type = (int)its.Type;
                            c.Category = its.Category;
                        }

                        if (c.Type == 1)
                        {
                            var price = db.Items_Services.FirstOrDefault(o => o.Code == c.Item).Price;
                            view.SetRowCellValue(e.RowHandle, colUnit_Cost, price.ToString());
                        }
                    }
                    view.SetRowCellValue(e.RowHandle, colVariant, "");
                    c.Qty = 0;
                    c.Unit_Cost = 0;
                    c.Balance = 0;
                    c.Total_Cost = 0;
                    break;
               
                   

                case "colQty":
                   
                    break;
                case "Unit_Cost":
                    if (c != null)
                    { c.Total_Cost = c.Unit_Cost * c.Qty; }
                    break;
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    Logging.Logging.ReportError(ex);
            //}
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column = view.FocusedColumn;
            if (c.Item == null && column != colItem)
            {
                e.Valid = false;
                e.ErrorText = string.Format("Select stock item ", c.Item_Name, e.Value);
                view.SetColumnError(colItem, e.ErrorText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                view.SetFocusedValue(null);
                return;
            }
            if (e.Value != null && e.Value.ToString() != string.Empty)
                switch (column.Name)
                {
                    case "colItem":
                        view.SetColumnError(column, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
                        break;
                    case "colVariant":
                        var prices = rice.prices.FirstOrDefault(o => o.Item_No_ == c.Item && o.Variant_Code == e.Value.ToString() && o.Sales_Type == (int)sales_TypeImageComboBoxEdit.EditValue);
                        double price = 0;
                        if (prices != null)
                            price = (double)prices.Unit_Price;

                        view.SetFocusedRowCellValue(colUnit_Cost, price.ToString());
                        // c.Unit_Cost =(decimal)price;            
                        q = rice.Itembalance(c.Item, e.Value.ToString(), c.Outlet);
                        view.SetFocusedRowCellValue(colBalance, q);
                        if (q < 1)
                        {
                        e.Valid = false;
                            //MessageBox.Show(string.Format("{0} is out of stock. ", c.Item_Description));
                            e.ErrorText = string.Format("{0} {1} is out of stock. ", c.Item_Name, e.Value);
                            view.SetColumnError(colItem, string.Format("{0} {1} is out of stock.", c.Item_Name, e.Value), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);

                            view.SetFocusedValue(null);

                            //db.Items_Services_List.Remove((Items_Services_List)gridView1.GetFocusedRow());
                            //items_Services_ListBindingSource.RemoveCurrent();
                            //gridView1.CancelUpdateCurrentRow();
                            return;
                        }
                        else

                            view.SetColumnError(column, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);

                        break;

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
        private void items_Services_ListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (items_Services_ListBindingSource.Current != null)
                c = (Items_Services_List)items_Services_ListBindingSource.Current;
        }
    private void gridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Missing Data";
           
            
            gridView1.HideEditor();
        }
    }
}
