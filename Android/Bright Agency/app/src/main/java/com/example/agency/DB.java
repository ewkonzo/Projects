package com.example.agency;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.DatabaseUtils;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.text.TextUtils;
import android.util.Log;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.List;

public class DB extends SQLiteOpenHelper {

    Calendar cdt;
    //region Constants
    public static final String DATABASE_NAME = "Agency.db";
    //region tables
    public static final String TRANS_TABLE = "Transactions";
    public static final String tmpTRANS_TABLE = "tmpTransactions";

    public static final String ACCOUNTS_TABLE = "Accounts";
    public static final String tmpACCOUNTS_TABLE = "tmpAccounts";

    public static final String AGENT_TABLE = "Agents";
    public static final String tmpAGENT_TABLE = "tmpAgents";
    public static final String LOAN_TABLE = "LOAN";
    public static final String tmpLOAN_TABLE = "tmpLOAN";
    //endregion
    //region columns
    //region transaction table
    public static final String reference = "reference";
    public static final String member_1 = "member_1";
    public static final String member_2 = "member_2";
    public static final String account_1 = "account_1";
    public static final String tname = "name";
    public static final String account_2 = "account_2";
    public static final String amount = "amount";
    public static final String amount_charge = "amount_charge";
    public static final String code = "code";
    public static final String loan_no = "loan_no";
    public static final String transactiontype = "transactiontype";
    public static final String status = "status";
    public static final String valid = "valid";
    public static final String date = "date";
    public static final String time = "time";
    public static final String agent = "agent";
    public static final String newpin = "newpin";
    public static final String pinchanged = "pinchanged";
    public static final String message = "message";
    public static final String Telephone_No = "Telephone_No";
    public static final String Depositor_Name = "Depositor_Name";
    public static final String Minimun_Amount = "Minimun_Amount";
    public static final String Maximun_Amount = "Maximun_Amount";
    public static final String society = "society";
    public static final String product = "product";
    //endregion
    //region accounts/Member
    public static final String Account_No = "Account_No";
    public static final String Account_Name = "Account_Name";
    public static final String Account_Balance = "Account_Balance";
    public static final String Account_type = "Account_type";
    public static final String AccTelephone = "Telephone";
    public static final String Selected = "Selected";
    public static final String Account_ok = "Account_ok";
    public static final String Message = "Message";
    public static final String shares = "shares";
    public static final String Monthlycont = "Monthlycont";

    //endregion
    //region Agent
    public static final String Pin_changed = "Pin_changed";
    public static final String Telephone = "Telephone";
    public static final String account_balance = "account_balance";
    public static final String agent_Account = "agent_Account";
    public static final String agent_Name = "agent_Name";
    public static final String agent_code = "agent_code";
    public static final String logged_in = "logged_in";
    //public static final String message = "message";
    public static final String new_pin = "new_pin";
    public static final String pin = "pin";
    //endregion
    //region loans
    public static final String member = "member";
    public static final String Loan_No = "Loan_No";
    public static final String Loan_Type = "Loan_Type";
    public static final String Loan_Type_Name = "Loan_Type_Name";
    public static final String Loan_Balance = "Loan_Balance";
    public static final String loan_source = "loan_source";
    //endregion
// endregion columns
//endregion Constants
    //region Create db
    public DB(Context context) {
        super(context, DATABASE_NAME, null, 2);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(
                "create table " + TRANS_TABLE + "" +
                        "(" + reference + " text primary key," +
                        member_1 + " text," +
                        member_2 + " text," +
                        account_1 + " text," +
                        account_2 + " text," +
                        date + " text," +
                        tname + " text," +
                        time + " text," +
                        amount + " float," +
                        status + " integer," +
                        amount_charge + " float," +
                        code + " text," +
                        loan_no + " text," +
                        agent + " text," +
                        transactiontype + " integer," +
                        Telephone_No + " text," +
                        Depositor_Name + " text," +
                        Minimun_Amount + " float," +
                        Maximun_Amount + " float," +

                        society + " text," +
                        product + " text," +
                        message + " text )"
        );
        db.execSQL(
                "create table " + ACCOUNTS_TABLE + "" +
                        "(" + Account_No + " text primary key," +
                        Account_Name + " text," +
                        Account_Balance + " float," +
                        AccTelephone + " text," +
                        Selected + " Boolean," +
                        Account_ok + " boolean," +
                        Message + " text," +
                        shares + " float," +
                        Monthlycont + " float )"
        );
        db.execSQL(
                "create table " + AGENT_TABLE + "" +
                        "(" + agent_code + " text primary key," +
                        agent_Name + " text," +
                        Telephone + " text," +
                        account_balance + " float," +
                        agent_Account + " text," +

                        message + " text," +
                        pin + " text)"
        );
        db.execSQL(
                "create table " + LOAN_TABLE + "" +
                        "(" + loan_no + " text primary key," +
                        Loan_Type + " text," +
                        Loan_Type_Name + " text," +
                        Loan_Balance + " float," +
                        loan_source + " text )"
        );
  }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // TODO Auto-generated method stub
        try {
            Log.i("Db", "Updating db");
            Cursor res = db.query(TRANS_TABLE, null, null, null, null, null, null);
            String[] cols = res.getColumnNames();
            List<String> fcols = new ArrayList<String>(Arrays.asList(cols));

            res = db.query(ACCOUNTS_TABLE, null, null, null, null, null, null);
            String[] cola = res.getColumnNames();
            List<String> fcola = new ArrayList<String>(Arrays.asList(cola));
            //agent
            res = db.query(AGENT_TABLE, null, null, null, null, null, null);
            String[] colag = res.getColumnNames();
            List<String> colg = new ArrayList<String>(Arrays.asList(colag));
            //loan
            res = db.query(AGENT_TABLE, null, null, null, null, null, null);
            String[] loan = res.getColumnNames();
            List<String> loans = new ArrayList<String>(Arrays.asList(loan));

            db.execSQL("Drop table if exists " + tmpTRANS_TABLE);
            db.execSQL("Drop table if exists " + tmpACCOUNTS_TABLE);
            db.execSQL("Drop table if exists " + tmpAGENT_TABLE);
            db.execSQL("Drop table if exists " + tmpLOAN_TABLE);

            db.execSQL("ALTER table " + TRANS_TABLE + " RENAME TO '" + tmpTRANS_TABLE + "'");
            db.execSQL("ALTER table " + ACCOUNTS_TABLE + " RENAME TO '" + tmpACCOUNTS_TABLE + "'");
            db.execSQL("ALTER table " + AGENT_TABLE + " RENAME TO '" + tmpAGENT_TABLE + "'");
            db.execSQL("ALTER table " + LOAN_TABLE + " RENAME TO '" + tmpLOAN_TABLE + "'");

            onCreate(db);

            String fcol = TextUtils.join(",", fcols);
            String acol = TextUtils.join(",", cola);
            String gcol = TextUtils.join(",", colg);
            String loanc = TextUtils.join(",", loans);

            db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s", TRANS_TABLE, fcol, fcol, tmpTRANS_TABLE));
            db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s", ACCOUNTS_TABLE, acol, acol, tmpACCOUNTS_TABLE));
            db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s", AGENT_TABLE, gcol, gcol, tmpAGENT_TABLE));
            db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s", LOAN_TABLE, gcol, gcol, tmpLOAN_TABLE));

            db.execSQL(" DROP table '" + tmpTRANS_TABLE + "'");
            db.execSQL(" DROP table '" + tmpACCOUNTS_TABLE + "'");
            db.execSQL(" DROP table '" + tmpAGENT_TABLE + "'");
            db.execSQL(" DROP table '" + tmpLOAN_TABLE + "'");

            Log.i("Db update", "Database updated");
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    //endregion
//    //region Trans
    public Long insertTransaction(Transaction t) {

        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();


        contentValues.put(date, t.Date);
        contentValues.put(time, t.Time);
        contentValues.put(reference, t.reference);
       // contentValues.put(member_1, t.member_1.id_no);
        //contentValues.put(member_2, t.member_2.id_no);
       // contentValues.put(account_1, t.account_1.Account_No);
       // contentValues.put(account_2, t.account_2.Account_No);
        contentValues.put(amount, t.amount);
        contentValues.put(amount_charge, t.amount_charge);
        contentValues.put(code, t.code);
        contentValues.put(tname, t.account_1.Account_Name);
      //  contentValues.put(loan_no, t.loan_no.Loan_No);
        contentValues.put(transactiontype, t.transactiontype.ordinal());
        contentValues.put(status, t.status.ordinal());
       // contentValues.put(valid, t.valid);
        //contentValues.put(agent, t.agent.agent_code);
        //contentValues.put(message, t.message);
        contentValues.put(Telephone_No, t.Telephone_No);
        contentValues.put(Depositor_Name, t.Depositor_Name);
        contentValues.put(Minimun_Amount, t.Minimun_Amount);
        contentValues.put(Maximun_Amount, t.Maximun_Amount);
       // contentValues.put(society, t.society.code);
      //  contentValues.put(product, t.product.Code);
        long dd = db.insertWithOnConflict(TRANS_TABLE, null, contentValues, SQLiteDatabase.CONFLICT_REPLACE);

        return dd;
    }

    public int TotalTransactions() {
        SQLiteDatabase db = this.getReadableDatabase();
        int numRows = (int) DatabaseUtils.queryNumEntries(db, TRANS_TABLE);
        return numRows;
    }

    public boolean updateTrans(Transaction t) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(member_1, t.member_1.id_no);
        contentValues.put(member_2, t.member_2.name);
        contentValues.put(account_1, t.account_1.Account_No);
        contentValues.put(account_2, t.account_2.Account_Name);
        contentValues.put(amount, t.amount);
        contentValues.put(amount_charge, t.amount_charge);
        contentValues.put(code, t.code);
        contentValues.put(loan_no, t.loan_no.Loan_No);
        contentValues.put(transactiontype, t.transactiontype.toString());
        contentValues.put(status, t.status.toString());
        contentValues.put(valid, t.valid);
        contentValues.put(agent, t.agent.agent_code);
        contentValues.put(newpin, t.newpin);
        contentValues.put(pinchanged, t.pinchanged);
        contentValues.put(message, t.message);
        contentValues.put(Telephone_No, t.Telephone_No);
        contentValues.put(Depositor_Name, t.Depositor_Name);
        contentValues.put(Minimun_Amount, t.Minimun_Amount);
        contentValues.put(Maximun_Amount, t.Maximun_Amount);
        contentValues.put(society, t.society.code);
        contentValues.put(product, t.product.Code);
        db.update(TRANS_TABLE, contentValues, reference + " = ? ", new String[]{t.reference});
        return true;
    }
//
//    public Integer deleteTrans(Transaction f) {
//        SQLiteDatabase db = this.getWritableDatabase();
//        return db.delete(TRANS_TABLE,
//                reference + " = ? ",
//                new String[]{f.reference});
//    }
//
//    public ArrayList<Transaction> getAllTrans() {
//        ArrayList<Transaction> array_list = new ArrayList<Collection>();
//        //hp = new HashMap();
//        SQLiteDatabase db = this.getReadableDatabase();
//        Cursor res = db.rawQuery("select * from " + Collection_TABLE_NAME, null);
//        res.moveToFirst();
//
//        while (res.isAfterLast() == false) {
//            Transaction f = new Transaction();
//            f.Collection_Number = res.getString(res.getColumnIndex(Collection_Number));
//            f.Factory = res.getString(res.getColumnIndex(Factory));
//            f.Farmers_Name = res.getString(res.getColumnIndex(Farmers_Name));
//            f.Farmers_Number = res.getString(res.getColumnIndex(Farmers_Number));
//            f.Transporter = res.getString(res.getColumnIndex(Transporter));
//            f.kgcollected = res.getDouble(res.getColumnIndex(kgcollected));
//            f.Kg_Collected = res.getDouble(res.getColumnIndex(Kg_Collected));
//            f.Cumm = res.getDouble(res.getColumnIndex(Cumm));
//            f.sent = (res.getInt(res.getColumnIndex(sent))) == 1 ? true : false;
//            f.Date = (res.getString(res.getColumnIndex(Collections_Date)));
//            f.Time = (res.getString(res.getColumnIndex(Collection_time)));
//            f.status = (res.getString(res.getColumnIndex(status)));
//            array_list.add(f);
//            res.moveToNext();
//        }
//        res.close();
//        return array_list;
//    }
//
public ArrayList<Summaries.Bydate> getdates() {
    ArrayList<Summaries.Bydate> array_list = new ArrayList<Summaries.Bydate>();
    SQLiteDatabase db = this.getReadableDatabase();
    Cursor res = db.query (true,TRANS_TABLE,new String[] {date},null,null,null,null,date + " DESC",null);
    res.moveToFirst();

    while (res.isAfterLast() == false) {
        Summaries.Bydate f = new Summaries.Bydate();
        f.Date =  res.getString(res.getColumnIndex(date));

        array_list.add(f);
        res.moveToNext();
    }
    res.close();
    return array_list;
}
    public ArrayList<Transaction> getTransbydate(String date) {
        ArrayList<Transaction> array_list = new ArrayList<Transaction>();
        //hp = new HashMap();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + TRANS_TABLE + " where date = '"+ date+"'" , null);
        res.moveToFirst();
        while (res.isAfterLast() == false) {
            Transaction c = new Transaction();
            c.reference = res.getString(res.getColumnIndex(reference));
//            c.account_1 = getaccount(res.getString(res.getColumnIndex(account_1)));
//            c.account_2 = getaccount(res.getString(res.getColumnIndex(account_2)));
//            c.member_1 = getaccount(res.getString(res.getColumnIndex(member_1)));
//            c.member_2 = getaccount(res.getString(res.getColumnIndex(member_2)));
           c.Name = res.getString(res.getColumnIndex(tname));
            c.amount = res.getFloat(res.getColumnIndex(amount));
            c.amount_charge = res.getFloat(res.getColumnIndex(amount_charge));
           // c.agent = getagent(res.getString(res.getColumnIndex(agent)));
            c.Depositor_Name = res.getString(res.getColumnIndex(Depositor_Name));
            c.code = res.getString(res.getColumnIndex(code));
         //   c.loan_no = getloan(res.getString(res.getColumnIndex(loan_no)));
            c.transactiontype = Transaction.Transtype.values()[res.getInt(res.getColumnIndex(transactiontype))];
            c.status = Transaction.Status.values()[res.getInt(res.getColumnIndex(status))];
            c.Minimun_Amount = res.getFloat(res.getColumnIndex(Minimun_Amount));
            c.Maximun_Amount = res.getFloat(res.getColumnIndex(Maximun_Amount));
           // c.product = getproduct(res.getString(res.getColumnIndex(product)));
         //   c.message = res.getString(res.getColumnIndex(message));
          //  c.valid = (res.getInt(res.getColumnIndex(valid))) == 1 ? true : false;
          //  c.society = getsociety(res.getString(res.getColumnIndex(society)));
            c.Telephone_No = res.getString(res.getColumnIndex(Telephone_No));
            array_list.add(c);
            res.moveToNext();
        }
        res.close();
        return array_list;
    }
//    //endregion Trans
//
//    //region Accounts
//    public Long insertAccounts(Account t) {
//        SQLiteDatabase db = this.getWritableDatabase();
//        ContentValues contentValues = new ContentValues();
//        contentValues.put(Account_No, t.Account_No);
//        contentValues.put(member_1, t.member_1.id_no);
//        contentValues.put(member_2, t.member_2.id_no);
//        contentValues.put(account_1, t.account_1.Account_No);
//        contentValues.put(account_2, t.account_2.Account_No);
//        contentValues.put(amount, t.amount);
//        contentValues.put(amount_charge, t.amount_charge);
//        contentValues.put(code, t.code);
//        contentValues.put(loan_no, t.loan_no.Loan_No);
//        contentValues.put(transactiontype, t.transactiontype.ordinal());
//        contentValues.put(status, t.status.ordinal());
//        contentValues.put(valid, t.valid);
//        contentValues.put(agent, t.agent.agent_code);
//        contentValues.put(message, t.message);
//        contentValues.put(Telephone_No, t.Telephone_No);
//        contentValues.put(Depositor_Name, t.Depositor_Name);
//        contentValues.put(Minimun_Amount, t.Minimun_Amount);
//        contentValues.put(Maximun_Amount, t.Maximun_Amount);
//        contentValues.put(society, t.society.code);
//        contentValues.put(product, t.product.Code);
//        long dd = db.insertWithOnConflict(TRANS_TABLE, null, contentValues, SQLiteDatabase.CONFLICT_REPLACE);
//        return dd;
//    }
//    public int TotalTransactions() {
//        SQLiteDatabase db = this.getReadableDatabase();
//        int numRows = (int) DatabaseUtils.queryNumEntries(db, TRANS_TABLE);
//        return numRows;
//    }
//    public boolean updateTrans(Transaction t) {
//        SQLiteDatabase db = this.getWritableDatabase();
//        ContentValues contentValues = new ContentValues();
//        contentValues.put(member_1, t.member_1.id_no);
//        contentValues.put(member_2, t.member_2.name);
//        contentValues.put(account_1, t.account_1.Account_No);
//        contentValues.put(account_2, t.account_2.Account_Name);
//        contentValues.put(amount, t.amount);
//        contentValues.put(amount_charge, t.amount_charge);
//        contentValues.put(code, t.code);
//        contentValues.put(loan_no, t.loan_no.Loan_No);
//        contentValues.put(transactiontype, t.transactiontype.toString());
//        contentValues.put(status, t.status.toString());
//        contentValues.put(valid, t.valid);
//        contentValues.put(agent, t.agent.agent_code);
//        contentValues.put(newpin, t.newpin);
//        contentValues.put(pinchanged, t.pinchanged);
//        contentValues.put(message, t.message);
//        contentValues.put(Telephone_No, t.Telephone_No);
//        contentValues.put(Depositor_Name, t.Depositor_Name);
//        contentValues.put(Minimun_Amount, t.Minimun_Amount);
//        contentValues.put(Maximun_Amount, t.Maximun_Amount);
//        contentValues.put(society, t.society.code);
//        contentValues.put(product, t.product.Code);
//        db.update(TRANS_TABLE, contentValues, reference + " = ? ", new String[]{t.reference});
//        return true;
//    }
//    public Integer deleteTrans(Transaction f) {
//        SQLiteDatabase db = this.getWritableDatabase();
//        return db.delete(TRANS_TABLE,
//                reference + " = ? ",
//                new String[]{f.reference});
//    }
//    public ArrayList<Transaction> getAllTrans() {
//        ArrayList<Collection> array_list = new ArrayList<Collection>();
//        //hp = new HashMap();
//        SQLiteDatabase db = this.getReadableDatabase();
//        Cursor res = db.rawQuery("select * from " + Collection_TABLE_NAME, null);
//        res.moveToFirst();
//
//        while (res.isAfterLast() == false) {
//            Collection f = new Collection();
//            f.Collection_Number = res.getString(res.getColumnIndex(Collection_Number));
//            f.Factory = res.getString(res.getColumnIndex(Factory));
//            f.Farmers_Name = res.getString(res.getColumnIndex(Farmers_Name));
//            f.Farmers_Number = res.getString(res.getColumnIndex(Farmers_Number));
//            f.Transporter = res.getString(res.getColumnIndex(Transporter));
//            f.kgcollected = res.getDouble(res.getColumnIndex(kgcollected));
//            f.Kg_Collected = res.getDouble(res.getColumnIndex(Kg_Collected));
//            f.Cumm = res.getDouble(res.getColumnIndex(Cumm));
//            f.sent = (res.getInt(res.getColumnIndex(sent))) == 1 ? true : false;
//            f.Date = (res.getString(res.getColumnIndex(Collections_Date)));
//            f.Time = (res.getString(res.getColumnIndex(Collection_time)));
//            f.status = (res.getString(res.getColumnIndex(status)));
//            array_list.add(f);
//            res.moveToNext();
//        }
//        res.close();
//        return array_list;
//    }
//    public ArrayList<Transaction> getpendingTrans() {
//        ArrayList<Transaction> array_list = new ArrayList<Transaction>();
//        //hp = new HashMap();
//        SQLiteDatabase db = this.getReadableDatabase();
//        Cursor res = db.rawQuery("select * from " + TRANS_TABLE + " where status ='Pending'", null);
//        res.moveToFirst();
//        while (res.isAfterLast() == false) {
//            Transaction c = new Transaction();
//            c.reference = res.getString(res.getColumnIndex(reference));
//            c.account_1 = getaccount(res.getString(res.getColumnIndex(account_1)));
//            c.account_2 = getaccount(res.getString(res.getColumnIndex(account_2)));
//            c.member_1 = getaccount(res.getString(res.getColumnIndex(member_1)));
//            c.member_2 = getaccount(res.getString(res.getColumnIndex(member_2)));
//            c.amount = res.getFloat(res.getColumnIndex(amount_charge));
//            c.amount_charge = res.getFloat(res.getColumnIndex(amount_charge));
//            c.agent = getagent(res.getString(res.getColumnIndex(agent)));
//            c.Depositor_Name = res.getString(res.getColumnIndex(Depositor_Name));
//            c.code = res.getString(res.getColumnIndex(code));
//            c.loan_no = getloan(res.getString(res.getColumnIndex(loan_no)));
//            c.transactiontype = Transaction.Transtype.values()[res.getInt(res.getColumnIndex(Depositor_Name))];
//            c.status = Transaction.Status.values()[res.getInt(res.getColumnIndex(Depositor_Name))];
//            c.Minimun_Amount = res.getFloat(res.getColumnIndex(Minimun_Amount));
//            c.Maximun_Amount = res.getFloat(res.getColumnIndex(Maximun_Amount));
//            c.product = getproduct(res.getString(res.getColumnIndex(product)));
//            c.message = res.getString(res.getColumnIndex(message));
//            c.valid = (res.getInt(res.getColumnIndex(valid))) == 1 ? true : false;
//            c.society = getsociety(res.getString(res.getColumnIndex(society)));
//            c.Telephone_No = res.getString(res.getColumnIndex(Telephone_No));
//            array_list.add(c);
//            res.moveToNext();
//        }
//        res.close();
//        return array_list;
//    }


}
    //endregion Trans


