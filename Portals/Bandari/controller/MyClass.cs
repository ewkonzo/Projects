#region
using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net.Mail;
using System.IO;
using System.Text.RegularExpressions;
#endregion

namespace Bandari_Sacco.controller
{
    public static class MyClass
    {
        #region Variables
      
        public static SqlConnection connToNAV;
        public static string CompanyName = "Bandari Sacco Ltd";
        public static string ListingPerPage = "200";

        public static Online_User.Online_User user(string User_Name) {
            Online_User.Online_User users= null;
            try {
                users = Global.user_Service.Read(User_Name);

            } catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return users;
        }

        #endregion

        #region getconn To NAV

        //public static SqlConnection getconnToNAV()
        //{
        //    if (connToNAV == null || connToNAV.State == ConnectionState.Closed)

        //        connToNAV = new SqlConnection(@"Data Source=KAMUYE-PC;Initial Catalog=CoreTEC Sacco;MultipleActiveResultSets=true;User ID=sa;Password=123");//

        //    //connToNAV = new SqlConnection(@"Data Source=192.168.1.179;Initial Catalog=WAUMINIDB;MultipleActiveResultSets=true;User ID=webportal;Password=W@up0rtal1");

        //    // connToNAV.Open();

        //    return connToNAV;
        //}

        public static SqlConnection getconnToNAV()
        { return CRUD.getconnToNAV(); }

        #endregion

        #region Generate Random String

        public static string RandomString()
        {
            string rStr = Path.GetRandomFileName();
            rStr = rStr.Replace(".", ""); // For Removing the .
            return rStr;
        }

        #endregion

        #region Send Email Alert Using Sacco SMTP

        public static Boolean SendEmailAlert_(string body, string recepient, string subject, string attachmentFilename)
        {
            Boolean x = false;
            try
            {
                MailMessage mail = new MailMessage();

                string smtpServer, _User_ID, _pass;

                smtpServer = "192.168.0.215";
                _User_ID = "administrator"; //clientservices
                _pass = "YO~#g{Be356@Pj-";  //silica1*

                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                mail.From = new MailAddress("administrator@gerties.org");
                mail.To.Add(recepient);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(_User_ID, _pass);
                System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(smtpServer, 25);
                mailClient.EnableSsl = false;
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = mailAuthentication;

                mailClient.Send(mail);
                x = true;

            }
            catch (Exception ex2)
            {
                ex2.Data.Clear();
            }

            return x;
        }
        #endregion

        #region send Email Using Gmail SMTP

        public static Boolean SendEmailAlert_Gmail(string body, string recepient, string subject, string attachmentFilename)
        {
            Boolean x = false;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.Headers.Add("Message-Id", String.Concat("<", DateTime.Now.ToString("yyMMdd"), ".", DateTime.Now.ToString("HHmmss"), "@gmail.com>"));
                mail.From = new MailAddress("mwangi.luke@gmail.com");
                mail.To.Add(recepient);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("mwangi.luke", "24439817");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                x = true;
            }
            catch (Exception ex2)
            {
                ex2.Data.Clear();
            }
            return x;
        }
        #endregion

        #region Send Email Alert Using GMAIL SMTP

        public static Boolean SendEmailAlert(string body, string recepient, string subject, string attachmentFilename)
        {
            Boolean x = false;

            string a = "";
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.Headers.Add("Message-Id", String.Concat("<", DateTime.Now.ToString("yyMMdd"), ".", DateTime.Now.ToString("HHmmss"), "@gmail.com>"));
                mail.From = new MailAddress("edukamuye@gmail.com");
                mail.To.Add(recepient);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("postbanksacco", "Opere2013$$");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                x = true;

                

                x = true;
               

            }
            catch (Exception ex2)
            {
                ex2.Data.Clear();
                }

            return x;
        }
        #endregion

        #region get Member Names

        public static string getMembersNames(string Member_No_)
        {
            string returnfieldvalue = "";


            var m = Global.member_Service.Read(Member_No_);

            if (m != null) returnfieldvalue = m.Name;


            //using (SqlConnection conn = Controller.getconnToNAV())
            //{

            //    string s = String.Format("SELECT [Name] FROM [{0}$Member] WHERE [No_] = @Member_No;", Controller.CompanyName);
            //    SqlCommand command = new SqlCommand(s, conn);
            //    command.Parameters.AddWithValue("@Member_No", Member_No_);

            //    using (SqlDataReader drMember = command.ExecuteReader())
            //    {
            //        if (drMember.HasRows)
            //        {
            //            drMember.Read();
            //            returnfieldvalue = drMember["Name"].ToString();
            //        }
            //    }
            //    conn.Close();
            //}
            return returnfieldvalue;
        }

        public static string getMemberFullNames(string Member_No_)
        {
            string returnfieldvalue = "";
            var m = Global.member_Service.Read(Member_No_);

            if (m != null) returnfieldvalue = m.Name;
            //using (SqlConnection conn = Controller.getconnToNAV())
            //{

            //    string s = String.Format("SELECT [First Name], [Second Name], [Last Name] FROM [{0}$Member] WHERE [No_] = @Member_No;", Controller.CompanyName);
            //    SqlCommand command = new SqlCommand(s, conn);
            //    command.Parameters.AddWithValue("@Member_No", Member_No_);

            //    using (SqlDataReader drMember = command.ExecuteReader())
            //    {
            //        if (drMember.HasRows)
            //        {
            //            drMember.Read();
            //            returnfieldvalue = drMember["First Name"].ToString() + " " + drMember["Second Name"].ToString() + " " + drMember["Last Name"].ToString();
            //        }
            //    }
            //    conn.Close();
            //}
            return returnfieldvalue;
        }
        #endregion

        #region get Member Names

        public static string get_EmployerNamesWithConnection(string EmployerCode, SqlConnection conn)
        {
            string returnfieldvalue = "";

            string s = String.Format("SELECT [Name] FROM [{0}$Customer] WHERE [No_] = @EmployerCode;", Controller.CompanyName);
            SqlCommand command = new SqlCommand(s, conn);
            command.Parameters.AddWithValue("@EmployerCode", EmployerCode);

            using (SqlDataReader drMember = command.ExecuteReader())
            {
                if (drMember.HasRows == true)
                {
                    drMember.Read();
                    returnfieldvalue = drMember["Name"].ToString();
                }
            }

            return returnfieldvalue;
        }
        #endregion

        #region FormatNumber

        public static string FormatNumber(double Number2Format)
        {
            return Controller.FormatNumber(Number2Format.ToString());
        }

        public static string FormatNumber(string Number2Format)
        {
            Number2Format = Math.Round(Convert.ToDouble(Number2Format), 2).ToString();

            if (Number2Format.Contains("(") || Number2Format.Contains(")"))
                Number2Format = Number2Format.Substring(1, Number2Format.Length - 2);

            double d = Convert.ToDouble(Number2Format);//remove non-numeric characters

            string s = d.ToString();//revert to string

            string wholeNumber = "";
            string decimalPoint = "";

            bool negativeNumber;

            if (Convert.ToDouble(Number2Format) < 0)
                negativeNumber = true;
            else
                negativeNumber = false;

            if (negativeNumber)
                s = s.Substring(1);

            try
            {
                int i, j, k;

                if (s.Contains(".") == false)
                    s += ".00";

                i = s.IndexOf(".");

                decimalPoint = s.Substring(i + 1);

                if (decimalPoint.Length == 1)
                    decimalPoint = decimalPoint + "0";
                else if (decimalPoint.Length > 2)
                    decimalPoint = decimalPoint.Substring(0, 2);

                k = 0;
                for (j = (i - 1); j >= 0; j--)
                {
                    wholeNumber = s.Substring(j, 1) + wholeNumber;

                    k++;
                    if (k == 3)
                    {
                        k = 0;

                        if (j > 0) wholeNumber = "," + wholeNumber;
                    }
                }
            }
            catch (Exception ex)
            {

                ex.Data.Clear();
            }

            if (negativeNumber) s = String.Format("-{0}.{1}", wholeNumber, decimalPoint);

            else s = String.Format("{0}.{1}", wholeNumber, decimalPoint);

            return s;
        }

        #endregion

        #region GET Current Shares

        public static double CurrentShares(string Member_No_)
        {
            double d = 0;
            string Reversed = "0";
            try
            {
                using (SqlConnection conn = Controller.getconnToNAV())
                {

                    //string A = "select sum([Amount]) as SharesZote from [" + Controller.CompanyName + "$Member Ledger Entry]" +
                    //" where [Customer No_] = @Member_No_ AND ([Transaction Types] = 8) AND Reversed=@Reversed";

                    string A = "SELECT sum(a.[Amount]) as SharesZote FROM [" + Controller.CompanyName + "$Member Ledger Entry]a, [" + Controller.CompanyName + "$SACCO Account]b  " +
                              "WHERE b.[Member No_] = @Member_No_ AND a.[Customer No_] = b.[No_] AND a.[Transaction Types]=8 AND a.[Reversed]=@Reversed";

                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@Member_No_", Member_No_);
                    command.Parameters.AddWithValue("@Reversed", Reversed);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (dr["SharesZote"] != null)
                                {
                                    d = Convert.ToDouble(dr["SharesZote"]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return (d * (-1));

        }
        #endregion

        #region GET Outstanding Loan Balance

        public static double OutstandingLoanBalance(string Member_No_)
        {
            double d = 0;
            try
            {
                using (SqlConnection conn = Controller.getconnToNAV())
                {

                    //string A = "select [Amount] as SharesZote from [" + Controller.CompanyName + "$Member Ledger Entry]" +
                    //    " where [Customer No_] = @Member_No_ " +
                    //" AND [Transaction Types] in (2,3,5,6)";

                    string A = "SELECT a.[Amount] as SharesZote FROM [" + Controller.CompanyName + "$Member Ledger Entry]a, [" + Controller.CompanyName + "$SACCO Account]b  " +
                             "WHERE b.[Member No_] = @Member_No_ AND a.[Customer No_] = b.[No_] AND a.[Transaction Types] in (2,3,5,6)";

                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@Member_No_", Member_No_);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (dr["SharesZote"] != null)
                                {
                                    d += Convert.ToDouble(dr["SharesZote"]);
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return (d);

        }
        #endregion

        #region GET Outstanding Specific Loan Balance

        public static double OutstandingSpecificLoanBalance(string loanNo)
        {
            {
                double d = 0;

                try
                {
                var lb  =    Global.loan_Service.Read(loanNo);
                    if (lb != null)
                        d =(double) lb.Loan_Balance;
                  
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }

                return d;
            }
        }
        #endregion

        #region Get Report Path

        public static string ReportsPath()
        {
            string path = "";
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            String Root = Directory.GetCurrentDirectory();
            path = Root + "\\Downloads\\";

            return path;
        }

        #endregion

        #region Get Images Path

        public static string ImagesPath()
        {
            string path = "";
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            String Root = Directory.GetCurrentDirectory();
            path = Root + "\\images\\";

            return path;
        }

        #endregion

        #region Random Number
        public static string getRandomString()
        {
            string rStr = Path.GetRandomFileName();
            rStr = rStr.Replace(".", ""); // For Removing the .
            return rStr;
        }
        #endregion

        #region Check If Changed Password

        public static string CheckIfChangedPassword(string memberNo)
        {
            string changedPassword = "0";

            

            using (SqlConnection conn = Controller.getconnToNAV())
            {

                string s = string.Format("SELECT [Changed Password] FROM [{0}$Online User] WHERE [User Name] = @Member_No", CompanyName);
                SqlCommand command = new SqlCommand(s, conn);
                command.Parameters.AddWithValue("@Member_No", memberNo);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        changedPassword = dr["Changed Password"].ToString();
                    }
                }

                conn.Close();
            }
            return changedPassword;

        }


        public static string CheckIfAccountBlocked(string memberNo)
        {
            string blocked = "2";
            var u = user(memberNo);

            //using (SqlConnection conn = Controller.getconnToNAV())
            //{

            //    string s = string.Format("SELECT [Blocked] FROM [{0}$Online User] WHERE [Login ID] = @Member_No", CompanyName);
            //    SqlCommand command = new SqlCommand(s, conn);
            //    command.Parameters.AddWithValue("@Member_No", memberNo);

            //    using (SqlDataReader dr = command.ExecuteReader())
            //    {
            //        if (dr.HasRows)
            //        {
            //            dr.Read();
            //            blocked = dr["Blocked"].ToString();
            //        }
            //    }

            //    conn.Close();
            //}
            return blocked;


        }
        #endregion

        #region GET Mothly Shares Contribution

        public static double MothlySharesContribution(string Member_No_)
        {
            double d = 0;
            try
            {
                using (SqlConnection conn = Controller.getconnToNAV())
                {

                    string A = "SELECT [Monthly Contribution] FROM [" + Controller.CompanyName + "$Member]" +
                        " WHERE [No_] = @Member_No_ ";

                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@Member_No_", Member_No_);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            if (dr["Monthly Contribution"] != null)
                            {
                                d = Convert.ToDouble(dr["Monthly Contribution"]);

                                if (d < 0)
                                {
                                    d = d * (-1);
                                }
                            }

                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return d;

        }
        #endregion

        #region GET Shares Capital

        public static double GetSharesCapital(string Member_No_)
        {
            double d = 0;
            try
            {
                using (SqlConnection conn = Controller.getconnToNAV())
                {

                    //string A = "SELECT SUM([Amount]) as SharesCapital from [" + Controller.CompanyName + "$Member Ledger Entry]" +
                    //    " where [Customer No_] = @Member_No_  AND ([Transaction Types] = 14 ";

                    string A = "SELECT Sum(a.[Amount]) as [SharesCapital] FROM [" + Controller.CompanyName + "$Member Ledger Entry]a, [" + Controller.CompanyName + "$SACCO Account]b  " +
                       "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Transaction Types]=14";

                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@Member_No_", Member_No_);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            if (dr["SharesCapital"] != null)
                            {
                                d = Convert.ToDouble(dr["SharesCapital"]);
                            }

                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return (d * (-1));

        }
        #endregion

        #region GET Last Shares Pay Date

        public static DateTime GetLastSharesPayDate(string Member_No_)
        {
            DateTime d = DateTime.Now;
            try
            {
                using (SqlConnection conn = Controller.getconnToNAV())
                {

                    //string A = "SELECT max([Posting Date]) as LastDate FROM [" + Controller.CompanyName + "$Member Ledger Entry]" +
                    //    " WHERE [Customer No_] = @Member_No_  AND [Transaction Types] = 14 ";

                    string A = "SELECT max(a.[Posting Date]) as LastDate FROM [" + Controller.CompanyName + "$Member Ledger Entry]a, [" + Controller.CompanyName + "$SACCO Account]b  " +
                    "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Transaction Types]=14";

                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@Member_No_", Member_No_);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            if (dr["LastDate"] != null)
                            {
                                d = Convert.ToDateTime(dr["LastDate"]);
                            }

                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return d;

        }
        #endregion

        #region GET Loan Last Pay Date

        public static DateTime GetLoanLastPayDateWithConnection(string Loan_No_, SqlConnection conn)
        {
            DateTime d = Convert.ToDateTime("01-01-1900");
            try
            {


                string A = "SELECT MAX([Posting Date]) as LastDate FROM [" + Controller.CompanyName + "$Member Ledger Entry]" +
                        " WHERE [Loan No] = @Loan_No_  AND [Transaction Types] = 3 ";

                SqlCommand command = new SqlCommand(A, conn);
                command.Parameters.AddWithValue("@Loan_No_", Loan_No_);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();

                        if (dr["LastDate"] != null)
                        {
                            d = Convert.ToDateTime(dr["LastDate"]);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return d;

        }
        #endregion

        #region GET Outstanding SpecificLoan Balance With Connection
        /// <summary>
        /// Gets the loan number and SqlConnection an returns the Total Loan amount as d;
        /// </summary>
        /// <param name="loanNo"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static double OutstandingSpecificLoanBalanceWithConnection(string loanNo, SqlConnection conn)
        {
            {
                double d = 0;
                double Debit_Amount = 0, Credit_Amount = 0, Closing_Balance = 0, TotalClosing_Balance = 0;


                try
                {

                    string A = "SELECT convert(DOUBLE PRECISION,[Amount]) as SharesZote,[Debit Amount],[Credit Amount] FROM [" + Controller.CompanyName + "$Member Ledger Entry]" +
                           " where [Loan No] = @loanNo" +
                           " AND [Transaction Types]  in (2,3,5,6)" +
                           " AND  ([Document No_] <> 'INT JAN2012' AND [Document No_] <> 'JAN2012 INT')"
                           ;

                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@loanNo", loanNo);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (dr["SharesZote"] != null)
                                {
                                    d += Convert.ToDouble(dr["SharesZote"]);
                                    Debit_Amount = Convert.ToDouble(dr["Debit Amount"].ToString().Trim());
                                    Credit_Amount = Convert.ToDouble(dr["Credit Amount"].ToString().Trim());

                                    Closing_Balance = Credit_Amount - Debit_Amount;
                                    TotalClosing_Balance += Closing_Balance;
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }

                return d;
            }
        }
        #endregion

        #region GET Interest Paid With Connection

        public static double InterestPaidWithConnection(string loanNo, SqlConnection conn)
        {
            {
                double d = 0;


                try
                {

                    string A = "SELECT [Amount] as SharesZote FROM [" + Controller.CompanyName + "$Member Ledger Entry]" +
                           " where [Loan No] = @loanNo" +
                           " AND [Transaction Types]  in (6)" +
                           " AND  ([Document No_] <> 'INT JAN2012' AND [Document No_] <> 'JAN2012 INT')"
                           ;

                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@loanNo", loanNo);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (dr["SharesZote"] != null)
                                {
                                    d += Convert.ToDouble(dr["SharesZote"]);

                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }

                return d;
            }
        }
        #endregion

        #region GET Total_Loans_Amount

        public static double Total_Loans_Amount(string Member_No)
        {
            {
                double d = 0;


                try
                {
                    using (SqlConnection conn = Controller.getconnToNAV())
                    {
                        string A = "SELECT [Approved Amount] as SharesZote FROM [" + Controller.CompanyName + "$Loans]" +
                            " where [Member No_]=@Member_No AND [Approved Amount]>0";

                        SqlCommand command = new SqlCommand(A, conn);
                        command.Parameters.AddWithValue("@Member_No", Member_No);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (dr["SharesZote"] != null)
                                    {
                                        d += Convert.ToDouble(dr["SharesZote"]);

                                    }
                                }
                            }
                        }
                        conn.Close();
                    }

                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }

                return d;
            }
        }
        #endregion

        #region GET Loan Type With Connection

        public static string GetLoanTypeWithConnection(string loanNo, SqlConnection conn)
        {
            {
                string d = "";

                try
                {

                    string A = "SELECT b.[Product Description] FROM [" + Controller.CompanyName + "$Loans] a,[" + Controller.CompanyName + "$Loan Product Types] b" +
                       " WHERE a.[Loan  No_] = @loanNo AND a.[Loan Product Type]=b.[Code]";

                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@loanNo", loanNo);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            if (dr["Product Description"] != null)
                            {
                                d = dr["Product Description"].ToString().Trim();
                            }

                        }
                    }

                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }

                return d;
            }
        }
        #endregion

        #region Hash Password
        public static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
        #endregion

        #region check_link_status

        public static string check_link_status(string MyGroup, string FildName)
        {

            string field_val = "0";

            using (SqlConnection conn = Controller.getconnToNAV())
            {
                string A = String.Format("SELECT [" + FildName + "] FROM [{0}$Online Access Group Priveleges] WHERE [Group Name]=" + "'" + MyGroup + "'" + "", Controller.CompanyName);
                SqlCommand cmds = new SqlCommand() { CommandType = CommandType.Text, Connection = conn, CommandText = A };
                using (SqlDataReader rdr = cmds.ExecuteReader())
                {
                    if (rdr.HasRows == true)
                    {
                        rdr.Read();
                        field_val = rdr[0].ToString();
                    }
                }

                conn.Close();
            }

            return field_val;

        }
        #endregion

        #region Get Time Entered

        public static string getTimeEntered()
        {
            return "1754-01-01 " + DateTime.Now.ToString("HH:mm:ss tt");
        }

        #endregion

        #region Get Time Sent to Server

        public static string getTimeSentToServer()
        {
            return "1753-01-01 " + DateTime.Now.ToString("HH:mm:ss tt");
        }

        #endregion

        #region Generate Random Password

        public static string GenerateRandomPassword(int passwordLength)
        {
            string allowedChars = "123456789";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
        #endregion

        #region GET Outstanding Specific Loan Balance

        //public static double OutstandingSpecificLoanBalance(string loanNo)
        //{
        //    {
        //        double d = 0;

        //        try
        //        {
        //            using (SqlConnection conn = MyClass.getconnToNAV())
        //            {

        //                string A = "SELECT b.[Amount] as SharesZote FROM [" + MyClass.CompanyName + "$Cust_ Ledger Entry] a,[" + MyClass.CompanyName + "$Detailed Cust_ Ledg_ Entry] b" +
        //                " where  a.[Entry No_]=b.[Cust_ Ledger Entry No_] AND  a.[Loan No] = @loanNo" +
        //                " and (a.[Transaction Types] = 2 or a.[Transaction Types] = 3 or a.[Transaction Types] = 5)" +
        //                " AND  (a.[Document No_] <> 'INT JAN2012' AND a.[Document No_] <> 'JAN2012 INT')"
        //                ;

        //                SqlCommand command = new SqlCommand(A, conn);
        //                command.Parameters.AddWithValue("@loanNo", loanNo);
        //                using (SqlDataReader dr = command.ExecuteReader())
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        while (dr.Read())
        //                        {
        //                            if (dr["SharesZote"] != null)
        //                            {
        //                                d += Convert.ToDouble(dr["SharesZote"]);
        //                            }
        //                        }
        //                    }
        //                }
        //                conn.Close();

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ex.Data.Clear();
        //        }

        //        return d;
        //    }
        //}
        #endregion

        #region GET Outstanding Loan Balance

        //public static double OutstandingLoanBalance(string Member_No_)
        //{
        //    double d = 0;
        //    try
        //    {
        //        using (SqlConnection conn = MyClass.getconnToNAV())
        //        {

        //            string A = "select b.[Amount] as SharesZote FROM [" + MyClass.CompanyName + "$Cust_ Ledger Entry] a,[" + MyClass.CompanyName + "$Detailed Cust_ Ledg_ Entry] b" +
        //                " where a.[Entry No_]=b.[Cust_ Ledger Entry No_] AND a.[Customer No_] = @Member_No_ " +
        //            " AND (a.[Transaction Types] = 2 or a.[Transaction Types] = 3 or a.[Transaction Types] = 5 " +
        //            " or a.[Transaction Types] = 27)";

        //            SqlCommand command = new SqlCommand(A, conn);
        //            command.Parameters.AddWithValue("@Member_No_", Member_No_);

        //            using (SqlDataReader dr = command.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        if (dr["SharesZote"] != null)
        //                        {
        //                            d += Convert.ToDouble(dr["SharesZote"]);
        //                        }
        //                    }
        //                }
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Clear();
        //    }

        //    return (d);

        //}
        #endregion

        #region Get OutstandingS pecificLoanBalanceWithLoanType

        public static double OutstandingSpecificLoanBalanceWithLoanType(string LoanProductType, string ClientCode)
        {
            {
                double d = 0;

                try
                {
                    using (SqlConnection conn = MyClass.getconnToNAV())
                    {

                        string loanNo = string.Empty;

                        string A_ = String.Format("SELECT [Loan  No_] FROM [{0}$Loans]  WHERE [Member No_]=@ClientCode AND [Loan Product Type]=", MyClass.CompanyName);
                        SqlCommand command_ = new SqlCommand(A_, conn);
                        command_.Parameters.AddWithValue("@ClientCode", ClientCode);
                        command_.Parameters.AddWithValue("@LoanProductType", LoanProductType);
                        using (SqlDataReader dr_W = command_.ExecuteReader())
                        {
                            if (dr_W.HasRows)
                            {
                                dr_W.Read();
                                loanNo = dr_W["Loan  No_"].ToString();

                                #region

                                string A = "SELECT b.[Amount] as SharesZote FROM [" + MyClass.CompanyName + "$Cust_ Ledger Entry] a,[" + MyClass.CompanyName + "$Detailed Cust_ Ledg_ Entry] b" +
                                " where  a.[Entry No_]=b.[Cust_ Ledger Entry No_] AND  a.[Loan No] = @loanNo" +
                                " and (a.[Transaction Types] = 2 or a.[Transaction Types] = 3 or a.[Transaction Types] = 5)" +
                                " AND  (a.[Document No_] <> 'INT JAN2012' AND a.[Document No_] <> 'JAN2012 INT')"
                                ;

                                SqlCommand command = new SqlCommand(A, conn);
                                command.Parameters.AddWithValue("@loanNo", loanNo);
                                using (SqlDataReader dr = command.ExecuteReader())
                                {
                                    if (dr.HasRows)
                                    {
                                        while (dr.Read())
                                        {
                                            if (dr["SharesZote"] != null)
                                            {
                                                d += Convert.ToDouble(dr["SharesZote"]);
                                            }
                                        }
                                    }
                                }

                                #endregion

                            }
                        }

                        conn.Close();

                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }

                return d;
            }
        }
        #endregion

        #region Remove special characters
        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }
        #endregion
        #region Send SMS

        public static void SendSMS(string Member_No_, string Msg_, SqlConnection conn)
        {
            string MSISDN = string.Empty;

            string s = String.Format("SELECT [E-Mail],[Phone No_] AS [Mobile Phone No],[Name] FROM [{0}$Customer] WHERE [No_] = @Member_No;", MyClass.CompanyName);
            SqlCommand command = new SqlCommand(s, conn);
            command.Parameters.AddWithValue("@Member_No", Member_No_);

            using (SqlDataReader dr = command.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr["Mobile Phone No"].ToString() != null)
                    {
                        MSISDN = dr["Mobile Phone No"].ToString();
                    }
                }
            }


            if (MSISDN.Length == 12)
            {
                int Entry_No = 0;

                string getEntryNo = String.Format("SELECT MAX([Entry No]) as [Entry No] FROM [{0}$SMS Messages]", MyClass.CompanyName);
                SqlCommand cmd_Entry = new SqlCommand(getEntryNo, conn);
                using (SqlDataReader dr__ = cmd_Entry.ExecuteReader())
                {
                    if (dr__.HasRows)
                    {
                        dr__.Read();
                        Entry_No = Convert.ToInt32(dr__["Entry No"]);
                    }
                }

                int BulkSMSBalance = 0;

                string getSmsBal = String.Format("SELECT [Bulk SMS Balance] FROM [{0}$SMS Messages] WHERE [Entry No]=@Entry_No", MyClass.CompanyName);
                SqlCommand cmd_SMSBal = new SqlCommand(getSmsBal, conn);
                cmd_SMSBal.Parameters.AddWithValue("@Entry_No", Entry_No);

                using (SqlDataReader dr__Sms = cmd_SMSBal.ExecuteReader())
                {
                    if (dr__Sms.HasRows)
                    {
                        dr__Sms.Read();
                        BulkSMSBalance = Convert.ToInt32(dr__Sms["Bulk SMS Balance"]);

                    }
                }

                Entry_No += 1;


                #region Queue SMS

                string Document_No = MSISDN, Source = "PORTAL";

                DateTime dt_ = DateTime.Now;

                string Queue_sms = "INSERT INTO [" + MyClass.CompanyName + "$SMS Messages] ([Entry No],[Telephone No],[SMS Message],[Document No],[Source],[Date Entered],[Time Entered],[Entered By],[Sent To Server],[Date Sent to Server],[Time Sent To Server],[No_ Series],[Account No],[Batch No],[Bulk SMS Balance],[Entry No_])" +
                      " VALUES(@Entry_No,@Telephone_No,@SMS_Message,@Document_No,@Source,@DateEntered,@Time_Entered,@Entered_By,@Sent_To_Server,@Date_Sent_to_Server,@Time_Sent_To_Server,@No_Series,@Account_No,@Batch_No,@Bulk_SMS_Balance,@Entry_No_)";

                SqlCommand cmd_ = new SqlCommand(Queue_sms, conn);
                cmd_.Parameters.AddWithValue("@Entry_No", Entry_No);
                cmd_.Parameters.AddWithValue("@Telephone_No", MSISDN);
                cmd_.Parameters.AddWithValue("@SMS_Message", Msg_);
                cmd_.Parameters.AddWithValue("@Document_No", Document_No);
                cmd_.Parameters.AddWithValue("@Source", Source);
                cmd_.Parameters.AddWithValue("@DateEntered", DateTime.Now.ToString("yyyy-MMM-dd"));
                cmd_.Parameters.AddWithValue("@Time_Entered", MyClass.getTime());
                cmd_.Parameters.AddWithValue("@Entered_By", Source);
                cmd_.Parameters.AddWithValue("@Sent_To_Server", "0");
                cmd_.Parameters.AddWithValue("@Date_Sent_to_Server", DateTime.Now.ToString("yyyy-MMM-dd"));
                cmd_.Parameters.AddWithValue("@Time_Sent_To_Server", "1753-01-01 00:00:00.000");
                cmd_.Parameters.AddWithValue("@No_Series", Source);
                cmd_.Parameters.AddWithValue("@Account_No", Source);
                cmd_.Parameters.AddWithValue("@Batch_No", Source);
                cmd_.Parameters.AddWithValue("@Entry_No_", Entry_No);
                cmd_.Parameters.AddWithValue("@Bulk_SMS_Balance", BulkSMSBalance - 1);
                cmd_.ExecuteNonQuery();

                #endregion

            }


        }
        #endregion
        #region Get Time

        public static string getTime()
        {
            return "1754-01-01 " + DateTime.Now.ToString("HH:mm:ss");
        }

        #endregion


        #region Evaluate Date
        public static bool EvaluateDate(string startdate, string enddate)
        {

            bool evaluation = false;
            try
            {
                DateTime dt1 = DateTime.Parse(startdate);
                DateTime dt2 = DateTime.Parse(startdate);
                evaluation = true;
            }

            catch
            {
                throw;
            }

            return evaluation;

        }
        #endregion

    }


    #region Password Stength Checker
    public enum enPasswordScore
    {
        psBlank = 0,
        psVeryWeak = 1,
        psWeak = 2,
        psMedium = 3,
        psStrong = 4,
        psVeryStrong = 5
    }
    public class cPasswordAdvisor
    {
        public static enPasswordScore CheckStrength(string password)
        {
            int score = 1;
            if (password.Length < 1)
            {
                return enPasswordScore.psBlank;
            }
            if (password.Length < 6)
            {
                return enPasswordScore.psVeryWeak;
            }
            if (password.Length >= 6)
            {
                score++;
            }
            if (password.Length >= 12)
            {
                score++;
            }
            if (Regex.IsMatch(password, @"\d+"))
            {
                score++;
            }
            if (Regex.IsMatch(password, @"[a-z]") && Regex.IsMatch(password, @"[A-Z]"))
            {
                score++;
            }

            if (Regex.IsMatch(password, @"[!@#\$%\^&\*\?_~\-\(\);\.\+:]+"))
            {
                score++;
            }

            return (enPasswordScore)score;
        }
    }

    #endregion

}