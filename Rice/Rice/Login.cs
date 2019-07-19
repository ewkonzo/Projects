using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hangfire;
using System.Threading.Tasks;
using System.Threading;

namespace Rice
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        RiceEntities db = new RiceEntities(rice.ConnectionString());
        public Login()
        {
            InitializeComponent();
            Logging.Logging.logpath = @"C:\Logs\";
            //Task task = Task.Factory.StartNew(() =>
            // {
                 try
                 {
                    //Scripting.Createscript();
                 }
                 catch (Exception ex)
                 {
                     Logging.Logging.ReportError(ex);
                 }
             //});

                
        }
        
     Rice.User u = new Rice.User();
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {               

                if (txtusername.Text.Equals(""))
                {
                    errorProvider1.SetError(txtusername, "User name required");
                    txtusername.Focus();
                    return;
                }
                if (txtpassword.Text.Equals(""))
                {
                    errorProvider1.SetError(txtpassword, "Password required");
                    txtpassword.Focus();
                    return;
                }

            if (panelControl2.Visible){
                if (outletImageComboBoxEdit.EditValue == null)
                {
                    errorProvider1.SetError(outletImageComboBoxEdit, "Outlet required");
                    outletImageComboBoxEdit.Focus();
                    return;
                }
                if (string.IsNullOrEmpty( outletImageComboBoxEdit.EditValue.ToString()))
                {
                    errorProvider1.SetError(outletImageComboBoxEdit, "Outlet required");
                    outletImageComboBoxEdit.Focus();
                    return;
                }
            }
                
                
                u.Name = txtusername.Text.ToUpper();
                u.Password = txtpassword.Text;
                
                var user = rice.login(u);
               
                if (user.Code == 0)
                {

                    WeighMain wm = new WeighMain();
                    wm.Show();
                    var dd = new externaldata();
                    Task.Factory.StartNew(() => dd.load());
                    this.Hide();
                }
                else
                    MessageBox.Show(user.Desc);

            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);

                MessageBox.Show(ex.Message);
              
             
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
              
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            if (rice.outlets == null)
                rice.outlets = db.Outlets.ToArray();
            var useroutlet = db.User_outlets.Where(o => o.User_Name == txtusername.Text);
                     panelControl2.Visible=useroutlet.Count()>1;
                     if (useroutlet.Count() == 1)
                         u.Outlet = useroutlet.FirstOrDefault().Active_Outlet;
            if (useroutlet.Count()>1)
                 foreach (var item in db.User_outlets.Where(o=> o.User_Name == txtusername.Text) .ToList())
                     outletImageComboBoxEdit.Properties.Items.Add(item.outlet_name, item.Active_Outlet, -1);
            rice.useroutlets = useroutlet.ToArray();
        }

        private void outletImageComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outletImageComboBoxEdit.EditValue != null) 
            u.Outlet = outletImageComboBoxEdit.EditValue.ToString();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
