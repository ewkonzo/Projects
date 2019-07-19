using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;

namespace Rice
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
            this.ribbonControl1.MdiMergeStyle = RibbonMdiMergeStyle.OnlyWhenMaximized;
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
                    case "btnitemmovement":
                        f = new ItemMovement();
                        break;
                 
                    case "bfarmers":
                        f = new Farmers();
                        break;
                    case "btnsupplynote":
                        modal = new SupplyNote();
                        break;
                    case "btntransfer":
                        modal = new Transferstock ();
                        break;
                    case "btnstocktake":
                        modal = new Stocktake();
                        break;
                    case "btnreturn":
                        modal = new Return();
                        break;
                    case "btnconvertstock":
                        modal = new Convertstock();
                        break;
                    case "btnreceive":
                        modal = new Receivestock();
                        break;
                    case "btnitems":
                        modal = new Items__and_services();
                        break;
                    case "btnsaleslist":
                        f = new Sales();
                        break;
                    case "btnpos":
                        f = new POS();
                        break;
                    case "btnissueditems":
                        f = new Itemlist();
                        break;
                    case "btndeliverylist":
                        f = new Paddy_list();
                        break;
                    case "btnnewfarmer":
                        modal = new Contacts(true);
                        break;
                    case "btnpaddy":
                        f = new Paddy_list();
                        break;
                    case "btnnewdelivery":
                        using (var form = new Paddy())
                        {
                            var result = form.ShowDialog(true);
                        }
                        break;
                    case "btnnewweigh":
                        using (var form = new Weigh())
                        {
                            var result = form.ShowDialog();
                        }
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
                    case  "btnsalesreport":
                        f = new Reportfilters(reports.source.Pos, reports.report.Sales);
                        break;
                    case "btnpaddyweighed":
                        f = new Reportfilters(reports.source.paddy, reports.report.Paddy);
                        break;
                    case  "btnsalessummary":
                        f = new Reportfilters(reports.source.Pos, reports.report.salessummary);
                        break;
                
                    case "btnstock":
                        f = new Reportfilters(reports.source.stocks, reports.report.stockanalysis);
                      break;
                    case "btncummulative":
                        f = new Reportfilters(reports.source.Pos, reports.report.salescummulative);
                        break;
                    case "btnpurchases":
                         f = new Reportfilters(reports.source.Purchase, reports.report.Purchasereport);    break;
                    case "btnpurchasecumm":
                         f = new Reportfilters(reports.source.Purchase, reports.report.Purchasecumm);    break;
                    case "bservicereport":
                        f = new Reportfilters(reports.source.Farmers, reports.report.farmers);
                        break;
                    case "btnmachineexp":
                        f = new Reportfilters(reports.source.Machineexpenditure, reports.report.Machineexpenduture);
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
                        f.ShowInTaskbar = false;
                        f.MdiParent = parent;
                        f.Show();
                      
                    }
                    foreach (Control item in f.Controls)
                    {
                        if (item is UserControl)
                        {
                            foreach (Control i in item.Controls)
                            {
                                if (i is RibbonControl)
                                {
                                    ribbonControl1.MergeRibbon((RibbonControl)i);

                                    ribbonControl1.SelectedPage = ribbonControl1.MergedRibbon.Pages[0];
                                }
                            }

                          //  break;
                        }
                    }
                }
                if (modal != null)
                {
                    modal.ShowInTaskbar = false;
                    modal.StartPosition = FormStartPosition.CenterParent;
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

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void ribbonControl1_Merge(object sender, RibbonMergeEventArgs e)
        {
            e.MergeOwner.SelectedPage = e.MergeOwner.MergedPages.GetPageByName(e.MergedChild.SelectedPage.Name);
        }
    }
}
