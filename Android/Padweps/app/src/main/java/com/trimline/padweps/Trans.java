package com.trimline.padweps;


import android.arch.persistence.room.Entity;
import android.arch.persistence.room.PrimaryKey;
import android.support.annotation.NonNull;

import java.io.Serializable;



/**
 * Created by Paul on 09-Dec-16.
 */

@Entity(tableName = "Trans Header")
public class Trans implements Serializable {
    public void setDescription(String description) {
        Description = description;
    }

    public void setGroup_Code(String group_Code) {
        Group_Code = group_Code;
    }

    public void setGroup_Name(String group_Name) {
        Group_Name = group_Name;
    }

    public void setProject(String project) {
        Project = project;
    }

    public void setDate(java.sql.Date date) {
        Date = date;
    }

    public void setDateSpecified(boolean dateSpecified) {
        DateSpecified = dateSpecified;
    }

    public void setReceipt_No(String receipt_No) {
        Receipt_No = receipt_No;
    }

    public void setBranch_Code(String branch_Code) {
        Branch_Code = branch_Code;
    }

    public void setBranch_Name(String branch_Name) {
        Branch_Name = branch_Name;
    }

    public void setGroup_Officer_Code(String group_Officer_Code) {
        Group_Officer_Code = group_Officer_Code;
    }

    public void setGroup_Officer_Name(String group_Officer_Name) {
        Group_Officer_Name = group_Officer_Name;
    }

    public void setLoan_Principle_Paid(float loan_Principle_Paid) {
        Loan_Principle_Paid = loan_Principle_Paid;
    }

    public void setLoan_Interest_Paid(float loan_Interest_Paid) {
        Loan_Interest_Paid = loan_Interest_Paid;
    }

    public void setSavings_Received(float savings_Received) {
        Savings_Received = savings_Received;
    }

    public void setAdvance_Principle_Paid(float advance_Principle_Paid) {
        Advance_Principle_Paid = advance_Principle_Paid;
    }

    public void setAdvance_Interest_Paid(float advance_Interest_Paid) {
        Advance_Interest_Paid = advance_Interest_Paid;
    }

    public void setAdvances_Issued(float advances_Issued) {
        Advances_Issued = advances_Issued;
    }

    public void setOther_Transactions_Paid(float other_Transactions_Paid) {
        Other_Transactions_Paid = other_Transactions_Paid;
    }

    public void setCredit_Officer_Totals(float credit_Officer_Totals) {
        Credit_Officer_Totals = credit_Officer_Totals;
    }

    public void setBank_Account(String bank_Account) {
        Bank_Account = bank_Account;
    }

    public static void setStatus(Trans.Status status) {
        Status = status;
    }

    public void setHall_Received(float hall_Received) {
        Hall_Received = hall_Received;
    }

    public void setHall_Paid(float hall_Paid) {
        Hall_Paid = hall_Paid;
    }

    public void setGroup_Fines(float group_Fines) {
        Group_Fines = group_Fines;
    }

    public void setPenalty(float penalty) {
        Penalty = penalty;
    }

    public void setAdvance_Fine(float advance_Fine) {
        Advance_Fine = advance_Fine;
    }

    public void setPosted(boolean posted) {
        Posted = posted;
    }

    public void setJanuary(float january) {
        January = january;
    }

    public void setFebruary(float february) {
        February = february;
    }

    public void setMarch(float march) {
        March = march;
    }

    public void setApril(float april) {
        April = april;
    }

    public void setMay(float may) {
        May = may;
    }

    public void setJune(float june) {
        June = june;
    }

    public void setJuly(float july) {
        July = july;
    }

    public void setPosted_Advance(float posted_Advance) {
        Posted_Advance = posted_Advance;
    }

    @PrimaryKey

    @NonNull
    public String Transaction_No;
    public String Description;
    public String Group_Code;
    public String Group_Name;
    public String Project;
    public java.sql.Date Date;
    public boolean DateSpecified;
    public String Receipt_No;
    public String Branch_Code;
    public String Branch_Name;
    public String Group_Officer_Code;
    public String Group_Officer_Name;
    public float Loan_Principle_Paid;
    public float Loan_Interest_Paid;
    public float Savings_Received;
    public float Advance_Principle_Paid;
    public float Advance_Interest_Paid;
    public float Advances_Issued;
    public float Other_Transactions_Paid;
    public float Credit_Officer_Totals;
    public String Bank_Account;
    public static Status Status;
    public float Hall_Received;
    public float Hall_Paid;
    public float Group_Fines;
    public float Penalty;
    public float Advance_Fine;
    public boolean Posted;
    public float January;
    public float February;
    public float March;
    public float April;
    public float May;
    public float June;
    public float July;
    public float Posted_Advance;


    @Override
    public String toString() {
        return Description;
    }

    public enum Status {
        /// <remarks/>
        Pending,
        /// <remarks/>
        Approved,
    }}


