using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Weigh
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtusername.Text.Equals(""))
                {
                    errorProvider1.SetError(txtusername, "User name required");
                    return;
                }
                if (txtpassword.Text.Equals(""))
                {
                    errorProvider1.SetError(txtpassword, "Password required");
                    return;
                }
                var encryptedpass = txtpassword.Text;// AutoweighEntities.GetMd5Hash(txtpassword.Text);
                var user = AutoweighEntities.Db.Users.FirstOrDefault(o => o.Name == txtusername.Text && o.Password == encryptedpass);
                if (user != null)
                {
                    AutoweighEntities.user = user;
                    WeighMain wm = new WeighMain();
                    wm.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Invalid Username or password");

            }
            catch (Exception ex) { Logging.Logging.ReportError(ex);
                MessageBox.Show(ex.Message);
            } }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
