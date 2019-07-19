// Decompiled with JetBrains decompiler
// Type: M_SACCO_Webservice.Mobile
// Assembly: M-SACCO Webservice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F0157AEC-175E-4D5E-A397-15B9A7805B87
// Assembly location: D:\M-Sacco\Bandari\M-SACCO Webservice.dll

using M_SACCO_Webservice.NavisionWebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Web.Script.Services;
using System.Web.Services;

namespace M_SACCO_Webservice
{
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [WebService(Namespace = "http://tempuri.org/")]
    public class Mobile : WebService
    {
        private Results results = new Results();
        private ServerSetting ss = new ServerSetting();
        private MSACCO Msacco = new MSACCO();
        private NetworkCredential cd;

        public Mobile()
        {
            this.ss.getsettings(this.Server.MapPath("~/Settings.txt"));
            this.cd = new NetworkCredential(this.ss.user, this.ss.pass, this.ss.domain);
            this.Msacco.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/MSACCO", (object)this.ss.server, (object)this.ss.Companyname, (object)this.ss.Instance, (object)this.ss.Port);
            this.Msacco.PreAuthenticate = true;
            this.Msacco.Credentials = (ICredentials)this.cd;
        }

        private string gettime()
        {
            return "1754-01-01 " + DateTime.Now.ToString("HH:mm:ss tt");
        }

        [WebMethod]
        public Results AccountName(string Account)
        {
            try
            {
                this.results.ResultsData = (object)this.Msacco.AccountName(Account);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public Results BalanceEnquiryfull(string Phone, string Ref)
        {
            try
            {
                Phone = Phone.Replace("+", "");
                this.results.ResultsData = (object)this.Msacco.BalanceEnquiry(ref Phone, Ref);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public List<loans> Getloans(string Phone)
        {
            List<loans> loansList = new List<loans>();
            try
            {
                Phone = Phone.Replace("+", "");
                try
                {
                    string str1 = this.Msacco.Loanbalances(Phone);
                    char[] separator1 = new char[1] { '|' };
                    int num1 = 1;
                    foreach (string str2 in str1.Split(separator1, (StringSplitOptions)num1))
                    {
                        char[] separator2 = new char[1] { ';' };
                        int num2 = 0;
                        string[] strArray = str2.Split(separator2, (StringSplitOptions)num2);
                        loansList.Add(new loans()
                        {
                            loan_No = strArray[0],
                            Loan_Type = strArray[1],
                            loan_Balance = Convert.ToDouble(strArray[2])
                        });
                    }
                }
                catch (Exception ex)
                {
                    loansList.Add(new loans()
                    {
                        Hasresults = false,
                        Errors = ex.Message
                    });
                }
                this.results.ResultsData = (object)loansList;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return loansList;
        }

        [WebMethod]
        public List<loans> LoanStatus(string Phone)
        {
            List<loans> loansList = new List<loans>();
            try
            {
                Phone = Phone.Replace("+", "");
                try
                {
                    string str1 = this.Msacco.LoanStatus(Phone);
                    char[] separator1 = new char[1] { '|' };
                    int num1 = 1;
                    foreach (string str2 in str1.Split(separator1, (StringSplitOptions)num1))
                    {
                        char[] separator2 = new char[1] { ';' };
                        int num2 = 0;
                        string[] strArray = str2.Split(separator2, (StringSplitOptions)num2);
                        loansList.Add(new loans()
                        {
                            loan_No = strArray[0],
                            Loan_Type = strArray[1],
                            loan_Balance = Convert.ToDouble(strArray[2]),
                            Interest = Convert.ToDouble(strArray[3])
                        });
                    }
                }
                catch (Exception ex)
                {
                    loansList.Add(new loans()
                    {
                        Hasresults = false,
                        Errors = ex.Message
                    });
                }
                this.results.ResultsData = (object)loansList;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return loansList;
        }

        [WebMethod]
        public Results Ministatement(string Account, string Ref)
        {
            try
            {
                this.results.ResultsData = (object)this.Msacco.Ministatement(Account, Ref);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public Results AccountBalance(string account)
        {
            try
            {
                this.results.ResultsData = (object)Convert.ToDouble(this.Msacco.AccountBalance(account));
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public Results WithRequest(string phone, string Traceid, string AccountNo, Decimal Amount)
        {
            try
            {
                phone = phone.Replace("+", "");
                this.results.ResultsData = (object)this.Msacco.InsertToBuffer(AccountNo, Amount, Traceid, phone);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public loans PayLoan(loans loan)
        {
            try
            {
                loan.results = this.Msacco.PayLoan(loan.loan_No, loan.Amount, loan.account.Account_No, loan.Document_No);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                loan.Hasresults = false;
                loan.Errors = ex.Message;
            }
            return loan;
        }

        [WebMethod]
        public Transfers transfer(Transfers trans)
        {
            try
            {
                trans.Results = this.Msacco.Transfer(trans.From_Account, trans.To_Account, trans.Amount, trans.Reference, (int)trans.ttype);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                trans.Hasresults = false;
                trans.Errors = ex.Message;
            }
            return trans;
        }

        [WebMethod]
        public Results WithConfirm(string recieptno, string description, string phone, string transactiontype, string AccountNo, Decimal Amount, string otherinfo)
        {

            try
            {
                transtype t = transtype.Blank_;

                switch (transactiontype)
                {
                    case "withdrawal":
                        t = transtype.Withdrawal;
                        break;
                }
                this.results.ResultsData = (object)this.Msacco.Inserttojournal(recieptno,(int)t, description, DateTime.Now, AccountNo, Amount, otherinfo, phone);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public Results WithDecline(string Traceid)
        {
            try
            {
                this.results.ResultsData = (object)this.Msacco.Decline(Traceid);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public List<Accounts> Getaccount(string Phone)
        {
            List<Accounts> accountsList = new List<Accounts>();
            try
            {
                Phone = Phone.Replace("+", "");
                string str1 = this.Msacco.Accounts(Phone);
                char[] separator1 = new char[1] { '~' };
                int num1 = 1;
                foreach (string str2 in str1.Split(separator1, (StringSplitOptions)num1))
                {
                    char[] separator2 = new char[1] { '|' };
                    int num2 = 0;
                    string[] strArray = str2.Split(separator2, (StringSplitOptions)num2);
                    accountsList.Add(new Accounts()
                    {
                        Account_No = strArray[0],
                        Account_Name = strArray[1],
                        Staff_No = strArray[2]
                    });
                }
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
            }
            return accountsList;
        }

        public Results account(string Phone)
        {
            try
            {
                Phone = Phone.Replace("+", "");
                this.results.ResultsData = (object)this.Msacco.Accounts(Phone);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public Results Deposit(string recieptno, string description, string phone, string transactiontype, string AccountNo, Decimal Amount, string otherinfo)
        {
            try
            {
                transtype t = transtype.Blank_;

                switch (transactiontype)
                {
                    case "deposit":
                        t = transtype.Deposit;
                        break;
                }
                this.results.ResultsData = (object)this.Msacco.Inserttojournal(recieptno,(int)t, description, DateTime.Now, AccountNo, Amount, otherinfo, phone);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public loans Advance(loans loan)
        {
            try
            {
                int num = this.Msacco.Advance(loan.Document_No, loan.account.Account_No, loan.Amount);
                loan.results = num.ToString();
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                loan.Hasresults = false;
                loan.Errors = ex.Message;
            }
            return loan;
        }

        [WebMethod]
        public List<Applications> NewRegistrations()
        {
            List<Applications> applicationsList = new List<Applications>();
            try
            {
                string str = this.Msacco.NewRegistration();
                char[] separator = new char[1] { '|' };
                int num = 1;
                foreach (string clientRequest in str.Split(separator, (StringSplitOptions)num))
                {
                    CUtilities.LogEntryOnFile(clientRequest);
                    string[] strArray = clientRequest.Split(new char[1]
          {
            '~'
          }, StringSplitOptions.None);
                    applicationsList.Add(new Applications()
                    {
                        Telephone = strArray[0]
                    });
                }
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                applicationsList.Add(new Applications()
                {
                    Hasresults = false,
                    Errors = ex.Message
                });
            }
            return applicationsList;
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public List<BulkSms> Sms()
        {
            List<BulkSms> bulkSmsList = new List<BulkSms>();
            try
            {
                string empty = string.Empty;
                int num = 1;
                for (string str = this.Msacco.Sms(); str != ""; str = this.Msacco.Sms())
                {
                    string[] strArray = str.Split(new char[1] { '~' }, StringSplitOptions.None);
                    bulkSmsList.Add(new BulkSms()
                    {
                        EntryNo = Convert.ToInt32(strArray[0]),
                        Phone = strArray[1],
                        Text = strArray[2]
                    });
                    ++num;
                    if (num > 300)
                        break;
                }
                this.results.ResultsData = (object)bulkSmsList;
            }
            catch (Exception ex)
            {
                BulkSms bulkSms = new BulkSms();
                bulkSms.Hasresults = false;
                bulkSms.Errors = ex.Message;
                CUtilities.LogEntryOnFile(ex.Message);
                bulkSmsList.Add(bulkSms);
            }
            return bulkSmsList;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<BulkSms> GetSms(int smsCount)
        {
            List<BulkSms> l = new List<BulkSms>();

            try
            {

                try
                {
                    string[] Results = Msacco.GetSms(smsCount).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var msg in Results)
                    {
                        string[] message = msg.Split(new char[] { '|' }, StringSplitOptions.None);
                        if ((message[0] == "0") && (message[3].Trim().Length >= 9) && (message[4].Trim().Length > 0))
                        {
                            BulkSms ll = new BulkSms();
                            ll.status = message[0];
                            ll.StatusDescription = message[1];

                            ll.EntryNo = Convert.ToInt32(message[2]);
                            ll.Phone = message[3];
                            ll.Text = message[4];

                            ll.Source = message[5];
                            ll.DateCreated = message[6]; // DateTime.Today.ToString("dd-MM-yyyy");
                            ll.TimeCreated = message[7]; // DateTime.Today.ToString("dd-MM-yyyy HH:mm:ss");


                            l.Add(ll);
                        }
                    }
                }
                catch (Exception ex)
                {
                    BulkSms ll = new BulkSms();
                    ll.Hasresults = false;
                    ll.status = "1";
                    ll.StatusDescription = ex.ToString();
                    ll.Errors = ex.Message;
                    l.Add(ll);
                }
                results.ResultsData = l;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }

            return l;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<BulkSms> Smsupdate(List<BulkSms> bulk)
        {
            string empty = string.Empty;
            try
            {
                foreach (BulkSms bulkSms in bulk)
                {
                    try
                    {
                        bulkSms.updated = this.Msacco.Smsupdate(bulkSms.EntryNo, bulkSms.status, bulkSms.balance);
                    }
                    catch (Exception ex)
                    {
                        bulkSms.Hasresults = false;
                        bulkSms.Errors = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
            }
            return bulk;
        }

        [WebMethod]
        public void PinRequest()
        {
        }

        [WebMethod]
        public Results Balancecharge()
        {
            try
            {
                this.results.ResultsData = (object)this.Msacco.Balcharge();
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public Results Ministatementcharge()
        {
            try
            {
                this.results.ResultsData = (object)this.Msacco.Minicharge();
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public Results Transfercharge()
        {
            try
            {
                this.results.ResultsData = (object)this.Msacco.Transfercharge();
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public Results Msaccocharge()
        {
            try
            {
                this.results.ResultsData = (object)this.Msacco.Msacocharge();
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public List<Advance> MaximumSalaryAdvance(string Phone, int NoOfMonths)
        {
            List<Advance> advanceList = new List<Advance>();
            this.results.ResultsData = (object)advanceList;
            return advanceList;
        }

        [WebMethod]
        public Results UtilityPayments(string recieptno, string description, string phone, string transactiontype, string AccountNo, Decimal Amount, string otherinfo)
        {
            try
            {
                transtype t = transtype.Blank_;

                switch (transactiontype)
                {
                    case "UtilityPayment":
                        t = transtype.Utility_Payment;
                        break;
                }
                this.results.ResultsData = (object)this.Msacco.UtilityPayment(recieptno,(int)t, description, DateTime.Now, AccountNo, Amount, otherinfo);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public loans LoanRequest(loans loan)
        {
            try
            {
                int num = this.Msacco.Advance(loan.Document_No, loan.account.Account_No, loan.Amount);
                loan.results = num.ToString();
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                loan.Hasresults = false;
                loan.Errors = ex.Message;
            }
            return loan;
        }

        [WebMethod]
        public Results CallManualFunctions()
        {
            try
            {
                this.results.ResultsData = (object)this.Msacco.CallManualFunctions();
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public Results CallExecutionFunction(int functionId)
        {
            try
            {
                string Results = Msacco.CallExecuteFunction(functionId);
                results.ResultsData = Results;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                results.Hasresults = false;
                results.ResultErros = ex.Message;
            }
            return results;

        }

        [WebMethod]
        public Results MsaccoOtherServices(string TraceId, string AccountNo, string phone, string transactiontype, string ChequeLeafFrom, string ChequeLeafTo)
        {
            try
            {
                this.results.ResultsData = (object)this.Msacco.InsertMsaccoOtherServices(TraceId, AccountNo, phone, transactiontype, ChequeLeafFrom, ChequeLeafTo, DateTime.Now);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public Results CreateGuarantors(string TraceId, string GuarontorTelephoneNo, string ApplicantTelephoneNo)
        {
            return this.results;
        }

        [WebMethod]
        public Results GetBOSANumber(string Phone)
        {
            try
            {
                Phone = Phone.Replace("+", "");
                this.results.ResultsData = (object)this.Msacco.GetBOSANumber(Phone);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }

        [WebMethod]
        public Results TransferToAccountName(string Phone, string AccountNumberTo)
        {
            try
            {
                Phone = Phone.Replace("+", "");
                this.results.ResultsData = (object)this.Msacco.TransferToAccountName(AccountNumberTo, Phone);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                this.results.ResultErros = ex.Message;
            }
            return this.results;
        }
        [WebMethod]
        public DCSAcountDetails.DCSAccountDetails GetAccountDetails(string Phone)
        {
            try
            {
                Phone = '+' + Phone.Replace("+", "");
                DCSAcountDetails.DCSAccountDetails_Service dCSAccountDetails_Service = new DCSAcountDetails.DCSAccountDetails_Service();
                dCSAccountDetails_Service.Credentials = Msacco.Credentials;
                dCSAccountDetails_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/DCSAccountDetails", (object)this.ss.server, (object)this.ss.Companyname, (object)this.ss.Instance, (object)this.ss.Port);
                DCSAcountDetails.DCSAccountDetails dCSAccountDetails = dCSAccountDetails_Service.ReadMultiple(
                    new DCSAcountDetails.DCSAccountDetails_Filter[1]
                    {
                        new DCSAcountDetails.DCSAccountDetails_Filter { Field = DCSAcountDetails.DCSAccountDetails_Fields.MPESA_Mobile_No, Criteria=Phone }
                    },
                    null, 1)[0];
                return dCSAccountDetails;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                this.results.Hasresults = false;
                return null;
            }


        }
    }
}
