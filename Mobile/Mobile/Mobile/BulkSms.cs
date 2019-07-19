using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    class BulkSms : Sms
    {
        public Data.BulkSm Create(Sms s)
        {
            Data.BulkSm sm = sms2bulk(s);
            try
            {
                Db.BulkSms.Add(sm);
                Db.SaveChanges();
            }
            catch (Exception ex)
            { CUtilities.ReportError(ex); }
            finally
            { }
            return sm;
        }

        public Data.BulkSm sms2bulk(Sms s)
        {
            Data.BulkSm ss = new Data.BulkSm();
            try
            {
                ss.sourceId = s.sourceId;
                ss.Value =(int) s.Value;
                ss.Message = s.Message;
                ss.Phone = s.Phone;
                ss.Client = s.Client;
                ss.Balance = s.Balance;
                ss.Datetime = DateTime.Now;
                ss.Type = (int)s.type;
            }
            catch (Exception ex)
            { CUtilities.ReportError(ex); }
            finally
            { }
            return ss;
        }
    }

    class Sms
    {
        public static Data.MobileEntities Db = new Data.MobileEntities();
        public int sourceId;
        public string Phone;
        public Double Value;
        public string Message;
        public DateTime Datetime;
        public string Client;
        public int Balance;
        public Smstype type;
        public string Destinationid;
        public string Status;
        public enum Smstype
        {
            Bulk
        }
        public Sms Send(Sms s)
        {
            // Specify your login credentials
            string username = "SurestepMobile";
            string apiKey = "93b458e6bce841acfaaa395366ee9ab3ba536e7b2bc7ac65ab6346ea56463629";

            // Specify the numbers that you want to send to in a comma-separated list
            // Please ensure you include the country code (+254 for Kenya in this case)
            string recipients =  s.Phone;
            // And of course we want our recipients to know what we really do
            string message =  s.Message;

            // Create a new instance of our awesome gateway class
            AfricasTalkingGateway gateway = new AfricasTalkingGateway(username, apiKey);
            // Any gateway errors will be captured by our custom Exception class below,
            // so wrap the call in a try-catch block   
            try
            {
                // Thats it, hit send and we'll take care of the rest

                dynamic results = gateway.sendMessage(recipients, message, "HAZINASACCO");
                foreach (dynamic result in results)
                {
                    s.Value =Convert.ToDouble( ((string)result["cost"]).Replace("KES","").Trim());
                    s.Destinationid = (string)result["messageId"];
                    s.Status = (string)result["status"];
                    Console.Write((string)result["number"] + ",");
                    Console.Write((string)result["status"] + ","); // status is either "Success" or "error message"
                    Console.Write((string)result["messageId"] + ",");
                    Console.WriteLine((string)result["cost"]);
                }
            }
            catch (AfricasTalkingGatewayException e)
            {
                CUtilities.ReportError(e);
                Console.WriteLine("Encountered an error: " + e.Message);
                throw;
            }
            return s;
        }
    }

}
