using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bandari_Sacco.controller;
using iTextSharp.text.pdf.events;
//using Microsoft.Ajax.Utilities;

namespace Bandari_Sacco
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
      
        public DateTime totalstart = new DateTime(2011, 1, 1);
        public DateTime totalend = new DateTime(2015, 12, 31);

        public DateTime datestart2011 = new DateTime(2011, 1, 1);
        public DateTime dateend2011 = new DateTime(2011, 12, 31);

        public DateTime datestart2012 = new DateTime(2012, 1, 1);
        public DateTime dateend2012 = new DateTime(2012, 12, 31);

        public DateTime datestart2013 = new DateTime(2013, 1, 1);
        public DateTime dateend2013 = new DateTime(2013, 12, 31);

        public DateTime datestart2014 = new DateTime(2014, 1, 1);
        public DateTime dateend2014 = new DateTime(2014, 12, 31);

        public DateTime datestart2015 = new DateTime(2015, 1, 1);
        public DateTime dateend2015 = new DateTime(2015, 12, 31);

        public DateTime datestart2016 = new DateTime(2016, 1, 1);
        public DateTime dateend2016 = new DateTime(2016, 12, 31);

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
           // Response.Cache.SetNoStore();
        }


        public string TotalDeposits(DateTime deposityearfrom, DateTime deposityearto)
        {
            string totalDeposits = string.Empty;
            try
            {
                
                using (var conn = CRUD.getconnToNAV())
                {

                    //var s = "SELECT isnull(Sum([Amount]*-1),0) as TotalDeposits FROM [" + MyClass.CompanyName + "$Member Ledger Entry]" +
                    //        " WHERE [Customer No_]=@Member_No AND [Posting Date] BETWEEN @DepositYearFrom AND @DepositYearTo";

                    //var s = "SELECT isnull(Sum(a.[Amount]*-1),0) as TotalDeposits FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                    //       "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND b.[No_] LIKE 'L01%' AND a.[Transaction Types] =0 AND a.[Posting Date] BETWEEN @DepositYearFrom AND @DepositYearTo";
                    var s = "SELECT isnull(Sum(a.[Amount]*-1),0) as TotalDeposits FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                            "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Customer No_] LIKE 'S01%' AND a.[Posting Date] BETWEEN @DepositYearFrom AND @DepositYearTo " +
                            "UNION " +
                            "SELECT isnull(Sum(a.[Amount]*-1),0) as TotalDeposits FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b   " +
                            "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Customer No_] LIKE 'S02%' AND a.[Posting Date] BETWEEN @DepositYearFrom AND @DepositYearTo " +
                            "UNION " +
                            "SELECT isnull(Sum(a.[Amount]*-1),0) as TotalDeposits FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b   " +
                            "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Customer No_] LIKE 'S06%' AND a.[Posting Date] BETWEEN @DepositYearFrom AND @DepositYearTo";

                    var command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@Member_No", Session["Member_No"]);
                    command.Parameters.AddWithValue("@DepositYearFrom", deposityearfrom);
                    command.Parameters.AddWithValue("@DepositYearTo", deposityearto);

                    using (var dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                totalDeposits = (Convert.ToInt32(dr["TotalDeposits"])).ToString();
                            }
                        }
                    }
                }
                

            }
            catch (Exception ex)
            {
                
               // throw;
               SessionExpiry();

            }
            return totalDeposits;
           
        }
        public string TotalLoanRepayments(DateTime loansyearfrom, DateTime loansyearto)
        {

            var totalRepayments = string.Empty;
            try
            {
               
                using (var conn = CRUD.getconnToNAV())
                 {
                //    var s = "SELECT isnull(Sum([Repayment]),0) AS Repayment FROM [" + MyClass.CompanyName + "$Loans]" +
                //           " WHERE [Member No_]=@Member_No AND Posted=1 AND [Issued Date] BETWEEN @LoansYearFrom AND @LoansYearTo";

                    var s = "SELECT isnull(Sum([Repayment]),0) AS Repayment FROM [" + MyClass.CompanyName + "$Loans]" +
                           " WHERE [Member No_]=@Member_No AND Posted=1 AND [Loan Disbursement Date] BETWEEN @LoansYearFrom AND @LoansYearTo";

                    var command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@Member_No", Session["Member_No"]);
                    command.Parameters.AddWithValue("@LoansYearFrom", loansyearfrom);
                    command.Parameters.AddWithValue("@LoansYearTo", loansyearto);

                    using (var dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                totalRepayments = (Convert.ToInt32(dr["Repayment"])).ToString();
                            }
                        }
                    }
                }
               
            }
            catch (Exception)
            {
                //throw;
                SessionExpiry();
            }
            return totalRepayments;
            
        }

        public string TotalShareCapital(DateTime sharesyearfrom, DateTime sharesyearto)
        {
            var totalShareCapital = string.Empty;
            try
            {
               
                using (var conn = CRUD.getconnToNAV())
                {

                    //var s = "SELECT isnull(Sum([Amount]*-1),0)[Shares] FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
                    //    "WHERE [Customer No_]=@Member_No AND [Transaction Types]=14 AND [Posting Date] BETWEEN @SharesYearFrom AND @SharesYearTo";

                    var s = "SELECT isnull(Sum(a.[Amount]*-1),0) as [Shares] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                           "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Transaction Types]=1 AND a.[Posting Date] BETWEEN @SharesYearFrom AND @SharesYearTo";

                    var command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@Member_No", Session["Member_No"]);
                    command.Parameters.AddWithValue("@SharesYearFrom", sharesyearfrom);
                    command.Parameters.AddWithValue("@SharesYearTo", sharesyearto);

                    using (var dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                totalShareCapital = (Convert.ToInt32(dr["Shares"])).ToString();
                            }
                        }
                    }
                }
               
            }
            catch (Exception)
            {
                //throw;
                SessionExpiry();
            }
            return totalShareCapital;
         
        }

        public string TotalLoans(DateTime loansyearsfrom, DateTime loansyearsto)
        {
            var totalloans = string.Empty;
            try
            {
                
                using (var conn = CRUD.getconnToNAV())
                {

                    //var s = string.Format("SELECT isnull(Sum([Approved Amount]),0) AS [LoanAmount] FROM {0}"+
                    //    " WHERE [Member No_]=@Member_No AND [Issued Date] BETWEEN @LoansYearFrom AND @LoansYearTo", "[" + MyClass.CompanyName + "$Loans]");

                    var s = string.Format("SELECT isnull(Sum([Approved Amount]),0) AS [LoanAmount] FROM {0}" +
                       " WHERE [Member No_]=@Member_No AND [Loan Disbursement Date] BETWEEN @LoansYearFrom AND @LoansYearTo", "[" + MyClass.CompanyName + "$Loans]");

                    var command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@Member_No", Session["Member_No"]);
                    command.Parameters.AddWithValue("@LoansYearFrom", loansyearsfrom);
                    command.Parameters.AddWithValue("@LoansYearTo", loansyearsto);
                    using (var dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                totalloans = (Convert.ToDouble(dr["LoanAmount"])).ToString();
                            }
                        }
                    }
                }
               
            }
            catch (Exception)
            {
                //throw;
                SessionExpiry();
            }
            return totalloans;
            
        }

        public string TotalLoanRepayments()
        {
            var totalRepayments = string.Empty;
            double repayment = 0;
            try
            {

                using (var conn = CRUD.getconnToNAV())
                {

                    var s = "SELECT isnull(Sum([Repayment]),0) AS Repayment FROM [" + MyClass.CompanyName + "$Loans] WHERE [Member No_]=@Member_No AND Posted=1";

                    var command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@Member_No", Session["Member_No"]);

                    using (var dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                repayment = Convert.ToDouble(dr["Repayment"]);
                            }
                        }
                        totalRepayments = repayment.ToString();
                    }
                }

            }
            catch
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
            return totalRepayments;
        }

        public string TotalLoans()
        {
            var totalloans = string.Empty;
            try
            {
                double totalbalance = 0;
                double balance = 0;
                string membernumber = Session["Member_No"].ToString().Trim();
                int returnedcount = GetLoansCount(membernumber);
                string[] loannumber = GetLoansNumber(membernumber, returnedcount);
                foreach (string one in loannumber)
                {
                    balance = GetOustandingBalance(one);
                    totalbalance += balance;
                }
                totalloans = totalbalance.ToString();
            }
            catch
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
            return totalloans;
        }

        protected double GetOustandingBalance(string loannumber)
        {
            double balance = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT isnull(Sum([Amount]),0) AS [Amount] FROM [{0}$Member Ledger Entry] WHERE [Loan No]=@LoanNo AND [Transaction Types] in (4,5)", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@LoanNo", loannumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                balance = Convert.ToDouble(dr["Amount"]);

                            }
                    }
                }
            }
            catch
            {
                throw;
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
            return balance;
        }

        protected int GetLoansCount(string membernumber)
        {
            int count = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT COUNT ([Loan  No_]) AS [Count] FROM [{0}$Loans] WHERE [Member No_]=@MemberNo", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@MemberNo", membernumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                count = Convert.ToInt32(dr["Count"]);

                            }
                    }
                }
            }
            catch
            {
                throw;
            }

            return count;
        }

        protected string[] GetLoansNumber(string membernumber, int count)
        {
            int i = 0;
            string[] loannumbers = new string[count];
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Loan  No_] FROM [{0}$Loans] WHERE [Member No_]=@MemberNo", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@MemberNo", membernumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {

                                loannumbers[i] = dr["Loan  No_"].ToString();
                                i++;

                            }
                    }
                }
            }
            catch
            {
                throw;
            }
            return loannumbers;
        }

        protected string DisplayName()
        {
            var membername = string.Empty;


            try
            {

                using (var conn = CRUD.getconnToNAV())
                {                    
                    string  s = string.Format("SELECT [No_], [First Name] as [Name] FROM [{0}$Member] WHERE [No_]=@Member_No", MyClass.CompanyName);
 
                    var command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@Member_No", Session["Member_No"]);
                    using (var dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                membername = dr["Name"].ToString();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //throw;
                SessionExpiry();
            }
            return membername;


        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            LogTimeOut();
            Session.Remove("Member_No");
            Session.Remove("User_Group_Name");
            Session.Abandon();
            Response.Redirect("Login.aspx");

        }

        protected void SessionExpiry()
        {
            LogTimeOut();
            Session.Remove("Member_No");
            Session.Remove("User_Group_Name");
            Session.Abandon();
            Response.Redirect("Login.aspx");

        }

        protected void LogTimeOut()
        {
            try
            {
                DateTime LogoutTime = DateTime.Now;
                string sessionID = Session["SessionID"].ToString();
                string membernumber = Session["Member_No"].ToString(); 
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = "UPDATE [" + MyClass.CompanyName + "$Online Sessions]" +
                               " SET [LogoutTime] = @LogoutTime " +
                               " WHERE [User Number] = @UserName AND [SessionID]=@Session";

                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@LogoutTime", LogoutTime);
                    command.Parameters.AddWithValue("@UserName", membernumber);
                    command.Parameters.AddWithValue("@Session", sessionID);  
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                //throw;
                SessionExpiry();
            }

        }


      

    }


}
