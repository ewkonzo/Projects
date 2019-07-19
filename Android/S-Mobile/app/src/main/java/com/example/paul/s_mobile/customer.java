package com.example.paul.s_mobile;

import java.util.Date;

public class customer {
    public String No = null;
    public String Name = null;
    public String Global_Dimension_1_Code = null;
    public String Global_Dimension_2_Code = null;
    public Blocked Blocked = null;
    public double Balance = 0;
    public String E_Mail = null;
    public String ID_No = null;
    public String Mobile_Phone_No = null;
    public Status status = customer.Status.Active;
    public String Account_Type = null;
    public Date Date_of_Birth;
    public double ATM_Transactions = 0;
    public double Uncleared_Cheques = 0;
    public enum Blocked {
        _blank_,
        Payment,
        All,
    }
    public enum Status {
        Active,
        Frozen,
        Closed,
        Archived,
        New,
        Dormant,
        Deceased,
    }
}
