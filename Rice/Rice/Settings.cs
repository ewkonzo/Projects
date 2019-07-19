using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Rice
{
    public partial class Settings : DevExpress.XtraEditors.XtraForm
    {
        private RiceEntities db = new RiceEntities(rice.ConnectionString());
        public Settings()
        {
            InitializeComponent();
            try
            {
                string[] ports = SerialPort.GetPortNames();
                foreach (string port in ports)
                    com_PortImageComboBoxEdit.Properties.Items.Add(port.ToString(), port, -1);

                var printers = System.Drawing.Printing.PrinterSettings.InstalledPrinters;
                foreach (string printer in printers)
                    sales_receipt_PrinterImageComboBoxEdit.Properties.Items.Add(printer.ToString(), printer, -1);
                foreach (var item in Enum.GetValues(typeof(rice.Stockcalculation)))
                    stock_CalculationImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);
                outletBindingSource.DataSource = db.Outlets.ToList();
                settingBindingSource.DataSource = db.Settings.ToList();
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
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
            settingBindingSource.EndEdit();
            db.SaveChanges(RiceEntities.Savetype.ShowMessage);
                      
        }
        Setting s;
             private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            rice.populatelists();
            //settingBindingNavigatorSaveItem_Click(sender, e);
        }
        private void current_cropComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void settingBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Setting sh = null;
                sh = new Setting();
                e.NewObject = sh;
                db.Settings.Add(sh);
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }
        private void settingBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                //db.SaveChanges();
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}