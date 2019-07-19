using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Rice
{
    public partial class Filter : UserControl
    {
        public BindingSource bindingsource = new BindingSource() ;

        public Filter(object Data)
        {
            InitializeComponent();

            bindingsource.DataSource = Data;
            var dtype = bindingsource.DataSource.GetType();
            if (dtype == typeof(Items_Services_List))
            {
                var p = GetProperties(dtype);
                foreach (var item in p)
                {
                    repofield.Items.Add(item.Name);
                }
            }
        }
        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }
        private void Filter_Load(object sender, EventArgs e)
        { 
          
        }
    }
}
