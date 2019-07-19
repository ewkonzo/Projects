package com.example.m_saccoagency;

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
    }}
