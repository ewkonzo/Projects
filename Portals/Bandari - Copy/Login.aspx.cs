using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Bandari_Sacco;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bandari_Sacco.controller;
using OGL;

namespace Bandari_Sacco
{
    public partial class Login1 : System.Web.UI.Page
    {
        int loginattempt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            User_No.Focus();
           
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Authenticate();
        }



        protected void Authenticate()
        {
            string Member_No_ = "";

            try
            {
                Member_No_ = User_No.Text.Trim().ToUpper();

                if (MyClass.CheckIfAccountBlocked(Member_No_) == "0")
                {
                    using (SqlConnection conn = MyClass.getconnToNAV())
                    {
                        string checkchange = String.Format("SELECT [Login ID],[User Name], [Changed Password] FROM [{0}$Online User] WHERE [Login ID]=@UserName", MyClass.CompanyName);
                        SqlCommand command = new SqlCommand(checkchange, conn);
                        command.Parameters.AddWithValue("@UserName", Member_No_);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows == true)
                            {
                                dr.Read();
                                int changed = Convert.ToInt32(dr["Changed Password"]);
                                if (changed == 0)
                                {
                                    conn.Close();
                                    PlainAuthenticate();
                                }
                                else if (changed == 1)
                                {
                                    conn.Close();
                                    HashAuthenticate();
                                }
                            }
                            else if (dr.HasRows == false)
                            {
                                string Msg = "Invalid Crudentials";
                                lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);

                            }
                        }
                    }
                }
                else if (MyClass.CheckIfAccountBlocked(Member_No_) == "1")
                {
                    string Msg = "Account Blocked. Kindly contact Bandari sacco for assistance";

                    lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);
                }
                else if (MyClass.CheckIfAccountBlocked(Member_No_) == "2")
                {
                    string Msg = "Either Bandari Sacco does not recognize the member number," +
                                 " or you have not registered for an online account." +
                                 " Please contact Bandari Sacco for more assistance.";
                    lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);
                }
               
            }

            catch (Exception e)
            {
                string Msg = "Login Failed. Please Try Again";
                lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);
                
            }
        }


        protected void PlainAuthenticate()
        {
            string membernumber, password;
            try
            {
                membernumber = User_No.Text.Trim().ToUpper();
                password = Password.Text.Trim();

                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string s = String.Format("SELECT [Login ID], [User Name], [User Type],[Password] FROM [{0}$Online User] WHERE [Login ID] = @UserName AND [Password] = @Password", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@UserName", membernumber);
                    command.Parameters.AddWithValue("@Password", password);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows == true)
                        {
                            dr.Read();
                            Session["Member_No"] = dr["User Name"].ToString();
                            string Member_No = dr["User Name"].ToString();
                            cSite.ExternalUserID = Session["Member_No"].ToString();
                            Session["User_Group_Name"] = dr["User Type"].ToString();
                            
                                Response.Redirect("ChangePassword.aspx", false);
                                Context.ApplicationInstance.CompleteRequest();

                                //log user information
                                string username = Session["Member_No"].ToString();
                                conn.Close();
                                LogUserInformation(username);
                          
                        }
                        else if (dr.HasRows == false)
                        {

                            cSite.LoginAttempt++;
                            if (cSite.LoginAttempt >= cSite.maxLogins)
                            {
                                BlockAccount();
                            }
                            int attempts = cSite.LoginAttempt;
                            int remainder = (3 - attempts);
                            string Msg = "Incorrect User ID or password combination." +
                                             "You have " + remainder + " more attempt(s)";
                            lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);

                        }
                    }
                }


            }
            catch (Exception e)
            {
                string Msg = "Login Failed. Please Try Again";
                lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);
                
            }
        }
        protected void HashAuthenticate()
        {
            string membernumber, password;
            try
            {
                membernumber = User_No.Text.Trim().ToUpper();
                password = Password.Text.Trim();

                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string s = String.Format("SELECT [Login ID], [User Name], [User Type],[Password] FROM [{0}$Online User] WHERE [Login ID] = @UserName AND [Password] = @Password", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@UserName", membernumber);
                    command.Parameters.AddWithValue("@Password", MyClass.GetMd5Hash(password));

                    using (SqlDataReader dr = command.ExecuteReader())
                    {

                        if (dr.HasRows == true)
                        {
                            dr.Read();
                            Session["Member_No"] = dr["User Name"].ToString();
                            string Member_No = dr["User Name"].ToString();
                            cSite.ExternalUserID = Session["Member_No"].ToString();
                            Session["User_Group_Name"] = dr["User Type"].ToString();
                           
                                Response.Redirect("Dashboard.aspx", false);
                                Context.ApplicationInstance.CompleteRequest();

                                //log user information
                                string username = Session["Member_No"].ToString();
                                conn.Close();
                                LogUserInformation(username);
                                                   }
                        else if (dr.HasRows == false)
                        {

                            cSite.LoginAttempt++;
                            if (cSite.LoginAttempt >= cSite.maxLogins)
                            {
                                BlockAccount();
                            }
                            int attempts = cSite.LoginAttempt;
                            int remainder = (4 - attempts);
                            string Msg = "Incorrect User ID or password combination." +
                                         " You have " + remainder + " more attempt(s)";

                            lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);

                        }
                    }
                }

            }

            catch
            {
                string Msg = "Login Failed. Please Try Again";
                lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);
                
            }
        }

        protected void LogUserInformation(string loginID)
        {
            string membername = MyClass.getMemberFullNames(loginID);

            string s = loginID.ToUpper() + ": ";
            s += cSite.FormatDate(DateTime.Now);

            cSite.ExternalUserSessionID = cSite.ValidateEntry(new oglRijndael().sEncrypt(s));
            string sessionID = cSite.ExternalUserSessionID;
            Session["SessionID"] = cSite.ExternalUserSessionID;
            DateTime loginTime = DateTime.Now;
            DateTime logoutTime = DateTime.Now; 

            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = "INSERT INTO [" + MyClass.CompanyName + "$Online Sessions] " +
                               " ([SessionID],[User Name],[LoginTime],[LogoutTime],[User Number]) " +
                               " VALUES(@SessionId ,@UserName,@LoginTime ,@LogoutTime,@UserNumber)";

                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@SessionId", sessionID);
                    command.Parameters.AddWithValue("@UserName", membername);
                    command.Parameters.AddWithValue("@LoginTime", loginTime);
                    command.Parameters.AddWithValue("@LogoutTime", logoutTime);
                    command.Parameters.AddWithValue("@UserNumber", loginID);
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                string Msg = "Login Failed. Please Try Again";
                lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);
                
            }

        }

    
        protected void BlockAccount()
        {
          
                try
                {

                    string membernumber = User_No.Text.Trim().ToUpper();
                    using (SqlConnection conn = MyClass.getconnToNAV())
                    {
                        string A = "UPDATE [" + MyClass.CompanyName + "$Online User]" +
                                   " SET [Blocked] = 1 " +
                                   " WHERE [Login ID] = @UserName";

                        SqlCommand command = new SqlCommand(A, conn);
                        command.Parameters.AddWithValue("@UserName", membernumber);
                        command.ExecuteNonQuery();
                        lblError.Text = "Login Attempts expired. Your account has been locked. Kindly contact Bandari sacco for more assistance";
                    }
                }
                catch
                {
                    string Msg = "Login Failed. Please Try Again";
                    lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);
                
                }
            }
        
    }
}