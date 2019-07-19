using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Net;

using System.Security.Cryptography.X509Certificates;

namespace RunCodunit
{
    using Comp;
    using System.Net.Security;
    public partial class Navs : ServiceBase
    {
        public static System.Net.NetworkCredential cd; 
        private settings ss = new settings();
        public static Runc.RunThem run = new Runc.RunThem();
        public Navs()
        {
            try
            {
                InitializeComponent();
                string path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\Settings.xml";
             ss=   ss.loadsettings(path);
                loadsettings();
            }
            catch (Exception ex)
            {
                 Logging.Logging.LogEntryOnFile(ex.Message);
                 Logging.Logging.LogEntryOnFile(ex.StackTrace);
            }
        }
        private void loadsettings()
        {
        
           

            NetworkCredential networkCredential = new NetworkCredential(ss.Username, ss.pass);
            CredentialCache credentialCaches = new CredentialCache();
            cd = new System.Net.NetworkCredential(ss.Username, ss.pass, ss.domain);
           
            run.Url =Uri.EscapeUriString( String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/RunThem", ss.Serverip, ss.Companyname,
                ss.Instance, ss.Port));
                run.PreAuthenticate = true;
                run.Credentials = (ICredentials)cd;

                RunThem.Sservice.Url = Uri.EscapeUriString(String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Sms", ss.Serverip, ss.Companyname,
                ss.Instance, ss.Port));
                RunThem.Sservice.PreAuthenticate = true;
                RunThem.Sservice.Credentials = (ICredentials)cd;

                RunThem.mbranch.Url = Uri.EscapeUriString(String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/MBranch", ss.Serverip, ss.Companyname,
                ss.Instance, ss.Port));
                RunThem.mbranch.PreAuthenticate = true;
                RunThem.mbranch.Credentials = (ICredentials)cd;
            //    run.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\certs\\NavServiceCert.cer"));
            //run.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\certs\\RootNavServiceCA.cer"));
            //credentialCaches.Add(new Uri(run.Url), "Basic", networkCredential);
            //IWebProxy iwp = new WebProxy("192.168.1.158:808");
            //          run.Proxy = iwp;
            //run.Credentials = credentialCaches;
            //run.PreAuthenticate = true;
        }
        private void loadsettingsssl() {
            ServicePointManager.ServerCertificateValidationCallback = (object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => (true);


            NetworkCredential networkCredential = new NetworkCredential(ss.Username, ss.pass);
            CredentialCache credentialCaches = new CredentialCache();

            RunThem.Sservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Sms", ss.Serverip, ss.Companyname, ss.Instance, ss.Port);
            RunThem.Sservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(ss.certpath));// "E:\\CERTS\\NavServiceCert.cer"));
            RunThem.Sservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(ss.certpath));//"E:\\CERTS\\RootNavServiceCA.cer"));
            credentialCaches.Add(new Uri(RunThem.Sservice.Url), "Basic", networkCredential);
            RunThem.Sservice.Credentials = credentialCaches;
            RunThem.Sservice.PreAuthenticate = true;
        }

        public   void test()
        {
            RunThem r = new RunThem();
            r.start();
           
        }
       
        protected override void OnStart(string[] args)
        {
            RunThem rn = new RunThem();
            rn.onstart();
        }

        protected override void OnStop()
        {
            RunThem.stop = true;
        }
    }
}
