package com.example.paul.agency;
import android.content.ContentValues;
import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import com.google.gson.annotations.SerializedName;
import com.example.paul.agency.Account;
import com.example.paul.agency.Agent;
import com.example.paul.agency.Database;
import com.example.paul.agency.Loans;
import com.example.paul.agency.Member;
import com.example.paul.agency.Societies;

import java.io.Serializable;

// Referenced classes of package com.example.paul.a_sacco:
//            Database, Member, Account, Loans, 
//            Agent, Societies

public class Transaction
{
    public  enum Status
    {

            Pending  ,
            Confirmation ,
            Successful,
            Failed ,
            Completed
    }

    public enum  Transtype implements Serializable {
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
    static final String Table = "Transactions";
    static final String colAccount_1 = "Account_1";
    static final String colAccount_2 = "Account_2";
    static final String colAmount = "Amount";
    static final String colCode = "Code";
    static final String colDepositor_Name = "Depositor";
    static final String colEntry = "Entry";
    static final String colLoan_No = "Loan_No";
    static final String colMaximun_Amount = "Maximun";
    static final String colMinimun_Amount = "Minimun";
    static final String colTelephone_No = "Telephone";
    static final String colagent = "agent";
    static final String colid = "Id";
    static final String colmember_1 = "member_1";
    static final String colmember_2 = "member_2";
    static final String colstatus = "status";
    static final String coltransactiontype = "transactiontype";
public  int id = 0;
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
    public boolean valid = true;
    public Agent agent = null;
    public String newpin;
    public Boolean pinchanged = false;
    public String message = null;
    public String Telephone_No = null;
    public String Depositor_Name = null;
    public double Minimun_Amount = 0;
    public double Maximun_Amount = 0;
    public Societies society = null;



    public static Transaction AddRanch(Database data, Transaction transaction)
    {
        SQLiteDatabase  db = data.getWritableDatabase();
        ContentValues contentvalues = new ContentValues();
        contentvalues.put("Entry", transaction.reference);
        contentvalues.put("member_1", transaction.member_1.id_no);
        contentvalues.put("member_2", transaction.member_2.id_no);
        contentvalues.put("Account_1", transaction.account_1.Account_No);
        contentvalues.put("Account_2", transaction.account_2.Account_No);
        contentvalues.put("Amount", Double.valueOf(transaction.amount));
        contentvalues.put("Code", transaction.code);
        contentvalues.put("Loan_No", transaction.loan_no.Loan_No);
        contentvalues.put("transactiontype", transaction.transactiontype.toString());
        contentvalues.put("status", transaction.status.toString());
        contentvalues.put("agent", transaction.agent.agent_code);
        contentvalues.put("Telephone", transaction.Telephone_No);
        contentvalues.put("Depositor", transaction.Depositor_Name);
        contentvalues.put("Minimun", Double.valueOf(transaction.Minimun_Amount));
        contentvalues.put("Maximun", Double.valueOf(transaction.Maximun_Amount));
        transaction.id = (int)db.insertWithOnConflict("Transactions", "Account_1", contentvalues, 5);
        db.close();
        return transaction;
    }
}
