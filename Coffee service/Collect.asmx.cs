using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

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
        public Items.Items_Service itemservice = new Items.Items_Service();
        public ItemEntries.Item_entries_Service itementries = new ItemEntries.Item_entries_Service();
        public Stores.Stores_Service storeservice = new Stores.Stores_Service();
        public Collect()
        {

            string path = Server.MapPath("~/Settings.txt");
            ServerSetting.getsettings(path);
            Logging.Logging.logpath = CUtilities.logpath;

            cd = new System.Net.NetworkCredential(ServerSetting.user, ServerSetting.pass, ServerSetting.domain);
            vservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Vendor",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            vservice.Credentials = cd;
            vservice.PreAuthenticate = true;
            Collservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Collection",
              ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            Collservice.Credentials = cd;
            Collservice.PreAuthenticate = true;

            itemservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Items",
                          ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            itemservice.Credentials = cd;
            itemservice.PreAuthenticate = true;

            itementries.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Item_entries",
                                      ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            itementries.Credentials = cd;
            itementries.PreAuthenticate = true;


            storeservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Stores",
                                   ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, 7047);
            storeservice.Credentials = cd;
            storeservice.PreAuthenticate = true;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Vendor.Vendor GetFarmer(Vendor.Vendor data)
        {

            var response = new Vendor.Vendor();
            Vendor.Vendor v = data;
            try
            {
                response = vservice.Read(v.No);
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            return response;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List< Vendor.Vendor> UpdateFarmer(List< Vendor.Vendor> data)
        {

            var response = new Vendor.Vendor();
            List< Vendor.Vendor> v = data;
            try
            {
                foreach (var item in v)
                {
                    response = vservice.Read(item.No);
                    if (response != null)
                    {
                        try
                        {
                            response.Name = item.Name;
                            response.Phone_No = item.Phone_No;
                            response.ID_No = item.ID_No;
                            vservice.Update(ref response);
                            item.Code = 0;
                        }
                        catch (Exception ex)
                        {
                            item.Code = -1;
                            item.desc = ex.Message;
                            Logging.Logging.ReportError(ex);
                        }

                    }
                    else
                    {
                        try
                        {
                            Vendor.Vendor nv = new Vendor.Vendor();
                            nv.No = item.No;
                            nv.Name = item.Name;
                            nv.Phone_No = item.Phone_No;
                            nv.ID_No = item.ID_No;
                            nv.Account_Category = item.Account_Category;
                            nv.Account_CategorySpecified = true;
                            vservice.Create(ref nv);
                            item.Code = 0;
                        }
                        catch (Exception ex)
                        {
                            item.Code = -1;
                            item.desc = ex.Message;
                            Logging.Logging.ReportError(ex);
                        }
                    }
                }
                data = v;
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            return data;
        }
        [WebMethod]
        public List<Items.Items> Items()
        {
            var response = new List<Items.Items>();
            try
            {
                response = itemservice.ReadMultiple(new Items.Items_Filter[] { }, null, 0).ToList();
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            return response;
        }
        [WebMethod]
        public List<ItemEntries.Item_entries> ItemsEntries()
        {
            var response = new List<ItemEntries.Item_entries>();
            try
            {
                response = itementries.ReadMultiple(new ItemEntries.Item_entries_Filter[] { }, null, 0).ToList();
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            return response;
        }
        [WebMethod]
        public List<Vendor.Vendor> Farmers(Vendor.Vendor data)
        {
            var response = new List<Vendor.Vendor>();
            Vendor.Vendor v = data;
            try
            {
                response = vservice.ReadMultiple(new Vendor.Vendor_Filter[] { new Vendor.Vendor_Filter { Criteria = "<>''", Field = Vendor.Vendor_Fields.No } }, null, 0).ToList();
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            return response;
        }
        [WebMethod]
        public List<Vendor.Vendor> Farmersbyfactory(String factory)
        {
            var response = new List<Vendor.Vendor>();
            try
            {
                response = vservice.ReadMultiple(new Vendor.Vendor_Filter[] { new Vendor.Vendor_Filter { Criteria = "<>''", Field = Vendor.Vendor_Fields.No }, new Vendor.Vendor_Filter { Criteria = factory, Field = Vendor.Vendor_Fields.Factory } }, null, 0).ToList();
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
            }
            return response;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<DataCollection.Collection> GetCollections(string factory)
        {
            var response = new List<DataCollection.Collection>();
            try
            {
                response = Collservice.ReadMultiple(new DataCollection.Collection_Filter[] { new DataCollection.Collection_Filter { Criteria = factory, Field = DataCollection.Collection_Fields.Factory } }, null, 10000).ToList();
            }
            catch (Exception ex)
            { CUtilities.LogEntryOnFile(ex.Message); }
            return response;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<DataCollection.Collection> Collections(List<DataCollection.Collection> data)
        {
            CreateXML(data);
            String response = string.Empty;
            List<DataCollection.Collection> collection = data;
            foreach (DataCollection.Collection c in collection)
            {
                var ccc = c;
                try
                {
                    try { 
                    //create account
                    var f = vservice.Read(c.Farmers_Number);

                    if (f==null)
                    {
                        Vendor.Vendor v = new Vendor.Vendor();
                        v.No = c.Farmers_Number;
                        v.Name = c.Farmers_Name;
                        v.Factory = c.Factory;
                        v.Account_Category = Vendor.Account_Category.Single;
                        vservice.Create(ref v);

                    }
                    }
                    catch (Exception e) { Logging.Logging.ReportError(e); }
                    var cc = Collservice.Read(c.Farmers_Number, c.Collections_Date, c.Collection_Number, c.Coffee_Type);
                    if (cc == null)
                        Collservice.Create(ref ccc);
                    c.Code = 0;
                    // Sendsms.Sms sms = new Sendsms.Sms();
                    //  var f = Farmer(collection.Farmers_Number);
                    //  if (f!=null)
                    //  if ( ! string.IsNullOrEmpty(f.Phone_No))
                    //CUtilities.LogEntryOnFile( sms.Sendsms(collection.Collection_Number,f.Phone_No,string.Format("Collection No: {0}\nKg collected: {1}\nCummulative: {2}",collection.Collection_Number,collection.Kg_Collected,f.Cummulative),"10000"));
                }
                catch (Exception ex)
                {
                    c.Code = -1;
                    c.desc = ex.Message;
                    Logging.Logging.ReportError(ex);
                }
            }
            return collection;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Stores.Stores> SetStores(List<Stores.Stores> data)
        {
            CreateXML(data);
            String response = string.Empty;
            List<Stores.Stores> collection = data;
            foreach (Stores.Stores c in collection)
            {
                var ccc = c;
                try
                {
                    var cc = storeservice.ReadMultiple(new Stores.Stores_Filter[] {new Stores.Stores_Filter{Criteria = c.Source_no.ToString(),Field= Stores.Stores_Fields.Source_no},new Stores.Stores_Filter{Criteria = c.Factory, Field = Stores.Stores_Fields.Factory},new Stores.Stores_Filter{Criteria = c.Receipt_No, Field = Stores.Stores_Fields.Receipt_No}},null,0);

                    if (cc.Count() == 0)
                    {
                        storeservice.Create(ref ccc);
                    }
                    else {
                        ccc.Key = cc.FirstOrDefault().Key;

                        storeservice.Update(ref ccc);
                    }
                        c.Code = 0;
                               }
                catch (Exception ex)
                {
                    c.Code = -1;
                    c.desc = ex.Message;
                    Logging.Logging.ReportError(ex);
                }
            }
            return collection;
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
            { CUtilities.LogEntryOnFile(ex.Message); }
            return v;
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
    }
}