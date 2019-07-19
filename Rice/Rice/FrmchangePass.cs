using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rice
{
    public partial class FrmchangePass : Form
    {
        public bool Passwordchanged= false;
        public FrmchangePass()
        {
            InitializeComponent();
        }

        private void FrmchangePass_Load(object sender, EventArgs e)
        {
            if (rice.user != null) {
                this.Text = rice.user.Name;
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
                using (var db = new RiceEntities(rice.ConnectionString()))
                {
                    var pass = db.Users.FirstOrDefault(o => o.Name == rice.user.Name);
                if (pass != null)
                {
                    pass.Password = txtconfirm.Text;
                    pass.Password_Changed = true;
                    Passwordchanged = true;
                    pass.Date_Password_Changed = DateTime.Now;
                    pass.Updated = true;
                    db.SaveChanges(RiceEntities.Savetype.ShowMessage);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }}
            }
            catch(Exception ex) { Logging.Logging.ReportError(ex);MessageBox.Show("Unable to change password"); }
        }
    }
}
