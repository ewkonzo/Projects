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
    public partial class Stocks : Form
    {
        public Stocks()
        {
            InitializeComponent();
        }
        public Stocks(Item_Variant i )
        {
            InitializeComponent();
            this.Text = String.Format("{0} - {1}",i.Item_name.ToUpper(),i.Code);
            stockBindingSource.DataSource = new AutoweighEntities(coffee.ConnectionString()).Stocks.Where(o => o.Item == i.No && o.Variant == i.Code).ToList();
        }

        private void Stocks_Load(object sender, EventArgs e)
        {
           
        }
    }
}
