using Client;
using Client.Loans;
using Client.Sms;
using Client.Transactions;
using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
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

                Smss.smsservice.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Sms", s.Serverip, s.Companyname, s.Instance, s.Port);
                Smss.smsservice.PreAuthenticate = true;
                Smss.smsservice.Credentials = cd;

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
        public Trans Transaction(Trans t)
        {
            return Trans.Create(t);
        }
        public List<Sms.Sms> sms(int count)
        {
            return Smss.Getsms(count);
        }
        public List<Sms.Sms> SmsUpdate(List<Sms.Sms> s)
        {
            Smss.Upddatesms(ref s);
            return s;
        }
        public double Bal(string acc)
        {
            return  Trans.Balance(acc);
        }
        public double Eligibility(string acc)
        {
            return (double) Trans.s_mobile.AdvanceEligibility(acc);
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
                Customerloan = loanservice.ReadMultiple(new Loans_Filter[] { new Loans_Filter { Criteria = acc, Field = Loans_Fields.Member_No } }, null, 10).ToList();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return Customerloan;
        }

        internal static void LoanBalance(ref Trans t)
        {
            List<loan> ll = new List<loan>();
            Trans tt = t;
            var cl = Customerloans(t.Account_No).Where(o => o.Loan_Status == Loan_Status.Posted);
            foreach (var l in cl)
            {
                loan la = new loan();
                la.loantype = l.Loan_Name;
                la.balance = l.Loan_Balance + l.Accrued_Interest;
                ll.Add(la);
            }
            Accounts.Accounts a = Trans.Getaccount(t.Account_No);

            Members.member = Members.getmember(a.Member_No);
            cl = Customerloans(Members.member.No).Where(o => o.Loan_Status == Loan_Status.Posted);
            foreach (var l in cl)
            {
                if (ll.FirstOrDefault(o => o.loantype == l.Loan_Name) == null)
                {
                    loan la = new loan();
                    la.loantype = l.Loan_Name;
                    la.balance = l.Loan_Balance + l.Accrued_Interest;
                    ll.Add(la);
                }
            }

            t.LoanBalances = ll;
        }
        internal static void Loanstatus(ref Trans t)
        {
            List<loan> ll = new List<loan>();
            Trans tt = t;
            var cl = Customerloans(t.Account_No).Where(o => o.Loan_Status == Loan_Status.Posted);
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
            Members.member = Members.getmember(a.Member_No);
            cl = Customerloans(Members.member.No).Where(o => o.Loan_Status == Loan_Status.Posted);
            foreach (var l in cl)
            {
                loan la = new loan();
                la.loantype = l.Loan_Name;
                la.balance = l.Loan_Balance + l.Accrued_Interest;
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
    public class Results
    {
        public int code = 0;
        public string error_Desc;
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
    }
    public class Trans : Results
    {
        public static Transactions_Service trservice = new Transactions_Service();
        public static Statement.Account_Entries_Service Accentriesservice = new Statement.Account_Entries_Service();
        public static Accounts.Accounts_Service Accservice = new Accounts.Accounts_Service();
        public static S_Mobile.S_Mobile s_mobile = new S_Mobile.S_Mobile();
        public static AccountTypes.Account_Types_Service account_Types_Service = new AccountTypes.Account_Types_Service();
        public int Entry;
        public string Account_No = string.Empty;
        public string Account_Name;
        public string Document_No = string.Empty;
        public System.DateTime Document_Date = DateTime.Now.Date;
        public System.DateTime Transaction_Time = DateTime.Now;
        public int Transaction_Type = -1;
        public string Telephone_Number = string.Empty;
        public string Account_2;
        public string Loan_No;
        public Transactions.Status Status = Transactions.Status.Pending;
        public string Comments;
        public decimal Amount = 0;
        public decimal Charge = 0;
        public string Description = string.Empty;
        public string Client;
        public List<Ministatement> Mini = null;
        public decimal AccountBalance = 0;
        public List<loan> LoanBalances = null;
        public List<loan> LoanStatus = null;
        public decimal sharedepositbalance = 0;
        public int statement_size = 5;
        public static Setup.Setup_Service setupservice = new Setup.Setup_Service();
        public static Setup.Setup setup;


        public Trans()
        { }
        public enum Trans_Type
        {
            _blank_ = 0,
            Withdrawal = 1,
            Deposit = 2,
            Balance = 3,
            Ministatement = 4,
            Airtime = 5,
            Loan_balance = 6,
            Loan_Status = 7,
            Share_Deposit_Balance = 8,
            Transfer_to_Fosa = 9,
            Transfer_to_Bosa = 10,
            Utility_Payment = 11,
            Loan_Application = 12,
            Standing_orders = 13,
            Reversal = 14,
            Loan_Repayment = 15,
            Share_Contribution = 16,
        }
        public static void CreateXML(Object YourClassObject)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                //Represents an XML document, 
                // Initializes a new instance of the XmlDocument class.          
                XmlSerializer xmlSerializer = new XmlSerializer(YourClassObject.GetType());
                // Creates a stream whose backing store is memory. 
                using (MemoryStream xmlStream = new MemoryStream())
                {
                    xmlSerializer.Serialize(xmlStream, YourClassObject);
                    xmlStream.Position = 0;
                    //Loads the XML document from the specified string.
                    xmlDoc.Load(xmlStream);
                }
                Logging.Logging.LogEntryOnFile(xmlDoc.InnerXml);
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }

        }
        public static Trans Create(Trans t)
        {
            CreateXML(t);
            Transactions.Transactions[] trs = null;
            Transactions.Transactions tr = new Transactions.Transactions();
            try
            {
                trs = trservice.ReadMultiple(new Transactions_Filter[] { new Transactions_Filter { Criteria = t.Document_No, Field = Transactions_Fields.Document_No }, new Transactions_Filter { Criteria = "Completed|Pending", Field = Transactions_Fields.Status }, new Transactions_Filter { Criteria = t.Transaction_Type.ToString(), Field = Transactions_Fields.Transaction_Type } }, null, 1);
                if (trs.Count() == 0)
                {
                    tr.Account_No = t.Account_No;
                    tr.Account_Name = t.Account_Name;
                    tr.Document_No = t.Document_No;
                    tr.Document_Date = t.Document_Date;
                    tr.Document_DateSpecified = true;
                    tr.Date_PostedSpecified = true;
                    tr.Transaction_Time = t.Transaction_Time;
                    tr.Transaction_TimeSpecified = true;
                    tr.Transaction_Type = (Transaction_Type)t.Transaction_Type;
                    tr.Transaction_TypeSpecified = true;
                    tr.Telephone_Number = t.Telephone_Number;
                    tr.Account_2 = t.Account_2;
                    tr.Loan_No = t.Loan_No;
                    tr.Amount = t.Amount;
                    tr.AmountSpecified = true;
                    tr.Charge = t.Charge;
                    tr.ChargeSpecified = true;
                    tr.Description = (t.Description == string.Empty ? tr.Transaction_Type.ToString() : tr.Description);
                    tr.Client = t.Client;
                    tr.Status = t.Status;
                    tr.StatusSpecified = true;
                    tr.Comments = t.Comments;
                    t.code = 0;

                    checkparameters(ref t);
                    if (t.code != 0)
                        return t;

                    validateaccount(ref t);
                    if (t.code != 0)
                        return t;

                    switch ((Trans_Type)t.Transaction_Type)
                    {
                        case Trans_Type.Ministatement:
                            Ministatement(ref t);
                            break;
                        case Trans_Type.Loan_balance:
                            loan.LoanBalance(ref t);
                            if (t.LoanBalances.Count() == 0)
                                t.code = 13;
                            break;
                        case Trans_Type.Balance:
                            t.AccountBalance = s_mobile.Balance(t.Account_No);
                            break;
                        case Trans_Type.Share_Deposit_Balance:
                           // t.sharedepositbalance = Members.member.;
                            break;
                        case Trans_Type.Loan_Status:
                            loan.Loanstatus(ref t);
                            if (t.LoanStatus.Count() == 0)
                                t.code = 13;
                            break;

                        case Trans_Type.Loan_Application:
                            try
                            {
                                var amount = s_mobile.AdvanceEligibility(t.Account_No);
                                if (amount < t.Amount)
                                    t.code = 19;
                            }
                            catch (Exception ex)
                            {
                                t.code = Convert.ToInt32(ex.Message);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                t.code = -1;
                t.error_Desc = "Unspecified error";
                Logging.Logging.ReportError(ex);
            }
            finally
            {
                try
                {
                    t.error_Desc = GeterrorDesc(t.code);
                    if (t.code != 0)
                    {
                        tr.Status = Transactions.Status.Failed;
                        tr.Comments = t.error_Desc;
                        t.Status = Transactions.Status.Failed;
                    }

                    if (trs.Count() == 0)
                    {

                        trservice.Create(ref tr);
                        t.Entry = tr.Entry;
                        try
                        {
                            s_mobile.Post();
                        }
                        catch (Exception ex) { Logging.Logging.ReportError(ex); }
                    }

                    else
                    {
                        t.code = 10;
                        t.error_Desc = GeterrorDesc(t.code);
                    }

                }
                catch (Exception ex)
                {
                    t.code = -1;
                    t.error_Desc = "Unspecified error";
                    Logging.Logging.ReportError(ex);
                }
            }
            Logging.Logging.LogEntryOnFile("Response");
            CreateXML(t);
            return t;
        }

        private static void validateaccount(ref Trans t)
        {
            try
            {
                Logging.Logging.LogEntryOnFile(t.Account_No);
                Accounts.Accounts a = Getaccount(t.Account_No);

                Members.member = Members.getmember(a.Member_No);
                Logging.Logging.LogEntryOnFile(t.Transaction_Type.ToString());
                if (a == null)
                {
                    t.code = 1;
                    return;
                }
                t.Account_Name = a.Name;
                Logging.Logging.LogEntryOnFile(t.Transaction_Type.ToString());
                if (a.Account_Status != Accounts.Account_Status.Active)
                {
                    t.code = 2;
                    return;
                }
                Logging.Logging.LogEntryOnFile(t.Transaction_Type.ToString());
                if (a.Blocked != Accounts.Blocked._blank_)
                {
                    t.code = 3;
                    return;
                }
                Logging.Logging.LogEntryOnFile(t.Transaction_Type.ToString());
                //if (a.S_Mobile_No.Replace("+", "") != t.Telephone_Number.Replace("+", ""))
                //{
                //    t.code = 5;
                //    return;
                //}
                switch ((Trans_Type)t.Transaction_Type)
                {
                    case Trans_Type.Deposit:
                    case Trans_Type.Loan_Repayment:
                    case Trans_Type.Loan_Application:
                    case Trans_Type.Reversal:
                    case Trans_Type.Share_Contribution:
                        break;
                    default:
                        {
                            if ((Balance(t.Account_No) < (double)(t.Amount + t.Charge + Tcharges((Trans_Type)t.Transaction_Type, t.Amount))))
                            {
                                t.code = 4;
                                return;
                            }
                            break;
                        }
                }
                Logging.Logging.LogEntryOnFile(t.Transaction_Type.ToString());
                switch ((Trans_Type)t.Transaction_Type)
                {
                    case Trans_Type.Withdrawal:
                        try
                        {
                            if (Dailyamount(t.Account_No, Trans_Type.Airtime.ToString()) > setup.Max_Daily_limit)
                            {
                                t.code = 11;
                                return;
                            }
                            if (t.Amount > setup.Max_Trans_Limit)
                            {
                                t.code = 12;
                                return;
                            }
                        }
                        catch (Exception ex) { Logging.Logging.ReportError(ex); }
                        break;
                    case Trans_Type.Airtime:
                        if (Dailyamount(t.Account_No, Trans_Type.Airtime.ToString()) > setup.Max_daily_Airtime)
                        {
                            t.code = 11;
                            return;
                        }
                        if (t.Amount > setup.Max_airtime)
                        {
                            t.code = 12;
                            return;
                        }
                        if (t.Amount < setup.Min_Airtime)
                        {
                            t.code = 12;
                            return;
                        }
                        break;
                    case Trans_Type.Share_Deposit_Balance:
                        if (Members.member == null)
                        {
                            t.code = 13;
                            return;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                t.code = -1;
                Logging.Logging.ReportError(ex);
            }
        }
        private static decimal Dailyamount(string account_No, string t)
        {
            decimal limit = 0;
            try
            {
                limit = trservice.ReadMultiple(new Transactions_Filter[] { new Transactions_Filter { Criteria = account_No, Field = Transactions_Fields.Account_No }, new Transactions_Filter { Criteria = "<>Failed", Field = Transactions_Fields.Status }, new Transactions_Filter { Criteria = DateTime.Now.Date.ToString(parsedate()), Field = Transactions_Fields.Document_Date }, new Transactions_Filter { Criteria = t, Field = Transactions_Fields.Transaction_Type } }, null, 100).Sum(o => o.Amount);

            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            return limit;
        }
        private static string parsedate()
        {
            string inputString = "15-08-2015";
            string format = string.Empty;
            DateTime dDate;

            if (DateTime.TryParse(inputString, out dDate))
            {
                format = "dd/MM/yyyy";
            }
            else
            {
                format = "MM/dd/yyyy";
            }

            return format;
        }
        private static void checkparameters(ref Trans t)
        {
            if (t.Document_No == string.Empty)
            {
                t.code = 6;
                return;
            }
            if (t.Telephone_Number == string.Empty)
            {
                t.code = 7;
                return;
            }
            if (t.Account_No == string.Empty)
            {
                t.code = 8;
                return;
            }
            if ((Trans_Type)t.Transaction_Type == Trans_Type._blank_)
            {
                t.code = 9;
                return;
            }

            switch ((Trans_Type)t.Transaction_Type)
            {
                case Trans_Type.Reversal:
                    var trs = trservice.ReadMultiple(new Transactions_Filter[] { new Transactions_Filter { Criteria = t.Document_No, Field = Transactions_Fields.Document_No }, new Transactions_Filter { Criteria = "Completed|Pending", Field = Transactions_Fields.Status }, new Transactions_Filter { Criteria = "<>Reversal", Field = Transactions_Fields.Transaction_Type } }, null, 1);
                    if (trs == null)
                    {
                        t.code = 15;
                        return;

                    }
                    break;


            }

        }

        public static Accounts.Accounts Getaccount(string account_No)
        {
            Accounts.Accounts acc = null;
            try
            {
                acc = Accservice.Read(account_No);
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return acc;
        }
        public static List<Accounts.Accounts> Getaccounts(string tel)
        {
            List<Accounts.Accounts> acc = new List<Accounts.Accounts>();
            try
            {
                acc = Accservice.ReadMultiple(new Accounts.Accounts_Filter[] { new Accounts.Accounts_Filter { Criteria = tel, Field = Accounts.Accounts_Fields.MPESA_Mobile_No } }, null, 1000).ToList();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return acc;
        }
        public static List<Accounts.Accounts> Getmemberaccounts(string memberno)
        {
            List<Accounts.Accounts> acc = new List<Accounts.Accounts>();
            try
            {
                acc = Accservice.ReadMultiple(new Accounts.Accounts_Filter[] { new Accounts.Accounts_Filter { Criteria = memberno, Field = Accounts.Accounts_Fields.Member_No } }, null, 1000).ToList();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return acc;
        }
        private static string GeterrorDesc(int code)
        {
            string err = string.Empty;
            try
            {
                err = s_mobile.GetErrorCode(code);
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            return err;
        }

        private static decimal Tcharges(Trans_Type transaction_Type, decimal amount)
        {
            return s_mobile.Charge((int)transaction_Type, amount);

        }
        public static double Balance(string account)
        {
            double bal = 0;
            try
            {
                bal = (double)s_mobile.Balance(account);
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            return bal;
        }
        public static void Ministatement(ref Trans t)
        {
            List<Ministatement> mini = new List<Ministatement>();
            try
            {

                var min = Accentriesservice.ReadMultiple(new Statement.Account_Entries_Filter[] { new Statement.Account_Entries_Filter { Criteria = t.Account_No, Field = Statement.Account_Entries_Fields.Vendor_No } }, null, t.statement_size).ToList();
                foreach (var m in min)
                {
                    var nmin = new Ministatement();
                    nmin.amount = (double)m.Amount;
                    nmin.desc = m.Desc;
                    nmin.posting_Date = m.Posting_Date;
                    mini.Add(nmin);
                }
                t.Mini = mini;
            }
            catch (Exception ex)
            {
                t.code = -1;
                Logging.Logging.ReportError(ex);
            }
        }
    }
        public partial class Smss : Results
    {
        public static Sms_Service smsservice = new Sms_Service();
        public static List<Sms.Sms> Getsms(int count)
        {
            List<Sms.Sms> s = new List<Sms.Sms>();
            try
            {
                s = smsservice.ReadMultiple(new Sms_Filter[] { new Sms_Filter { Criteria = "No", Field = Sms_Fields.Sent_To_Server } }, null, count).ToList();
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            return s;
        }
        public static void Upddatesms(ref List<Sms.Sms> s)
        {
            try
            {
                Sms.Sms[] ss = s.ToArray();
                smsservice.UpdateMultiple(ref ss);
                s = ss.ToList();
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
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
                a = Trans.Accservice.ReadMultiple(new Accounts.Accounts_Filter[] { new Accounts.Accounts_Filter { Criteria = No, Field = Accounts.Accounts_Fields.Member_No } }, null, 0).ToList();

                return a.ToArray();

            }
        }
    }
}
