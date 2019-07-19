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
    public partial class Sales : Form
    {
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        Navigation navigation;
        public Sales()
        {

            InitializeComponent();
            navigation = new Navigation(items_Services_ListBindingSource, items_Services_ListGridControl, db, false, false);
            this.Controls.Add(navigation);

            foreach (var item in Enum.GetValues(typeof(ItemList.Payment_Mode)))
                paymoderepo.Items.Add(item.ToString(), (int)item, -1);
            foreach (var item in Enum.GetValues(typeof(ItemList.Payment_Mode)))
                payment_ModeImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);
foreach (var item in Enum.GetValues(typeof(ItemList.Sales_Type)))
                salestyperipo.Items.Add(item.ToString(), (int)item, -1);

              Task task = Task.Factory.StartNew(() =>
              {
                  items_Services_ListBindingSource.DataSource = db.Items_Services_List.Where(o => o.Outlet == rice.setup.POS_Outlet).ToList();
              }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

              groupControl1.Left = (this.ClientSize.Width - groupControl1.Width) / 2;
              groupControl1.Top = (this.ClientSize.Height - groupControl1.Height) / 2;
        }
        private void Sales_Load(object sender, EventArgs e)
        {
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                GridView view = sender as GridView;
                view.FocusedRowHandle = e.HitInfo.RowHandle;
                contextMenuStrip1.Show(view.GridControl, e.Point);


            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Hide();
            switch (e.ClickedItem.Name)
            {
                case "filterByThisValueToolStripMenuItem":
                    gridView1.ActiveFilterString = "[" + gridView1.FocusedColumn.FieldName + "] = '" + gridView1.FocusedValue + "'";
                    break;
                case "changePayModeToolStripMenuItem":
                    groupControl1.Visible = true;
                    break;
 case "reprintReceiptToolStripMenuItem":
                    var cc = ((Items_Services_List)gridView1.GetRow(gridView1.FocusedRowHandle));
                    Items_Header ih = db.Items_Headers.FirstOrDefault(o => o.Collection_No == cc.Receipt_No);

                    Task task = Task.Factory.StartNew(() =>
                    {
                        Reports.Sales_Receipt s = new Reports.Sales_Receipt();
                        s.i = ih;
                        using (ReportPrintTool printTool = new ReportPrintTool(s))
                        {
                            if (!string.IsNullOrEmpty(rice.setup.Sales_receipt_Printer))
                                printTool.PrinterSettings.PrinterName = rice.setup.Sales_receipt_Printer;
                            printTool.Print();
                        }
                    });
                    break;
                case "reverseToolStripMenuItem":
                    string message = "Are you sure you want to reverse the current item?";
                    string caption = "Reverse Item";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);

                    if (result == DialogResult.Yes)
                    {


                        GridView view = sender as GridView;

                        var c = ((Items_Services_List )gridView1.GetRow(gridView1.FocusedRowHandle));

                        var ee = db.Item_Reversals.FirstOrDefault(o => o.Reversal_Id == c.Entry.ToString() && o.Entry_Type == (int)Reversals.Entry_Type.Sale);

                        if (ee != null)
                        {
                            MessageBox.Show("There is already a request/reversal for this item please wait until this is approved.","Reversal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        Item_Reversal r = new Item_Reversal();
                        r.Date = DateTime.Now.Date;
                        r.Time = DateTime.Now;
                        r.Reversal_Id = c.Entry.ToString(); 
                        r.Location = c.Outlet;
                        r.Status = (int)Reversals.Status.Pending;
                        r.Entry_Type = (int)Reversals.Entry_Type.Sale;
                        r.Reversed_By = rice.user.Name;
                        r.Item = c.Item;
                        r.Variant = c.Variant;
                        c.Reversed = true;
                        db.Item_Reversals.Add(r);
                        db.SaveChanges();
                        MessageBox.Show("Reversal request sent, once the reversal has been approved the record will be reversed.", "Reversal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(items_Services_ListBindingSource.Current!= null)
            {
                var itemlist = (Items_Services_List)items_Services_ListBindingSource.Current;
                var it = db.Items_Services_List.Where(o => o.Receipt_No == itemlist.Receipt_No);
                foreach (var item in it)
                {
                    item.Payment_Mode = (int)payment_ModeImageComboBoxEdit.EditValue;
                    item.Reference = referenceTextBox.Text;
                }
                db.SaveChanges();
                groupControl1.Visible = false;
            }
        }

        private void changePayModeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
  groupControl1.Visible = false;
        }
    }
}
