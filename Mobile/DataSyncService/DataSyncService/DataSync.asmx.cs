using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Security.Cryptography;
using System.Net;



namespace DataSyncService
{
    [WebService(Namespace = "http://172.31.181.115:35070/DataSync/DataSync.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Services.Protocols.SoapDocumentService(RoutingStyle = SoapServiceRoutingStyle.RequestElement)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DataSync : System.Web.Services.WebService, IDataSyncBinding
    {
        [WebMethod]
        public syncSubscriptionDataResponse syncSubscriptionData(syncSubscriptionData _ssData)
        {
            syncSubscriptionDataResponse _ssdr = new syncSubscriptionDataResponse();
            try
            {
                CommonFunctions.LogEntryOnFile("syncSubscriptionData > " + _ssData.MSISDN + " " + _ssData.productId + " " + _ssData.serviceId);
                using (var db = new MobileEntities())
                {
                    Subscription newsub = new Subscription();
                    newsub.MSISDN = _ssData.MSISDN;
                    newsub.Service_id =Convert.ToInt64( _ssData.serviceId);
                    newsub.Product_id = _ssData.productId;
                    newsub.Update_type = _ssData.updateType;
                    newsub.Date_time= DateTime.Now;
                    db.AddToSubscriptions(newsub);
                                  
                    

                    db.SaveChanges();

                }

            }
            catch (Exception e)
            {
                if (e.InnerException.Message != null)
                    CommonFunctions.LogEntryOnFile(e.InnerException.Message);
                else
                    CommonFunctions.LogEntryOnFile(e.Message);
            }
            return _ssdr;
        }

        [WebMethod]
        public changeMSISDNResponse changeMSISDN(changeMSISDN _changeMSISDN1)
        {
            changeMSISDNResponse _cmsisdnr = new changeMSISDNResponse();
            try
            {
                CommonFunctions.LogEntryOnFile("changeMSISDN > " + _changeMSISDN1.MSISDN + " " + _changeMSISDN1.newMSISDN + " " + _changeMSISDN1.timeStamp);
            }
            catch (Exception e)
            {
            }
            return _cmsisdnr;
        }

        public syncOrderRelationResponse syncOrderRelation(syncOrderRelation syncOrderRelation1)
        {
            syncOrderRelationResponse _sorr = new syncOrderRelationResponse();
            _sorr.result = 0;
            _sorr.resultDescription = "Ok";
            try
            {
                CommonFunctions.LogEntryOnFile(string.Format("{3}-{0}-{1}-{2}-{4}", syncOrderRelation1.userID.ID, syncOrderRelation1.productID, syncOrderRelation1.serviceID, DateTime.Now, syncOrderRelation1.updateType));
                using (var db = new MobileEntities())
                {
                    Subscription newsub = new Subscription();
                    newsub.MSISDN = syncOrderRelation1.userID.ID;
                    newsub.Service_id = Convert.ToInt64(syncOrderRelation1.serviceID);
                    newsub.Product_id = syncOrderRelation1.productID;
                    newsub.Update_type = syncOrderRelation1.updateType;
                    newsub.Date_time = DateTime.Now;
                    db.AddToSubscriptions(newsub);
                                     
                    db.SaveChanges();

                

                }

            }

            catch (Exception e)
            {
                CommonFunctions.LogEntryOnFile(e.Message);
               CommonFunctions.LogEntryOnFile(e.InnerException.Message);
            } 
            return _sorr;
        }
        public string GetMd5(string timestamp, string spid, string sppassword)
        {
            string pasword = spid.Trim() + sppassword + timestamp;// 

            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pasword));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
     
        public syncMSISDNChangeResponse syncMSISDNChange(syncMSISDNChange syncMSISDNChange1)
        {
            syncMSISDNChangeResponse _syncmsisdnchange = new syncMSISDNChangeResponse();
            try
            {
                CommonFunctions.LogEntryOnFile("syncMSISDNChange >  " + syncMSISDNChange1.MSISDN + " " + syncMSISDNChange1.newMSISDN);
            }
            catch (Exception e)
            {
            } return _syncmsisdnchange;
        }
    }


}