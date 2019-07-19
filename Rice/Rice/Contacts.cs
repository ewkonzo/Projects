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
    public partial class Contacts : Form
    {
        Navigation navigation;
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        public Contacts(bool addnew =false)
        {
            InitializeComponent();
            navigation = new Navigation(contactBindingSource, null, db);
            this.Controls.Add(navigation);
           
            foreach (var item in Enum.GetValues(typeof(NewContact.Membership_Class)))
                membership_ClassImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);
            foreach (var item in Enum.GetValues(typeof(NewContact.Gender)))
                genderImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);
            foreach (var item in Enum.GetValues(typeof(NewContact.Marital_Status)))
                marital_StatusImageComboBoxEdit.Properties.Items.Add(item.ToString(), (int)item, -1);
          
            foreach (var item in rice.sections())
                sectionImageComboBoxEdit.Properties.Items.Add(item.Name, item.Code, -1);
            var b = db.Bank_Accounts.ToList();
            bank_NameLookUpEdit.Properties.DataSource = b.ToList();
            bank_NameLookUpEdit.Properties.DisplayMember = "Name";
            bank_NameLookUpEdit.Properties.ValueMember = "No_";
           
            contactBindingSource.DataSource = db.Contacts.ToList();
            if (addnew)
                contactBindingSource.AddNew();
        }

        private void contactBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Contact sh = new Contact();
                sh.Created_By = rice.user.Name;
                sh.Date_of_Join = DateTime.Now.Date;
                sh.Created_Date = DateTime.Now.Date;
                sh.Account_Status =(int) NewContact.Account_Types.Individual;
                sh.Sent = false;    
                e.NewObject = sh;
                db.Contacts.Add(sh);
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void contactBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            try
            {
                sentCheckEdit.EditValue = false;
                //if (contactBindingSource != null)
                //    if (contactBindingSource.Current != null)
                //        ((Contact)contactBindingSource.Current).Sent = false;
                //contactBindingSource.EndEdit();
                db.SaveChanges(RiceEntities.Savetype.Updatestatus);

                groupControl1.Text = "";
                sentCheckEdit.EditValue = true;
            }
            catch (DbEntityValidationException ee)
            {
                foreach (var eve in ee.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        groupControl1.Text = ve.ErrorMessage;

                    }
                }

            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
        }

        private void unitImageComboBoxEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
        }

        private void member_NoLabel_Click(object sender, EventArgs e)
        {

        }

        private void sectionImageComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
 if (sectionImageComboBoxEdit.EditValue!=null)
            {
                var s = sectionImageComboBoxEdit.EditValue.ToString();
                unitImageComboBoxEdit.Properties.Items.Clear();
                var u = rice.units.Where(o => o.Section == s).ToList();
            foreach (var item in u)
                unitImageComboBoxEdit.Properties.Items.Add(item.Name, item.Code, -1);}
        }
    }
}
