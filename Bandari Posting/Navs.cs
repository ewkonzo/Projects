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
    public partial class Navs : ServiceBase
    {
        public static System.Net.NetworkCredential cd; private ServerSetting ss = new ServerSetting();
        public static Runc.RunThem run = new Runc.RunThem();

        public Navs()
        { try
                    {
            InitializeComponent();
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)+"\\Settings.txt";
            ss.getsettings(path);

            NetworkCredential networkCredential = new NetworkCredential(ss.user, ss.pass);
            CredentialCache credentialCaches = new CredentialCache();
            cd = new System.Net.NetworkCredential(ss.user, ss.pass, ss.domain);
           
            run.Url =Uri.EscapeUriString( String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/RunThem", ss.server, ss.Companyname,
                ss.Instance, ss.Port));
                run.PreAuthenticate = true;
                run.Credentials = (ICredentials)cd;

                RunThem.Sservice.Url =Uri.EscapeUriString( String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Sms", ss.server, ss.Companyname,
                ss.Instance, ss.Port));
                RunThem.Sservice.PreAuthenticate = true;
                RunThem.Sservice.Credentials = (ICredentials)cd;

                RunThem.mbranch.Url = Uri.EscapeUriString(String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/MBranch", ss.server, ss.Companyname,
                ss.Instance, ss.Port));
                RunThem.mbranch.PreAuthenticate = true;
                RunThem.mbranch.Credentials = (ICredentials)cd;

 RunThem.atm_Service.Url = Uri.EscapeUriString(String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Atm", ss.server, ss.Companyname,
                ss.Instance, ss.Port));
                RunThem.atm_Service.PreAuthenticate = true;
                RunThem.atm_Service.Credentials = (ICredentials)cd;
            //    run.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\certs\\NavServiceCert.cer"));
            //run.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\certs\\RootNavServiceCA.cer"));
            //credentialCaches.Add(new Uri(run.Url), "Basic", networkCredential);
            //IWebProxy iwp = new WebProxy("192.168.1.158:808");
            //          run.Proxy = iwp;
            //run.Credentials = credentialCaches;
            //run.PreAuthenticate = true;
                    }
        catch (Exception ex)
        {
            CUtilities.LogEntryOnFile(ex.Message);
            CUtilities.LogEntryOnFile(ex.StackTrace);
        }
        }
        public   void test()
        {
            RunThem r = new RunThem();
            r.start();
            // Create instance of service and set credentials.
             
          Systemservice.SystemService service = new Systemservice.SystemService();
          service.PreAuthenticate = true;
            // The service URL is set by the proxy with a 
            // value from the .config file.
            service.Credentials = (ICredentials)cd;

            // Load all companies into an array.
            string[] companies = service.Companies();

            // Run through and print all companies.
            // Also print company name in encoded form.
            foreach (string company in companies)
            {
                Console.WriteLine(company);
                Console.WriteLine((Uri.EscapeDataString(company)));
            }
            Console.ReadLine();
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
