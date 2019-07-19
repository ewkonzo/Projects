using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PData.Transactions;
using System.Xml.Serialization;
using System.IO;
using PData.Loans;
using PData.Sms;
using System.Xml;

namespace PData
{

    public class loan
    {
        public static Loans.Loans_Service loanservice = new Loans.Loans_Service();
        public string loantype;
        public decimal balance;
        public Loans.Loan_Status status;
        
        public static List<Loans.Loans> Customerloans(string acc)
        {
            List<Loans.Loans> Customerloan = new List<Loans.Loans>();
            try
            {
                Customerloan = loanservice.ReadMultiple(new Loans_Filter[] { new Loans_Filter { Criteria = acc, Field = Loans_Fields.Client_Code } }, null, 10).ToList();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return Customerloan;
        }

        internal static void LoanBalance(ref Trans t)
        {
            List<loan> ll = new List<loan>();
            Trans tt = t;
            var cl = Customerloans(t.Account_No).Where(o => o.Posted == true);
            foreach (var l in cl)
            {
                loan la = new loan();
                la.loantype = l.Loan_Name;
                la.balance = l.Outstanding_Balance + l.Oustanding_Interest;
                ll.Add(la);
            }
            Accounts.Accounts a =Trans. Getaccount(t.Account_No);

            Members.member = Members.getmember(a.BOSA_Account_No);
   cl = Customerloans(Members.member.No).Where(o => o.Posted == true);
            foreach (var l in cl)
            {
                if (ll.FirstOrDefault(o => o.loantype == l.Loan_Name) == null)
                {
                    loan la = new loan();
                    la.loantype = l.Loan_Name;
                    la.balance = l.Outstanding_Balance + l.Oustanding_Interest;
                    ll.Add(la);
                }
            }

            t.LoanBalances = ll;
        }
        internal static void Loanstatus(ref Trans t)
        {
            List<loan> ll = new List<loan>();
            Trans tt = t;
            var cl = Customerloans(t.Account_No).Where(o => o.Posted == false);
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
            cl = Customerloans(Members.member.No).Where(o => o.Posted == true);
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
        public void setup(ref settings s) {
            var p = s.Username;
            s.pass = p ;
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
            catch (Exception ex) {
                Logging.Logging.ReportError(ex);
            } return m;
        }
    }
    
    public class Trans : Results
    {
        public static Transactions.Transactions_Service trservice = new Transactions.Transactions_Service();
        public static Statement.Account_Entries_Service Accentriesservice = new Statement.Account_Entries_Service();
        public static Accounts.Accounts_Service Accservice = new Accounts.Accounts_Service();
        public static S_Mobile.S_Mobile s_mobile = new S_Mobile.S_Mobile();
        public int Entry;
        public string Account_No= string.Empty;
        public string Account_Name;
        public string Document_No=string.Empty;
        public System.DateTime Document_Date = DateTime.Now.Date;
        public System.DateTime Transaction_Time = DateTime.Now;
        public int Transaction_Type=-1;
        public string Telephone_Number = string.Empty;
        public string Account_2;
        public string Loan_No;
        public Transactions.Status Status = Transactions.Status.Pending;
        public string Comments;
        public decimal Amount=0;
        public decimal Charge=0;
        public string Description=string.Empty;
        public string Client;
        public List<Ministatement> Mini = null;
        public decimal AccountBalance = 0;
        public List<loan> LoanBalances = null;
        public List<loan> LoanStatus = null;
        public decimal sharedepositbalance = 0;
        public int statement_size = 5;
        public static PData.Setup.Setup_Service setupservice = new PData.Setup.Setup_Service();
        public static PData.Setup.Setup setup;


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
            Reversal =14,
            Loan_Repayment=15,
            Share_Contribution=16,
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
                    tr.Transaction_Type = (Transactions.Transaction_Type)t.Transaction_Type;
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
                            t.sharedepositbalance = Members.member.Current_Shares;
                            break;
                        case Trans_Type.Loan_Status:
                            loan.Loanstatus(ref t);
                            if (t.LoanStatus.Count() == 0)
                                t.code = 13;
                            break;
                       
                        case Trans_Type.Loan_Application:
                            try
                            {
                              var amount =  s_mobile.AdvanceEligibility(t.Account_No);
                                if (amount < t.Amount)
                                    t.code = 19;
                            }
                            catch(Exception ex)
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
                        tr.Status =Transactions. Status.Failed;
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

                    else {
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

                Members.member = Members.getmember(a.BOSA_Account_No);
                Logging.Logging.LogEntryOnFile(t.Transaction_Type.ToString());
                if (a == null)
                {
                    t.code = 1;
                    return;
                }
                t.Account_Name = a.Name;
                Logging.Logging.LogEntryOnFile(t.Transaction_Type.ToString());
                if (a.Status != Accounts.Status.Active)
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
                            break; }
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
            catch (Exception ex) {
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

            switch((Trans_Type) t.Transaction_Type)
            {
                case Trans_Type.Reversal:
                  var  trs = trservice.ReadMultiple(new Transactions_Filter[] { new Transactions_Filter { Criteria = t.Document_No, Field = Transactions_Fields.Document_No }, new Transactions_Filter { Criteria = "Completed|Pending", Field = Transactions_Fields.Status }, new Transactions_Filter { Criteria = "<>Reversal" , Field = Transactions_Fields.Transaction_Type } }, null, 1);
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
                acc = Accservice.ReadMultiple(new Accounts.Accounts_Filter[] { new Accounts.Accounts_Filter { Criteria = tel, Field = Accounts.Accounts_Fields.S_Mobile_No } }, null, 1000).ToList();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return acc;
        }

        private static string GeterrorDesc(int code)
        {
            string err = "";
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
          return  s_mobile.Charge((int)transaction_Type, amount);
           
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
                    var nmin = new PData.Ministatement();
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
    
    }
 public partial class Sms:PData.Results
    {
    public static PData.Sms.Sms_Service smsservice = new PData.Sms.Sms_Service();

    public static List<PData.Sms.Sms> Getsms(int count)
    {
        List<PData.Sms.Sms> s = new List<PData.Sms.Sms>();
        try
        {
            s = smsservice.ReadMultiple(new PData.Sms.Sms_Filter[] { new PData.Sms.Sms_Filter { Criteria = "No", Field = PData.Sms.Sms_Fields.Sent_To_Server } },null,count).ToList();
        }
        catch (Exception ex)
        {
            Logging.Logging.ReportError(ex);
        }
        return s;
    }

    public static void Upddatesms(ref List<PData.Sms.Sms> s)
    {
        try
        {
            PData.Sms.Sms[] ss = s.ToArray();
            smsservice.UpdateMultiple(ref ss);
            s = ss.ToList();
        }
        catch (Exception ex)
        {
            Logging.Logging.ReportError(ex);
        }
        
    }
}
namespace PData.MBranchTransactions
{
    public partial class M_Branch_Transactions
    {
        public string Date;
        public string Time;
    }
    }
