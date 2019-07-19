using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace notifyQueueTimeout
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    //[WebService(Namespace = "http://172.31.181.115:35070/DataSync/notifyQueueTimeout.asmx")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    //// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //// [System.Web.Script.Services.ScriptService]
    [WebService(Namespace = "http://172.31.181.115:35070/DataSync/notifyQueueTimeout.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Services.Protocols.SoapDocumentService(RoutingStyle = SoapServiceRoutingStyle.RequestElement)]
    public class Service1 : System.Web.Services.WebService, IQueueTimeoutNotificationBinding
    {
        [WebMethod]
        public notifyQueueTimeoutResponse notifyQueueTimeout(notifyQueueTimeout notifyQueueTimeout1)
        {
            notifyQueueTimeoutResponse rtval = new notifyQueueTimeoutResponse();
            try
            {

               
                string lines = "OK";//rtval.result.ResultCode +" "+rtval.result.ResultDesc;

                // Write the string to a file.
                System.IO.StreamWriter file =
   new System.IO.StreamWriter("D:\\timeouttx.txt", true);
                file.WriteLine(lines);

                file.Close();
          
                rtval.result.ResultCode = "00000000";
                rtval.result.ResultDesc = "success";
            }
            catch (Exception e)
            {

                string lines = "NOT OK";//rtval.result.ResultCode +" "+rtval.result.ResultDesc;

                // Write the string to a file.
                System.IO.StreamWriter file =
   new System.IO.StreamWriter("D:\\timeouttx.txt", true);
                file.WriteLine(lines);

                file.Close();
                rtval.result.ResultCode = "000000001";
                rtval.result.ResultDesc = "failed";

            }

            return rtval;
        }
    }
}