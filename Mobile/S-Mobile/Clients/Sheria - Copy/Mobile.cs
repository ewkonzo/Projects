using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Client
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface Mobile
    {
      
        [OperationContract]
        Results Tstatus(string documentNo);
        [OperationContract]
        eligibility Eligibility(string phone, Transactions.Loan_Type loantype);
        [OperationContract]
               Member.Member member(string acc);
        [OperationContract]
             List<Accounts.Accounts> Memberaccounts(string tel);
        [OperationContract]
   
        Trans Transaction(Trans t);
        [OperationContract]
        [XmlSerializerFormat]
        List<Sms.Sms> sendsms(List<Sms.Sms> smses);
        //[OperationContract]
        //List<Sms.Sms> SmsUpdate(List<Sms.Sms> s);
        [OperationContract]
        [XmlSerializerFormat]
        double Bal(string acc);
        [OperationContract]
        List<S_Applications.Applications> Registration();

        [OperationContract]
        List<Loans.Loans> CustomerLoans(string telephone);

        [OperationContract]
        List<Accounts.Accounts> Accounts(string tel);

        [OperationContract]
        Accounts.Accounts Account(string tel);

        [OperationContract]
        List<Accounts.Accounts> Accountsbyid(string id);
        [OperationContract]
        List<Accounts.Accounts> ChildAccounts(string no);
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
