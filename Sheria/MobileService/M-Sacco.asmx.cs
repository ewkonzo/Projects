using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System.Net.Security;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace MobiService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    // [WebService(Namespace = "http://tempuri.org/")]
    [WebService(Namespace = "http://Spotcash.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Mobile : System.Web.Services.WebService
    {
        Results results = new Results();
        ServerSetting ss = new ServerSetting();
        System.Net.NetworkCredential cd;
        M_SACCO_Webservice.NavisionWebService.SPOTCASH Msacco = new M_SACCO_Webservice.NavisionWebService.SPOTCASH();
        M_SACCO_Webservice.MobileTransactions.MobileTransactions_Service trans = new M_SACCO_Webservice.MobileTransactions.MobileTransactions_Service();
        public Mobile()
        {
            string path = Server.MapPath("~/Settings.txt");
            ss.getsettings(path);
            cd = new System.Net.NetworkCredential(ss.user, ss.pass, ss.domain);
            Msacco.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/SPOTCASH", ss.server, ss.Companyname, ss.Instance, ss.Port);
            Msacco.PreAuthenticate = true;
            Msacco.Credentials = cd;
            trans.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/MobileTransactions", ss.server, ss.Companyname, ss.Instance, ss.Port);
            trans.PreAuthenticate = true;
            trans.Credentials = cd;

        }

        [WebMethod]
        public List<BalanceEnquiry> ReqBalanceEnquiry(string Phone, string reference)
        {
            List<BalanceEnquiry> l = new List<BalanceEnquiry>();
            try
            {

                Phone = Phone.Replace("+", "");
                try
                {
                    string[] Results = Msacco.BalanceEnquiry(ref Phone, reference).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    Results = Utilities.RemoveDuplicates(Results);

                    foreach (var Loans in Results)
                    {
                        if (string.IsNullOrEmpty(Loans.Replace(" ", "")) == false)
                        {
                            string[] loan = Loans.Split(new char[] { '|' }, StringSplitOptions.None);
                            BalanceEnquiry ll = new BalanceEnquiry();
                            ll.phone = loan[0];
                            ll.AccountNo = loan[1];
                            ll.AccountName = loan[2];
                            ll.Accounttype = loan[3];
                            ll.Balance = Convert.ToDouble(loan[4]);
                            ll.Transaction_Desc = loan[5];
                            ll.status = loan[6];
                            l.Add(ll);
                        }
                    }
                }
                catch (Exception ex)
                {
                    BalanceEnquiry ll = new BalanceEnquiry();
                    ll.Hasresults = false;
                    ll.Errors = ex.Message;
                    ll.Transaction_Desc = ex.Message;
                    l.Add(ll);
                }
                results.ResultsData = l;
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }

            return l;
        }
        [WebMethod]
        public List<LoanBalance> ReqLoanBalance(string phoneNo)
        {
            Utilities.LogEntryOnFile(string.Concat(new object[] { "LOANBALANCE Phone: ", phoneNo, " ", DateTime.Now, Environment.NewLine }));
            List<LoanBalance> loanBalances = new List<LoanBalance>();
            try
            {
                phoneNo = phoneNo.Replace("+", "").Trim();
                string[] strArrays = Utilities.RemoveDuplicates(this.Msacco.LoanStatus(phoneNo).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    string str = strArrays[i];
                    if (!string.IsNullOrEmpty(str.Replace(" ", "")))
                    {
                        string[] strArrays1 = str.Split(new char[] { '|' }, StringSplitOptions.None);
                        LoanBalance loanBalance = new LoanBalance()
                        {
                            LoanNo = strArrays1[0],
                            LoanType = strArrays1[1],
                            OutstandingBalance = Convert.ToDouble(strArrays1[2]),
                            Status = strArrays1[3],
                            Transaction_Desc = strArrays1[4]
                        };
                        loanBalances.Add(loanBalance);
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                Utilities.LogEntryOnFile(exception.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = exception.Message;
            }
            return loanBalances;
        }

        [WebMethod]
        public List<Registration> ReqRegistrations()
        {
            List<Registration> registrations = new List<Registration>();
            try
            {
                try
                {
                    string[] strArrays = this.Msacco.Registrations().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < (int)strArrays.Length; i++)
                    {
                        string[] strArrays1 = strArrays[i].Split(new char[] { '|' }, StringSplitOptions.None);
                        Registration registration = new Registration()
                        {
                            Date_Posted = DateTime.Today.ToString("dd-MM-yyyy HH:mm"),
                            Status = strArrays1[0],
                            Transaction_Desc = strArrays1[1],
                            NationalIdNo = strArrays1[2],
                            FosaACCNo = strArrays1[3],
                            MemberName = strArrays1[4],
                            MemberMobileNo = strArrays1[5]
                        };
                        registrations.Add(registration);
                    }
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    Registration registration1 = new Registration()
                    {
                        Hasresults = false,
                        Status = "1",
                        Transaction_Desc = exception.ToString(),
                        Errors = exception.Message
                    };
                    registrations.Add(registration1);
                }
                this.results.ResultsData = registrations;
            }
            catch (Exception exception3)
            {
                Exception exception2 = exception3;
                Utilities.LogEntryOnFile(exception2.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = exception2.Message;
            }
            return registrations;
        }
        [WebMethod]
        public List<Ministatement> ReqMinistatement(string Phone, string reference, int No_of_trans)
        {
            List<Ministatement> l = new List<Ministatement>();
            Phone = Phone.Replace("+", "");
           try
            {
                try
                {
                    string[] Results = Msacco.Ministatement(Phone, reference, No_of_trans).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var Loans in Results)
                    {
                        if (string.IsNullOrEmpty(Loans.Replace(" ", "")) == false)
                        {
                            string[] loan = Loans.Split(new char[] { '|' }, StringSplitOptions.None);
                            Ministatement ll = new Ministatement();
                            ll.Date_Posted = loan[0];
                            ll.Transaction_Desc = loan[1];
                            ll.Amount = loan[2];
                            ll.status = loan[3];
                            l.Add(ll);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Ministatement ll = new Ministatement();
                    ll.Hasresults = false;
                    ll.Errors = ex.Message;
                    ll.status = "1";
                    ll.Transaction_Desc = ex.Message;
                    l.Add(ll);
                }
                results.ResultsData = l;
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }
            return l;
        }
        [WebMethod]
        public List<SMS> ReqSMS()
        {
            List<SMS> l = new List<SMS>();
            try
            {
                try
                {
                    string[] Results = Msacco.Sms().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var msg in Results)
                    {

                        string[] message = msg.Split(new char[] { '|' }, StringSplitOptions.None);
                        SMS ll = new SMS();
                        ll.Date_Posted = DateTime.Today.ToString("dd-MM-yyyy HH:mm");
                        ll.Status = message[0];
                        ll.Transaction_Desc = message[1];
                        ll.SmsTelephoneNo = message[2];
                        ll.SmsBody = message[3];
                        l.Add(ll);
                    }
                }
                catch (Exception ex)
                {
                    SMS ll = new SMS();
                    ll.Hasresults = false;
                    ll.Status = "1";
                    ll.Transaction_Desc = ex.ToString();
                    ll.Errors = ex.Message;
                    l.Add(ll);
                }
                results.ResultsData = l;
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }

            return l;
        }

        [WebMethod]
        public List<WithdrawalRequest> ReqWithdrawalRequest(string Phone, string ReferenceNo, decimal Amount, decimal charge)
        {

            List<WithdrawalRequest> l = new List<WithdrawalRequest>();
            try
            {
                Phone = Phone.Replace("+", "");

                Amount += charge;

                try
                {
                    string[] Results = Msacco.WithdrawalRequest(Phone, Amount, ReferenceNo).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    WithdrawalRequest ll = new WithdrawalRequest();
                    ll.Amount = Convert.ToDouble(Results[0]);
                    ll.Transaction_Desc = Results[1];
                    ll.Status = Results[2];
                    l.Add(ll);
                }
                catch (Exception ex)
                {
                    WithdrawalRequest ll = new WithdrawalRequest();
                    ll.Hasresults = false;
                    ll.Errors = ex.Message;
                    ll.Status = "1";
                    ll.Transaction_Desc = ex.Message;
                    l.Add(ll);
                }

                results.ResultsData = l;
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }

            return l;
        }

        [WebMethod]
        public List<WithdrawalConfirm> ReqWithdrawalConfirm(string ReferenceNo, string recieptno, string description, string Phone, decimal Amount, decimal charge)
        {
            List<WithdrawalConfirm> l = new List<WithdrawalConfirm>();
             decimal num = new decimal();
             decimal amount = Amount + charge;
            string hasnulls = string.Empty;
             num = decimal.Parse(amount.ToString("#.####"));
             num = decimal.Round(num, 2);
            try
            {
                //check for nulls
                if (string.IsNullOrEmpty(recieptno))
                {
                    hasnulls = "Receipt No Empty";
                    Utilities.LogEntryOnFile(hasnulls);
                }

                //check for nulls
                if (string.IsNullOrEmpty(Phone))
                {
                    hasnulls = "Phone No Empty";
                    Utilities.LogEntryOnFile(hasnulls);
                }

                //check for nulls
                if (Amount == 0)
                {
                    hasnulls = "Amount is zero";
                    Utilities.LogEntryOnFile(hasnulls);
                }

                //check for nulls
                if (charge == 0)
                {
                    hasnulls = "Charge is zero";
                    Utilities.LogEntryOnFile(hasnulls);
                }

                Phone = Phone.Replace("+", "");

                try
                {
                    // spotcash transaction
                    string[] Results = Msacco.Inserttojournal(recieptno, "Withdrawal", description, DateTime.Now, Phone, Amount, "",ReferenceNo,num).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    // Safaricom Payment Charge 
                    string[] Results1 = Msacco.Inserttojournal(recieptno, "Withdrawal", "Business Payment Charge", DateTime.Now, Phone, charge, "",ReferenceNo,num).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    WithdrawalConfirm ll = new WithdrawalConfirm();
                    ll.Status = Results[0];

                    if (!string.IsNullOrEmpty(hasnulls))
                    {
                        ll.Transaction_Desc = hasnulls;
                    }
                    else
                    {
                        ll.Transaction_Desc = Results[1];
                    }

                    l.Add(ll);
                }
                catch (Exception ex)
                {
                    WithdrawalConfirm ll = new WithdrawalConfirm();
                    ll.Status = "1";
                    ll.Hasresults = false;
                    ll.Transaction_Desc = ex.ToString();
                    ll.Errors = ex.Message;
                    l.Add(ll);
                }

                results.ResultsData = l;

            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }

            return l;
        }

        [WebMethod]
        public List<WithdrawalDecline> ReqWithdrawalReversal(string Phone, string ReferenceNo, decimal Amount)
        {
            List<WithdrawalDecline> l = new List<WithdrawalDecline>();

            try
            {
                Phone = Phone.Replace("+", "");

                try
                {
                    string[] Results = Msacco.Decline(ReferenceNo).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    WithdrawalDecline ll = new WithdrawalDecline();
                    ll.Amount = Convert.ToDouble(Amount);
                    ll.Transaction_Desc = Results[1];
                    ll.Status = Results[0];
                    l.Add(ll);
                }
                catch (Exception ex)
                {
                    WithdrawalDecline ll = new WithdrawalDecline();
                    ll.Hasresults = false;
                    ll.Errors = ex.Message;
                    ll.Transaction_Desc = ex.ToString();
                    ll.Status = "1";
                    l.Add(ll);
                }

                results.ResultsData = l;
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }

            return l;
        }

        [WebMethod]
        public List<Deposit> ReqDeposit(string recieptno, string description, string phone, string AccountNo, decimal Amount)
        {

            List<Deposit> l = new List<Deposit>();

            try
            {
                string[] Results = Msacco.InserttojournalDeposits(recieptno, "Deposit", description, DateTime.Now, AccountNo, Amount, "", phone).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                Deposit ll = new Deposit();
                ll.Amount = Convert.ToDouble(Amount);
                ll.Transaction_Desc = Results[1];
                ll.Status = Results[0];
                l.Add(ll);

                results.ResultsData = l;
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }
            return l;
        }

        [WebMethod]
        public transaction Transactions(transaction t) {
            Result r = new Result();
            try
            {
               var tran =trans.Read(t.Reference, t.TransType);
               if (tran == null)
               {
                   tran = new M_SACCO_Webservice.MobileTransactions.MobileTransactions();
                   tran.Account_No = t.Account;
                   tran.Account_No_2 = t.Account_2;
                   tran.Charge =(decimal) t.charge;
                   tran.ChargeSpecified = true;
                   tran.Document_No = t.Reference;
                   tran.Amount =(decimal) t.Amount;
                   tran.AmountSpecified = true;
                   tran.Transaction_Date = t.TransTime.Date;
                   tran.Transaction_DateSpecified = true;
                   tran.Transaction_Time = t.TransTime;
                   tran.Transaction_TimeSpecified = true;
                   tran.Transaction_Type = t.TransType;
                   trans.Create(ref tran);
               }
                t.code = 0;
                t.Desc = "Successfull";
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                t.code = -1;
                t.Desc = ex.Message;
            }

            return t;

        }
        [WebMethod]
        public List<ShareContribution> ReqShareConrtibution(string recieptno, string description, string phone, string AccountNo, decimal Amount)
        {

            List<ShareContribution> l = new List<ShareContribution>();

            try
            {
                string[] Results = Msacco.InserttojournalDeposits(recieptno, "Share Contribution", description, DateTime.Now, AccountNo, Amount, "", phone).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                ShareContribution ll = new ShareContribution();
                ll.Amount = Convert.ToDouble(Amount);
                ll.Transaction_Desc = Results[1];
                ll.Status = Results[0];
                l.Add(ll);

                results.ResultsData = l;
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }

            return l;
        }

        [WebMethod]
        public List<Transfer> ReqTransfer(string accountFrom, string accountTo, decimal amount, string referenceNo, int transType)
        {

            List<Transfer> l = new List<Transfer>();

            try
            {
                string[] Results = Msacco.Transfer(accountFrom, accountTo, amount, referenceNo, transType).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                Transfer ll = new Transfer();
                ll.Amount = Convert.ToDouble(amount);
                ll.Transaction_Desc = Results[1];
                ll.Status = Results[0];
                l.Add(ll);

                results.ResultsData = l;
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }

            return l;
        }

        [WebMethod]
        public List<LoanStatus> ReqLoanStatus(string phoneNo)
        {
            List<LoanStatus> l = new List<LoanStatus>();

            try
            {

                phoneNo = phoneNo.Replace("+", "").Trim();

                string[] Results = Msacco.LoanStatus(phoneNo).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                Results = Utilities.RemoveDuplicates(Results);
                foreach (var Loans in Results)
                {
                    if (string.IsNullOrEmpty(Loans.Replace(" ", "")) == false)
                    {
                        string[] loan = Loans.Split(new char[] { '|' }, StringSplitOptions.None);
                        LoanStatus ll = new LoanStatus();
                        ll.LoanNo = loan[0];
                        ll.LoanType = loan[1];
                        ll.OutstandingBalance = Convert.ToDouble(loan[2]);
                        ll.Status = loan[3];
                        ll.Transaction_Desc = loan[4];
                        l.Add(ll);
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }

            return l;
        }

        [WebMethod]
        public List<LoanRepayment> ReqLoanRepayment(string loanNumber, string Accountno, decimal amount, string referenceNo)
        {

            List<LoanRepayment> l = new List<LoanRepayment>();

            try
            {
                string[] Results = Msacco.PayLoan(loanNumber, amount, Accountno, referenceNo).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                LoanRepayment ll = new LoanRepayment();
                ll.Amount = Convert.ToDouble(amount);
                ll.Transaction_Desc = Results[1];
                ll.Status = Results[0];
                l.Add(ll);

                results.ResultsData = l;
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }

            return l;
        }

        [WebMethod]
        public List<AirtimeRequest> ReqAirtime(string Phone, string ReferenceNo, decimal Amount, string description)
        {
            List<AirtimeRequest> l = new List<AirtimeRequest>();
            try
            {
                Phone = Phone.Replace("+", "");

                try
                {
                    string[] Results = Msacco.WithdrawalRequest(Phone, Amount, ReferenceNo).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    AirtimeRequest ll = new AirtimeRequest();
                    ll.Amount = Convert.ToDouble(Results[0]);
                    ll.Transaction_Desc = Results[1];
                    ll.Status = Results[2];
                    l.Add(ll);
                }
                catch (Exception ex)
                {
                    AirtimeRequest ll = new AirtimeRequest();
                    ll.Hasresults = false;
                    ll.Errors = ex.Message;
                    ll.Status = "1";
                    ll.Transaction_Desc = ex.Message;
                    l.Add(ll);
                }

                results.ResultsData = l;

            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }

            return l;
        }

        [WebMethod]
        public List<AirtimeConfirm> ReqAirtimeConfirm(string ReferenceNo, string recieptno, string description, string Phone, decimal Amount)
        {
            List<AirtimeConfirm> l = new List<AirtimeConfirm>();

            try
            {
                Phone = Phone.Replace("+", "");

                try
                {
                    // spotcash transaction
                    string[] Results = Msacco.Inserttojournal(recieptno, "Utility Payment", description, DateTime.Now, Phone, Amount, "",ReferenceNo,Amount).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    AirtimeConfirm ll = new AirtimeConfirm();
                    ll.Amount = Convert.ToDouble(Results[0]);
                    ll.Transaction_Desc = Results[1];
                    ll.Status = Results[0];
                    l.Add(ll);
                }
                catch (Exception ex)
                {
                    AirtimeConfirm ll = new AirtimeConfirm();
                    ll.Hasresults = false;
                    ll.Errors = ex.Message;
                    ll.Transaction_Desc = ex.Message;
                    l.Add(ll);
                }
                results.ResultsData = l;
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }
            return l;
        }

        [WebMethod]
        public List<AirtimeDecline> ReqAirtimeReversal(string Phone, string ReferenceNo, decimal Amount)
        {
            List<AirtimeDecline> l = new List<AirtimeDecline>();
            try
            {
                Phone = Phone.Replace("+", "");

                try
                {
                    string[] Results = Msacco.Decline(ReferenceNo).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    AirtimeDecline ll = new AirtimeDecline();
                    ll.Status = Results[0];
                    ll.Transaction_Desc = Results[1];
                    l.Add(ll);
                }
                catch (Exception ex)
                {
                    AirtimeDecline ll = new AirtimeDecline();
                    ll.Hasresults = false;
                    ll.Errors = ex.Message;
                    ll.Status = "1";
                    ll.Transaction_Desc = ex.Message;
                    l.Add(ll);
                }
                results.ResultsData = l;
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }

            return l;
        }
       public enum Loantype{ELoan=0,Mloan=1,Divinded=2}
       public enum source { Mpesa=0, Fosa=1 }
           [WebMethod]
        public Result ReqLoanRequest(string Phone, string ReferenceNo, decimal Amount, Loantype loantype)
        {
            Result r = new Result();
            try
            {
                Phone = Phone.Replace("+", "");
                try
                {
                    int Results = Msacco.LoanRequest(ReferenceNo, Phone, Amount,(int) loantype);
                    r.code = 0;
              }
                catch (Exception ex)
                {
                    r.code = -1;
                    r.Desc = ex.Message;
                }
            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
            }

            return r;
        }
    [WebMethod]
        public Result ReqLoanEligibility(string Phone, Loantype loantype)
        {
            Result r = new Result();
            try
            {
                Phone = Phone.Replace("+", "");
                try
                {

                    decimal Results = Msacco.LoanEligibility(Phone,(int) loantype);
                    r.code = 0;
                    r.Data = Results;

                }
                catch (Exception ex)
                {
                    r.code = -1;
                    r.Desc = ex.Message;
                }

            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
            }

            return r;
        } 
        [WebMethod]
    public LoanbalResult ReqLoanbal(string Phone, Loantype loantype)
        {
            LoanbalResult r = new LoanbalResult();
            try
            {
                Phone = Phone.Replace("+", "");
                try
                {
                    string Name = string.Empty;
                    try
                    {
                        Name = Msacco.Accounts(Phone).Split(new char[]{'~'})[0].Split(new char[]{'|'})[1].ToString();
                    }
                    catch (Exception exx)
                    { }
                    var bal = Msacco.Loanbal(Phone,(int) loantype);
                    Loanball l = new Loanball();
                    
                    l.bal =(double) bal;
                    l.name = Name;
                    r.code = 0;
                    r.Data = l;
                }
                catch (Exception ex)
                {
                    r.code = -1;
                    r.Desc = ex.Message;
                }

            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
            }

            return r;
        } [WebMethod]
        public Result ReqLoanrepayment(string Phone, string ReferenceNo, decimal Amount,Loantype loantype,source Source)
        {
            Result r = new Result();
            try
            {
                Phone = Phone.Replace("+", "");
                try
                {
                    decimal Results = Msacco.LoanRepayment(ReferenceNo, Phone,Amount,(int) loantype,(int) Source);
                    r.code = 0;
                    r.Data = Results;
                }
                catch (Exception ex)
                {
                    r.code = -1;
                    r.Desc = ex.Message;
                }

            }
            catch (Exception ex)
            {
                Utilities.LogEntryOnFile(ex.Message);
            }

            return r;
        }
    }
}
