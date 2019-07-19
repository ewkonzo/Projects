using Bandari_Sacco.Online_Sessions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Serialization;

namespace Bandari_Sacco
{
    public partial class Global : System.Web.HttpApplication
    {
        public static Online_User.Online_User_Service user_Service = new Online_User.Online_User_Service();
        public static Online_Sessions_Service sessions_Service = new Online_Sessions_Service();
        public static Member.mobile_Member_Service member_Service = new Member.mobile_Member_Service();
        public static Mobile_Loan.Mobile_Loan_Service loan_Service = new Mobile_Loan.Mobile_Loan_Service();
        public static Account_Entries.Mobile_Account_Entries_Service entries_Service = new Account_Entries.Mobile_Account_Entries_Service();
        public static Mobile_Securities.Mobile_Securities_Service securities_Service = new Mobile_Securities.Mobile_Securities_Service();
        public static loanproducts.Loan_Products_Service products_Service = new loanproducts.Loan_Products_Service();
        public static loan_Calc.Online_Loan_Calc_Service loan_Calc_Service = new loan_Calc.Online_Loan_Calc_Service();
        public static Functions.MBranch mBranch = new Functions.MBranch();

        settings s = new settings();
        public static Online_User.Online_User currentuser; 
        NetworkCredential cd;
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            loadsettings();
            
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            
            Response.Redirect("Login.aspx");
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }
        private void loadsettings()
        {
            try
            {
                s = s.loadsettings(HttpContext.Current.Server.MapPath("~/Settings.xml"));
                cd = new NetworkCredential(s.Username, s.pass, s.domain);

                user_Service.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Online_User", s.Serverip, s.Companyname, s.Instance, s.Port);
                user_Service.PreAuthenticate = true;
                user_Service.Credentials = cd;

                sessions_Service.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Online_Sessions", s.Serverip, s.Companyname, s.Instance, s.Port);
                sessions_Service.PreAuthenticate = true;
                sessions_Service.Credentials = cd;

                member_Service.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/mobile_Member", s.Serverip, s.Companyname, s.Instance, s.Port);
                member_Service.PreAuthenticate = true;
                member_Service.Credentials = cd;

                loan_Service.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Mobile_Loan", s.Serverip, s.Companyname, s.Instance, s.Port);
                loan_Service.PreAuthenticate = true;
                loan_Service.Credentials = cd;

                entries_Service.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Mobile_Account_Entries", s.Serverip, s.Companyname, s.Instance, s.Port);
                entries_Service.PreAuthenticate = true;
                entries_Service.Credentials = cd;

                securities_Service.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Mobile_Securities", s.Serverip, s.Companyname, s.Instance, s.Port);
                securities_Service.PreAuthenticate = true;
                securities_Service.Credentials = cd;

                mBranch.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/MBranch", s.Serverip, s.Companyname, s.Instance, s.Port);
                mBranch.PreAuthenticate = true;
                mBranch.Credentials = cd;

                products_Service.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Loan_Products", s.Serverip, s.Companyname, s.Instance, s.Port);
                products_Service.PreAuthenticate = true;
                products_Service.Credentials = cd;

                loan_Calc_Service.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Online_Loan_Calc", s.Serverip, s.Companyname, s.Instance, s.Port);
                loan_Calc_Service.PreAuthenticate = true;
                loan_Calc_Service.Credentials = cd;

            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }

        }
    }

    public class settings
    {
        public string Serverip = string.Empty;
        public string domain = string.Empty;
        public string Instance = string.Empty;
        public int Port = 0;
        public string Username = string.Empty;
        public string pass = string.Empty;
        public string Companyname = string.Empty;
        public int PostIntervalinsec = 2;
        public int Reconnectintervalinsec = 10;
        public string logpath = string.Empty;
        public Boolean usewindowsauth = true;
        public string certpath = string.Empty;
        public DateTime t = DateTime.Now.Date;
        public DateTime tt = new DateTime(2017, 2, 5);
        public settings loadsettings(string file)
        {
            settings s = new settings();
            XmlSerializer xs = new XmlSerializer(typeof(settings));
            using (var sr = new StreamReader(file))
            {
                s = (settings)xs.Deserialize(sr);
                Logging.Logging.logpath = s.logpath;
            }
            return s;
        }
       
    }
}
