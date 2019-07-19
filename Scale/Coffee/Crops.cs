using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
namespace Coffee
{
    public partial class Crops : Form
    {

        private AutoweighEntities db = new AutoweighEntities(coffee.ConnectionString());
        public Crops()
        {
            InitializeComponent();

            db.Crops.Load();
            cropsBindingSource.DataSource = db.Crops.Local.ToBindingList();
            cropsBindingNavigator.BindingSource = cropsBindingSource;
       
        }

        private void cropsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }

        private void Crops_Load(object sender, EventArgs e)
        {
           
        }
    }
}
