package com.example.m_saccoagency;

import com.google.gson.annotations.SerializedName;

/**
 * Created by Paul on 1/12/2016.
 */
public class Transaction {
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
    public Boolean valid = true;
    public Agent agent = null;
    public String newpin;
    public Boolean pinchanged = false;
    public String message = null;
    public String Telephone_No = null;
    public String Depositor_Name = null;
    public double Minimun_Amount = 0;
    public double Maximun_Amount = 0;
    public Societies society = null;

    public enum Transtype {
        @SerializedName("0")
        None,
        @SerializedName("1")
        Registration,
        @SerializedName("2")
        Withdrawal,
        @SerializedName("3")
        Deposit,
        @SerializedName("4")
        LoanRepayment,
        @SerializedName("5")
        Transfer,
        @SerializedName("6")
        Sharedeposit,
        @SerializedName("7")
        Schoolfeespayment,
        @SerializedName("8")
        Balance,
        @SerializedName("9")
        Ministatment,
        @SerializedName("10")
        Paybill,
        @SerializedName("11")
        Memberactivation,
        @SerializedName("12")
        MemberRegistration,
        @SerializedName("13")
        Changepin;

    }

    public enum Status {
        @SerializedName("0")
        Pending,
        @SerializedName("1")
        Confirmation,
        @SerializedName("2")
        Successful,
        @SerializedName("3")
        Failed,
        @SerializedName("4")
        Completed;

    }


}
