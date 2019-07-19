using System;
using System.Linq;
using System.Collections.Generic;

using System.Data;

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
namespace AGENCY
{
    public class Account
    {
        public static Accounts.Vendors_Service Accservice = new Accounts.Vendors_Service();
        public static Customer.Customers_Service Custservice = new Customer.Customers_Service();
        public static AccountDetails.CustomerDetails_Service accdetservice = new AccountDetails.CustomerDetails_Service();
        public String Account_No = null;
        public String Account_Name = null;
        public double Account_Balance = 0;
        public String Account_type = null;
        public String Telephone = null;
        public Boolean Selected = false;
        public Boolean Account_ok = true;
        public String Message = null;
        public double shares=0;
        public double Monthlycont = 0;
       


        public static List<Account> accountlist(String id_no)
        {
            String response = string.Empty;
            List<Account> accounts = new List<Account>();
            try
            {
                var dt = Accservice.ReadMultiple(new Accounts.Vendors_Filter[] { new Accounts.Vendors_Filter { Criteria = id_no, Field = Accounts.Vendors_Fields.ID_No }, new Accounts.Vendors_Filter { Criteria = "Active|New", Field = Accounts.Vendors_Fields.Status }, new Accounts.Vendors_Filter { Criteria = " ", Field = Accounts.Vendors_Fields.Blocked } }, null, 10).ToList();

                        foreach (var row in dt)
                        {
                            Account account = new Account();
                            account.Account_No = row.No;
                            account.Account_Name = row.Name;
                            account.Account_type = row.Account_Type;
                            account.Telephone = row.Phone_No;
                            account.Account_Balance =(double) Agency.Post.Bal(account.Account_No);
                            accounts.Add(account);
                        }
                 
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            return accounts;

        }
        public static List<Account> accountlistwithdrawable(String id_no)
        {
            String response = string.Empty;
            List<Account> accounts = new List<Account>();
            try
            {
                var dt = Accservice.ReadMultiple(new Accounts.Vendors_Filter[] { new Accounts.Vendors_Filter { Criteria = id_no, Field = Accounts.Vendors_Fields.ID_No }, new Accounts.Vendors_Filter { Criteria = "Active|New", Field = Accounts.Vendors_Fields.Status }, new Accounts.Vendors_Filter { Criteria = " ", Field = Accounts.Vendors_Fields.Blocked } }, null, 10).ToList();
                        foreach (var row in dt)
                        {
                            Account account = new Account();
                            account.Account_No = row.No;
                            account.Account_Name = row.Name;
                            account.Account_type = row.Account_Type;
                            account.Telephone = row.Phone_No;
                            account.Account_Balance = (double)Agency.Post.Bal(account.Account_No);
                            accounts.Add(account);
                        }
   
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            return accounts;
        }
        public static List<Account> accountlistall(String id_no)
        {
            String response = string.Empty;
            List<Account> accounts = new List<Account>();
            try
            {
                var dt = Accservice.ReadMultiple(new Accounts.Vendors_Filter[] { new Accounts.Vendors_Filter { Criteria = id_no, Field = Accounts.Vendors_Fields.ID_No }, new Accounts.Vendors_Filter { Criteria = "Active|New", Field = Accounts.Vendors_Fields.Status }, new Accounts.Vendors_Filter { Criteria = " ", Field = Accounts.Vendors_Fields.Blocked } }, null, 10).ToList();

                foreach (var row in dt)
                {
                    Account account = new Account();
                    account.Account_No = row.No;
                    account.Account_Name = row.Name;
                    account.Account_type = row.Account_Type;
                    account.Telephone = row.Phone_No;
                    account.Account_Balance = (double)Agency.Post.Bal(account.Account_No);
                    accounts.Add(account);
                }

            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            return accounts;

        }
        public static List<Account> Memberlist(String id_no)
        {
            String response = string.Empty;
            List<Account> accounts = new List<Account>();
            try
            {
                var dt = Custservice.ReadMultiple(new Customer.Customers_Filter[] { new Customer.Customers_Filter { Criteria = id_no, Field = Customer.Customers_Fields.ID_No } }, null, 10).ToList();
                foreach (var row in dt)
                {
                    Account account = new Account();
                    account.Account_No = row.No;
                    account.Account_Name = row.Name;
                    account.Telephone = row.Phone_No;
                    account.shares =(double) row.Shares_Retained;
                    account.Monthlycont = (double)row.Monthly_Contribution;
                    accounts.Add(account);
                }
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            return accounts;

        }
        public static String Ministatement(String acc)
        {
            String response = string.Empty;
          
            try
            {
                var dt = accdetservice.ReadMultiple(new AccountDetails.CustomerDetails_Filter[] { new AccountDetails.CustomerDetails_Filter { Criteria = acc, Field = AccountDetails.CustomerDetails_Fields.Vendor_No } }, null, 10).ToList();
                        foreach (var row in dt)
                        {
                            response = String.Format("{0}{1};{2};{3}\n", response,row.Posting_Date.ToShortDateString(),(row.Amount>0 ?"DR " + row.Amount :"CR " + (row.Amount*-1)),row.Vendledger_Description);
                           
                        }




            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            return response;

        }
        public static double accountbalance(string acc) 
        
        { double bal = 0;
        try
        {
            bal = (double)Agency.Post.Bal(acc);
        }
        catch (Exception ex) { }
        return bal;
        }

        public static List<Account> MemberlistAll(String id_no)
        {
            String response = string.Empty;
            List<Account> accounts = new List<Account>();
            try
            {

                var dt = Custservice.ReadMultiple(new Customer.Customers_Filter[] { new Customer.Customers_Filter { Criteria = id_no, Field = Customer.Customers_Fields.ID_No } }, null, 100);
                foreach (var row in dt)
                {
                    Account account = new Account();
                    account.Account_No = row.No;// row["No_"].ToString();
                    account.Account_Name = row.Name;// row["Name"].ToString();
                    account.Telephone = row.Phone_No;// row["Phone No_"].ToString();
                    account.shares =(double) row.Shares_Retained;
                    account.Monthlycont = (double)row.Monthly_Contribution;

                    accounts.Add(account);
                }


            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            return accounts;

        }
        public static Account accountinfo(Account acc)
        {
            String response = string.Empty;
          
            try
            {
               
                var r = Accservice.ReadMultiple(new Accounts.Vendors_Filter[] { new Accounts.Vendors_Filter { Criteria = acc.Account_No, Field = Accounts.Vendors_Fields.No }, new Accounts.Vendors_Filter { Criteria = "Active|New", Field = Accounts.Vendors_Fields.Status }, new Accounts.Vendors_Filter { Criteria = " ", Field = Accounts.Vendors_Fields.Blocked } }, null, 1).FirstOrDefault();
                if (r != null){
                            acc.Account_No =r.No;// r["No_"].ToString();
                            acc.Account_Name =r.Name;// r["Name"].ToString();
                            acc.Account_type = r.Account_Type;// r["Account Type"].ToString();
                            acc.Telephone = r.Phone_No;// r["Phone No_"].ToString();
                            acc.Account_ok = true;
                        }
                        else
                        {
                            acc.Account_ok = false;
                            acc.Message = "Account Not Found";
                        }


                  

            }
            catch (Exception ex)
            {
               
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
                acc.Account_ok = false;
                acc.Message = "Unable to get account";
            }
            return acc;

        }
   
       
      
    }
}
