using DevExpress.XtraReports.UI;
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
    public partial class PosCash : DevExpress.XtraEditors.XtraForm
    {
        RiceEntities db ;
        List<Items_Services_List> lines;
        Items_Header header;
        public PosCash()
        {
            InitializeComponent();

             }
        public PosCash(List<Items_Services_List> items,Items_Header h, RiceEntities db )
        {
         InitializeComponent();
         foreach (var item in Enum.GetValues(typeof(ItemList.Payment_Mode)))
                payment_ModeImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);
         this.db = db;
           this.lines = items;
           this.header = h;
        }
        private void PosCash_Load(object sender, EventArgs e)
        {
        }
                private void payment_ModeLabel_Click(object sender, EventArgs e)
        {
                            }
        public DialogResult ShowDialog(Items_Header p)
        {
            items_HeaderBindingSource.DataSource = header;
          // this.Enabled = (bool)!header.Posted;
            return base.ShowDialog();
        }
        private void cashTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                balanceLabel2.Text = "";
                changeLabel2.Text = "";
                if (cashTextBox.Text != "")
                {
                    double bal = (Convert.ToDouble(cashTextBox.Text) - Convert.ToDouble(amountLabel1.Text));

                    if (bal < 0)
                    {
                        balanceLabel2.Text =String.Format("({0})", (bal * -1).ToString("N2"));
                        changeLabel2.Text = "0";
                    }
                    else
                    {
                        changeLabel2.Text = bal.ToString("N2");
                        balanceLabel2.Text = "0";
                    }
                }
                items_HeaderBindingSource.EndEdit();

            }
            catch (Exception ex) {
                Logging.Logging.ReportError(ex);
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (payment_ModeImageComboBoxEdit.EditValue.ToString() != string.Empty)
            {
                switch (((ItemList.Payment_Mode)payment_ModeImageComboBoxEdit.EditValue))
                {
                    case ItemList.Payment_Mode.Mpesa:
                    case ItemList.Payment_Mode.Bank_Deposit:
                        if (referenceTextBox.Text == string.Empty)
                        {
                            MessageBox.Show("Reference Must have a value");
                            return;
                        }
                        break;
                    case ItemList.Payment_Mode.Cash:
                        if (Convert.ToDouble(amountLabel1.Text) > Convert.ToDouble(cashTextBox.Text))
                        {
                            MessageBox.Show("Cash Transaction not paid in full, Please change to Payment mode to Credit");
                            return;
                        }
                        break;
                }
            }
            var h = ((Items_Header)items_HeaderBindingSource.Current);
            h.Posted = true;
            foreach (var it in lines)
            {
                it.Payment_Mode = h.Payment_Mode;
                it.Reference = h.Reference;
                it.Customer = h.Customer;
                it.Phone_No = h.Phone_No;
                it.Posted = 1;
                db.Items_Services_List.Add(it);
            }
            db.Items_Headers.Add(h);
            db.SaveChanges();
            Items_Header ih =db.Items_Headers.FirstOrDefault(o=>  o.Collection_No==  header.Collection_No);
           Task task = Task.Factory.StartNew(() =>
           {
               Reports.Sales_Receipt s = new Reports.Sales_Receipt();
               s.i = ih;
               using (ReportPrintTool printTool = new ReportPrintTool(s))
               {
                   if (!string.IsNullOrEmpty(rice.setup.Sales_receipt_Printer))
                       printTool.PrinterSettings.PrinterName = rice.setup.Sales_receipt_Printer;
                   printTool.Print();
               }
           });
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void changeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void changeLabel2_Click(object sender, EventArgs e)
        {

        }

        private void changeLabel2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void payment_ModeImageComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (payment_ModeImageComboBoxEdit.EditValue.ToString() != string.Empty)
            {
                panel1.Visible = false;
                switch (((ItemList.Payment_Mode)payment_ModeImageComboBoxEdit.EditValue))
                {
                    case ItemList.Payment_Mode.Credit:
                        customerTextBox.Text = "";
                        break;
                    case ItemList.Payment_Mode.Cash:
                        customerTextBox.Text = "CASH SALE";
                        break;
                    default:
                        panel1.Visible = true;
                        customerTextBox.Text = "";
                        referenceTextBox.Text = "";
                        break;
                    
                }
                items_HeaderBindingSource.EndEdit();
              
            }
        }
    }
}
