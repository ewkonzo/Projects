using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Microsoft.VisualBasic;
//using System.Text.StringBuilder;
using System.Text;
using Bandari_Sacco.controller;
namespace Bandari_Sacco
{
    public partial class LoanAppraisal : System.Web.UI.Page
    {
        double StatisticalSalary = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            string membernumber = Session["Member_No"].ToString().Trim();
            int returnedoption = GetOption();
            double returnedpercentage = GetPercentage();
            int returnedcount = GetLoansCount(membernumber);
            int returnedsalarycount = GetSalariesCount(membernumber);
            double processedsalary = ProcessLastThreeSalaries(membernumber, returnedoption, returnedpercentage, returnedsalarycount);
            string[] loannumber = GetLoansNumber(membernumber, returnedcount);
            double oustandinginterest = 0;
            double repayment = 0;
            double totaldeduction = 0;
            double standingorderamount = 0;
            double qualification = 0;
            double overalldeductions = 0;
            double interestrate = 0;


            
            if (loannumber.Length == 1)
            {
                double oustandingbalance = GetOustandingBalance(loannumber[0]);
                if (oustandingbalance > 0)
                {
                    repayment = GetRepayment(loannumber[0]);
                    interestrate = GetInterestRate(loannumber[0]);
                    oustandinginterest = oustandingbalance * (interestrate / 100) * (1 / 12);
                    
                    totaldeduction = oustandinginterest + repayment;
                }

            }
            if (loannumber.Length > 1)
            {

                foreach (string one in loannumber)
                {
                   double balance = GetOustandingBalance(one);
                   if (balance > 0)
                   {
                       repayment = GetRepayment(one);
                       interestrate = GetInterestRate(one);
                       oustandinginterest = ((balance * (interestrate / 100))/12);
                           
                       totaldeduction = oustandinginterest + repayment;
                       overalldeductions += totaldeduction;
                                    
                   }
                   
                }

            }

            standingorderamount =  GetStandingOrderAmount(membernumber);

            //get qualification
            qualification = ((StatisticalSalary - overalldeductions - standingorderamount) * 0.75);
            //populate table
            PopulateTable(StatisticalSalary, overalldeductions, qualification);

        }
        

        #region ProcessLastThreeSalaries
        protected double ProcessLastThreeSalaries(string membernumber, int option, double percentage, int salarycount)
        {
            //salarycount = salarycount + 1;

            double processed = 0;
            double[] valuez = new double[3];
            int i = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT top 3 [Amount] AS [Salaries], [Date] FROM [{0}$Salary Processing Buffer] WHERE [Member No_]=@MemberNo AND [Processed]='1' ORDER BY [Date] DESC", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@MemberNo", membernumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                              
                                valuez[i] = (Convert.ToDouble(dr["Salaries"]));
                                i++;

                            }
                        if (option == 0)
                        {
                            processed = processed;

                        }
                        else if (option == 1)
                        {
                            double salary = valuez.Average();
                            StatisticalSalary = salary;
                            processed = salary * percentage;
                            

                        }
                        else if (option == 2)
                        {
                            double salary = valuez.Max();
                            StatisticalSalary = salary;
                            processed = salary * percentage;

                        }
                        else if (option == 3)
                        {
                            double salary = valuez.Min();
                            StatisticalSalary = salary;
                            processed = salary * percentage;

                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return processed;
        }

        #endregion ProcessLastThreeSalaries

        #region GetOption
        protected int GetOption()
        {
            int option = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [One Month Auto Option] FROM [{0}$Product Factory] WHERE [Product ID]='A04'", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                option = Convert.ToInt32(dr["One Month Auto Option"]);
                            }
                    }
                }
            }
            catch
            {
                throw;
            }
            return option;
        }
        #endregion GetOption

        #region GetPercentage
        protected double GetPercentage()
        {
            double percentage = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Percentage of Net Salary] FROM [{0}$Product Factory] WHERE [Product ID]='A04'", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                percentage = ((Convert.ToInt32(dr["Percentage of Net Salary"])) * 0.01);

                            }
                    }
                }
            }
            catch
            {
                throw;
            }
            return percentage;
        }
        #endregion GetPercentage

        #region GetStandingOrderAmount
        protected double GetStandingOrderAmount(string membernumber)
        {
            double amount = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Amount] FROM [{0}$Standing Orders] WHERE [Member No]=@MemberNo AND [Destination Account No_] LIKE 'A06%'", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@MemberNo", membernumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                amount += Convert.ToDouble(dr["Amount"]);

                            }
                    }
                }
            }
            catch
            {
                throw;
            }
            return Convert.ToDouble(1500);
        }
        #endregion GetStandingOrderAmount

        #region GetOustandingBalance
        protected double GetOustandingBalance(string loannumber)
        {
            double balance = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                   string A = String.Format("SELECT isnull(Sum([Amount]),0) AS [Amount] FROM [{0}$Member Ledger Entry] WHERE [Loan No]=@LoanNo AND [Transaction Types] in (4,5)", MyClass.CompanyName);

                   // string A = String.Format("SELECT isnull(Sum([Amount]),0) AS [Amount] FROM [{0}$Member Ledger Entry] WHERE [Loan No]=@LoanNo", MyClass.CompanyName); 
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
            }
            return balance;
        }
        #endregion GetOustandingBalance

        #region GetOustandingInterest
        protected double GetOustandingInterest(string loannumber)
        {
            double interest = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT isnull(Sum([Amount]),0) AS [Amount] FROM [{0}$Member Ledger Entry] WHERE [Loan No]=@LoanNo AND [Transaction Types] in (8,9)", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@LoanNo", loannumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                interest = Convert.ToDouble(dr["Amount"]);

                            }
                    }
                }
            }
            catch
            {
                throw;
            }
            return interest;
        }
        #endregion GetOustandingInterest

        #region GetLoansNumber
        protected string[] GetLoansNumber(string membernumber, int count)
        {
            int i = 0;
            string[] loannumbers = new string[count];
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Loan  No_] FROM [{0}$Loans] WHERE [Member No_]=@MemberNo AND [Loan Span] = 1 ", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@MemberNo", membernumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                               
                                loannumbers[i]= dr["Loan  No_"].ToString();
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

        #endregion GetLoansNumber

        #region GetRepayment
        protected double GetRepayment(string loannumber)
        {
            double repayment = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Repayment] FROM [{0}$Loans] WHERE [Loan  No_]=@LoanNo AND [Loan Span] = 1 ", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@LoanNo", loannumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                repayment = Convert.ToDouble(dr["Repayment"]);

                            }
                    }
                }
            }
            catch
            {
                throw;
            }
            return repayment;
        }
        #endregion GetRepayment

        #region GetLoansCount
        protected int GetLoansCount(string membernumber)
        {
            int count = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT COUNT ([Loan  No_]) AS [Count] FROM [{0}$Loans] WHERE [Member No_]=@MemberNo AND [Loan Span] = 1 ", MyClass.CompanyName);
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
        #endregion GetLoansCount

        #region GetSalariesCount
        protected int GetSalariesCount(string membernumber)
        {
            int count = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT top 3 [Amount], [Date] FROM [{0}$Salary Processing Buffer] WHERE [Member No_]=@MemberNo ORDER BY [Date] DESC", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@MemberNo", membernumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                count++;

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
        #endregion GetLoansCount

        #region GetInterestRate

        protected double GetInterestRate(string loannumber)
        {
            double rate = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Interest] FROM [{0}$Loans] WHERE [Loan  No_]=@LoanNo AND [Loan Span] = 1", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@LoanNo", loannumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                rate = Convert.ToDouble(dr["Interest"]);

                            }
                    }
                }
            }
            catch
            {
                throw;
            }
            return rate;
        }

        #endregion

        protected void PopulateTable(double salary, double deductions, double qualified)
        {
            txtSalary.Text = (Math.Round(salary, 2)).ToString();
            //txtSalary.Text = salary.ToString();
            txtDeduction.Text = deductions.ToString();
            txtQualifyingAmount.Text = qualified.ToString();


        }
    }
}