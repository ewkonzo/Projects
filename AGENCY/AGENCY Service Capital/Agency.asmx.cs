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
using AGENCY.Data;
namespace AGENCY
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Agency : System.Web.Services.WebService
    {
        SaccoData Db;
        public static string path;
        Sms sms = new Sms();
                public Agency()
        {
            path = Server.MapPath("~/Settings.txt");
            ServerSetting.getsettings(Agency.path);
           

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Getsocieties()
        {
            String response = string.Empty; 
            try
            {
                          
                response = new JavaScriptSerializer().Serialize(Societies.GetSocieties());
            }
            catch (Exception ex)
            {
                          response = new JavaScriptSerializer().Serialize(response);
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            Context.Response.Output.Write(response);

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Member(string login)
        {
            String response = string.Empty;
            Member member = null;
            try
            {
                member = JsonConvert.DeserializeObject<Member>(login);
                using (var db = new Data.AGENCYEntities())
                {
                    var a = db.Agency_Members.FirstOrDefault(b => b.ID_No == member.id_no);
                    if (a != null)
                    {
                        member.pin = a.Pin;
                        member.pin_changed =  (Boolean)a.Pin_Changed;
                    }
                    response = new JavaScriptSerializer().Serialize(member);
                }
            }
            catch (Exception ex)
            {

                response = new JavaScriptSerializer().Serialize(member);
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            Context.Response.Output.Write(response);

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Login(string login)
        {
            String response = string.Empty; 
            Agent agent = null;
            try
            {
                CUtilities.LogEntryOnFile(login);
                agent = JsonConvert.DeserializeObject<Agent>(login);
                using (var db = new Data.AGENCYEntities())
                {
                    CUtilities.LogEntryOnFile(agent.agent_code);
CUtilities.LogEntryOnFile(agent.pin);
                    var a = db.Agents.FirstOrDefault(b => b.Agent_Code == agent.agent_code && b.Password == agent.pin);
                    if (a != null)
                    {
                        if ((bool)a.Active)
                        {
                            agent.logged_in = true;
                            agent.agent_Name = a.Name;
                            agent.agent_code = a.Agent_Code;
                            agent.Telephone = a.Telephone;
                            agent.Pin_changed = (bool)a.Password_Changed;

                        }
                        else
                        {
                            agent.logged_in = false;
                            agent.message = "Account is not active";
                        }
                    }
                    else
                    {
                        agent.logged_in = false;
                        agent.message = "Invalid Agent code or Pin.";
                    }
                  
                }
                response = new JavaScriptSerializer().Serialize(agent);
            }
            catch (Exception ex)
            {
                agent.logged_in = false;
                agent.message = ex.Message;
                response = new JavaScriptSerializer().Serialize(agent);
                CUtilities.LogEntryOnFile(ex.Message);
                if (ex.InnerException != null)
                    CUtilities.LogEntryOnFile(ex.InnerException.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            Context.Response.Output.Write(response);

        }[WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Changepin(string data)
        {
            String response = string.Empty;
            Transaction tr = null;
            try
            {
         
                tr = JsonConvert.DeserializeObject<Transaction>(data);
                using (var db = new Data.AGENCYEntities())
                {
                    var a = db.Agency_Members.FirstOrDefault(b => b.ID_No == tr.member_1.id_no );
                    if (a != null)
                    {

                        a.Pin = tr.newpin;
                        a.Pin_Changed = true;
                        db.SaveChanges();
                        tr.member_1.pin_changed = (bool)a.Pin_Changed;
                        tr.status = Transaction.Status.Successful;
                    }
                    else
                    {
                        tr.status = Transaction.Status.Failed;
                        tr.message = "Invalid ID_No";
                    }
                        
                   
                }
                response = new JavaScriptSerializer().Serialize(tr);
            }
            catch (Exception ex)
            {               
                response = new JavaScriptSerializer().Serialize(tr);
                CUtilities.LogEntryOnFile(ex.Message);
                if (ex.InnerException != null)
                    CUtilities.LogEntryOnFile(ex.InnerException.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            Context.Response.Output.Write(response);

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Changepass(string login)
        {
            String response = string.Empty;
            Agent agent = null;
            try
            {
                CUtilities.LogEntryOnFile(login);
                agent = JsonConvert.DeserializeObject<Agent>(login);
                using (var db = new Data.AGENCYEntities())
                {
                    var a = db.Agents.FirstOrDefault(b => b.Agent_Code == agent.agent_code && b.Password == agent.pin);
                    if (a != null)
                    {
                        if ((bool)a.Active)
                        {

                            if (agent.new_pin != null)
                            {
                                a.Password = agent.new_pin;
                                a.Password_Changed = true;
                                db.SaveChanges();
                                agent.new_pin = null;
                                agent.Pin_changed = (bool)a.Password_Changed;
                            }
                        }
                    }
                    else
                        agent.logged_in = false;
                    db.SaveChanges();
                }
                response = new JavaScriptSerializer().Serialize(agent);
            }
            catch (Exception ex)
            {
                agent.logged_in = false;
                agent.message = ex.Message;
                response = new JavaScriptSerializer().Serialize(agent);
                CUtilities.LogEntryOnFile(ex.Message);
                if (ex.InnerException != null)
                    CUtilities.LogEntryOnFile(ex.InnerException.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            Context.Response.Output.Write(response);

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Accounts(string data)
        {
            String response = string.Empty;
            Transaction trans = null;
            try
            {
                CUtilities.LogEntryOnFile(data);
                Member member = null;
                trans = JsonConvert.DeserializeObject<Transaction>(data);
                
                if (trans.member_1 != null)
                {
                    member = trans.member_1;
                    using (var db = new Data.AGENCYEntities())
                    {
                        if (trans.transactiontype != Transaction.Transtype.Memberactivation)
                        {
                            var m = db.Agency_Members.FirstOrDefault(o => o.ID_No == member.id_no);
                            if (m != null)
                            {
                                member.pin = m.Pin;
                                member.pin_changed = (Boolean)m.Pin_Changed;
                                member.telephone = m.Telephone_No;
                                
                            }
                            else
                            {trans.status = Transaction.Status.Failed;
                                member.accounts = Account.accountlist(member.id_no);
                                if (member.accounts.Count > 0)
                                {                                    
                                    trans.message = "Customer not activated to use agency.";
                                }
                                else
                                { 
                                 trans.message = "Customer does not exist";
                                }

                            }
                        }
                    }
                }
                switch (trans.transactiontype)
                {
                    case Transaction.Transtype.Deposit:
                        trans.account_1 = Account.accountinfo(trans.account_1);
                        break;
                   case Transaction.Transtype.LoanRepayment:
                        member.accounts = Account.accountlist(member.id_no);
                        member.loans = Loans.loans(member.id_no);
                        break;
                    case Transaction.Transtype.Withdrawal:
                        member.accounts = Account.accountlistwithdrawable(member.id_no);
                        break;
                    case Transaction.Transtype.Sharedeposit:
                        member.accounts = Account.Memberlist(member.id_no);
                        break;
                    default:
                        member.accounts = Account.accountlist(member.id_no); 
                        if (trans.account_2!= null)
                            trans.account_2 = Account.accountinfo(trans.account_2);
                        break;
                   
                }
                                      
                    trans.member_1 = member;
                
                if (trans.account_2 != null)
                {
                    trans.account_2 =Account. accountinfo(trans.account_2);
                }
                response = new JavaScriptSerializer().Serialize(trans);

            }
            catch (Exception ex)
            {
                trans.status = Transaction.Status.Failed;
                trans.message = "Unable to get the account, please try again later.";
                response = new JavaScriptSerializer().Serialize(trans);
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            CUtilities.LogEntryOnFile(response);
            Context.Response.Output.Write(response);

        }
        

  
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Transactions(string data)
        {
            CUtilities.LogEntryOnFile(data);
            String response = string.Empty;
            Transaction tr = null;
            try
            {
                tr = JsonConvert.DeserializeObject<Transaction>(data);
                using (var localdb = new Data.AGENCYEntities())
                {
                    switch (tr.status)
                    {
                        case Transaction.Status.Pending:
                            {

                                string ottn = string.Concat(DateTime.Now.Minute.ToString().PadLeft(2, '0'), DateTime.Now.Second.ToString().PadLeft(2, '0')).PadRight(4, '0');

                                Agency_Transaction agt = null;
                                try
                                {
                                    agt = localdb.Agency_Transactions.FirstOrDefault(o => o.Document_No == tr.reference);
                                    if (agt == null)
                                    {
                                        // CUtilities.LogEntryOnFile("ok");
                                        agt = new Agency_Transaction();
                                        agt.Document_No = "";
                                        localdb.AddToAgency_Transactions(agt);
                                        localdb.SaveChanges();
                                    }

                                    agt.Agent_Code = tr.agent.agent_code;
                                    agt.OTTN = Convert.ToInt32(ottn.PadRight(4, '0'));
                                    agt.Agent_Name = tr.agent.agent_Name;
                                    agt.Amount = Convert.ToDecimal(tr.amount);
                                    agt.Status = (int)Transaction.Status.Confirmation;
                                    agt.Transaction_Type = tr.transactiontype.ToString();
                                    agt.Transaction_Date = DateTime.Now.Date;
                                    agt.Transaction_Time = DateTime.Now;

                                    tr.agent.account_balance = Account.accountbalance(Agent.GetAccount(ref tr.agent));
                                    CUtilities.LogEntryOnFile(tr.agent.account_balance.ToString());
                                    tr.code = agt.OTTN.ToString();
                                    tr.reference = string.Concat(agt.Entry_No, ottn);
                                    tr.Minimun_Amount = 100;
                                    tr.Maximun_Amount = 25000;
                                    agt.Document_No = tr.reference;
                                    tr.amount_charge = Tcharges(tr.transactiontype, tr.amount);
                                    tr.status = Transaction.Status.Confirmation;
                                    agt.Charge =(decimal) tr.amount_charge;

                                    if (tr.account_1 != null)
                                    {
                                        agt.Account_No = tr.account_1.Account_No;
                                        agt.Account_Name = tr.account_1.Account_Name;
                                        agt.Account_Type = tr.account_1.Account_type;

                                    }

                                    if (tr.account_2 != null)
                                    {
                                        agt.Account_No_2 = tr.account_2.Account_No;
                                    }
                                    if (tr.member_1 != null)
                                    {
                                        agt.ID_No = tr.member_1.id_no;
                                        agt.Account_Name = tr.member_1.name;
                                        agt.Source_Telephone_No = tr.member_1.telephone;
                                        if ((tr.member_1.pin_changed == false) && (tr.newpin != null))
                                        {
                                            var p = localdb.Agency_Members.FirstOrDefault(o => o.ID_No == tr.member_1.id_no);
                                            if (p != null)
                                            {
                                                p.Pin = tr.newpin;
                                                p.Pin_Changed = true;
                                                p.Date_Pin_Changed = DateTime.Now;
                                            }
                                        }
                                    }

                                    if (tr.Telephone_No != null)
                                    {
                                        agt.Depositer_Telephone_No = tr.Telephone_No;

                                    }
                                    switch (tr.transactiontype)
                                    {
                                        case Transaction.Transtype.Balance:
                                        case Transaction.Transtype.Ministatment:
                                        case Transaction.Transtype.Memberactivation:
                                            break;
                                        default:
                                            if (tr.amount < tr.Minimun_Amount)
                                            {
                                                tr.status = Transaction.Status.Failed;
                                                tr.message = "Amount should not be less than " + tr.Minimun_Amount ;
                                            } if (tr.amount > tr.Maximun_Amount)
                                            {
                                                tr.status = Transaction.Status.Failed;
                                                tr.message = "Amount should not be more than " + tr.Maximun_Amount ;
                                            }
                                                break;

                                    }

                                    switch (tr.transactiontype)
                                    {
                                        case Transaction.Transtype.Balance:
                                        case Transaction.Transtype.Ministatment:
                                            if (tr.account_1.Account_Balance < (tr.amount + tr.amount_charge))
                                            {
                                                tr.status = Transaction.Status.Failed;
                                                tr.message = "Insufficient Funds";
                                            }
                                            break;
                                        case Transaction.Transtype.Withdrawal:
                                        case Transaction.Transtype.Transfer:

                                            if (tr.account_1.Account_Balance < (tr.amount + tr.amount_charge))
                                            {
                                                tr.status = Transaction.Status.Failed;
                                                tr.message = "Insufficient Funds";
                                            }


                                           
                                            break;
                                        case Transaction.Transtype.Deposit:
                                        case Transaction.Transtype.LoanRepayment:
                                        case Transaction.Transtype.Sharedeposit:
                                        case Transaction.Transtype.Schoolfeespayment:
                                        case Transaction.Transtype.Paybill:
                                                                               CUtilities.LogEntryOnFile(tr.agent.Branch.ToString());
                                            if((tr.agent.Branch == false)&& (tr.agent.account_balance < (tr.amount)))
                                            {
                                                tr.status = Transaction.Status.Failed;
                                                tr.message = "Insufficient Float";
                                            }
                                         
                                            break;
                                        case Transaction.Transtype.Memberactivation:
                                            //if (tr.member_1 != null)
                                            //{
                                            //    var m = localdb.Agency_Members.FirstOrDefault(o => o.ID_No == tr.member_1.id_no);
                                            //    if (m != null)
                                            //    {
                                            //        tr.status = Transaction.Status.Failed;
                                            //        tr.message = "Member is Already Active";
                                            //    }
                                            //}
                                            break;
                                        case Transaction.Transtype.Registration:
                                            if ((tr.agent.Branch == false) && (tr.agent.account_balance < (tr.amount)))
                                            {
                                                tr.status = Transaction.Status.Failed;
                                                tr.message = "Insufficient Float";
                                            }
                                            var mes = Account.accountlistall(tr.member_1.id_no);

                                            if ((mes != null) && (mes.Count > 0))
                                            {
                                                tr.status = Transaction.Status.Failed;
                                                tr.message = "Account Already exist";
                                            }
                                            agt.Society = "";
                                            agt.Society_No = "";
                                            break;
                                        case Transaction.Transtype.MemberRegistration:
                                            if ((tr.agent.Branch == false) && (tr.agent.account_balance < (tr.amount)))
                                            {
                                                tr.status = Transaction.Status.Failed;
                                                tr.message = "Insufficient Float";
                                            }
                                            var mess = Account.MemberlistAll(tr.member_1.id_no);

                                            if ((mess != null) && (mess.Count > 0))
                                            {
                                                tr.status = Transaction.Status.Failed;
                                                tr.message = "Member Already exist";
                                            }
                                                                                   

                                            agt.Society = "";
                                            agt.Society_No = "";
                                            break;
                                    }
                                    //sms
                                    if ((tr.status != Transaction.Status.Failed) && (tr.valid))
                                    {
                                        switch (tr.transactiontype)
                                        {
                                            case Transaction.Transtype.Deposit:
                                            case Transaction.Transtype.LoanRepayment:
                                            case Transaction.Transtype.Sharedeposit:
                                                break;
                                            case Transaction.Transtype.Registration:
                                            case Transaction.Transtype.MemberRegistration:
                                                sms.Telephone = tr.member_1.telephone;
                                                sms.Text = String.Format("{0} CODE: {1}", Transaction.GetDescription(tr.transactiontype), agt.OTTN);
                                                sms.Send(sms);
                                                break;
                                            default:
                                                sms.Telephone = tr.account_1.Telephone;
                                                sms.Text = String.Format("{0} CODE: {1}", Transaction.GetDescription(tr.transactiontype), agt.OTTN);
                                                sms.Send(sms);
                                                break;
                                        }
                                    }
                                    localdb.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    CUtilities.LogEntryOnFile(ex.Message);
                                    CUtilities.LogEntryOnFile(ex.StackTrace);
                                    tr.status = Transaction.Status.Failed;
                                    tr.message = "Unable to complete the Transaction";
                                    agt.Status = (int)Transaction.Status.Failed;
                                    agt.Comments = ex.Message;
                                }
                                finally
                                {
                                    localdb.SaveChanges();
                                }
                                break;
                            }
                        case Transaction.Status.Confirmation:
                            {
                                var t = localdb.Agency_Transactions.FirstOrDefault(o => o.Document_No == tr.reference);

                                if (t != null)
                                {
                                    try
                                    {
                                        using (var db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                                        {
                                            if (db.mDB.State == ConnectionState.Open)
                                            {
                                                Random r = new Random(1000);
                                                string pin =r.Next(1000, 9999).ToString();
                                                int agno =Convert.ToInt32( tr.agent.agent_code.Replace("SAC", ""));


                                                switch (tr.transactiontype)
                                                {
                                                    case Transaction.Transtype.Memberactivation:
                                                        if (tr.member_1 != null)
                                                            if (tr.account_1.Telephone != null)
                                                            {
                                                                Agency_Member agm = null;
                                                                agm = localdb.Agency_Members.FirstOrDefault(o => o.ID_No == tr.member_1.id_no);
                                                                if (agm == null)
                                                                {
                                                                    agm = new Agency_Member();
                                                                    agm.Date_Registered = DateTime.Now;
                                                                    agm.Telephone_No = tr.account_1.Telephone;
                                                                    localdb.AddToAgency_Members(agm);
                                                                    localdb.SaveChanges();
                                                                }
                                                                agm.ID_No = tr.member_1.id_no;
                                                                agm.Pin_Changed = false;
                                                                agm.Pin = agm.ID.ToString().PadLeft(4, '0');
                                                                localdb.SaveChanges();

                                                                sms.Telephone = tr.account_1.Telephone;
                                                                sms.Text = String.Format("You have Successfully been activated to use M-SACCO AGENCY. Your start Pin is {0}.", agm.Pin);
                                                                sms.Send(sms);

                                                            }
                                                        break;
                                                    case Transaction.Transtype.Registration:
                                                        if (tr.member_1 != null)
                                                            if (tr.member_1.telephone != null)
                                                            {
                                                               
                                                                Agency_Member agm = new Agency_Member();
                                                                agm.Telephone_No = tr.member_1.telephone;
                                                                agm.ID_No = tr.member_1.id_no;
                                                                agm.Date_Registered = DateTime.Now;
                                                                agm.Pin_Changed = false;
                                                                localdb.AddToAgency_Members(agm);
                                                                localdb.SaveChanges();
                                                                agm.Pin = pin;
                                                                sms.Telephone = tr.member_1.telephone;
                                                                sms.Text = String.Format("{0} Completed.\nReference: {1}\n ID No: {2}\nAccount Name: {3} .\nYour account will be created shortly.", Transaction.GetDescription(tr.transactiontype), tr.reference, tr.member_1.id_no, tr.member_1.name);
                                                                sms.Send(sms);
                                                            }
                                                        break;
                                                    case Transaction.Transtype.MemberRegistration:
                                                        if (tr.member_1 != null)
                                                            if (tr.member_1.telephone != null)
                                                            {                                                              
                                                                Agency_Member agm = new Agency_Member();
                                                                agm.Telephone_No = tr.member_1.telephone;
                                                                agm.ID_No = tr.member_1.id_no;
                                                                agm.Date_Registered = DateTime.Now;
                                                                agm.Pin_Changed = false;
                                                                agm.Pin = pin;
                                                                localdb.AddToAgency_Members(agm);
                                                                localdb.SaveChanges();

                                                                sms.Telephone = tr.member_1.telephone;
                                                                sms.Text = String.Format("{0} Completed.\nReference: {1}\n ID No: {2}\nAccount Name: {3} .\nYour account will be created shortly.", Transaction.GetDescription(tr.transactiontype), tr.reference, tr.member_1.id_no, tr.member_1.name);
                                                                sms.Send(sms);
                                                            }
                                                        break;
                                                    case Transaction.Transtype.Transfer:
                                                        sms.Telephone = tr.account_1.Telephone;
                                                        sms.Text = String.Format("{0} Completed.\n Reference: {1}\n Account: {2} to: {4}\nAmount: {3} .", Transaction.GetDescription(tr.transactiontype), tr.reference, tr.account_1.Account_No, tr.amount,tr.account_2.Account_No);
                                                        sms.Send(sms);
                                                        sms = new Sms();
                                                        sms.Telephone = tr.account_2.Telephone;
                                                        sms.Text = String.Format("{0} has been credited to your FOSA account by {1} {2}.", tr.amount, tr.account_1.Account_Name, tr.account_1.Telephone);
                                                        sms.Send(sms);
                                                        break;
                                                    case Transaction.Transtype.Deposit:
                                                        sms.Telephone = tr.Telephone_No;
                                                        sms.Text = String.Format("{0} Completed.\n Reference: {1}\n Account: {2}\nAmount: {3} .", Transaction.GetDescription(tr.transactiontype), tr.reference, tr.account_1.Account_No, tr.amount);
                                                        sms.Send(sms);
                                                        sms = new Sms();
                                                        sms.Telephone = tr.account_1.Telephone;
                                                        sms.Text = String.Format("{0} has been credited to your FOSA account by {1} {2}.", tr.amount, tr.Depositor_Name, tr.Telephone_No);
                                                        sms.Send(sms);
                                                        break;
                                                    case Transaction.Transtype.Balance:
                                                        sms.Telephone = tr.account_1.Telephone;
                                                        sms.Text = String.Format("{0} Completed.\n Reference: {1}\n Account: {2}\nAmount: {3} .", Transaction.GetDescription(tr.transactiontype), tr.reference, tr.account_1.Account_No, tr.account_1.Account_Balance);
                                                        sms.Send(sms);

                                                        break;
                                                    case Transaction.Transtype.Ministatment:
                                                        sms.Telephone = tr.member_1.telephone;
                                                        sms.Text = Account.Ministatement(tr.account_1.Account_No);
                                                        sms.Send(sms);
                                                        break;
  
                                                    case Transaction.Transtype.LoanRepayment:
                                                        sms.Telephone = tr.member_1.telephone;
                                                        sms.Text = String.Format("{0} Completed.\n Reference: {1}\n Loan No: {2}\nAmount: {3} .", Transaction.GetDescription(tr.transactiontype), tr.reference, tr.loan_no.Loan_No, tr.amount);
                                                        sms.Send(sms);
                                                        break;
                                                    default:
                                                        sms.Telephone = tr.member_1.telephone;
                                                        sms.Text = String.Format("{0} Completed.\n Reference: {1}\n Account: {2}\nAmount: {3} .", Transaction.GetDescription(tr.transactiontype), tr.reference, tr.account_1.Account_No, tr.amount);
                                                        sms.Send(sms);

                                                        break;
                                                }
                                                sms.Telephone = tr.agent.Telephone;
                                                sms.Text = String.Format("{0} Completed.\n Reference: {1}\n Account: {2}\nAmount: {3} .", Transaction.GetDescription(tr.transactiontype), tr.reference, (tr.account_1!=null? tr.account_1.Account_No:""), tr.amount);
                                                sms.Send(sms);
                                                
                                                db.WriteDB(String.Format("INSERT INTO [dbo].[Capital SACCO Society Ltd$Agent Transactions] ([Document No_] ,[Description] ,[Transaction Date] ,[Account No_] ,[Amount] ,[Posted] ,[Transaction Time] ,[Bal_ Account No_] ,[Document Date] ,[Date Posted] ,[Time Posted] ,[Account Status] ,[Messages] ,[Needs Change] ,[Change Transaction No] ,[Old Account No] ,[Changed] ,[Date Changed] ,[Time Changed] ,[Changed By] ,[Approved By] ,[Original Account No] ,[Account Balance] ,[Branch Code] ,[Activity Code] ,[Global Dimension 1 Filter] ,[Global Dimension 2 Filter] ,[Transaction Type] ,[Account No 2] ,[OTTN] ,[Transaction Location] ,[Transaction By] ,[Agent Code],[Loan No],[Account Name],[Telephone],[Id No],[Society],[Member No])VALUES ('{0}' ,'{1}' ,'{2}' ,'{3}' ,{4} ,0 ,'{5}' ,'' ,'{2}','{2}' ,'{6}' ,'' ,'' ,'' ,'' ,'' ,0 ,'{2}' ,'{6}' ,'' ,'' ,'' ,0 ,'' ,'' ,'' ,'' ,{7} ,'{8}' ,'{9}' ,'' ,'' ,'{10}','{11}','{12}','{13}','{14}','{15}','{16}')", tr.reference, Transaction.GetDescription(tr.transactiontype), DateTime.Now.Date.ToString("yyyy/MM/dd"), (tr.account_1 == null ? "" : tr.account_1.Account_No), tr.amount, DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"), gettime(), (int)tr.transactiontype, (tr.account_2 == null ? "" : tr.account_2.Account_No), tr.code, tr.agent.agent_code, (tr.loan_no == null ? "" : tr.loan_no.Loan_No), (tr.member_1 == null ? "" : tr.member_1.name), (tr.member_1 == null ? "" :"+254" +  (tr.member_1.telephone.Length>=9?tr.member_1.telephone.Substring(tr.member_1.telephone.Length-9):tr.member_1.telephone)), (tr.member_1 == null ? "" : tr.member_1.id_no), agno, pin));
                                                tr.status = Transaction.Status.Successful;
                                                t.Status = (int)Transaction.Status.Successful;
                                                t.Transferred_To_Sacco = true;
                                                t.Date_Transferred_To_Sacco = DateTime.Now.Date;
                                                t.Time_Transferred_To_Sacco = DateTime.Now;
                                                t.Posted = true;
                                                t.Date_Posted = DateTime.Now.Date;
                                                t.Time_Posted = DateTime.Now;
                                            }
                                            db.close();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        tr.status = Transaction.Status.Failed;
                                        tr.message = "Unable to complete the Transaction";
                                        t.Status = (int)Transaction.Status.Failed;
                                        t.Comments = ex.Message;
                                        CUtilities.LogEntryOnFile(ex.Message);
                                        CUtilities.LogEntryOnFile(ex.StackTrace);
                                    }
                                }
                                
                                break;
                            }

                    }
                    localdb.SaveChanges();
                }
                response = new JavaScriptSerializer().Serialize(tr);
            }
            catch (Exception ex)
            {
                tr.status = Transaction.Status.Failed;
                tr.message = "Unable to complete the Transaction";
                response = new JavaScriptSerializer().Serialize(tr);
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            finally{
                CUtilities.LogEntryOnFile(new JavaScriptSerializer().Serialize(tr));
            }

            Context.Response.Output.Write(response);

        }

        private string gettime()
        {
            return "1754-01-01 " + DateTime.Now.ToString("HH:mm:ss tt");
        }

        private double Tcharges(Transaction.Transtype t, double Amount)
        {
            double balance = 0;
            String tt = string.Empty;
            SqlDataReader r;
            try
            {
                CUtilities.LogEntryOnFile(((int)t).ToString());
          CUtilities.LogEntryOnFile(Amount.ToString());
          Db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass);
                r = Db.ReadDB(String.Format("SELECT [Code] FROM [Capital SACCO Society Ltd$Tarrif Header]  WHERE ([Trans Type Agents] = '{0}')", (int)t));
                if (r.HasRows)
                {
                    r.Read();
                    tt = r["Code"].ToString();
                    r.Close();
                    r = null;
                    r = Db.ReadDB(String.Format("SELECT [Charge Amount] FROM [Capital SACCO Society Ltd$Tariff Details]  WHERE ([Code] = '{0}') and [Lower Limit] <= {1} and [Upper Limit]>= {1} ", tt, Amount));
                    if (r.HasRows)
                    {
                        r.Read();
                        balance = Convert.ToDouble(r["Charge Amount"]);

                    }
                }
                else
                    balance = 0;
                r.Close();
                r = null;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
            }
            return balance;
        }
    }
}