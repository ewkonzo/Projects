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
    public partial class garageexpenditure : DevExpress.XtraReports.UI.XtraReport
    {
     public   System.Windows.Forms.BindingSource bs;
     public string filter;
    public CriteriaOperator filtercriteria;
    public garageexpenditure()
        {
            InitializeComponent();
           
        }
        private void Sales_summary_DataSourceDemanded(object sender, EventArgs e)
        { 
            
            bindingSource1.DataSource = bs.DataSource;
            bindingSource1.Filter = bs.Filter;
            this.DataSource = bindingSource1.DataSource;
            this.FilterString = bindingSource1.Filter;
            xrLabel5.Text = filter.Replace("[","").Replace("]","");

            IEnumerable<Items_Services_List> quiry = from c in new RiceEntities(rice.ConnectionString()).Items_Services_List
                        select c;

            List<Items_Services_List> list = (List<Items_Services_List>)bs.DataSource;

            ExpressionEvaluator evaluator = new ExpressionEvaluator(TypeDescriptor.GetProperties(typeof(Items_Services_List)), this.filtercriteria);            

           // DbQuery<Items_Services_List> filteredQuiry = quiry.AppendWhere(new CriteriaToExpressionConverter(), filtercriteria) as DbQuery<Items_Services_List>;

            List<Items_Services_List> lists = new List<Items_Services_List>();// filteredQuiry.ToList();

            foreach (Items_Services_List p in quiry)
            {
                if (evaluator.Fit(p))
                    lists.Add(p);
            }

           
           
        
          
           
        }

    }
}
