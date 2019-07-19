using Global.HIMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
//using System.Threading.Tasks;
using System.Xml;
using System.Linq;

namespace HIMS
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Username.Focus();
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new PortalEntities(settings.Connection()))
                {
                    string Username_ = string.Empty;
                    string Password_ = string.Empty;

                    Username_ = Username.Text;
                    Password_ = Password.Text;
                    var user = db.Users.FirstOrDefault(o => o.UserName == Username_ && o.Password == Password_);
                    if (user != null)
                    {
                        Session["Username"] = user.UserName;
                        Session["CorporateNo"] = user.Client;
                        Session["Names"] = user.Name;
                        Session["User_Group_Name"] = user.User_Type.ToString();
                        Response.Redirect("Home.aspx?action=Home&Show=False");
                    }

                    else
                    {

                        string Msg = "Invalid User. Please try again";
                        lblError.Text = Msg;
                        Message(Msg);

                    }
                }
               
           
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
        }

        public void Message(string strMsg)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(strMsg);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

       
    }
}