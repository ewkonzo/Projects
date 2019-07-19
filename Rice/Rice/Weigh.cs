using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rice
{
    public partial class Weigh : DevExpress.XtraEditors.XtraForm
    {
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        private Farmer currentfarmer = null;
        private Paddy_Detail currentpaddy = null;
        internal Navigation navigation2;
        RibbonControl mainribbon;
        public Paddy_Detail p = null;
        public static SerialPort mySerialPort = new SerialPort();
        SerialPort sp;
        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                porthasdata = true;
                sp = (SerialPort)sender;
                string readdata = sp.ReadLine();
                Char[] strarr = readdata.Replace("\r", "").ToCharArray().Where(c => Char.IsDigit(c) || Char.IsPunctuation(c)).ToArray();
                decimal number = Convert.ToDecimal(new string(strarr).Replace(",", ""));
                SetText(number.ToString());
                //  txtkg.Text = indata;
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
        }
        public void serialerrorHandler(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show("Error");

        }
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {

            if (capture == false) { 
                if (this.gross_kgSpinEdit.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.gross_kgSpinEdit.EditValue = text;
                }
        }
        }
        public Weigh()
        {
            InitializeComponent();
            navigation2 = new Navigation(null, null, db);
            navigation2.Dock = DockStyle.Top;
            navigation2.SendToBack();
            this.Controls.Add(navigation2);

            navigation2.navigationribbon.Pages[0].Groups.Insert(0, ribbonControl1.Pages[0].Groups[0]);
            ribbonControl1.Visible = false;
            foreach (var item in Enum.GetValues(typeof(Bagweight.Bag_Type)))
                bag_typeImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            mySerialPort.ErrorReceived += new SerialErrorReceivedEventHandler(serialerrorHandler);
            scalestatus.Caption = "Connecting to Scale";
            if (db.Settings.FirstOrDefault().Scale_Autoconnect == true)
            {
                Task task = new Task(() => finddatacom());
                task.Start();
            }
            else
            {
                Task task = new Task(() => connect());
                task.Start();
            }
            if ((AUsers.Type)(Convert.ToInt16( rice.user.Type)) == AUsers.Type.User)
                gross_kgSpinEdit.Properties.ReadOnly = true;
        }
        bool porthasdata = false;
        private void finddatacom()
        {
            bool connected = false;
            while (!connected)
            { string[] ports = SerialPort.GetPortNames();
                foreach (string port in ports)
                {
                    try
                    {

                        var settings = new RiceEntities(rice.ConnectionString()).Settings.FirstOrDefault();
                        mySerialPort.PortName = port;
                        mySerialPort.BaudRate = (int)settings.BaudRate;// 9600;
                        mySerialPort.Parity = Parity.None;
                        mySerialPort.StopBits = StopBits.One;
                        mySerialPort.DataBits = 8;
                        mySerialPort.Handshake = Handshake.None;
                        mySerialPort.RtsEnable = true;
                        if (!mySerialPort.IsOpen)
                            mySerialPort.Open();

                        scalestatus.ItemAppearance.Normal.ForeColor = Color.Green;
                        scalestatus.Caption = "Scale Connected";
                        System.Threading.Thread.Sleep(2000);
                        if (porthasdata)
                        {
                            connected = true;
                            break;
                        }

                        mySerialPort.Close();
                        System.Threading.Thread.Sleep(5000);
                    }
                    catch (Exception ex)
                    {
                        scalestatus.Caption = "Unable to Connect to port: " + port;
                        scalestatus.ItemAppearance.Normal.ForeColor = Color.Red;
                        Logging.Logging.ReportError(ex);
                        if (mySerialPort.IsOpen)
                            mySerialPort.Close();
                    }
                }

            }

        }

        private void connect()
        {
            bool connected = false;
            while (!connected )
            {
                try
                {
                var settings = new RiceEntities(rice.ConnectionString()).Settings.FirstOrDefault();
                mySerialPort.PortName = settings.Com_Port;
                mySerialPort.BaudRate = (int)settings.BaudRate;// 9600;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;
                mySerialPort.RtsEnable = true;
              
                mySerialPort.Open();
                connected = true;
                    scalestatus.ItemAppearance.Normal.ForeColor= Color.Green;
                    scalestatus.Caption = "Scale Connected";
                   
                }catch(Exception ex)
                {


                    scalestatus.Caption = "Unable to Connect to scale: " + ex.Message;
                    scalestatus.ItemAppearance.Normal.ForeColor = Color.Red;

                   
                    Logging.Logging.ReportError(ex); }

            }

        }
        private void Weigh_Load(object sender, EventArgs e)
        {

        }

        private void totalBagsDeliveredLabel_Click(object sender, EventArgs e)
        {

        }

        private void bag_weightLabel_Click(object sender, EventArgs e)
        {

        }

        private void bag_weightLabel1_Click(object sender, EventArgs e)
        {

        }

        private void net_kgLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void noButtonEdit_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void collection_NumberButtonEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (currentfarmer != null)
            {
                var fp = db.Paddy_Details.Where(o => o.Farmers_Number == currentfarmer.No).ToList();
                var ffp = fp.Where(o => o.Unweighedbags > 0).ToList();
                if (ffp.Count > 0)

                    using (var form = new Paddy_list())
                    {
                        foreach (Gridcolumn item in form.gridView1.Columns.ToList())
                        {
                            item.Visible = item.Showinlist;
                        }
                        form.gridView1.BestFitColumns(true);
                        form.gridView1.OptionsBehavior.ReadOnly = true;
                        form.gridView1.OptionsSelection.MultiSelect = false;
                        form.gridView1.DoubleClick += new EventHandler(form.gridView1_DoubleClick);

                        var result = form.ShowDialog(ffp);

                        if (result == DialogResult.OK)
                        {
                            if (form.Selectedpaddy != null)
                            {
                                collection_NumberButtonEdit.EditValue = form.Selectedpaddy.Collection_Number;
                                collection_NumberButtonEdit_Leave(null, null);
                            }
                        }
                    }
            }
        }

        private void collection_NumberButtonEdit_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void collection_NumberButtonEdit_Leave(object sender, EventArgs e)
        {
            if (collection_NumberButtonEdit.EditValue != null)
                if (collection_NumberButtonEdit.EditValue.ToString() != string.Empty)
                {
                    string paddy = collection_NumberButtonEdit.EditValue.ToString();
                    currentpaddy = db.Paddy_Details.FirstOrDefault(o => o.Collection_Number == paddy);
                    if (currentpaddy == null)
                    {
                        new ErrorProvider().SetError(collection_NumberButtonEdit, "Delivery Not found");
                        return;
                    }
                    paddy_DetailBindingSource.DataSource = currentpaddy;
                    if (currentpaddy != null)
                    {
                        //if (currentpaddy.Unweighedbags<10)
                       //no_of_bagsSpinEdit.EditValue = currentpaddy.Unweighedbags;
                        no_of_bagsSpinEdit.Properties.MaxValue =(decimal) currentpaddy.Unweighedbags;
                    }
                    paddy_BagBindingSource.DataSource = db.Paddy_Details.FirstOrDefault(o => o.Collection_Number == currentpaddy.Collection_Number).BagsWeighed.ToList();
                }
        }

        private void noButtonEdit_Leave(object sender, EventArgs e)
        {
            if (noButtonEdit.EditValue != null)
                if (noButtonEdit.EditValue.ToString() != string.Empty)
                {
                    var farmer = noButtonEdit.EditValue.ToString();
                    currentfarmer = db.Farmers.FirstOrDefault(o => o.No == farmer);
                    if (currentfarmer != null)
                        farmerBindingSource.DataSource = currentfarmer;
                 else {
                        var c = db.Customers.FirstOrDefault(o=> o.ID == farmer );
                        if (c != null)
                        {
                            Farmer f = new Farmer();
                            f.Name = c.Name;
                            f.No = c.ID;
                            f.Bank = c.Bank;
                            f.Bank_Account = c.Bank_Account;
                            db.Farmers.Add(f);
                            db.SaveChanges(RiceEntities.Savetype.Updatestatus);
                            currentfarmer = f;
                            farmerBindingSource.DataSource = f;
                        }
                    }

                    //else
                    //    new ErrorProvider().SetError(noButtonEdit, "No Farmer/customer Found");
                }
            getdelivery();
        }
        private void getdelivery()
        {
            if (currentfarmer != null)
            {  var fp = db.Paddy_Details.Where(o => o.Farmers_Number == currentfarmer.No && (Collections.Status) o.Status != Collections.Status.Cancelled ).ToList();
            var ffp = fp.Where(o => o.Unweighedbags > 0).ToList();
                if (ffp.Count>0)
                    if (ffp.Count > 1)
                        using (var form = new Paddy_list())
                        {                           
                            form.gridView1.BestFitColumns(true);
                            form.gridView1.OptionsBehavior.ReadOnly = true;
                            form.gridView1.OptionsSelection.MultiSelect = false;
                            form.gridView1.DoubleClick += new EventHandler(form.gridView1_DoubleClick);
                            var result = form.ShowDialog(ffp);
                            if (result == DialogResult.OK)
                            {
                                if (form.Selectedpaddy != null)
                                {
                                    collection_NumberButtonEdit.EditValue = form.Selectedpaddy.Collection_Number;
                                    collection_NumberButtonEdit_Leave(null, null);
                                }
                            }
                        }
                    else
                    {
                        collection_NumberButtonEdit.EditValue = ffp.FirstOrDefault().Collection_Number;
                        collection_NumberButtonEdit_Leave(null, null);
                    }
            }
        }
        private void noButtonEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (var form = new Farmers())
            {
                var result = form.ShowDialog(true);
                if (result == DialogResult.OK)
                {
                    if (form.navigation1.Selecteditem != null)
                    {
                        noButtonEdit.EditValue =((Farmer)form.navigation1.Selecteditem).No;
                    }
                }
            }
        }
        Paddy_Bag pb = null;
        private bool capture = false;
        private bool paddyok = false;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            capture = true;
            if (collection_NumberButtonEdit.EditValue == null)
            {
                new ErrorProvider().SetError(collection_NumberButtonEdit, "Please Select Delivered paddy");
                collection_NumberButtonEdit.Focus();
                return;
            }
            if (no_of_bagsSpinEdit.EditValue == null)
            {
                new ErrorProvider().SetError(no_of_bagsSpinEdit, "Please Enter No of bags weighed");
                no_of_bagsSpinEdit.Focus();
                return;
            } 
            if (Convert.ToDouble( no_of_bagsSpinEdit.EditValue) <=0)
            {
                new ErrorProvider().SetError(no_of_bagsSpinEdit, "Please Enter No of bags weighed");
                no_of_bagsSpinEdit.Focus();
                return;
            }


            if (moistureSpinEdit.EditValue == null)
            {
                new ErrorProvider().SetError(moistureSpinEdit, "Please enter Moisture Percentage");
                moistureSpinEdit.Focus();
                return;
            }
            if (Convert.ToDouble(moistureSpinEdit.EditValue) <=0)
            {
                new ErrorProvider().SetError(moistureSpinEdit, "Please enter Moisture Percentage");
                moistureSpinEdit.Focus();
                return;
            }

        if (recoverySpinEdit.EditValue == null)
            {
                new ErrorProvider().SetError(recoverySpinEdit, "Please enter Recovery Percentage");
                recoverySpinEdit.Focus();
                return;
            }
        if (Convert.ToDouble(recoverySpinEdit.EditValue) <= 0)
            {
                new ErrorProvider().SetError(recoverySpinEdit, "Please enter Recovery Percentage");
                recoverySpinEdit.Focus();
                return;
            }


            if (no_of_bagsSpinEdit.EditValue == null)
            {
                new ErrorProvider().SetError(moistureSpinEdit, "Please enter No of bags");
                no_of_bagsSpinEdit.Focus();
                return;
            }
            if (bag_typeImageComboBoxEdit.EditValue == null)
            {
                new ErrorProvider().SetError(bag_typeImageComboBoxEdit, "Please select the bag type");
                bag_typeImageComboBoxEdit.Focus();
                return;
            }
            if (gross_kgSpinEdit.EditValue == null)
            {
                new ErrorProvider().SetError(gross_kgSpinEdit, "Nothing Weighed");
                bag_typeImageComboBoxEdit.Focus();
                return;
            }

            if (Convert.ToDouble( gross_kgSpinEdit.EditValue) <=0 )
            {
                new ErrorProvider().SetError(gross_kgSpinEdit, "Weight should be greater than 0");
                bag_typeImageComboBoxEdit.Focus();
                return;
            }
            var paddy = (Paddy_Detail)paddy_DetailBindingSource.Current;
            if (paddy.Unweighedbags <Convert.ToDouble( no_of_bagsSpinEdit.EditValue))
            {
                new ErrorProvider().SetError(no_of_bagsSpinEdit, "All Bag have been weighed for this Delivery");
                no_of_bagsSpinEdit.Focus();
                return;
            }
            if (paddy.Unweighedbags == 0)
            {
               MessageBox.Show("All Bag have been weighed for this Delivery");
                               return;
            }
            pb = new Paddy_Bag();
            pb.Action = 1;
            pb.Date = DateTime.Now.Date;
            pb.Time = DateTime.Now;
            pb.Id = DateTime.Now.Ticks.ToString();
            pb.Weighed_by = rice.user.Name;
            pb.Farmer = noButtonEdit.EditValue.ToString();
            pb.Gross_kg = Convert.ToDecimal((gross_kgSpinEdit.EditValue != null ? Convert.ToDouble(gross_kgSpinEdit.EditValue) : 0));
            pb.Variety = currentpaddy.Variety;
            pb.Paddy = collection_NumberButtonEdit.EditValue.ToString();
            pb.Bag_type = (int)(bag_typeImageComboBoxEdit.EditValue );
            pb.No_of_bags = (no_of_bagsSpinEdit.EditValue != null ? Convert.ToDouble(no_of_bagsSpinEdit.EditValue) : 0);
            double moisture = Convert.ToDouble(((((moistureSpinEdit.EditValue != null ? Convert.ToDouble(moistureSpinEdit.EditValue) : 0) - 13) / 87) * (gross_kgSpinEdit.EditValue != null ? Convert.ToDouble(gross_kgSpinEdit.EditValue) : 0)));
            pb.Moisture_Weight = (moisture < 0 ? 0 : moisture);
            moisture_WeightLabel1.Text = Convert.ToDouble(pb.Moisture_Weight).ToString("N2");

            int bt = (int)bag_typeImageComboBoxEdit.EditValue;
            var bww = db.Bag_Weights.FirstOrDefault(o => o.Bag_Type == bt);
            double bw = (bww != null ? (double)bww.Weight : 0);
            pb.Bag_weight = (decimal)Convert.ToDouble((no_of_bagsSpinEdit.EditValue != null ? Convert.ToDouble(no_of_bagsSpinEdit.EditValue) : 0) * bw);
            bag_weightLabel1.Text = Convert.ToDouble(pb.Bag_weight).ToString("N2");
            pb.Net_kg = (decimal)Convert.ToDouble((gross_kgSpinEdit.EditValue != null ? Convert.ToDouble(gross_kgSpinEdit.EditValue) : 0) - Convert.ToDouble(moisture_WeightLabel1.Text) - Convert.ToDouble(bag_weightLabel1.Text));
            net_kgLabel1.Text = Convert.ToDouble(pb.Net_kg).ToString("N2");
            paddyok = true;

           //set weigher

            var pp = db.Paddy_Details.FirstOrDefault(o => o.Collection_Number == collection_NumberButtonEdit.EditValue.ToString());
            if (pp!=null){
                pp.Weighed_by = rice.user.Name;
                pp.Date_Changed = DateTime.Now.Date;
            }

         
            simpleButton1.Focus();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            capture = false;
        }

        private void no_of_bagsSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            //no_of_bagsSpinEdit.SelectAll();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (capture == false)
                simpleButton2_Click(null, null);
            if (paddyok)
            {
                db.Paddy_Bags.Add(pb);
                currentpaddy.Weighed_by = rice.user.Name;
                db.SaveChanges(RiceEntities.Savetype.Updatestatus);
                rice.bags = db.Paddy_Bags.ToList();
                
                rice.populatelists();
               
                paddyok = false;


                no_of_bagsSpinEdit.EditValue = 0;
                gross_kgSpinEdit.EditValue = 0;
                moisture_WeightLabel1.Text = "0";
                bag_weightLabel1.Text = "0";
                net_kgLabel1.Text = "0";
                
                var fp = db.Paddy_Details.Where(o => o.Farmers_Number == currentfarmer.No).ToList();
                var ffp = fp.Where(o => o.Unweighedbags > 0).ToList();
                if (ffp.Count > 0)
                    getdelivery();

                paddy_BagBindingSource.DataSource = db.Paddy_Details.FirstOrDefault(o => o.Collection_Number == currentpaddy.Collection_Number).BagsWeighed.ToList();
                capture = true;
            }
        }

        private void recoverySpinEdit_Leave(object sender, EventArgs e)
        {
            if (recoverySpinEdit.EditValue == null)
                recoverySpinEdit.EditValue = "50";
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (currentpaddy != null)
            {
                Reports.Weighslip report = new Reports.Weighslip();
                report.p =db.Paddy_Details.FirstOrDefault(o=> o.Collection_Number ==  currentpaddy.Collection_Number);
                Task task = Task.Factory.StartNew(() =>
          {
              using (ReportPrintTool printTool = new ReportPrintTool(report))
              {
                  // Invoke the Ribbon Print Preview form modally, 
                  // and load the report document into it.
                  printTool.PrinterSettings.Copies = 2;
                  printTool.Print();
                  // Invoke the Ribbon Print Preview form
                  // with the specified look and feel setting.
                  //printTool.ShowRibbonPreviewDialog(UserLookAndFeel.Default);
              }
          });
            }
            // farmerBindingSource.DataSource = null;
            //paddy_BagBindingSource.DataSource = null;
            //paddy_DetailBindingSource = null;


        }

        private void paddy_DetailBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            db.SaveChanges(savetype: RiceEntities.Savetype.Updatestatus);
        }

        private void btnpost_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            simpleButton1_Click(null, null);
        }

        private void btnpostprint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            simpleButton4_Click(null, null);
        }

        private void moistureSpinEdit_Enter(object sender, EventArgs e)
        {
           
        }

        private void recoverySpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            recoverySpinEdit.SelectAll();
        }
        private void moistureSpinEdit_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void moistureSpinEdit_Click(object sender, EventArgs e)
        {
       
        }

        private void recoverySpinEdit_MouseClick(object sender, MouseEventArgs e)
        {
            recoverySpinEdit.SelectAll();
        }

        private void moistureSpinEdit_MouseClick(object sender, MouseEventArgs e)
        {
            moistureSpinEdit.SelectAll();
        }

        private void Weigh_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Task.Factory.StartNew(() => { mySerialPort.Close(); });
              
            }
            catch (Exception ex) { }
        }

        private void no_of_bagsLabel_Click(object sender, EventArgs e)
        {

        }

        private void moistureSpinEdit_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
   
}
