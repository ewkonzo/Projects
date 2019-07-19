using System;
using System.Linq;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
namespace AGENCY
{
    public class Account
    {
        public String Account_No = null;
        public String Account_Name = null;
        public double Account_Balance = 0;
        public String Account_type = null;
        public String Telephone = null;
        public Boolean Selected = false;
        public Boolean Account_ok = true;
        public String Message = null;


        public static List<Account> accountlist(String id_no)
        {
            String response = string.Empty;
            List<Account> accounts = new List<Account>();
            try
            {

                using (var db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    if (db.mDB.State == ConnectionState.Open)
                    {//DataTable dt = db.Getdatatable(String.Format("SELECT  [No_],[Name],[Phone No_] ,[Blocked],[Status],[Account Type],[Identification No_],[Amount To Hold]  FROM [dbo].[Capital SACCO Society Ltd$Vendor] where [Identification No_] = '{0}' and (Status = 0 OR Status = 4) and Blocked = 0 and ([Account Type] = 'SAVINGS' or [Account Type] = 'AKIBA' ) ", id_no));
                        DataTable dt = db.Getdatatable(String.Format("SELECT  [No_],[Name],[Phone No_] ,[Blocked],[Status],[Account Type],[Identification No_],[Amount To Hold]  FROM [dbo].[Capital SACCO Society Ltd$Vendor] where [Identification No_] = '{0}' and (Status = 0 OR Status = 4) and Blocked = 0  ", id_no));
                        foreach (DataRow row in dt.Rows)
                        {
                            Account account = new Account();
                            account.Account_No = row["No_"].ToString();
                            account.Account_Name = row["Name"].ToString();
                            account.Account_type = row["Account Type"].ToString();
                            account.Telephone = row["Phone No_"].ToString();
                            account.Account_Balance = Math.Round(accountbalance(account.Account_No) - MinimunAccountBalance(account.Account_type), 2);
                            accounts.Add(account);
                        }
                    }
                    db.close();
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

                using (var db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    if (db.mDB.State == ConnectionState.Open)
                    {//DataTable dt = db.Getdatatable(String.Format("SELECT  [No_],[Name],[Phone No_] ,[Blocked],[Status],[Account Type],[Identification No_],[Amount To Hold]  FROM [dbo].[Capital SACCO Society Ltd$Vendor] where [Identification No_] = '{0}' and (Status = 0 OR Status = 4) and Blocked = 0 and ([Account Type] = 'SAVINGS' or [Account Type] = 'AKIBA' ) ", id_no));
                        DataTable dt = db.Getdatatable(String.Format("SELECT  [No_],[Name],[Phone No_] ,[Blocked],[Status],[Account Type],[Identification No_],[Amount To Hold]  FROM [dbo].[Capital SACCO Society Ltd$Vendor] where [Identification No_] = '{0}' and (Status = 0 OR Status = 4) and Blocked = 0  ", id_no));
                        foreach (DataRow row in dt.Rows)
                        {
                            if (iswithdrawable(row["Account Type"].ToString()))
                            {
                                Account account = new Account();
                                account.Account_No = row["No_"].ToString();
                                account.Account_Name = row["Name"].ToString();
                                account.Account_type = row["Account Type"].ToString();
                                account.Telephone = row["Phone No_"].ToString();
                                account.Account_Balance = Math.Round(accountbalance(account.Account_No) - MinimunAccountBalance(account.Account_type), 2);
                                accounts.Add(account);
                            }
                        }
                    }
                    db.close();
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
                using (var db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    if (db.mDB.State == ConnectionState.Open)
                    {//DataTable dt = db.Getdatatable(String.Format("SELECT  [No_],[Name],[Phone No_] ,[Blocked],[Status],[Account Type],[Identification No_],[Amount To Hold]  FROM [dbo].[Capital SACCO Society Ltd$Vendor] where [Identification No_] = '{0}' and  ([Account Type] = 'SAVINGS'  ) ", id_no));
                        DataTable dt = db.Getdatatable(String.Format("SELECT  [No_],[Name],[Phone No_] ,[Blocked],[Status],[Account Type],[Identification No_],[Amount To Hold]  FROM [dbo].[Capital SACCO Society Ltd$Vendor] where [Identification No_] = '{0}'  ", id_no));
                        foreach (DataRow row in dt.Rows)
                        {
                            Account account = new Account();
                            account.Account_No = row["No_"].ToString();
                            account.Account_Name = row["Name"].ToString();
                            account.Account_type = row["Account Type"].ToString();
                            account.Telephone = row["Phone No_"].ToString();
                            account.Account_Balance = accountbalance(account.Account_No) - MinimunAccountBalance(account.Account_type);
                            accounts.Add(account);
                        }


                    }
                    db.close();
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

                using (var db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    if (db.mDB.State == ConnectionState.Open)
                    {
                        DataTable dt = db.Getdatatable(String.Format("SELECT  [No_],[Name],[Phone No_] ,[Blocked],[Status],[Identification No_]  FROM [dbo].[Capital SACCO Society Ltd$Member] where [Identification No_] = '{0}' and (Status = 0 OR Status = 4) and Blocked = 0 ", id_no));
                        foreach (DataRow row in dt.Rows)
                        {
                            Account account = new Account();
                            account.Account_No = row["No_"].ToString();
                            account.Account_Name = row["Name"].ToString();
                            account.Telephone = row["Phone No_"].ToString();
                            accounts.Add(account);
                        }



                    }
                    db.close();
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
                using (var db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    if (db.mDB.State == ConnectionState.Open)
                    {
                        DataTable dt = db.Getdatatable(String.Format("select top(5) convert(nvarchar(10),[Capital SACCO Society Ltd$Vendor Ledger Entry].[Posting Date],105)+ '; '+ case when[Capital SACCO Society Ltd$Vendor Ledger Entry].[Description] like '%Payment received from%' then 'M-Pesa deposit' when[Capital SACCO Society Ltd$Vendor Ledger Entry].[Description] like '%Payment to%' then 'M-Pesa Withdrawal'else[Capital SACCO Society Ltd$Vendor Ledger Entry].[Description] end +'; '+ convert(nvarchar(100),convert(decimal,[Capital SACCO Society Ltd$Detailed Vendor Ledg_ Entry].Amount)) as results from [Capital SACCO Society Ltd$Vendor Ledger Entry] right outer join [Capital SACCO Society Ltd$Detailed Vendor Ledg_ Entry] on [Capital SACCO Society Ltd$Detailed Vendor Ledg_ Entry].[Vendor Ledger Entry No_] = [Capital SACCO Society Ltd$Vendor Ledger Entry].[Entry No_] where [Capital SACCO Society Ltd$Vendor Ledger Entry].[Vendor No_]= '{0}' and ( lower([Capital SACCO Society Ltd$Vendor Ledger Entry].Description) not like '%charge%' and  [Capital SACCO Society Ltd$Vendor Ledger Entry].Description not like '%Stamp duty%'and  [Capital SACCO Society Ltd$Vendor Ledger Entry].Description not like '%Salary Processing Fee%' and  [Capital SACCO Society Ltd$Vendor Ledger Entry].Description not like '%Comm%'and  [Capital SACCO Society Ltd$Vendor Ledger Entry].Description not like '%Appraisal%') order by [Capital SACCO Society Ltd$Vendor Ledger Entry].[timestamp] desc", acc));
                        foreach (DataRow row in dt.Rows)
                        {
                            response = String.Format("{0}{1}\n", response, row["results"]);
                        }
                    }
                    db.close();
                }
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            return response;

        }
        public static List<Account> MemberlistAll(String id_no)
        {
            String response = string.Empty;
            List<Account> accounts = new List<Account>();
            try
            {
                using (var db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    if (db.mDB.State == ConnectionState.Open)
                    {
                        DataTable dt = db.Getdatatable(String.Format("SELECT  [No_],[Name],[Phone No_] ,[Blocked],[Status],[Identification No_]  FROM [dbo].[Capital SACCO Society Ltd$Member] where [Identification No_] = '{0}' ", id_no));
                        foreach (DataRow row in dt.Rows)
                        {
                            Account account = new Account();
                            account.Account_No = row["No_"].ToString();
                            account.Account_Name = row["Name"].ToString();
                            account.Telephone = row["Phone No_"].ToString();
                            accounts.Add(account);
                        }
                    }
                    db.close();
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
            SqlDataReader r;
            try
            {
                using (var db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    if (db.mDB.State == ConnectionState.Open)
                    {
                        r = db.ReadDB(String.Format("SELECT Top(1) [No_],[Name],[Phone No_] ,[Blocked],[Status],[Account Type],[Identification No_],[Amount To Hold]  FROM [dbo].[Capital SACCO Society Ltd$Vendor] where [No_] = '{0}' and (Status = 0 OR Status = 4) and Blocked = 0", acc.Account_No));
                        if (r.HasRows)
                        {
                            r.Read();
                            acc.Account_No = r["No_"].ToString();
                            acc.Account_Name = r["Name"].ToString();
                            acc.Account_type = r["Account Type"].ToString();
                            acc.Telephone = r["Phone No_"].ToString();
                            acc.Account_ok = true;
                        }
                        else
                        {
                            acc.Account_ok = false;
                            acc.Message = "Account Not Found";
                        }
                    }
                    db.close();
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
        public static Double accountbalance(string account)
        {
            Decimal unc = 0;
            Decimal atm;
            Decimal balance;
            Decimal amttohold;
            SqlDataReader r;
            try
            {
                using (var Db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    r = Db.ReadDB(String.Format("SELECT [Account Type],isnull(SUM([Capital SACCO Society Ltd$Detailed Vendor Ledg_ Entry].Amount),0) AS Balance FROM [Capital SACCO Society Ltd$Detailed Vendor Ledg_ Entry] RIGHT OUTER JOIN [Capital SACCO Society Ltd$Vendor Ledger Entry] ON [Capital SACCO Society Ltd$Vendor Ledger Entry].[Entry No_] = [Capital SACCO Society Ltd$Detailed Vendor Ledg_ Entry].[Vendor Ledger Entry No_] RIGHT OUTER JOIN [Capital SACCO Society Ltd$Vendor] ON [Capital SACCO Society Ltd$Vendor].No_ = [Capital SACCO Society Ltd$Vendor Ledger Entry].[Vendor No_] WHERE ([Capital SACCO Society Ltd$Vendor Ledger Entry].[Vendor No_] = '{0}') GROUP BY [Account Type]", account));
                    if (r.HasRows)
                    {
                        r.Read();
                        balance = Convert.ToDecimal(r["Balance"]);
                    }
                    else
                        balance = 0;
                    r.Close();
                    r = null;
                    r = Db.ReadDB(String.Format("SELECT isnull(SUM(Amount),0) AS Balance FROM [Capital SACCO Society Ltd$Transactions] WHERE [Account No_] ='{0}' AND Deposited =1 AND [Cheque Processed] = 0 AND Type = 'Cheque Deposit'", account));
                    if (r.HasRows)
                    {
                        r.Read();
                        unc = Convert.ToDecimal(r["balance"]);
                    }
                    else
                        unc = 0;
                    r.Close();
                    r = null;
                    r = Db.ReadDB(String.Format("SELECT isnull([Amount To Hold],0) AS Balance  FROM [Capital SACCO Society Ltd$Vendor] WHERE No_ ='{0}'", account));
                    if (r.HasRows)
                    {
                        r.Read();
                        amttohold = Convert.ToDecimal(r["Balance"]);
                    }
                    else
                        amttohold = 0;
                    r.Close();
                    r = null;
                    r = Db.ReadDB(String.Format("SELECT isnull(SUM(Amount),0) AS Balance FROM [Capital SACCO Society Ltd$ATM Transactions] WHERE [Account No] ='{0}' AND Posted =0 ", account));
                    if (r.HasRows)
                    {
                        r.Read();
                        atm = Convert.ToDecimal(r["balance"]);
                    }
                    else
                        atm = 0;
                    r.Close();
                    r = null;
                    Db.close();
                }
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                throw ex;
            }
            return Convert.ToDouble((balance * -1) - (unc) - atm - amttohold);
        }
        public static double MinimunAccountBalance(string atype)
        {
            double balance = 0;

            SqlDataReader r;
            try
            {
                using (var Db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    r = Db.ReadDB(String.Format("SELECT [Code],isnull([Minimum Balance],0) AS Balance FROM [Capital SACCO Society Ltd$Account Types]  WHERE ([Code] = '{0}')", atype));
                    if (r.HasRows)
                    {
                        r.Read();
                        balance = Convert.ToDouble(r["Balance"]);
                    }
                    else
                        balance = 0;
                    r.Close();
                    r = null;
                    Db.close();
                }
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
            }
            return balance;
        }
        public static Boolean iswithdrawable(string atype)
        {
            Boolean balance = true;

            SqlDataReader r;
            try
            {
                using (var Db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    r = Db.ReadDB(String.Format("SELECT [Withdrawable] FROM [Capital SACCO Society Ltd$Account Types]  WHERE ([Code] = '{0}')", atype));
                    if (r.HasRows)
                    {
                        r.Read();
                        balance = Convert.ToBoolean(r["Withdrawable"]);
                    }
                    r.Close();
                    r = null;
                    Db.close();
                }
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
            }
            return balance;
        }
    }
}
