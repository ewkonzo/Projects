using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.MobileControls;
using System.Xml.Serialization;

namespace MobiService
{
    public class Results
    {
        public bool Hasresults = true;
        public object ResultsData = null;
        public string ResultErros = string.Empty;
    }
    public class Result
    {
        public int code = 0;
        public string Desc = string.Empty;
        public Object Data = "";

    }
    public class LoanbalResult
    {
        public int code = 0;
        public string Desc = string.Empty;
        public Loanball Data = null;

    }
    public class loans
    {
        public string loan_No;
        public string Loan_Type;
        public double loan_Balance;
        public string staff_No;
        public decimal Amount;
        public double Interest;
        public DateTime Repayment_Date;
        public string Document_No;
        public Accounts account = null;
        public Boolean Hasresults = true;
        public string Errors;
        public string results = string.Empty;
    }

    public class BalanceEnquiry
    {
        public string phone;
        public string AccountNo;
        public string AccountName;
        public string Accounttype;
        public string Comment;
        public string Transaction_Desc;
        public double Balance;
        public Boolean Hasresults = true;
        public string Errors;
        public string status;
        public string results = string.Empty;
    }

    public class Ministatement
    {
        public string Date_Posted;
        public string Transaction_Desc;
        public string Amount;
        public string Comment;
        public Boolean Hasresults = true;
        public string Errors;
        public string status;
        public string results = string.Empty;
    }

    public class SMS
    {
        public string Date_Posted;
        public string SmsBody;
        public string SmsTelephoneNo;
        public string Comment;
        public Boolean Hasresults = true;
        public string Errors;
        public string Status;
        public string Transaction_Desc;
        public string results = string.Empty;
    }

    public class Registration
    {
        public string Date_Posted;
        public string NationalIdNo;
        public string FosaACCNo;
        public string MemberName;
        public string MemberMobileNo;
        public string Comment;
        public Boolean Hasresults = true;
        public string Errors;
        public string Status;
        public string Transaction_Desc;
        public string results = string.Empty;
    }

    public class WithdrawalRequest
    {
        public string Status;
        public string Transaction_Desc;
        public double Amount;
        public string Comment;
        public Boolean Hasresults = true;
        public string Errors;
        public string results = string.Empty;
    }

    public class WithdrawalConfirm
    {
        public string Status;
        public string Transaction_Desc;
        public double Amount;
        public double charge;
        public string Comment;
        public Boolean Hasresults = true;
        public string Errors;
        public string results = string.Empty;
    }

    public class WithdrawalDecline
    {
        public string Status;
        public string Transaction_Desc;
        public double Amount;
        public string Comment;
        public Boolean Hasresults = true;
        public string Errors;
        public string results = string.Empty;
    }

    public class Deposit
    {
        public string Status;
        public string Transaction_Desc;
        public double Amount;
        public string Comment;
        public Boolean Hasresults = true;
        public string Errors;
        public string results = string.Empty;
    }

    public class ShareContribution
    {
        public string Status;
        public string Transaction_Desc;
        public double Amount;
        public string Comment;
        public Boolean Hasresults = true;
        public string Errors;
        public string results = string.Empty;
    }

    public class AirtimeRequest
    {
        public string Status;
        public string Transaction_Desc;
        public double Amount;
        public string Comment;
        public Boolean Hasresults = true;
        public string Errors;
        public string results = string.Empty;
    }


    public class Transfer
    {
        public string Status;
        public string Transaction_Desc;
        public double Amount;
        public string Comment;
        public Boolean Hasresults = true;
        public string Errors;
        public string results = string.Empty;
    }

    public class LoanRepayment
    {
        public string Status;
        public string Transaction_Desc;
        public double Amount;
        public string Comment;
        public Boolean Hasresults = true;
        public string Errors;
        public string results = string.Empty;
    }


    public class LoanStatus
    {
        public string Status;
        public string Transaction_Desc;
        public double OutstandingBalance;
        public string Comment;
        public string LoanNo;
        public string LoanType;
        public Boolean Hasresults = true;
        public string Errors;
        public string results = string.Empty;
    }

    public class Loanball
    {
        public double bal = 0;
        public string name = string.Empty;
    }
    public class LoanBalance
    {
        public string Status;

        public string Transaction_Desc;

        public double OutstandingBalance;

        public string Comment;

        public string LoanNo;

        public string LoanType;

        public bool Hasresults = true;

        public string Errors;

        public string results = string.Empty;

        public LoanBalance()
        {
        }
    }
    public class AirtimeConfirm
    {
        public string Status;
        public string Transaction_Desc;
        public double Amount;
        public string Comment;
        public Boolean Hasresults = true;
        public string Errors;
        public string results = string.Empty;
    }

    public class AirtimeDecline
    {
        public string Status;
        public string Transaction_Desc;
        public string Comment;
        public double Amount;
        public Boolean Hasresults = true;
        public string Errors;
        public string results = string.Empty;
    }

    public class Advance
    {
        public string Status;
        public double MaximumLoanAmount;
        public double OutstandingLoanBalance;
        public string LoanType;
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
            FosaFosa, FosaBosa
        }
    }
    public partial class transaction:Result
    {
        public string TransType;
        
        public DateTime TransTime;
        public double Amount;
        public string ShortCode;
        public string BillRefNumber;
        public string InvoiceNumber;
        public string AccountBalance;
        public string Reference;
        public string MSISDN;
        public string Name;
        public string Account;
        public string Account_2;
        public double charge;

    }
}
