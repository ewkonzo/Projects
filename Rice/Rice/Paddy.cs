using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rice
{
    public partial class Paddy : DevExpress.XtraEditors.XtraForm
    {
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        private Navigation navigation2;
        List<Paddy_Detail> data;
        Task task;
        public Paddy()
        {
            InitializeComponent();
            navigation2 = new Navigation(null, null, db, false);
            navigation2.Dock = DockStyle.Top;
            navigation2.SendToBack();
            this.Controls.Add(navigation2);
            navigation2.navigationribbon.Pages[0].Groups.Insert(0, ribbonControl1.Pages[0].Groups[0]);// .MergeRibbon(ribbonControl1);
            ribbonControl1.Visible = false;

           // task =  Task.Run(() => combos()).ContinueWith(t => loaddata(), TaskScheduler.FromCurrentSynchronizationContext());

            combos();

        }
        private void combos()
        {
            try
            {
                foreach (var item in rice.items.Where(o => o.Category == "PADDY").ToList())
                    varietyImageComboBoxEdit.Properties.Items.Add(item.Name, item.Code, -1);
                foreach (var item in Enum.GetValues(typeof(Collections.Collect_type)))
                    collect_typeComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);
                foreach (var item in Enum.GetValues(typeof(Collections.Type)))
                    typeImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);
                foreach (var item in Enum.GetValues(typeof(Collections.Status)))
                    statusImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);
                foreach (var item in Enum.GetValues(typeof(Collections.Status)))
                    statusrepos.Items.Add(item.ToString(), (int)item, -1);
                foreach (var item in Enum.GetValues(typeof(Collections.Transport_Mode)))
                    transport_ModeImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);
                loaddata();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }
        
        private void loaddata()
        {
            data = db.Paddy_Details.ToList();
            paddy_DetailBindingSource.DataSource = data;
            loadhistory();
        }
        private void Paddy_Load(object sender, EventArgs e)
        {
        }

        private void paddy_DetailBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Paddy_Detail sh = new Paddy_Detail();
                sh.Collections_Date = DateTime.Now.Date;
              
                sh.Collections_Time = DateTime.Now;
                sh.Collection_Number = String.Format("{0}{1}{2}{3}{4}{5}{6}", rice.setup.POS_Outlet, sh.Collections_Time.Value.Year, sh.Collections_Time.Value.Month, sh.Collections_Time.Value.Day, sh.Collections_Time.Value.Hour, sh.Collections_Time.Value.Minute, DateTime.Now.Second);
                sh.Collected_by = rice.user.Name;
                sh.Status = 0;
                sh.Type =(int) Collections.Type.Paddy;
                sh.Sent = false;
                sh.Crop = rice.setup.Current_crop;
                e.NewObject = sh;
                db.Paddy_Details.Add(sh);
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void paddy_DetailBindingSource_PositionChanged(object sender, EventArgs e)
        {

        }

        private void paddy_DetailBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (paddy_DetailBindingSource != null)
                if (paddy_DetailBindingSource.Current != null)
                {
                    var current = (Paddy_Detail)paddy_DetailBindingSource.Current;
                    this.Text = string.Format("Paddy Delivery [{0}]", current.Collection_Number);
                    paddy_BagBindingSource.DataSource = db.Paddy_Bags.Where(o => o.Paddy == current.Collection_Number).ToList();

                }
            loadhistory();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //try
            //{
            //    DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //    if (paddy_DetailBindingSource != null)
            //        if (paddy_DetailBindingSource.Current != null)
            //        {
            //            var current = (Paddy_Detail)paddy_DetailBindingSource.Current;

            //            if (current.Farmers_Number != "")
            //            {
            //                view.SetRowCellValue(e.RowHandle, colPaddy, current.Collection_Number);
            //                Paddy_Bag s = ((Paddy_Bag)gridView1.GetFocusedRow());
            //                s.Id = DateTime.Now.Ticks.ToString();
            //                s.Farmer = current.Farmers_Number;
            //                s.Action = 0;
            //                s.Variety = varietyImageComboBoxEdit.EditValue.ToString();

            //                db.Paddy_Bags.Add(s);
            //            }
            //            else
            //            {

            //                view.CancelUpdateCurrentRow();
            //            }
            //        }
            //}
            //catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void paddy_BagBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
          
            //db.SaveChanges();
            loadhistory();
           
           
        }
        private void loadhistory()
        {
            rice.populatelists();
            if (paddy_DetailBindingSource != null)
                if (paddy_DetailBindingSource.Current != null)
                {
                    var current = (Paddy_Detail)paddy_DetailBindingSource.Current;
                    Task<Paddy_Detail[]> task3 = Task<Paddy_Detail[]>.Factory.StartNew(() =>
        {
            var history = db.Paddy_Details.Where(o => o.Farmers_Number == current.Farmers_Number && o.Status == 1).ToArray();
            return history;
        });
                    paddylistbindingsource.DataSource = task3.Result.ToList();
                }



        }
        private void printcurrentdelivery()
        {
            if (paddy_DetailBindingSource != null)
                if (paddy_DetailBindingSource.Current != null)
                {
                    
                        printdelivery((Paddy_Detail)paddy_DetailBindingSource.Current);
                   
                }
        }
        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (paddy_DetailBindingSource.Current != null)
            {
                gridView2.Focus();
                paddy_BagBindingSource.EndEdit();
                var paddy = (Paddy_Detail)paddy_DetailBindingSource.Current;
                if ((paddy.No_of_bags_Delivered < 1) || (paddy.No_of_bags_Delivered == null))
                {
                    MessageBox.Show("Bags Delivered must have a value");
                    no_of_bags_DeliveredSpinEdit.Focus();
                    return;
                }
                if (paddy.Collect_type == null)
                {
                    MessageBox.Show("Collect_type must have a value");
                    collect_typeComboBoxEdit.Focus();
                    return;
                }
                if (paddy.Farmers_Number == null)
                {
                    MessageBox.Show("Farmer Number must have a value");
                    farmers_NumberButtonEdit.Focus();
                    return;
                }
                if (paddy.Type == null)
                {
                    MessageBox.Show("Type must have a value");
                    typeImageComboBoxEdit.Focus();
                    return;
                }
                if (paddy.Transport_Mode == null)
                {
                    MessageBox.Show("Transport_Mode must have a value");
                    transport_ModeImageComboBoxEdit.Focus();
                    return;
                } if (paddy.Variety == null)
                {
                    MessageBox.Show("Variety must have a value");
                    varietyImageComboBoxEdit.Focus();
                    return;
                }
                switch (e.Item.Name)
                {
                    case "btnpost":

                        statusImageComboBoxEdit.EditValue = (int)Collections.Status.Weigh;
                        paddy_DetailBindingSource.EndEdit();
                        rice.populatelists();
                        db.SaveChanges(savetype: RiceEntities.Savetype.Updatestatus);
                        printcurrentdelivery();
                        paddy_DetailBindingSource.AddNew();
                        break;

                    case "btnprint":
                        statusImageComboBoxEdit.EditValue = (int)Collections.Status.Weigh;
                        paddy_DetailBindingSource.EndEdit();
                        rice.populatelists();
                        db.SaveChanges(savetype: RiceEntities.Savetype.Updatestatus);
                        printcurrentdelivery();
                        //paddy_DetailBindingSource.AddNew();

                        break;
                }
                loadhistory();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void collectionsGridControl_Click(object sender, EventArgs e)
        {

        }

        private void collect_typeComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (collect_typeComboBoxEdit.EditValue.ToString() != string.Empty)
                switch ((Collections.Collect_type)collect_typeComboBoxEdit.EditValue)
                {
                    case Collections.Collect_type.Non_Member:
                        farmers_NumberLabel.Text = "Customer ID";
                        break;
                    case Collections.Collect_type.Member:
                        farmers_NumberLabel.Text = "Farmers No.";
                        break;   }

        }


        private void farmers_NumberButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
        }

        private void farmers_NumberButtonEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (collect_typeComboBoxEdit.EditValue.ToString() != string.Empty)
                switch ((Collections.Collect_type)collect_typeComboBoxEdit.EditValue)
                {
                    case Collections.Collect_type.Non_Member:
                        using (var form = new Customers())
                        {
                            var result = form.ShowDialog(true);
                            if (result == DialogResult.OK)
                            {
                                if (form.navigation1.Selecteditem != null)
                                {
                                    farmers_NumberButtonEdit.EditValue =((Customer) form.navigation1.Selecteditem).ID;
                                    farmers_NameTextEdit.EditValue = ((Customer)form.navigation1.Selecteditem).Name;
                                }
                            }
                        }
                        break;
                    case Collections.Collect_type.Member:
                        using (var form = new Farmers())
                        {
                            
                            form.gridView1.BestFitColumns(true);
                            form.gridView1.OptionsBehavior.ReadOnly = true;
                            form.gridView1.OptionsSelection.MultiSelect = false;
                          
                            var result = form.ShowDialog(true);
                            if (result == DialogResult.OK)
                            {
                                if (form.navigation1.Selecteditem != null)
                                {
                                    farmers_NumberButtonEdit.EditValue =((Farmer) form.navigation1.Selecteditem).No;
                                    farmers_NameTextEdit.EditValue = ((Farmer)form.navigation1.Selecteditem).Name;
                                    sectionTextEdit.EditValue = ((Farmer)form.navigation1.Selecteditem).Sectionname;
                                    unitTextEdit.EditValue = ((Farmer)form.navigation1.Selecteditem).Unit;
                                }
                            }
                        }
                        break;
                }
        }


        private void printdelivery(Paddy_Detail p)
        {
            Task.Factory.StartNew(() =>
            {
                switch ((Collections.Collect_type)p.Collect_type) { 
                    case Collections.Collect_type.Member:
                Reports.Delivery report = new Reports.Delivery();
                report.p = p;
                        using (ReportPrintTool printTool = new ReportPrintTool(report))
                        {
                            printTool.PrinterSettings.Copies = 2;
                            printTool.Print();
                        }
                break;
                    case Collections.Collect_type.Non_Member:
              Reports.DeliveryCustomer r = new Reports.DeliveryCustomer();
                r.p = p;
                        using (ReportPrintTool printTool = new ReportPrintTool(r))
                        {
                            printTool.PrinterSettings.Copies = 2;
                            printTool.Print();
                        }
                break;               
            }     
                
            });
        }

        private void paddy_DetailBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {   
            //try
            //{
            //    label1.Text = "";
            paddy_DetailBindingSource.EndEdit();
            //db.SaveChanges(savetype: RiceEntities.Savetype.Paddy);
            //}
            //catch (DbEntityValidationException ee)
            //{
            //    foreach (var eve in ee.EntityValidationErrors)
            //    {
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            label1.Text = ve.ErrorMessage;

            //        }
            //    }

            //}
            //catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void vehicle_NoButtonEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var c = (Paddy_Detail)paddy_DetailBindingSource.Current;
            switch ((Collections.Transport_Mode)c.Transport_Mode)
            {
                case Collections.Transport_Mode.Transporter:

                    using (var form = new Transporters())
                    {
                        form.StartPosition = FormStartPosition.CenterParent;
                        var result = form.ShowDialog(true);
                        if (result == DialogResult.OK)
                        {
                            if (form.navigation1.Selecteditem != null)
                            {
                                Transporter t = (Transporter)form.navigation1.Selecteditem;
                                vehicle_NoButtonEdit.EditValue = t.Vehicle_No;
                                transporter_NameTextEdit.EditValue = t.Name;
                                transporter_NumberTextEdit.EditValue = t.Phone_No;
                            }
                        }
                    }
                    break;
                case Collections.Transport_Mode.Society:
                    using (var form = new Vehicles())
                    {
                        form.StartPosition = FormStartPosition.CenterParent;
                        var result = form.ShowDialog(true);
                        if (result == DialogResult.OK)
                        {
                            if (form.navigation1.Selecteditem != null)
                            {
                                Resource t = (Resource)form.navigation1.Selecteditem;
                                vehicle_NoButtonEdit.EditValue = t.No;
                                transporter_NameTextEdit.EditValue = t.Name;
                            }
                        }
                    }
                    break;
            }
        }     
        public DialogResult ShowDialog(bool newpaddy)
        {
            paddy_DetailBindingSource.AddNew();
            return this.ShowDialog();
        } 
        public DialogResult ShowDialog(int position)
        {            
                paddy_DetailBindingSource.Position = position;
                if (paddy_DetailBindingSource.Current != null)
                {
                    var p = (Paddy_Detail)paddy_DetailBindingSource.Current;
                    if ((Collections.Status)p.Status == Collections.Status.Weigh)
                        panel1.Enabled = false;
                }
            
          return   this.ShowDialog();
         
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            var d = (Paddy_Bag)e.Row;
            db.Paddy_Bags.Remove(d);
            //db.SaveChanges();
        }

        private void farmers_NumberButtonEdit_Leave(object sender, EventArgs e)
        {
            var c = (Paddy_Detail)paddy_DetailBindingSource.Current;
            if (collect_typeComboBoxEdit.EditValue.ToString() != string.Empty)
                switch ((Collections.Collect_type)collect_typeComboBoxEdit.EditValue)
                {
                    case Collections.Collect_type.Non_Member:
                        if (farmers_NumberButtonEdit.EditValue != null)
                        {
                            var fn = farmers_NumberButtonEdit.EditValue.ToString();
                            var f = db.Customers.FirstOrDefault(o => o.ID == fn);
                            if (f != null)
                                c.Farmers_Name = f.Name;
                            //farmers_NameTextEdit.EditValue = f.Name;
                            else
                            {
                                new ErrorProvider().SetError(farmers_NumberButtonEdit, "Customer not found");
                                farmers_NumberButtonEdit.Focus();
                            }
                        }
                        break;
                    case Collections.Collect_type.Member:
                        if (farmers_NumberButtonEdit.EditValue != null)
                        {
                            var fn = farmers_NumberButtonEdit.EditValue.ToString();
                            var f = db.Farmers.FirstOrDefault(o => o.No == fn && (Members.Status) o.Status == Members.Status.Active) ;
                            if (f != null)
                            {
                                c.Farmers_Name = f.Name;
                                c.Section = f.Sectionname;
                                c.Unit = f.Unit;
                                
                                farmers_NumberButtonEdit.ErrorText = "";
                            }
                            else
                            {
                                c = null;
                                new ErrorProvider().SetError(farmers_NumberButtonEdit, "Farmer not found");
                                farmers_NameTextEdit.Text = "";
                                sectionTextEdit.Text = "";
                                unitTextEdit.Text = "";
                                    
                                farmers_NumberButtonEdit.Focus();
                       
                            }
                        }
                        break;
                }
            loadhistory();
        }

        private void vehicle_NoButtonEdit_Leave(object sender, EventArgs e)
        {

            if (vehicle_NoButtonEdit.EditValue != null)
            { var vn = vehicle_NoButtonEdit.EditValue.ToString().ToUpper();
                var c = (Paddy_Detail)paddy_DetailBindingSource.Current;
                switch ((Collections.Transport_Mode)c.Transport_Mode)
                {
                    case Collections.Transport_Mode.Transporter:


              
               
                var t = db.Transporters.FirstOrDefault(o => o.Vehicle_No == vn);
                if (t != null)
                {
                    transporter_NameTextEdit.EditValue = t.Name;
                    transporter_NumberTextEdit.EditValue = t.Phone_No;
                }
                else
                {                   
                    new ErrorProvider().SetError(vehicle_NoButtonEdit, "Transporter not found");
                    vehicle_NoButtonEdit.Focus();
                }
                        break;
                    case Collections.Transport_Mode.Society:

                        var v = db.Resources.FirstOrDefault(o => o.No == vn && (Resources.Type)o.Type == Resources.Type.Machine);
                        if (v != null)
                        {
                            transporter_NameTextEdit.EditValue = v.Name;
                            transporter_NumberTextEdit.EditValue = v.Name;
                        }
                        else
                        {
                            new ErrorProvider().SetError(vehicle_NoButtonEdit, "Vehicle not found");
                            vehicle_NoButtonEdit.Focus();
                        }
                        break;
                }
            }
        }

        private void unitLabel_Click(object sender, EventArgs e)
        {

        }

        private void transport_ModeImageComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            transporter_NameTextEdit.Text = "";
            vehicle_NoButtonEdit.Text = "";
            transporter_NumberTextEdit.Text = "";
            if (transport_ModeImageComboBoxEdit.SelectedItem!=null)
            switch (transport_ModeImageComboBoxEdit.SelectedItem.ToString())
            {
               
                case "Own":
                     panel2.Enabled = false;
                    vehicle_NoButtonEdit.EditValue = "Own";
                    break;

                default:
                     panel2.Enabled = true;
                    
                    break;
            }
        }

        private void transport_ModeLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnpost_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

         
        }

        private void farmers_NumberButtonEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //gridView1.PostEditor() ;
            //gridView1.UpdateCurrentRow();
            //loadhistory();
        }

        private void paddy_BagBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (paddy_DetailBindingSource.Current != null)
            {
                var paddyd = (Paddy_Detail)paddy_DetailBindingSource.Current;

                Paddy_Bag sh = new Paddy_Bag();
                sh.Date = paddyd.Collections_Date;
                sh.Paddy = paddyd.Collection_Number;
                sh.Variety = paddyd.Variety;
                sh.Action = (int)PaddyBags.Action.Delivery;
                             e.NewObject = sh;
                db.Paddy_Bags.Add(sh);
            }
        }

        private void no_of_bags_DeliveredLabel_Click(object sender, EventArgs e)
        {

        }

        private void no_of_bags_DeliveredSpinEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void transporter_NameTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void transporter_NumberTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_NoButtonEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

       
    }
}
