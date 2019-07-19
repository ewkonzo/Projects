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
        settings s = new settings();
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

                //Trans.Accentriesservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Account_Entries", s.Serverip, s.Companyname, s.Instance, s.Port);
                //Trans.Accentriesservice.PreAuthenticate = true;
                //Trans.Accentriesservice.Credentials = cd;

                //Trans.account_Types_Service.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Account_Types", s.Serverip, s.Companyname, s.Instance, s.Port);
                //Trans.account_Types_Service.PreAuthenticate = true;
                //Trans.account_Types_Service.Credentials = cd;

                //Trans.Accservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Accounts", s.Serverip, s.Companyname, s.Instance, s.Port);
                //Trans.Accservice.PreAuthenticate = true;
                //Trans.Accservice.Credentials = cd;

                //Trans.s_mobile.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/S_Mobile", s.Serverip, s.Companyname, s.Instance, s.Port);
                //Trans.s_mobile.PreAuthenticate = true;
                //Trans.s_mobile.Credentials = cd;

                //Applications.appservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Applications", s.Serverip, s.Companyname, s.Instance, s.Port);
                //Applications.appservice.PreAuthenticate = true;
                //Applications.appservice.Credentials = cd;

                //Trans.setupservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Setup", s.Serverip, s.Companyname, s.Instance, s.Port);
                //Trans.setupservice.PreAuthenticate = true;
                //Trans.setupservice.Credentials = cd;

                //Members.Memberservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Member", s.Serverip, s.Companyname, s.Instance, s.Port);
                //Members.Memberservice.PreAuthenticate = true;
                //Members.Memberservice.Credentials = cd;

                //loan.loanservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Loans", s.Serverip, s.Companyname, s.Instance, s.Port);
                //loan.loanservice.PreAuthenticate = true;
                //loan.loanservice.Credentials = cd;

                //Smss.smsservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Sms", s.Serverip, s.Companyname, s.Instance, s.Port);
                //Smss.smsservice.PreAuthenticate = true;
                //Smss.smsservice.Credentials = cd;



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
