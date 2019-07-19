using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using System.Net;
using System.Xml.Serialization;
namespace Mpesa_Api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Deposit" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Deposit.svc or Deposit.svc.cs at the Solution Explorer and start debugging.
    public class Deposit : IDeposit
    {
        public static settings s = new settings();
        private static System.Net.NetworkCredential cd;
        public static Mpesa.Mpesa_Service mpesa = new Mpesa.Mpesa_Service();
        public Deposit()
        {
            Logging.Logging.logpath = @"E:\Logs\";
            string path = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            path = string.Concat(path, "Settings.xml");
            Logging.Logging.LogEntryOnFile(path);
            s = s.loadsettings(path);
            cd = new System.Net.NetworkCredential(s.Username, s.pass, s.domain);
            mpesa.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Page/Mpesa", s.Serverip, s.Companyname,
                s.Instance, s.Port);

            mpesa.PreAuthenticate = true;
            mpesa.Credentials = cd;
        }

        public string ValidateC2BPayment(Stream request)
        {

            using (var reader = new StreamReader(request))
            {
                string inn = reader.ReadToEnd();

                Logging.Logging.LogEntryOnFile("validate " + inn);

                // {"ResultDesc":"Validaion Service request accepted succesfully","ResultCode":"0"}
                Response r = new Response();
                var json = new JavaScriptSerializer().Serialize(r);
                Logging.Logging.LogEntryOnFile("validateR " + json);
                return json;
            }
        }
        public string ConfirmC2BPayment(Stream request)
        {
            string json = string.Empty;
            Response res = new Response();

            try
            {
                using (var reader = new StreamReader(request))
                {
                    string inn = reader.ReadToEnd();
                    Logging.Logging.LogEntryOnFile("confirm " + inn);

                    C2B r = JsonConvert.DeserializeObject<C2B>(inn);
                    DateTime d = new DateTime(Convert.ToInt32(r.TransTime.Substring(0, 4)), Convert.ToInt32(r.TransTime.Substring(4, 2)), Convert.ToInt32(r.TransTime.Substring(6, 2)), Convert.ToInt32(r.TransTime.Substring(8, 2)), Convert.ToInt32(r.TransTime.Substring(10, 2)), Convert.ToInt32(r.TransTime.Substring(12, 2)));

                    //using (var db = new MobileEntities())
                    //{

                        //MPESA_Transaction t;

                        //t = db.MPESA_Transactions.FirstOrDefault(o => o.Receipt_No_ == r.TransID);

                        //if (t == null)
                        //{
                        //    t = new MPESA_Transaction();
                        //    t.Receipt_No_ = r.TransID;
                        //    t.Paid_In = Convert.ToDecimal(r.TransAmount);
                        //    t.Completion_Time = d;
                        //    t.Initiation_Time = d;
                        //    t.Paybil_Number = r.BusinessShortCode;
                        //    t.Phone = r.MSISDN;
                        //    t.Balance = Convert.ToDecimal(r.OrgAccountBalance);
                        //    t.A_C_No_ = r.BillRefNumber;
                        //    t.Transaction_Type = r.TransType;
                        //    t.Transaction_Date = d.Date;
                        //    t.Name = string.Format("{0} {1} {2}", r.FirstName, r.MiddleName, r.LastName);
                        //    t.Other_Party_Info = string.Format("{0} {1}", t.Phone, t.Name);
                        //    t.Detaills = String.Format("Pay Bill from {0} - {1} Acc. {2} ", t.Phone, t.Name, t.A_C_No_);
                        //    t.Sent = false;
                        //    db.MPESA_Transactions.Add(t);
                        //    db.SaveChanges();
                        //}
                        var trans = mpesa.Read(r.TransID);
                        if (trans == null)
                        {

                            Mpesa.Mpesa m = new Mpesa.Mpesa();
                            m.Receipt_No = r.TransID;

                            m.Completion_Time = d;
                            m.Completion_TimeSpecified = true;
                            m.Initiation_Time = d;
                            m.Initiation_TimeSpecified = true;
                            m.Paid_In = Convert.ToDecimal(r.TransAmount);
                            m.Paid_InSpecified = true;
                            m.Paybil_Number = r.BusinessShortCode;
                            m.Phone = r.MSISDN;
                            m.Status = Mpesa.Status.Completed;
                            m.StatusSpecified = true;
                            m.Balance = Convert.ToDecimal(r.OrgAccountBalance);
                            m.BalanceSpecified = true;
                            m.A_C_No = r.BillRefNumber;
                            m.Transaction_Date = d.Date;
                            m.Transaction_DateSpecified = true;
                            m.Transaction_Type = r.TransactionType.ToString();
                            m.Time = d;
                            m.TimeSpecified = true;
                            m.Name = string.Format("{0} {1} {2}", r.FirstName, r.MiddleName, r.LastName);
                            m.Other_Party_Info = m.Phone + " " + m.Name;
                            m.Detaills = String.Format("Pay Bill from {0} - {1} Acc. {2} ", m.Phone, m.Name, m.A_C_No);
                            mpesa.Create(ref m);
                        }
                        //t.Sent = true;
                        //db.SaveChanges();
                        //var tt = db.MPESA_Transactions.Where(o => o.Sent == false);
                        //foreach (MPESA_Transaction mp in tt.ToList())
                        //{
                        //    var tran = mpesa.Read(mp.Receipt_No_);
                        //    if (tran == null)
                        //    {
                        //        Mpesa.Mpesa m = new Mpesa.Mpesa();
                        //        m.Receipt_No = mp.Receipt_No_;
                        //        m.Paid_In = Convert.ToDecimal(mp.Paid_In);
                        //        m.Paid_InSpecified = true;
                        //        m.Paybil_Number = mp.Paybil_Number;
                        //        m.Phone = mp.Phone;
                        //        m.Status = Mpesa.Status.Completed;
                        //        m.StatusSpecified = true;
                        //        m.Balance = Convert.ToDecimal(mp.Balance);
                        //        m.BalanceSpecified = true;
                        //        m.Transaction_Type = mp.Transaction_Type;
                        //        m.A_C_No = mp.A_C_No_;
                        //        m.Name = mp.Name;
                        //        m.Status = Mpesa.Status.Completed;
                        //        m.StatusSpecified = true;
                        //        m.Completion_Time = (DateTime)mp.Completion_Time;
                        //        m.Completion_TimeSpecified = true;
                        //        m.Initiation_Time = (DateTime)mp.Initiation_Time;
                        //        m.Initiation_TimeSpecified = true;
                        //        m.Transaction_Date = (DateTime)mp.Transaction_Date;
                        //        m.Transaction_DateSpecified = true;
                        //        m.Detaills = mp.Detaills;
                        //        m.Other_Party_Info = mp.Other_Party_Info;
                        //        m.Time = (DateTime)mp.Initiation_Time;
                        //        m.TimeSpecified = true;
                        //        mpesa.Create(ref m);
                        //    }
                        //    mp.Sent = true;
                        //    db.SaveChanges();
                        //}
                    //}

                    Logging.Logging.LogEntryOnFile("confirmR " + json);
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
                res.ResultCode = "0";
                res.ResultDesc = "Unspecified error";
            }
            finally { json = new JavaScriptSerializer().Serialize(res); }
            return json;



        }
        public string stkpush(Stream request)
        {
            using (var reader = new StreamReader(request))
            {
                string inn = reader.ReadToEnd();
                Logging.Logging.LogEntryOnFile("Stk " + inn);
                stk s = JsonConvert.DeserializeObject<stk>(inn);
                // {"ResultDesc":"Validaion Service request accepted succesfully","ResultCode":"0"}
                Response r = new Response();
                var json = new JavaScriptSerializer().Serialize(r);
              
                Logging.Logging.LogEntryOnFile("stk " + json);
                return json;
            }
        }
        public string QueueTimeOut(Stream request)
        {

            using (var reader = new StreamReader(request))
            {
                string inn = reader.ReadToEnd();

                Logging.Logging.LogEntryOnFile("Timeout " + inn);

                // {"ResultDesc":"Validaion Service request accepted succesfully","ResultCode":"0"}
                Response r = new Response();
                var json = new JavaScriptSerializer().Serialize(r);
                Logging.Logging.LogEntryOnFile("Timeout " + json);
                return json;
            }
        }
        public string Results(Stream request)
        {

            using (var reader = new StreamReader(request))
            {
                string inn = reader.ReadToEnd();

                Logging.Logging.LogEntryOnFile("Results " + inn);

                // {"ResultDesc":"Validaion Service request accepted succesfully","ResultCode":"0"}
                Response r = new Response();
                var json = new JavaScriptSerializer().Serialize(r);
                Logging.Logging.LogEntryOnFile("Results " + json);
                return json;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }

    public class CallbackMetadata
    {
        public List<Item> Item { get; set; }
    }

    public class StkCallback
    {
        public string MerchantRequestID { get; set; }
        public string CheckoutRequestID { get; set; }
        public int ResultCode { get; set; }
        public string ResultDesc { get; set; }
        public CallbackMetadata CallbackMetadata { get; set; }
    }

    public class Body
    {
        public StkCallback stkCallback { get; set; }
    }

    public class stk
    {
        public Body Body { get; set; }
    }
    public class Response {
        public string ResultCode="0";
        public string ResultDesc = "Validation Service request accepted succesfully";
    }
    public partial class C2B
    {
        public string TransactionType;
        public string TransID;
        public string TransTime;
        public string TransAmount;
        public string BusinessShortCode;
        public string BillRefNumber = string.Empty;
        public string InvoiceNumber = string.Empty;
        public string OrgAccountBalance = string.Empty;
        public string ThirdPartyTransID = string.Empty;
        public string MSISDN = string.Empty;
        public string FirstName = string.Empty; public string MiddleName = string.Empty; public string LastName = string.Empty;
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
        public string Certpath = string.Empty;
        public string CertpathCA = string.Empty;
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
    }
   
  
}
