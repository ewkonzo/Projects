package com.example.m_saccoagency;

/**
 * Created by Paul on 25-Sep-16.
 */

public class Products {
    public String Code;
    public String Product_Description;
    public Source Source;
    public double Interest_rate;
    public Repayment_Method Repayment_Method;
    public int Grace_Period_Principle_M;
    public int Grace_Period_Interest_M;
    public boolean Use_Cycles;
    public String Instalment_Period;
    public int No_of_Installment;
    public int Default_Installements;
    public String Penalty_Calculation_Days;
    public double Penalty_Percentage;
    public int Recovery_Priority;
    public int Min_No_Of_Guarantors;
    public String Min_Re_application_Period;
    public int Shares_Multiplier;
    public Penalty_Calculation_Method Penalty_Calculation_Method;
    public String Penalty_Paid_Account;
    public double Min_Loan_Amount;
    public double Max_Loan_Amount;
    public String Loan_Account;
    public String Loan_Interest_Account;
    public String Receivable_Interest_Account;
    public Action Action;
    public String BOSA_Account;
    public String BOSA_Personal_Loan_Account;
    public String Top_Up_Commision_Account;
    public double Top_Up_Commision;
    public int Check_Off_Loan_No;
    public Repayment_Frequency Repayment_Frequency;
    public Boolean Mobile ;
    public String toString() {
        return this.Product_Description;
    }
    public enum Source {

        /// <remarks/>
        BOSA,

        /// <remarks/>
        FOSA,

        /// <remarks/>
        Investment,

        /// <remarks/>
        MICRO,
    }

    /// <remarks/>
    public enum Repayment_Method {

        /// <remarks/>
        Amortised,

        /// <remarks/>
        Reducing_Balance,

        /// <remarks/>
        Straight_Line,

        /// <remarks/>
        Constants,
    }

    public enum Penalty_Calculation_Method {

        /// <remarks/>
        No_Penalty,

        /// <remarks/>
        Principal_in_Arrears,

        /// <remarks/>
        Principal_in_Arrears_x002B_Interest_in_Arrears,

        /// <remarks/>
        Principal_in_Arrears_x002B_Interest_in_Arrears_x002B_Penalty_in_Arrears,
    }

    /// <remarks/>
   public enum Action {

        /// <remarks/>
        _blank_,

        /// <remarks/>
        Off_Set_Commitments,

        /// <remarks/>
        Discounting,
    }

    /// <remarks/>
   public enum Repayment_Frequency {

        /// <remarks/>
        Daily,

        /// <remarks/>
        Weekly,

        /// <remarks/>
        Monthly,

        /// <remarks/>
        Quaterly,

        /// <remarks/>
        Yearly,
    }
}
