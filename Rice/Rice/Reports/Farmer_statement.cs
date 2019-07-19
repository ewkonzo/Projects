using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using System.Collections.Generic;
 using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.Filtering;
using System.Data.Entity.Infrastructure;
using DevExpress.Data.Linq;
using DevExpress.Data.Filtering.Helpers;


namespace Rice.Reports.Pos
{
    public partial class Farmer_statement : DevExpress.XtraReports.UI.XtraReport
    {
     public   System.Windows.Forms.BindingSource bs;
     public string filter;
    public CriteriaOperator filtercriteria;
    public Farmer_statement()
        {
            InitializeComponent();
           
        }
        private void Sales_summary_DataSourceDemanded(object sender, EventArgs e)
        { 
            
            bindingSource1.DataSource = bs.DataSource;
            bindingSource1.Filter = bs.Filter;
            this.DataSource = bindingSource1.DataSource;
            this.FilterString = bindingSource1.Filter;
            xrLabel5.Text = filter.Replace("[","").Replace("]","").Replace("Outlet_Name","Outlet");

            IEnumerable<Farmer> quiry = from c in new RiceEntities(rice.ConnectionString()).Farmers
                        select c;

            var list = bs.DataSource;

            ExpressionEvaluator evaluator = new ExpressionEvaluator(TypeDescriptor.GetProperties(typeof(Farmer)), this.filtercriteria);            

           // DbQuery<Items_Services_List> filteredQuiry = quiry.AppendWhere(new CriteriaToExpressionConverter(), filtercriteria) as DbQuery<Items_Services_List>;

            List<Farmer> lists = new List<Farmer>();// filteredQuiry.ToList();

            foreach (Farmer p in quiry)
            {
                if (evaluator.Fit(p))
                    lists.Add(p);
            }

           
         
        
          
           
        }

    }
}
