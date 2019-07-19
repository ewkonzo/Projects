using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Coffee
{
    public partial class FrmchangePass : Form
    {
        public FrmchangePass()
        {
            InitializeComponent();
        }

        private void FrmchangePass_Load(object sender, EventArgs e)
        {
            if (coffee.user != null) {
                this.Text = coffee.user.Name;
            }
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorProvider er = new ErrorProvider();
                if (txtnew.Text.Equals(""))
                {
                    er.SetError(txtnew, "New password required");
                    txtnew.Focus();
                    return;
                }
                if (txtconfirm.Text.Equals(""))
                {
                    er.SetError(txtconfirm, "Confirm password required");
                    txtconfirm.Focus();
                    return;
                }
                if (!txtnew.Text.Equals(txtconfirm.Text))
                {

                    MessageBox.Show("Password confirmation does not match");
                    return;
                }
                using (var db = new AutoweighEntities(coffee.ConnectionString())){
                var pass = db.Users.FirstOrDefault(o => o.Name== coffee.user.Name);
                if (pass != null)
                {
                    pass.Password = txtconfirm.Text;
                    db.SaveChanges(true);
                    this.Close();
                }}


            }

            catch(Exception ex) { Logging.Logging.ReportError(ex);MessageBox.Show("Unable to change password"); }
        }
    }
}
