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


namespace Rice.Reports
{
    public partial class paddylist : DevExpress.XtraReports.UI.XtraReport
    {
     public   System.Windows.Forms.BindingSource bs;
     public string filter;
    public CriteriaOperator filtercriteria;
    public paddylist()
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

            IEnumerable<Paddy_Detail> quiry = from c in new RiceEntities(rice.ConnectionString()).Paddy_Details
                        select c;

          var list =bs.DataSource;

            ExpressionEvaluator evaluator = new ExpressionEvaluator(TypeDescriptor.GetProperties(typeof(Paddy_Detail)), this.filtercriteria);            

           // DbQuery<Items_Services_List> filteredQuiry = quiry.AppendWhere(new CriteriaToExpressionConverter(), filtercriteria) as DbQuery<Items_Services_List>;

            List<Paddy_Detail> lists = new List<Paddy_Detail>();// filteredQuiry.ToList();
            //GroupOperator opbinarys = filtercriteria as GroupOperator;
            //if (opbinarys != null)
            //{
            //    foreach (var item in opbinarys.Operands)
            //    {
            //        BinaryOperator opBinary = item as BinaryOperator;
            //        if (opBinary != null)
            //        {
            //            OperandProperty opProperty = opBinary.LeftOperand as OperandProperty;
            //            OperandValue opValue = opBinary.RightOperand as OperandValue;

            //            if (opProperty.PropertyName == "Collect_type")
            //            {
            //                opValue = (OperandValue) ((int)(Collections.Collect_type)opValue).ToString();
                         
            //            }
                       
            //        }
            //    }
            //}
            //else
            //{
            //    BinaryOperator opBinary = filtercriteria as BinaryOperator;

            //    if (opBinary != null)
            //    {

            //        OperandProperty opProperty = opBinary.LeftOperand as OperandProperty;
            //        OperandValue opValue = opBinary.RightOperand as OperandValue;

            //        if (opProperty.PropertyName == "Collect_type")
            //        {
                      
            //        }
                   
            //    }
            //}

            foreach (Paddy_Detail p in quiry)
            {
                if (evaluator.Fit(p))
                    lists.Add(p);
            }

      
         
        
          
           
        }

    }
}
