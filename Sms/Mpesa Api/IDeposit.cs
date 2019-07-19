using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Mpesa_Api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDeposit" in both code and config file together.
    [ServiceContract]
    public interface IDeposit
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json)]
        string ValidateC2BPayment(Stream request);

        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json)]
        string ConfirmC2BPayment(Stream request);
        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json)]
        string stkpush(Stream request);
        [OperationContract]
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json)]
        string QueueTimeOut(Stream request);
        [OperationContract]
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json)]
        string Results(Stream request);
    }
}
