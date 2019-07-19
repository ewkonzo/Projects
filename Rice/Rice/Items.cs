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
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
        }

        private void load() {
        }
        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
            //paddy_BagBindingSource.EndEdit();
            //switch (e.Item.Name)
            //{
            //    case "btnpost":
            //        statusImageComboBoxEdit.EditValue = (int)Collections.Status.Weigh;
            //        paddy_DetailBindingSource.EndEdit();
            //        rice.populatelists();
            //        db.SaveChanges(savetype: RiceEntities.Savetype.Updatestatus);
            //        break;

            //    case "btnprint":
            //        statusImageComboBoxEdit.EditValue = (int)Collections.Status.Weigh;
            //        paddy_DetailBindingSource.EndEdit();
            //        db.SaveChanges(savetype: RiceEntities.Savetype.Updatestatus);
            //        printcurrentdelivery();
            //        //paddy_DetailBindingSource.AddNew();

            //        break;
            //}
          
        }
    }
}
