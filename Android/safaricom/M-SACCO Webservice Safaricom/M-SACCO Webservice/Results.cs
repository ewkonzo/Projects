using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_SACCO_Webservice
{
    public class Results
    {
        public bool Hasresults =true;
        public object ResultsData = null;
        public string ResultErros = string.Empty;
            }
    public class loans
    {
    public string loan_No;
    public string Loan_Type;
    public double loan_Balance;
    public string staff_No;
    public decimal Amount;
    public DateTime Repayment_Date;
    public string Document_No;
    public Accounts account = null;    
    public Boolean Hasresults = true;
    public string Errors;
    public string results = string.Empty;
    }
    public class Applications
    {
        public string Telephone = string.Empty;
        public string Applicant_Name = string.Empty;
        public Boolean Hasresults = true;
        public string Errors;
    }
    public class Accounts
    {
        public string Account_No = string.Empty;
        public string Account_Name = string.Empty;
        public double Account_Balance = 0;
        public string Staff_No = string.Empty;
    }
    public class Transfers
    {
        public string From_Account;
        public string To_Account;
        public decimal Amount;
        public string Reference;
        public string Results;
        public Boolean Hasresults = true;
        public string Errors;
        public transfertype ttype;
        public enum transfertype
        { 
        FosaFosa,FosaBosa
        }
        }
}