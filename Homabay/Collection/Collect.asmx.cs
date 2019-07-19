using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using PData;
using Newtonsoft.Json;
using Logging;
using PData.MBranchTransactions;
using PData.Groups;
using PData.Constituency;
using PData.MBranchsms;
using PData.MBranch;
using PData.MBranchMembers;
using PData.MbranchApplications;
using PData.MBranchtranstypes;

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
        public M_Branch_Applications_Service Aservice = new M_Branch_Applications_Service();
        public M_Branch_Transactions_Service Tservice = new M_Branch_Transactions_Service();

        public M_Branch_Members_Service Mservice = new M_Branch_Members_Service();

        public M_Branch_transtypes_Service TTservice = new M_Branch_transtypes_Service();

        public M_Branch_Groups_Service Gservice = new M_Branch_Groups_Service();
        public Constituency_Service Cservice = new Constituency_Service();
        public  Mpesa.Mpesa_Service mpesa_Service = new Mpesa.Mpesa_Service();
        public Sms_Service Sservice = new Sms_Service();

        public MBranch mbranch = new MBranch();

        public Collect()
        {
            string path = Server.MapPath("~/Settings.txt");
            ServerSetting.getsettings(path);
            Logging.Logging.logpath = ServerSetting.logpath;
            cd = new System.Net.NetworkCredential(ServerSetting.user, ServerSetting.pass, ServerSetting.domain);
            Aservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/M_Branch_Applications",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            Aservice.Credentials = cd;
            Aservice.PreAuthenticate = true;

            Tservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/M_Branch_Transactions",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            Tservice.Credentials = cd;
            Tservice.PreAuthenticate = true;

            Mservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/M_Branch_Members",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            Mservice.Credentials = cd;
            Mservice.PreAuthenticate = true;

            Cservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Constituency",
                                     ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            Cservice.Credentials = cd;
            Cservice.PreAuthenticate = true;

            Gservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/M_Branch_Groups",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            Gservice.Credentials = cd;
            Gservice.PreAuthenticate = true;

            Sservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Sms",
                       ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            Sservice.Credentials = cd;
            Sservice.PreAuthenticate = true;

            mbranch.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/MBranch",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            mbranch.Credentials = cd;
            mbranch.PreAuthenticate = true;

            TTservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/M_Branch_transtypes",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            TTservice.Credentials = cd;
            TTservice.PreAuthenticate = true;

            mpesa_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Mpesa",
                                     ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            mpesa_Service.Credentials = cd;
            mpesa_Service.PreAuthenticate = true;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void groups()
        {

            var response = string.Empty;

            try
            {

                response = new JavaScriptSerializer().Serialize(Gservice.ReadMultiple(new M_Branch_Groups_Filter[] { }, null, 10000).ToList());


            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Constituency()
        {

            var response = string.Empty;

            try
            {

                response = new JavaScriptSerializer().Serialize(Cservice.ReadMultiple(new Constituency_Filter[] { }, null, 10000).ToList());


            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            Context.Response.Output.Write(response);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Transtypes()
        {
            var response = string.Empty;
            try
            {

                response = new JavaScriptSerializer().Serialize(TTservice.ReadMultiple(new M_Branch_transtypes_Filter[] { }, null, 10000).ToList());


            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void members(string division)
        {
            var response = string.Empty;

            try
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer() { MaxJsonLength = Int32.MaxValue };
                response = jsSerializer.Serialize(Mservice.ReadMultiple(new M_Branch_Members_Filter[] { new M_Branch_Members_Filter { Criteria = division, Field = M_Branch_Members_Fields.Division_Department } }, null, 5000).ToList());


            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);


            }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void memberss(string division)
        {
            var response = string.Empty;
            m n;
            try
            {
                n = JsonConvert.DeserializeObject<m>(division);
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer() { MaxJsonLength = Int32.MaxValue };
                response = jsSerializer.Serialize(Mservice.ReadMultiple(new M_Branch_Members_Filter[] { new M_Branch_Members_Filter { Criteria = n.division, Field = M_Branch_Members_Fields.Division_Department } }, n.key, 200).ToList());


            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);


            }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void allmembers()
        {
            var response = string.Empty;
            try
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer() { MaxJsonLength = Int32.MaxValue };
                response = jsSerializer.Serialize(Mservice.ReadMultiple(new M_Branch_Members_Filter[] { }, null, 5000).ToList());
            }
            catch (Exception ex)
            {
                response = ex.Message;
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

                response = new JavaScriptSerializer().Serialize(Aservice.ReadMultiple(new M_Branch_Applications_Filter[] { }, null, 10000).ToList());


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
            M_Branch_Members member;
            try
            {
                member = JsonConvert.DeserializeObject<M_Branch_Members>(data);

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
            String response = string.Empty;
            M_Branch_Transactions collection;
            try
            {
                collection = JsonConvert.DeserializeObject<M_Branch_Transactions>(data);
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
                }
                catch (Exception ex)
                {
                    Logging.Logging.ReportError(ex);
                }
                //  if ((Farmer(collection.Transporter) != null) && (Farmer(collection.Farmers_Number) != null)) { 
                var c = Tservice.ReadMultiple(new M_Branch_Transactions_Filter[] { new M_Branch_Transactions_Filter { Criteria = collection.Document_No, Field = M_Branch_Transactions_Fields.Document_No } }, null, 1);
                if (c.Count() == 0)
                    Tservice.Create(ref collection);



                try
                {
                    try
                    {
                        // sendsms();
                    }
                    catch (Exception e)
                    {
                        Logging.Logging.ReportError(e);

                    }

                    // mbranch.Post();


                }
                catch (Exception ex)
                {
                    Logging.Logging.ReportError(ex);
                }
                //}

                // Sendsms.Sms sms = new Sendsms.Sms();
                //  var f = Farmer(collection.Farmers_Number);
                //  if (f!=null)
                //  if ( ! string.IsNullOrEmpty(f.Phone_No))
                //CUtilities.LogEntryOnFile( sms.Sendsms(collection.Collection_Number,f.Phone_No,string.Format("Collection No: {0}\nKg collected: {1}\nCummulative: {2}",collection.Collection_Number,collection.Kg_Collected,f.Cummulative),"10000"));

                response = new JavaScriptSerializer().Serialize(collection);
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
            Context.Response.Output.Write(response);
        }

       
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetPaybill()
        {
            string response = string.Empty;
            List<mpesa> m = new List<mpesa>();
            try
            {
                var c = mpesa_Service.ReadMultiple(new Mpesa.Mpesa_Filter[] { }, null, 0);
                if (c.Count() > 0)
                {
                    foreach (var mm in c)
                    {
                        mpesa mp = new mpesa();
                        mp.acc = mm.A_C_No;
                        mp.phone = mm.Phone;
                        mp.Code = mm.Receipt_No;
                        mp.amount = (double)mm.Paid_In;
                        mp.utilized = (double)mm.Amount_utilized;
                        m.Add(mp);
                    }

                }
                response = new JavaScriptSerializer().Serialize(m);

            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);

            }
            Context.Response.Output.Write(response);
        }

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
                var c = Tservice.ReadMultiple(new M_Branch_Transactions_Filter[] { new M_Branch_Transactions_Filter { Criteria ="<>"+ v.user, Field = M_Branch_Transactions_Fields.Agent_Code }, new M_Branch_Transactions_Filter { Criteria = d.Date.ToShortDateString() , Field = M_Branch_Transactions_Fields.Transaction_Date } }, null, 0).ToList();
                foreach (var cc in c)
                {
                    if (string.IsNullOrEmpty(cc.Date))
                    {
                        cc.Date = cc.Transaction_Date.ToString("dd-MM-yyyy");
                        cc.Time = cc.Transaction_Time.ToString("HH:mm:ss");
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

        private void sendsms()
        {
            try
            {
                Sendsms.send.Service1 Ssms = new Sendsms.send.Service1();
                Sendsms.send.sms ss = new Sendsms.send.sms();
                ss.client = "HBCWSACCO";


                var sms = Sservice.ReadMultiple(new Sms_Filter[] { new Sms_Filter { Criteria = "No", Field = Sms_Fields.Sent_To_Server } }, null, 5);
                foreach (var ssave in sms)
                {
                    var s = ssave;
                    try
                    {

                        if (!string.IsNullOrEmpty(s.Telephone_No) || s.Telephone_No.Length < 9)
                        {
                            ss.Sourceid = s.Entry_No.ToString();
                            ss.phone = "254" + s.Telephone_No.Substring(s.Telephone_No.Length - 9);
                            ss.text = s.SMS_Message;
                            ss = Ssms.Sendsms(ss);

                            if (ss.results.code == 0)
                            {
                                s.Sent_To_Server = Sent_To_Server.Yes;
                                s.Sent_To_ServerSpecified = true;
                                s.Date_Sent_to_Server = DateTime.Now.Date;
                                s.Date_Sent_to_ServerSpecified = true;
                                s.Time_Sent_To_Server = DateTime.Now;
                                s.Time_Sent_To_ServerSpecified = true;
                                s.Bulk_SMS_Balance = ss.balance;
                            }
                            else
                            {
                                s.Sent_To_Server = Sent_To_Server.Failed;
                                s.Sent_To_ServerSpecified = true;
                                s.Date_Sent_to_Server = DateTime.Now.Date;
                                s.Date_Sent_to_ServerSpecified = true;
                                s.Time_Sent_To_Server = DateTime.Now;
                                s.Time_Sent_To_ServerSpecified = true;
                                s.Comments = ss.results.Description;
                            }


                        }
                        else
                        {
                            s.Sent_To_Server = Sent_To_Server.Failed;
                            s.Sent_To_ServerSpecified = true;
                            s.Date_Sent_to_Server = DateTime.Now.Date;
                            s.Date_Sent_to_ServerSpecified = true;
                            s.Time_Sent_To_Server = DateTime.Now;
                            s.Time_Sent_To_ServerSpecified = true;
                            s.Comments = "Invalid telephone";
                        }
                        Sservice.Update(ref s);
                    }
                    catch (Exception ex)
                    {
                        s.Sent_To_Server = Sent_To_Server.Failed;
                        s.Sent_To_ServerSpecified = true;
                        s.Date_Sent_to_Server = DateTime.Now.Date;
                        s.Date_Sent_to_ServerSpecified = true;
                        s.Time_Sent_To_Server = DateTime.Now;
                        s.Time_Sent_To_ServerSpecified = true;
                        s.Comments = "Can't send sms";
                        Sservice.Update(ref s);
                        Logging.Logging.ReportError(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }


        }
        public class getdata
        {
            public string firstdate;
            public string LastDate;
            public string user;

        }
        public class m
    {
        public String key = null;
        public String division = "";

    }
        public class mpesa
        {
            public string Code;
            public double amount;
            public string phone;
            public string acc;
            public double utilized;
        }
        public class Results
        {
            public int code = 0;
            public string error_Desc;
        }
    }
   
}