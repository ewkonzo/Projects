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

namespace Coffee
{
    public partial class Settings : Form
    {
        private AutoweighEntities db = new AutoweighEntities(coffee.ConnectionString());
        public Settings()
        {
            InitializeComponent();
            try
            {
                server_urlTextBox.Enabled = client.connectedtomain;
                foreach (var item in Enum.GetValues(typeof(coffee.Coffee_Type)))
                    coffe_typeImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);
  
              
                string[] ports = SerialPort.GetPortNames();
              
                foreach (string port in ports)
                {
                    com_PortComboBox.Items.Add(port);
                                 }
                var printers = System.Drawing.Printing.PrinterSettings.InstalledPrinters;
                foreach (string printer in printers)
                {
                    printerComboBox.Items.Add(printer);
                  }
                // cmbprinter.SelectedIndex = printers.FindIndex(o => o == s.);
                loadcrops();
                if (coffee.user.Type != "Admin")
                {
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                }
                settingBindingSource.DataSource = db.Settings.ToArray();
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
        }
        private void loadcrops()
        {
            using (var db = new AutoweighEntities(coffee.ConnectionString()))
            {
                db.Crops.Load();
                current_cropComboBox.DataSource = db.Crops.ToList();
                current_cropComboBox.DisplayMember = "Crop_Name";
                current_cropComboBox.ValueMember = "Crop_Name";
            }
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            var d = db.Settings;
            if (d.Count() == 0)
              settingBindingSource.AddNew();
        }
        private void settingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {        
            db.SaveChanges(true);
        }
        Setting s;
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            s = new Setting();
           db.Settings.Add(s);
            bindingNavigatorAddNewItem.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {

            db.SaveChanges();
            coffee.loadlists();
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
               //string cc = current_cropComboBox.Text;
               // if (!cc.Equals(coffee.setup.Current_crop))
               // if (MessageBox.Show("Are you sure you want to change the Crop year", "Change Crop", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
               // {
               //     using (var db = new AutoweighEntities(coffee.ConnectionString()))
               //     {
               //         var f = db.Farmers. ToList();

               //         Cursor.Current = Cursors.WaitCursor;
               //         var colls = db.Daily_Collections_Details.ToList();
               //         foreach (var farmer in f)
               //         {
               //             var tcherry = colls.Where(o => o.Farmers_Number == farmer.No && o.Crop == cc && o.Coffee_Type == "CHERRY").Sum(o => o.Kg__Collected);
               //             if (tcherry != null)
               //                 farmer.Cum_Cherry = (double)tcherry;
               //             else
               //                 farmer.Cum_Cherry = 0;

               //             var tmbuni = colls.Where(o => o.Farmers_Number == farmer.No && o.Crop == cc && o.Coffee_Type == "MBUNI").Sum(o => o.Kg__Collected);
               //             if (tmbuni != null)
               //                 farmer.Cum_Mbuni = (double)tmbuni;
               //             else
               //                 farmer.Cum_Mbuni = 0;
               //         }
               //         db.SaveChanges();
                    
               //         MessageBox.Show("Crop year successfully changed");
               //     }

               // }
            }
            catch (Exception ex) {
                Logging.Logging.ReportError(ex);
            MessageBox.Show("Unable to change crop year");
            }
            finally { Cursor.Current = Cursors.Default; }
        }

       
        private void allow_Multiple_salesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            no_of_sales_per_dayNumericUpDown.Enabled = allow_Multiple_salesCheckBox.Checked;
        }

        private void current_cropComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
  
        }
    }
}