using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Collections;

namespace SmsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public MobileEntities db = new MobileEntities();
        public Service1()
        {
            Logging.Logging.logpath = @"C:\Mobile\Logs\Sms\Sms\";
            //var  connectionstring = data.Connectionstring(@"WIN-23324ER32IT", "Mobile");

        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public sms Sendsms(sms s) {
            Results r = new Results();
            r.code = 1;
            try
            {
                var client = db.Clients.FirstOrDefault(o => o.Client_Code == s.client);
                if (client != null)
                {
                    if ((bool)client.Active)
                    {
                        var chopped = choppedtext(s.text, 160);
                        var Bal = db.BulkSms.Where(o => o.Client == s.client).Sum(o => o.Value);
                        if (Bal >= chopped.Count())
                        {
                            var smsexist = db.BulkSms.FirstOrDefault(o => o.Source_Id == s.Sourceid && o.Client == s.client);
                            if (smsexist == null)
                            {
                                BulkSm bulk = new BulkSm();
                                bulk.Source_Id = s.Sourceid;
                                bulk.Client = s.client;
                                bulk.Phone = s.phone;
                                bulk.Message = s.text;
                                bulk.Datetime = DateTime.Now;
                                bulk.Status = 0;
                                bulk.Value = chopped.Count() * -1;
                                Logging.Logging.LogEntryOnFile(string.Format("Time {0}", s.Scheduledtime));
                                bulk.Scheduled = s.Scheduled;
                                bulk.Scheduled_Time = s.Scheduledtime;
                                if (s.Scheduledtime.Year == 0001)
                                    bulk.Scheduled_Time = DateTime.Now;
                               
                                s.balance = (int)Bal - chopped.Count();
                                db.BulkSms.Add(bulk);
                                db.SaveChanges();
                                s.Smsclient = client.Client_Code;
                                if (s.Scheduled == false)
                                {
                                    Send(ref s);
                                    bulk.Status = 1;
                                    bulk.Balance = s.balance;
                                    bulk.Trace = s.status;
                                    bulk.Destination_Id = s.Terminationid;
                                }
                                db.SaveChanges();
                            }
                            else
                                s.balance = (int)smsexist.Balance;
                            r.code = 0;
                            r.Description = "OK";
                        }
                        else r.Description = "Insufficient Balance";

                    }
                    else r.Description = "Client Not active";
                }
                else r.Description = "Invalid Client";

              //  Task.Factory.StartNew(() => { unsent(); });
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
                r.code = -1;
                r.Description = ex.Message;
            }
            s.results = r;
            return s;
        }
        public sms Sendsmsonly(sms s)
        {
            Results r = new Results();
            r.code = 1;
            try
            {                  
             Send(ref s);
                r.code = 0;
                r.Description = "OK";
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
                r.code = -1;
                r.Description = ex.Message;
            }
            s.results = r;
            return s;
        }
        public airtime sendAirtime(airtime s)
        {

            Results r = new Results();
            r.code = 1;
            try
            {
                var client = db.Clients.FirstOrDefault(o => o.Client_Code == s.client);
                if (client != null)
                {
                    if ((bool)client.Active)
                    {
                        var airtime = db.Airtimes.Where(o => o.Client == s.client).Select(l => l.Amount)
                            .DefaultIfEmpty(0)
                            .Sum();
                        if (airtime >= s.amount)
                        {
                            var send = new Airtime();
                            send.Amount = s.amount*-1;
                            send.Telephone = s.telephone;
                            send.Client = s.client;
                            db.Airtimes.Add(send);
                            sendairtime(ref s);
                            send.Status = s.status;
                            send.error_message = s.error_message;
                            send.Discount = s.discount;
                            r.code = 0;
                            r.Description = "OK";
                        }
                        else
                            r.Description = "Insufficient funds";
                    }
                    else r.Description = "Client Not active";
                }
                else r.Description = "Invalid Client";
             
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
                r.code = -1;
                r.Description = ex.Message;
            }
            finally {
                db.SaveChanges();
            }
            s.results = r;
            return s;
        }
        private void unsent()
        {
            var unsent = db.BulkSms.Where(o => o.Status == 0);
         foreach (var s in unsent.ToList())
                {
                try
                {
                    sms ss = new sms();
                    ss.client = s.Client;
                    ss.phone = s.Phone;
                    ss.text = s.Message;       
                    Send(ref ss);
                    s.Status = 1;
                    s.Destination_Id = ss.Terminationid;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Logging.Logging.ReportError(ex);
                }
            }
        }
        public static IEnumerable<string> choppedtext(string str, int chunkSize)
        {
            for (int i = 0; i < str.Length; i += chunkSize)
                yield return str.Substring(i, Math.Min(chunkSize, str.Length - i));
        //    return Enumerable.Range(0, str.Length / chunkSize)
             //   .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
        public sms Send(ref sms s)
        {
            // Specify your login credentials
            string username = "Paulo";
            string apiKey = "9268c470fa9a9dae0ba01fee00053f8c3025af9542e98e8f79543df4da0fa728";
            // Specify the numbers that you want to send to in a comma-separated list
            // Please ensure you include the country code (+254 for Kenya in this case)
            string recipients = s.phone;
            // And of course we want our recipients to know what we really do
            string message = s.text;
            // Create a new instance of our awesome gateway class
            AfricasTalkingGateway gateway = new AfricasTalkingGateway(username, apiKey);
            // Any gateway errors will be captured by our custom Exception class below,
            // so wrap the call in a try-catch block   
            try
            {
                // Thats it, hit send and we'll take care of the rest 
                dynamic results;
                if (s.Smsclient != "10000")
                    results = gateway.sendMessage(recipients, message, s.Smsclient);
                else
                    results = gateway.sendMessage(recipients, message);

                foreach (dynamic result in results)
                {
                    Logging.Logging.LogEntryOnFile(string.Format("{0}:{1}", (string)result["messageId"], (string)result["status"]));
                    s.cost = Convert.ToDouble(((string)result["cost"]).Replace("KES", "").Trim());
                    s.Terminationid = (string)result["messageId"];
                    s.status = (string)result["status"];
                    //Console.Write((string)result["number"] + ",");
                    //Console.Write((string)result["status"] + ","); // status is either "Success" or "error message"
                    //Console.Write((string)result["messageId"] + ",");
                    //Console.WriteLine((string)result["cost"]);
                }
            }
            catch (AfricasTalkingGatewayException e)
            {
                Logging.Logging.ReportError(e);
               
                throw;
            }
            return s;
        }

        public airtime sendairtime( ref airtime airtime)
        {
            string username = "Paulo";
            string apiKey = "9268c470fa9a9dae0ba01fee00053f8c3025af9542e98e8f79543df4da0fa728";

            // Specify an array list to hold numbers to receive airtime
            ArrayList AirtimeRecipientsList = new ArrayList();

            // Declare hashtable to hold the first number
            // Please ensure you include the country code for phone numbers (+254 for Kenya in this case)
            // Please ensure you include the country code for phone numbers (KES for Kenya in this case)
            // Specify the country currency and the amount as shown below

            Hashtable rec1 = new Hashtable();
            rec1["phoneNumber"] = airtime.telephone;
            rec1["amount"] =string.Format("KES {0}",airtime.amount);

            // Add recipient to list
            AirtimeRecipientsList.Add(rec1);

            // Declare hashtable to hold the another number
         

            // Create a new instance of our awesome gateway class
            AfricasTalkingGateway gateway = new AfricasTalkingGateway(username, apiKey);

            try
            {
                // That's it. Hit send and we will handle the rest

                dynamic response = gateway.sendAirtime(AirtimeRecipientsList);
                foreach (dynamic result in response)
                {
                    airtime.status = result["status"];
                    airtime.discount =Convert.ToDouble(result ["discount"].ToString().Replace("KES","")) ;
                    airtime.error_message = result["errorMessage"];
                    Console.Write(result["status"] + ",");
                    Console.Write(result["phoneNumber"] + ",");
                    Console.Write(result["amount"] + ",");
                    Console.Write(result["discount"] + ",");
                    Console.WriteLine(result["errorMessage"]);
                }
            }
            catch (AfricasTalkingGatewayException ex)
            {
               Logging.Logging.ReportError(ex);
            }
            catch (Exception e)
            {
                Logging.Logging.ReportError(e);
            }
            return airtime;
        }
    }
}
