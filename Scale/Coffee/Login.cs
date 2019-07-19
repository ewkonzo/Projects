using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Coffee
{
    public partial class Login : Form
    {  AutoweighEntities db ;
        public Login()
    {
        InitializeComponent();
        //try
        //{
        string path = "Settings.xml";
        settings s = new settings().loadsettings(path);
            Logging.Logging.LogEntryOnFile("Starting");
                
            db = new AutoweighEntities(coffee.ConnectionString());
            //Scripting.Createscript();
            string text = System.IO.File.ReadAllText("Script.sql");
           string connectionString;
            if (s.IntegratedSecurity)
             connectionString=string.Format("Data Source={0}\\{1};Initial Catalog={2};Integrated Security={3}",s.Serverip,s.Instance,s.database,s.IntegratedSecurity);
            else
                connectionString = string.Format("Data Source={0}\\{1};Initial Catalog={2};Integrated Security={3};User id={4};Password={5}", s.Serverip, s.Instance, s.database, s.IntegratedSecurity,s.Username,s.pass);

            // Provide the query string with a parameter placeholder. 
            string queryString =
               text;


            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Logging.Logging.ReportError(ex);
                }
                Console.ReadLine();
            }
new coffee();
        //}catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message);
        //}

    }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
              //  MessageBox.Show(Coffee.client.user);
                using (var db = new AutoweighEntities(coffee.ConnectionString()))
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
                    Coffee.User u = new Coffee.User();
                    u.Name = txtusername.Text;
                    u.Password = txtpassword.Text;

                    var user = coffee.login(u);

                    if (user.Code == 0)
                    {

                        WeighMain wm = new WeighMain();
                        wm.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show(user.Desc);

                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);

                MessageBox.Show(ex.Message);
              
                Logging.Logging.ReportError(ex);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
