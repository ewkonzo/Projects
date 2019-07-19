using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rice
{
    public partial class Vehicles : Form
    {
        public Navigation navigation1;
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        public Vehicles()
        {
            InitializeComponent();
            navigation1 = new Navigation(resourceBindingSource, resourceGridControl, db);
            this.Controls.Add(navigation1);
            resourceBindingSource.DataSource = db.Resources.Where( o=> (Resources.Type)o.Type == Resources.Type.Machine).ToList();
        }

        public DialogResult ShowDialog(bool list)
        {
            navigation1.selectgroup.Visible = true;

            return base.ShowDialog();


        }
    }
}
