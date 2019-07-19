using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace AGENCY
{
    public class Loans
    {
        public static Loan.Loans_Service loanservice = new Loan.Loans_Service();
        public static Loanproducts.LoanProducts_Service productservice = new Loanproducts.LoanProducts_Service();
        public Member member = null;
        public String Loan_No = null;
        public String Loan_Type = null;
        public String Loan_Type_Name;
        public double Loan_Balance = 0;
        public Loan_Source loan_source;
        public enum Loan_Source
        {
            BOSA,
            FOSA
        }
        public static List<Loanproducts.LoanProducts> loanproducts(){

            List<Loanproducts.LoanProducts> lp = new List<Loanproducts.LoanProducts>();
            
            try{
                lp = productservice.ReadMultiple(new Loanproducts.LoanProducts_Filter[] { new Loanproducts.LoanProducts_Filter { Criteria = "Yes", Field = Loanproducts.LoanProducts_Fields.Mobile } }, null, 100).ToList();
        
        }
            catch(Exception ex)
        {
            CUtilities.LogEntryOnFile(ex.Message);
                        CUtilities.LogEntryOnFile(ex.StackTrace);
            }
            return lp;
        }

        public String Type_Name
        {
            get
            {
                String name = String.Empty;
                if (Loan_Type != null)
                {

                    try
                    {
                        name = productservice.Read(Loan_Type).Product_Description;
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
                        var dt = loanservice.ReadMultiple(new Loan.Loans_Filter[] { new Loan.Loans_Filter { Criteria = id_no, Field = Loan.Loans_Fields.ID_NO }, new Loan.Loans_Filter { Criteria = "Yes", Field = Loan.Loans_Fields.Posted } }, null, 100);
                                        foreach (var row in dt)
                        {
                            Loans account = new Loans();
                            account.Loan_No = row.Loan_No;// row["Loan  No_"].ToString();
                            account.Loan_Type = row.Loan_Product_Type;// row["Loan Product Type"].ToString();
                            account.Loan_Type_Name = row.Loan_Product_Type_Name;// account.Type_Name;
                            account.loan_source = (AGENCY.Loans.Loan_Source)Enum.Parse(typeof(AGENCY.Loans.Loan_Source), row.Source.ToString() );
                            account.Loan_Balance =(double) row.Outstanding_Balance + (double) row.Oustanding_Interest;
                            l.Add(account);
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
