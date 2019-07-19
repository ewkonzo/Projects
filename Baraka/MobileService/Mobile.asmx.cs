using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using M_SACCO_Webservice.Loans;
using System.Data.Services.Client;
using System.Net;
using System.Data.Services.Common;

namespace MobiService
{
    /// <summary>
    /// Summary description for Mobile
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Mobile : System.Web.Services.WebService
    {
        System.Net.NetworkCredential cd;
        M_SACCO_Webservice.MobileTrans.MobileTransactions_Service mobile = new M_SACCO_Webservice.MobileTrans.MobileTransactions_Service();
        M_SACCO_Webservice.Applicatons.MobileApplications_Service app = new M_SACCO_Webservice.Applicatons.MobileApplications_Service();
        M_SACCO_Webservice.Loans.Loans_Service loans = new M_SACCO_Webservice.Loans.Loans_Service();
        M_SACCO_Webservice.Members.Members_Service members = new M_SACCO_Webservice.Members.Members_Service();
        M_SACCO_Webservice.Alternate.Alternate nav = new M_SACCO_Webservice.Alternate.Alternate();
        public static settings ss = new settings();

        public Mobile()
        {
            string path = Server.MapPath("~/Settings.xml");
            ss = ss.loadsettings(path);
            cd = new System.Net.NetworkCredential(ss.Username, ss.pass, ss.domain);

            mobile.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/MobileTransactions", ss.Serverip, ss.Companyname, ss.Instance, ss.Port);
            mobile.PreAuthenticate = true;
            mobile.Credentials = cd;

            app.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/MobileApplications", ss.Serverip, ss.Companyname, ss.Instance, ss.Port);
            app.PreAuthenticate = true;
            app.Credentials = cd;

            loans.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Loans", ss.Serverip, ss.Companyname, ss.Instance, ss.Port);
            loans.PreAuthenticate = true;
            loans.Credentials = cd;

            members.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Members", ss.Serverip, ss.Companyname, ss.Instance, ss.Port);
            members.PreAuthenticate = true;
            members.Credentials = cd;

            nav.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/Alternate", ss.Serverip, ss.Companyname, ss.Instance, ss.Port);
            nav.PreAuthenticate = true;
            nav.Credentials = cd;

        }
     
        
        [WebMethod]
        public Result Transactions(M_SACCO_Webservice.MobileTrans.MobileTransactions t)
        {
            Result r = new Result();
            try
            {
                t.Transaction_Date = DateTime.Today;
                t.Transaction_Time = DateTime.Now;
                if (string.IsNullOrEmpty(t.Document_No)) throw new Exception("Document No Required");
                if (string.IsNullOrEmpty(t.Transaction_Type.ToString())) throw new Exception("Transaction type is Required");
                if (string.IsNullOrEmpty(t.Mobile_No.ToString())) throw new Exception("Telephone no is Required");
                t.Mobile_No = string.Format("+{0}", t.Mobile_No.Replace("+", ""));
                Logging.Logging.LogEntryOnFile(t.Mobile_No);
                switch (t.Transaction_Type)
                {
                    case 8://Balance
                        var ap = app.ReadMultiple(new M_SACCO_Webservice.Applicatons.MobileApplications_Filter[] { new M_SACCO_Webservice.Applicatons.MobileApplications_Filter { Criteria = t.Mobile_No, Field = M_SACCO_Webservice.Applicatons.MobileApplications_Fields.MPESA_Mobile_No } }, null, 0).FirstOrDefault();
                        if (ap == null)
                            throw new Exception("Account Not found");
                        t.Account_No = ap.No;
                        var m = members.Read(ap.No);
                        List<Balances> b = new List<Balances>();

                        if (m != null)
                        {
                            Balances bb = new Balances();
                            if (m.Toto_savings != 0)
                            {
                                bb.Accounttype = "Total Savings";
                                bb.Balance = (double)m.Toto_savings;
                                b.Add(bb);
                            }
                            if (m.Plaza_Shares != 0)
                            {
                                bb = new Balances();
                                bb.Accounttype = "Plaza Savings";
                                bb.Balance = (double)m.Plaza_Shares;
                                b.Add(bb);
                            }
                            if (m.Christmas_Savings != 0)
                            {
                                bb = new Balances();
                                bb.Accounttype = "Christmas Savings";
                                bb.Balance = (double)m.Christmas_Savings;
                                b.Add(bb);
                            }
                        }
                        r.Balances = b.ToArray();

                        break;
                    case 10://loan balance
                        ap = app.ReadMultiple(new M_SACCO_Webservice.Applicatons.MobileApplications_Filter[] { new M_SACCO_Webservice.Applicatons.MobileApplications_Filter { Criteria = t.Mobile_No, Field = M_SACCO_Webservice.Applicatons.MobileApplications_Fields.MPESA_Mobile_No } }, null, 0).FirstOrDefault();
                        if (ap == null)
                            throw new Exception("Account Not found");

                        t.Account_No = ap.No;
                        var l = loans.ReadMultiple(new Loans_Filter[] { new Loans_Filter { Criteria = ap.No, Field = Loans_Fields.Client_Code } }, null, 0).Where(o => o.Balance > 1).ToArray();
                        r.loans = l;
                        break;
                    case 21://e loan
                        var aap = app.ReadMultiple(new M_SACCO_Webservice.Applicatons.MobileApplications_Filter[] { new M_SACCO_Webservice.Applicatons.MobileApplications_Filter { Criteria = t.Mobile_No, Field = M_SACCO_Webservice.Applicatons.MobileApplications_Fields.MPESA_Mobile_No } }, null, 0).FirstOrDefault();
                        if (aap == null)
                            throw new Exception("Account Not found");
                        t.Account_No = aap.No;
                        var eligibility = nav.Eligibility(t.Mobile_No);
                        Logging.Logging.LogEntryOnFile(string.Format("{0}{1}", t.Account_No, eligibility));
                        if (eligibility < t.Amount)
                            throw new Exception(String.Format("You only qualify for {0}", eligibility));
                        break;
                    case 24://eligibility
                        var aaap = app.ReadMultiple(new M_SACCO_Webservice.Applicatons.MobileApplications_Filter[] { new M_SACCO_Webservice.Applicatons.MobileApplications_Filter { Criteria = t.Mobile_No, Field = M_SACCO_Webservice.Applicatons.MobileApplications_Fields.MPESA_Mobile_No } }, null, 0).FirstOrDefault();
                        if (aaap == null)
                            throw new Exception("Account Not found");
                        t.Account_No = aaap.No;
                        var eligible = nav.Eligibility(t.Mobile_No);
                        r.eligibility = (double)eligible;
                        break;
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
                r.code = -1;
                r.Description = ex.Message;
                t.Comments = r.Description;
            }
            finally
            {
                try
                {
                    var tran = mobile.Read(t.Document_No, t.Transaction_Type);
                    if (tran == null)
                    {
                        tran = new M_SACCO_Webservice.MobileTrans.MobileTransactions();
                        tran.Document_No = t.Document_No;
                        tran.Transaction_Type = t.Transaction_Type;
                        tran.Transaction_TypeSpecified = true;
                        mobile.Create(ref tran);
                    }
                    tran.Account_No = t.Account_No;
                    tran.Account_No_2 = t.Account_No_2;
                    tran.Amount = (decimal)t.Amount;
                    tran.AmountSpecified = true;
                    tran.Charge = t.Charge;
                    tran.ChargeSpecified = true;
                    tran.Status = M_SACCO_Webservice.MobileTrans.Status.Pending;
                    tran.StatusSpecified = true;
                    tran.Transaction_Date = (DateTime)t.Transaction_Date;
                    tran.Transaction_DateSpecified = true;
                    tran.Description = t.Description;
                    tran.Comments = t.Comments;
                    if (r.code != 0)
                        tran.Status = M_SACCO_Webservice.MobileTrans.Status.Failed;
                    mobile.Update(ref tran);
                }
                catch (Exception f)
                {
                    Logging.Logging.ReportError(f);
                    r.code = -1;
                    r.Description = "Unspecified Error occured";
                }
            }
            return r;
        }
        [WebMethod]
        public List<M_SACCO_Webservice.Applicatons.MobileApplications> Applications()
        {
            List<M_SACCO_Webservice.Applicatons.MobileApplications> a = new List<M_SACCO_Webservice.Applicatons.MobileApplications>();
            try
            {
                a = app.ReadMultiple(new M_SACCO_Webservice.Applicatons.MobileApplications_Filter[] { new M_SACCO_Webservice.Applicatons.MobileApplications_Filter { Criteria = "No", Field = M_SACCO_Webservice.Applicatons.MobileApplications_Fields.Sent_To_Server } }, null, 0).ToList();
                foreach (var item in a)
                {
                    M_SACCO_Webservice.Applicatons.MobileApplications m = item;
                    m.Sent_To_Server = M_SACCO_Webservice.Applicatons.Sent_To_Server.Yes;
                    m.Sent_To_ServerSpecified = true;
                    app.Update(ref m);
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);

            }

            return a;

        }
    }
    public class Result
    {
        public int code;
        public string Description;
        public Loans[] loans
        {
            get;
            set;
        }
        public Balances[] Balances
        {
            get;
            set;
        }
        public Double eligibility{
            get;set;}
    }
    public class Balances
    {
        public string Accounttype;
        public double Balance;

    }
}
