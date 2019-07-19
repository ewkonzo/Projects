using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PData;
using System.ServiceModel.Activation;
using System.Web;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using PData.Sms;

namespace Client
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Client : Mobile
    {
        settings s = new settings();
        NetworkCredential cd;

        public Client()
        {
            s = s.loadsettings(HttpContext.Current.Server.MapPath("~/Settings.xml"));
            if (s.usewindowsauth)
                loadsettings();
            else
                loadsettingswithcertificate();
        }
        private void loadsettings()
        {
            try
            {
                s = s.loadsettings(HttpContext.Current.Server.MapPath("~/Settings.xml"));
                cd = new NetworkCredential(s.Username, s.pass, s.domain);

                Trans.trservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Transactions", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.trservice.PreAuthenticate = true;
                Trans.trservice.Credentials = cd;

                Trans.Accentriesservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Account_Entries", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.Accentriesservice.PreAuthenticate = true;
                Trans.Accentriesservice.Credentials = cd;

                Trans.Accservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Accounts", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.Accservice.PreAuthenticate = true;
                Trans.Accservice.Credentials = cd;

                Trans.s_mobile.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/S_Mobile", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.s_mobile.PreAuthenticate = true;
                Trans.s_mobile.Credentials = cd;

                Applications.appservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Applications", s.Serverip, s.Companyname, s.Instance, s.Port);
                Applications.appservice.PreAuthenticate = true;
                Applications.appservice.Credentials = cd;

                Trans.setupservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Setup", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.setupservice.PreAuthenticate = true;
                Trans.setupservice.Credentials = cd;

                Members.Memberservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Member", s.Serverip, s.Companyname, s.Instance, s.Port);
                Members.Memberservice.PreAuthenticate = true;
                Members.Memberservice.Credentials = cd;

                loan.loanservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Loans", s.Serverip, s.Companyname, s.Instance, s.Port);
                loan.loanservice.PreAuthenticate = true;
                loan.loanservice.Credentials = cd;

                Sms.smsservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Sms", s.Serverip, s.Companyname, s.Instance, s.Port);
                Sms.smsservice.PreAuthenticate = true;
                Sms.smsservice.Credentials = cd;

                Trans.setup = Trans.setupservice.Read(1);

            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }

        }
        private void loadsettingswithcertificate()
        {
            try
            {

                NetworkCredential networkCredential = new NetworkCredential(s.Username, s.pass);
                CredentialCache credentialCaches = new CredentialCache();

                Trans.trservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Transactions", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.trservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\NavServiceCert.cer"));
                Trans.trservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Trans.trservice.Url), "Basic", networkCredential);
                Trans.trservice.Credentials = credentialCaches;
                Trans.trservice.PreAuthenticate = true;

                Trans.Accentriesservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Account_Entries", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.Accentriesservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\NavServiceCert.cer"));
                Trans.Accentriesservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Trans.Accentriesservice.Url), "Basic", networkCredential);
                Trans.Accentriesservice.Credentials = credentialCaches;
                Trans.Accentriesservice.PreAuthenticate = true;

                Trans.Accservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Accounts", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.Accservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\NavServiceCert.cer"));
                Trans.Accservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Trans.Accservice.Url), "Basic", networkCredential);
                Trans.Accservice.Credentials = credentialCaches;
                Trans.Accservice.PreAuthenticate = true;

                Trans.s_mobile.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/S_Mobile", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.s_mobile.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\NavServiceCert.cer"));
                Trans.s_mobile.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Trans.s_mobile.Url), "Basic", networkCredential);
                Trans.s_mobile.Credentials = credentialCaches;
                Trans.s_mobile.PreAuthenticate = true;

                Applications.appservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Applications", s.Serverip, s.Companyname, s.Instance, s.Port);
                Applications.appservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\NavServiceCert.cer"));
                Applications.appservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Applications.appservice.Url), "Basic", networkCredential);
                Applications.appservice.Credentials = credentialCaches;
                Applications.appservice.PreAuthenticate = true;

                Trans.setupservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Setup", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.setupservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\NavServiceCert.cer"));
                Trans.setupservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Trans.setupservice.Url), "Basic", networkCredential);
                Trans.setupservice.Credentials = credentialCaches;
                Trans.setupservice.PreAuthenticate = true;

                Members.Memberservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Member", s.Serverip, s.Companyname, s.Instance, s.Port);
                Members.Memberservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\NavServiceCert.cer"));
                Members.Memberservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Members.Memberservice.Url), "Basic", networkCredential);
                Members.Memberservice.Credentials = credentialCaches;
                Members.Memberservice.PreAuthenticate = true;

                loan.loanservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Loans", s.Serverip, s.Companyname, s.Instance, s.Port);
                loan.loanservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\NavServiceCert.cer"));
                loan.loanservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("C:\\cert\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(loan.loanservice.Url), "Basic", networkCredential);
                loan.loanservice.Credentials = credentialCaches;
                loan.loanservice.PreAuthenticate = true;

                Trans.setup = Trans.setupservice.Read(1);

            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }

        }
        public Trans Transaction(Trans t)
        {
            return Trans.Create(t);
        }
        public List<PData.Sms.Sms> sms(int count)
        {
            return Sms.Getsms(count);
        }
        public List<PData.Sms.Sms> SmsUpdate( List<PData.Sms.Sms> s)
        {
            Sms.Upddatesms(ref s);
            return s;
        }

        public decimal Bal(string acc)
        {
            return (decimal)Trans.Balance(acc);
        }
        public List<PData.S_Applications.Applications> Registration()
        {
            return Applications.Registrations();
        }
        public List<PData.Loans.Loans> CustomerLoans(string telephone)
        {
            return loan.Customerloans(telephone);
        }
        public List<PData.Accounts.Accounts> Accounts(string tel)
        {
            return Trans.Getaccounts(tel);
        }
        public PData.Accounts.Accounts Account(string acc)
        {
            return Trans.Getaccount(acc);
        }

     
    }
}
