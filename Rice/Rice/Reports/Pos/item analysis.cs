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
    public partial class itemanalysis : DevExpress.XtraReports.UI.XtraReport
    {
        public System.Windows.Forms.BindingSource bs;
        public string filter;
        public CriteriaOperator filtercriteria;
        public itemanalysis()
        {
            InitializeComponent();

        }
        private void Sales_summary_DataSourceDemanded(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<MovementList> quiry = new MovementList().getlist();

                itemstatistics list = new itemstatistics();
                list.load();
                ExpressionEvaluator evaluator = new ExpressionEvaluator(TypeDescriptor.GetProperties(typeof(MovementList)), this.filtercriteria);

                List<MovementList> lists = new List<MovementList>();// 

                foreach (MovementList p in quiry)
                {
                    if (evaluator.Fit(p))
                        lists.Add(p);
                }

                List<Summary> summary = new List<Summary>();
                List<DateTime?> dates = lists.Select(o => o.Date).Distinct().OrderBy(o => o.Value).ToList();
                Outlet locs = null;
                var items = rice.items;

                GroupOperator opbinarys = filtercriteria as GroupOperator;
                if (opbinarys != null)
                {
                    foreach (var item in opbinarys.Operands)
                    {
                        BinaryOperator opBinary = item as BinaryOperator;
                        if (opBinary != null)
                        {

                            OperandProperty opProperty = opBinary.LeftOperand as OperandProperty;
                            OperandValue opValue = opBinary.RightOperand as OperandValue;

                            if (opProperty.PropertyName == "Location_Name")
                            {
                                using (var db = new RiceEntities(rice.ConnectionString()))
                                {
                                    // var value = opValue.ToString();
                                    locs = db.Outlets.FirstOrDefault(o => o.Name == opValue.Value.ToString());
                                    if (opValue.Value.ToString().Equals("<Select Location>"))
                                    {
                                        System.Windows.Forms.MessageBox.Show("Please select Location");
                                        return;
                                    }
                                    var loc = db.Category_locations.Where(o => o.Location == locs.Code).Select(u => u.Category).ToArray();
                                    items = items.Where(o => loc.Contains(o.Category)).ToArray();
                                    quiry = quiry.Where(o => o.location == locs.Code);
                                    lists = lists.Where(o => o.location == locs.Code).ToList();
                                }
                            }
                            if (dates.Count() == 0)
                                if (opProperty.PropertyName == "Date")
                                {
                                    dates.Add(System.Convert.ToDateTime(opValue.Value));
                                }
                        }
                    }
                }
                else
                {
                    BinaryOperator opBinary = filtercriteria as BinaryOperator;

                    if (opBinary != null)
                    {

                        OperandProperty opProperty = opBinary.LeftOperand as OperandProperty;
                        OperandValue opValue = opBinary.RightOperand as OperandValue;

                        if (opProperty.PropertyName == "locationname")
                        {
                            using (var db = new RiceEntities(rice.ConnectionString()))
                            {
                                // var value = opValue.ToString();
                                locs = db.Outlets.FirstOrDefault(o => o.Name == opValue.Value.ToString());

                                var loc = db.Category_locations.Where(o => o.Location == locs.Code).Select(u => u.Category).ToArray();
                                items = items.Where(o => loc.Contains(o.Category)).ToArray();
                                quiry = quiry.Where(o => o.location == locs.Code);
                                lists = lists.Where(o => o.location == locs.Code).ToList();
                            }
                        }
                        if (dates.Count() == 0)
                            if (opProperty.PropertyName == "Date")
                            {
                                dates.Add((DateTime)opValue.Value);
                            }
                    }
                }

                foreach (var item in items.Where(o => o.Type == 0))
                {
                    foreach (var v in rice.variants.Where(o => o.Item_Code == item.Code))
                    {
                        
                        Summary s = new Summary();
                        s.item = item.Code;
                        s.Variant = v.Code;
                        s.Category = item.Category;

                        s.OpeningBalance = quiry.Where(o => o.Date < dates[0].Value && o.item == item.Code && o.Variant == v.Code)
                           .Select(l => l.qty)
                            .DefaultIfEmpty(0)
                            .Sum();
                       s.StockTake = lists.Where(o => o.Movement_type == MovementList.Movetype.Stock_Take && o.item == item.Code && o.Variant == v.Code)
                                                      .Select(l => l.qty)
                                                   .DefaultIfEmpty(0)
                                                   .Sum();
                        s.Sold = lists.Where(o => o.Movement_type == MovementList.Movetype.Sale && o.item == item.Code && o.Variant == v.Code)
                                   .Select(l => l.qty)
                                .DefaultIfEmpty(0)
                                .Sum();
                        s.Transfered = lists.Where(o => o.Movement_type == MovementList.Movetype.Transfer && o.item == item.Code && o.Variant == v.Code)
                                .Select(l => l.qty)
                             .DefaultIfEmpty(0)
                             .Sum();
                        s.Received = lists.Where(o => o.Movement_type == MovementList.Movetype.Receive && o.item == item.Code && o.Variant == v.Code)
                                .Select(l => l.qty)
                             .DefaultIfEmpty(0)
                             .Sum();
                        s.Returned = lists.Where(o => o.Movement_type == MovementList.Movetype.Return && o.item == item.Code && o.Variant == v.Code)
                                .Select(l => l.qty)
                             .DefaultIfEmpty(0)
                             .Sum();

                        s.Converted = lists.Where(o => o.Movement_type == MovementList.Movetype.Convert && o.item == item.Code && o.Variant == v.Code)
                                .Select(l => l.qty)

                             .Sum();
                        s.Balance = s.OpeningBalance + s.StockTake + s.Received + s.Converted + s.Transfered + s.Returned + s.Sold;


                        var price = rice.prices.FirstOrDefault(o => o.Item_No_ == s.item && o.Variant_Code == s.Variant && o.Sales_Type == rice.setup.outlet.Price && o.Sales_Type == (int)Prices.Sales_Type.All_Customers);


                        if (price != null)
                        {
                            s.Price = (double)price.Unit_Price;
                            s.Stock_value = (double)(s.Balance * s.Price);
                        }
                        if ((s.Balance != 0) || (s.OpeningBalance != 0) || (s.StockTake != 0) || (s.Received != 0) || (s.Converted != 0) || (s.Transfered != 0) || (s.Returned != 0) || (s.Sold != 0))
                            summary.Add(s);
                    }
                }
                list.summary = summary.ToArray();
                list.summary.OrderBy(o => o.item_desc);
                bindingSource2.DataSource = list;

                xrLabel5.Text = filter.Replace("[", "").Replace("]", "").Replace("Location_Name", "Location");

            }
            catch (Exception ex)

            { Logging.Logging.ReportError(ex); }

        }

    }
}
