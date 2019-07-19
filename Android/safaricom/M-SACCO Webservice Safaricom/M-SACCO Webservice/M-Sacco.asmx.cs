using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System.Net.Security;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace M_SACCO_Webservice
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Mobile : System.Web.Services.WebService
    {
        Results results = new Results();
        ServerSetting ss = new ServerSetting();
        System.Net.NetworkCredential cd;
        NAVService.MsaccoApp Msacco = new NAVService.MsaccoApp();

        public Mobile()
        {
           //ServicePointManager.ServerCertificateValidationCallback = (object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => (true);
           //string path = Server.MapPath("~/Settings.txt");
           // ss.getsettings(path);
           // //  getsettings();
           // //safcom
           // NetworkCredential credentials = new NetworkCredential(ss.user, "9o73UEOAr2mnaFE8MBXQraZHgkKTpJdCkNOOCcb1saY=");
           // //NetworkCredential credentials = new NetworkCredential(ss.user, ss.pass, ss.domain);//"9o73UEOAr2mnaFE8MBXQraZHgkKTpJdCkNOOCcb1saY=");
           // CredentialCache credCache = new CredentialCache();
           // cd = new System.Net.NetworkCredential(ss.user, ss.pass, ss.domain);
           // Msacco.Url = String.Format("https://{0}:{3}/{2}/WS/{1}/Codeunit/MsaccoApp", ss.server, ss.Companyname, ss.Instance, ss.Port);
           // Msacco.ClientCertificates.Add(X509Certificate.CreateFromCertFile(@"E:\CERTS\NavServiceCert.cer"));
           // Msacco.ClientCertificates.Add(X509Certificate.CreateFromCertFile(@"E:\CERTS\RootNavServiceCA.cer"));
           // // Msacco.ClientCertificates.Add(X509Certificate.CreateFromCertFile(@"D:\Projects\Projects -Paul\Msacco projects\M-SACCO Webservice Safaricom\RootNavServiceCA.crl"));
           // // System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
           // credCache.Add(new Uri(Msacco.Url), "Basic", credentials);
           // Msacco.Credentials = credCache;
           // Msacco.PreAuthenticate = true;
            //safcom

           // cd = new System.Net.NetworkCredential(ss.user, ss.pass, ss.domain);
            //Msacco.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/MsaccoApp", ss.server, ss.Companyname, ss.Instance, ss.Port);
            //Msacco.PreAuthenticate = true;
            //Msacco.Credentials = cd;

            string path = Server.MapPath("~/Settings.txt");
            ss.getsettings(path);
            //  getsettings();
            cd = new System.Net.NetworkCredential(ss.user, ss.pass, ss.domain);
            Msacco.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/MsaccoApp", ss.server, ss.Companyname, ss.Instance, ss.Port);
            Msacco.PreAuthenticate = true;
            Msacco.Credentials = cd;

        }
        private string gettime()
        {
            return "1754-01-01 " + DateTime.Now.ToString("HH:mm:ss tt");
        }

        [WebMethod]
        public List<string> GetAccountBalance(string telephoneNo)
        {
            //string results = string.Empty;
            var balances = new List<String>();
            string account_numbers = string.Empty;
            string account_names = string.Empty;
            string bosa_acc = string.Empty;
            string[] accountsArray;
            string[] accountNamesArray;
            string[] loansArray;
            string shares;
            string deposits;
            var accountbalancesList = new List<string>();
            telephoneNo = telephoneNo.Replace("+", "");
            try
            {
                bosa_acc = Msacco.GetBosaAccount(telephoneNo);

                //Get all user FOSA account numbers
                account_numbers = Msacco.Accounts(bosa_acc);

                //Get all user FOSA account names
                account_names = Msacco.AccountNames(bosa_acc);

                //Split string into individual accounts.
                accountsArray = account_numbers.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                accountNamesArray = account_names.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);

                //Get account Balance for each individual Account
                for (int x = 0; x < accountsArray.Length; x++)
                {
                    accountbalancesList.Add("Account Name: "+accountNamesArray[x] + ":::" + Msacco.AccountBalance(bosa_acc, accountsArray[x]));
                }

                //Add shares and deposits
                deposits = Msacco.GetDeposits(telephoneNo);
                accountbalancesList.Add("My Deposits:::" + deposits);
                shares = Msacco.GetShares(telephoneNo);
                accountbalancesList.Add("My Shares:::" + shares);

                //Get Loan Balances
                String LoanBals = Msacco.Loanbalances(telephoneNo);

                //Split loan balances string to individual loan balances
                loansArray = LoanBals.Split(new string[] { "$$$$" }, StringSplitOptions.RemoveEmptyEntries);

                //Get Add all loan balances
                for (int index = 0; index < loansArray.Length; index++)
                {
                    accountbalancesList.Add("Loan Type: "+loansArray[index]);
                }

            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                // results.Hasresults = false;
                //results.ResultErros = ex.Message;
            }
            return accountbalancesList;
        }

        [WebMethod]
        public string getMinistatement(string phone_no)
        {
            string results = "";
            try
            {
                phone_no = phone_no.Replace("+", "");
                results = Msacco.Ministatement(phone_no);
                //results.ResultsData = Results;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                //results.Hasresults = false;
                //results.ResultErros = ex.Message;
            }
            return results;
        }
        [WebMethod]
        public List<string> getActiveFOSAAccounts(string phone_no)
        {
            //string results = "";
            string bosa_acc = string.Empty;
            string account_numbers = string.Empty;
            string account_names = string.Empty;
            string[] accountsArray;
            string[] accountNamesArray;
            phone_no = phone_no.Replace("+", "");
            var fosaAccountsList = new List<string>();
            try
            {
                bosa_acc = Msacco.GetBosaAccount(phone_no);

                //Get all user FOSA account numbers
                account_numbers = Msacco.Accounts(bosa_acc);

                //Get all user FOSA account names
                account_names = Msacco.AccountNames(bosa_acc);

                //Split string into individual accounts.
                accountsArray = account_numbers.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                accountNamesArray = account_names.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);

                //Combine account names to numbers
                for (int x = 0; x < accountsArray.Length; x++)
                {
                    fosaAccountsList.Add(accountNamesArray[x] + ":::" + accountsArray[x]);
                }

            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                //results.Hasresults = false;
                //results.ResultErros = ex.Message;
            }
            return fosaAccountsList;
        }

        [WebMethod]
        public string getdashboardData(string phone_no, int lastEntry)
        {
            string results = "";
            try
            {
                phone_no = phone_no.Replace("+", "");
                results = Msacco.GetDashboardData(phone_no, lastEntry);
                //results.ResultsData = Results;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                //results.Hasresults = false;
                //results.ResultErros = ex.Message;
            }
            return results;
        }
        [WebMethod]
        public string getShares(string phone_no)
        {
            string results = "";
            try
            {
                phone_no = phone_no.Replace("+", "");
                results = Msacco.GetShares(phone_no);
                //results.ResultsData = Results;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                //results.Hasresults = false;
                //results.ResultErros = ex.Message;
            }
            return results;
        }
        [WebMethod]
        public string getDeposits(string phone_no)
        {
            string results = "";
            try
            {
                phone_no = phone_no.Replace("+", "");
                results = Msacco.GetDeposits(phone_no);
                //results.ResultsData = Results;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                //results.Hasresults = false;
                //results.ResultErros = ex.Message;
            }
            return results;
        }

        [WebMethod]
        public string getMyBOSAAcc(string phone_no)
        {
            string results = "";
            try
            {
                phone_no = phone_no.Replace("+", "");
                results = Msacco.GetBosaAccount(phone_no);
                //results.ResultsData = Results;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                //results.Hasresults = false;
                //results.ResultErros = ex.Message;
            }
            return results;
        }

        [WebMethod]
        public string getMyFOSAAccts(string phone_no)
        {
            string results = "";
            try
            {
                phone_no = phone_no.Replace("+", "");
                results = Msacco.GetFosaAccount(phone_no);
                //results.ResultsData = Results;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                //results.Hasresults = false;
                //results.ResultErros = ex.Message;
            }
            return results;
        }

        [WebMethod]
        public string getMemberInfo(string phone_no)
        {
            string Results = "";

            try
            {
                phone_no = phone_no.Replace("+", "");
                Results = Msacco.GetmemberInfo(phone_no);
                //results.ResultsData = Results;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                // results.Hasresults = false;
                //results.ResultErros = ex.Message;
            }
            return Results;

        }

        [WebMethod]
        public string GetActiveLoans(string phone_no)
        {
            string results = "";

            try
            {
                phone_no = phone_no.Replace("+", "");
                results = Msacco.GetActiveLoans(phone_no);

            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
            }
            return results;

        }

        [WebMethod]
        public string GetLoanStatus(string LoanNo, string phone_no)
        {
            string results = "";

            try
            {
                phone_no = phone_no.Replace("+", "");
                results = Msacco.GetLoanStatus(LoanNo, phone_no);

            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
            }
            return results;

        }
        [WebMethod]
        public string getMemberCardDetails(string phone_no)
        {
            string Results = "";

            try
            {
                phone_no = phone_no.Replace("+", "");
                Results = Msacco.GetMemberCardDetails(phone_no);
                //results.ResultsData = Results;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                // results.Hasresults = false;
                //results.ResultErros = ex.Message;
            }
            return Results;

        }
        [WebMethod]
        public string GetLoanTypes()
        {
            string results = "";

            try
            {
                results = Msacco.GetLoanTypes();

            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
            }
            return results;
        }
        [WebMethod]
        public string GetLoanBalances(string phone_no)
        {
            string Results = "";

            try
            {
                phone_no = phone_no.Replace("+", "");
                Results = Msacco.Loanbalances(phone_no);
                //results.ResultsData = Results;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                // results.Hasresults = false;
                //results.ResultErros = ex.Message;
            }
            return Results;

        }
        [WebMethod]
        public string getNextOfKin(string phone_no)
        {
            string results = "";
            try
            {
                phone_no = phone_no.Replace("+", "");
                results = Msacco.GetNextOfKin(phone_no);
                //results.ResultsData = Results;
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                //results.Hasresults = false;
                //results.ResultErros = ex.Message;
            }
            return results;
        }
    }
}
