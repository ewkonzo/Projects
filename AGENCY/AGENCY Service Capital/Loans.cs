using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace AGENCY
{
    public class Loans
    {
        public Member member = null;
        public String Loan_No = null;
        public String Loan_Type = null;
        public String Loan_Type_Name;
        public double Loan_Balance = 0;
        public Loan_Source loan_source;
        public enum Loan_Source
        {
            Bosa,
            Fosa
        }
        public String Type_Name
        {
            get
            {
                String name = String.Empty;
                if (Loan_Type != null)
                {
                    SqlDataReader r;
                    try
                    {
                        using (var db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                        {
                            if (db.mDB.State == ConnectionState.Open)
                            {
                                r = db.ReadDB(String.Format("SELECT Top(1)  [Description]  FROM [dbo].[Capital SACCO Society Ltd$Loan Product Types1] where [Code] = '{0}'  ", Loan_Type));
                                if (r.HasRows)
                                {
                                    r.Read();
                                    name = r["Description"].ToString();
                                }

                            }
                            db.mDB.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        CUtilities.LogEntryOnFile(ex.Message);
                        CUtilities.LogEntryOnFile(ex.StackTrace);
                    }
                }
                return name;

            }
        }
        public static List<Loans> loans(String id_no)
        {
            String response = string.Empty;
            List<Loans> l = new List<Loans>();
            try
            {
                using (var db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    if (db.mDB.State == ConnectionState.Open)
                    {
                        DataTable dt = db.Getdatatable(String.Format("SELECT [Capital SACCO Society Ltd$Loan Application Form1].[Loan Product Type Name], [Capital SACCO Society Ltd$Loan Application Form1].[Loan  No_], [Capital SACCO Society Ltd$Loan Application Form1].[Loan Product Type], SUM([Capital SACCO Society Ltd$Member Ledger Entry].Amount)  AS loanbalance, [Capital SACCO Society Ltd$Loan Application Form1].Source FROM [Capital SACCO Society Ltd$Loan Application Form1] LEFT OUTER JOIN [Capital SACCO Society Ltd$Member] ON [Capital SACCO Society Ltd$Loan Application Form1].[Member Code] = [Capital SACCO Society Ltd$Member].No_ RIGHT OUTER JOIN [Capital SACCO Society Ltd$Member Ledger Entry] ON [Capital SACCO Society Ltd$Loan Application Form1].[Member Code] = [Capital SACCO Society Ltd$Member Ledger Entry].[Customer No_] AND [Capital SACCO Society Ltd$Loan Application Form1].[Loan  No_] = [Capital SACCO Society Ltd$Member Ledger Entry].[Loan No] where  [Capital SACCO Society Ltd$Member]. [Identification No_]= '{0}' and ([Capital SACCO Society Ltd$Member Ledger Entry].[Transaction Type] =2 or [Capital SACCO Society Ltd$Member Ledger Entry].[Transaction Type] =3 ) GROUP BY [Capital SACCO Society Ltd$Loan Application Form1].[Loan Product Type], [Capital SACCO Society Ltd$Loan Application Form1].[Loan  No_], [Capital SACCO Society Ltd$Loan Application Form1].Source,[Capital SACCO Society Ltd$Loan Application Form1].[Loan Product Type Name] HAVING (SUM([Capital SACCO Society Ltd$Member Ledger Entry].Amount) > 0) union all SELECT [Capital SACCO Society Ltd$Loan Application Form1].[Loan Product Type Name], [Capital SACCO Society Ltd$Loan Application Form1].[Loan  No_], [Capital SACCO Society Ltd$Loan Application Form1].[Loan Product Type], SUM([Capital SACCO Society Ltd$Member Ledger Entry].Amount) AS loanbalance, [Capital SACCO Society Ltd$Loan Application Form1].Source FROM [Capital SACCO Society Ltd$Vendor] INNER JOIN [Capital SACCO Society Ltd$Loan Application Form1] ON [Capital SACCO Society Ltd$Vendor].No_ = [Capital SACCO Society Ltd$Loan Application Form1].[Member Code] RIGHT OUTER JOIN [Capital SACCO Society Ltd$Member Ledger Entry] ON [Capital SACCO Society Ltd$Loan Application Form1].[Member Code] = [Capital SACCO Society Ltd$Member Ledger Entry].[Customer No_] AND [Capital SACCO Society Ltd$Loan Application Form1].[Loan  No_] = [Capital SACCO Society Ltd$Member Ledger Entry].[Loan No] WHERE ([Capital SACCO Society Ltd$Member Ledger Entry].[Transaction Type] = 2 OR [Capital SACCO Society Ltd$Member Ledger Entry].[Transaction Type] = 3 )and [Capital SACCO Society Ltd$Vendor]. [Identification No_]= '{0}' GROUP BY [Capital SACCO Society Ltd$Loan Application Form1].[Loan Product Type], [Capital SACCO Society Ltd$Loan Application Form1].[Loan  No_], [Capital SACCO Society Ltd$Loan Application Form1].Source,[Capital SACCO Society Ltd$Loan Application Form1].[Loan Product Type Name] HAVING (SUM([Capital SACCO Society Ltd$Member Ledger Entry].Amount) > 0)", id_no));
                        foreach (DataRow row in dt.Rows)
                        {
                            Loans account = new Loans();
                            account.Loan_No = row["Loan  No_"].ToString();
                            account.Loan_Type = row["Loan Product Type"].ToString();
                            account.Loan_Type_Name = account.Type_Name;
                            account.loan_source = (AGENCY.Loans.Loan_Source)Enum.Parse(typeof(AGENCY.Loans.Loan_Source), row["Source"].ToString());
                            account.Loan_Balance = Convert.ToDouble(string.Format("{0:0.00}", row["loanbalance"]));
                            l.Add(account);
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            return l;

        }
    }
}
