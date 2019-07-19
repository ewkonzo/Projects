using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Threading.Tasks;
namespace Coffee
{
    public   partial  class Navigation : UserControl
    {
        private bool saveonchange = true;
        private   BindingSource bs;
        private  AutoweighEntities db;
        public object Selecteditem;
        private   DevExpress.XtraGrid.GridControl grid;

        public Navigation(BindingSource b, DevExpress.XtraGrid.GridControl g, AutoweighEntities e, Boolean edit = true, bool soc = true)
        {
            InitializeComponent();
         // Task.Factory.StartNew(() => {  
            bs = b;
            grid = g;
            db = e;
            saveonchange = soc;
                //   }); 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            if (bs != null)
            {
                bs.CurrentChanged += new EventHandler(BindingSource_CurrentChanged);
                bs.CurrentItemChanged += new EventHandler(BindingSource_CurrentItemChanged);
                bs.PositionChanged += new EventHandler(BindingSource_PositionChanged);

            }
            else
            {
                ribbonPageGroup1.Visible = false;

            }
            ribbonPageGroup3.Visible = edit;
            if (grid == null)
            {
                ribbonPageGroup2.Visible = false;
              //  ((GridView)grid.FocusedView).OptionsBehavior.ReadOnly = edit;
            }
           
            this.Dock = DockStyle.Top;
            this.SendToBack();
        }
        private void BindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            try
            {
                if (bs != null) 
                bs.EndEdit();
               
                if (saveonchange==true)
                    db.SaveChanges();
               
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
        }
        private void Navigation_Load(object sender, EventArgs e)
        {

            initializenav();
        }

        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BindingSource b = bs;

            switch (e.Item.Name)
            {
                case "btnrefresh":
                    if (grid != null)
                        grid.MainView.RefreshData();
                    break;

                case "btnclose":
                    ((Form)this.Parent).Close();
                    break;
                case "btnSelect":
                    db.SaveChanges();
                    this.Selecteditem = bs.Current;
                    ((Form)this.Parent).DialogResult = DialogResult.OK;
                    ((Form)this.Parent).Close();
                    break;
                case "btndelete":
                    if (bs != null)
                         if (bs.Current != null) if (bs.AllowRemove)
                                                  bs.RemoveCurrent();
                    break;
                case "btnnew":
                    bs.AddNew();
                    break;
                case "btnsave":
                    db.SaveChanges(true);
                    break;
                case "btnsavennew":
                    db.SaveChanges();
                    bs.AddNew();
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
                case "btnexcelx":
                    try
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel 2010|*.xlsx";
                        saveFileDialog1.Title = "Save list to File";
                        saveFileDialog1.ShowDialog();

                        // If the file name is not an empty string open it for saving.  
                        if (saveFileDialog1.FileName != "")
                        {
                            grid.ExportToXlsx(saveFileDialog1.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logging.Logging.ReportError(ex);
                        MessageBox.Show("Unable to save file");
                    }
                    break;
                case "btnexcel":
                    try
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel File|*.xls";
                        saveFileDialog1.Title = "Save list to File";
                        saveFileDialog1.ShowDialog();

                        // If the file name is not an empty string open it for saving.  
                        if (saveFileDialog1.FileName != "")
                        {
                            grid.ExportToXls(saveFileDialog1.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logging.Logging.ReportError(ex);
                        MessageBox.Show("Unable to save file");
                    }
                    break;
                case "btnpdf":
                    try
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Pdf|*.pdf";
                        saveFileDialog1.Title = "Save list to File";
                        saveFileDialog1.ShowDialog();

                        // If the file name is not an empty string open it for saving.  
                        if (saveFileDialog1.FileName != "")
                        {
                            grid.ExportToPdf(saveFileDialog1.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logging.Logging.ReportError(ex);
                        MessageBox.Show("Unable to save file");
                    }
                    break;
            }
            if (bs != null)
            {
               
                txtrecord.Caption = string.Format("of {0}", bs.Count);
            }
        }
        private void initializenav()
        {  if (bs != null) {
            txtrecord.EditValue = bs.Position + 1;
           
            txtrecord.Caption = string.Format("of {0}", bs.Count);

            if (bs.Position == 0)
            {
                navprevious.Enabled = false;
                navfirst.Enabled = false;
            }
            else
            {
                navprevious.Enabled = true;
                navfirst.Enabled = true;
            }

            if (bs.Position == bs.Count - 1)
            {
                navnext.Enabled = false;
                navlast.Enabled = false;
            }
            else
            {
                navnext.Enabled = true;
                navlast.Enabled = true;
            }
            }
        if (grid != null)
        {
           ((GridView) grid.FocusedView).OptionsBehavior.EditingMode = GridEditingMode.EditForm;

            

        }
        }
        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (bs.Current == null)
                disable();
            else { 
                enable();
              
             
            }

            if (bs.Position == 0)
            {
                navprevious.Enabled = false;
                navfirst.Enabled = false;
            }
            else
            {
                navprevious.Enabled = true;
                navfirst.Enabled = true;
            }

            if (bs.Position == bs.Count - 1)
            {
                navnext.Enabled = false;
                navlast.Enabled = false;
            }
            else
            {
                navnext.Enabled = true;
                navlast.Enabled = true;
            }
        }
        private void BindingSource_PositionChanged(object sender, EventArgs e)
        {
            txtrecord.EditValue = bs.Position+1;
        }
        private void enable()
        {
            navlast.Enabled = true;
            navprevious.Enabled = true;
            navnext.Enabled = true;
            navfirst.Enabled = true;

        }
        private void disable()
        {
            navlast.Enabled = false;
            navprevious.Enabled = false;
            navfirst.Enabled = false;
            navnext.Enabled = false;
        }

        private void txtrecord_EditValueChanged(object sender, EventArgs e)
        {

         
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
