using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace AgencyClientService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string Login(string AgentCode, string Pin)
        {
            string b = "false";

            try
            {
                using (SqlConnection connToNAV = Cutilities.getconnToAgencyDB())
                {

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = "SELECT [Agent Code], [Active] FROM [Agents] WHERE [Agent Code]=@agentcode AND [Password]=@password";
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@agentcode", AgentCode);
                    cmdRt.Parameters.AddWithValue("@password", Pin);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            string active = dr["Active"].ToString();
                            if (active != "True")
                            {
                                b = "Inactive account";
                            }
                            else
                            {

                                b = "true";
                            }

                        }

                    }

                }


            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return b;
        }
        
        [WebMethod]
        public string GetAccounts(string IdNumber)
        {
            string accounts = string.Empty;
            try
            {
                using (SqlConnection connToNAV = Cutilities.getconnToNAV())
                {

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("SELECT [No_], [Name], [Phone No_] FROM [{0}$Vendor] WHERE [ID No_] =@idnumber AND [Blocked]='0' AND (Status = 0 OR Status = 4)", Cutilities.Company_Name);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@idnumber", IdNumber);                    
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            accounts = String.Format("{0}:::{1}:::{2}", dr["No_"], dr["Name"], dr["Phone No_"]);

                        }
                        else {
                            accounts = "none";
                        }
                        

                    }

                }


            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return accounts;
        }

        [WebMethod]
        public string GetAccountsWithBalance(string IdNumber)
        {
            string accounts = string.Empty;
            double bal = 0.0;

            try
            {
                using (SqlConnection connToNAV = Cutilities.getconnToNAV())
                {

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("SELECT [No_], [Name], [Phone No_] FROM [{0}$Vendor] WHERE [ID No_] =@idnumber AND [Blocked]='0' AND (Status = 0 OR Status = 4)", Cutilities.Company_Name);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@idnumber", IdNumber);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            accounts = String.Format("{0}:::{1}:::{2}", dr["No_"], dr["Name"], dr["Phone No_"]);

                            string acctNo = dr["No_"].ToString();
                            string accType = GetAccountType(acctNo, connToNAV);
                            double minbal = getMinimumBal(accType, connToNAV);
                            double ledgBal = getLedgerBal(acctNo, connToNAV);

                            bal = ledgBal - minbal;
                            accounts = String.Format("{0}:::{1}", accounts, bal);
                        }
                        else
                        {
                            accounts = "none";
                        }


                    }

                }


            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return accounts;
        }

        [WebMethod]
        public string AccountActivation(string acctNo, string Agentcode, string accName, string telNo, string idNo, string pin)
        {
            string result = string.Empty;
            bool b = false;
            try {
                b = isActivated(idNo);
                if (b == false)
                {
                    try
                    {
                        //  INSERT INTO AGECNY DB
                        using (SqlConnection connToNAV = Cutilities.getconnToAgencyDB())
                        {
                            SqlCommand cmdRt = new SqlCommand();
                            string SQL = string.Format("INSERT INTO [Agency Members] ([ID No], [Telephone No],[Pin], [Pin Changed], [Date Registered]) " +
                              " VALUES ('{0}' ,'{1}' ,'{2}' ,'{3}', '{4}')", idNo, telNo, pin, "0", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                            cmdRt.CommandText = SQL;
                            cmdRt.Connection = connToNAV;
                            cmdRt.CommandType = CommandType.Text;
                            cmdRt.ExecuteNonQuery();
                        }

                        // SEND TRANSACTION
                        //  public static void InsertTransactions(string AccNo, string transDesc, string Amount, int transactionType, string AgentCode, string loanNo, string AccountName, string telNo, string IdNo,string accTo){

                        b = Transactions.InsertTransactions(acctNo, "Member Activation", "0", 11, Agentcode, "", accName, telNo, idNo, "");
                     
                        result = b.ToString();

                    }catch(Exception ex){
                        ex.Data.Clear();
                    }
                }
                else {
                    result = "activated";
                }
            
            }catch(Exception ex){
                ex.Data.Clear();
            }

            return result;
        }

        [WebMethod]
        public string GetMemberPin(string IdNo) {

            string res = string.Empty;
            try {
                using (SqlConnection connToNAV = Cutilities.getconnToAgencyDB())
                {
                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = string.Format("SELECT [Pin] FROM [Agency Members] WHERE [ID No] = {0} ", IdNo);                
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.ExecuteNonQuery();
                }
            
            }catch(Exception Ex){
                Ex.Data.Clear();
            }

            return res;
        }

        
        [WebMethod]
        public string AccountOpening(string AccName, string NationalID, string TelNo, string Society, string MemberNo, string Amount, string AgentCode) {
            string results = string.Empty;
            bool b = false;
            try {
                // SEND TRANSACTION
                //  public static void InsertTransactions(string AccNo, string transDesc, string Amount, int transactionType, string AgentCode, string loanNo, string AccountName, string telNo, string IdNo,string accTo){

                b = Transactions.InsertOperation("Account Opening", Amount, 1, AgentCode, AccName, TelNo, NationalID, Society,MemberNo );
                results = b.ToString();
            }catch(Exception Ex){
                Ex.Data.Clear();
            }
            return results;
        }
        [WebMethod]
        public string MemberRegistration(string AccName, string NationalID, string TelNo, string Society, string MemberNo, string Amount, string AgentCode)
        {
            string results = string.Empty;
            bool b = false;
            try
            {
                // SEND TRANSACTION
                //  public static void InsertTransactions(string AccNo, string transDesc, string Amount, int transactionType, string AgentCode, string loanNo, string AccountName, string telNo, string IdNo,string accTo){

                b = Transactions.InsertOperation("Member Registration", Amount, 12, AgentCode, AccName, TelNo, NationalID, Society, MemberNo);
                results = b.ToString();
            }
            catch (Exception Ex)
            {
                Ex.Data.Clear();
            }
            return results;
        }
      
        [WebMethod]
        public string GetShareAccount(string IdNumber)
        {
            string accounts = string.Empty;
            try
            {
                using (SqlConnection connToNAV = Cutilities.getconnToNAV())
                {

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("SELECT [No_], [Name], [Phone No_] FROM [{0}$Members] WHERE [ID No_] =@idnumber AND [Blocked]='0' AND (Status = 0 OR Status = 4)", Cutilities.Company_Name);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@idnumber", IdNumber);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            accounts = String.Format("{0}:::{1}:::{2}", dr["No_"], dr["Name"], dr["Phone No_"]);

                        }
                        else {
                            accounts = "none";
                        }


                    }

                }


            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
                
            }

            return accounts;
        }

        [WebMethod]
        public string GetLoanDetails(string IdNumber)
        {
            string accounts = string.Empty;
            string BosaNo = string.Empty;
            try
            {
                using (SqlConnection connToNAV = Cutilities.getconnToNAV())
                {

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("SELECT [Loan  No_], [Loan Product Type Name], [Client Code] FROM [{0}$Loans] WHERE [ID NO] =@idnumber AND [Loan Status]='4'", Cutilities.Company_Name);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@idnumber", IdNumber);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            BosaNo = dr["Client Code"].ToString();
                            accounts = String.Format("{0}:::{1}", dr["Loan  No_"], dr["Loan Product Type Name"]);

                            string moredetails = GetMoreDetails(BosaNo, connToNAV);
                            accounts = String.Format("{0}:::{1}", accounts, moredetails);
                        }
                        else
                        {
                            accounts = "none";
                        }

                        
                    }

                }


            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);

            }

            return accounts;
        }

        private string GetMoreDetails(string BosaNo, SqlConnection connToNAV)
        {
            string results = string.Empty;
            try
            {
                
                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("SELECT [Phone No_], [ID No_] FROM [{0}$Members] WHERE [No_] =@bosaNo ", Cutilities.Company_Name);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@bosaNo", BosaNo);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            results = String.Format("{0}:::{1}", dr["Phone No_"], dr["ID No_"]);

                        }
                    
                }
            }catch(Exception ex){
                //Cutilities.LogEntryOnFile(ex.Message);
            }
            return results;
        }

        [WebMethod]
        public string GetAccountName(string AccNo)
        {
            string accounts = string.Empty;
            try
            {
                using (SqlConnection connToNAV = Cutilities.getconnToNAV())
                {

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("SELECT [No_], [Name], [Phone No_] FROM [{0}$Vendor] WHERE [No_] =@AccNo AND [Blocked]='0' AND (Status = 0 OR Status = 4)", Cutilities.Company_Name);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@AccNo", AccNo);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            accounts = String.Format("{0}:::{1}", dr["Name"], dr["Phone No_"]);

                        }


                    }

                }


            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return accounts;
        }

        [WebMethod]
        public string BalanceEnquiry(string acctNo, string Agentcode, string accName, string telNo, string idNo)
        {
                     
            double bal = 0.0;
            try{
                string accType = GetAccountType(acctNo);
                double minbal = getMinimumBal(accType);
                double ledgBal = getLedgerBal(acctNo);

                bal = ledgBal - minbal;
                //  public static void InsertTransactions(string AccNo, string transDesc, string Amount, int transactionType, string AgentCode, string loanNo, string AccountName, string telNo, string IdNo){
                Transactions.InsertTransactions(acctNo, "Balance", "0", 8, Agentcode, "", accName, telNo, idNo,"");
            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return bal.ToString();
        }

        [WebMethod]
        public string WithdrawCash(string acctNo, string amount, string Agentcode, string accName, string telNo, string idNo)
        {
            string b = "false";
            double bal = 0.0;
            bool t = false;
            try
            {
                string accType = GetAccountType(acctNo);
                double minbal = getMinimumBal(accType);
                double ledgBal = getLedgerBal(acctNo);

                bal = ledgBal - minbal;
                if (double.Parse(amount) < bal)
                {
                    //  public static void InsertTransactions(string AccNo, string transDesc, string Amount, int transactionType, string AgentCode, string loanNo, string AccountName, string telNo, string IdNo){
                   t= Transactions.InsertTransactions(acctNo, "Cash Withdrawal", amount, 2, Agentcode, "", accName, telNo, idNo, "");
                    b = t.ToString();
                }
                else {
                    b = "No";
                }
            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return b;
        }

        [WebMethod]
        public string Ministatement(string acctNo,  string Agentcode, string accName, string telNo, string idNo)
        {
            string b = "false";
            string ministatement = string.Empty;
            bool t = false;
            try
            {
                using (SqlConnection connToNAV = Cutilities.getconnToNAV())
                {

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = "SELECT TOP 5 CONVERT(varchar(12), v.[Posting Date],103) as [Posting Date] , v.[Description], dv.Amount FROM [" + Cutilities.Company_Name + "$Vendor Ledger Entry] v, [" + Cutilities.Company_Name + "$Detailed Vendor Ledg_ Entry] dv " +
                        " WHERE  v.[Entry No_] = dv.[Vendor Ledger Entry No_]  AND v.[Vendor No_]=@acctno ORDER BY v.[Posting Date] DESC ";
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@acctno", acctNo);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if(dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //string bal = dr["Minimum Balance"].ToString();
                                ministatement += String.Format("{0} -{1} -{2}.00::::", dr["Posting Date"], dr["Description"], Double.Parse(dr["Amount"].ToString()));
                                //d = Math.Round(d, 2);
                            }

                        }

                    }

                } 
            
                    //  public static void InsertTransactions(string AccNo, string transDesc, string Amount, int transactionType, string AgentCode, string loanNo, string AccountName, string telNo, string IdNo){
                t = Transactions.InsertTransactions(acctNo, "Mini Statement", "0", 9, Agentcode, "", accName, telNo, idNo, "");
                    b = t.ToString();
            
            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }
            if (b == "True")
            {
                return ministatement;
            }
            else
            {

                return b;
            }
        }

        [WebMethod]
        public bool ShareDeposit(string acctNo, string amount, string Agentcode, string accName, string telNo, string idNo)
        {
            bool b = false;
            try
            {
                //  public static void InsertTransactions(string AccNo, string transDesc, string Amount, int transactionType, string AgentCode, string loanNo, string AccountName, string telNo, string IdNo){
                Transactions.InsertTransactions(acctNo, "Share Deposit", amount, 6, Agentcode, "", accName, telNo, idNo, "");
                b = true;
            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return b;
        }

        [WebMethod]
        public bool CashDeposit(string acctNo, string amount, string Agentcode, string accName, string telNo, string idNo)
        {
            bool b = false;
            try
            {
                //  public static void InsertTransactions(string AccNo, string transDesc, string Amount, int transactionType, string AgentCode, string loanNo, string AccountName, string telNo, string IdNo){
                Transactions.InsertTransactions(acctNo, "Cash Deposit", amount, 3, Agentcode, "", accName, telNo, idNo, "");
                b = true;
            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return b;
        }

        [WebMethod]
        public bool LoanRepayment(string amount, string LoanNo, string Agentcode, string telNo, string idNo)
        {
            bool b = false;
            try
            {
                //  public static void InsertTransactions(string AccNo, string transDesc, string Amount, int transactionType, string AgentCode, string loanNo, string AccountName, string telNo, string IdNo){
                Transactions.InsertTransactions("", "Loan Repayment", amount, 4, Agentcode, LoanNo, "", telNo, idNo,"");
                b = true;
            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return b;
        }

        [WebMethod]
        public string CashTransfer(string accFrom, string accTo, string amount, string Agentcode, string accName, string telNo, string idNo)
        {
            string b = "false";
            bool t = false;
            double bal = 0.0;
            try
            {
                string accType = GetAccountType(accFrom);
                double minbal = getMinimumBal(accType);
                double ledgBal = getLedgerBal(accFrom);

                bal = ledgBal - minbal;
                if (double.Parse(amount) < bal)
                {
                    //  public static void InsertTransactions(string AccNo, string transDesc, string Amount, int transactionType, string AgentCode, string loanNo, string AccountName, string telNo, string IdNo){
                 t=  Transactions.InsertTransactions(accFrom, "Inter Account Transfer", amount, 5, Agentcode, "", accName, telNo, idNo, accTo);
                    b = t.ToString();
                }
                else
                {
                    b = "No";
                }
            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return b;
        }

        public string GetAccountType(string accountNo) {
            string acctype = string.Empty;

            try
            {
                using (SqlConnection connToNAV = Cutilities.getconnToNAV())
                {

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("SELECT [Account Type] FROM [{0}$Vendor] WHERE [No_] =@accno", Cutilities.Company_Name);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@accno", accountNo);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            acctype = dr["Account Type"].ToString();

                        }

                    }

                }


            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }
            return acctype;
        }

        public double getMinimumBal(string acctype)
        {
            double d = 0.0;
            try
            {
                using (SqlConnection connToNAV = Cutilities.getconnToNAV())
                {

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("SELECT [Minimum Balance] FROM [{0}$Account Types] WHERE [Code] =@acctype", Cutilities.Company_Name);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@acctype", acctype);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            //string bal = dr["Minimum Balance"].ToString();
                            d = Convert.ToDouble( dr["Minimum Balance"]);
                            //d = Math.Round(d, 2);

                        }

                    }

                }


            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return d;
        
        }

        public double getLedgerBal(string acctNo)
        {

            double d = 0.0;
            try
            {
                using (SqlConnection connToNAV = Cutilities.getconnToNAV())
                {

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("SELECT  isnull(SUM(Amount),0) as Amount FROM [{0}$Detailed Vendor Ledg_ Entry] WHERE [Vendor No_] =@accno", Cutilities.Company_Name);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@accno", acctNo);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            //string bal = dr["Minimum Balance"].ToString();
                            d = Convert.ToDouble(dr["Amount"]);
                            d = Math.Round(d, 2);
                            d = d * -1;

                        }

                    }

                }


            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return d;
        }

        public string GetAccountType(string accountNo, SqlConnection connToNAV)
        {
            string acctype = string.Empty;

            try
            {
                

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("SELECT [Account Type] FROM [{0}$Vendor] WHERE [No_] =@accno", Cutilities.Company_Name);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@accno", accountNo);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            acctype = dr["Account Type"].ToString();

                        }

                    }
                


            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }
            return acctype;
        }

        public double getMinimumBal(string acctype, SqlConnection connToNAV)
        {
            double d = 0.0;
            try
            {
               

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("SELECT [Minimum Balance] FROM [{0}$Account Types] WHERE [Code] =@acctype", Cutilities.Company_Name);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@acctype", acctype);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            //string bal = dr["Minimum Balance"].ToString();
                            d = Convert.ToDouble(dr["Minimum Balance"]);
                            //d = Math.Round(d, 2);

                        }

                    }             


            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return d;

        }

        public double getLedgerBal(string acctNo, SqlConnection connToNAV)
        {

            double d = 0.0;
            try
            {
                
                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("SELECT  isnull(SUM(Amount),0) as Amount FROM [{0}$Detailed Vendor Ledg_ Entry] WHERE [Vendor No_] =@accno", Cutilities.Company_Name);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@accno", acctNo);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            //string bal = dr["Minimum Balance"].ToString();
                            d = Convert.ToDouble(dr["Amount"]);
                            d = Math.Round(d, 2);
                            d = d * -1;

                        }

                    }          


            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return d;
        }

        private bool isActivated(string idNo)
        {
            bool b = false;
            try
            {
                using (SqlConnection connToNAV = Cutilities.getconnToAgencyDB())
                {

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = "SELECT [ID No] FROM [Agency Members] WHERE [ID No] =@idno";
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@idno", idNo);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            //acctype = dr["Account Type"].ToString();
                            b = true;
                        }

                    }

                }


            }
            catch (Exception ex)
            {
                Cutilities.LogEntryOnFile(ex.Message);
            }
            return b;
        }
    }
}