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
                Member_No_ = User_No.Text.Trim();
                var user = MyClass.user(Member_No_);
                if (user == null)
                {
                    string Msg = "Invalid Crudentials";
                    lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);
                    return;
                }
                if (user.Blocked == true)
                {
                    string Msg = "Account Blocked. Kindly contact Bandari sacco for assistance";
                    lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);
                    return;
                }
                if (user.Changed_Password == false)
                {
                    PlainAuthenticate(user);
                }
                else
                {
                    HashAuthenticate(user);
                }
            }
            catch (Exception e)
            {
                string Msg = "Login Failed. Please Try Again";
                lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);
            }
        }

        protected void PlainAuthenticate(Online_User.Online_User user)
        {
            string membernumber, password;
            try
            {
                membernumber = User_No.Text.Trim().ToUpper();
                password = Password.Text.Trim();


                if (user.Password == MyClass.GetMd5Hash( password))
                {

                    Session["Member_No"] = user.Member_Id;
                    Session["user_id"] = user.Login_ID;
                    string Member_No = user.User_Name;
                    cSite.ExternalUserID = Session["Member_No"].ToString();
                    Session["User_Group_Name"] = user.User_Type;

                    Response.Redirect("ChangePassword.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();

                    //log user information
                    string username = Session["Member_No"].ToString();

                    LogUserInformation(username);

                }
                else
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
            catch (Exception e)
            {
                string Msg = "Login Failed. Please Try Again";
                lblError.Text = String.Format("<div class='alert alert-danger'>{0}</div>", Msg);
                
            }
        }
        protected void HashAuthenticate(Online_User.Online_User user)
        {
            string membernumber, password;
            try
            {
                membernumber = User_No.Text.Trim().ToUpper();
                password = Password.Text.Trim();


                if (user.Password ==MyClass.GetMd5Hash( password))
                {
                    Session["Member_No"] = user.Member_Id;
                    Session["user_id"] = user.Login_ID;
                    string Member_No = user.User_Name;
                    cSite.ExternalUserID = Session["Member_No"].ToString();
                    Session["User_Group_Name"] = user.User_Type.ToString();
                    Global.currentuser = user;
                    Response.Redirect("Dashboard.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    //log user information
                    string username = Session["Member_No"].ToString();

                    LogUserInformation(username);
                }
                else
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
                Online_Sessions.Online_Sessions online_ = new Online_Sessions.Online_Sessions();
                online_.SessionID = sessionID;
                online_.User_Name = membername;
                online_.LoginTime = loginTime;
                online_.LogoutTime = logoutTime;
                online_.User_Number = loginID;
                Global.sessions_Service.Create(ref online_);

              
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
                         var user =      Global.user_Service.Read(membernumber);
                if (user != null)
                {
                    user.Blocked = true;
                    user.BlockedSpecified = true;
                    Global.user_Service.Update(ref user);
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