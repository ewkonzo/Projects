using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rice
{
    public partial class Splash : DevExpress.XtraEditors.XtraForm
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void loaddb()
        {
            try
            {
                string path = "Settings.xml";
                Rice.settings s = new Rice.settings().loadsettings(path);
                rice.setting = s;
                //Scripting.Createscript();
                string text = System.IO.File.ReadAllText("script.txt");
                string connectionString = "Data Source=" + string.Concat(s.Server, @"\", s.Instance) + ";Initial Catalog=" + s.database + ";Integrated Security=" + s.IntegratedSecurity + "";
                // Provide the query string with a parameter placeholder. 
                string queryString =
                   text;
                using (SqlConnection connection = new SqlConnection(connectionString))
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
                }
                RiceEntities db = new RiceEntities(rice.ConnectionString());
                Logging.Logging.logpath = rice.setting.logpath;
                Rice.client.Db = rice.setting.database;
                Rice.client.Server = rice.setting.Server;
                Rice.client.IntegratedSecurity = rice.setting.IntegratedSecurity;
                Rice.client.instance = rice.setting.Instance;
                Rice.client.user = rice.setting.Username;
                Rice.client.password = rice.setting.pass;
                var d = db.Companies.FirstOrDefault();
                if (d != null)
                    rice.Factory_Name = d.Name.ToUpper();
                else
                    rice.Factory_Name = "RICE";
                new rice();
                var dd = new externaldata();
                Task.Factory.StartNew(() => dd.users());
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
        }
       Task task;
       private void Splash_Load(object sender, EventArgs e)
       {
           //var dd = new externaldata();
           //   Task.Factory.StartNew(() => dd.load());

           task = Task.Run(() => loaddb()).ContinueWith(t => starttimer(), TaskScheduler.FromCurrentSynchronizationContext());
         
           pictureEdit1item.Text = "Loading Database";
                   }
       private void starttimer()
       {
           Login l = new Login();
           l.Show();
           this.Hide();
       

       }
        private void layoutControlGroup1_Shown(object sender, EventArgs e)
        {
          
        } 
        externaldata data = new externaldata();
        private void usersupdated(object sender, AUsers.UpdateCompletedEventArgs e)
        { }
        private async void usersread(object sender, AUsers.ReadCompletedEventArgs e, User u)
        {
          
            if (e.Result != null)
            {
                e.Result.Password = u.Password;
                e.Result.Password_Changed = true;
                e.Result.Date_Password_Changed = (DateTime)u.Date_Password_Changed;
                e.Result.Password_ChangedSpecified = true;
                e.Result.Date_Password_ChangedSpecified = true;
                var r = e.Result;
                data.usersservice.Update(ref r);
                u.Updated = false;
            }
        }
        private async void users()
        {
            #region users
            try
            {
                data.usersservice.UpdateCompleted += new AUsers.UpdateCompletedEventHandler(usersupdated);
                using (var db = new RiceEntities(rice.ConnectionString()))
                {
                    var updatedusers = db.Users.Where(o => o.Updated == true);
                    if (updatedusers.Count() > 0)
                    {
                        foreach (var u in updatedusers)
                        {
                            data.usersservice.ReadCompleted += (sender, e) => usersread(sender, e, u);

                    

                        }
                    }
                    db.SaveChanges();

                    var c = data. usersservice.ReadMultiple(new AUsers.Users_Filter[] { }, null, 0).ToList();
                    foreach (var u in c)
                    {
                        var uu = db.Users.FirstOrDefault(o => o.Name == u.User_Name);
                        if (uu == null)
                        {
                            uu = new User();
                            uu.Name = u.User_Name;
                            uu.Password = u.Password;
                            //uu.Date_Created = u.Date_Added;
                            uu.Password_Changed = false;
                            uu.Phone = u.Phone_Number;
                            db.Users.Add(uu);
                        }
                        uu.Phone = u.Phone_Number;
                        if (u.User_Outlets.Count() > 0)
                        {
                            db.User_outlets.RemoveRange(db.User_outlets.Where(o => o.User_Name == uu.Name));

                            foreach (var item in u.User_Outlets)
                            {
                                var user = new User_outlet();
                                user.User_Name = item.User_Name;
                                user.Active_Outlet = item.Active_Outlet;
                                db.User_outlets.Add(user);
                            }
                        }
                        if (u.Reset)
                        {
                            uu.Password = u.Password;
                            uu.Password_Changed = false;
                        }
                        if (u.Password_Changed)
                        {
                            uu.Password = u.Password;
                            uu.Password_Changed = true;
                        }

                        u.Reset = false;
                        u.ResetSpecified = true;
                        AUsers.Users ua = u;
                       data. usersservice.Update(ref ua);

                    } db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);

            }
            #endregion
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
                   
                    Login l = new Login();
                    l.Show();
                    this.Hide();
                    timer1.Stop();
        }
    }
}
