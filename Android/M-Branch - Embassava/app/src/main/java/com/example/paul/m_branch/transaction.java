package com.example.paul.m_branch;

import java.text.DecimalFormat;
import java.util.Date;

/**
 * Created by Paul on 09-Dec-16.
 */

public class transaction {
    public String Document_No;
    public String Account_No;
    public String Agent_Code;
    public String Loan_No;
    public String Account_Name;
    public String Telephone;
    public String Id_No;
    public Double Amount;
    public int Transaction_Type;
    public String Description;
    public String Date;
    public String Time;
    public String Messages;
    public String OTTN;
    public String Transaction_Location;
    public String Transaction_By;
    public boolean sent;
    public int Gender;
    public int Marital;
    public String Constituency;
    public String Ward;
    public String typename;
    public String Group;

    public String Type ;

    public enum gender {

        _blank_("Select"),
        Male("Male"),
        Female("Female");

        private String type;

        gender(String aState) {
            type = aState;
        }

        @Override
        public String toString() {
            return type;
        }
    }

    public enum marital {

        _blank_("Select"),
        Single("Single"),
        Married("Married"),

        Devorced("Devorced"),

        Widower("Widower");
        private String type;

        marital(String aState) {
            type = aState;
        }

        @Override
        public String toString() {
            return type;
        }
    }


    public enum T_Type {

        _blank_("Select"),

        /// <remarks/>
        Registration("Registration"),

        /// <remarks/>
        Loan_Repayment("Repayment"),
        /// <remarks/>
        Deposit_contribution("Deposit"),
        /// <remarks/>
        share_capital("Shares"),
        /// <remarks/>
        Penalty("Penalty");

        private String type;

        T_Type(String aState) {
            type = aState;
        }

        @Override
        public String toString() {
            return type;
        }
    }
}
