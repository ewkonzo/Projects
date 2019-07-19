using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;

namespace AGENCY
{
    public class Transaction
    {
        public static AgencyTransactions.AgentTransactions_Service Agtranservice = new AgencyTransactions.AgentTransactions_Service();
        public String reference = null;
        public Member member_1 = null;
        public Member member_2 = null;
        public Account account_1 = null;
        public Account account_2 = null;
        public double amount = 0;
        public double amount_charge = 0;
        public String code = null;
        public Loans loan_no = null;
        public Transtype transactiontype = Transtype.None;
        public Status status = Status.Pending;
        public bool valid = true;
        public Agent agent = null;
        public String newpin;
        public Boolean pinchanged = false;
        public String message = null;
        public String Telephone_No = null;
        public String Depositor_Name = null;
        public double Minimun_Amount = 0;
        public double Maximun_Amount = 0;
        public Societies society = null;
        public Loanproducts.LoanProducts product = null;
        public List<Loanproducts.LoanProducts> products = null;


        public enum Transtype
        {
            [Description("NONE")]
            None,
            [Description("Account Opening")]
            Registration,
            [Description("Cash Withdrawal")]
            Withdrawal,
            [Description("Cash Deposit")]
            Deposit,
            [Description("Loan Repayment")]
            LoanRepayment,
            [Description("Inter Account Transfer")]
            Transfer,
            [Description("Share Deposit")]
            Sharedeposit,
            [Description("School Fees Payment")]
            Schoolfeespayment,
            [Description("Balance")]
            Balance,
            [Description("Mini Statement")]
            Ministatment,
            [Description("Pay Bill")]
            Paybill,
            [Description("Member Activation")]
            Memberactivation,
            [Description("Member Registration")]
            MemberRegistration,
            [Description("Change Pin")]
            Changepin,
            [Description("Share Variation")]
            Share_Variation,
            [Description("Loan Applications")]
            Loan_Applications
                    }
        public enum Status
        {
            Pending, Confirmation, Successful, Failed, Completed
        }

        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
    }

}
