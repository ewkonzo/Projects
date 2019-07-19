using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;
using MClientService.SmobileTransactions;
using MClientService.Stypes;
using MClientService.Customers;
namespace MClientService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Mobile : System.Web.Services.WebService
    {
        public static Bulk.SMS_Service Blkservice = new Bulk.SMS_Service();
        public static Smobile_Service Smobileservice = new Smobile_Service();
        public static SmobileTransactiontypes_Service Stypesservice = new SmobileTransactiontypes_Service();
        public static Customers.Smobilemembers_Service Cservice = new Customers.Smobilemembers_Service();
        private System.Net.NetworkCredential cd;
        public Mobile()
        {
            try
            {
                string path = Server.MapPath("~/Settings.txt");
                ServerSetting.getsettings(path);
                cd = new System.Net.NetworkCredential(ServerSetting.user, ServerSetting.pass, ServerSetting.domain);
                Blkservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/SMS",
               ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, ServerSetting.Port);
                Blkservice.PreAuthenticate = true;
                Blkservice.Credentials = (ICredentials)this.cd;

                Smobileservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Smobile",
               ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, ServerSetting.Port);
                Smobileservice.PreAuthenticate = true;
                Smobileservice.Credentials = (ICredentials)this.cd;

                Stypesservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/SmobileTransactiontypes",
               ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, ServerSetting.Port);
                Stypesservice.PreAuthenticate = true;
                Stypesservice.Credentials = (ICredentials)this.cd;

                Cservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Smobilemembers",
               ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, ServerSetting.Port);
                Cservice.PreAuthenticate = true;
                Cservice.Credentials = (ICredentials)this.cd;
            }
            catch (Exception ex)
            {
                CUtilities.ReportError(ex);
            }
       }
        [WebMethod]
        public List<Bulk.SMS> Sms(int count)
        {
            List<Bulk.SMS> blk = new List<Bulk.SMS>();
            try
            {
                blk = Blkservice.ReadMultiple(new Bulk.SMS_Filter[] { new Bulk.SMS_Filter() { Criteria ="No" , Field = Bulk.SMS_Fields.Delivered } }.ToArray(), null, count).ToList();
            }
            catch (Exception ex)
            {
                CUtilities.ReportError(ex);
            }
            return blk;
        }
        [WebMethod]
        public List<Bulk.SMS> Smsupdate(List<Bulk.SMS> s)
        {
            Bulk.SMS[] blk = s.ToArray();
            try
            {
                Blkservice.UpdateMultiple(ref blk);
            }
            catch (Exception ex)
            {
                CUtilities.ReportError(ex);
            }
            return s;
        }
        [WebMethod]
        public Smobile transactions(Smobile t)
        {
            try
            {

            }
            catch (Exception ex)
            {
                CUtilities.ReportError(ex);
            }
            return t;
        } 
        [WebMethod]
        public List< Smobilemembers> member(string phone)
        {
            List<Smobilemembers> c = null; 
            try
            {
                c = Customer.Getcustomer(phone);
            }
            catch (Exception ex)
            {
                CUtilities.ReportError(ex);
            }
            return c ;
        }
    }
   
}