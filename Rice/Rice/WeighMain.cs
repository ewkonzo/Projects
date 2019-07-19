using DevExpress.XtraBars.Ribbon;
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

    public partial class WeighMain : Form
    {
        public bool stop = false;
       
        private int childFormNumber = 0;
        RibbonControl mainribbon;
        public WeighMain()
        {
            InitializeComponent();
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            rice.status = statusbar1;

            this.IsMdiContainer = true;
            mainribbon = menu1.ribbonControl1;
           

            
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void Weigh_Load(object sender, EventArgs e)
        {
            var outl = rice.outlets.FirstOrDefault(o => o.Code == rice.setup.POS_Outlet);
            
            this.Text =string.Format("{0}[{1}][{2}]", 
                rice.Factory_Name ,rice.setup.Current_crop,(outl==null?"":outl.Name));

            rice.status.txtuser.Text = rice.user.Name;
          
        }


        private void WeighMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            externaldata.stop = true;
            //stop = true;
            //if (AutoweighEntities. Db.ChangeTracker.Entries().Any(ee => ee.State == EntityState.Added
            //                                     || ee.State == EntityState.Modified
            //                                     || ee.State == EntityState.Deleted))
            //{
            //    DialogResult result1 = MessageBox.Show("There are changes made to your data, do you want to save them?", "Save Changes", MessageBoxButtons.YesNo);
            //    if (result1 == DialogResult.Yes)
            //        AutoweighEntities. db.SaveChanges(RiceEntities.Savetype.ShowMessage);
            //}
            Application.Exit();
        }

        private void farmersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Farmers f = new Farmers();
            //f.MdiParent = this;
            //f.WindowState = FormWindowState.Maximized;
            //f.Show();
        }

        private void collectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //  Collection c = new Collection();
            //c.ShowDialog();
        }

        private void collectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Allcollections ac = new Allcollections();
            //ac.MdiParent = this;
            //ac.WindowState = FormWindowState.Maximized;
            //ac.Show();
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rice.Settings s = new Rice.Settings();
            s.ShowDialog();

            //Settings s = new Settings();
            //s.StartPosition = FormStartPosition.CenterScreen;
            //s.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Users s = new Users();
            //s.StartPosition = FormStartPosition.CenterScreen;
            //s.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmchangePass s = new FrmchangePass();
            //s.StartPosition = FormStartPosition.CenterScreen;
            //s.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            //Login l = new Login();
            //l.Show();
        }

        private void dailyCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reports r = new Reports(Reports.reports.Dailycollection);
            //r.MdiParent = this;
            //r.WindowState = FormWindowState.Maximized;
            //r.Show();
        }

        private void todaysCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reports r = new Reports(Reports.reports.Dailycollection);
            //r.MdiParent = this;
            //r.WindowState = FormWindowState.Maximized;
            //r.Show();
        }

        private void farmersDeliveryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reports r = new Reports(Reports.reports.Farmerdailycollection);
            //r.MdiParent = this;
            //r.WindowState = FormWindowState.Maximized;
            //r.Show();
        }

        private void cummulativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reports r = new Reports(Reports.reports.cummulative);
            //r.MdiParent = this;
            //r.WindowState = FormWindowState.Maximized;
            //r.Show();
        }

        private void WeighMain_MdiChildActivate(object sender, EventArgs e)
        {
            var dd = "";
        }

        private void xtraTabbedMdiManager1_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {


            //foreach (Control c in e.Page.MdiChild.Controls)
            //{
            //    if (c is RibbonControl)
            //    {
            //        if (mainribbon != null)
            //        {
            //            mainribbon.MergeRibbon((RibbonControl)c);
            //            mainribbon.SelectedPage = mainribbon.MergedRibbon.Pages[((RibbonControl)c).Pages[0].Text];
            //        }

            //    }


            //}
        }

        private void xtraTabbedMdiManager1_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            foreach (Control c in e.Page.MdiChild.Controls)
            {
                if (c is RibbonControl)
                {
                    if (mainribbon != null)
                    {

                    }

                }
            }
        }
        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (xtraTabbedMdiManager1.SelectedPage != null)
                {
                    foreach (Control c in xtraTabbedMdiManager1.SelectedPage.MdiChild.Controls)
                    {
                        if (c is UserControl)
                            foreach (Control cc in c.Controls)
                            {
                                if (cc is RibbonControl)
                                {
                                    if (mainribbon != null)
                                    {
                                        mainribbon.MergeRibbon((RibbonControl)cc);
                                        mainribbon.SelectedPage = mainribbon.MergedRibbon.Pages[((RibbonControl)cc).Pages[0].Text];
                                       
                                    }
                                }
                            }
                        if (c is RibbonControl)
                                {
                                    if (mainribbon != null)
                                    {
                                        mainribbon.MergeRibbon((RibbonControl)c);
                                        mainribbon.SelectedPage = mainribbon.MergedRibbon.Pages[((RibbonControl)c).Pages[0].Text];
                                       
                                    }
                                }
                    }
                }
                else
                    if (mainribbon != null)
                        mainribbon.UnMergeRibbon();
            }
            catch (Exception ex) {
                Logging.Logging.ReportError(ex);
            }
        }

        private void WeighMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menu1_Load(object sender, EventArgs e)
        {

        }
    }
}
