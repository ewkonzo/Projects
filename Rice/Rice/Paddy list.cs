using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rice
{
    public partial class Paddy_list : Form
    {
        public Paddy_Detail Selectedpaddy = null;
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        Navigation navigation1;
        RibbonControl mainribbon;
        List<Paddy_Detail> data;
        Task task;
        public Paddy_list()
        {
            InitializeComponent();
            // loaddata();
            navigation1 = new Navigation(null, paddy_DetailGridControl, db);

            this.Controls.Add(navigation1);
            foreach (RibbonPageGroup g in ribbonControl1.Pages[0].Groups)
            {
                navigation1.navigationribbon.Pages[0].Groups.Insert(0, g);
            }
            //Task t = Task.Run(() => ).ContinueWith(tt => loaddata(), TaskScheduler.FromCurrentSynchronizationContext());

            loadcombos();
            loaddata();
            gridView1.BestFitColumns();

        }
        private void loadcombos()
        {
            ribbonControl1.Visible = false;
            foreach (var item in Enum.GetValues(typeof(Collections.Collect_type)))
                collecttyperepository.Items.Add(item.ToString(), (int)item, -1);
            foreach (var item in Enum.GetValues(typeof(Collections.Type)))
                typerepository.Items.Add(item.ToString(), (int)item, -1);
            foreach (var item in rice.items)
                varietyrepository.Items.Add(item.Name, item.Code, -1);
            foreach (var item in Enum.GetValues(typeof(Collections.Status)))
                statusrepository.Items.Add(item.ToString(), (int)item, -1);
            rice.populatelists();
        }
        private void loaddata()
        {

            paddy_DetailBindingSource.DataSource = db.Paddy_Details.ToList();
            gridView1.ExpandGroupRow(1);
        }
        public DialogResult ShowDialog(List<Paddy_Detail> p)
        {
            paddy_DetailBindingSource.DataSource = p;
            panel1.Visible = true;
            gridView1.BestFitColumns();
            return base.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Selectedpaddy = (Paddy_Detail)gridView1.GetFocusedRow();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);
        }
        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                simpleButton1_Click(null, null);
            }
        }

        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btndelivery":
                    using (var f = new Paddy())
                    {
                        var result = f.ShowDialog(true);
                    }
                    break;
                case "btnweigh":
                    using (Form f = new Weigh())
                    {
                        var result = f.ShowDialog();
                    }
                    break;
                case "btnviewdelivery":
                    using (var f = new Paddy())
                    {
                        var result = f.ShowDialog(paddy_DetailBindingSource.Position);
                    }
                    break;
                case "printdelivery":
                  rice.  bags = db.Paddy_Bags.ToList();
                    Paddy_Detail p = (Paddy_Detail)gridView1.GetFocusedRow();
                    switch ((Collections.Collect_type)p.Collect_type)
                    {
                        case Collections.Collect_type.Member:
                            Reports.Delivery report = new Reports.Delivery();
                            report.p = p;
                            using (ReportPrintTool printTool = new ReportPrintTool(report))
                                printTool.PrintDialog();
                            break;
                        case Collections.Collect_type.Non_Member:
                            Reports.DeliveryCustomer rr = new Reports.DeliveryCustomer();
                            rr.p = p;
                            using (ReportPrintTool printTool = new ReportPrintTool(rr))
                                printTool.PrintDialog();
                            break;
                    } break;
                case "printweighslip":
                    rice.bags = db.Paddy_Bags.ToList();
                    Paddy_Detail pp = (Paddy_Detail)gridView1.GetFocusedRow();
                    switch ((Collections.Collect_type)pp.Collect_type)
                    {
                        case Collections.Collect_type.Member:
                            Reports.Weighslip r = new Reports.Weighslip();
                            r.p = pp;
                            using (ReportPrintTool printTool = new ReportPrintTool(r))
                            {
                                printTool.PrintDialog();
                            }
                            break;
                        case Collections.Collect_type.Non_Member:
                            Reports.Weighslipcustomer rc = new Reports.Weighslipcustomer();
                            rc.p = pp;
                            using (ReportPrintTool printTool = new ReportPrintTool(rc))
                            {
                                printTool.PrintDialog();
                            }
                            break;
                    }
                            break;
                case "btnviewbags":
                    var c = ((Paddy_Detail)gridView1.GetRow(gridView1.FocusedRowHandle));
                    if (c != null)
                    {
                        using (var form = new Bags())
                        {
                            form.StartPosition = FormStartPosition.CenterParent;
                            var result = form.ShowDialog(c.BagsWeighed.ToArray(), db);
                        }
                    }
                    break;
            }
        }
     private void Paddy_list_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Paddy_list_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Hide();
            switch (e.ClickedItem.Name)
            {
                case "filterByThisValueToolStripMenuItem":
                    gridView1.ActiveFilterString = "[" + gridView1.FocusedColumn.FieldName + "] = '" + gridView1.FocusedValue + "'";
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

                        var c = ((Item_Movement)gridView1.GetRow(gridView1.FocusedRowHandle));

                        var ee = db.Item_Reversals.FirstOrDefault(o => o.Reversal_Id == c.Entry.ToString() && o.Entry_Type == (int)Reversals.Entry_Type.Movement);
                        if (ee != null)
                        {
                            MessageBox.Show("There is already a request/reversal for this item please wait until this is approved.", "Reversal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        Item_Reversal r = new Item_Reversal();
                        r.Date = DateTime.Now.Date;
                        r.Time = DateTime.Now;
                        r.Reversal_Id = c.Entry.ToString(); ;
                        r.Location = c.Location;
                        r.Status = (int)Reversals.Status.Pending;
                        r.Entry_Type = (int)Reversals.Entry_Type.Movement;
                        r.Reversed_By = rice.user.Name;
                        r.Reverse_document = false;
                        r.Reference = c.Reference;
                        r.Item = c.Item;
                        r.Variant = c.Variant;
                        switch ((Movement.Movement_Type)c.Movement_Type)
                        {
                            case Movement.Movement_Type.Convert:
                            case Movement.Movement_Type.Transfer:
                            case Movement.Movement_Type.Return:
                                r.Reverse_document = true;
                                r.Reference = c.Reference;
                                break;
                        }
                        db.Item_Reversals.Add(r);
                        db.SaveChanges();
                        MessageBox.Show("Reversal request sent, once the reversal has been approved the record will be reversed.", "Reversal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }

        private void Paddy_list_Enter(object sender, EventArgs e)
        {
            loaddata();
        }

        private void repositoryItemHypertextLabel1_OpenHyperlink(object sender, DevExpress.Utils.OpenHyperlinkEventArgs e)
        {

        }

        private void repositoryItemHyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {

        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
           
        }

        private void paddy_DetailGridControl_Click(object sender, EventArgs e)
        {

        }
    }
}
