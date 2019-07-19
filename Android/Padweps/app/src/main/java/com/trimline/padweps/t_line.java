package com.trimline.padweps;


import android.arch.persistence.room.Entity;
import android.arch.persistence.room.PrimaryKey;

@Entity(tableName = "Trans line")
public  class t_line {
    @PrimaryKey(autoGenerate = true)
    public int No;
    public String PAWDEP_No;
    public String Member_Name;
    public String Loan_No;
    public float Savings_B_F;
    public float Loan_Balance_B_F;
    public float Expected_Interest;
    public float Total_Paid;
    public float Principle_Paid;
    public float Interest_Paid;
    public float Monthly_Savings;
    public float Savings__Shares_C_F;
    public float Loan_Balance_C_F;
    public float Interest_Balance_C_F;
    public float Fines;
    public String Transaction_No;

    public float Unpaid_Penalty;
    public float Penalty_Charged;
    public boolean Non_Cash;
    public float Expected_Principal;
    public String Member_No;
    public float Principle_Recovered;
    public float Intrerest_Recovered;
    public float Hall;
    public String Branch_Code;
    public String Trans_Header;
}
