using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
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
    public partial class Debts : Form
    {
        AutoweighEntities db = new AutoweighEntities(coffee.ConnectionString());
        public Debts()
        {
            try
            {
                InitializeComponent();
                itemBindingSource.DataSource = db.Items.ToList();
                //storeBindingSource.DataSource = db.Stores.ToList();
                itemVariantBindingSource.DataSource = db.Item_Variants.ToList();
                stores_headerBindingSource.DataSource = db.Stores_headers.Where(o => o.Posted == false).ToList();
                foreach (var item in Enum.GetValues(typeof(server.Paymode)))
                    paymodeImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void amountLabel_Click(object sender, EventArgs e)
        {

        }

        private void amountSpinEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Debts_Load(object sender, EventArgs e)
        {

        }

        private void clientTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!clientTextEdit.Text.Equals(""))
                {
                    using (var db = new AutoweighEntities(coffee.ConnectionString()))
                    {
                        var name = db.Farmers.FirstOrDefault(o => o.No == clientTextEdit.Text);
                        if (name != null)
                        {
                            lblclientname.Text = name.Name;
                            lblcherry.Text = string.Format("Cherry: {0} Mbuni: {1}", name.Cum_Cherry.ToString(), name.Cum_Mbuni.ToString());
                            label3.Text = name.Other_Loans.ToString();
                        }
                    }
                }
                else
                {
                    lblclientname.Text = "";
                    lblcherry.Text = "";
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void totalLabel_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                ColumnView view = (ColumnView)sender;
                using (var db = new AutoweighEntities(coffee.ConnectionString()))
                {
                    if (view.FocusedColumn.Name == "colVariant")
                    {
                        LookUpEdit edit = (LookUpEdit)view.ActiveEditor;
                        string item = (string)view.GetFocusedRowCellValue(colItem);
                        //  (string)gridView1.GetFocusedRowCellValue("colItem");
                        // itemVariantBindingSource.DataSource= db.Item_Variants.Where(o => o.No == item).ToArray();
                        edit.Properties.DataSource = db.Item_Variants.Where(o => o.No == item).ToArray();
                        //edit.Properties.DisplayMember = "Description";
                        //edit.Properties.ValueMember = "Code";
                    }
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (!clientTextEdit.Text.Equals(""))
                {
                  
                }
                else
                {
                    clientTextEdit.ErrorText = "Client No is required";
                    view.CancelUpdateCurrentRow();
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }
        List<Stock> stock;

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                switch (e.Column.Name)
                {

                    case "colAmount":

                        if (!e.Value.ToString().Equals(""))

                            if (view.GetRowCellValue(e.RowHandle, colQuantity) != null)
                                if (!view.GetRowCellValue(e.RowHandle, colQuantity).ToString().Equals(""))
                                    view.SetRowCellValue(e.RowHandle, colLine_total, (double)view.GetRowCellValue(e.RowHandle, colQuantity) * (double)view.GetRowCellValue(e.RowHandle, colAmount));
                        break;
                    case "colQuantity":
                        if (!e.Value.ToString().Equals(""))
                        {
                            using (var db = new AutoweighEntities(coffee.ConnectionString()))
                            {
                                if (view.GetRowCellValue(e.RowHandle, colAmount) != null)
                                    if (!view.GetRowCellValue(e.RowHandle, colAmount).ToString().Equals(""))
                                        view.SetRowCellValue(e.RowHandle, colLine_total, (double)view.GetRowCellValue(e.RowHandle, colQuantity) * (double)view.GetRowCellValue(e.RowHandle, colAmount));
                                double qty = (double)e.Value;
                                var s = stock.OrderBy(o => o.Date_Added).FirstOrDefault(o => o.quantity_Bal > 0);
                                double totalqty = qty;
                                if (totalqty <= s.quantity_Bal)
                                {
                                    view.SetRowCellValue(e.RowHandle, colStock, s.Document_No);

                                    totalqty -= qty;
                                }
                                else
                                {
                                    Store sto = (Store)view.GetFocusedRow();
                                    view.SetRowCellValue(e.RowHandle, colStock, s.Document_No);

                                    //view.SetRowCellValue(e.RowHandle, colQuantity, s.quantity_Bal);
                                    var c = db.Stores.FirstOrDefault();
                                    if (c != null)
                                    {
                                        c.Quantity = s.quantity_Bal;
                                        c.Stock = s.Document_No;
                                    }
                                    stock.Remove(s);
                                    s = stock.FirstOrDefault(o => o.quantity_Bal > 0);

                                    Store store = new Store();
                                    store = sto;
                                    store.Stock = s.Document_No;
                                    store.Amount = (double)s.Unit_Price;
                                    store.Quantity = totalqty;
                                    store.Line_total = store.Amount * store.Quantity;
                                    db.Stores.Add(store);
                                   // db.SaveChanges();
                                    storeBindingSource.DataSource = null;

                                    storeBindingSource.DataSource = db.Stores.Where(o => o.Entry == store.Entry).ToList();

                                }
                            }
                        }


                        break;
                    case "colVariant":
                        if (!e.Value.ToString().Equals(""))
                        {
                            using (var db = new AutoweighEntities(coffee.ConnectionString()))
                            {
                                var s = (Store)view.GetFocusedRow();
                                stock = db.Stocks.Where(o => o.Variant == s.Variant && o.Item == s.Item).OrderBy(o => o.Date_Added).ToList();
                                stockBindingSource.DataSource = stock;

                                string item = view.GetRowCellValue(e.RowHandle, colItem).ToString();
                                var dd = db.Item_Variants.FirstOrDefault(o => o.Code == e.Value.ToString() && o.No == item).Price;
                                view.SetRowCellValue(e.RowHandle, colAmount, dd.ToString());

                                var sold = db.Stores.Where(o => o.Item == item && o.Variant == e.Value);
                               double sol=0,stoc=0;
                               if (sold.Count() > 0)
                                   sol = (double)sold.Sum(o => o.Quantity);
                               if (stock.Count() > 0)
                                   stoc = (double)stock.Sum(o => o.Quantity);

                               view.SetRowCellValue(e.RowHandle, colBalance, (stoc - sol));
                                     
                            }
                        }
                        break;


                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }
        Stores_header sh = null;
        private void stores_headerBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                sh = new Stores_header();
                sh.Date = DateTime.Now.Date;
                sh.Entry = DateTime.Now.Ticks.ToString();
                sh.Posted = false;
                sh.Paymode = (int)server.Paymode.Credit;
                e.NewObject = sh;
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void stores_headerBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (stores_headerBindingSource.Current != null)
                {
                    storeBindingSource.DataSource = new AutoweighEntities(coffee.ConnectionString()).Stores.Where(o => o.Entry == ((Stores_header)stores_headerBindingSource.Current).Entry).ToList();
                    //storeBindingSource.DataSource = ((Stores_header)stores_headerBindingSource.Current).Store_lines.ToList();
                    toolpost.Enabled = true;
                    clientTextEdit.Enabled = true;
                    storeGridControl.Enabled = true;
                }
                else
                {
                    storeBindingSource.DataSource = null;
                    toolpost.Enabled = false;
                    clientTextEdit.Enabled = false;
                    storeGridControl.Enabled = false;
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                if (sh != null)
                {
                    db.Stores_headers.Add(sh);
                    sh = null;
                }
                //db.SaveChanges();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }


        }

       
        private void storeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if ((gridView1.PostEditor() && gridView1.UpdateCurrentRow()))
            {
                db.SaveChanges(true);
            }
        }

        private void dateLabel_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (colLine_total.SummaryItem.SummaryValue != null)
                    totalSpinEdit.Text = colLine_total.SummaryItem.SummaryValue.ToString();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            var dd = "";
            db.Stores.Remove((Store)e.Row);
        }

        private void toolpost_Click(object sender, EventArgs e)
        {
            try
            {
                if ((gridView1.PostEditor() && gridView1.UpdateCurrentRow()))
                {
                    //gridView1.EndUpdate();
                    double t = Convert.ToDouble(colLine_total.SummaryItem.SummaryValue);
                    if (t == 0)
                    {
                        MessageBox.Show("Amount cannot be zero");
                        return;
                    }
                    DialogResult d = MessageBox.Show("Are you sure you want to Post this receipt", "Post Store", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        ((Stores_header)stores_headerBindingSource.Current).Posted = true; ;
                        db.SaveChanges();
                        var a = db.Stores.Where(o => o.Entry == ((Stores_header)stores_headerBindingSource.Current).Entry);
                        foreach (var ii in a)
                        {
                            ii.Sent = false;

                        }
                        db.SaveChanges();
                        var fr = new Reports.Storereceipt(db.Stores_headers.FirstOrDefault(o => o.Entry == ((Stores_header)stores_headerBindingSource.Current).Entry));
                        DevExpress.XtraReports.UI.ReportPrintTool pr = new DevExpress.XtraReports.UI.ReportPrintTool(fr);
                       pr.PrinterSettings.PrinterName = coffee.setup.Printer;
                        //pr.PrinterSettings.Copies = (short)(coffee.setup.Stores_receipts_copies == null ? 1 : coffee.setup.Stores_receipts_copies);
                        for (int i = 1; i <= coffee.setup.Stores_receipts_copies; i++)
                        {
                            pr.Print();
                        }
                        stores_headerBindingSource.DataSource = db.Stores_headers.Where(o => o.Posted == false).ToList();
                    }
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }

        }

        private void itemBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        private void storeBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {

        }

        private void stores_headerBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {

            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                var d = (Stores_header)stores_headerBindingSource.Current;
                if (d != null)
                {
                    var dd = coffee.Reversestore(d.Entry);
                    storeGridControl.RefreshDataSource();
                    db.Stores_headers.Remove(d);
                    //db.SaveChanges();


                }
            }
            catch (Exception ex) { }
        }

        private void storeBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                if (stores_headerBindingSource.Current != null)
                {
                    Stores_header ss = (Stores_header)stores_headerBindingSource.Current;
                    Store s = new Store();
                    s.Date = DateTime.Now.Date;
                    s.Entry = ss.Entry;
                    s.Date=(DateTime) dateDateEdit.EditValue;
                    s.Client = ss.Client;
                    s.Entry = ss.Entry;
                    s.Sent =false;
                    s.Served_By = coffee.user.Name;
                    s.Factory = coffee.setup.Branch;
                    s.Crop = coffee.setup.Current_crop;
                    e.NewObject = s;
                    db.Stores.Add(s);
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }
        Store c;
        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column = view.FocusedColumn;
          var  c = (Store)view.GetFocusedRow();
            if (e.Value != null && e.Value.ToString() != string.Empty)
                switch (column.Name)
                {                  
                    case "colVariant":
                        if (!String.IsNullOrEmpty(e.Value.ToString()))
                        {
                            var stock = db.Stocks.Where(o => o.Variant == e.Value.ToString() && o.Item == c.Item).OrderBy(o => o.Date_Added).ToList();
                            var sold = db.Stores.Where(o => o.Item == c.Item && o.Variant == e.Value.ToString());
                            double sol = 0, stoc = 0;
                       
                            if (sold.Count() > 0)
                                sol = (double)sold.Sum(o => o.Quantity);
                            if (stock.Count() > 0)
                                stoc = (double)stock.Sum(o => o.Quantity);
                            c.Balance = (int) (stoc - sol);
                            if (c.Balance < 0)
                            {
                                e.Valid = false;
                                //MessageBox.Show(string.Format("{0} is out of stock. ", c.Item_Description));
                                e.ErrorText = string.Format("{0} {1} is out of stock. ", c.Item_name, e.Value);
                                view.SetColumnError(colItem, string.Format("{0} {1} is out of stock.", c.Item_name, e.Value), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);

                                return;
                            }
                            view.SetColumnError(column, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
                        }
                        break;
                    case "colQuantity":
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
                            e.ErrorText = string.Format("{0} in stock is less that qty entered. ", c.Item_description);
                            view.SetColumnError(column, e.ErrorText);
                            e.Value = "";
                            //db.Items_Services_List.Remove((Items_Services_List)gridView1.GetFocusedRow());    items_Services_ListBindingSource.RemoveCurrent();

                            //gridView1.CancelUpdateCurrentRow();
                            return;
                        }
                        
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
            if (view.GetFocusedRowCellValue(colQuantity) == null)
            {
                e.Valid = false; e.ErrorText = "Qty cannot be Empty";
                view.SetColumnError(colQuantity, e.ErrorText);
                return;
            }
            if (Convert.ToDouble(view.GetFocusedRowCellValue(colQuantity)) <= 0)
            {
                e.Valid = false; e.ErrorText = "Qty cannot be zero or Negative";
                view.SetColumnError(colQuantity, e.ErrorText);
                return;
            }
            if (view.GetRowCellValue(e.RowHandle, colAmount) == null)
            {
                e.Valid = false; e.ErrorText = "Price cannot be Empty";
                view.SetColumnError(colAmount, e.ErrorText);
                return;
            }
            if (Convert.ToDouble(view.GetFocusedRowCellValue(colAmount)) <= 0)
            {
                e.Valid = false; e.ErrorText = "Price cannot be zero or Negative";
                view.SetColumnError(colAmount, e.ErrorText);
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
    }
}
