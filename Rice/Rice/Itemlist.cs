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
    public partial class Itemlist : Form
    {
        Navigation navigation;
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        public Itemlist()
        {
            
            InitializeComponent();

            navigation = new Navigation(items_Services_ListBindingSource,items_Services_ListGridControl, db,false);
            this.Controls.Add(navigation);
            navigation.navigationribbon.Pages[0].Groups.Insert(0, ribbonControl1.Pages[0].Groups[0]);
            ribbonControl1.Visible = false;
             Task task = Task.Factory.StartNew(() =>
             {
                 items_Services_ListBindingSource.DataSource = db.Items_Services_List.OrderByDescending(o=> o.Entry).ToList();
             }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

        }
        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnprint":

                    reprint();
                    break;
            
            }
        }
        public void reprint()
        {
            if (items_Services_ListBindingSource.Current != null)
            {
                Reports.SupplyNote report = new Reports.SupplyNote();
                report.ith = db.Items_Headers.FirstOrDefault(o => o.Collection_No == ((Items_Services_List)items_Services_ListBindingSource.Current).Receipt_No);
            //    Task.Factory.StartNew(() =>
            //{
                using (ReportPrintTool printTool = new ReportPrintTool(report))
                {

                    printTool.PrintDialog();
                }
            //});
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
                case "reprintSupplyNoteToolStripMenuItem":
                    reprint();
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
                        r.Qty =(int) c.Qty;
                        r.Variant = c.Variant;
                        c.Reversed = true;
                        db.Item_Reversals.Add(r);
                        db.SaveChanges();
                        MessageBox.Show("Reversal request sent, once the reversal has been approved the record will be reversed.", "Reversal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    break;
            }
        }
        private void btnprint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

    }
}
