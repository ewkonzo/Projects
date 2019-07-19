// Decompiled with JetBrains decompiler
// Type: M_SACCO_Webservice.BulkSms
// Assembly: M-SACCO Webservice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F0157AEC-175E-4D5E-A397-15B9A7805B87
// Assembly location: D:\M-Sacco\Bandari\M-SACCO Webservice.dll

namespace Msacco
{
  //public class BulkSms
  //{
  //  public string Phone = "";
  //  public string Text = "";
  //  public string status = "";
  //  public bool Hasresults = true;
  //  public int EntryNo;
  //  public int balance;
  //  public bool updated;
  //  public string Errors;
  //}
  public class BulkSms
  {
      public string status = string.Empty;
      public string StatusDescription = string.Empty;

      public int EntryNo = 0;
      public string Phone = string.Empty;
      public string Text = string.Empty;

      public string Source = string.Empty;
      public string DateCreated = string.Empty;
      public string TimeCreated = string.Empty;

      public int balance = 0;

      public bool updated = false;
      public bool Hasresults = true;
      public string Errors = string.Empty;

  }
    public enum transtype
    {
        Blank_ = 0,
        Withdrawal = 1,
        Deposit = 2,
        Balance = 3,
        Ministatement = 4,
        Airtime = 5,
        Loan_balance = 6,
        Loan_Status = 7,
        Share_Deposit_Balance = 8,
        Transfer_to_Fosa = 9,
        Transfer_to_Bosa = 10,
        Utility_Payment = 11,
        Loan_Application = 12,
        Standing_orders = 13,
        Reversal = 14,
        Loan_Repayment = 15,
        Share_Contribution = 16,


    }
}
