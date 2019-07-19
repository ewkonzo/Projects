using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering.Helpers;

namespace Rice.Reports.Pos
{
    public partial class Purchasescumm : DevExpress.XtraReports.UI.XtraReport
    {
        public System.Windows.Forms.BindingSource bs;
        public string filter;
        public CriteriaOperator filtercriteria;
        public Purchasescumm()
        {
            InitializeComponent();
        }

        private void Purchases_DataSourceDemanded(object sender, EventArgs e)
        {
            bindingSource1.DataSource = bs.DataSource;
            bindingSource1.Filter = bs.Filter;
            this.DataSource = bindingSource1.DataSource;
            this.FilterString = bindingSource1.Filter;
            xrLabel16.Text =rice.formatfilter( filter);
            IEnumerable<Item_Movement> quiry = from c in new RiceEntities(rice.ConnectionString()).Item_Movements
                                               select c;
            Item_Movement[] list = (Item_Movement[])bs.DataSource;
            ExpressionEvaluator evaluator = new ExpressionEvaluator(TypeDescriptor.GetProperties(typeof(Item_Movement)), this.filtercriteria);

            // DbQuery<Items_Services_List> filteredQuiry = quiry.AppendWhere(new CriteriaToExpressionConverter(), filtercriteria) as DbQuery<Items_Services_List>;

            List<Item_Movement> lists = new List<Item_Movement>();// filteredQuiry.ToList();
            foreach (Item_Movement p in quiry)
            {
                if (evaluator.Fit(p))
                    lists.Add(p);
            }
        }

    }
}
