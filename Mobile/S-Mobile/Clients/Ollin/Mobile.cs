using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PData;
namespace Client
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface Mobile
    {      
        [OperationContract]
        Trans Transaction(Trans t);
        [OperationContract]
        List<PData.Sms.Sms> sms(int count);
        [OperationContract]
        List<PData.Sms.Sms> SmsUpdate(List<PData.Sms.Sms> s);
        [OperationContract]
        decimal Bal(string acc);
        [OperationContract]
        List<PData.S_Applications.Applications> Registration();
        [OperationContract]
        List<PData.Loans.Loans> CustomerLoans(string telephone);
        [OperationContract]
        List<PData.Accounts.Accounts> Accounts(string tel);
        [OperationContract]
        PData.Accounts.Accounts Account(string tel);


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
}
