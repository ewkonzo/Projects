using DevExpress.Utils.Menu;
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
    public partial class ItemMovement : Form
    {
      List<DXMenuItem> menuitems = new List<DXMenuItem>();
        Navigation navigation;
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        public ItemMovement()
        {
            InitializeComponent();
            navigation = new Navigation(itemMovementBindingSource, item_Movement_HeaderGridControl, db, false, false);
            this.Controls.Add(navigation);
            foreach (var item in Enum.GetValues(typeof(ItemMovementHeader.Movement_Type)))
                repositoryItemImageComboBox1.Items.Add(item.ToString(), (int)item, -1);
            itemMovementBindingSource.DataSource = db.Item_Movements.Where(o=> o.Location == rice.setup.POS_Outlet) .ToArray();
            gridView1.ExpandGroupRow(1);
         
        }

        private void Click(object sender, System.EventArgs e)
        {
            
            gridView1.ShowEditor();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Hide();
            switch (e.ClickedItem.Name)
            { 
                case "filterByThisValueToolStripMenuItem":
                    gridView1.ActiveFilterString = "[" + gridView1.FocusedColumn.FieldName + "] = '" + gridView1.FocusedValue + "'";
                    break;
                case "reverseToolStripMenuItem":
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

                        var c = ((Item_Movement)gridView1.GetRow(gridView1.FocusedRowHandle));

                        var ee = db.Item_Reversals.FirstOrDefault(o => o.Reversal_Id == c.Entry.ToString() && o.Entry_Type == (int)Reversals.Entry_Type.Movement);
                            if (ee!= null)
                            {
                                MessageBox.Show("There is already a request/reversal for this item please wait until this is approved.", "Reversal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                            }
                            Item_Reversal r = new Item_Reversal();
                            r.Date = DateTime.Now.Date;
                            r.Time = DateTime.Now;
                            r.Reversal_Id = c.Entry.ToString(); ;
                            r.Location = c.Location;
                            r.Status = (int)Reversals.Status.Pending;
                            r.Entry_Type = (int)Reversals.Entry_Type.Movement;
                            r.Reversed_By = rice.user.Name;
                            r.Reverse_document = false;
                            r.Reference = c.Reference;
                            r.Item = c.Item;
                            r.Variant = c.Variant;
                            switch((Movement.Movement_Type) c.Movement_Type )
                            { case Movement.Movement_Type.Convert:
                                case Movement.Movement_Type.Transfer:
                                case Movement.Movement_Type.Return:
                                    r.Reverse_document = true;
                                    r.Reference = c.Reference;
                                break;
                            }
                            db.Item_Reversals.Add(r);
                            db.SaveChanges();
                            MessageBox.Show("Reversal request sent, once the reversal has been approved the record will be reversed.", "Reversal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    break;
            }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                GridView view = sender as GridView;
                view.FocusedRowHandle = e.HitInfo.RowHandle;
                contextMenuStrip1.Show(view.GridControl, e.Point);

              
            }
        }
    }
}
