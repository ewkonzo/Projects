using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rice
{
    public partial class DeliveryList : Form
    {
        public Paddy_Detail Selectedpaddy = null;
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        Navigation navigation1;
        RibbonControl mainribbon;
        List<Paddy_Detail> data;
        public DeliveryList()
        {
            InitializeComponent();
            loaddata();
            navigation1 = new Navigation(paddy_DetailBindingSource,paddy_DetailGridControl, db);
            navigation1.Dock = DockStyle.Top;
            navigation1.SendToBack();
            this.Controls.Add(navigation1);
           foreach (Control c in navigation1.Controls)
            {
                if (c is RibbonControl)
                {
                    mainribbon = (RibbonControl)c;
                    break;
                }
            }
           mainribbon.Pages[0].Groups.Insert(0, ribbonControl1.Pages[0].Groups[0]);
           ribbonControl1.Visible = false;

            foreach (var item in Enum.GetValues(typeof(Collections.Collect_type)))
                collecttyperepository.Items.Add(item.ToString(), (int)item, -1);
            foreach (var item in Enum.GetValues(typeof(Collections.Type)))
                typerepository.Items.Add(item.ToString(), (int)item, -1);
            foreach (var item in rice.varieties())
                varietyrepository.Items.Add(item.Name, item.Code, -1);
           
            foreach (var item in Enum.GetValues(typeof(Collections.Status)))
                statusrepository.Items.Add(item.ToString(), (int)item, -1);
        }
        private void loaddata()
        {
            data = db.Paddy_Details.ToList();
            paddy_DetailBindingSource.DataSource = data;
        }
        public DialogResult ShowDialog(List<Paddy_Detail> p)
        {
            paddy_DetailBindingSource.DataSource = p;
            panel1.Visible = true;
            return base.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Selectedpaddy = (Paddy_Detail)gridView1.GetFocusedRow();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    

        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
