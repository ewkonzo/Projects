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
            Smsservice.Service1 send = new Smsservice.Service1();
            Smsservice.sms s = new Smsservice.sms();
            s.client = "10000";
            s.phone = "254" + sms.Telephone.Substring(sms.Telephone.Length - 9);
            s.text = sms.Text;
            s.Sourceid = (DateTime.Now.Millisecond * 10000).ToString();
           s= send.Sendsms(s);
            
            CUtilities.LogEntryOnFile(s.results.code.ToString());
            CUtilities.LogEntryOnFile(s.results.Description);
            return sms;
        }
    }
}
