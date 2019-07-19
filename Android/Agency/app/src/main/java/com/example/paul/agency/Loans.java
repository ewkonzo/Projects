package com.example.paul.agency;

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


