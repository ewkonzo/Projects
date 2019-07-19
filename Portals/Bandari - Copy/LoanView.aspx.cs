using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using Bandari_Sacco.controller;

namespace Bandari_Sacco
{
    public partial class LoanView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            TotalLoans();
        }

        protected string TotalLoans()
        {
            double balance = 0;
            string balance1 = "";
            int i = 0;
            string htmlStr = "";
            string membernumber = Session["Member_No"].ToString().Trim();
            int returnedcount = GetLoansCount(membernumber);
            string[] loannumber = GetLoansNumber(membernumber, returnedcount);
            foreach (string one in loannumber)
            {
                
                balance = GetOustandingBalance(one);
                if(balance != 0)
                {
                    balance1 = balance.ToString("N");
                    i++;
                    htmlStr += string.Format(@"<tr>
                                           <td class='small'>{0}</td>
                                           <td class='small'>{1}</td>
                                           <td class='small'>KSH.{2}</td>
                                           </tr>", i, one, balance1);
                }
                
            }
            return htmlStr;
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
               // throw;
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
            return balance;
        }

    }
}