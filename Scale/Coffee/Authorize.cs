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
    public partial class Authorize : Form
    {
        public Boolean authorized = false;
        AutoweighEntities db = new AutoweighEntities(coffee.ConnectionString());
        public User user = null;
        public Authorize()
        {
            InitializeComponent();
            userBindingSource.DataSource = db.Users.Where(o => o.Type == "Admin").ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = db.Users.FirstOrDefault(o => o.Name == comboBox1.Text && o.Password == textBox1.Text);
            if (u != null)
            {
                this.authorized = true;
                user = u;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                new ErrorProvider().SetError(textBox1, "Invalid username or password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
