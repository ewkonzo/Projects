using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using static Collection.Collect;

namespace Collection
{
    /// <summary>
    /// Summary description for Soap
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Soap : System.Web.Services.WebService
    {
        private System.Net.NetworkCredential cd;
        public Mpesa.Mpesa_Service mpesa_Service = new Mpesa.Mpesa_Service();
        public Logging.settings s= new Logging.settings();
        public Soap()
        {
            string path = Server.MapPath("~/Settings.xml");
           s= s.loadsettings(path);
           // s.loadsettings(path);
            System.Security.SecureString accesskey = new System.Security.SecureString();

            cd = new System.Net.NetworkCredential(s.navsettings.Username, s.navsettings.pass, s.navsettings.domain);

            mpesa_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Mpesa",
                                     s.navsettings.Server, s.navsettings.Companyname, s.navsettings.Instance, s.navsettings.Port);
            mpesa_Service.Credentials = cd;
            mpesa_Service.PreAuthenticate = true;
        }
        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Results Paybill(Mpesa.Mpesa data)
        {
            Results response = new Results();
            // string d = string.Empty;
            try
            {
                
                var c = mpesa_Service.Read(data.Receipt_No);
                if (c == null)
                    mpesa_Service.Create(ref data);
                response.code = 0;
                // d = new JavaScriptSerializer().Serialize(response);
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
                response.code = -1;
                response.error_Desc = ex.Message;
            }
            return response;
        }
    }
}
