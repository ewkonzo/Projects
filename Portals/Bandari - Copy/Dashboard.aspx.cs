using System;
using System.Data.SqlClient;
using Bandari_Sacco.controller;

namespace Bandari_Sacco
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }


        public string TotalDeposits()
        {
            string totalDeposits = string.Empty;
            try
            {                
                double depositdigits = 0;
                using (var conn = CRUD.getconnToNAV())
                {

                    //var s = "SELECT isnull(Sum([Amount]*-1),0) as TotalDeposits FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
                    //           "WHERE [Customer No_]=@Member_No";
                    //var s = "SELECT isnull(Sum(a.[Amount]*-1),0) as TotalDeposits FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                    //      "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND b.[No_] LIKE 'L01%' AND a.[Transaction Types] =0";

                    var s = "SELECT isnull(Sum(a.[Amount]*-1),0) as TotalDeposits FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b   " +
                            "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Customer No_] LIKE 'S01%' " +
                            "UNION " +
                            "SELECT isnull(Sum(a.[Amount]*-1),0) as TotalDeposits FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b   " +
                            "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Customer No_] LIKE 'S02%' " +
                            "UNION " +
                            "SELECT isnull(Sum(a.[Amount]*-1),0) as TotalDeposits FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b   " +
                            "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Customer No_] LIKE 'S06%' ";


                    var command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@Member_No", Session["Member_No"]);

                    using (var dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                depositdigits += Convert.ToDouble(dr["TotalDeposits"]);
                                //totalDeposits = (Convert.ToDouble(dr["TotalDeposits"])).ToString("N");
                            }
                            totalDeposits = depositdigits.ToString("N");
                        }
                    }
                }
               
            }
            catch
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
                
            }
            return totalDeposits;
        }

        public string TotalLoanRepayments()
        {
            var totalRepayments = string.Empty;
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
                                totalRepayments = (Convert.ToDouble(dr["Repayment"])).ToString("N");
                            }
                        }
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

        public string TotalShareCapital()
        {
            var totalShareCapital = string.Empty;
            try
            {
               
                using (var conn = CRUD.getconnToNAV())
                {

                    //var s = string.Format("SELECT isnull(Sum([Amount]*-1),0)[Shares] FROM {0} WHERE [Customer No_]=@Member_No AND [Transaction Types]=14", "[" + MyClass.CompanyName + "$Member Ledger Entry]");
                    var s = "SELECT isnull(Sum(a.[Amount]*-1),0) as [Shares] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                           "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND [Transaction Types]=2";
                    var command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@Member_No", Session["Member_No"]);
                    using (var dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                totalShareCapital = (Convert.ToDouble(dr["Shares"])).ToString("N");
                            }
                        }
                    }
                }
              
            }
            catch
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
            return totalShareCapital;
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
                totalloans = totalbalance.ToString("N");
            }
            catch
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
            return totalloans;
        }


        public string LatestTransactions()
        {
            string htmlStr = "";
            string productname = "";
            string productid = "";
            double balancelcy = 0;
            int i = 0; 
            string membernumber = Session["Member_No"].ToString().Trim();
            int returnedcount = GetAccountCount(membernumber);
            string [] accountnumber = GetMembersAccount(membernumber, returnedcount);
            foreach (string one in accountnumber)
            {
                balancelcy = GetBalanceLCY(one);
                productname = GetProductName(one);
                productid = GetProductID(one);
                if (balancelcy != 0)
                {
                    htmlStr += string.Format("<tr><td class='small' style='font-size:10px'>{0}</td><td class='small' style='font-size:10px'>{1}</td><td class='small' style='font-size:10px'>{2}</td><td></td></tr>", productname, productid, balancelcy);
                }
               
            }
              
               
            return htmlStr;
        }
        // 
        public string LoanStatement()
        {
            string htmlStr = "";
            try
            {
                string Loan_Type = "", Loan_Detail = "";
               

                using (SqlConnection conn = CRUD.getconnToNAV())
                {
                    //string s =
                    //    "SELECT Top 6 a.[Issued Date],a.[Application Date],a.[Approved Amount],b.[Product Description], a.[Loan Product Type Name]" +
                    //    " FROM [" + MyClass.CompanyName + "$Loans] a,[" + MyClass.CompanyName + "$Loan Product Types] b" +
                    //    " WHERE a.[Member No_]=@Member_No AND a.[Loan Product Type]=b.[Code] ORDER BY [Application Date] DESC";

                    string s =
                              "SELECT Top 10 a.[Loan Disbursement Date],a.[Application Date],a.[Approved Amount],b.[Product Description], a.[Loan Product Type Name]" +
                              " FROM [" + MyClass.CompanyName + "$Loans] a,[" + MyClass.CompanyName + "$Product Factory] b" +
                              " WHERE a.[Member No_]=@Member_No AND a.[Loan Product Type]=b.[Product ID] ORDER BY [Application Date] DESC";
                    SqlCommand command = new SqlCommand(s, conn);

                    command.Parameters.AddWithValue("@Member_No", Session["Member_No"]);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            int i = 0;
                            while (dr.Read())
                            {
                                i++;


                                Loan_Detail = dr["Loan Product Type Name"].ToString();
                                DateTime dt_ = DateTime.Now;

                                //if (dr["Issued Date"] != null)
                                //{
                                //    dt_ = Convert.ToDateTime(dr["Issued Date"]);
                                //}
                                if (dr["Loan Disbursement Date"] != null)
                                {
                                    dt_ = Convert.ToDateTime(dr["Loan Disbursement Date"]);
                                }


                                else if (dr["Application Date"] != null)
                                {
                                    dt_ = Convert.ToDateTime(dr["Application Date"]);
                                }

                                Loan_Type = dr["Product Description"].ToString().ToUpper();


                                var approvedAmount = Convert.ToDouble(dr["Approved Amount"].ToString()).ToString("N");


                                htmlStr += "<tr><td class='small' style='font-size:10px'>" + dt_ +
                                           "</td><td class='small' style='font-size:10px'>" + Loan_Detail + "</td><td class='small' style='font-size:10px'>" + Loan_Type +
                                           "</td><td class='small' align='right' style='font-size:10px'>" + approvedAmount + "</td></tr>";
                            }
                        }
                    }

                }
                
            }
            catch
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
            return htmlStr;
            
        }

        protected string SavingsAccountStatement()
        {
            string htmlStr = "";
            try
            {
                string description = "";
                double amount = 0, closingbalance = 0, creditamount = 0, debitamount = 0, totalcreditamount = 0, totalclosingbalance = 0;
                DateTime postingdate = DateTime.Now;
                string stringpostingdate = "";
               

                using (SqlConnection conn = CRUD.getconnToNAV())
                {
                    string s = "SELECT Top 10 a.[Posting Date],a.[Description],a.[Amount],a.[Debit Amount],a.[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                                "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Customer No_] like 'L01%'" +
                                "ORDER BY a.[Posting Date] DESC";
                    SqlCommand command = new SqlCommand(s, conn);

                    command.Parameters.AddWithValue("@Member_No", Session["Member_No"]);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            int i = 0;
                            while (dr.Read())
                            {
                                i++;
                                postingdate = Convert.ToDateTime(dr["Posting Date"].ToString().Trim());
                                stringpostingdate = postingdate.ToShortDateString();
                                description = dr["Description"].ToString().Trim();
                                amount = -Convert.ToDouble(dr["Amount"].ToString().Trim());
                                debitamount = Convert.ToDouble(dr["Debit Amount"].ToString().Trim());
                                creditamount = Convert.ToDouble(dr["Credit Amount"].ToString().Trim());

                                closingbalance += (creditamount - debitamount);

                                totalcreditamount += creditamount;
                                totalclosingbalance += closingbalance;
                                htmlStr += "<tr><td class='small' style='font-size:10px'>" + stringpostingdate +
                                           "</td><td class='small' style='font-size:10px'>" + description +
                                           "</td><td class='small' style='font-size:10px'>" + debitamount +
                                           "</td><td class='small' style='font-size:10px'>" + creditamount +
                                           "</td><td class='small' style='font-size:10px'>" + amount + "</td></tr>";
                            }
                        }
                    }
                }
              
            }
            catch
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
            return htmlStr;
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
        protected int GetAccountCount(string membernumber)
        {
            int count = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT COUNT ([No_]) AS [Count] FROM [{0}$SACCO Account] WHERE [Member No_]=@MemberNo AND [Account Product Category]=2", MyClass.CompanyName);
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

        protected string[] GetMembersAccount(string membernumber, int count)
        {
            int i = 0;
            string[] accountnumber = new string[count];
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [No_] FROM [{0}$SACCO Account] WHERE [Member No_]=@MemberNo AND [Account Product Category]=2", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@MemberNo", membernumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                accountnumber[i] = dr["No_"].ToString();
                                i++;

                            }
                    }
                }
            }
            catch
            {
                throw;
            }

            return accountnumber;
        }

        protected double GetBalanceLCY(string accountnumber)
        {
            double balance = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT isnull(Sum([Amount]*-1),0) as [Balance] FROM [{0}$Member Ledger Entry] WHERE [Customer No_]=@CustomerNo", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CustomerNo", accountnumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                balance = Convert.ToDouble(dr["Balance"]);

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


        protected string GetProductName(string accountnumber)
        {
            string productname = "";
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Product Name] FROM [{0}$SACCO Account] WHERE [No_]=@CustomerNo", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CustomerNo", accountnumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                productname = dr["Product Name"].ToString();

                            }
                    }
                }
            }
            catch
            {
                throw;

            }

            return productname;
        }

        protected string GetProductID(string accountnumber)
        {
            string productid = "";
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Product Type] FROM [{0}$SACCO Account] WHERE [No_]=@CustomerNo", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CustomerNo", accountnumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                productid = dr["Product Type"].ToString();

                            }
                    }
                }
            }
            catch
            {
                throw;

            }

            return productid;
        }

    }
}