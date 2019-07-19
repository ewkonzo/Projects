using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
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
    public partial class Items__and_services : Form
    {
        Navigation navigation;
        public RiceEntities db = new RiceEntities(rice.ConnectionString());
        public Items__and_services()
        {
            InitializeComponent();
            navigation = new Navigation(items_HeaderBindingSource, null, db,false,false);
            this.Controls.Add(navigation);
            navigation.navigationribbon.Pages[0].Groups.Insert(0, ribbonControl1.Pages[0].Groups[0]);// .MergeRibbon(ribbonControl1);
            ribbonControl1.Visible = false;
            try
            {
                //Task task = Task.Factory.StartNew(() =>
                //            {

                                items_HeaderBindingSource.DataSource = db.Items_Headers.Where(o => o.Posted == false).ToList();
                                if (items_HeaderBindingSource.Count == 0)
                                    items_HeaderBindingSource.AddNew();
                                var outitems = db.Category_locations.Where(o => o.Location == rice.setup.POS_Outlet).Select(u => u.Category).ToArray();
                                itemsServicesBindingSource.DataSource = db.Items_Services.Where(o => outitems.Contains(o.Category)).ToList();
                                //itemsServicesBindingSource.DataSource = db.Items_Services.ToList();
                                FarmerlistbindingSource.DataSource = db.Farmers.ToArray();
                                variantBindingSource.DataSource = db.Variants.ToList();
                            //}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
        }
       Items_Header itemheader ;
        private void items_HeaderBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            groupControl1.Enabled = items_HeaderBindingSource.Current != null;
            if (items_HeaderBindingSource.Current != null)
            {
               itemheader= (Items_Header)items_HeaderBindingSource.Current;
                    items_Services_ListBindingSource.DataSource = db.Items_Services_List.Where(o => o.Receipt_No == ((Items_Header)items_HeaderBindingSource.Current).Collection_No).ToList();

                
            }
            else
            {
                itemheader =null;
                items_Services_ListBindingSource.DataSource = null;
              
            }
        }
        private void memberitemservices()
        {
            //try
            //{


            //}
            //catch (Exception ex)
            //{
            //    Logging.Logging.ReportError(ex);
            //}
        }
        private void farmerTextEdit_Leave(object sender, EventArgs e)
        {
            //Task task = Task.Factory.StartNew(() =>
            //{
                if (farmerTextEdit.EditValue != null)
                {
                
                    var farmer = db.Farmers.FirstOrDefault(o => o.No == farmerTextEdit.EditValue.ToString()  );
                    farmerBindingSource.DataSource = farmer;
                    if (farmer!= null){
                    items_Services_ListGridControl.Enabled = farmer.Serviced_Acres >0;
                    if ((Members.Status)farmer.Status != Members.Status.Active)
                        MessageBox.Show("Farmer Account is not Active");
                    if (farmer.Serviced_Acres == null || farmer.Serviced_Acres==0)
                        MessageBox.Show("Farmer has not applied for service agreement.");

                    }
                    

                   
                    
                    
                    

                }
            //}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void items_HeaderBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Items_Header sh = null;
                sh = new Items_Header();
                sh.Date = DateTime.Now.Date;
                sh.Collection_No = String.Format("{0}{1}{2}{3}{4}{5}{6}", rice.setup.POS_Outlet, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                sh.Posted = false;
                sh.Season = rice.setup.Current_crop;
                sh.User_Name = rice.user.Name;
                sh.Outlet = rice.setup.POS_Outlet;
                sh.Reference = sh.Collection_No;
                sh.Sales_Type = (int)ItemHeader.Sales_Type.Members;
                sh.Payment_Mode = (int)ItemHeader.Payment_Mode.Credit;
                e.NewObject = sh;
                //db.Items_Headers.Add(sh);
                //farmerBindingSource.DataSource = null;
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void items_Services_ListBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Items_Services_List sh = new Items_Services_List();
                if (items_HeaderBindingSource.Current != null)
                {
                    var h = (Items_Header)items_HeaderBindingSource.Current;
                    sh.Farmer = h.Farmer;
                    sh.Receipt_No = h.Collection_No;
                    sh.Source_no = (int)h.Entry;
                    sh.Entry_Type=(int)ItemList.Type.Items;
                    sh.Recid =  DateTime.Now.Ticks;
                    sh.Date = h.Date;
                    sh.User = rice.user.Name;
                    sh.Time = DateTime.Now;
                    sh.Season = rice.setup.Current_crop;
                    sh.Outlet = rice.setup.POS_Outlet;
                    sh.Sales_Type = (int)ItemHeader.Sales_Type.Members;
                    sh.Payment_Mode = (int)ItemHeader.Payment_Mode.Credit;
                    e.NewObject = sh;
                  //  db.Items_Services_List.Add(sh);
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //try
            //{
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            var c = (Items_Services_List)view.GetFocusedRow();
      
            if (e.Value != null)
            switch (e.Column.Name)
            {
                case "colItem":
                    if (c != null)
                    {
                        c.Variant ="";
                        c.Qty = 0;
                        c.Unit_Cost = 0;
                        c.User = rice.user.Name;
                        c.Total_Cost = 0;
                        c.Balance = 0;
                        c.Item = e.Value.ToString();
                        var its = db.Items_Services.FirstOrDefault(o => o.Code == c.Item);
                        if (its != null && its.Type != null)
                            c.Type = (int)its.Type;
                        if (c.Type == 1)
                        {
                            var price = db.Items_Services.FirstOrDefault(o => o.Code == c.Item).Price;
                            c.Unit_Cost = (decimal)price;

                            // view.SetRowCellValue(e.RowHandle, Unit_Cost, price.ToString());
                        }
                       
                    }
                    var v = db.Variants.Where(o => o.Item_Code == e.Value.ToString()).ToArray();
                    if (v.Count() == 1)
                    {
                        c.Variant = v.FirstOrDefault().Code;

                        var price = db.Sales_Prices.FirstOrDefault(o => o.Item_No_ == c.Item && o.Variant_Code == c.Variant && o.Sales_Type == (int)Prices.Sales_Type.Members);
                        c.Unit_Cost = (decimal)(price == null ? 0 : price.Unit_Price);
                          
                        c.Balance = rice.Itembalance(c.Item, c.Variant, rice.setup.POS_Outlet);
                    }
                    //view.SetRowCellValue(e.RowHandle, colVariant, "");
                    break;
                case "colVariant":
                    if (!e.Value.ToString().Equals(""))
                    {
                        c.Qty = 0;
                        c.Total_Cost = 0;
                        c.Variant = e.Value.ToString();
                      
                        if (c.Type == 1)
                        {
                            var price = db.Items_Services.FirstOrDefault(o => o.Code == c.Item);
                       
                                c.Unit_Cost = (decimal)(price==null?0:price.Price );
                        }
                        else
                        {
                            var price = db.Sales_Prices.FirstOrDefault(o => o.Item_No_ == c.Item && o.Variant_Code == e.Value.ToString() && o.Sales_Type == (int)Prices.Sales_Type.Members);
                            c.Unit_Cost = (decimal)(price == null ? 0 : price.Unit_Price);
                          c.Balance = rice.Itembalance(c.Item, c.Variant, rice.setup.POS_Outlet);
                            //view.SetRowCellValue(e.RowHandle, Unit_Cost, price.ToString());
                        }
                    }
                    break;
                case "colQty":
                    if (c != null)
                    { c.Total_Cost = c.Unit_Cost * c.Qty; }
                    break;
                case "Unit_Cost":
                    if (c != null)
                    { c.Total_Cost = c.Unit_Cost * c.Qty; }
                    break;
            }
            //}
            //catch (Exception ex)
            //{
            //    Logging.Logging.ReportError(ex);
            //}
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {

        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                ColumnView view = (ColumnView)sender;

                if (view.FocusedColumn.Name == "colVariant")
                {
                    GridLookUpEdit edit = (GridLookUpEdit)view.ActiveEditor;
                    string item = (string)view.GetFocusedRowCellValue(colItem);
                    //  (string)gridView1.GetFocusedRowCellValue("colItem");
                    // itemVariantBindingSource.DataSource= db.Item_Variants.Where(o => o.No == item).ToArray();
                    edit.Properties.DataSource = db.Variants.Where(o => o.Item_Code == item).ToArray();
                    //edit.Properties.DisplayMember = "Description";
                    //edit.Properties.ValueMember = "Code";
                }

            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void btnpost_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnprint":
                    if (items_HeaderBindingSource.Current != null)
                    {                      
                        if ((gridView1.PostEditor() && gridView1.UpdateCurrentRow()))
                        { 
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
                                    i.Posted =1;
                                    items.Add(i);
                                }
                            }
                            db.Items_Services_List.AddRange(items);

                            h.Posted = true;
                           
                            db.SaveChanges();
                            Reports.SupplyNote report = new Reports.SupplyNote();
                            report.ith = db.Items_Headers.FirstOrDefault(o => o.Entry == h.Entry);
                            Task.Factory.StartNew(() =>
                            {
                                using (ReportPrintTool printTool = new ReportPrintTool(report))
                                {
                                    for (int i = 1; i <= rice.setup.Inputs_Receipts; i++)
                                    {
                                        printTool.Print();
                                    }
                                }
                            });
                            var itemlist = db.Items_Headers.Where(o => o.Posted == false).ToList();
                            items_HeaderBindingSource.DataSource = itemlist;
                            if (itemlist.Count == 0)
                                items_HeaderBindingSource.AddNew();
                        }
                    }
                    break;
                case "btnpost":
                    if ((gridView1.PostEditor() && gridView1.UpdateCurrentRow()))
                        db.SaveChanges(RiceEntities.Savetype.ShowMessage);
                    break;
            }
        }
        private void btnprint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

         
        }

        private void items_Services_ListGridControl_ProcessGridKey(object sender, KeyEventArgs e)
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
            db.Items_Services_List.Remove(( Items_Services_List)e.Row);
        }

        private void items_Services_ListBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
        
   
        }

        private void farmerTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                if (!string.IsNullOrEmpty(farmerTextEdit.EditValue.ToString()))
                {
                    var farmer = db.Farmers.FirstOrDefault(o => o.No == farmerTextEdit.EditValue.ToString() && (Members.Status)o.Status == Members.Status.Active);
                    if (farmer != null)
                        farmerBindingSource.DataSource = farmer;
                    else
                        farmerBindingSource.DataSource = typeof(Farmer);
                }
                else
                    farmerBindingSource.DataSource = typeof(Farmer);
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void gridView1_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Missing Data";


            gridView1.HideEditor();
        }

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Missing Data";


            gridView1.HideEditor();
        }
        Items_Services_List c;
        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            c = (Items_Services_List)view.GetFocusedRow();
            GridColumn column = view.FocusedColumn;
            if (c != null)
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
                        var itemserviceslist = db.Items_Services_List.Where(o => o.Farmer == itemheader.Farmer && o.Item == e.Value.ToString()).ToList();
                        if (itemserviceslist.Count() > 0)
                        {
                            var item = db.Items_Services.FirstOrDefault(o => o.Code ==(string) e.Value);
                            string items = string.Empty;
                            foreach (var dd in itemserviceslist)
                            {
                                items += string.Format("{0} {1}\n", (double)(dd.Qty??0), dd.Item_Description);
                            }
                            string message = String.Format("{0}({1})\n has been issued with the following items\n{2}Do you want to issue more?", itemheader.Farmerrecord.Name, itemheader.Farmer, items);
                            string caption = "Inputs Issued";
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result;
                            // Displays the MessageBox.
                            result = MessageBox.Show(this, message, caption, buttons,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (result == DialogResult.No)
                            {
                                try { view.DeleteSelectedRows();
                                }
                                catch (Exception ex) { }
                            }
                        }
                        break;
                    case "colVariant":
                        if (string.IsNullOrEmpty(e.Value.ToString()))
                        {
                            e.Valid = false;
                            view.SetColumnError(colItem, string.Format("Variant is required.", c.Item_Name, e.Value), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                            view.SetFocusedValue(null);
                            return;
                        }
                        break;

                    case "colQty":
                        if (string.IsNullOrEmpty(c.Variant))
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

            if (view.GetRowCellValue(e.RowHandle, Unit_Cost) == null)
            {
                e.Valid = false; e.ErrorText = "Price cannot be Empty";
                view.SetColumnError(Unit_Cost, e.ErrorText);
                return;

            }
            if (Convert.ToDouble(view.GetFocusedRowCellValue(Unit_Cost)) <= 0)
            {
                e.Valid = false; e.ErrorText = "Price cannot be zero or Negative";
                view.SetColumnError(Unit_Cost, e.ErrorText);
                return;
            }
        }

        private void farmerTextEdit_TextChanged(object sender, EventArgs e)
        {

        }

        private void items_HeaderBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
           // e.ListChangedType = ListChangedType.ItemDeleted
                
        }

        private void dateDateEdit_EditValueChanged(object sender, EventArgs e)
        {
             //int rHandle = -1;
             //while (gridView1.IsValidRowHandle(rHandle)){
             //    var r = (Items_Services_List)gridView1.GetRow(rHandle);
             //    r.Date = (DateTime)dateDateEdit.EditValue;
             //   rHandle -= 1;
             //}
        }

    }
}
