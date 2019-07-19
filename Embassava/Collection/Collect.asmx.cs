using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;

using Newtonsoft.Json;
using Logging;
using Collection.Transtypes;

namespace Collection
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Collect : System.Web.Services.WebService
    {
        private System.Net.NetworkCredential cd;
        public Users.Users_Service Aservice = new Users.Users_Service();
        public Transactions.Transactions_Service Tservice = new Transactions.Transactions_Service();
        public Transaction1 .Transactions1_Service Tservice1 = new Transaction1.Transactions1_Service();
        public Members.Members_Service Mservice = new Members.Members_Service();
        public Transtypes_Service TTservice = new Transtypes_Service();
        public Mbranch.Mbranch mbranch = new Mbranch.Mbranch();
        public Vehicles.Vehicles_Service vservice = new Collection.Vehicles.Vehicles_Service();
        public Credits.Credits_Service cservice = new Credits.Credits_Service();
        public Collect()
        {
            string path = Server.MapPath("~/Settings.txt");
            ServerSetting.getsettings(path);
            Logging.Logging.logpath = ServerSetting.logpath;
            cd = new System.Net.NetworkCredential(ServerSetting.user, ServerSetting.pass, ServerSetting.domain);
            Aservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Users",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, ServerSetting.Port);
            Aservice.Credentials = cd;
            Aservice.PreAuthenticate = true;

            Tservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Transactions",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, ServerSetting.Port);
            Tservice.Credentials = cd;
            Tservice.PreAuthenticate = true;

  Tservice1.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Transactions",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, ServerSetting.Port);
            Tservice1.Credentials = cd;
            Tservice1.PreAuthenticate = true;


            Mservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Members",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, ServerSetting.Port);
            Mservice.Credentials = cd;
            Mservice.PreAuthenticate = true;

            mbranch.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/MBranch",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, ServerSetting.Port);
            mbranch.Credentials = cd;
            mbranch.PreAuthenticate = true;

            TTservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Transtypes",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, ServerSetting.Port);
            TTservice.Credentials = cd;
            TTservice.PreAuthenticate = true;


            vservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Vehicles",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, ServerSetting.Port);
            vservice.Credentials = cd;
            vservice.PreAuthenticate = true;

            cservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Credits",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, ServerSetting.Port);
            cservice.Credentials = cd;
            cservice.PreAuthenticate = true;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Transtypes()
        {
            var response = string.Empty;
            try
            {
                response = new JavaScriptSerializer().Serialize(TTservice.ReadMultiple(new Transtypes_Filter[] { }, null, 10000).ToList());
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
            Context.Response.Output.Write(response);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void loans()
        {
            var response = string.Empty;
            try
            {
                response = new JavaScriptSerializer().Serialize(cservice.ReadMultiple(new Credits.Credits_Filter[] { }, null, 10000).ToList());
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void balances()
        {
            var response = "";
            try
            {
               List<Sms> r = new List<Sms>();
                using (var db = new MobileEntities()) {
                     r = db.BulkSms
                       .GroupBy(m=> m.Client)
                       .Select(m=> new Sms {client= m.Key, balance=(double) m.Sum(v=> v.Value)})
                       .OrderByDescending(m=>m.client).ToList();
                }
                response = new JavaScriptSerializer().Serialize(r);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                Logging.Logging.ReportError(ex); }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void addclient(string data)
        {
            results r = new results();
            var response = "";
            try
            {
                Sms c = JsonConvert.DeserializeObject<Sms>(data);
                using (var db = new MobileEntities())
                {
                    var cc = db.Clients.FirstOrDefault(o => o.Client_Code == c.client);
                    if (cc == null)
                    {
                        Client cl = new Client();
                        cl.Client_Code = c.client;
                        cl.Client_Name = c.client;
                        cl.Active = true;
                        db.Clients.Add(cl);

                        db.SaveChanges();
                        BulkSm b = new BulkSm
                        {
                            Source_Id = string.Concat(c.client, DateTime.Now.Ticks.ToString()),
                            Client = c.client,
                            Value = (int)c.balance,
                            Phone = c.client,
                            Datetime = DateTime.Now,
                            Status = 1
                        };
                        db.BulkSms.Add(b);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
                Logging.Logging.ReportError(ex);
            }
            response = new JavaScriptSerializer().Serialize(r);
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void addsms(string data)
        { results r = new results();
            var response = "";
            try
            {
               Sms c = JsonConvert.DeserializeObject<Sms>(data);
      
                using (var db = new MobileEntities())
                {
                    BulkSm b = new BulkSm { 
                    Source_Id=string.Concat(c.client, DateTime.Now.Ticks.ToString()),
                    Client = c.client,
                    Value =(int) c.balance,
                    Phone = c.client,
                    Datetime = DateTime.Now,
                    Status =1
                                        };
                    db.BulkSms.Add(b);
                    db.SaveChanges();
                    response = "Sms Updated";
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
                Logging.Logging.ReportError(ex);
            } 
            //response = new JavaScriptSerializer().Serialize(r);
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Vehicles()
        {
            Logging.Logging.LogEntryOnFile(vservice.Url);
            var response = string.Empty;
            try
            {
                response = new JavaScriptSerializer().Serialize(vservice.ReadMultiple(new Collection.Vehicles.Vehicles_Filter[] { }, null, 10000).ToList());
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void members()
        {
            var response = string.Empty;
            try
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer() { MaxJsonLength = Int32.MaxValue };
                response = jsSerializer.Serialize(Mservice.ReadMultiple(new Members.Members_Filter[] { }, null, 5000).ToList());

            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);


            }
            Context.Response.Output.Write(response);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void logins()
        {
            string response = string.Empty;
            try
            {
                response = new JavaScriptSerializer().Serialize(Aservice.ReadMultiple(new Users.Users_Filter[] { }, null, 10000).ToList());
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void updatemembers(string data)
        {

            Logging.Logging.LogEntryOnFile(data);
            String response = string.Empty;
            Members.Members member;
            try
            {
                member = JsonConvert.DeserializeObject<Members.Members>(data);

                var m = Mservice.Read(member.No);
                if (m != null)
                {
                    m.Phone_No = member.Phone_No;
                    m.ID_No = member.ID_No;

                    Mservice.Update(ref m);
                }

                response = new JavaScriptSerializer().Serialize(m);
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Collections(string data)
        {
            Logging.Logging.LogEntryOnFile(data);
            Logging.Logging.LogEntryOnFile(Tservice.Url);
            String response = string.Empty;
            Transactions.Transactions collection;
            try
            {
                collection = JsonConvert.DeserializeObject<Transactions.Transactions>(data);
                collection.AmountSpecified = true;
                collection.Transaction_TypeSpecified = true;
                try
                {
                    string[] date = collection.Date.Split(new char[] { '-' });
                    DateTime d = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                    collection.Transaction_Date = d;
                    collection.Transaction_DateSpecified = true;

                    string[] time = collection.Time.Split(new char[] { ':' });
                    DateTime t = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                    collection.Transaction_Time = t;
                    collection.Transaction_TimeSpecified = true;

                    collection.Creation_time = t;
                    collection.Creation_timeSpecified = true;
                }
                catch (Exception ex)
                {
                    Logging.Logging.ReportError(ex);
                }
                var c = Tservice.ReadMultiple(new Transactions.Transactions_Filter[] { new Transactions.Transactions_Filter { Criteria = collection.Document_No, Field = Transactions.Transactions_Fields.Document_No } }, null, 1);
                if (c.Count() == 0)
                    Tservice.Create(ref collection);
                else
                    Logging.Logging.LogEntryOnFile("Transaction exists: " + collection.Document_No);
                response = new JavaScriptSerializer().Serialize(collection);
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            Context.Response.Output.Write(response);
        }

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void Collections1(string data)
        //{
        //    Logging.Logging.LogEntryOnFile(data);
        //    Logging.Logging.LogEntryOnFile(Tservice.Url);
        //    String response = string.Empty;
        //    Transaction1.Transactions1 collection;
        //    try
        //    {
        //        collection = JsonConvert.DeserializeObject<Transaction1.Transactions1>(data);
        //        collection.AmountSpecified = true;
        //        collection.Transaction_TypeSpecified = true;
        //        try
        //        {
        //            string[] date = collection.Date.Split(new char[] { '-' });
        //            DateTime d = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
        //            collection.Transaction_Date = d;
        //            collection.Transaction_DateSpecified = true;

        //            string[] time = collection.Time.Split(new char[] { ':' });
        //            DateTime t = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
        //            collection.Transaction_Time = t;
        //            collection.Transaction_TimeSpecified = true;

        //            collection.Creation_time = t;
        //            collection.Creation_timeSpecified = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            Logging.Logging.ReportError(ex);
        //        }
        //        var c = Tservice1.ReadMultiple(new Transaction1.Transactions1_Filter[] { new Transaction1.Transactions1_Filter { Criteria = collection.Document_No, Field = Transaction1 .Transactions1_Fields.Document_No } }, null, 1);
        //        if (c.Count() == 0)
        //            Tservice1.Create(ref collection);
        //        else
        //            Logging.Logging.LogEntryOnFile("Transaction exists: " + collection.Document_No);
        //        response = new JavaScriptSerializer().Serialize(collection);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logging.Logging.ReportError(ex);
        //    }
        //    Context.Response.Output.Write(response);
        //}
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetCollections(string data)
        {
            Logging.Logging.LogEntryOnFile(data);
            string response = string.Empty;
            getdata v = null;
            try
            {
                v = JsonConvert.DeserializeObject<getdata>(data);
                string[] date = v.firstdate.Split(new char[] { '-' });
                DateTime d = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                //string[] date2 = v.LastDate.Split(new char[] { '-' });
                //DateTime d2 = new DateTime(int.Parse(date2[2]), int.Parse(date2[1]), int.Parse(date2[0]));
                var c = Tservice.ReadMultiple(new Transactions.Transactions_Filter[] { new Transactions.Transactions_Filter { Criteria =  v.user, Field = Transactions.Transactions_Fields.Loan_No }, new Transactions.Transactions_Filter { Criteria = d.Date.ToShortDateString(), Field = Transactions.Transactions_Fields.Transaction_Date } }, null, 0).ToList();
                foreach (var cc in c)
                {
                    if (string.IsNullOrEmpty(cc.Date))
                    {
                        cc.Date = cc.Transaction_Date.ToString("dd-MM-yyyy");
                        cc.Time = cc.Creation_time.ToString("HH:mm:ss");
                    }
                }
                response = new JavaScriptSerializer().Serialize(c);
            }
            catch (Exception ex)

            {

                Logging.Logging.LogEntryOnFile(ex.Message);
                Logging.Logging.LogEntryOnFile(ex.Source);
                Logging.Logging.LogEntryOnFile(ex.StackTrace);

            }
            Context.Response.Output.Write(response);
        }
    }
    public class getdata
    {
        public string firstdate;
        public string LastDate;
        public string user;

    }
}
namespace Collection.Transactions
{
    public partial class Transactions
    {
        public string Date;
        public string Time;
    }
}

namespace Collection.Transaction1
{
    public partial class Transactions1
    {
        public string Date;
        public string Time;
    }
}