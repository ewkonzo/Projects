using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace Coffee
{
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();

        }



        private void bfarmers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.menuribbon.MdiMergeStyle = RibbonMdiMergeStyle.OnlyWhenMaximized;
        }

        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool open = false;
                var parent = this.Parent as Form;
                Form f = null;
                Form modal = null;
                switch (e.Item.Name)
                {
                    case "bcollections":
                        f = new Allcollections();
                        break;
                    case "bfarmers":
                        f = new Farmers();
                        break;
                    case "bstores":
                        f = new Stores();
                        break;
                    case "bdebts":
                        f = new Debts();
                        break;
                    case "bposteddebts":
                        f = new Posted_Debts();
                        break;
                    case "bcollect":
                        modal = new Collection();
                        modal.TopLevel = true;
                        break;
                    case "bsetup":
                        modal = new Settings();
                        modal.TopLevel = true;
                        break;
                    case "busers":
                        modal = new Users();
                        modal.TopLevel = true;
                        break;
                    case "bchangepass":
                        modal = new FrmchangePass();
                        modal.TopLevel = true;
                        break;
                    //Reports
                    case "rptfarmers":
                        f = new Reportfilters(typeof(Farmer));
                        break;
                    case "rptdailysummary":
                        var x = new Reports.Daily_summary();
                        var r = new Report(x);
                        r.MdiParent = parent;
                        r.Show();
                       break;
 case "rptcollections":
                        f = new Reportfilters(typeof(Daily_Collections_Detail));
                        break;
                }
             
                if (f != null)
                {
                    if (Parent.HasChildren)
                        foreach (Form child in parent.MdiChildren)
                        {
                            if (child.Name.Equals(f.Name))
                            {
                                child.Activate();
                                open = true;
                                break;
                            }
                        }
                    if ( open == false)
                    {
                        f.MdiParent = parent;
                        f.Show();
                      
                    }
  //foreach (Control item in f.Controls)

  //                      {
  //                          if (item is RibbonControl)
  //                          {
  //                                  ribbonControl1.MergeRibbon((RibbonControl)item);

  //                                 ribbonControl1.SelectedPage= ribbonControl1.MergedRibbon.Pages["Collections"];
                                 
                                 
  //                              break;
  //                          }
  //                      }
                }
                if (modal != null)
                {
                    modal.ShowDialog();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Unable to load form");
                Logging.Logging.ReportError(ex); }
        }

        private void _Activated(object sender, EventArgs e)
        {
            //foreach (var ctl in (sender as Form).Controls)
            //{
            //    if (ctl  is BindingSource)
            //    {
            //    (ctl as BindingSource).
            //    }
            //}
        }

        private void bdebts_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
