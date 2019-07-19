using Client;
using Client.Loans;
using Client.Sms;
using Client.Transactions;
using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Activation;

using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Client
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Client : Mobile
    {        settings s = new settings();
        NetworkCredential cd;
        public Client()
        {
            s = s.loadsettings(HttpContext.Current.Server.MapPath("~/Settings.xml"));
            // if (s.t > s.tt)
            //  s.setup(ref s);
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

                Trans.account_Types_Service.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Account_Types", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.account_Types_Service.PreAuthenticate = true;
                Trans.account_Types_Service.Credentials = cd;

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

                //Smss.smsservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Sms", s.Serverip, s.Companyname, s.Instance, s.Port);
                //Smss.smsservice.PreAuthenticate = true;
                //Smss.smsservice.Credentials = cd;

                Trans.setup = Trans.setupservice.
                    Read(1);
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
                Trans.trservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\NavServiceCert.cer"));
                Trans.trservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Trans.trservice.Url), "Basic", networkCredential);
                Trans.trservice.Credentials = credentialCaches;
                Trans.trservice.PreAuthenticate = true;

                Trans.Accentriesservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Account_Entries", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.Accentriesservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\NavServiceCert.cer"));
                Trans.Accentriesservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Trans.Accentriesservice.Url), "Basic", networkCredential);
                Trans.Accentriesservice.Credentials = credentialCaches;
                Trans.Accentriesservice.PreAuthenticate = true;

                Trans.Accservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Accounts", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.Accservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\NavServiceCert.cer"));
                Trans.Accservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Trans.Accservice.Url), "Basic", networkCredential);
                Trans.Accservice.Credentials = credentialCaches;
                Trans.Accservice.PreAuthenticate = true;

                Trans.account_Types_Service.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Account_Types", s.Serverip, s.Companyname, s.Instance, s.Port);

                Trans.account_Types_Service.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\NavServiceCert.cer"));
                Trans.account_Types_Service.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Trans.Accservice.Url), "Basic", networkCredential);
                Trans.account_Types_Service.Credentials = credentialCaches;
                Trans.account_Types_Service.PreAuthenticate = true;

                Trans.s_mobile.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/S_Mobile", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.s_mobile.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\NavServiceCert.cer"));
                Trans.s_mobile.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Trans.s_mobile.Url), "Basic", networkCredential);
                Trans.s_mobile.Credentials = credentialCaches;
                Trans.s_mobile.PreAuthenticate = true;

                Applications.appservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Applications", s.Serverip, s.Companyname, s.Instance, s.Port);
                Applications.appservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\NavServiceCert.cer"));
                Applications.appservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Applications.appservice.Url), "Basic", networkCredential);
                Applications.appservice.Credentials = credentialCaches;
                Applications.appservice.PreAuthenticate = true;
                Trans.setupservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Setup", s.Serverip, s.Companyname, s.Instance, s.Port);
                Trans.setupservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\NavServiceCert.cer"));
                Trans.setupservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Trans.setupservice.Url), "Basic", networkCredential);
                Trans.setupservice.Credentials = credentialCaches;
                Trans.setupservice.PreAuthenticate = true;

                Members.Memberservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Member", s.Serverip, s.Companyname, s.Instance, s.Port);
                Members.Memberservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\NavServiceCert.cer"));
                Members.Memberservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(Members.Memberservice.Url), "Basic", networkCredential);
                Members.Memberservice.Credentials = credentialCaches;
                Members.Memberservice.PreAuthenticate = true;

                loan.loanservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Loans", s.Serverip, s.Companyname, s.Instance, s.Port);
                loan.loanservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\NavServiceCert.cer"));
                loan.loanservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile(s.certpath + "\\RootNavServiceCA.cer"));
                credentialCaches.Add(new Uri(loan.loanservice.Url), "Basic", networkCredential);
                loan.loanservice.Credentials = credentialCaches;
                loan.loanservice.PreAuthenticate = true;
                Trans.setup = Trans.setupservice.ReadByRecId("1");
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }

        }

       public Results Tstatus(string documentNo)
        {
            Results r = new Results();
            try
            {
                var T = Trans.trservice.ReadMultiple(new Transactions_Filter[] { new Transactions_Filter { Criteria = documentNo, Field = Transactions_Fields.Document_No } }, null,0 );
                if (T.Count() > 0)
                {
                    if (T[0].Status == Status.Completed)
                    {
                        r.code = 0;
                        r.error_Desc = "Successfull";
                    }
                    else
                    {
                        r.code = -1;
                        r.error_Desc = T[0].Comments;
                    }
                }
                else {  r.code = -1;
                        r.error_Desc = "Transaction not found";
                }
            }
            catch(Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            return r;
        }

        public Trans Transaction(Trans t)
        {
            return Trans.Create(t);
        }
        public List<Sms.Sms> sendsms(List<Sms.Sms> smses)
        {            
            return Sms.Sms.sendsms(smses);
        }
        //public List<Sms.Sms> SmsUpdate(List<Sms.Sms> s)
        //{
        //    Smss.Upddatesms(ref s);
        //    return s;
        //}
        public double Bal(string acc)
        {
            return  Trans.Balance(acc);
        }
        public eligibility Eligibility(string phone,Transactions.Loan_Type loantype)
        {
            eligibility el = new eligibility();

            try
            {
               el.eligible_amount=(double)Trans.s_mobile.LoanEligibility(phone, (int)loantype);
              
            }
            catch(Exception ex)
            {
                el.code = -1;
                el.error_Desc = ex.Message;
                Logging.Logging.ReportError(ex);

            }
        Trans. CreateXML(el);
            return el;

        }
        public List<S_Applications.Applications> Registration()
        {
            return Applications.Registrations();
        }
        public List<Loans.Loans> CustomerLoans(string telephone)
        {
            return loan.Customerloans(telephone);
        }
        public List<Accounts.Accounts> Accounts(string tel)
        {
            return Trans.Getaccounts(tel);
        }
        public List<Accounts.Accounts> Accountsbyid(string id)
        {
            return Trans.Getaccountsbyid(id);
        }
        public List<Accounts.Accounts> ChildAccounts(string no)
        {
            return Trans.Getchilda(no);
        }

        public List<Accounts.Accounts> Memberaccounts(string tel)
        {
            return Trans.Getmemberaccounts(tel);
        }
        public Accounts.Accounts Account(string acc)
        {
            return Trans.Getaccount(acc);
        }
        public Member.Member member(string acc)
        {
            return Members.getmember(acc);
        }

    }
    public enum loantypes {
        Mloan, Dividend
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
        public void setup(ref settings s)
        {
            var p = s.Username;
            s.pass = p;
        }
    }
    public class loan
    {

        public static Loans_Service loanservice = new Loans_Service();
        public string loantype;
        public decimal balance;
        public Loan_Status status;

        public static List<Loans.Loans> Customerloans(string acc)
        {
            List<Loans.Loans> Customerloan = new List<Loans.Loans>();
            try
            {
                var a = Trans.Getaccounts(acc);
                if (a.Count()!=0)
                Customerloan = loanservice.ReadMultiple(new Loans_Filter[] { new Loans_Filter { Criteria = a[0].No, Field = Loans_Fields.Client_Code } }, null, 0).Where(o=> o.Outstanding_Balance>0 || o.Oustanding_Interest >0).ToList();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return Customerloan;
        }

        internal static void LoanBalance(ref Trans t)
        {
            List<loan> ll = new List<loan>();
            Trans tt = t;
            var cl = Customerloans(t.Account_No).Where(o => o.Loan_Status == Loan_Status.Approved);
            foreach (var l in cl)
            {
                loan la = new loan();
                la.loantype = l.Loan_Name;
                la.balance = l.Outstanding_Balance + l.Outstanding_Balance;
                ll.Add(la);
            }
            Accounts.Accounts a = Trans.Getaccount(t.Account_No);

            Members.member = Members.getmember(a.BOSA_Account_No);
            cl = Customerloans(Members.member.No).Where(o => o.Loan_Status == Loan_Status.Approved);
            foreach (var l in cl)
            {
                if (ll.FirstOrDefault(o => o.loantype == l.Loan_Name) == null)
                {
                    loan la = new loan();
                    la.loantype = l.Loan_Name;
                    la.balance = l.Outstanding_Balance + l.Outstanding_Balance;
                    ll.Add(la);
                }
            }

            t.LoanBalances = ll;
        }
        internal static void Loanstatus(ref Trans t)
        {
            List<loan> ll = new List<loan>();
            Trans tt = t;
            var cl = Customerloans(t.Account_No).Where(o => o.Loan_Status == Loan_Status.Approved);
            foreach (var l in cl)
            {
                loan la = new loan()
                {
                    loantype = l.Loan_Name,
                    status = l.Loan_Status
                };
                ll.Add(la);
            }
            Accounts.Accounts a = Trans.Getaccount(t.Account_No);
            Members.member = Members.getmember(a.BOSA_Account_No);
            cl = Customerloans(Members.member.No).Where(o => o.Loan_Status == Loan_Status.Approved);
            foreach (var l in cl)
            {
                loan la = new loan();
                la.loantype = l.Loan_Name;
                la.balance = l.Outstanding_Balance + l.Oustanding_Interest;
                ll.Add(la);
            }
            t.LoanStatus = ll;
        }
    }
    public class Applications
    {
        public static S_Applications.Applications_Service appservice = new S_Applications.Applications_Service();
        public static List<S_Applications.Applications> Registrations()
        {
            List<S_Applications.Applications> r = new List<S_Applications.Applications>();
            try
            {
                var rr = appservice.ReadMultiple(new S_Applications.Applications_Filter[] { new S_Applications.Applications_Filter { Criteria = "No", Field = S_Applications.Applications_Fields.Sent }, new S_Applications.Applications_Filter { Criteria = "Approved", Field = S_Applications.Applications_Fields.Status } }, null, 100);
                foreach (var i in rr)
                {
                    i.Sent = true;
                    i.SentSpecified = true;
                }
                appservice.UpdateMultiple(ref rr);
                r = rr.ToList();
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            Trans.CreateXML(r);
            return r;
        }
    }
    public class eligibility :Results
    {
        public double eligible_amount;
    }
  
    public class Ministatement
    {
        public double amount;
        public string desc;
        public DateTime posting_Date;


    }
    public class Members
    {
        public static Member.Member_Service Memberservice = new Member.Member_Service();
        public static Member.Member member;
        public static Member.Member getmember(string acc)
        {
            Member.Member m = null;
            try
            {

                m = Members.Memberservice.Read(acc);

            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            return m;
        }
        public List<deposits> depositbalance (string member)
        {
            List<deposits> d = new List<deposits>();
            try
            {
               var m = Members.Memberservice.Read(member);
                d.Add(new deposits("Share  Capital", (double)m.Shares_Retained));
                d.Add(new deposits("Deposits", (double)m.Current_Shares));

            }
            catch (Exception e) { }
            return d;
        }
        public class deposits
        {
            public string type;
                public double balance;
            public deposits() { }
            public deposits(string type, double bal)
            {
                this.type = type;
                this.balance = bal;
            }

        }
    }
    
  }
namespace Client.Accounts
{
    public partial class Accounts
    {
        public AccountTypes.Account_Types Type
        {
            get
            {
                var types = Trans.account_Types_Service.Read(Account_Type);

                return types;
            }
        }
    }
}
namespace Client.Member
{
    public partial class Member
    {
        public Accounts.Accounts[] accounts
        {
            get
            {
                List<Accounts.Accounts> a = new List<Accounts.Accounts>();
                a = Trans.Accservice.ReadMultiple(new Accounts.Accounts_Filter[] { new Accounts.Accounts_Filter { Criteria = No, Field = Accounts.Accounts_Fields.BOSA_Account_No } }, null, 0).ToList();

                return a.ToArray();

            }
        }
    }
}
namespace Client.Sms
{
  
    public partial class Sms:Results
    {
        public static List<Sms> sendsms(List<Sms> s)
        {
            Sms[] ss = s.ToArray();
            try
            {
                foreach (var sms in s)
                {
                    try
                    {
                        Trans.s_mobile.SendSms(sms.Source, sms.Telephone_No, sms.SMS_Message, sms.Source);
                        sms.code = 0;
                    }
                    catch (Exception ex)
                    {
                        sms.code = -1;
                        sms.error_Desc = "Unspecified Error";
                        Logging.Logging.ReportError(ex); }
                }
}
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            return ss.ToList();
        }
    }
}
namespace Client.Loans
{
    public partial class Loans
    {
        public double Loan_Balance
        {
            get
            {
                return (double)Outstanding_Balance + (double)Oustanding_Interest;
            }
        }
    }
}