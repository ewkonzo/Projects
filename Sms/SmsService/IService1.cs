using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SmsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        sms Sendsms(sms s);
        [OperationContract]
        airtime sendAirtime(airtime s);
        [OperationContract]
        sms Sendsmsonly(sms s);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    [DataContract]
    public class sms {
        [DataMember]
        public string Sourceid;
        [DataMember]
        public string phone;
        [DataMember]
        public string text;
        [DataMember]
        public string client;
        [DataMember]
        public string Smsclient = string.Empty;
        [DataMember]
        public int balance;
        [DataMember]
        public Results results;
        [DataMember]
        public string Terminationid;
        [DataMember]
        public string status;
        [DataMember]
        public double cost;
        [DataMember]
        public Boolean Scheduled=false;
        [DataMember]
        public DateTime Scheduledtime=DateTime.Now;
    }
    public class Results
    {
        [DataMember]
        public int code;
        [DataMember]
        public string Description;
    }
    public class airtime
    {
        [DataMember]
        public string telephone;
        [DataMember]
        public string client;
        [DataMember]
        public double amount;
        [DataMember]
        public double discount;
        [DataMember]
        public string status;
        [DataMember]
        public string error_message;
        [DataMember]
        public Results results;
    }
}
