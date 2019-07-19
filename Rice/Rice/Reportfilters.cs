using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
namespace Rice
{
    public partial class Reportfilters : Form
    {
        XtraReport rep;
        reports.report report;
        reports.source reportsource;
        BindingSource bs= new BindingSource();
        public Reportfilters()
        {
            InitializeComponent();     
           
        }
        public Reportfilters(reports.source source, reports.report x)
        {
            InitializeComponent();
            filterEditorControl1.AllowAggregateEditing = DevExpress.XtraEditors.FilterControlAllowAggregateEditing.AggregateWithCondition;
            Task task = Task.Factory.StartNew(() =>
           {
               report = x;
               reportsource = source;
               using (var db = new RiceEntities(rice.ConnectionString()))
               {
                   switch (source)
                   {
                       case reports.source.Pos:
                         bs.DataSource =  (from it in db.Items_Services_List where (it.Reversed == null || it.Reversed == false) select it).ToList(); //db.Items_Services_List.ToArray();
                           filterEditorControl1.SourceControl = bs;
                           filterEditorControl1.FilterString = "[Date]=#" + DateTime.Today.ToString("yyyy-MM-dd") + "# and Outlet_Name ='" + rice.setup.outletname + "'";
                           break;
                       case reports.source.stocks:
                           var stat = new itemstatistics();
                           stat.movementlist = new MovementList().getlist();
                           bs.DataSource = stat.movementlist;
                            filterEditorControl1.SourceControl = bs;
                            filterEditorControl1.FilterString = "[Date]=#" + DateTime.Today.ToString("yyyy-MM-dd") 
                                + "# and Location_Name ='"+rice.setup.outletname +"'"
                                //+ "' and Movement_Type ='<Movement Type>'"
                                ;

                               break;
                       case reports.source.Machineexpenditure:
                        
                           
                           bs.DataSource = db.Items_Services_List.Where(o=> o.Reversed == false || string.IsNullOrEmpty(o.Reversed.ToString())).ToArray();
                           filterEditorControl1.SourceControl = bs;
                           filterEditorControl1.FilterString = "[Date]=#" + DateTime.Today.ToString("yyyy-MM-dd")
                               + "# and Location_Name ='" + rice.setup.outletname + "'"
                               //+ "' and Movement_Type ='<Movement Type>'"
                               ;

                           break;

                       case reports.source.Purchase:
                             
                               bs.DataSource = db.Item_Movements.Where(o => o.Reversed == false || string.IsNullOrEmpty(o.Reversed.ToString())).ToArray();
                               filterEditorControl1.SourceControl = bs;
                               filterEditorControl1.FilterString = "[Date]=#" + DateTime.Today.ToString("yyyy-MM-dd")
                                   + "# and Location_Name ='" + rice.setup.outletname + "' and moveType ='<Select Movement Type>'"
                                   ;

                               break;   case reports.source.Farmers:
                             
                               bs.DataSource = db.Farmers.ToArray();
                               filterEditorControl1.SourceControl = bs;
                               filterEditorControl1.FilterString = "[Sectionname]='<Select Section>' and Serviced_Acres >0"
                                   ;

                               break; 
                       case reports.source.paddy:
                               var data = db.Paddy_Details.ToArray();
                               bs.DataSource =data .Where(o=> o.Unweighedbags ==0).ToArray();
                               filterEditorControl1.SourceControl = bs;
                               filterEditorControl1.FilterString = "[Collections_Date]=#" + DateTime.Today.ToString("yyyy-MM-dd") + "# and Collect_type='<Select member/Non member>'"
                                   ;

                               break;   
                   }

                   //db.Paddy_Details.Load();
                   //f = db.Paddy_Details.Local.ToBindingList();
                   //bs.DataSource = f;
                   //filterEditorControl1.SourceControl = bs;

               }
           }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
    

        private void filterEditorControl1_FilterChanged(object sender, DevExpress.XtraEditors.FilterChangedEventArgs e)
        {
            
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
             //   filterEditorControl1.ApplyFilter();
             //  if (Data == typeof(Farmer))
             //   {
             //   x = new Reports.Farmers(bs);
             //  }
             //if (Data == typeof(Daily_Collections_Detail))
             //   {
             //   x = new Reports.Collections(bs);
             //  }
             //   var r = new Report(x);
             //   r.MdiParent = this.MdiParent;
             //   r.Show();
             //   this.Close();
            
        }
        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            filterEditorControl1.Update();
            filterEditorControl1.ApplyFilter();

            switch (report)
            {
                case reports.report.Sales:
                    var r = new Reports.Pos.Sales();
                    r.items = bs;
                    rep = r;
                    break;
                case reports.report.salessummary:
                    var rr = new Reports.Pos.Sales_summary();
                    rr.bs = bs;
                    rr.filter = filterEditorControl1.FilterString;
                    rr.filtercriteria = filterEditorControl1.FilterCriteria;
                    rep = rr;
                    break;
                case reports.report.salescummulative:
                    var cumreport = new Reports.Pos.Sales_cumm();
                    cumreport.bs = bs;
                    cumreport.filter = filterEditorControl1.FilterString;
                    cumreport.filtercriteria = filterEditorControl1.FilterCriteria;
                    rep = cumreport;
                    break;
                case reports.report.Machineexpenduture:
                    var machineexpe = new Reports.machineex();
                    machineexpe.bs = bs;
                    machineexpe.filter = filterEditorControl1.FilterString;
                    machineexpe.filtercriteria = filterEditorControl1.FilterCriteria;
                    rep = machineexpe;
                    break;
                case reports.report.stockanalysis:
                    var analysis = new Reports.Pos.itemanalysis();
                    analysis.bs = bs;
                    analysis.filter = filterEditorControl1.FilterString;
                    analysis.filtercriteria = filterEditorControl1.FilterCriteria;
                    rep = analysis;
                    break;
                case reports.report.Purchasereport: var purchases = new Reports.Pos.Purchases();
                    purchases.bs = bs;
                    purchases.filter = filterEditorControl1.FilterString;
                    purchases.filtercriteria = filterEditorControl1.FilterCriteria;
                    rep = purchases;
                    break;
                case reports.report.Purchasecumm:
                    var purchasescumm = new Reports.Pos.Purchasescumm();
                    purchasescumm.bs = bs;
                    purchasescumm.filter = filterEditorControl1.FilterString;
                    purchasescumm.filtercriteria = filterEditorControl1.FilterCriteria;
                    rep = purchasescumm;
                    break;
                case reports.report.farmers:
                    var farmers = new Reports.Pos.Farmer_statement();
                    farmers.bs = bs;
                    farmers.filter = filterEditorControl1.FilterString;
                    farmers.filtercriteria = filterEditorControl1.FilterCriteria;
                    rep = farmers;
                    break; 
                case reports.report.Paddy:
                    var paddy = new Reports.paddylist();
                    paddy.bs = bs;
                    paddy.filter = filterEditorControl1.FilterString;
                    paddy.filtercriteria = filterEditorControl1.FilterCriteria;
                    rep = paddy;
                    break;
            }

            switch (e.Item.Name)
            {
                case "btnprint":

                    using (ReportPrintTool printTool = new ReportPrintTool(rep))
                        printTool.Print();
                    break;
                case "btnpreview":

                    Report_Preview p = new Report_Preview();
                    p.documentViewerRibbonController1.DocumentViewer.DocumentSource = rep;

                    p.MdiParent = this.Parent.Parent as Form;
                    p.WindowState = FormWindowState.Maximized;
                    p.Show();

                    //using (ReportPrintTool printTool = new ReportPrintTool(rep))
                    //{
                    //    printTool.PreviewRibbonForm.MdiParent = this.Parent.Parent as Form;
                    //    printTool.ShowRibbonPreviewDialog();
                        
                    //}
                    break;
            }
            this.Close();
        }

        private void Reportfilters_Load(object sender, EventArgs e)
        {
            
                //Filter f = new Filter(bs);
                //f.Dock = DockStyle.Fill;
                //f.BringToFront();
                //this.Controls.Add(f);
            
        }

        private void filterControl1_BeforeShowValueEditor(object sender, DevExpress.XtraEditors.Filtering.ShowValueEditorEventArgs e)
        {
            switch (e.CurrentNode.FirstOperand.PropertyName)
            {
                case "Outlet":
                case "Outlet_Name":
                     var riComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                foreach (var item in rice.outlets.ToArray())
                        riComboBox.Items.Add(item.Name); ;
		 e.CustomRepositoryItem = riComboBox;
                    break;
                case "Location_Name":
                     riComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                foreach (var item in rice.outlets.ToArray())
                        riComboBox.Items.Add(item.Name); 
                 
		 e.CustomRepositoryItem = riComboBox;
         break;
                case "moveType":
         riComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();

         foreach (var item in Enum.GetValues(typeof(MovementList.Movetype)))
             riComboBox.Items.Add(item.ToString()); ;
         e.CustomRepositoryItem = riComboBox;
         break;
                case "Collect_type":
        var rilookup = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
         foreach (var item in Enum.GetValues(typeof(Collections.Collect_type)))
             rilookup.Items.Add( item.ToString(),item,-1); ;
         e.CustomRepositoryItem = rilookup;
         break;
            }
            
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void filterEditorControl1_FilterTextChanged(object sender, DevExpress.XtraEditors.FilterTextChangedEventArgs e)
        {
       var   dd =   e.Text;
        }
    
    }
}
