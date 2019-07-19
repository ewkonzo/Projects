package com.example.paul.a_sacco;

import com.google.gson.annotations.SerializedName;

public class Loans
{
  public double Loan_Balance = 0.0D;
  public String Loan_No = null;
  public String Loan_Type = null;
  public String Loan_Type_Name = null;
  public Loan_Source loan_source;
  public Member member = null;
  
  public static enum Loan_Source
  {
    Bosa,  Fosa;
    
    private Loan_Source() {}
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\Loans.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */