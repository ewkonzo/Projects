using DevExpress.XtraBars.Ribbon;
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
    public partial class WeighMain : Form
    {
        public bool stop = false;
        public server.Collect service = new server.Collect();
        private int childFormNumber = 0;
        RibbonControl mainribbon;
        public WeighMain()
        {
            InitializeComponent();
            coffee.status = statusbar1;
           new ExternalData().start();
            this.IsMdiContainer = true;
            mainribbon = menu1.menuribbon;
            //Scripting.Createscript();
        }
        private void Weigh_Load(object sender, EventArgs e)
        {
            this.Text =String.Format("{0}|{1}" ,coffee.Factory_Name, Coffee.coffee.setup.Current_crop);
            if (Coffee.coffee.user == null)
            {
                Coffee.coffee.user = new AutoweighEntities(coffee.ConnectionString()).Users.FirstOrDefault();
            }
            Coffee.coffee.status.txtuser.Text = Coffee.coffee.user.Name;
        }
                private void WeighMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //stop = true;
            //if (AutoweighEntities. Db.ChangeTracker.Entries().Any(ee => ee.State == EntityState.Added
            //                                     || ee.State == EntityState.Modified
            //                                     || ee.State == EntityState.Deleted))
            //{
            //    DialogResult result1 = MessageBox.Show("There are changes made to your data, do you want to save them?", "Save Changes", MessageBoxButtons.YesNo);
            //    if (result1 == DialogResult.Yes)
            //        AutoweighEntities. Db.SaveChanges(true);
            //}
            Application.Exit();
        }

        private void WeighMain_MdiChildActivate(object sender, EventArgs e)
        {
         
        }

        private void xtraTabbedMdiManager1_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {


        }

        private void xtraTabbedMdiManager1_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
           
        }
     
        private void xtraTabbedMdiManager2_SelectedPageChanged(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
        }

    }
}
