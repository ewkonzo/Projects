using DevExpress.XtraGrid.Views.Base;
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

namespace Coffee
{
    public partial class Posted_Debts : Form
    {
        AutoweighEntities db = new AutoweighEntities(coffee.ConnectionString());
        public Posted_Debts()
        {
            InitializeComponent();
              Task task = Task.Factory.StartNew(() =>
            {

            //var q = from s in ps.Stores join sh in ps.Stores_headers on s.Entry equals sh.Entry where sh.Posted == true select s;
            itemBindingSource.DataSource = db.Items.ToList();
            // var binding = new BindingList<Store>(q.ToList());

            farmerBindingSource.DataSource = db.Farmers.ToList();
            storeBindingSource.DataSource = db.Stores.ToList();
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        public Posted_Debts(Item_Variant ss)
        {
            InitializeComponent();
            this.Text = String.Format("{0} - {1}", ss.Item_name.ToUpper(), ss.Code);
            //var q = from s in ps.Stores where s.Item ==ss.No && s.Variant == ss.Code join sh in ps.Stores_headers on s.Entry equals sh.Entry where sh.Posted == true select s;
            itemBindingSource.DataSource = db.Items.ToList();
            // var binding = new BindingList<Store>(q.ToList());

            farmerBindingSource.DataSource = db.Farmers.ToList();
            storeBindingSource.DataSource = db.Stores.ToList();

        }
        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BindingSource b = storeBindingSource;

            switch (e.Item.Name)
            {
                case "btndaily":

                    break;

                case "btnrefresh":
                    storeBindingSource.DataSource = db.Stores.ToList();
                    break;
                case "navfirst":
                    b.MoveFirst();
                    break;
                case "navnext":
                    b.MoveNext();
                    break;
                case "navprevious":
                    b.MovePrevious();
                    break;
                case "navlast":
                    b.MoveLast();
                    break;
                case "actionxlsx":
                    try
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel 2010|*.xlsx";
                        saveFileDialog1.Title = "Save list to File";
                        saveFileDialog1.ShowDialog();

                        // If the file name is not an empty string open it for saving.  
                        if (saveFileDialog1.FileName != "")
                        {
                            storeGridControl.ExportToXlsx(saveFileDialog1.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logging.Logging.ReportError(ex);
                        MessageBox.Show("Unable to save file");
                    }
                    break;
                case "actionxls":
                    try
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel File|*.xls";
                        saveFileDialog1.Title = "Save list to File";
                        saveFileDialog1.ShowDialog();

                        // If the file name is not an empty string open it for saving.  
                        if (saveFileDialog1.FileName != "")
                        {
                            storeGridControl.ExportToXls(saveFileDialog1.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logging.Logging.ReportError(ex);
                        MessageBox.Show("Unable to save file");
                    }
                    break;
                case "actionpdf":
                    try
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Pdf|*.pdf";
                        saveFileDialog1.Title = "Save list to File";
                        saveFileDialog1.ShowDialog();

                        // If the file name is not an empty string open it for saving.  
                        if (saveFileDialog1.FileName != "")
                        {
                            storeGridControl.ExportToPdf(saveFileDialog1.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logging.Logging.ReportError(ex);
                        MessageBox.Show("Unable to save file");
                    }
                    break;
            }
        }
        private void Posted_Debts_Load(object sender, EventArgs e)
        {

        }

        private void storeGridControl_Click(object sender, EventArgs e)
        {

        }

        private void Posted_Debts_Activated(object sender, EventArgs e)
        {

        }

        private void gridView1_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            //Stores_header p = (Stores_header)gridView1.GetRow(e.RowHandle);
            //e.IsEmpty = p.Store_lines.Count() == 0;
        }

        private void gridView1_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            //e.RelationCount = 1;
        }

        private void gridView1_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            //e.RelationName = "Stores";
        }

        private void gridView1_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            //Stores_header p = (Stores_header)gridView1.GetRow(e.RowHandle);
            //e.ChildList = p.Store_lines.ToList(); ;
        }
        private void cellcontext_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "filterWithThisValueToolStripMenuItem":
                    gridView1.ActiveFilterString = "[" + gridView1.FocusedColumn.FieldName + "] = '" + gridView1.FocusedValue + "'";
                    break;
                case "reverseThisReceiptToolStripMenuItem":
                    if (coffee.user.Type == "Admin")
                    {
                        string reverseentry = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colEntry).ToString();
                        var dd = coffee.Reversestore(reverseentry);
                        MessageBoxIcon m = (dd.Code == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation);
                        MessageBox.Show(dd.Desc, "Reversal", MessageBoxButtons.OK, m);
                        storeBindingSource.DataSource = null;
                        storeBindingSource.DataSource = db.Stores.ToList();
                        storeGridControl.RefreshDataSource();
                    }
                    else {
                        MessageBox.Show("Contact the administrator for this action");

                    }
                    break;
            }
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                cellcontext.Show(storeGridControl, e.Location);
            }
        }

        private void storeGridControl_Click_1(object sender, EventArgs e)
        {

        }

        private void reverseThisReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
