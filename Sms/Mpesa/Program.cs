using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Http;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography;
namespace Mpesa
{
    class Program
    {
        public static Auth aouth;
        static void Main(string[] args)
        {
            customer c = new customer();
            c.customer_key = "C4SmgbTeWpoXMUgfASJoUEg2YXI1jkIa";
            c.customer_secret = "d9aYx9P0RZuHTGQs";
            c.ShortCode = "821965";
            c.confirmurl = "https://197.232.21.217:4001/Deposit.svc/ConfirmC2BPayment";
            c.validateurl = "https://197.232.21.217:4001/Deposit.svc/ValidateC2BPayment";

            aouth = live.auth(c);
            live.registerurl(c);
            live.test();
            aouth = auth();
            // registerurl();
            // test();

            b2b();

        }

        public static Auth auth()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string app_key = "aQLRytFTRELbr3tURADWCRNIYHO3TKM9";
            string app_secret = "7ms9VKfnBEa4L2AA";
            string appKeySecret = string.Format("{0}:{1}", app_key, app_secret);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(appKeySecret);
            String auth = System.Convert.ToBase64String(plainTextBytes);
            HttpWebRequest client = (HttpWebRequest)System.Net.WebRequest.Create("https://sandbox.safaricom.co.ke/oauth/v1/generate?grant_type=client_credentials");

            client.KeepAlive = false;
            client.UserAgent = null;
            client.Headers.Add(HttpRequestHeader.Authorization, "Basic " + auth);
            client.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
            // client.ClientCertificates.Add(cert);
            client.Method = "GET";
            client.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)client.GetResponse();
            Stream stream = response.GetResponseStream();
            string html = string.Empty;
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            Auth a = JsonConvert.DeserializeObject<Auth>(html);
            return a;
        }
        public static registerresponse registerurl()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest client = (HttpWebRequest)System.Net.WebRequest.Create("https://sandbox.safaricom.co.ke/mpesa/c2b/v1/registerurl");

            // client.KeepAlive = false;
            //client.UserAgent = null;
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + aouth.access_token);
            client.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
            // client.ClientCertificates.Add(cert);
            client.Method = "POST";
            client.ContentType = "application/json;charset=utf-8";

            register r = new register();
            r.ShortCode = "600257";
            r.ConfirmationURL = "https://197.248.158.54:4000/Deposit.svc/ConfirmC2BPayment";
            r.ValidationURL = "https://197.248.158.54:4000/Deposit.svc/ValidateC2BPayment";
            r.ResponseType = "Completed";

            string rowadata = new JavaScriptSerializer().Serialize(r);


            var encoder = new UTF8Encoding();
            var data = System.Text.UTF8Encoding.UTF8.GetBytes(rowadata);

            client.ContentLength = data.Length;

            using (var st = client.GetRequestStream())
            {
                st.Write(data, 0, data.Length);
            }

            HttpWebResponse response = (HttpWebResponse)client.GetResponse();

            Stream stream = response.GetResponseStream();

            string html = string.Empty;

            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            registerresponse a = JsonConvert.DeserializeObject<registerresponse>(html);
            return a;
        }
        public static string test()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest client = (HttpWebRequest)System.Net.WebRequest.Create("https://sandbox.safaricom.co.ke/mpesa/c2b/v1/simulate");
            // client.KeepAlive = false;
            //client.UserAgent = null;
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + aouth.access_token);
            client.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
            // client.ClientCertificates.Add(cert);
            client.Method = "POST";
            client.ContentType = "application/json";

            c2btrans r = new c2btrans();
            r.ShortCode = "600257";
            r.CommandID = "CustomerPayBillOnline";
            r.BillRefNumber = "2345rff";
            r.Msisdn = "254708374149";
            r.Amount = "fff";

            string rowadata = new JavaScriptSerializer().Serialize(r);
            var encoder = new UTF8Encoding();
            var data = System.Text.UTF8Encoding.UTF8.GetBytes(rowadata);
            client.ContentLength = data.Length;
            using (var st = client.GetRequestStream())
            {
                st.Write(data, 0, data.Length);
            }
            HttpWebResponse response = (HttpWebResponse)client.GetResponse();

            Stream stream = response.GetResponseStream();

            string html = string.Empty;

            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            //registerresponse a = JsonConvert.DeserializeObject<registerresponse>(html);
            return html;
        }
        public static string encryptpassword()
        {
            string encrptedpass = string.Empty;
            X509Certificate cert = X509Certificate.CreateFromCertFile(@"E:\Tray\cert.cer");
            byte[] publicKey = cert.GetPublicKey();
            int keyLength = publicKey.Length;
            
            return encrptedpass;
        }
        public static stkresponse stkpush() {
            stkresponse a = new stkresponse();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest client = (HttpWebRequest)System.Net.WebRequest.Create("https://sandbox.safaricom.co.ke/mpesa/stkpush/v1/processrequest");
            try
            {
                // client.KeepAlive = false;
                //client.UserAgent = null;
                client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + aouth.access_token);
                client.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
                // client.ClientCertificates.Add(cert);
                client.Method = "POST";
                client.ContentType = "application/json;charset=utf-8";
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string passkey = "bfb279f9aa9bdbcf158e97dd71a467cd2e0c893059b10f78e6b72ada1ed2c919";

                stkpush r = new stkpush();
                r.BusinessShortCode = "174379";
                string p = string.Format("{0}{1}{2}", r.BusinessShortCode, passkey, timestamp);
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(p);
                r.Password = System.Convert.ToBase64String(plainTextBytes);
                r.Timestamp = timestamp;
                r.TransactionType = "CustomerPayBillOnline";
                r.Amount = "10";
                r.PartyA = "254708374149";
                r.PartyB = r.BusinessShortCode;
                r.PhoneNumber = "254710563359";
                r.CallBackURL = "http://mpesa.ngrok.io/Deposit.svc/stkpush";
                r.AccountReference = "99889rr";
                r.TransactionDesc = "Ok";

                string rowadata = new JavaScriptSerializer().Serialize(r);


                var encoder = new UTF8Encoding();
                var data = System.Text.UTF8Encoding.UTF8.GetBytes(rowadata);

                client.ContentLength = data.Length;

                using (var st = client.GetRequestStream())
                {
                    st.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)client.GetResponse();

                Stream stream = response.GetResponseStream();

                string html = string.Empty;

                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
                a = JsonConvert.DeserializeObject<stkresponse>(html);
                a.success = true;
            }
            catch (WebException ex) {
                a.success = false;
                using (WebResponse response = ex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    {
                        string text = new StreamReader(data).ReadToEnd();
                        Httperror e = JsonConvert.DeserializeObject<Httperror>(text);
                        a.httperror = e;
                    }
                }

            }


            return a;
        }

        public static B2cResponse b2c() {
            B2cResponse a = null;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest client = (HttpWebRequest)System.Net.WebRequest.Create("https://sandbox.safaricom.co.ke/mpesa/b2c/v1/paymentrequest");
            try
            {
                // client.KeepAlive = false;
                //client.UserAgent = null;
                client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + aouth.access_token);
                client.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
                // client.ClientCertificates.Add(cert);
                client.Method = "POST";
                client.ContentType = "application/json;charset=utf-8";
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string passkey = "bfb279f9aa9bdbcf158e97dd71a467cd2e0c893059b10f78e6b72ada1ed2c919";

                B2C r = new B2C();
                r.InitiatorName = "testapi";
               // string pass = "Safaricom207!";
               // byte[] pass2 = Encoding.ASCII.GetBytes(pass);
               //X509Certificate2  cert = new X509Certificate2( X509Certificate.CreateFromSignedFile(@"D:\Projects\Projects\Cert\Cert.cer"));
               // RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)cert.PublicKey.Key;
               // byte[] encrypted = rsa.Encrypt(pass2, true);
               // string enpass =Convert.ToBase64String(encrypted);
                           
                r.SecurityCredential = "g7sZvOFgy58XPTpYP2EZY6lIidLw8XvR/FzPmflSCc6t95x0Re3WUFmsuKGo1ocGJ49ETlO9rHKJ1CU1tiAbHdZFyaSUzAatg5Z31LCpHshZXknxo+BqU10aY+Y8IIXJUzAdgO8ijnJMlXesU1Kgi4HNRx/A0/EsXpv3tuxtIl1UlqC4p+4hvOa1n0v+IagTFxFK1bn4nnKRRsH/2Y8tqJsVbM5ojKTvm+fj6n/jZDkot+5GqNUeHKcunkalYyQItU1p6H/ULgzMleMIqq+PWk3QP8O2kAnC3KHVwNtxOOJh6ZkVKl8mFfcYs94DyV/yTVZDF3t9y+CyvwmrsZW/sw==";
                r.CommandID = "BusinessPayment";
                r.Amount = 10;
                r.PartyA = "600207";
                r.PartyB = "254708374149";
                r.Remarks = "Successfull";
                r.QueueTimeOutURL = "http://mobiletest.ngrok.io/Deposit.svc/QueueTimeOut";
                r.ResultURL = "http://mobiletest.ngrok.io/Deposit.svc/Results";
                r.Occasion = "Ok";

                string rowadata = new JavaScriptSerializer().Serialize(r);


                var encoder = new UTF8Encoding();
                var data = System.Text.UTF8Encoding.UTF8.GetBytes(rowadata);

                client.ContentLength = data.Length;

                using (var st = client.GetRequestStream())
                {
                    st.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)client.GetResponse();

                Stream stream = response.GetResponseStream();

                string html = string.Empty;
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
                a = JsonConvert.DeserializeObject<B2cResponse>(html);
            }
           catch (WebException ex)
            {
                //a.success = false;
                using (WebResponse response = ex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    {
                        string text = new StreamReader(data).ReadToEnd();
                        Httperror e = JsonConvert.DeserializeObject<Httperror>(text);

                    }
                }

            }
            return a;

        }
        public static B2BResponse b2b()
        {
            B2BResponse a = null;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest client = (HttpWebRequest)System.Net.WebRequest.Create("https://sandbox.safaricom.co.ke/mpesa/b2c/v1/paymentrequest");
            try
            {
                // client.KeepAlive = false;
                //client.UserAgent = null;
                client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + aouth.access_token);
                client.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
                // client.ClientCertificates.Add(cert);
                client.Method = "POST";
                client.ContentType = "application/json;charset=utf-8";
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

                B2B r = new B2B();
                r.Initiator = "testapi";
                r.CommandID = "MerchantServicesMMFAccountTransfer";
                r.SecurityCredential = "g7sZvOFgy58XPTpYP2EZY6lIidLw8XvR/FzPmflSCc6t95x0Re3WUFmsuKGo1ocGJ49ETlO9rHKJ1CU1tiAbHdZFyaSUzAatg5Z31LCpHshZXknxo+BqU10aY+Y8IIXJUzAdgO8ijnJMlXesU1Kgi4HNRx/A0/EsXpv3tuxtIl1UlqC4p+4hvOa1n0v+IagTFxFK1bn4nnKRRsH/2Y8tqJsVbM5ojKTvm+fj6n/jZDkot+5GqNUeHKcunkalYyQItU1p6H/ULgzMleMIqq+PWk3QP8O2kAnC3KHVwNtxOOJh6ZkVKl8mFfcYs94DyV/yTVZDF3t9y+CyvwmrsZW/sw==";
                r.Amount = 10;
                r.PartyA = "600207";
                r.SenderIdentifierType = 4;
                r.PartyB = "600000";
                r.RecieverIdentifierType = 4;
                r.Remarks = "Successfull";
                r.QueueTimeOutURL = "http://mobiletest.ngrok.io/Deposit.svc/QueueTimeOut";
                r.ResultURL = "http://mobiletest.ngrok.io/Deposit.svc/Results";
                r.AccountReference = "Ok";
                string rowadata = new JavaScriptSerializer().Serialize(r);
                var encoder = new UTF8Encoding();
                var data = System.Text.UTF8Encoding.UTF8.GetBytes(rowadata);
                client.ContentLength = data.Length;

                using (var st = client.GetRequestStream())
                {
                    st.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)client.GetResponse();

                Stream stream = response.GetResponseStream();

                string html = string.Empty;
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
                a = JsonConvert.DeserializeObject<B2BResponse>(html);
            }
            catch (WebException ex)
            {
                //a.success = false;
                using (WebResponse response = ex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    {
                        string text = new StreamReader(data).ReadToEnd();
                        Httperror e = JsonConvert.DeserializeObject<Httperror>(text);
                    }
                }
            }
            return a;
        }
    }
    public class B2cResponse
    {
        public string ConversationID { get; set; }
        public string OriginatorConversationID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
    }
    public class B2BResponse
    {
        public string ConversationID { get; set; }
        public string OriginatorConversationID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
    }
    public class Auth
    {
        public string access_token = string.Empty;
        public int expires_in = 0;
    }

    public class B2C
    {
        public string InitiatorName;
        public string SecurityCredential;
        public string CommandID;
        public double Amount;
        public string PartyA;
        public string PartyB;
        public string Remarks;
        public string QueueTimeOutURL;
        public string ResultURL;
        public string Occasion;
    }
    

public class B2B
    {
        public string Initiator { get; set; }
        public string SecurityCredential { get; set; }
        public string CommandID { get; set; }
        public int SenderIdentifierType { get; set; }
        public int RecieverIdentifierType { get; set; }
        public double Amount { get; set; }
        public string PartyA { get; set; }
        public string PartyB { get; set; }
        public string AccountReference { get; set; }
        public string Remarks { get; set; }
        public string QueueTimeOutURL { get; set; }
        public string ResultURL { get; set; }
    }
    public class Httperror
    {
        public string requestId { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
    }
    public class register
    {
        public string ValidationURL = string.Empty;
        public string ConfirmationURL = string.Empty;
        public string ResponseType = string.Empty;
        public string ShortCode = string.Empty;
    }
    public class stkresponse
    {
        public string MerchantRequestID { get; set; }
        public string CheckoutRequestID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string CustomerMessage { get; set; }
        public Httperror httperror { get; set; }
        public bool success;
    }
    public class registerresponse
    {

        public string ConversationID = string.Empty;
        public string OriginatorCoversationID = string.Empty;
        public string ResponseDescription = string.Empty;

    }
    public class stkpush
    {

        public string BusinessShortCode;
        public string Password;
        public string Timestamp;
        public string TransactionType;
        public string Amount;
        public string PartyA;
        public string PartyB;
        public string PhoneNumber;
        public string CallBackURL;
        public string AccountReference;
        public string TransactionDesc;
    }
    public class c2btrans
    {
        public string CommandID = string.Empty;
        public string Amount = string.Empty;
        public string Msisdn = string.Empty;
        public string BillRefNumber = string.Empty;
        public string ShortCode = string.Empty;
    }

    public class live
    {
        public static Auth auth(customer c)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string app_key = c.customer_key;// "trPzD8glbWrSYxUGZd0E60e6m7C5uAaj";
            string app_secret = c.customer_secret;// "aQpCLuQxsofx87YZ";
            string appKeySecret = string.Format("{0}:{1}", app_key, app_secret);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(appKeySecret);
            String auth = System.Convert.ToBase64String(plainTextBytes);
            HttpWebRequest client = (HttpWebRequest)System.Net.WebRequest.Create("https://api.safaricom.co.ke/oauth/v1/generate?grant_type=client_credentials");

            client.KeepAlive = false;
            client.UserAgent = null;
            client.Headers.Add(HttpRequestHeader.Authorization, "Basic " + auth);
            client.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
            // client.ClientCertificates.Add(cert);
            client.Method = "GET";
            client.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)client.GetResponse();

            Stream stream = response.GetResponseStream();
            string html = string.Empty;
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            Auth a = JsonConvert.DeserializeObject<Auth>(html);
            return a;

        }
        public static registerresponse registerurl(customer c)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest client = (HttpWebRequest)System.Net.WebRequest.Create("https://api.safaricom.co.ke/mpesa/c2b/v1/registerurl");

            // client.KeepAlive = false;
            //client.UserAgent = null;
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Program.aouth.access_token);
            client.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
            // client.ClientCertificates.Add(cert);
            client.Method = "POST";
            client.ContentType = "application/json;charset=utf-8";
            register r = new register();
            r.ShortCode = c.ShortCode;// "967637";
            r.ConfirmationURL = c.confirmurl;// "https://41.72.194.236:4000/Deposit.svc/ConfirmC2BPayment";
            r.ValidationURL = c.validateurl;// "https://41.72.194.236:4000/Deposit.svc/ValidateC2BPayment";
            r.ResponseType = "Completed";

            string rowadata = new JavaScriptSerializer().Serialize(r);

            var encoder = new UTF8Encoding();
            var data = System.Text.UTF8Encoding.UTF8.GetBytes(rowadata);

            client.ContentLength = data.Length;

            using (var st = client.GetRequestStream())
            {
                st.Write(data, 0, data.Length);
            }
            string html = string.Empty;
            try
            {
                HttpWebResponse response = (HttpWebResponse)client.GetResponse();
                Stream stream = response.GetResponseStream();

                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {

            }


            registerresponse a = JsonConvert.DeserializeObject<registerresponse>(html);
            return a;
        }
        public static string test()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest client = (HttpWebRequest)System.Net.WebRequest.Create("https://sandbox.safaricom.co.ke/mpesa/c2b/v1/simulate");

            // client.KeepAlive = false;
            //client.UserAgent = null;
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Program.aouth.access_token);
            client.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
            // client.ClientCertificates.Add(cert);
            client.Method = "POST";
            client.ContentType = "application/json";

            c2btrans r = new c2btrans();
            r.ShortCode = "600257";
            r.CommandID = "CustomerPayBillOnline";
            r.BillRefNumber = "2345rff";
            r.Msisdn = "254708374149";
            r.Amount = "fff";

            string rowadata = new JavaScriptSerializer().Serialize(r);


            var encoder = new UTF8Encoding();
            var data = System.Text.UTF8Encoding.UTF8.GetBytes(rowadata);

            client.ContentLength = data.Length;

            using (var st = client.GetRequestStream())
            {
                st.Write(data, 0, data.Length);
            }

            HttpWebResponse response = (HttpWebResponse)client.GetResponse();

            Stream stream = response.GetResponseStream();

            string html = string.Empty;

            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            //registerresponse a = JsonConvert.DeserializeObject<registerresponse>(html);
            return html;
        }
        public static string encryptpassword()
        {
            string encrptedpass = string.Empty;
            X509Certificate cert = X509Certificate.CreateFromCertFile(@"E:\Tray\cert.cer");
            byte[] publicKey = cert.GetPublicKey();
            int keyLength = publicKey.Length;
            return encrptedpass;
        }

    }

    public class customer
    {
        public string customer_key;
        public string customer_secret;
        public string ShortCode;
        public string confirmurl;
        public string validateurl;
    }
}
