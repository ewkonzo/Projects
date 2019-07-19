using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System.Net.Security;
using System.Net;
using System.Web;
using System.IO;
namespace AGENCY
{
    public class Sms 
    {
     
        
        public String Telephone = null;
        public String Text = null;
        public string Results;
    
        public Sms Send(Sms sms)
        { 
            ServicePointManager.ServerCertificateValidationCallback = (object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => (true);
            WebRequest request;
            request = WebRequest.Create(String.Format("https://localhost/Capital.asmx/Send?message={0}&phone={1}", sms.Text, "254" + sms.Telephone.Substring(sms.Telephone.Length - 9)));
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            var results = new StreamReader(response.GetResponseStream()).ReadToEnd();

            request = null;
                        return sms;
        }
    }
}
