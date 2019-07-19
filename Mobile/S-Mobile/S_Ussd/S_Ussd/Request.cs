using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile;
namespace S_Ussd
{

    public class depositoptions
    {
        public string no;
        public string name;
        public string type;

    }
    public class useroptions
    {
        public static string Menu(ref Request r, List<Client_Menu> m)
        {
            string menu = string.Empty;
            try
            {
                int i = 1;
                foreach (Client_Menu mm in m)
                {
                    User_Option nm = new User_Option();
                    nm.Acc = mm.Menu_Id.ToString();
                    nm.Name = mm.Description;
                    nm.Session = r.SESSIONID;
                    nm.Selection = i;
                    nm.Option = (int)enums.options.Menu;
                    Request.db.User_Options.Add(nm);
                    menu = string.Format("{0}{1}. {2}{3}", menu, i, nm.Name, Request.newline);
                    i += 1;
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }

            return menu;
        }
        public static string accounts(ref Request r, List<account> m, enums.options option = enums.options.Withacc)
        {
            string str1 = string.Empty;
            try
            {
                int i = 1;
                foreach (account mm in m)
                {
                    User_Option nm = new User_Option();
                    nm.Acc = mm.No.ToString();
                    nm.Name = mm.Name;
                    nm.Session = r.SESSIONID;
                    nm.Value = mm.Balance;
                    nm.Selection = i;
                    nm.Type = mm.memberno;
                    nm.Option = (int)option;
                    Request.db.User_Options.Add(nm);
                    str1 = string.Format("{0}{1}. {2}{3}", str1, i, nm.Acc, Request.newline);
                    i += 1;
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }

            return str1;
        }
        public static string utilities(ref Request r, List<Utility> m)
        {
            string str1 = string.Empty;
            try
            {
                int i = 1;
                foreach (Utility mm in m)
                {
                    User_Option nm = new User_Option();
                    nm.Acc = mm.Id.ToString();
                    nm.Name = mm.Name;
                    nm.Session = r.SESSIONID;
                    nm.Value = 0;
                    nm.Selection = i;

                    nm.Option = (int)enums.options.Utility;
                    Request.db.User_Options.Add(nm);
                    str1 = string.Format("{0}{1}. {2}{3}", str1, i, nm.Name, Request.newline);
                    i += 1;
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }

            return str1;
        }
        public static string loans(ref Request r, List<loan> m)
        {
            string str1 = string.Empty;
            try
            {
                int i = 1;
                foreach (loan mm in m)
                {
                    User_Option nm = new User_Option();
                    nm.Acc = mm.No.ToString();
                    nm.Name = mm.Name;
                    nm.Session = r.SESSIONID;
                    nm.Value = mm.Balance + mm.Interest;
                    nm.Selection = i;
                    nm.Option = (int)enums.options.Loans;
                    Request.db.User_Options.Add(nm);
                    str1 = string.Format("{0}{1}. {2}({3}){4}", str1, i, nm.Acc, nm.Value, Request.newline);
                    i += 1;
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }

            return str1;
        }

        public static string Deposits(ref Request r, List<depositoptions> m)
        {
            string str1 = string.Empty;
            try
            {
                int i = 1;
                foreach (depositoptions mm in m)
                {
                    User_Option nm = new User_Option();
                    nm.Acc = mm.no.ToString();
                    nm.Name = mm.name;
                    nm.Session = r.SESSIONID;
                    nm.Value = 0;
                    nm.Selection = i;
                    nm.Type = mm.type;
                    nm.Option = (int)enums.options.deposit;
                    Request.db.User_Options.Add(nm);
                    str1 = string.Format("{0}{1}. {2}{3}", str1, i, nm.Name, Request.newline);
                    i += 1;
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }

            return str1;
        }

        public static void selectedmenu(ref Request r)
        {
            if (String.IsNullOrEmpty(r.session.Menu.ToString()))
            {
                Request rr = r;
                var usersel = int.Parse(userselection(rr, enums.options.Menu).Acc);
                var d = Request.db.Menus.FirstOrDefault(o => o.ID == usersel);
                r.session.Menu = d.ID;
            }

        }
        public static User_Option userselection(Request r, enums.options e)
        {
            var usersel = int.Parse(r.Currentoption);
            int ee = (int)e;
            return Request.db.User_Options.FirstOrDefault(o => o.Selection == usersel && o.Session == r.SESSIONID && o.Option == ee);
        }
    }
    public class Request
    {
        public static MobileEntities db;
        public static string newline = "&#x000a;";
        public string MSISDN;
        public string SESSIONID;
        public string SERVICECODE;
        public string USSDSTRING;
        public string clientCode;
        public string Currentoption;
        public Customer customer;
        public Ussd session;
        public Client client;
        public List<Session> sessiondetails;
        public Transaction transaction;
        public Session lastsession;
        public static string common = string.Format("{0}00. Home{0} 000. Logout", newline);
    }
    public class lang
    {
        public Request request;
        public enums.response message;
        public static string getlang(enums.sessionstatus s, ref Request l, enums.response message, params object[] args)
        {
            string mes = message.ToString();
            string lan;
            if (l.customer == null)
                lan = "EN";
            else
                lan = l.customer.Language;
            Session ss = new Session();
            ss.SESSION_ID = l.SESSIONID;
            ss.Value = l.Currentoption;
            ss.Option = (int)message;
            Request.db.Sessions.Add(ss);
            var ll = Request.db.Ussd_Languages.FirstOrDefault(o => o.Languagecode == lan && o.Messagecode == mes);
            return string.Format("{0} {1}", s.ToString(), string.Format(ll.Message, args));
            //  return string.Concat( string.Format("{0} {1}", s.ToString(), string.Format(Request.db.Languages.FirstOrDefault(o => o.Languagecode == lan && o.Messagecode == mes).Message, args)),Request.common);
        }
    }
    public class enums
    {
        public enum options
        {
            Menu = 0,
            Withacc = 1,
            Loans,
            deposit,
            ToAccount,
            Utility
        }
        public enum sessionstatus
        {
            CON,
            END
        }

        public enum response
        {
            NotRegistered = 0,
            NotActive = 1,
            pin = 2,
            selectclient = 3,
            Menu = 4,
            Repin = 5,
            Blocked = 6,
            balance = 7,
            insufficientfunds = 8,
            Ministatement = 9,
            selectacc = 10,
            Noaccount = 11,
            sendto = 12,
            amount = 13,
            otheraccount = 14,
            Invalidentry = 15,
            withdrawalconfirm = 16,
            withdrawal = 17,
            Cancel_cash_Deposit = 18,
            selectdeposit = 19,
            SelectLoans = 20,
            Depositconfirm = 21,
            Deposit = 22,
            canceldeposit = 23,
            Transferto = 24,
            selectToacc = 25,
            Tconfirm = 26,
            Transfer = 27,
            otherTelephone = 28,
            Topupconfirm = 29,
            Topup = 30,
            canceltopup = 31,
            selectutility = 32,
            utilityaccount = 33,
            Utilityconfirm = 34,
            Utility = 35,
            cancelUtility = 36,
            Newpin = 37,
            Confirmpin = 38,
            PinChanged = 39,
            loanamount = 40,
            invalidloanamount = 41,
            loanconfirm = 42,
            Loan = 43,
            cancelloan = 44,
            Failed = 45,

            //agency
            enter_account = 101,
            enter_amount  = 102,
            agency_confirm = 103,
            cash_Deposit = 104,
            enter_id = 105,
            enter_amount_withdrawal = 106,
            customerpin = 107,
            customerotp = 108,
            wrongotp = 109,
            agency_withdrawal_confirm = 110,
            cash_withdrawal = 111,
            Cancel_trans = 112,
            BankCode = 113,
            enter_amount_bill = 114,
            agency_bills_confirm = 115,
            bill_type = 116,
            enter_account_to = 117,
            enter_amount_transfer = 118,
            agency_transfer_confirm = 119,
            bill_account = 120
        }
        //public enum Transtype
        //{
        //    /// <remarks/>
        //    _blank_,

        //    /// <remarks/>
        //    Withdrawal,

        //    /// <remarks/>
        //    Deposit,

        //    /// <remarks/>
        //    Balance,

        //    /// <remarks/>
        //    Ministatement,

        //    /// <remarks/>
        //    Airtime,

        //    /// <remarks/>
        //    Loan_balance,

        //    /// <remarks/>
        //    Loan_Status,

        //    /// <remarks/>
        //    Share_Deposit_Balance,

        //    /// <remarks/>
        //    Transfer_to_Fosa,

        //    /// <remarks/>
        //    Transfer_to_Bosa,

        //    /// <remarks/>
        //    Utility_Payment,

        //    /// <remarks/>
        //    Loan_Application,

        //    /// <remarks/>
        //    Standing_orders,
        //}
        public enum Menu
        {
            Balance = 1,
            Ministatement = 2,
            Withdrawal = 3,
            Deposits = 4,
            Transfer = 5,
            Topup = 6,
            utility = 7,
            Pin = 8,
            E_loan = 9,
            //Agency
            Cash_withdrawal_agency = 1006,
            Cash_Deposit_agency = 1007,
            Fund_Transfer_agency = 1008,
            Bill_Payment_agency = 1009
        }
    }
    public class Member
    {
        public string No;
        public string Name;
        public List<account> Account;

    }
    public class account
    {
        public string No;
        public string Name;
        public Stat Status;
        public double Balance;
        public string memberno;


        public enum Stat
        {

            /// <remarks/>
            Active,

            /// <remarks/>
            Frozen,

            /// <remarks/>
            Closed,

            /// <remarks/>
            Archived,
            /// <remarks/>
            New,

            /// <remarks/>
            Dormant,

            /// <remarks/>
            Deceased,
        }
        public account(string no, string name, Stat status, double balance, string member)
        {
            No = no;
            Name = name;
            Status = status;
            Balance = balance;
            memberno = member;
        }
    }
    public class loan
    {
        public string No;
        public string Name;
        public Stat Status;
        public double Balance;
        public double Interest;
         public enum Stat
        {
            /// <remarks/>
            New,

            /// <remarks/>
            Appraisal,

            /// <remarks/>
            Posted,
        }
        public loan(string no, string name, Stat status, double balance, double interest)
        {
            No = no;
            Name = name;
            Status = status;
            Balance = balance;
            Interest = interest;
        }
    }
    public class client
    {
        public static S_mobileClient.Client smobile = new S_mobileClient.Client();
        public static List<account> Accounts(string tel)
        {
            List<account> Account = new List<account>();
            try
            {
                var a = smobile.Accounts(tel);
                foreach (S_mobileClient.Accounts ac in a)
                {
                    Account.Add(new account(ac.noField, ac.nameField, (account.Stat)ac.account_StatusField, (double)ac.balanceField, ac.member_NoField));
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            return Account;
        }
        public static account Account(string acc)
        {
            account Account = null;
            try
            {
                var a = smobile.Account(acc);
                Account = new account(a.noField, a.nameField, (account.Stat)a.account_StatusField, (double)a.balanceField, a.member_NoField);

            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            return Account;
        }
        public static double Eligibility(string acc)
        {
            double elig = 0;
            try
            {

                bool spec;
                smobile.Eligibility(acc, out elig, out spec);


            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            return elig;
        }

        public static List<loan> Loans(string tel)
        {
            List<loan> Account = new List<loan>();
            try
            {
                var a = smobile.CustomerLoans(tel);
                foreach (S_mobileClient.Loans ac in a)
                {
                    Account.Add(new loan(ac.loan_NoField, ac.loan_NameField, (loan.Stat)ac.loan_StatusField, (double)ac.loan_BalanceField, (double)ac.accrued_InterestField));
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            return Account;
        }

        public static Member member(string tel)
        {
            Member Account = new Member();
            try
            {
                var a = smobile.member(tel);

            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            return Account;
        }
        public static List<account> MemberAccounts(string memberno)
        {
            List<account> Account = new List<account>();
            try
            {
                var a = smobile.Memberaccounts(memberno);
                foreach (S_mobileClient.Accounts ac in a)
                {
                    Account.Add(new account(ac.noField, ac.nameField, (account.Stat)ac.account_StatusField, (double)ac.balanceField, ac.member_NoField));
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            return Account;
        }

        public static double Balance(string acc)
        {
            double bal = 0;
            try
            {
                bool bs = true;
                smobile.Bal(acc, out bal, out bs);//.Account(acc).balanceField;
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return bal;
        }



        public static double Balance(ref Request r)
        {
            double bal = 0;
            try
            {
                var t = Trans(ref r);

                bal = (double)smobile.Account(r.transaction.Account_No).balanceField;
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return bal;
        }
        public static double Tcharges(double amount, Transtype type)
        {
            double bal = 0;
            return bal;
        }

        public static string ministatement(ref Request r)
        {
            StringBuilder mini = new StringBuilder();
            try
            {
                r.transaction.Min_size = 5;
                var t = Trans(ref r);
                if (t.code == 0)
                    foreach (S_mobileClient.Ministatement min in t.Mini)
                    {
                        mini.AppendLine(string.Format("{0}:{1}:{2}:{3}", min.posting_Date.ToShortDateString(), (min.amount > 0 ? "CR" : "DR"), min.amount, min.desc));
                    }
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
            return mini.ToString();
        }
        public static S_mobileClient.Trans Trans(ref Request t)
        {
            S_mobileClient.Trans trans = new S_mobileClient.Trans();
            try
            {
                trans.Account_No = t.transaction.Account_No;
                trans.Document_No = t.transaction.Document_No;
                trans.Document_Date = DateTime.Now.Date;
                trans.Transaction_Time = DateTime.Now;
                trans.Transaction_Type = (int)t.transaction.Transaction_Type;
                trans.Account_2 = t.transaction.Account_2;
                trans.Charge = (decimal)(t.transaction.Charge ?? 0);
                trans.Amount = (decimal)(t.transaction.Amount ?? 0);
                trans.Telephone_Number = t.transaction.MSISDN;
                trans.Transaction_TypeSpecified = true;
                trans.Transaction_TimeSpecified = true;
                trans.ChargeSpecified = true;
                trans.AmountSpecified = true;
                trans.Document_DateSpecified = true;
                trans = smobile.Transaction(trans);
                t.transaction.Status = trans.code;
                t.transaction.Comments = trans.Comments;
            }


            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return trans;
        }
    }


    public partial class Customer
    {

        public Client client_record
        {
            get
            {
                using (var db = new MobileEntities())
                {
                    if (Client != null)
                        return db.Clients.FirstOrDefault(o => o.Client_Code == Client);
                    else
                        return null;
                }
            }
        }
    }
    
}
