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
    public partial class Reversal : DevExpress.XtraEditors.XtraForm
    {
        Navigation navigation;
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        public Reversal()
        {
            InitializeComponent();
            navigation = new Navigation(item_ReversalBindingSource, item_ReversalGridControl, db, false, false);

            this.Controls.Add(navigation);
            item_ReversalBindingSource.DataSource = db.Item_Reversals.ToArray();
            
        }
    }
}
