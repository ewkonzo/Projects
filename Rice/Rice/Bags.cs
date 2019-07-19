using DevExpress.XtraGrid.Views.Grid;
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
    public partial class Bags : Form
    {
        RiceEntities db;
        public Bags()
        {
            InitializeComponent();
        }
        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           Paddy_Bag  d = new Paddy_Bag();

            switch (e.Item.Name)
            {
                case "btnreverse":
                    string message = "Are you sure you want to reverse the current item?";
                    string caption = "Reverse Item";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);

                    if (result == DialogResult.Yes)
                    {
                        GridView view = sender as GridView;
                        var c = ((Paddy_Bag)gridView1.GetRow(gridView1.FocusedRowHandle));


                       
                        var cc = db.Paddy_Bags.FirstOrDefault(o => o.Id == c.Id);
                        if (cc != null)
                        {
                            if (cc.Reversed == true)
                        {
                            MessageBox.Show("This item has been reversed", "Reversal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                            cc.Reversed = true;
                            cc.Sent = false;
                            db.SaveChanges();
                        }
                        d = new Paddy_Bag();
                        d.Paddy = c.Paddy;
                        d.Farmer = c.Farmer;
                        d.Date = c.Date;
                        d.Time = c.Time;
                        d.Action = c.Action;
                        d.Id = DateTime.Now.Ticks.ToString();
                        d.Variety = c.Variety;
                        d.Weighed_by = rice.user.Name;
                        d.Gross_kg = (c.Gross_kg ?? 0) * -1;
                        d.Moisture_Weight = (c.Moisture_Weight ?? 0) * -1;
                        d.Bag_weight = (c.Bag_weight ?? 0) * -1;
                        d.Net_kg = (c.Net_kg ?? 0) * -1;
                        d.No_of_bags = (c.No_of_bags ?? 0) * -1;
                        d.Reversed = true;
                        d.Sent = false;
                        db.Paddy_Bags.Add(d);
                        p.Add(d);
                        paddy_BagBindingSource.DataSource = p;
                        db.SaveChanges(RiceEntities.Savetype.Updatestatus);
                        rice.bags = db.Paddy_Bags.ToList();
                    }


                    break;
                case "btnreverseall":
                     message = "Are you sure you want to reverse the current item(s)?";
                     caption = "Reverse Item";
                    MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
                    DialogResult result1;

                    // Displays the MessageBox.

                    result1 = MessageBox.Show(this, message, caption, buttons1,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                    if (result1 == DialogResult.Yes)
                    {
                        int counter = 10;
                        for (int j = 0; j < gridView1.RowCount; j++)
                        {
                            int rowHandle = gridView1.GetVisibleRowHandle(j);
                            if (gridView1.IsDataRow(rowHandle))
                            {
                              //  var i = (Items_Services_List)gridView1.GetRow(rowHandle);
                                var c = ((Paddy_Bag)gridView1.GetRow(rowHandle));
                                if (c.Reversed != true)
                                {
                                    var cc = db.Paddy_Bags.FirstOrDefault(o => o.Id == c.Id);
                                    if (cc != null)
                                    {
                                        if (cc.Reversed == false)
                                        {
                                            cc.Reversed = true;
                                            cc.Sent = false;
                                            db.SaveChanges();
  d = new Paddy_Bag();
                                    d.Paddy = c.Paddy;
                                    d.Farmer = c.Farmer;
                                    d.Sent = false;
                                    d.Date = c.Date;
                                    d.Time = c.Time;
                                    d.Action = c.Action;
                                    d.Id = DateTime.Now.AddSeconds(counter).Ticks.ToString();
                                    d.Variety = c.Variety;
                                    d.Weighed_by = rice.user.Name;
                                    d.Gross_kg = (c.Gross_kg ?? 0) * -1;
                                    d.Moisture_Weight = (c.Moisture_Weight ?? 0) * -1;
                                    d.Bag_weight = (c.Bag_weight ?? 0) * -1;
                                    d.Net_kg = (c.Net_kg ?? 0) * -1;
                                    d.No_of_bags = (c.No_of_bags ?? 0) * -1;
                                    d.Reversed = true;
                                    db.Paddy_Bags.Add(d);
                                    p.Add(d);
                                    paddy_BagBindingSource.DataSource = p;
                                 db.SaveChanges(RiceEntities.Savetype.Updatestatus);  
                                        }
                                    }                          
                                 
                                }
                            }
                            counter += 1;
                        }
                        
                        rice.bags = db.Paddy_Bags.ToList();
                    }

                    break;
            }
        }
        List<Paddy_Bag> p;
        public DialogResult ShowDialog(Paddy_Bag[] p,RiceEntities db)
        {
            this.db = db;
            this.p = p.ToList() ;
            paddy_BagBindingSource.DataSource = p;
            return base.ShowDialog();
        }

        private void paddy_BagBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {

        }
    }
}
