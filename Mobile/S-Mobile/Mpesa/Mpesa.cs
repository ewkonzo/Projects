using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Mpesa
{
    public class Mpesa
    {
        public Mpesa(customer c)
        {
            //aouth = Mpesa.Auth;
            aouth = auth(c);

        }
    
        public static Auth auth(customer c)
        {
            Auth a = null;
         
            try
            {   ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string app_key = "aQLRytFTRELbr3tURADWCRNIYHO3TKM9";// c.customer_key;// "trPzD8glbWrSYxUGZd0E60e6m7C5uAaj";
                string app_secret = "7ms9VKfnBEa4L2AA" ;// c.customer_secret;// "aQpCLuQxsofx87YZ";
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
                a = JsonConvert.DeserializeObject<Auth>(html);
            }
            catch (WebException ex)
            {
           
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
        public  stkresponse Stkpush(stkpush push)
            {
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

                    push.TransactionType = "CustomerPayBillOnline";
                    string p = string.Format("{0}{1}{2}", push.BusinessShortCode, passkey, timestamp);
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(p);
                    push.Password = System.Convert.ToBase64String(plainTextBytes);
                    push.Timestamp = timestamp;

                    string rowadata = new JavaScriptSerializer().Serialize(push);
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
                catch (WebException ex)
                {
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
        public  B2cResponse b2c()
        {
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
        public  Auth aouth;

        public class B2cResponse
        {
            public string ConversationID { get; set; }
            public string OriginatorConversationID { get; set; }
            public string ResponseCode { get; set; }
            public string ResponseDescription { get; set; }
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
        public class customer
        {
            public string customer_key;
            public string customer_secret;
            public string ShortCode;
            public string confirmurl;
            public string validateurl;
        }
        public class Auth
        {
            public string access_token = string.Empty;
            public int expires_in = 0;
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
            public double Amount;
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
    }
}
    namespace Mobile {
    public enum Transtype
    {
        /// <remarks/>
        _blank_,

        /// <remarks/>
        Withdrawal,

        /// <remarks/>
        Deposit,

        /// <remarks/>
        Balance,

        /// <remarks/>
        Ministatement,

        /// <remarks/>
        Airtime,

        /// <remarks/>
        Loan_balance,

        /// <remarks/>
        Loan_Status,

        /// <remarks/>
        Share_Deposit_Balance,

        /// <remarks/>
        Transfer_to_Fosa,

        /// <remarks/>
        Transfer_to_Bosa,

        /// <remarks/>
        Utility_Payment,

        /// <remarks/>
        Loan_Application,

        /// <remarks/>
        Standing_orders,
        //Agency

        Cash_Deposit,
        Cash_Withdrawal,
        Cash_Withdrawal_Agency,
        bills_agency,
        account_to,
        Transfer_agency,
    }
    public enum Status
    {
        Processing = 0,
        Pending = 1,
        Completed = 2,
        Failed = 3
    }
}
