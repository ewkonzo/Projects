using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using System.IO.Ports;
using System.Drawing.Printing;
using System.Drawing.Imaging;

using System.IO;
using DevExpress.XtraReports.UI;
using System.Threading.Tasks;

namespace Coffee
{
    public partial class Collection : Form
    {
        private decimal gross, tare;

        public Collection()
        {
            InitializeComponent();

            Serial.mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            Serial.mySerialPort.ErrorReceived += new SerialErrorReceivedEventHandler(serialerrorHandler);
            try
            {
                if (coffee.user.Type != "Admin")
                {
                    btnManual.Visible = false;
                    txtkg.Enabled = false;
                }
                //Serial.serial();
                Task.Factory.StartNew(() =>
                {
                    bool connected = false;
                    while (connected == false)
                    {
                        try
                        {
                            Serial.serial();
                            connected = true;
                            if (this.Scalestatus.InvokeRequired)
                            {
                                this.Scalestatus.BeginInvoke((MethodInvoker)delegate()
                                {
                                    this.Scalestatus.Text = "Connected"; this.Scalestatus.ForeColor = Color.Green;
                                });

                            }
                            else
                            {
                                Scalestatus.ForeColor = Color.Green;
                                Scalestatus.Text = "Connected";
                            }
                        }
                        catch (Exception e)
                        {
                            if (this.Scalestatus.InvokeRequired)
                            {
                                this.Scalestatus.BeginInvoke((MethodInvoker)delegate()
                                {
                                    Scalestatus.Text = "Not Connected: " + e.Message;
                                    Scalestatus.ForeColor = Color.Red;
                                });

                            }
                            else
                            {
                                Scalestatus.Text = "Not Connected: " + e.Message;
                                Scalestatus.ForeColor = Color.Red;

                            }

                        }
                        System.Threading.Thread.Sleep(10000);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logging.Logging.ReportError(ex);
            }
            finally
            {
                loadtodays();
            }
            noofbags.Text = "1";



        }
        Farmer f;
        Daily_Collections_Detail c;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dbb = new AutoweighEntities(coffee.ConnectionString()))
                {
                    if (this.txtfarmer.Text.Equals(""))
                    {
                        errorProvider1.SetError(txtfarmer, "Farmer No required");
                        return;
                    }

                    if (this.txtkg.Text.Equals(""))
                    {
                        errorProvider1.SetError(txtkg, "Kg required");
                        return;
                    }
                    if (f == null)
                    {
                        MessageBox.Show("Farmer record not found");
                        txtfarmer.Focus();
                        return;
                    }
                    if (Convert.ToDouble(this.txtkg.Text) == 0)
                    {
                        errorProvider1.SetError(txtkg, "Kg required");
                        return;
                    }
                    var dat = DateTime.Now.Date;
                    var sold = dbb.Daily_Collections_Details.FirstOrDefault(o => o.Collections_Date == dat && o.Farmers_Number == f.No && o.Cancelled == "No");
                    if (coffee.setup.Allow_Multiple_sales == true)
                    {
                        var m = dbb.Daily_Collections_Details.Where(o => o.Collections_Date == dat && o.Farmers_Number == f.No && o.Cancelled == "No").Count();
                        if (m >= coffee.setup.No_of_sales_per_day)
                        {
                            MessageBox.Show("No of sales per day limit exceeded for Member " + f.No);
                            return;
                        }
                    }
                    else if (sold != null && (server.Account_Category)(f.Account_Category == null ? 0 : f.Account_Category) == server.Account_Category.Single)
                    {
                        MessageBox.Show("Farmer cannot deliver twice per day");
                        return;
                    }
                    var cn = string.Format("{0}{1}", f.No, DateTime.Now.ToString("yyMMddmmss"));
                    c = new Daily_Collections_Detail();
                    c.Collections_Date = DateTime.Now.Date;
                    c.Collection_time = DateTime.Now;
                    c.Farmers_Number = txtfarmer.Text;
                    c.Farmers_Name = f.Name;
                    c.Sent = false;
                    c.Collection_Number = cn;
                    c.Cancelled = "No";
                    c.Crop = coffee.setup.Current_crop;
                    c.Coffee_Type = (coffee.setup.Coffe_type == 0 ? "CHERRY" : "MBUNI");
                    c.Factory = coffee.setup.Branch;
                    c.Gross = Convert.ToDouble(txtkg.Text);

                    c.Kg__Collected = Convert.ToDouble(netkg.Text) + Convert.ToDouble(txthold.Text);
                    if (c.Kg__Collected < 0)
                    {
                        MessageBox.Show("Kg cannot be Negative");
                        return;
                    }
                    c.User = coffee.user.Name;
                    c.Collect_type = (auto == true ? "Auto" : "Manual");
                    var ff = dbb.Farmers.FirstOrDefault(o => o.No == f.No);
                    if (ff != null)
                        if (coffee.setup.Coffe_type == 0)
                        {
                           // ff.Cum_Cherry += c.Kg__Collected;
                            c.Cumm = (double)ff.Cherry + c.Kg__Collected;
                        }
                        else
                        {
                           // ff.Cum_Mbuni += c.Kg__Collected;
                            c.Cumm = (double)ff.Mbuni + c.Kg__Collected;

                        }


                    dbb.Daily_Collections_Details.Add(c);
                    //while (true) {
                    //    try
                    //    {
                            
                    dbb.SaveChanges();
                            //break;
                        //}
                        //catch (Exception ex)
                        //{ Logging.Logging.ReportError(ex); }
                    
                    //}
                }
                loadmembers();
                printreceipt(c);
                //Run(c);
                loadtodays();
                txtfarmer.Text = "";
                txtkg.Text = "";
                netkg.Text = "";
                txthold.Text = "0";
                if (coffee.setup.Manual_tare == false)
                    noofbags.Text = "1";
                else
                    noofbags.Text = "0";
                viewfarmername.Text = "";
                txtfarmer.Focus();
                gross = 0;
                tare = 0;
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
                MessageBox.Show("Unable to post, please try again");
            }
        }
        private void printreceipt(Daily_Collections_Detail c)
        {
            Coffee.Reports.Receipt r = new Reports.Receipt(c);
            ReportPrintTool rpt = new ReportPrintTool(r);
            rpt.PrinterSettings.PrinterName = coffee.setup.Printer;
            rpt.Print();
            coffee.loadlists();

        }
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        
     private void txtfarmer_Leave(object sender, EventArgs e)
        {
            if (this.txtfarmer.Text.Equals(""))
            {
                errorProvider1.SetError(txtfarmer, "Farmer No required");
                txtfarmer.Focus();
            }
            else
            {
                errorProvider1.SetError(txtfarmer, null);
                using (var db = new AutoweighEntities(coffee.ConnectionString()))
                {
                    f = db.Farmers.FirstOrDefault(o => o.No == txtfarmer.Text);
                    if (f == null)
                    {
                        MessageBox.Show("Farmer record not found");
                        txtfarmer.Focus();
                        return;
                    }
                }
                viewfarmername.Text = f.Name;

                loadmembers();
            }
        }
        private void loadtodays()
        {
            Task.Factory.StartNew(() => { loadtodayscollections(); });

        }
        private void loadmembers()
        {
            Task.Factory.StartNew(() => { loadcollections(); });

        }
        private void loadcollections()
        {
            try
            {
                using (var db = new AutoweighEntities(coffee.ConnectionString()))
                {
                    string farmer = txtfarmer.Text;
                    var cumm = db.Daily_Collections_Details.Where(o => o.Farmers_Number == farmer && o.Cancelled == "No" && o.Crop == coffee.setup.Current_crop).ToList();
                    this.Invoke((MethodInvoker)delegate
               {
                   daily_Collections_DetailsBindingSource1.DataSource = cumm;

               });
                }
            }
            catch (Exception ex) { }
        }
        private void loadtodayscollections()
        {
            using (var db = new AutoweighEntities(coffee.ConnectionString()))
            {
                // This line of code is generated by Data Source Configuration Wizard
                var d = DateTime.Now.Date;
                var total = db.Daily_Collections_Details.Where(o => o.Collections_Date == d && o.Crop == coffee.setup.Current_crop).ToList();
                this.Invoke((MethodInvoker)delegate
                {
                    daily_Collections_DetailsBindingSource.DataSource = total;

                });
            }
        }
        private void txtkg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtkg.Text.Equals(""))
                {
                    if (coffee.setup.Manual_tare == false)
                        netkg.Text = Convert.ToString(Convert.ToDouble(txtkg.Text) - ((!noofbags.Text.Equals("") ? Convert.ToDouble(noofbags.Text) : 0) * (double)(coffee.setup.Bag_weight == null ? 0 : coffee.setup.Bag_weight)));
                    else
                        netkg.Text = Convert.ToString(Convert.ToDouble(txtkg.Text) - (!noofbags.Text.Equals("") ? Convert.ToDouble(noofbags.Text) : 0));

                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }
        private void txtkg_Leave(object sender, EventArgs e)
        {
            if (this.txtkg.Text.Equals(""))
                errorProvider1.SetError(txtkg, "Kgs required");
            else
            {
                errorProvider1.SetError(txtkg, null);

            }
        }
        public void serialerrorHandler(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show("Error");

        }
        SerialPort sp;
        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
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

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (auto)
            {
                if (this.txtkg.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.txtkg.Text = text;
                }
            }
        }
        private void Collection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Serial.mySerialPort.IsOpen)
            {
                e.Cancel = true; //cancel the fom closing

                System.Threading.Thread CloseDown = new System.Threading.Thread(new System.Threading.ThreadStart(CloseSerialOnExit)); //close port in new thread to avoid hang

                CloseDown.Start(); //close port in new thread to avoid hang
            }
        }
        private void CloseSerialOnExit()
        {
            try
            {
                Serial.mySerialPort.Close(); //close the serial port
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //catch any serial port closing error messages
            }
            this.Invoke(new EventHandler(NowClose)); //now close back in the main thread
        }
        private void NowClose(object sender, EventArgs e)
        {
            this.Close(); //now close the form
        }
        private void btnopenport_Click(object sender, EventArgs e)
        {
            try
            {
                Serial.serial();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            sp.WriteLine("Zero");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sp.WriteLine("Tare");
        }
        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    if (((TextBox)sender).Name == "txtfarmer")
                    {
                        if (txtkg.Enabled == true)
                        {
                            if (txtfarmer.Text.Equals(""))
                            {
                                errorProvider1.SetError(txtfarmer, "Farmer No required");
                                txtfarmer.Focus();
                            }
                            else
                            {

                                txtkg.Focus();

                            }
                        }
                        else
                            if (coffee.setup.Bag_weight == 0)
                                btnprocess.Focus();
                            else
                                noofbags.Focus();
                    }
                    if (((TextBox)sender).Name == "txtkg")
                    {
                        if (coffee.setup.Bag_weight == 0)
                            btnprocess.Focus();
                        else
                            noofbags.Focus();

                    }
                    if (((TextBox)sender).Name == "noofbags")
                    {
                        btnprocess.Focus();
                    }

                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }
        private void OtherControl_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void txtfarmer_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnprocess_Enter(object sender, EventArgs e)
        {
            //  ((Button)sender) 
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new AutoweighEntities(coffee.ConnectionString()))
                {

                    string c = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, colCollection_Number1).ToString();

                    DialogResult d = MessageBox.Show("Are you sure you want to cancel this receipt", c, MessageBoxButtons.YesNo);

                    if (d == DialogResult.Yes)
                    {
                        var coll = db.Daily_Collections_Details.FirstOrDefault(o => o.Collection_Number == c);
                        if (coll != null)
                        {
                            bool authorize = false;
                            if ((coll.Collections_Date != DateTime.Now.Date) && (coffee.user.Type != "Admin"))
                            {
                                using (var form = new Authorize())
                                {
                                    var result = form.ShowDialog();
                                    if (result == DialogResult.OK)
                                    {
                                        authorize = form.authorized;
                                    }
                                }
                            }
                            else { authorize = true; }

                            if (!authorize)
                            {
                                MessageBox.Show("Not Authorized");
                                return;
                            }
                            if (coll.Cancelled == "Yes")
                            {

                                MessageBox.Show("You can't reverse an already reversed transaction");
                                return;
                            }
                            coll.Cancelled = "Yes";
                            Daily_Collections_Detail ct = new Daily_Collections_Detail();
                            ct.Collections_Date = coll.Collections_Date;
                            ct.Collection_time = coll.Collection_time;
                            ct.Farmers_Number = coll.Farmers_Number;
                            ct.Farmers_Name = coll.Farmers_Name;
                            ct.Sent = false;
                            ct.Collection_Number = coll.Collection_Number + "-1";
                            ct.Cancelled = "Yes";
                            ct.Coffee_Type = coll.Coffee_Type;
                            ct.Factory = coll.Factory;
                            ct.Crop = coll.Crop;
                            ct.Kg__Collected = coll.Kg__Collected * -1;
                            ct.User = coffee.user.Name;
                            ct.Collect_type = coll.Collect_type;

                            var ff = db.Farmers.FirstOrDefault(o => o.No == coll.Farmers_Number);
                            if (ff != null)
                            {
                                if (coffee.setup.Coffe_type == 0)
                                {
                                    ff.Cum_Cherry -= coll.Kg__Collected;

                                    ct.Cumm = (double)ff.Cum_Cherry;
                                }
                                else
                                {
                                    ff.Cum_Mbuni -= coll.Kg__Collected;

                                    ct.Cumm = (double)ff.Cum_Mbuni;
                                }
                            }

                            db.Daily_Collections_Details.Add(ct);
                        }
                        db.SaveChanges();
                        loadtodays();
                        coffee.loadlists();
                    }
                }
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
        }
        private void Reprint(object sender, EventArgs e)
        {
            try
            {
                using (var db = new AutoweighEntities(coffee.ConnectionString()))
                {
                    string c = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, colCollection_Number1).ToString();

                    var coll = db.Daily_Collections_Details.FirstOrDefault(o => o.Collection_Number == c);
                    if (coll != null)
                    {
                        printreceipt(coll);

                    }
                }
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }

        }
        private bool auto = true;
        private void btnManual_Click(object sender, EventArgs e)
        {
            auto = (auto == true ? false : true);
            btnManual.Text = (auto == true ? "Manual" : "Auto");
        }
        private void Collection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                btnManual_Click(null, null);
            }
            if (e.KeyCode == Keys.H)
            {
                btnhold_Click(null, null);
            } if (e.KeyCode == Keys.C)
            {
                button5_Click(null, null);
            }
        }
        private void txtfarmer_KeyPress(object sender, KeyPressEventArgs e)
        {
       //     if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       //(e.KeyChar != '.'))
       //     {
       //         e.Handled = true;
       //     }

       //     // only allow one decimal point
       //     if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
       //     {
       //         e.Handled = true;
       //     }
        }
        private void txtkg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void noofbags_TextChanged(object sender, EventArgs e)
        {

            if (!txtkg.Text.Equals(""))
            {
                // netkg.Text = Convert.ToString(Convert.ToDouble(txtkg.Text) - ((!noofbags.Text.Equals("") ? Convert.ToDouble(noofbags.Text) : 0) * (double)(coffee.setup.Bag_weight == null ? 0 : coffee.setup.Bag_weight)));
                if (coffee.setup.Manual_tare == false)
                    netkg.Text = Convert.ToString(Convert.ToDouble(txtkg.Text) - ((!noofbags.Text.Equals("") ? Convert.ToDouble(noofbags.Text) : 0) * (double)(coffee.setup.Bag_weight == null ? 0 : coffee.setup.Bag_weight)));
                else
                    netkg.Text = Convert.ToString(Convert.ToDouble(txtkg.Text) - (!noofbags.Text.Equals("") ? Convert.ToDouble(noofbags.Text) : 0));
            }
        }
        private void noofbags_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void netkg_Click(object sender, EventArgs e)
        {

        }
              private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Collection_Load(object sender, EventArgs e)
        {
            if ((coffee.setup.Bag_weight == 0) && coffee.setup.Manual_tare == false)
                groupBox2.Visible = false;
            else
                groupBox2.Visible = true;
            if (coffee.setup.Manual_tare == true)
            {
                label2.Text = "Bag weight";
                noofbags.Text = "0";
            }
        }
        private void btnhold_Click(object sender, EventArgs e)
        {
            if (!txtkg.Text.Equals(""))
                txthold.Text = (Convert.ToDouble(txthold.Text) + Convert.ToDouble(netkg.Text)).ToString();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            txthold.Text = "0.0";
        }
        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new AutoweighEntities(coffee.ConnectionString()))
            {
                // This line of code is generated by Data Source Configuration Wizard
                var total = db.Daily_Collections_Details.Where(o => o.Collections_Date == (DateTime)dateEdit1.EditValue && o.Crop == coffee.setup.Current_crop).ToList();
                this.Invoke((MethodInvoker)delegate
                {
                    daily_Collections_DetailsBindingSource.DataSource = total;

                });

            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
