using Client.Transactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Client
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    //[XmlSerializerFormat]
    public interface Mobile
    {
      
        [OperationContract]
        Results Tstatus(string documentNo);
        [OperationContract]
        eligibility Eligibility(string phone, Transactions.Loan_Type loantype);
        [OperationContract]
               Member.Member member(string acc);
        [OperationContract]
             List<Accounts.Accounts> Memberaccounts(string tel);
        [OperationContract]
   
        Trans Transaction(Trans t);
        [OperationContract]
        [XmlSerializerFormat]
        List<Sms.Sms> sendsms(List<Sms.Sms> smses);
        //[OperationContract]
        //List<Sms.Sms> SmsUpdate(List<Sms.Sms> s);
        [OperationContract]
        [XmlSerializerFormat]
        double Bal(string acc);
        [OperationContract]
        List<S_Applications.Applications> Registration();

        [OperationContract]
        List<Loans.Loans> CustomerLoans(string telephone);

        [OperationContract]
        List<Accounts.Accounts> Accounts(string tel);

        [OperationContract]
        Accounts.Accounts Account(string tel);

        [OperationContract]
        List<Accounts.Accounts> Accountsbyid(string id);
        [OperationContract]
        List<Accounts.Accounts> ChildAccounts(string no);
    }
// Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    [DataContract]
    public class Results
    {[DataMember]
        public int code = 0;
        [DataMember]
        public string error_Desc;
    }
    [DataContract]
    public class Trans : Results
    {
        [XmlIgnore]
        public static Transactions_Service trservice = new Transactions_Service();
        [XmlIgnore]
        public static Statement.Account_Entries_Service Accentriesservice = new Statement.Account_Entries_Service();
        [XmlIgnore]
        public static Accounts.Accounts_Service Accservice = new Accounts.Accounts_Service();
        [XmlIgnore]
        public static S_Mobile.S_Mobile s_mobile = new S_Mobile.S_Mobile();
        [XmlIgnore]
        public static AccountTypes.Account_Types_Service account_Types_Service = new AccountTypes.Account_Types_Service();
        [XmlIgnore]
        public static Setup.Setup_Service setupservice = new Setup.Setup_Service();
        [XmlIgnore]
        public static Setup.Setup setup;
        [XmlIgnore]
        public int Entry;
        [DataMember]
        public string Account_No = string.Empty;
        [DataMember]
        public string Account_Name;
        [DataMember]
        public string Document_No = string.Empty;
        [DataMember]
        public System.DateTime Document_Date = DateTime.Now.Date;
        [DataMember(EmitDefaultValue = true)]
        public System.DateTime Transaction_Time = DateTime.Now;
        [DataMember]
        public int Transaction_Type = -1;
        [DataMember]
        public string Telephone_Number = string.Empty;
        [DataMember]
        public string Account_2 = string.Empty;
        [XmlIgnore]
        public Transactions.Status Status = Transactions.Status.Pending;
        [DataMember]
        public string Comments;
        [DataMember]
        public decimal Amount = 0;
        [DataMember]
        public decimal Charge = 0;
        [DataMember]
        public string Description = string.Empty;
        [XmlIgnore]
        public string Client;
        [DataMember]
        public List<Ministatement> Mini = null;
        [DataMember]
        public decimal AccountBalance = 0;
        [DataMember]
        public List<loan> LoanBalances = null;
        [DataMember]
        public List<loan> LoanStatus = null;
        [DataMember]
        public List<Members.deposits> sharedepositbalance;
        [DataMember]
        public int statement_size = 5;
        [DataMember]
        public string Loan_No;
        [DataMember]
        public Transactions.Loan_Type loantype;
        [DataMember]
        public Source source;
        [DataMember]
        public Destination destination;
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Qualified), MessageBodyMember]
        [DataMember]
        public string Receipt_No { get; set; }
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
            Stop_Atm = 17,
            Confirm = 18,
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
            Transactions.Transactions tr = null;
            try
            {
                Logging.Logging.LogEntryOnFile(((Transaction_Type)t.Transaction_Type).ToString());
                //switch ((Transaction_Type)t.Transaction_Type)
                //{
                //    case Transactions.Transaction_Type.Confirm:
                //        trs = trservice.ReadMultiple(new Transactions_Filter[] { new Transactions_Filter { Criteria = t.Document_No, Field = Transactions_Fields.Document_No },
                //            new Transactions_Filter { Criteria = "Pending", Field = Transactions_Fields.Status },
                //            new Transactions_Filter { Criteria = "Withdrawal", Field = Transactions_Fields.Transaction_Type } }, null, 1);

                //        if (trs.Count() == 0)
                //            t.code = 21;
                //        else
                //        {
                //            if (string.IsNullOrEmpty(t.Receipt_No))
                //            {
                //                t.code = 20;
                //                return t;
                //            }
                //            tr = trs[0];
                //            tr.Document_No = t.Receipt_No;
                //            tr.Receipt_No = t.Document_No;
                //            tr.Transaction_Type = (Transaction_Type)t.Transaction_Type;
                //            tr.Transaction_TypeSpecified = true;
                //            trservice.Create(ref tr);
                //        }


                //        break;
                //    default:
                if (t.Transaction_Type == 18)
                {
                    var doc = t.Document_No;

                    t.Document_No = t.Receipt_No;
                    t.Receipt_No = doc;
                }

                        trs = trservice.ReadMultiple(new Transactions_Filter[] { new Transactions_Filter { Criteria = t.Document_No, Field = Transactions_Fields.Document_No }, new Transactions_Filter { Criteria = "Completed|Pending", Field = Transactions_Fields.Status }, new Transactions_Filter { Criteria = t.Transaction_Type.ToString(), Field = Transactions_Fields.Transaction_Type } }, null, 1);
                        if (trs.Count() == 0)
                        {
                            tr = new Transactions.Transactions();
                            tr.Account_No = t.Account_No;
                            tr.Account_Name = t.Account_Name;
                            tr.Document_No = t.Document_No;
                            tr.Document_Date = t.Document_Date;
                            tr.Document_DateSpecified = true;
                            tr.Date_PostedSpecified = true;
                            t.Transaction_Time = DateTime.Now;
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
                            tr.Source = t.source;
                            tr.SourceSpecified = true;
                            tr.Destination = t.destination;
                            tr.DestinationSpecified = true;
                            tr.Comments = t.Comments;
                            tr.Loan_Type = t.loantype;
                            tr.Loan_TypeSpecified = true;
                            tr.Receipt_No = t.Receipt_No;
                            trservice.Create(ref tr);
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
                                    t.sharedepositbalance = new Members().depositbalance(t.Account_No);
                                    break;
                                case Trans_Type.Loan_Status:
                                    loan.Loanstatus(ref t);
                                    if (t.LoanStatus.Count() == 0)
                                        t.code = 13;
                                    break;

                                case Trans_Type.Loan_Application:
                                    try
                                    {
                                        var amount = s_mobile.LoanEligibility(t.Telephone_Number, (int)t.loantype);

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
                        else
                        {
                            t.code = 10;

                        }
                //        break;

                //}
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
                        if (tr != null)
                        {
                            tr.Status = Transactions.Status.Failed;
                            tr.Comments = t.error_Desc;
                            t.Status = Transactions.Status.Failed;
                        }
                    }


                    if (tr != null)
                    {
                    
                        trservice.Update(ref tr);
                     
                    }
                    try
                    {
                        s_mobile.Post();
                    }
                    catch (Exception ex) { Logging.Logging.ReportError(ex); }




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
                //Logging.Logging.LogEntryOnFile(t.Account_No);
                Accounts.Accounts a = Getaccount(t.Account_No);

                Members.member = Members.getmember(a.BOSA_Account_No);
                //Logging.Logging.LogEntryOnFile(t.Transaction_Type.ToString());
                if (a == null)
                {
                    t.code = 1;
                    return;
                }
                t.Account_Name = a.Name;
                //Logging.Logging.LogEntryOnFile(t.Transaction_Type.ToString());
                if (a.Status != Accounts.Status.Active)
                {
                    t.code = 2;
                    return;
                }
                //Logging.Logging.LogEntryOnFile(t.Transaction_Type.ToString());
                if (a.Blocked != Accounts.Blocked._blank_)
                {
                    t.code = 3;
                    return;
                }
                //Logging.Logging.LogEntryOnFile(t.Transaction_Type.ToString());
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
                            if (t.source == Source.Fosa)
                                if ((Balance(t.Account_No) < (double)(t.Amount + t.Charge + Tcharges((Trans_Type)t.Transaction_Type, t.Amount))))
                                {
                                    t.code = 4;
                                    return;
                                }
                            break;
                        }
                }
                switch ((Trans_Type)t.Transaction_Type)
                {
                    case Trans_Type.Airtime:
                    case Trans_Type.Utility_Payment:
                    case Trans_Type.Withdrawal:
                        if (t.source != Source.Fosa)
                        {
                            t.code = 17;
                            return;
                        }
                        break;
                    default:
                        {

                            break;
                        }
                }

                //Logging.Logging.LogEntryOnFile(t.Transaction_Type.ToString());
                switch ((Trans_Type)t.Transaction_Type)
                {

                    case Trans_Type.Loan_Repayment:
                        try
                        {
                            if (string.IsNullOrEmpty(t.Loan_No))
                            { t.code = 16; return; }
                        }
                        catch (Exception ex)
                        {
                            Logging.Logging.ReportError(ex);
                        }
                        break;
                    case Trans_Type.Withdrawal:
                        try
                        {
                            if (Dailyamount(t.Account_No, Trans_Type.Withdrawal.ToString()) > setup.Max_Daily_limit)
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
                case Trans_Type.Transfer_to_Fosa:
                    switch (t.destination)
                    {
                        case Destination.Fosa:
                            if (string.IsNullOrEmpty(t.Account_2))
                            {
                                t.code = 8;
                                return;
                            }

                            break;
                        default:
                            break;
                    }
                    break;
                case Trans_Type.Confirm:
                    if (string.IsNullOrEmpty(t.Receipt_No))
                    {
                        t.code = 20;
                        return;
                    }
                    var w = trservice.ReadMultiple(new Transactions_Filter[] { new Transactions_Filter { Criteria = t.Document_No, Field = Transactions_Fields.Document_No }, new Transactions_Filter { Criteria = "Withdrawal", Field = Transactions_Fields.Transaction_Type } }, null, 1);
                    if (w == null)
                    {
                        t.code = 21;
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
                if (acc.Count()==0)
                    acc = Accservice.ReadMultiple(new Accounts.Accounts_Filter[] { new Accounts.Accounts_Filter { Criteria = tel, Field = Accounts.Accounts_Fields.Mobile_Phone_No } }, null, 1000).ToList();
                if (acc.Count() == 0)
                    acc = Accservice.ReadMultiple(new Accounts.Accounts_Filter[] { new Accounts.Accounts_Filter { Criteria = tel, Field = Accounts.Accounts_Fields.Phone_No } }, null, 1000).ToList();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return acc;
        }
        public static List<Accounts.Accounts> Getaccountsbyid(string id)
        {
            List<Accounts.Accounts> acc = new List<Accounts.Accounts>();
            try
            {
                acc = Accservice.ReadMultiple(new Accounts.Accounts_Filter[] { new Accounts.Accounts_Filter { Criteria = id, Field = Accounts.Accounts_Fields.ID_No } }, null, 1000).ToList();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return acc;
        }
        public static List<Accounts.Accounts> Getchilda(string no)
        {
            List<Accounts.Accounts> acc = new List<Accounts.Accounts>();
            try
            {
                var ac = Accservice.Read(no);
                if (ac != null)
                    acc = Accservice.ReadMultiple(new Accounts.Accounts_Filter[] { new Accounts.Accounts_Filter { Criteria = ac.ID_No, Field = Accounts.Accounts_Fields.ID_No }, new Accounts.Accounts_Filter { Criteria = "CHILDA", Field = Accounts.Accounts_Fields.Account_Type } }, null, 1000).ToList();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return acc;
        }
        public static List<Accounts.Accounts> Getmemberaccounts(string memberno)
        {
            List<Accounts.Accounts> acc = new List<Accounts.Accounts>();
            try
            {
                acc = Accservice.ReadMultiple(new Accounts.Accounts_Filter[] { new Accounts.Accounts_Filter { Criteria = memberno, Field = Accounts.Accounts_Fields.No } }, null, 1000).ToList();
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
}
