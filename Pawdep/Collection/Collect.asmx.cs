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
using System.Xml.Serialization;
using System.IO;
using System.Net;

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
        public Members.Members_Service Members_Service = new Members.Members_Service();
        public TransHeader.Trans_Header_Service Trans_Header_Service = new TransHeader.Trans_Header_Service();
        public TransLine.Trans_Line_Service Trans_Line_Service = new TransLine.Trans_Line_Service();
        public Groups.Groups_Service Groups_Service = new Groups.Groups_Service();
        public Mobile.Mobile mobile = new Mobile.Mobile();
        public Mpesa.Mpesa_Service mpesa_Service = new Mpesa.Mpesa_Service();
        public Logins.Logins_Service login_service = new Logins.Logins_Service();
        public Loans.Loans_Service Loans_Service = new Loans.Loans_Service();
        public Advance.Advance_Service Advance_Service = new Advance.Advance_Service();
        public Transactions.PW_Transactions_Service PW_Transactions_Service = new Transactions.PW_Transactions_Service();
        public Advance_issue.Advance_issue_Service advance_Issue_Service = new Advance_issue.Advance_issue_Service();

        public Logging.settings s = new Logging.settings();
        public Collect()
        {
           // createxml();
            string path = Server.MapPath("~/Settings.xml");
            s=s.loadsettings(path);

            System.Security.SecureString accesskey = new System.Security.SecureString();
            cd = new System.Net.NetworkCredential(s.navsettings.Username, s.navsettings.pass, s.navsettings.domain);

            System.Net.CredentialCache myCredentials = new System.Net.CredentialCache();
            NetworkCredential netCred = new NetworkCredential(s.navsettings.Username,s.navsettings.pass,s.navsettings.domain);
           
            Members_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Members",
                          s.navsettings.Server, s.navsettings.Companyname, s.navsettings.Instance, s.navsettings.Port);
            Members_Service.Credentials = cd;
            Members_Service.PreAuthenticate = true;
            
            Trans_Header_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Trans_Header",
                          s.navsettings.Server, s.navsettings.Companyname, s.navsettings.Instance, s.navsettings.Port);
            Trans_Header_Service.Credentials = cd;
            Trans_Header_Service.PreAuthenticate = true;

            Trans_Line_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Trans_Line",
                          s.navsettings.Server, s.navsettings.Companyname, s.navsettings.Instance, s.navsettings.Port);
            Trans_Line_Service.Credentials = cd;
            Trans_Line_Service.PreAuthenticate = true;

            Groups_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Groups",
                                      s.navsettings.Server, s.navsettings.Companyname, s.navsettings.Instance, s.navsettings.Port);
            Groups_Service.Credentials = cd;
            Groups_Service.PreAuthenticate = true;

            Loans_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Loans",
                                      s.navsettings.Server, s.navsettings.Companyname, s.navsettings.Instance, s.navsettings.Port);
            Loans_Service.Credentials = cd;
            Loans_Service.PreAuthenticate = true;

            PW_Transactions_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/PW_Transactions",
                                      s.navsettings.Server, s.navsettings.Companyname, s.navsettings.Instance, s.navsettings.Port);
            PW_Transactions_Service.Credentials = cd;
            PW_Transactions_Service.PreAuthenticate = true;

            Advance_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Advance",
                                      s.navsettings.Server, s.navsettings.Companyname, s.navsettings.Instance, s.navsettings.Port);
            Advance_Service.Credentials = cd;
            Advance_Service.PreAuthenticate = true;

            advance_Issue_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Advance_issue",
                                      s.navsettings.Server, s.navsettings.Companyname, s.navsettings.Instance, s.navsettings.Port);
            advance_Issue_Service.Credentials = cd;
            advance_Issue_Service.PreAuthenticate = true;


            login_service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Logins",
                          s.navsettings.Server, s.navsettings.Companyname, s.navsettings.Instance, s.navsettings.Port);

            //myCredentials.Add(new Uri(login_service.Url), "Basic", netCred);
            //login_service.Credentials = myCredentials;

            login_service.Credentials = cd;
            login_service.PreAuthenticate = true;

            mobile.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/Mobile",
                                     s.navsettings.Server, s.navsettings.Companyname, s.navsettings.Instance, s.navsettings.Port);
            mobile.Credentials = cd;
            mobile.PreAuthenticate = true;

        }
        void createxml()
        {
            Logging.settings d = new Logging.settings();
            Logging.nav ff = new nav();
            ff.Companyname = "kk";
            d.navsettings = ff;
            XmlSerializer xs = new XmlSerializer(typeof(Logging.settings));

            TextWriter txtWriter = new StreamWriter(@"C:\Serialization.xml");

            xs.Serialize(txtWriter, d);

            txtWriter.Close();

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void allmembers(string bookmarkkey)
        {
            var response = string.Empty;
            try
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer() { MaxJsonLength = Int32.MaxValue };
                response = jsSerializer.Serialize(Members_Service.ReadMultiple(new Members.Members_Filter[] { },(string.IsNullOrEmpty(bookmarkkey)? null:bookmarkkey), 1000).ToList());
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
        public void allgroups(string bookmarkkey)
        {
            var response = string.Empty;
            try
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer() { MaxJsonLength = Int32.MaxValue };
                response = jsSerializer.Serialize(Groups_Service.ReadMultiple(new Groups.Groups_Filter[] { }, (string.IsNullOrEmpty(bookmarkkey) ? null : bookmarkkey), 500).ToList());
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
        public void loans(string bookmarkkey)
        {
            var response = string.Empty;
            try
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer() { MaxJsonLength = Int32.MaxValue };
                response = jsSerializer.Serialize(Loans_Service.ReadMultiple(new Loans.Loans_Filter[] { }, (string.IsNullOrEmpty(bookmarkkey) ? null : bookmarkkey), 500).ToList());
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
                response = new JavaScriptSerializer().Serialize(login_service.ReadMultiple(new Logins.Logins_Filter[] { }, null, 10000).ToList());

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
            TransHeader.Trans_Header collection;
            try
            {
                collection = JsonConvert.DeserializeObject<TransHeader.Trans_Header>(data);
           
                //  if ((Farmer(collection.Transporter) != null) && (Farmer(collection.Farmers_Number) != null)) { 
                var c = Trans_Header_Service.ReadMultiple(new TransHeader.Trans_Header_Filter [] { new TransHeader.Trans_Header_Filter { Criteria = collection.Transaction_No, Field = TransHeader.Trans_Header_Fields.Transaction_No } }, null, 1);
                if (c.Count() == 0)
                    Trans_Header_Service.Create(ref collection);

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