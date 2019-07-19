using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Weigh
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            try
            {
                s = AutoweighEntities.Db.Settings.FirstOrDefault();
                if (s != null)
                    txtfactory.Text = s.Branch;
                cmbcoffetype.SelectedIndex = (int)s.Coffe_type;
                baudRateSpinEdit.Text = s.BaudRate.ToString();
                txtserver.Text = s.Server_url;
                string[] ports = SerialPort.GetPortNames();
                int i = 0;
                foreach (string port in ports)
                {
                    com_PortTextEdit.Items.Add(port);
                    if (s.Com_Port == port)
                        com_PortTextEdit.SelectedIndex = i;
                    i++;
                }

                i = 0;
                var d = ports.ToList().IndexOf(s.Com_Port);
                com_PortTextEdit.SelectedIndex = ports.ToList().IndexOf(s.Com_Port);
                var printers = System.Drawing.Printing.PrinterSettings.InstalledPrinters;
                foreach (string printer in printers)
                {
                    cmbprinter.Items.Add(printer);
                    if (s.Printer == printer)
                        cmbprinter.SelectedIndex = i;
                    i++;
                }

                // cmbprinter.SelectedIndex = printers.FindIndex(o => o == s.);
                loadcrops();
                i = 0;
                foreach (var item in AutoweighEntities.Db.Crops)
                {
                    if (s.Current_crop == item.Crop_Name)
                        current_cropComboBox.SelectedIndex = i;
                    i++;
                }
                if (AutoweighEntities.user.Type != "Admin")
                {
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                }
                checkEdit1.Checked =(bool) s.Pick_factory_farmers;

            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
        }
        private void loadcrops()
        {
            AutoweighEntities db = new AutoweighEntities();
            db.Crops.Load();
            current_cropComboBox.DataSource = db.Crops.ToList();
            current_cropComboBox.DisplayMember = "Crop_Name";
            current_cropComboBox.ValueMember = "Crop_Name";

        }
        private void Settings_Load(object sender, EventArgs e)
        {
            var d = AutoweighEntities.Db.Settings;
            if (d.Count() > 0)
                bindingNavigatorAddNewItem.Visible = false;
        }
        private void settingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            s.Com_Port = com_PortTextEdit.Text;
            s.BaudRate = Convert.ToInt32(baudRateSpinEdit.Text);
            s.Branch = txtfactory.Text;
            s.Coffe_type = cmbcoffetype.SelectedIndex;
            s.Printer = cmbprinter.Text;
            s.Server_url = txtserver.Text;
            s.Current_crop = current_cropComboBox.Text;
            s.Pick_factory_farmers = checkEdit1.Checked;
            AutoweighEntities.Db.SaveChanges(true);
            AutoweighEntities.setup = AutoweighEntities.Db.Settings.FirstOrDefault();
        }
        Setting s;
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            s = new Setting();
            AutoweighEntities.Db.Settings.Add(s);
            bindingNavigatorAddNewItem.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {

            //settingBindingNavigatorSaveItem_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Crops c = new Crops();
            c.ShowDialog();
            loadcrops();
        }

        private void current_cropComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string cc = current_cropComboBox.Text;
                if (!cc.Equals(AutoweighEntities.setup.Current_crop))
                if (MessageBox.Show("Are you sure you want to change the Crop year", "Change Crop", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (var db = new AutoweighEntities())
                    {
                        var f = db.Farmers. ToList();

                        Cursor.Current = Cursors.WaitCursor;

                        foreach (var farmer in f)
                        {
                            var tcherry = db.Daily_Collections_Details.Where(o => o.Farmers_Number == farmer.No && o.Crop == cc && o.Coffee_Type == "CHERRY").Sum(o => o.Kg__Collected);
                            if (tcherry != null)
                                farmer.Cum_Cherry = (double)tcherry;
                            else
                                farmer.Cum_Cherry = 0;

                            var tmbuni = db.Daily_Collections_Details.Where(o => o.Farmers_Number == farmer.No && o.Crop == cc && o.Coffee_Type == "MBUNI").Sum(o => o.Kg__Collected);
                            if (tmbuni != null)
                                farmer.Cum_Mbuni = (double)tmbuni;
                            else
                                farmer.Cum_Mbuni = 0;
                        }
                        db.SaveChanges();
                    
                        MessageBox.Show("Crop year successfully changed");
                    }

                }
            }
            catch (Exception ex) {
                Logging.Logging.ReportError(ex);
            MessageBox.Show("Unable to change crop year");
            }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}