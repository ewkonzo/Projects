using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataSyncService
{
    public class SendSms
    {

        public void send(string phone,string message,string corporateno)
        { 
        using (var db= new MessagesEntities())
        {
            
       var service = (from services in db.tblServices where services.Corporate == "100" select services).FirstOrDefault();
     
                                if (service !=null)
                                {
                                   
                                    var sms = new Messages2();
                                    sms.Direction = 2;
                                    sms.Type = 1;
                                    sms.ChannelID = service.ServiceID;
                                    sms.BillingID = service.spID.ToString();
                                    sms.Status = 1;
                                    sms.StatusDetails = 200;
                                    sms.CustomField1 = Convert.ToInt32( service.correlator_last_used);
                                    sms.FromAddress = service.AccessNo.ToString();
                                    sms.ToAddress = phone;
                                    sms.Body = message;
                                    sms.spID = service.spID;
                                    sms.serviceID = service.ServiceID;
                                    sms.correlator =Convert.ToInt32(service.correlator_last_used);
                                    sms.Corporate_No = corporateno;
                                    sms.Datetime = DateTime.Now;
                                    db.AddToMessages2(sms);
                                }
                                db.SaveChanges();
        }
        }
    }
}