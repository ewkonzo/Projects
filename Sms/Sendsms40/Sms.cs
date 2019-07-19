


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Script.Serialization;

namespace Sendsms
{
    public class Sms
    {
        public string Sourceid;
        public string phone;
        public string text;
        public string client;
        public string Smsclient = string.Empty;
        public int balance;
        public Results results;
        public string Terminationid;
        public string status;
        public double cost;
        public class jsonmessage
        {
            public string msisdn;
            public string username;
            public string password;
            public string message;
            public string messageid;
        }
        public static send.sms Sendsms(ref send.sms s)
        {
            ServicePointManager.ServerCertificateValidationCallback = (object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => (true);
            string result = string.Empty;
            try
            {
                send.Service1 client = new send.Service1();
                client.Url = "http://197.232.21.217:4000/Sms/Service1.svc";
                //client.Url = "http://localhost:866/Service1.svc";
                s = client.Sendsms(s);
            }
            catch (Exception ex) { result = string.Format("Error|in{0}", ex.Message); }
            return s;
        }
        public string Sendsms(string Sourceid, string phone, string text, string Client)
        {
            ServicePointManager.ServerCertificateValidationCallback = (object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => (true);
            string result = string.Empty;
            try
            {
                send.sms s = new send.sms();
                s.Sourceid = Sourceid;
                phone = phone.Replace(" ", "");
                s.phone = "+254" + phone.Substring(phone.Length - 9);
                s.text = text;
                s.client = Client;
                send.Service1 client = new send.Service1();
                client.Url = "http://197.232.21.217:4000/Sms/Service1.svc";
                //client.Url = "http://localhost:866/Service1.svc";
                s = client.Sendsms(s);
                if (s.results.code == 0)
                    result = string.Format("OK|{0}", s.balance);
                else
                    result = string.Format("Error|{0}", s.results.Description);
            }
            catch (Exception ex) { result = string.Format("Error|in{0}", ex.Message); }
            return result;
        }
        public static string Sendsmsonly(string Sourceid, string phone, string text, string Client)
        {
            ServicePointManager.ServerCertificateValidationCallback = (object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => (true);
            string result = string.Empty;
            try
            {
                send.sms s = new send.sms();
                s.Sourceid = Sourceid;
                phone = phone.Replace(" ", "");
                s.phone = "+254" + phone.Substring(phone.Length - 9);
                s.text = text;
                s.client = Client;
                send.Service1 client = new send.Service1();
                client.Url = "http://197.232.21.217:4000/Sms/Service1.svc";
                //client.Url = "http://localhost:866/Service1.svc";
                s = client.Sendsmsonly(s);
                if (s.results.code == 0)
                    result = string.Format("OK|{0}", s.balance);
                else
                    result = string.Format("Error|{0}", s.results.Description);
            }
            catch (Exception ex) { result = string.Format("Error|in{0}", ex.Message); }
            return result;
        }
        public static send.sms Sendsmsonly(ref send.sms s)
        {
            ServicePointManager.ServerCertificateValidationCallback = (object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => (true);
            string result = string.Empty;
            try
            {
                send.Service1 client = new send.Service1();
                client.Url = "http://197.232.21.217:4000/Sms/Service1.svc";
                //client.Url = "http://localhost:866/Service1.svc";
                s = client.Sendsmsonly(s);
            }
            catch (Exception ex) { result = string.Format("Error|in{0}", ex.Message); }
            return s;
        }
        public string Sendsmsjson(string Sourceid, string phone, string text, string username, string password)
        {
            ServicePointManager.ServerCertificateValidationCallback = (object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => (true);
            string result = string.Empty;
            try
            {
                jsonmessage s = new jsonmessage();
                s.messageid = Sourceid;
                s.msisdn = phone;
                s.message = text;
                s.username = username;
                s.password = password;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://mysms.trueafrican.com/v1/api/esme/send");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    string json = new JavaScriptSerializer().Serialize(s);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                string res;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    res = streamReader.ReadToEnd();
                }
                result = res;
                //s = JsonConvert.DeserializeObject<jsonmessage>(res);
                //if (s.results.code == 0)
                //    result = string.Format("OK|{0}", s.balance);
                //else
                //    result = string.Format("Error|{0}", s.results.Description);
            }
            catch (Exception ex)
            {
                result = string.Format("Error|{0}", ex.Message);

            }
            return result;
        }
    }
    public class Results
    {      
        public int code;
        public string Description;
    }

    public class airtime {
        public send.airtime sendairtime( ref send.airtime s)
        {
            send.Service1 client = new send.Service1();
            client.Url = "http://197.232.21.217:4000/Sms/Service1.svc";
            //client.Url = "http://localhost:886/Service1.svc?wsdl";
            s = client.sendAirtime(s);
            return s;
        }    
    }
}
