using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Logs = Logging.Logging;
using sms = Sendsms;
using System.Data.SqlClient;
using System.Drawing;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity;
using System.Xml.Serialization;
using System.IO;
using Mpesa;
using Mobile;
namespace S_Ussd
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class S_Mobile : WebService
    {
        public string res = "END Thank You for using M-Branch";
        static settings s = new settings();
        public static Request req = new Request();
        public lang lang = new lang();
        
        public S_Mobile()
        {
            s = s.loadsettings(HttpContext.Current.Server.MapPath("~/Settings.xml"));
          // var connectionstring = PData. Connectionstring(@".\", "Mobile");
            Request.db = new MobileEntities(ConnectionString());
        }
        public static string ConnectionString()
        {
            // Specify the provider name, server and database.
            string providerName = "System.Data.SqlClient";
            //string serverName = "Server\\sql2008";
            //string databaseName = client.Db;
            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            // Set the properties for the data source.
            sqlBuilder.DataSource =string.Concat(s.Serverip, @"\", s.Instance);
            sqlBuilder.InitialCatalog = s.Database;
            sqlBuilder.IntegratedSecurity =s.IntegratedSecurity;
            sqlBuilder.MultipleActiveResultSets = true;
            if (s.IntegratedSecurity == false)
            {
                sqlBuilder.UserID = s.Username;
                sqlBuilder.Password = s.pass;
            }
            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();
            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            //Set the provider name.
            entityBuilder.Provider = providerName;
            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;
            // Set the Metadata location.
            entityBuilder.Metadata = "res://*/";
            return entityBuilder.ToString();

        }
        [WebMethod]
        public void USSDMTECH(string MSISDN, string SESSIONID, string DATA, string STAGE)
        {
            try
            {
                MSISDN = "+" + MSISDN;
                Logs.LogEntryOnFile(string.Format("{0}|{1}|{2}|{3}", MSISDN,SESSIONID,DATA,STAGE));
                String[] coption = DATA.Split(new Char[] { '*' }, StringSplitOptions.None);
                req.MSISDN = MSISDN;
                req.SESSIONID = SESSIONID;
                req.SERVICECODE = "";
                req.USSDSTRING =(STAGE == "BEGIN" ? "": DATA);
                req.Currentoption = coption[coption.GetUpperBound(0)];
                lang.request = req;
                //Welcome to our test USSD menu|12345| 254701123456|CONT 
                string m = Menu();
                string r = string.Format("{0}|{1}|{2}|{3}", m.Replace("CON ", "").Replace("END ", ""), SESSIONID, MSISDN, (m.StartsWith("CON") == true ? "CONTINUE": "ABORT")) ;
                Logging.Logging.LogEntryOnFile(r);
                res = r;
            }
            catch (Exception ex)
            {
                Logs.ReportError(ex);
            }
            Context.Response.Write(res);
        }
        [WebMethod]
        public void USSD(string phoneNumber, string sessionId, string serviceCode, string text)
        {
            try
            {
                String[] coption = text.Split(new Char[] { '*' }, StringSplitOptions.None);
                req.MSISDN = phoneNumber;
                req.SESSIONID = sessionId;
                req.SERVICECODE = serviceCode;
                req.USSDSTRING = text;
                req.Currentoption = coption[coption.GetUpperBound(0)];
                lang.request = req;
                res = Menu();
            }
            catch (Exception ex)
            {
                Logs.ReportError(ex);
            }
            Context.Response.Write(res);
        }
        public string Menu()
        {
            //using (Request.db = new PData.MobileEntities(data.Connectionstring(@".\", "Mobile")))
            using (Request.db = new MobileEntities(ConnectionString()))
            {
                try
                {
                    if (string.IsNullOrEmpty(req.USSDSTRING))
                    {
                        req.session = new Ussd();
                        req.session.SESSION = req.SESSIONID;
                        req.session.Phone = req.MSISDN;
                        req.session.Transaction_Time = DateTime.Now;
                        req.session.Code = req.SERVICECODE;
                        req.session.Status = (int)Status.Processing;
                        Request.db.Ussds.Add(req.session);
                        req.transaction = new Transaction();
                        req.transaction.Reference = req.SESSIONID;
                        req.transaction.Mpesa_Status = (int)Status.Pending;
                        req.transaction.Posted = false;
                        req.transaction.Status = (int)Status.Pending;
                        if (req.SESSIONID.Length > 18)
                            req.transaction.Document_No = req.SESSIONID.Substring(0, 20);
                        else
                            req.transaction.Document_No = req.SESSIONID;
                        req.transaction.MSISDN = req.MSISDN;
                        req.transaction.Transaction_Date = DateTime.Now;
                        Request.db.Transactions.Add(req.transaction);
                        var cust = Request.db.Customers.Where(o => o.Telephone == req.MSISDN).ToList();
                        if (cust.Count() == 0)
                        {
                            req.session.Status = (int)Status.Failed;
                            req.session.comments = "Not Registered";
                            return lang.getlang(enums.sessionstatus.END, ref req, enums.response.NotRegistered);
                        }
                        if (cust.Count() > 1)
                        {
                            return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.selectclient);
                        }
                        if (cust[0].Active == false)
                        {
                            req.session.Status = (int)Status.Failed;
                            req.session.comments = "Not Active";
                            return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.NotActive);
                        }
                        req.customer = cust[0];
                        req.session.Client = cust[0].Client;
                        return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.pin,Request.newline, cust[0].client_record.Client_Name,req.customer.Name);
                    }
                    else
                    {
                        req.transaction = Request.db.Transactions.FirstOrDefault(o => o.Reference == req.SESSIONID);
                        req.session = Request.db.Ussds.FirstOrDefault(o => o.SESSION == req.SESSIONID);
                        if (req.session != null)
                        {
                            req.sessiondetails = Request.db.Sessions.Where(o => o.SESSION_ID == req.SESSIONID).ToList();
                            req.customer = Request.db.Customers.FirstOrDefault(o => o.Telephone == req.MSISDN);
                            if (!string.IsNullOrEmpty(req.session.Client))
                                req.client = Request.db.Clients.FirstOrDefault(o => o.Client_Code == req.session.Client);
                            return pin();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logs.ReportError(ex);
                }
                finally
                {

                    Request.db.SaveChanges();
                }
            }
            return res;
        }
        private string pin()
        {
            string res = string.Empty;
            var r = req.sessiondetails.OrderByDescending(o => o.Id).FirstOrDefault();

            switch ((enums.response)r.Option)
            {
                case enums.response.pin:
                    return Validatepin();
                case enums.response.BankCode:
                    req.transaction.Send_to = req.Currentoption;
                    var menu3 = Request.db.Menus.Where(o => o.Active == true).Select(i => i.ID).ToList();
                    var menu1 = Request.db.Client_Menus.Where(o => o.Client == req.client.Client_Code && o.Active == true).OrderBy(o => o.Order).ToList();
                    var fmenu = menu1.Where(o => menu3.Contains((int)o.Menu_Id)).ToList();
                    req.session.Menu_Count = 0;
                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Menu, Request.newline, useroptions.Menu(ref req, fmenu));
                default:
                    useroptions.selectedmenu(ref req);
                    return menu(ref req);
            }
        }

        private string Validatepin()
        {
            try
            {
                var login = Request.db.Logins.FirstOrDefault(o => o.Telephone == req.MSISDN && o.PIN_Encrypted == req.Currentoption);
                if (login != null)
                {
                    var menu = Request.db.Menus.Where(o =>  o.Active == true).Select(i=> i.ID).ToList();
                    var menu1 = Request.db.Client_Menus.Where(o => o.Client == req.client.Client_Code && o.Active == true).OrderBy(o => o.Order).ToList();
                    var fmenu = menu1.Where(o => menu.Contains((int)o.Menu_Id)).ToList();
                    req.session.Menu_Count = 0;

                    if (req.client.Client_Code =="10")
                        res = lang.getlang(enums.sessionstatus.CON, ref req, enums.response.BankCode);
                    else
                    res = lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Menu, Request.newline, useroptions.Menu(ref req, fmenu));
                }
                else {
                    if ((req.session != null)  && (req.client != null))
                        if (req.session.Menu_Count >= req.client.Pin_Retries)
                        {
                            res = lang.getlang(enums.sessionstatus.END, ref req, enums.response.Blocked);
                        }
                        else
                        {
                            req.session.Menu_Count += 1;
                            res = lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Repin, (req.client.Pin_Retries - req.session.Menu_Count));
                        }
                }
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
            return res;
        }
        private string menu(ref Request r)
        {
            try
            {
                var lastsession = r.sessiondetails.OrderByDescending(o => o.Id).FirstOrDefault();
                r.transaction.Client = r.client.Client_Code;
                client.smobile.Url = req.client.Url;
                switch ((enums.Menu)req.session.Menu)
                {
                    #region balance
                    case enums.Menu.Balance:
                        switch ((enums.response)lastsession.Option)
                        {
                            #region Getaccount
                            case enums.response.Menu:
                                r.transaction.Transaction_Type = (int)Transtype.Balance;
                                var accounts = client.Accounts(req.MSISDN);
                                if (accounts.Count() == 0)
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Noaccount);
                                if (accounts.Count() > 1)
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.selectacc, Request.newline, useroptions.accounts(ref req, accounts));
                                else
                                {
                                    r.transaction.Account_No = accounts[0].No;
                                    r.transaction.Account_Name = accounts[0].Name;
                                    goto case enums.response.selectacc;
                                }
                            #endregion
                            #region Show balance
                            case enums.response.selectacc:
                                var selection = useroptions.userselection(r, enums.options.Withacc);
                                if (String.IsNullOrEmpty(r.transaction.Account_No))
                                    r.transaction.Account_No = selection.Acc;

                                double bal = client.Balance(r.transaction.Account_No);
                                if (r.client.Show_bal_for_overdrawan_acc == true)
                                {
                                    client.Trans(ref req);
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.balance, r.transaction.Account_No, bal)
                                   ;
                                }
                                else
                                {
                                    if (bal >= client.Tcharges(0, Transtype.Balance))
                                    {
                                        client.Trans(ref req);
                                        return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.balance, r.transaction.Account_No, bal);
                                    }
                                    else
                                    {
                                        r.transaction.Status = (int)Status.Failed;
                                        r.transaction.Comments = "Insufficcient funds";
                                        return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.insufficientfunds);
                                    }
                                }
                                #endregion
                        }
                        break;
                    #endregion
                    #region Ministatement
                    case enums.Menu.Ministatement:
                        switch ((enums.response)lastsession.Option)
                        {
                            #region Getaccount
                            case enums.response.Menu:
                                r.transaction.Transaction_Type = (int)Transtype.Ministatement;
                                var accounts = client.Accounts(req.MSISDN);
                                if (accounts.Count() == 0)
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Noaccount);
                                if (accounts.Count() > 1)
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.selectacc, Request.newline, useroptions.accounts(ref req, accounts));
                                else
                                {
                                    r.transaction.Account_No = accounts[0].No;
                                    goto case enums.response.selectacc;
                                }
                            #endregion
                            #region Show Ministatement
                            case enums.response.selectacc:
                                var selection = useroptions.userselection(r, enums.options.Withacc);
                                if (String.IsNullOrEmpty(r.transaction.Account_No))
                                    r.transaction.Account_No = selection.Acc;

                                double bal = client.Balance(r.transaction.Account_No);

                                if (r.client.Show_bal_for_overdrawan_acc == true)
                                {
                                    r.transaction.Status = (int)Status.Completed;
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Ministatement, client.ministatement(ref r));
                                }
                                else
                                {
                                    if (bal >= client.Tcharges(0, (Transtype)r.transaction.Transaction_Type))
                                    {
                                        r.transaction.Status = (int)Status.Completed;
                                        return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Ministatement, client.ministatement(ref r));
                                    }
                                    else
                                    {
                                        r.transaction.Status = (int)Status.Failed;
                                        r.transaction.Comments = "Insufficcient funds";
                                        return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.insufficientfunds);
                                    }
                                }
                                #endregion
                        }
                        break;
                    #endregion
                    #region Withdrawal
                    case enums.Menu.Withdrawal:
                        switch ((enums.response)lastsession.Option)
                        {
                            #region Getaccount
                            case enums.response.Menu:
                                r.transaction.Transaction_Type = (int)Transtype.Withdrawal;
                                var accounts = client.Accounts(req.MSISDN);
                                if (accounts.Count() == 0)
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Noaccount);
                                if (accounts.Count() > 1)
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.selectacc, Request.newline, useroptions.accounts(ref req, accounts));
                                else
                                {
                                    r.transaction.Account_No = accounts[0].No;
                                    goto case enums.response.selectacc;
                                }
                            #endregion
                            #region Select Destination
                            case enums.response.selectacc:
                                var selection = useroptions.userselection(r, enums.options.Withacc);
                                if (String.IsNullOrEmpty(r.transaction.Account_No))
                                    r.transaction.Account_No = selection.Acc;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.sendto, Request.newline);
                            #endregion
                            #region Destination
                            case enums.response.sendto:
                                switch (r.Currentoption)
                                {
                                    case "1":
                                        r.transaction.Send_to = r.MSISDN;
                                        return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.amount, Request.newline);

                                    case "2":
                                        return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.otherTelephone, Request.newline);
                                }
                                break;
                            #endregion
                            #region other telephone
                            case enums.response.otherTelephone:
                                r.transaction.Send_to = r.Currentoption;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.amount, Request.newline);

                            #endregion
                            #region amount
                            case enums.response.amount:
                                double amount;
                                if (double.TryParse(r.Currentoption, out amount))
                                    r.transaction.Amount = (decimal)amount;
                                else
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Invalidentry, Request.newline);
                                double bal = client.Balance(r.transaction.Account_No);
                                r.transaction.Charge = (Decimal)((double)r.transaction.Amount + client.Tcharges((double)r.transaction.Amount, Transtype.Withdrawal));

                                if (bal >= (double)r.transaction.Charge)
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.withdrawalconfirm, Request.newline, r.transaction.Amount, r.transaction.Account_No, r.transaction.MSISDN);
                                else
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.insufficientfunds, Request.newline);
                            #endregion
                            #region Confirm
                            case enums.response.withdrawalconfirm:
                                switch (r.Currentoption)
                                {
                                    case "1":
                                        r.transaction.Status = (int)Status.Completed;
                                        client.Trans(ref r);
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.withdrawal, Request.newline);
                                    case "2":
                                        r.transaction.Status = (int)Status.Failed;
                                        r.transaction.Comments = "User cancelled";
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Cancel_cash_Deposit, Request.newline);
                                }
                                break;
                                #endregion
                        }
                        break;
                    #endregion
                    #region Deposits
                    case enums.Menu.Deposits:
                        switch ((enums.response)lastsession.Option)
                        {
                            #region Deposit options
                            case enums.response.Menu:
                                r.transaction.Transaction_Type = (int)Transtype.Deposit;
                                var accounts = client.Accounts(req.MSISDN);
                                if (accounts.Count() == 0)
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Noaccount);

                                List<depositoptions> dd = new List<depositoptions>();
                                depositoptions d = new depositoptions();
                                var loans = client.Loans(req.MSISDN).Where(o => o.Balance > 0 || o.Interest > 0);

                                if (loans.Count() != 0)
                                {
                                    d.no = "Loan";
                                    d.name = "Loans";
                                    d.type = "Loan";
                                    dd.Add(d);
                                }

                                var ma = client.MemberAccounts(accounts[0].memberno);
                                foreach (var m in ma)
                                {
                                    d = new depositoptions();
                                    d.no = m.No;
                                    d.name = m.Name;
                                    d.type = "Account";
                                    dd.Add(d);
                                }
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.selectdeposit, Request.newline, useroptions.Deposits(ref req, dd));

                            #endregion
                            #region Select Accounts
                            case enums.response.selectdeposit:
                                var selection = useroptions.userselection(r, enums.options.deposit);
                                r.transaction.Deposit_type = selection.Type;
                                switch (selection.Type)
                                {
                                    case "Loan":

                                        var loan = client.Loans(req.MSISDN).Where(o => o.Balance > 0 || o.Interest > 0).ToList();
                                        return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.SelectLoans, Request.newline, useroptions.loans(ref req, loan));
                                    default:
                                        r.transaction.Account_No = selection.Acc;
                                        return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.amount, Request.newline);

                                }
                            #endregion
                            #region SelectLoans
                            case enums.response.SelectLoans:
                                var sel = useroptions.userselection(r, enums.options.deposit);
                                r.transaction.Loan = sel.Acc;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.amount, Request.newline);

                            #endregion
                            #region amount
                            case enums.response.amount:
                                double amount;
                                if (double.TryParse(r.Currentoption, out amount))
                                    r.transaction.Amount = (decimal)amount;
                                else
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Invalidentry, Request.newline);
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Depositconfirm, Request.newline, r.transaction.Amount, r.transaction.Deposit_type, r.transaction.Account_No);

                            #endregion
                            #region Confirm
                            case enums.response.Depositconfirm:
                                switch (r.Currentoption)
                                {
                                    case "1":
                                        r.transaction.Status = (int)Status.Completed;
                                        client.Trans(ref r);
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Deposit, Request.newline);
                                    case "2":
                                        r.transaction.Status = (int)Status.Failed;
                                        r.transaction.Comments = "User cancelled";
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.canceldeposit, Request.newline);
                                }
                                break;
                                #endregion
                        }
                        break;
                    #endregion
                    #region Transfer
                    case enums.Menu.Transfer:
                        switch ((enums.response)lastsession.Option)
                        {
                            #region Getaccount
                            case enums.response.Menu:
                                r.transaction.Transaction_Type = (int)Transtype.Transfer_to_Fosa;
                                var accounts = client.Accounts(req.MSISDN);
                                if (accounts.Count() == 0)
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Noaccount);
                                if (accounts.Count() > 1)
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.selectacc, Request.newline, useroptions.accounts(ref req, accounts));
                                else
                                {
                                    r.transaction.Account_No = accounts[0].No;
                                    r.transaction.Member_No = accounts[0].memberno;
                                    goto case enums.response.selectacc;
                                }
                            #endregion
                            #region selected account
                            case enums.response.selectacc:
                                var selection = useroptions.userselection(r, enums.options.Withacc);
                                if (selection != null)
                                {
                                    r.transaction.Account_No = selection.Acc;
                                    r.transaction.Member_No = selection.Type;
                                }
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Transferto, Request.newline);
                            #endregion
                            #region Destination
                            case enums.response.Transferto:
                                switch (r.Currentoption)
                                {
                                    case "1":
                                        r.transaction.Send_to = r.MSISDN;
                                        var ac = r.transaction.Account_No;
                                        var ma = client.MemberAccounts(r.transaction.Member_No).Where(o => o.No != ac).ToList();
                                        return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.selectToacc, Request.newline, useroptions.accounts(ref req, ma, enums.options.ToAccount));
                                    case "2":
                                        return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.otheraccount, Request.newline);
                                }
                                break;
                            #endregion
                            #region other account
                            case enums.response.otheraccount:

                                r.transaction.Account_2 = r.Currentoption;
                                var a = client.Account(r.Currentoption);
                                if (a == null)
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Invalidentry, Request.newline);

                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.amount, Request.newline);

                            #endregion
                            #region other telephone
                            case enums.response.selectToacc:
                                var s = useroptions.userselection(r, enums.options.ToAccount);
                                if (s != null)
                                {
                                    r.transaction.Account_2 = s.Acc;

                                }

                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.amount, Request.newline);

                            #endregion
                            #region amount
                            case enums.response.amount:
                                double amount;
                                if (double.TryParse(r.Currentoption, out amount))
                                    r.transaction.Amount = (decimal)amount;
                                else
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Invalidentry, Request.newline);
                                double bal = client.Balance(r.transaction.Account_No);
                                r.transaction.Charge = (Decimal)((double)r.transaction.Amount + client.Tcharges((double)r.transaction.Amount, Transtype.Withdrawal));

                                if (bal >= (double)r.transaction.Charge)
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Tconfirm, Request.newline, r.transaction.Amount, r.transaction.Account_No, r.transaction.Account_2);
                                else
                                {
                                    r.transaction.Status = (int)Status.Failed;
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.insufficientfunds, Request.newline);
                                }

                            #endregion
                            #region Confirm
                            case enums.response.Tconfirm:
                                switch (r.Currentoption)
                                {
                                    case "1":
                                        r.transaction.Status = (int)Status.Completed;
                                        client.Trans(ref r);
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Transfer, Request.newline);
                                    case "2":
                                        r.transaction.Status = (int)Status.Failed;
                                        r.transaction.Comments = "User cancelled";
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Cancel_cash_Deposit, Request.newline);
                                }
                                break;
                                #endregion
                        }
                        break;
                    #endregion
                    #region Topup
                    case enums.Menu.Topup:
                        switch ((enums.response)lastsession.Option)
                        {
                            #region Getaccount
                            case enums.response.Menu:
                                r.transaction.Transaction_Type = (int)Transtype.Airtime;
                                var accounts = client.Accounts(req.MSISDN);
                                if (accounts.Count() == 0)
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Noaccount);

                                if (accounts.Count() > 1)
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.selectacc, Request.newline, useroptions.accounts(ref req, accounts));
                                else
                                {
                                    r.transaction.Account_No = accounts[0].No;
                                    goto case enums.response.selectacc;
                                }
                            #endregion
                            #region Select Destination
                            case enums.response.selectacc:
                                var selection = useroptions.userselection(r, enums.options.Withacc);
                                if (String.IsNullOrEmpty(r.transaction.Account_No))
                                    r.transaction.Account_No = selection.Acc;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.sendto, Request.newline);
                            #endregion
                            #region Destination
                            case enums.response.sendto:
                                switch (r.Currentoption)
                                {
                                    case "1":
                                        r.transaction.Send_to = r.MSISDN;
                                        return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.amount, Request.newline);

                                    case "2":
                                        return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.otherTelephone, Request.newline);
                                }
                                break;
                            #endregion
                            #region other telephone
                            case enums.response.otherTelephone:
                                r.transaction.Send_to = r.Currentoption;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.amount, Request.newline);
                            #endregion
                            #region amount
                            case enums.response.amount:
                                double amount;
                                if (double.TryParse(r.Currentoption, out amount))
                                    r.transaction.Amount = (decimal)amount;
                                else
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Invalidentry, Request.newline);
                                double bal = client.Balance(r.transaction.Account_No);
                                r.transaction.Charge = (Decimal)((double)r.transaction.Amount + client.Tcharges((double)r.transaction.Amount, Transtype.Withdrawal));

                                if (bal >= (double)r.transaction.Charge)
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Topupconfirm, Request.newline, r.transaction.Amount, r.transaction.Account_No, r.transaction.MSISDN);
                                else
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.insufficientfunds, Request.newline);
                            #endregion
                            #region Confirm
                            case enums.response.Topupconfirm:
                                switch (r.Currentoption)
                                {
                                    case "1":
                                        r.transaction.Status = (int)Status.Completed;
                                        client.Trans(ref r);
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Topup, Request.newline);
                                    case "2":
                                        r.transaction.Status = (int)Status.Failed;
                                        r.transaction.Comments = "User cancelled";
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.canceltopup, Request.newline);
                                }
                                break;
                                #endregion
                        }
                        break;
                    #endregion
                    #region Utility
                    case enums.Menu.utility:
                        switch ((enums.response)lastsession.Option)
                        {
                            #region Getaccount
                            case enums.response.Menu:
                                r.transaction.Transaction_Type = (int)Transtype.Utility_Payment;
                                var accounts = client.Accounts(req.MSISDN);
                                if (accounts.Count() == 0)
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Noaccount);

                                if (accounts.Count() > 1)
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.selectacc, Request.newline, useroptions.accounts(ref req, accounts));
                                else
                                {
                                    r.transaction.Account_No = accounts[0].No;
                                    goto case enums.response.selectacc;
                                }
                            #endregion
                            #region Select Destination
                            case enums.response.selectacc:
                                var selection = useroptions.userselection(r, enums.options.Withacc);
                                if (String.IsNullOrEmpty(r.transaction.Account_No))
                                    r.transaction.Account_No = selection.Acc;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.selectutility, Request.newline, useroptions.utilities(ref req, Request.db.Utilities.ToList()));

                            #endregion

                            #region other telephone
                            case enums.response.selectutility:
                                var sel = useroptions.userselection(r, enums.options.Utility);
                                r.transaction.Send_to = sel.Acc;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.utilityaccount, Request.newline);
                            #endregion

                            #region utility account
                            case enums.response.utilityaccount:
                                r.transaction.Account_2 = r.Currentoption;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.amount, Request.newline);
                            #endregion

                            #region amount
                            case enums.response.amount:
                                double amount;
                                if (double.TryParse(r.Currentoption, out amount))
                                    r.transaction.Amount = (decimal)amount;
                                else
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Invalidentry, Request.newline);

                                double bal = client.Balance(r.transaction.Account_No);
                                r.transaction.Charge = (Decimal)((double)r.transaction.Amount + client.Tcharges((double)r.transaction.Amount, Transtype.Withdrawal));

                                var utility = Convert.ToInt32(r.transaction.Send_to);

                                if (bal >= (double)r.transaction.Charge)
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Utilityconfirm, Request.newline, r.transaction.Amount, r.transaction.Account_No, Request.db.Utilities.FirstOrDefault(o => o.Id == utility).Name);
                                else
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.insufficientfunds, Request.newline);
                            #endregion
                            #region Confirm
                            case enums.response.Utilityconfirm:
                                switch (r.Currentoption)
                                {
                                    case "1":
                                        r.transaction.Status = (int)Status.Completed;
                                        client.Trans(ref r);
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Utility, Request.newline);
                                    case "2":
                                        r.transaction.Status = (int)Status.Failed;
                                        r.transaction.Comments = "User cancelled";
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.cancelUtility, Request.newline);
                                }
                                break;
                                #endregion
                        }
                        break;
                    #endregion
                    #region Pin
                    case enums.Menu.Pin:
                        switch ((enums.response)lastsession.Option)
                        {
                            #region New Pin
                            case enums.response.Menu:
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Newpin, Request.newline);
                            #endregion
                            #region confirm
                            case enums.response.Newpin:
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Confirmpin, Request.newline);
                            #endregion

                            #region change
                            case enums.response.Confirmpin:
                                var tel = r.MSISDN;
                                var logins = Request.db.Logins.FirstOrDefault(o => o.Telephone == tel);
                                if (logins != null)
                                    logins.PIN_Encrypted = r.Currentoption;
                                return lang.getlang(enums.sessionstatus.END, ref req, enums.response.PinChanged, Request.newline);
                                #endregion
                        }
                        break;
                    #endregion
                    #region ELoan
                    case enums.Menu.E_loan:
                        switch ((enums.response)lastsession.Option)
                        {
                            #region Getaccount
                            case enums.response.Menu:
                                r.transaction.Transaction_Type = (int)Transtype.Loan_Application;
                                var accounts = client.Accounts(req.MSISDN);
                                if (accounts.Count() == 0)
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Noaccount);

                                if (accounts.Count() > 1)
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.selectacc, Request.newline, useroptions.accounts(ref req, accounts));
                                else
                                {
                                    r.transaction.Account_No = accounts[0].No;
                                    goto case enums.response.selectacc;
                                }
                            #endregion
                            #region Select Destination
                            case enums.response.selectacc:
                                var selection = useroptions.userselection(r, enums.options.Withacc);
                                if (String.IsNullOrEmpty(r.transaction.Account_No))
                                    r.transaction.Account_No = selection.Acc;
                                double eligible = client.Eligibility(r.transaction.Account_No);
                                r.transaction.Eligibility = eligible;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.loanamount, Request.newline, eligible);
                            #endregion
                            #region Destination
                            case enums.response.loanamount:
                                double amount;
                                if (double.TryParse(r.Currentoption, out amount))
                                    r.transaction.Amount = (decimal)amount;
                                else
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.Invalidentry, Request.newline);
                                if (amount > r.transaction.Eligibility)
                                    return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.invalidloanamount, Request.newline);

                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.loanconfirm, Request.newline, r.transaction.Amount);
                            #endregion
                            #region Confirm
                            case enums.response.withdrawalconfirm:
                                switch (r.Currentoption)
                                {
                                    case "1":
                                        r.transaction.Status = (int)Status.Completed;
                                        client.Trans(ref r);
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Loan);
                                    case "2":
                                        r.transaction.Status = (int)Status.Failed;
                                        r.transaction.Comments = "User cancelled";
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.cancelloan);
                                }
                                break;
                                #endregion
                        }
                        break;
                    #endregion

                    //Agency
                    #region cash Deposit Agency
                    case enums.Menu.Cash_Deposit_agency:
                        switch ((enums.response)lastsession.Option)
                        {

                            case enums.response.Menu:
                                r.transaction.Transaction_Type = (int)Transtype.Cash_Deposit;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.enter_account);
                            case enums.response.enter_account:
                                r.transaction.Account_No = r.Currentoption;
                                r.transaction.Account_Name = "Test Account";
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.enter_amount, r.transaction.Account_Name);
                            case enums.response.enter_amount:
                                r.transaction.Amount = Convert.ToDecimal(r.Currentoption);
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.agency_confirm, r.transaction.Account_No, r.transaction.Account_Name, Request.newline);
                            case enums.response.agency_confirm:
                                switch (r.Currentoption)
                                {
                                    case "1":
                                        r.transaction.Status = (int)Status.Completed;
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.cash_Deposit, Request.newline);
                                    case "2":
                                        r.transaction.Status = (int)Status.Failed;
                                        r.transaction.Comments = "User cancelled";
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Cancel_trans, Request.newline);
                                }
                                break;
                        }
                        break;
                    #endregion
                    #region cash withdrawal Agency
                    case enums.Menu.Cash_withdrawal_agency:
                        switch ((enums.response)lastsession.Option)
                        {
                            case enums.response.Menu:
                                r.transaction.Transaction_Type = (int)Transtype.Cash_Withdrawal_Agency;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.enter_id);

                            case enums.response.enter_id:
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.enter_amount_withdrawal);

                            case enums.response.enter_amount_withdrawal:
                                r.transaction.Amount = Convert.ToDecimal(r.Currentoption);
                                var otp = GenerateRandomPassword(4);
                                sms.sms s = new sms.sms();
                                s.phone = r.MSISDN;
                                s.text = string.Format("Your OTP for cash withdrawal is {0}", otp);
                                s.Smsclient = "10000";
                                s.Sourceid = otp;
                                sms.Service1 client = new sms.Service1();
                                client.Sendsms(s);
                                r.transaction.Account_2 = otp;
                                r.transaction.ID_No = r.Currentoption;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.customerpin);
                            case enums.response.customerpin:

                                r.transaction.ID_No = r.Currentoption;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.customerotp);

                            case enums.response.customerotp:
                                r.transaction.Amount = Convert.ToDecimal(r.Currentoption);
                                if (!r.Currentoption.Equals(r.transaction.Account_2))
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.wrongotp);

                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.agency_withdrawal_confirm, r.transaction.Amount, r.transaction.Account_No, r.transaction.Account_Name, Request.newline);

                            case enums.response.agency_confirm:
                                switch (r.Currentoption)
                                {
                                    case "1":
                                        r.transaction.Status = (int)Status.Completed;
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.cash_withdrawal, Request.newline);
                                    case "2":
                                        r.transaction.Status = (int)Status.Failed;
                                        r.transaction.Comments = "User cancelled";
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Cancel_trans, Request.newline);
                                }
                                break;
                        }
                        break;
                    #endregion
                    #region Bill payment Agency
                    case enums.Menu.Bill_Payment_agency:
                        switch ((enums.response)lastsession.Option)
                        {
                            case enums.response.Menu:
                                r.transaction.Transaction_Type = (int)Transtype.bills_agency;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.enter_id);

                            case enums.response.enter_id:
                                r.transaction.Transaction_Type = (int)Transtype.bills_agency;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.bill_type, Request.newline);

                            case enums.response.bill_type:r.transaction.Account_No = r.Currentoption;
                                r.transaction.Transaction_Type = (int)Transtype.bills_agency;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.bill_account, Request.newline);

                            case enums.response.bill_account:
                                r.transaction.Account_2 = r.Currentoption;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.enter_amount_bill);

                            case enums.response.enter_amount_bill:

                                r.transaction.Amount = Convert.ToDecimal(r.Currentoption);
                                var otp = GenerateRandomPassword(4);
                                
                                sms.Sms s = new sms.Sms();
                                s.phone = r.MSISDN;
                                s.text = string.Format("Your OTP for Bill payment is {0}", otp);
                                s.Smsclient = "10000";
                                s.Sourceid = otp;
                                sms.Sms.Sendsms(ref s);
                                client.Sendsms(s);
                                r.transaction.Account_2 = otp;
                                r.transaction.ID_No = r.Currentoption;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.customerpin);
                            case enums.response.customerpin:

                                r.transaction.ID_No = r.Currentoption;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.customerotp);

                            case enums.response.customerotp:
                                r.transaction.Amount = Convert.ToDecimal(r.Currentoption);
                                if (!r.Currentoption.Equals(r.transaction.Account_2))
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.wrongotp);

                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.agency_bills_confirm, r.transaction.Amount, r.transaction.Account_No, r.transaction.Account_Name, Request.newline);

                            case enums.response.agency_bills_confirm:
                                switch (r.Currentoption)
                                {
                                    case "1":
                                        r.transaction.Status = (int)Status.Completed;
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.cash_withdrawal, Request.newline);
                                    case "2":
                                        r.transaction.Status = (int)Status.Failed;
                                        r.transaction.Comments = "User cancelled";
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Cancel_trans, Request.newline);
                                }
                                break;
                        }
                        break;
                    #endregion
                    #region Bill Transfer Agency
                    case enums.Menu.Fund_Transfer_agency:
                        switch ((enums.response)lastsession.Option)
                        {
                            case enums.response.Menu:
                                r.transaction.Transaction_Type = (int)Transtype.bills_agency;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.enter_id);

                            case enums.response.enter_id:
                                r.transaction.Account_No = r.Currentoption;
                                r.transaction.Transaction_Type = (int)Transtype.Transfer_agency;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.enter_account_to, Request.newline);

                            case enums.response.enter_account_to:
                                r.transaction.Account_2 = r.Currentoption;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.enter_amount_transfer);

                            case enums.response.enter_amount_transfer:
                                r.transaction.Amount = Convert.ToDecimal(r.Currentoption);
                                var otp = GenerateRandomPassword(4);
                                
                                sms.sms s = new sms.sms();
                                s.phone = r.MSISDN;
                                s.text = string.Format("Your OTP for transfer is {0}", otp);
                                s.Smsclient = "10000";
                                s.Sourceid = otp;
                                sms.Service1 client = new sms.Service1();
                                client.Sendsms(s);
                                r.transaction.Account_2 = otp;
                                r.transaction.ID_No = r.Currentoption;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.customerpin);
                            case enums.response.customerpin:

                                r.transaction.ID_No = r.Currentoption;
                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.customerotp);

                            case enums.response.customerotp:
                                r.transaction.Amount = Convert.ToDecimal(r.Currentoption);
                                if (!r.Currentoption.Equals(r.transaction.Account_2))
                                    return lang.getlang(enums.sessionstatus.END, ref req, enums.response.wrongotp);

                                return lang.getlang(enums.sessionstatus.CON, ref req, enums.response.agency_transfer_confirm, r.transaction.Amount, r.transaction.Account_No, r.transaction.Account_Name, Request.newline,r.transaction.Account_2);

                            case enums.response.agency_transfer_confirm:
                                switch (r.Currentoption)
                                {
                                    case "1":
                                        r.transaction.Status = (int)Status.Completed;
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.cash_withdrawal, Request.newline);
                                    case "2":
                                        r.transaction.Status = (int)Status.Failed;
                                        r.transaction.Comments = "User cancelled";
                                        return lang.getlang(enums.sessionstatus.END, ref req, enums.response.Cancel_trans, Request.newline);
                                }
                                break;
                        }
                        break;
                        #endregion
                }
            }
            catch (Exception ex)
            {
                r.transaction.Status = (int)Status.Failed;
                r.transaction.Comments = ex.Message;
                Logging.Logging.ReportError(ex);
            }
            return res;
        }
        private string chooseclient(ref List<Customer> customer)
        {

            return "";
        }
        public static string GenerateRandomPassword(int passwordLength)
        {
            string allowedChars = "123456789";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
    public partial class MobileEntities : DbContext
    {
        public MobileEntities(string Connectionstring)
           : base(Connectionstring)
        {
        }
    }
    public class settings
    {
        public string Serverip = string.Empty;
        public string domain = string.Empty;
        public string Instance = string.Empty;
        public string Database = string.Empty;
        public int Port = 0;
        public string Username = string.Empty;
        public string pass = string.Empty;
        public string Companyname = string.Empty;
        public int PostIntervalinsec = 2;
        public int Reconnectintervalinsec = 10;
        public string logpath = string.Empty;
        public Boolean usewindowsauth = true;
        public string certpath = string.Empty;
        public bool IntegratedSecurity = false;
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
}