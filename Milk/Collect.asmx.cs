using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

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
        public Vendor.Vendor_Service vservice = new Vendor.Vendor_Service();
        public DataCollection.Collection_Service Collservice = new DataCollection.Collection_Service();
        public Routes.Routes_Service routeservice = new Routes.Routes_Service();
        public Troutes.Troutes_Service trouteservice = new Troutes.Troutes_Service();
        public TList.Tlist_Service tlistservice = new TList.Tlist_Service();
        public Flist.Flist_Service flistservice = new Flist.Flist_Service();
        public Users.Users_Service userservice = new Users.Users_Service();
        public Collect()
        {
         string   path = Server.MapPath("~/Settings.txt");
            ServerSetting.getsettings(path);

            cd = new System.Net.NetworkCredential(ServerSetting.user, ServerSetting.pass, ServerSetting.domain);
            vservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Vendor",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            vservice.Credentials = cd;
            vservice.PreAuthenticate = true;

            Collservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Collection",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            Collservice.Credentials = cd;
            Collservice.PreAuthenticate = true;

            routeservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Routes",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            routeservice.Credentials = cd;
            routeservice.PreAuthenticate = true;

            trouteservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Troutes",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            trouteservice.Credentials = cd;
            trouteservice.PreAuthenticate = true;

            tlistservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Tlist",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            tlistservice.Credentials = cd;
            tlistservice.PreAuthenticate = true;

flistservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Flist",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            flistservice.Credentials = cd;
            flistservice.PreAuthenticate = true;

            userservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Users",
                        ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            userservice.Credentials = cd;
            userservice.PreAuthenticate = true;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetFarmer(string data)
        {
            CUtilities.LogEntryOnFile(data);
            string response = string.Empty;
            Vendor.Vendor v = null;
            try
            {
                v = JsonConvert.DeserializeObject<Vendor.Vendor>(data);
                response = new JavaScriptSerializer().Serialize(vservice.Read(v.No));
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Route()
        {
            string response = string.Empty;
            try
            {
                response = new JavaScriptSerializer().Serialize(routeservice.ReadMultiple(new Routes.Routes_Filter[] { }, null, 200).ToList());
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void TRoute()
        {
            string response = string.Empty;
            try
            {
                response = new JavaScriptSerializer().Serialize(trouteservice.ReadMultiple(new Troutes.Troutes_Filter[] { }, null, 0).ToList());
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Users(string factory)
        {
            string response = string.Empty;
            try
            {
                response = new JavaScriptSerializer().Serialize(userservice.ReadMultiple(new Users.Users_Filter[] { new Collection.Users.Users_Filter {Criteria = factory,Field =    Collection.Users.Users_Fields.Factory } }, null, 200).ToList());
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            Context.Response.Output.Write(response);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void updateUsers(string data)
        {
            Users.Users u = null;
            string response = string.Empty;
            try
            {
                u = JsonConvert.DeserializeObject<Users.Users>(data);
                var user = userservice.Read(u.User);
                if (user != null)
                {
                    user.Password = u.Password;
                    user.Password_Changed = u.Password_Changed;
                    user.Password_ChangedSpecified = true;
                    userservice.Update(ref user);
                    response = new JavaScriptSerializer().Serialize(user);
                }
              
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Transporters(string data)
        {
            CUtilities.LogEntryOnFile(data);
            string response=string.Empty;
            Vendor.Vendor v = null;
            try
            {
                v = JsonConvert.DeserializeObject<Vendor.Vendor>(data);
                response = new JavaScriptSerializer().Serialize(vservice.ReadMultiple(new Vendor.Vendor_Filter[] { new Vendor.Vendor_Filter { Criteria = "Transporter", Field = Vendor.Vendor_Fields.Creditor_Type }, new Vendor.Vendor_Filter { Criteria = v.No, Field = Vendor.Vendor_Fields.No } }, null, 0));
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            Context.Response.Output.Write(response);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Transporter()
        {        
            string response = string.Empty;
                     try
            {
              response = new JavaScriptSerializer().Serialize(vservice.ReadMultiple(new Vendor.Vendor_Filter[] { new Vendor.Vendor_Filter { Criteria = "Transporter", Field = Vendor.Vendor_Fields.Creditor_Type } }, null, 0));
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Farmers(string data)
        {
            CUtilities.LogEntryOnFile(data);
            string response = string.Empty;
            Vendor.Vendor v = null;
            try
            {
                //, new Vendor.Vendor_Filter { Criteria = v.No, Field = Vendor.Vendor_Fields.Transpoter } }
                vservice.Timeout = 600000;
               //v = JsonConvert.DeserializeObject<Vendor.Vendor>(data);
                var f = vservice.ReadMultiple(new Vendor.Vendor_Filter[] { new Vendor.Vendor_Filter { Criteria = "Farmer|Transporter", Field = Vendor.Vendor_Fields.Creditor_Type } }, null, 30000).ToList();
                //foreach (var vv in f)
                //{
                //    double cumm = 0;
                //    var c = GetCollection(vv.No);
                //    foreach (var cc in c)
                //    {
                //        if ((cc.Collections_Date.Month == DateTime.Now.Month) && (cc.Collections_Date.Year == DateTime.Now.Year))
                //        {
                //            cumm += (double)cc.Kg_Collected;
                //        }
                //    }
                //    vv.Cummulative =(decimal) cumm;
                //}
                response = new JavaScriptSerializer().Serialize(f);
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void TFarmers(string data)
        {
            CUtilities.LogEntryOnFile(data);
            string response = string.Empty;
            Vendor.Vendor v = null;
            try
            {
                //,new Vendor.Vendor_Filter { Criteria = v.No, Field = Vendor.Vendor_Fields.Transpoter } }
                vservice.Timeout = 600000;
                v = JsonConvert.DeserializeObject<Vendor.Vendor>(data);
                var f = vservice.ReadMultiple(new Vendor.Vendor_Filter[] { new Vendor.Vendor_Filter { Criteria = "Farmer", Field = Vendor.Vendor_Fields.Creditor_Type }, new Vendor.Vendor_Filter { Criteria = v.No, Field = Vendor.Vendor_Fields.Transpoter } }, null, 30000).ToList();
                //foreach (var vv in f)
                //{
                //    double cumm = 0;
                //    var c = GetCollection(vv.No);
                //    foreach (var cc in c)
                //    {
                //        if ((cc.Collections_Date.Month == DateTime.Now.Month) && (cc.Collections_Date.Year == DateTime.Now.Year))
                //        {
                //            cumm += (double)cc.Kg_Collected;
                //        }
                //    }
                //    vv.Cummulative =(decimal) cumm;
                //}
                response = new JavaScriptSerializer().Serialize(f);
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            Context.Response.Output.Write(response);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetCollections(string data)
        {
            CUtilities.LogEntryOnFile(data);
            string response = string.Empty;
            getdata v = null;
            try
            {
                v = JsonConvert.DeserializeObject<getdata>(data);
                string[] date = v.firstdate.Split(new char[] { '-' });
                DateTime d = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));

                string[] date2 = v.LastDate.Split(new char[] { '-' });
                DateTime d2 = new DateTime(int.Parse(date2[2]), int.Parse(date2[1]), int.Parse(date2[0]));
                var c = Collservice.ReadMultiple(new DataCollection.Collection_Filter[] { new DataCollection.Collection_Filter { Criteria = v.route, Field = DataCollection.Collection_Fields.Transporter }, new DataCollection.Collection_Filter { Criteria = "Farmer", Field = DataCollection.Collection_Fields.Creditor_Type }, new DataCollection.Collection_Filter { Criteria = d.Date.ToShortDateString() + ".." + d2.Date.ToShortDateString(), Field = DataCollection.Collection_Fields.Collections_Date } }, null, 0).ToList();
                foreach (var cc in c)
                {
                    if (string.IsNullOrEmpty(cc.Date))
                    {
                        cc.Date = cc.Collections_Date.ToString("dd-MM-yyyy");
                        cc.Time = cc.Collection_time.ToString("HH:mm:ss");
                    }
                }
                response = new JavaScriptSerializer().Serialize(c);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.Source);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            Context.Response.Output.Write(response);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void TransporterData(string data)
        {
            CUtilities.LogEntryOnFile(data);
            string response = string.Empty;
            gettrunsporterdata v = null;
            try
            {
                List<Transportertrans> t = new List<Transportertrans>();
                List<TList.Tlist> c = new List<TList.Tlist>();
                if (!data.Equals(""))
                {
                    v = JsonConvert.DeserializeObject<gettrunsporterdata>(data);
                    string[] date = v.fromdate.Split(new char[] { '-' });
                    DateTime d = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));

                    string[] date2 = v.ToDate.Split(new char[] { '-' });
                    DateTime d2 = new DateTime(int.Parse(date2[2]), int.Parse(date2[1]), int.Parse(date2[0]));

                    c = tlistservice.ReadMultiple(new TList.Tlist_Filter[] { new TList.Tlist_Filter { Criteria = d.Date.ToShortDateString() + ".." + d2.Date.ToShortDateString(), Field = TList.Tlist_Fields.Collections_Date } }, null, 0).ToList();
                }
                else
                    c = tlistservice.ReadMultiple(new TList.Tlist_Filter[] { }, null, 0).ToList();
                foreach (var cc in c)
                {
                    Transportertrans tt = new Transportertrans();
                    tt.Collections_Date = cc.Collections_Date.ToString("dd-MM-yyyy");
                    tt.Collection_time = cc.Collection_time.ToString("HH:mm:ss");
                    tt.Transporter_Name = cc.Farmers_Name;
                    tt.Transporter_no = cc.Farmers_Number;
                    tt.Route = cc.Factory;
                    tt.Colling_Plant = cc.Colling_Plant;
                    tt.Kg_Collected = cc.Kg_Collected;
                    tt.Collection_Number = cc.Collection_Number;
                    t.Add(tt);
                }
                response = new JavaScriptSerializer().Serialize(t);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.Source);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            Context.Response.Output.Write(response);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void FarmerData(string data)
        {
            CUtilities.LogEntryOnFile(data);
            string response = string.Empty;
            gettrunsporterdata v = null;
            try
            {
                List<Farmertrans> t = new List<Farmertrans>();
                List<Flist.Flist> c = new List<Flist.Flist>();
                if (!data.Equals(""))
                {
                    v = JsonConvert.DeserializeObject<gettrunsporterdata>(data);
                    string[] date = v.fromdate.Split(new char[] { '-' });
                    DateTime d = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));

                    string[] date2 = v.ToDate.Split(new char[] { '-' });
                    DateTime d2 = new DateTime(int.Parse(date2[2]), int.Parse(date2[1]), int.Parse(date2[0]));

                    c = flistservice.ReadMultiple(new Flist.Flist_Filter[] { new Flist.Flist_Filter { Criteria = d.Date.ToShortDateString() + ".." + d2.Date.ToShortDateString(), Field = Flist.Flist_Fields.Collections_Date } }, null, 0).ToList();
                }
                else
                    c = flistservice.ReadMultiple(new Flist.Flist_Filter[] { }, null, 0).ToList();
                foreach (var cc in c)
                {
                    Farmertrans tt = new Farmertrans();
                    tt.Collections_Date = cc.Collections_Date.ToString("dd-MM-yyyy");
                    tt.Collection_time = cc.Collection_time.ToString("HH:mm:ss");
                    tt.Name = cc.Farmers_Name;
                    tt.No = cc.Farmers_Number;
                    tt.Route = cc.Factory;
                    tt.Transporter = cc.Transporter;
                    tt.Kg_Collected = cc.Kg_Collected;
                    tt.Collection_Number = cc.Collection_Number;
                    t.Add(tt);
                }
                response = new JavaScriptSerializer().Serialize(t);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.Source);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            Context.Response.Output.Write(response);
        }
      
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<DataCollection. Collection> GetCollection(string No)
        {
            string response = string.Empty;
            List < DataCollection.Collection > c= new List<DataCollection.Collection>();
            try
            {
                 c = Collservice.ReadMultiple(new DataCollection.Collection_Filter[] { new DataCollection.Collection_Filter { Criteria = No, Field = DataCollection.Collection_Fields.Farmers_Number } }, null, 10000).ToList();
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            return c;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Collections(string data)
        {
            CUtilities.LogEntryOnFile(data);
            String response = string.Empty;
            DataCollection.Collection collection;
            try
            {
                collection = JsonConvert.DeserializeObject<DataCollection.Collection>(data);
                collection.Coffee_Type = "MILK";
                collection.Kg_CollectedSpecified = true;
                try
                {
                    string[] date = collection.Date.Split(new char[] { '-' });
                    DateTime d = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                    collection.Collections_Date = d;
                    collection.Collections_DateSpecified = true;
                    string[] time = collection.Time.Split(new char[] { ':' });
                    DateTime t = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                    collection.Collection_time = t;
                    collection.Collection_timeSpecified = true;
                }
                catch (Exception ex)
                {
                    CUtilities.LogEntryOnFile(ex.Message);
                    CUtilities.ReportError(ex);
                }
                //  if ((Farmer(collection.Transporter) != null) && (Farmer(collection.Farmers_Number) != null)) { 
                var c = Collservice.Read(collection.Farmers_Number, collection.Collections_Date, collection.Collection_Number, collection.Coffee_Type);
                if (c == null)
                    Collservice.Create(ref collection);
                //}

                //Sendsms.Sms sms = new Sendsms.Sms();
                //var f = Farmer(collection.Farmers_Number);
                //if (f != null)
                //    if (!string.IsNullOrEmpty(f.Phone_No))
                //        CUtilities.LogEntryOnFile(sms.Sendsms(collection.Collection_Number, f.Phone_No, string.Format("Collection No: {0}\nKg collected: {1}\nCummulative: {2}", collection.Collection_Number, collection.Kg_Collected, f.Cummulative), "10000"));
                response = new JavaScriptSerializer().Serialize(collection);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.ReportError(ex);
            }
            Context.Response.Output.Write(response);
        }
       public Vendor.Vendor Farmer(string No)
        {
           string response = string.Empty;
            Vendor.Vendor v = null;
            try
            {
                v = vservice.Read(No);
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);

                CUtilities.LogEntryOnFile(ex.StackTrace);
                CUtilities.LogEntryOnFile(ex.Source);
            }
            return v;
        }
    }
    public  class getdata
    {
        public string firstdate;
        public string LastDate;
        public string route;

    }  public  class gettrunsporterdata
    {
        public string fromdate;
        public string ToDate;
 
    }
    public  class Transportertrans
    {
        public string Transporter_no;
       
        public string Transporter_Name;

        public string Collections_Date;
      
        public decimal Kg_Collected;
      
        public string Route;

        public string Collection_time;
       
        public string Colling_Plant;

        public string Collection_Number;
       
    }
    public class Farmertrans
    {
        public string No;

        public string Name;

        public string Collections_Date;

        public decimal Kg_Collected;

        public string Route;

        public string Collection_time;

        public string Transporter;

        public string Collection_Number;

    }
}