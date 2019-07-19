package com.example.paul.m_branch;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.DatabaseUtils;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.text.TextUtils;
import android.util.Log;
import android.widget.ArrayAdapter;

import java.lang.reflect.Field;
import java.lang.reflect.Member;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class DB extends SQLiteOpenHelper {

    public static final String DATABASE_NAME = "MBranch.db";

    public static class t {
        public static final String Transactions_TABLE_NAME = "transactions";
        public static final String tmpTransactions_TABLE_NAME = "tmpFarmer";
        public static final String Document_No = "Document_No";
        public static final String Account_No = "Account_No";
        public static final String Agent_Code = "Agent_Code";
        public static final String Loan_No = "Loan_No";
        public static final String Account_Name = "Account_Name";
        public static final String Telephone = "Telephone";
        public static final String Id_No = "Id_No";
        public static final String Amount = "Amount";
        public static final String Transaction_Type = "Transaction_Type";
        public static final String Date = "Date";
        public static final String Time = "Time";
        public static final String OTTN = "OTTN";
        public static final String sent = "sent";
        public static final String Gender = "Gender";
        public static final String Marital = "Marital";
        public static final String Constituency = "Constituency";
        public static final String Ward = "Ward";
        public static final String Type = "Type";
        public static final String Group = "Groups";

        public List<summaries.reportfields> transfields() {
            //com.example.paul.m_branch.DB$t: $change=null, Account_Name=Account_Name, Account_No=Account_No, Agent_Code=Agent_Code, Amount=Amount, Constituency=Constituency, Date=Date, Document_No=Document_No, Gender=Gender, Id_No=Id_No, Loan_No=Loan_No, Marital=Marital, OTTN=OTTN, Telephone=Telephone, Time=Time, Transaction_Type=Transaction_Type, Transactions_TABLE_NAME=transactions, Ward=Ward, sent=sent, serialVersionUID=0, tmpTransactions_TABLE_NAME=tmpFarmer,
            ArrayList<summaries.reportfields> rfs = new ArrayList<>();

            for (Field f : getClass().getDeclaredFields()) {
                if (!f.getName().equals("$change") && !f.getName().equals("Agent_Code") && !f.getName().equals("Id_No") && !f.getName().equals("Loan_No") && !f.getName().equals("Marital") && !f.getName().equals("Gender") && !f.getName().equals("Gender")) {

                    summaries.reportfields rf = new summaries.reportfields();
                    rf.field = f.getName();

                    try {
                        rf.value = f.get(t.this).toString();

                    } catch (IllegalAccessException e) {
                        e.printStackTrace();
                    }
                    rfs.add(rf);
                }
            }
            return rfs;
        }


    }

    class a {
        public static final String agent_Table = "Agent";
        public static final String tmpagent_Table = "tmpAgent";
        public static final String Code = "Code";
        public static final String Customer_ID_No = "Customer_ID_No";
        public static final String Mobile_No = "Mobile_No";
        public static final String Status = "Status";
        public static final String agentName = "Name";
        public static final String Account = "Account";
        public static final String Password = "Password";
        public static final String Constituency = "Constituency";
        public static final String Account_type = "Account_type";
    }

    class m {
        public static final String member_Table = "Members";
        public static final String tmpmember_Table = "tmpMembers";
        public static final String No = "No";
        public static final String Name = "Name";
        public static final String Phone_No = "Phone_No";
        public static final String ID_No = "ID_No";
        public static final String Gender = "Gender";
        public static final String E_Mail = "E_Mail";
        public static final String Group = "Group_code";
        public static final String updated = "updated";
        public static final String Un_allocated_Funds = "Un_allocated_Funds";
        public static final String Outstanding_Balance = "Outstanding_Balance";
        public static final String Repayment = "Repayment";

    }

    class g {
        public static final String group_Table = "Groups";
        public static final String tmpgroup_Table = "tmpGroups";
        public static final String groupCode = "Code";
        public static final String groupName = "groupName";
    }

    static class v {
        public static final String vehicles_Table = "vehicles";
        public static final String tmpvehicles_Table = "tmpvehicles";
        public static final String Vehicle_Number = "Vehicle_Number";
        public static final String vehicle_type = "vehicle_type";
        public static final String Daily_Contribution = "Daily_Contribution";
        public static final String Start_Date = "Start_Date";
        public static final String Code = "Code";
        public static final String Id_Number = "Id_Number";

        public static ContentValues values(vehicles vv) {
            ContentValues contentValues = new ContentValues();
            contentValues.put(Vehicle_Number, vv.Vehicle_Number);
            contentValues.put(Daily_Contribution, vv.Daily_Contribution);
            contentValues.put(Start_Date, vv.Start_Date);
            contentValues.put(Code, vv.Code);
            contentValues.put(vehicle_type, vv.vehicle_type);
            contentValues.put(Id_Number, vv.Id_Number);
            return contentValues;
        }
    }

    static class tt {
        public static final String Types_Table = "types";
        public static final String tmpTypes_Table = "tmptypes";
        public static final String Code = "Code";
        public static final String Name = "Name";
        public static final String Active = "active";
        public static final String Attach_to_vehicle = "Attach_to_vehicle";
        public static final String Order = "lOrder";

        public static ContentValues values(types c) {
            ContentValues contentValues = new ContentValues();
            contentValues.put(Code, c.Code);
            contentValues.put(Name, c.Name);
            contentValues.put(Active, c.Active);
            contentValues.put(Attach_to_vehicle, c.Attach_to_vehicle);
            contentValues.put(Order, c.Order);
            return contentValues;
        }
    }

    static class l {

        public static final String Loanstable = "Loans";
        public static final String tmpLoanstable = "tmpLoans";
        public static final String Credit_Number = "Credit_Number";
        public static final String Client_Code = "Client_Code";
        public static final String Client_Name = "Client_Name";
        public static final String Client_ID_Number = "Client_ID_Number";
        public static final String Loan = "Loan";

        public static ContentValues values(loan l) {
            ContentValues contentValues = new ContentValues();
            contentValues.put(Credit_Number, l.Credit_Number);
            contentValues.put(Client_Code, l.Client_Code);
            contentValues.put(Client_ID_Number, l.Client_ID_Number);
            contentValues.put(Client_Name, l.Client_Name);
            contentValues.put(Loan, l.Loan);
            return contentValues;
        }
    }

    public DB(Context context) {
        super(context, DATABASE_NAME, null, 17);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        // TODO Auto-generated method stub
        db.execSQL(
                "create table " + t.Transactions_TABLE_NAME + "" +
                        "(" + t.Document_No + " text primary key," +
                        t.Account_Name + " text," +
                        t.Account_No + " text," +
                        t.Agent_Code + " text," +
                        t.Amount + " float," +
                        t.Telephone + " text," +
                        t.Loan_No + " text," +
                        t.Date + " text," +
                        t.Time + " text," +
                        t.OTTN + " text," +
                        t.Ward + " text," +
                        t.Type + " text," +
                        t.Group + " text," +
                        t.Constituency + " text," +
                        t.sent + " boolean," +
                        t.Transaction_Type + " integer," +
                        t.Gender + " integer," +
                        t.Marital + " integer," +
                        t.Id_No + " text )"
        );
        db.execSQL(
                "create table " + a.agent_Table + "" +
                        "(" + a.Code + " text primary key," +
                        a.agentName + " text," +
                        a.Customer_ID_No + " text," +
                        a.Mobile_No + " text," +
                        a.Status + " text," +
                        a.Account + " text," +
                        a.Constituency + " text," +
                        a.Account_type + " integer," +
                        a.Password + " text )");
        db.execSQL(
                "create table " + l.Loanstable + "" +
                        "(" + l.Credit_Number + " text primary key," +
                        l.Loan + " text," +
                        l.Client_Code + " text," +
                        l.Client_Name + " text," +
                        l.Client_ID_Number + " text )");
        db.execSQL(
                "create table " + m.member_Table + "" +
                        "(" + m.No + " text primary key," +
                        m.Name + " text," +
                        m.Phone_No + " text," +
                        m.ID_No + " text," +
                        m.Gender + " int," +
                        m.updated + " boolean," +
                        m.E_Mail + " text," +
                        m.Un_allocated_Funds + " float," +
                        m.Outstanding_Balance + " float," +
                        m.Repayment + " float," +
                        m.Group + " text)");
        db.execSQL(
                "create table " + g.group_Table + "" +
                        "(" + g.groupCode + " text primary key," +
                        g.groupName + " text)");
        db.execSQL(
                "create table " + v.vehicles_Table + "" +
                        "(" + v.Code + " text primary key," +
                        v.Vehicle_Number + " text," +
                        v.vehicle_type + " text," +
                        v.Start_Date + " text," +
                        v.Daily_Contribution + " float," +
                        v.Id_Number + " text)");
        db.execSQL(
                "create table " + tt.Types_Table + "" +
                        "(" + tt.Code + " text primary key," +
                        tt.Active + " boolean," +
                        tt.Order + " int," +
                        tt.Attach_to_vehicle + " boolean," +
                        tt.Name + " text)");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // TODO Auto-generated method stub
        try {
            Cursor res = db.query(t.Transactions_TABLE_NAME, null, null, null, null, null, null);
            String[] cols = res.getColumnNames();
            List<String> fcols = new ArrayList<String>(Arrays.asList(cols));

            res = db.query(a.agent_Table, null, null, null, null, null, null);
            cols = res.getColumnNames();
            List<String> acols = new ArrayList<String>(Arrays.asList(cols));


            res = db.query(m.member_Table, null, null, null, null, null, null);
            cols = res.getColumnNames();
            List<String> mcols = new ArrayList<String>(Arrays.asList(cols));


            res = db.query(g.group_Table, null, null, null, null, null, null);
            cols = res.getColumnNames();
            List<String> gcols = new ArrayList<String>(Arrays.asList(cols));

            List<String> ttcols = null;
            if (tableexists(db, tt.Types_Table)) {
                res = db.query(tt.Types_Table, null, null, null, null, null, null);
                cols = res.getColumnNames();
                ttcols = new ArrayList<String>(Arrays.asList(cols));
            }
            List<String> ccols = null;
            if (tableexists(db, v.vehicles_Table)) {
                res = db.query(v.vehicles_Table, null, null, null, null, null, null);
                cols = res.getColumnNames();
                ccols = new ArrayList<String>(Arrays.asList(cols));
            }

            List<String> lcols = null;
            if (tableexists(db, l.Loanstable)) {
                res = db.query(l.Loanstable, null, null, null, null, null, null);
                cols = res.getColumnNames();
                lcols = new ArrayList<String>(Arrays.asList(cols));
            }
            db.execSQL("Drop table if exists " + t.tmpTransactions_TABLE_NAME);
            db.execSQL("Drop table if exists " + a.tmpagent_Table);
            db.execSQL("Drop table if exists " + g.tmpgroup_Table);
            db.execSQL("Drop table if exists " + m.tmpmember_Table);
            db.execSQL("Drop table if exists " + v.tmpvehicles_Table);
            db.execSQL("Drop table if exists " + tt.tmpTypes_Table);
            db.execSQL("Drop table if exists " + l.tmpLoanstable);

            if (tableexists(db, t.Transactions_TABLE_NAME))
                db.execSQL("ALTER table " + t.Transactions_TABLE_NAME + " RENAME TO '" + t.tmpTransactions_TABLE_NAME + "'");
            if (tableexists(db, a.agent_Table))
                db.execSQL("ALTER table " + a.agent_Table + " RENAME TO '" + a.tmpagent_Table + "'");
            if (tableexists(db, m.member_Table))
                db.execSQL("ALTER table " + m.member_Table + " RENAME TO '" + m.tmpmember_Table + "'");
            if (tableexists(db, g.group_Table))
                db.execSQL("ALTER table " + g.group_Table + " RENAME TO '" + g.tmpgroup_Table + "'");
            if (tableexists(db, v.vehicles_Table))
                db.execSQL("ALTER table " + v.vehicles_Table + " RENAME TO '" + v.tmpvehicles_Table + "'");
            if (tableexists(db, tt.Types_Table))
                db.execSQL("ALTER table " + tt.Types_Table + " RENAME TO '" + tt.tmpTypes_Table + "'");
            if (tableexists(db, l.Loanstable))
                db.execSQL("ALTER table " + l.Loanstable + " RENAME TO '" + l.tmpLoanstable + "'");


            onCreate(db);

            String tcol = TextUtils.join(",", fcols);
            String acol = TextUtils.join(",", acols);
            String mcol = TextUtils.join(",", mcols);
            String gcol = TextUtils.join(",", gcols);
            String ttcol = null;
            String llcol = null;
            String ccol = null;
            if (ccols != null)
                ccol = TextUtils.join(",", ccols);
            if (ttcols != null)
                ttcol = TextUtils.join(",", ttcols);
            if (lcols != null)
                llcol = TextUtils.join(",", lcols);
            if ((tableexists(db, t.Transactions_TABLE_NAME)) && (tableexists(db, t.tmpTransactions_TABLE_NAME)))
                db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s", t.Transactions_TABLE_NAME, tcol, tcol, t.tmpTransactions_TABLE_NAME));
            if ((tableexists(db, a.agent_Table)) && (tableexists(db, a.tmpagent_Table)))
                db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s", a.agent_Table, acol, acol, a.tmpagent_Table));
            if ((tableexists(db, m.member_Table)) && (tableexists(db, m.tmpmember_Table)))
                db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s", m.member_Table, mcol, mcol, m.tmpmember_Table));
            if ((tableexists(db, g.group_Table)) && (tableexists(db, g.tmpgroup_Table)))
                db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s", g.group_Table, gcol, gcol, g.tmpgroup_Table));
            if ((tableexists(db, v.vehicles_Table)) && (tableexists(db, v.tmpvehicles_Table)))
                db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s", v.vehicles_Table, ccol, ccol, v.tmpvehicles_Table));
            if ((tableexists(db, tt.Types_Table)) && (tableexists(db, tt.tmpTypes_Table)))
                db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s", tt.Types_Table, ttcol, ttcol, tt.tmpTypes_Table));
            if ((tableexists(db, l.Loanstable)) && (tableexists(db, l.tmpLoanstable)))
                db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s", l.Loanstable, llcol, llcol, l.tmpLoanstable));
            db.execSQL(" DROP table '" + t.tmpTransactions_TABLE_NAME + "'");
            db.execSQL(" DROP table '" + m.tmpmember_Table + "'");
            db.execSQL(" DROP table '" + g.tmpgroup_Table + "'");
            db.execSQL(" DROP table '" + a.tmpagent_Table + "'");
            if (tableexists(db, v.tmpvehicles_Table))
                db.execSQL(" DROP table '" + v.tmpvehicles_Table + "'");
            if (tableexists(db, tt.tmpTypes_Table))
                db.execSQL(" DROP table '" + tt.tmpTypes_Table + "'");
            if (tableexists(db, l.tmpLoanstable))
                db.execSQL(" DROP table '" + l.tmpLoanstable + "'");
            Log.i("Db update", "Database updated");
        } catch (Exception ex) {
            ex.printStackTrace();
            throw ex;
        }

    }

    private Boolean tableexists(SQLiteDatabase db, String table) {
        boolean exists = false;
        Cursor cursor = db.rawQuery("SELECT * FROM sqlite_master WHERE name ='" + table + "' and type='table'", null);
        exists = (cursor.getCount() > 0);

        cursor.close();
        return exists;
    }

    public boolean inserttrans(transaction f) {
        try {
            SQLiteDatabase db = this.getWritableDatabase();
            ContentValues contentValues = new ContentValues();
            contentValues.put(t.Account_Name, f.Account_Name);
            contentValues.put(t.Account_No, f.Account_No);
            contentValues.put(t.Telephone, f.Telephone);
            contentValues.put(t.Amount, f.Amount);
            contentValues.put(t.Loan_No, f.Loan_No);
            contentValues.put(t.Date, f.Date);
            contentValues.put(t.Agent_Code, f.Agent_Code);
            contentValues.put(t.Time, f.Time);
            contentValues.put(t.Id_No, f.Id_No);
            contentValues.put(t.OTTN, f.OTTN);
            contentValues.put(t.Document_No, f.Document_No);
            contentValues.put(t.Transaction_Type, f.Transaction_Type);
            contentValues.put(t.Gender, f.Gender);
            contentValues.put(t.Marital, f.Marital);
            contentValues.put(t.Constituency, f.Constituency);
            contentValues.put(t.Ward, f.Ward);
            contentValues.put(t.sent, f.sent);
            contentValues.put(t.Type, f.Type);
            contentValues.put(t.Group, f.Group);

            db.insertWithOnConflict(t.Transactions_TABLE_NAME, null, contentValues, SQLiteDatabase.CONFLICT_REPLACE);
        } catch (Exception e) {
            e.printStackTrace();
        }
        return true;
    }

    public boolean updatetrans(transaction f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(t.Account_No, f.Account_No);
        contentValues.put(t.Account_Name, f.Account_Name);
        contentValues.put(t.Telephone, f.Telephone);
        contentValues.put(t.Transaction_Type, f.Transaction_Type);
        contentValues.put(t.Loan_No, f.Loan_No);
        contentValues.put(t.Amount, f.Amount);
        contentValues.put(t.Date, f.Date);
        contentValues.put(t.Id_No, f.Id_No);
        contentValues.put(t.Time, f.Time);
        contentValues.put(t.OTTN, f.OTTN);
        contentValues.put(t.sent, f.sent);
        contentValues.put(t.Agent_Code, f.Agent_Code);
        contentValues.put(t.Gender, f.Gender);
        contentValues.put(t.Marital, f.Marital);
        contentValues.put(t.Constituency, f.Constituency);
        contentValues.put(t.Ward, f.Ward);
        contentValues.put(t.Type, f.Type);
        contentValues.put(t.Group, f.Group);
        db.update(t.Transactions_TABLE_NAME, contentValues, t.Document_No + " = ? ", new String[]{f.Document_No});
        return true;
    }

    public boolean updatetransstatus(transaction f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(t.sent, f.sent);
        db.update(t.Transactions_TABLE_NAME, contentValues, t.Document_No + " = ? ", new String[]{f.Document_No});
        return true;
    }

    public boolean post(transaction f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(t.sent, "0");
        db.update(t.Transactions_TABLE_NAME, contentValues, t.OTTN + " = ? ", new String[]{f.OTTN});
        return true;
    }
    public boolean post(String f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(t.sent, "0");
        db.update(t.Transactions_TABLE_NAME, contentValues, t.OTTN + " = ? ", new String[]{f});
        return true;
    }
    public boolean refresh(String f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(t.sent, "0");
        db.update(t.Transactions_TABLE_NAME, contentValues, t.Date + " = ? ", new String[]{f});
        return true;
    }
    public transaction gettrans(String Accountno) {
        transaction f = null;
        //hp = new HashMap();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + t.Transactions_TABLE_NAME + " Where " + t.Account_No + " =?", new String[]{Accountno + ""});
        if (res.getCount() > 0) {
            res.moveToFirst();
            f = new transaction();
            f.Account_No = res.getString(res.getColumnIndex(t.Account_No));
            f.Account_Name = res.getString(res.getColumnIndex(t.Account_Name));
            f.Telephone = res.getString(res.getColumnIndex(t.Telephone));
            f.Transaction_Type = res.getInt(res.getColumnIndex(t.Transaction_Type));
            f.sent = (res.getInt(res.getColumnIndex(t.sent)) == 0 ? false : true);
            f.Amount = res.getDouble(res.getColumnIndex(t.Amount));
            f.Document_No = res.getString(res.getColumnIndex(t.Document_No));
            f.Date = res.getString(res.getColumnIndex(t.Date));
            f.Time = res.getString(res.getColumnIndex(t.Time));
            f.OTTN = res.getString(res.getColumnIndex(t.OTTN));
            f.Id_No = res.getString(res.getColumnIndex(t.Id_No));
            f.Constituency = res.getString(res.getColumnIndex(t.Constituency));
            f.Ward = res.getString(res.getColumnIndex(t.Ward));
            f.Type = res.getString(res.getColumnIndex(t.Type));
            f.Agent_Code = res.getString(res.getColumnIndex(t.Agent_Code));
            f.Gender = res.getInt(res.getColumnIndex(t.Gender));
            f.Marital = res.getInt(res.getColumnIndex(t.Marital));
        }

        res.close();
        return f;
    }
    public ArrayList<transaction> gettransallbydate(String date) {
        ArrayList<transaction> array_list = new ArrayList<transaction>();
        //hp = new HashMap();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + t.Transactions_TABLE_NAME + " where " + t.Date +"=?",new String[]{date} );
        res.moveToFirst();
        while (res.isAfterLast() == false) {
            transaction f = new transaction();
            f.Account_No = res.getString(res.getColumnIndex(t.Account_No));
            f.Account_Name = res.getString(res.getColumnIndex(t.Account_Name));
            f.Telephone = res.getString(res.getColumnIndex(t.Telephone));
            f.Transaction_Type = res.getInt(res.getColumnIndex(t.Transaction_Type));
            f.sent = (res.getInt(res.getColumnIndex(t.sent)) == 0 ? false : true);
            f.Amount = res.getDouble(res.getColumnIndex(t.Amount));
            f.Document_No = res.getString(res.getColumnIndex(t.Document_No));
            f.Loan_No = res.getString(res.getColumnIndex(t.Loan_No));
            f.Date = res.getString(res.getColumnIndex(t.Date));
            f.Time = res.getString(res.getColumnIndex(t.Time));
            f.Id_No = res.getString(res.getColumnIndex(t.Id_No));
            f.OTTN = res.getString(res.getColumnIndex(t.OTTN));
            f.Agent_Code = res.getString(res.getColumnIndex(t.Agent_Code));
            f.Constituency = res.getString(res.getColumnIndex(t.Constituency));
            f.Ward = res.getString(res.getColumnIndex(t.Ward));
            f.Gender = res.getInt(res.getColumnIndex(t.Gender));
            f.Marital = res.getInt(res.getColumnIndex(t.Marital));
            f.Type = res.getString(res.getColumnIndex(t.Type));
            f.Group = res.getString(res.getColumnIndex(t.Group));
            res.moveToNext();
            array_list.add(f);
        }
        res.close();
        return array_list;
    }
    public ArrayList<summaries.Receipts> getcollectionreceiptsbydate(String date) {
        ArrayList<summaries.Receipts> array_list = new ArrayList<summaries.Receipts>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor r = db.query(true, t.Transactions_TABLE_NAME, new String[]{t.OTTN}, t.Date + "=?", new String[] {date}, null, null, t.OTTN + " DESC", null);
        r.moveToFirst();
        while (r.isAfterLast() == false) {
            summaries.Receipts f = new summaries.Receipts();
            f.receipt = r.getString(r.getColumnIndex(t.OTTN));
            array_list.add(f);
            r.moveToNext();
        }
        Log.i("dates", String.valueOf(array_list.size()));
        r.close();
        return array_list;
    }

    public ArrayList<summaries.collectiondates> getcollectiondates() {
        ArrayList<summaries.collectiondates> array_list = new ArrayList<summaries.collectiondates>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.query(true, t.Transactions_TABLE_NAME, new String[]{t.Date}, null, null, null, null, t.OTTN + " DESC", null);
        res.moveToFirst();
        while (res.isAfterLast() == false) {
            summaries.collectiondates f = new summaries.collectiondates();
            f.date = res.getString(res.getColumnIndex(t.Date));
            array_list.add(f);
            res.moveToNext();
        }
        Log.i("dates", String.valueOf(array_list.size()));
        res.close();
        return array_list;
    }
    public ArrayList<summaries.Receipts> getcollectionreceipts() {
        ArrayList<summaries.Receipts> array_list = new ArrayList<summaries.Receipts>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor r = db.query(true, t.Transactions_TABLE_NAME, new String[]{t.OTTN}, null, null, null, null, t.OTTN + " DESC", null);
        r.moveToFirst();
        while (r.isAfterLast() == false) {
            summaries.Receipts f = new summaries.Receipts();
            f.receipt = r.getString(r.getColumnIndex(t.OTTN));

            array_list.add(f);
            r.moveToNext();
        }
        Log.i("dates", String.valueOf(array_list.size()));
        r.close();
        return array_list;
    }

    public ArrayList<transaction> gettransbybatch(String ottn) {
        ArrayList<transaction> array_list = new ArrayList<transaction>();
        //hp = new HashMap();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + t.Transactions_TABLE_NAME + " Where " + t.OTTN + " =?", new String[]{ottn + ""});
        res.moveToFirst();

        while (res.isAfterLast() == false) {
            transaction f = new transaction();
            f.Account_No = res.getString(res.getColumnIndex(t.Account_No));
            f.Account_Name = res.getString(res.getColumnIndex(t.Account_Name));
            f.Telephone = res.getString(res.getColumnIndex(t.Telephone));
            f.Transaction_Type = res.getInt(res.getColumnIndex(t.Transaction_Type));
            f.sent = (res.getInt(res.getColumnIndex(t.sent)) == 0 ? false : true);
            f.Amount = res.getDouble(res.getColumnIndex(t.Amount));
            f.Document_No = res.getString(res.getColumnIndex(t.Document_No));
            f.Loan_No = res.getString(res.getColumnIndex(t.Loan_No));
            f.Date = res.getString(res.getColumnIndex(t.Date));
            f.Time = res.getString(res.getColumnIndex(t.Time));
            f.Id_No = res.getString(res.getColumnIndex(t.Id_No));
            f.OTTN = res.getString(res.getColumnIndex(t.OTTN));
            f.Agent_Code = res.getString(res.getColumnIndex(t.Agent_Code));
            f.Constituency = res.getString(res.getColumnIndex(t.Constituency));
            f.Ward = res.getString(res.getColumnIndex(t.Ward));
            f.Type = res.getString(res.getColumnIndex(t.Type));
            f.Group = res.getString(res.getColumnIndex(t.Group));
            f.typename = gettype(f.Type).Name;
            f.Gender = res.getInt(res.getColumnIndex(t.Gender));
            f.Marital = res.getInt(res.getColumnIndex(t.Marital));
            res.moveToNext();
            array_list.add(f);
        }
        res.close();
        return array_list;
    }

    public transaction gettransbydocument(String doc) {
        transaction array_list = null;
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + t.Transactions_TABLE_NAME + " Where " + t.Document_No + " =?", new String[]{doc + ""});
        res.moveToFirst();
        transaction f = new transaction();
        f.Account_No = res.getString(res.getColumnIndex(t.Account_No));
        f.Account_Name = res.getString(res.getColumnIndex(t.Account_Name));
        f.Telephone = res.getString(res.getColumnIndex(t.Telephone));
        f.Transaction_Type = res.getInt(res.getColumnIndex(t.Transaction_Type));
        f.sent = (res.getInt(res.getColumnIndex(t.sent)) == 0 ? false : true);
        f.Amount = res.getDouble(res.getColumnIndex(t.Amount));
        f.Document_No = res.getString(res.getColumnIndex(t.Document_No));
        f.Loan_No = res.getString(res.getColumnIndex(t.Loan_No));
        f.Date = res.getString(res.getColumnIndex(t.Date));
        f.Time = res.getString(res.getColumnIndex(t.Time));
        f.Id_No = res.getString(res.getColumnIndex(t.Id_No));
        f.OTTN = res.getString(res.getColumnIndex(t.OTTN));
        f.Agent_Code = res.getString(res.getColumnIndex(t.Agent_Code));
        f.Constituency = res.getString(res.getColumnIndex(t.Constituency));
        f.Ward = res.getString(res.getColumnIndex(t.Ward));
        f.Type = res.getString(res.getColumnIndex(t.Type));
        f.Group = res.getString(res.getColumnIndex(t.Group));
        f.typename = gettype(f.Type).Name;
        f.Gender = res.getInt(res.getColumnIndex(t.Gender));
        f.Marital = res.getInt(res.getColumnIndex(t.Marital));
        array_list = f;

        res.close();
        return array_list;
    }

    public ArrayList<transaction> gettransbydate(String date) {
        ArrayList<transaction> array_list = new ArrayList<transaction>();
        //hp = new HashMap();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + t.Transactions_TABLE_NAME + " Where " + t.Date + " =?", new String[]{date + ""});
        res.moveToFirst();
        while (res.isAfterLast() == false) {

            transaction f = new transaction();
            f.Account_No = res.getString(res.getColumnIndex(t.Account_No));
            f.Account_Name = res.getString(res.getColumnIndex(t.Account_Name));
            f.Telephone = res.getString(res.getColumnIndex(t.Telephone));
            f.Transaction_Type = res.getInt(res.getColumnIndex(t.Transaction_Type));
            f.sent = (res.getInt(res.getColumnIndex(t.sent)) == 0 ? false : true);
            f.Amount = res.getDouble(res.getColumnIndex(t.Amount));
            f.Document_No = res.getString(res.getColumnIndex(t.Document_No));
            f.Loan_No = res.getString(res.getColumnIndex(t.Loan_No));
            f.Date = res.getString(res.getColumnIndex(t.Date));
            f.Time = res.getString(res.getColumnIndex(t.Time));
            f.Id_No = res.getString(res.getColumnIndex(t.Id_No));
            f.OTTN = res.getString(res.getColumnIndex(t.OTTN));
            f.Agent_Code = res.getString(res.getColumnIndex(t.Agent_Code));
            f.Constituency = res.getString(res.getColumnIndex(t.Constituency));
            f.Ward = res.getString(res.getColumnIndex(t.Ward));
            f.Gender = res.getInt(res.getColumnIndex(t.Gender));
            f.Marital = res.getInt(res.getColumnIndex(t.Marital));
            f.Type = res.getString(res.getColumnIndex(t.Type));
            f.Group = res.getString(res.getColumnIndex(t.Group));
            res.moveToNext();
            array_list.add(f);
        }
        res.close();
        return array_list;
    }

    public ArrayList<transaction> gettransbyottn(String ottn) {
        ArrayList<transaction> array_list = new ArrayList<transaction>();
        //hp = new HashMap();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + t.Transactions_TABLE_NAME + " Where " + t.OTTN + " =?", new String[]{ottn + ""});
        res.moveToFirst();
        while (res.isAfterLast() == false) {

            transaction f = new transaction();
            f.Account_No = res.getString(res.getColumnIndex(t.Account_No));
            f.Account_Name = res.getString(res.getColumnIndex(t.Account_Name));
            f.Telephone = res.getString(res.getColumnIndex(t.Telephone));
            f.Transaction_Type = res.getInt(res.getColumnIndex(t.Transaction_Type));
            f.sent = (res.getInt(res.getColumnIndex(t.sent)) == 0 ? false : true);
            f.Amount = res.getDouble(res.getColumnIndex(t.Amount));
            f.Document_No = res.getString(res.getColumnIndex(t.Document_No));
            f.Loan_No = res.getString(res.getColumnIndex(t.Loan_No));
            f.Date = res.getString(res.getColumnIndex(t.Date));
            f.Time = res.getString(res.getColumnIndex(t.Time));
            f.Id_No = res.getString(res.getColumnIndex(t.Id_No));
            f.OTTN = res.getString(res.getColumnIndex(t.OTTN));
            f.Agent_Code = res.getString(res.getColumnIndex(t.Agent_Code));
            f.Constituency = res.getString(res.getColumnIndex(t.Constituency));
            f.Ward = res.getString(res.getColumnIndex(t.Ward));
            f.Gender = res.getInt(res.getColumnIndex(t.Gender));
            f.Marital = res.getInt(res.getColumnIndex(t.Marital));
            f.Type = res.getString(res.getColumnIndex(t.Type));
            f.Group = res.getString(res.getColumnIndex(t.Group));
            res.moveToNext();
            array_list.add(f);
        }
        res.close();
        return array_list;
    }

    public ArrayList<transaction> gettransbydate() {
        ArrayList<transaction> array_list = new ArrayList<transaction>();
        //hp = new HashMap();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + t.Transactions_TABLE_NAME, null);
        res.moveToFirst();

        while (res.isAfterLast() == false) {
            transaction f = new transaction();
            f.Account_No = res.getString(res.getColumnIndex(t.Account_No));
            f.Account_Name = res.getString(res.getColumnIndex(t.Account_Name));
            f.Telephone = res.getString(res.getColumnIndex(t.Telephone));
            f.Transaction_Type = res.getInt(res.getColumnIndex(t.Transaction_Type));
            f.sent = (res.getInt(res.getColumnIndex(t.sent)) == 0 ? false : true);
            f.Amount = res.getDouble(res.getColumnIndex(t.Amount));
            f.Document_No = res.getString(res.getColumnIndex(t.Document_No));
            f.Loan_No = res.getString(res.getColumnIndex(t.Loan_No));
            f.Date = res.getString(res.getColumnIndex(t.Date));
            f.Time = res.getString(res.getColumnIndex(t.Time));
            f.Id_No = res.getString(res.getColumnIndex(t.Id_No));
            f.OTTN = res.getString(res.getColumnIndex(t.OTTN));
            f.Agent_Code = res.getString(res.getColumnIndex(t.Agent_Code));
            f.Constituency = res.getString(res.getColumnIndex(t.Constituency));
            f.Ward = res.getString(res.getColumnIndex(t.Ward));
            f.Gender = res.getInt(res.getColumnIndex(t.Gender));
            f.Marital = res.getInt(res.getColumnIndex(t.Marital));
            f.Type = res.getString(res.getColumnIndex(t.Type));
            res.moveToNext();
            array_list.add(f);
        }
        res.close();
        return array_list;
    }

    public ArrayList<transaction> getunsenttrans() {
        ArrayList<transaction> array_list = new ArrayList<transaction>();

        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + t.Transactions_TABLE_NAME + " Where " + t.sent + " =0", null);
        res.moveToFirst();

        while (res.isAfterLast() == false) {
            transaction f = new transaction();
            f.Account_No = res.getString(res.getColumnIndex(t.Account_No));
            f.Account_Name = res.getString(res.getColumnIndex(t.Account_Name));
            f.Telephone = res.getString(res.getColumnIndex(t.Telephone));
            f.Transaction_Type = res.getInt(res.getColumnIndex(t.Transaction_Type));
            f.sent = (res.getInt(res.getColumnIndex(t.sent)) == 0 ? false : true);
            f.Amount = res.getDouble(res.getColumnIndex(t.Amount));
            f.Loan_No = res.getString(res.getColumnIndex(t.Loan_No));
            f.Document_No = res.getString(res.getColumnIndex(t.Document_No));
            f.Date = res.getString(res.getColumnIndex(t.Date));
            f.Time = res.getString(res.getColumnIndex(t.Time));
            f.OTTN = res.getString(res.getColumnIndex(t.OTTN));
            f.Constituency = res.getString(res.getColumnIndex(t.Constituency));
            f.Ward = res.getString(res.getColumnIndex(t.Ward));
            f.Id_No = res.getString(res.getColumnIndex(t.Id_No));
            f.Agent_Code = res.getString(res.getColumnIndex(t.Agent_Code));
            f.Gender = res.getInt(res.getColumnIndex(t.Gender));
            f.Marital = res.getInt(res.getColumnIndex(t.Marital));
            f.Type = res.getString(res.getColumnIndex(t.Type));
            f.Group = res.getString(res.getColumnIndex(t.Group));

            res.moveToNext();
            array_list.add(f);
        }
        res.close();
        return array_list;
    }
    public ArrayList<transaction> gettransbytype(String Date,String veh,String type) {
        ArrayList<transaction> array_list = new ArrayList<transaction>();

        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + t.Transactions_TABLE_NAME + " Where "
                        + t.Date + " = '"+ Date +"' and "
                        + t.Loan_No + " = '"+ veh +"' and "
                        + t.Type + " = '"+ type +"'"
                , null);
        res.moveToFirst();

        while (res.isAfterLast() == false) {
            transaction f = new transaction();
            f.Account_No = res.getString(res.getColumnIndex(t.Account_No));
            f.Account_Name = res.getString(res.getColumnIndex(t.Account_Name));
            f.Telephone = res.getString(res.getColumnIndex(t.Telephone));
            f.Transaction_Type = res.getInt(res.getColumnIndex(t.Transaction_Type));
            f.sent = (res.getInt(res.getColumnIndex(t.sent)) == 0 ? false : true);
            f.Amount = res.getDouble(res.getColumnIndex(t.Amount));
            f.Loan_No = res.getString(res.getColumnIndex(t.Loan_No));
            f.Document_No = res.getString(res.getColumnIndex(t.Document_No));
            f.Date = res.getString(res.getColumnIndex(t.Date));
            f.Time = res.getString(res.getColumnIndex(t.Time));
            f.OTTN = res.getString(res.getColumnIndex(t.OTTN));
            f.Constituency = res.getString(res.getColumnIndex(t.Constituency));
            f.Ward = res.getString(res.getColumnIndex(t.Ward));
            f.Id_No = res.getString(res.getColumnIndex(t.Id_No));
            f.Agent_Code = res.getString(res.getColumnIndex(t.Agent_Code));
            f.Gender = res.getInt(res.getColumnIndex(t.Gender));
            f.Marital = res.getInt(res.getColumnIndex(t.Marital));
            f.Type = res.getString(res.getColumnIndex(t.Type));
            f.Group = res.getString(res.getColumnIndex(t.Group));

            res.moveToNext();
            array_list.add(f);
        }
        res.close();
        return array_list;
    }
    public boolean deletetrans(String doc) {
        SQLiteDatabase db = this.getReadableDatabase();
        return db.delete(t.Transactions_TABLE_NAME, t.Document_No + "='" + doc + "'", null) > 0;
    }

    public int Totaltrans() {
        SQLiteDatabase db = this.getReadableDatabase();
        int numRows = (int) DatabaseUtils.queryNumEntries(db, t.Transactions_TABLE_NAME);
        return numRows;
    }

    public boolean insertagent(agent f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(a.Account, f.Account);
        contentValues.put(a.agentName, f.Name.toUpperCase());
        contentValues.put(a.Mobile_No, f.Mobile_No);
        contentValues.put(a.Customer_ID_No, f.Customer_ID_No);
        contentValues.put(a.Code, f.Agent_Code);
        contentValues.put(a.Status, f.Status);
        contentValues.put(a.Password, f.Password);
        contentValues.put(a.Constituency, f.Constituency);
        contentValues.put(a.Account_type, f.Account_type);
        db.insertWithOnConflict(a.agent_Table, null, contentValues, SQLiteDatabase.CONFLICT_REPLACE);
        return true;
    }

    public boolean updateagent(agent f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(a.Account, f.Account);
        contentValues.put(a.agentName, f.Name);
        contentValues.put(a.Mobile_No, f.Mobile_No);
        contentValues.put(a.Customer_ID_No, f.Customer_ID_No);
        contentValues.put(a.Code, f.Agent_Code);
        contentValues.put(a.Status, f.Status);
        contentValues.put(a.Password, f.Password);
        contentValues.put(a.Constituency, f.Constituency);
        contentValues.put(a.Account_type, f.Account_type);
        db.update(a.agent_Table, contentValues, a.Code + " = ? ", new String[]{f.Agent_Code});
        return true;
    }

    public agent getagent(String agent) {
        agent f = null;

        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + a.agent_Table + " Where " + a.Code + " =?", new String[]{agent + ""});
        if (res.getCount() > 0) {
            res.moveToFirst();
            f = new agent();
            f.Agent_Code = res.getString(res.getColumnIndex(a.Code));
            f.Account = res.getString(res.getColumnIndex(a.Account));
            f.Customer_ID_No = res.getString(res.getColumnIndex(a.Customer_ID_No));
            f.Mobile_No = res.getString(res.getColumnIndex(a.Mobile_No));
            f.Name = res.getString(res.getColumnIndex(a.agentName));
            f.Status = res.getInt(res.getColumnIndex(a.Status));
            f.Password = res.getString(res.getColumnIndex(a.Password));
            f.Constituency = res.getString(res.getColumnIndex(a.Constituency));
            f.Account_type = res.getInt(res.getColumnIndex(a.Account_type));
        }
        res.close();
        return f;
    }

    public int Totalagents() {
        SQLiteDatabase db = this.getReadableDatabase();
        int numRows = (int) DatabaseUtils.queryNumEntries(db, a.agent_Table);
        return numRows;
    }

    public int deleteagents() {
        SQLiteDatabase db = this.getReadableDatabase();
        return db.delete(a.agent_Table, null, null);
    }

    public boolean insertmember(member f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(m.E_Mail, f.E_Mail);
        contentValues.put(m.Gender, f.Gender);
        contentValues.put(m.Group, f.Group);
        contentValues.put(m.ID_No, f.ID_No);
        contentValues.put(m.Phone_No, f.Phone_No);
        contentValues.put(m.Name, f.Name);
        contentValues.put(m.No, f.No);
        contentValues.put(m.Un_allocated_Funds, f.Un_allocated_Funds);
        contentValues.put(m.Outstanding_Balance, f.Outstanding_Balance);
        contentValues.put(m.Repayment, f.Repayment);
        contentValues.put(m.updated, f.updated);
        db.insertWithOnConflict(m.member_Table, null, contentValues, SQLiteDatabase.CONFLICT_REPLACE);
        return true;
    }

    public boolean updatemember(member f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(m.E_Mail, f.E_Mail);
        contentValues.put(m.Gender, f.Gender);
        contentValues.put(m.Group, f.Group);
        contentValues.put(m.ID_No, f.ID_No);
        contentValues.put(m.Name, f.Name);
        contentValues.put(m.Phone_No, f.Phone_No);
        contentValues.put(m.No, f.No);
        contentValues.put(m.Un_allocated_Funds, f.Un_allocated_Funds);
        contentValues.put(m.Outstanding_Balance, f.Outstanding_Balance);
        contentValues.put(m.Repayment, f.Repayment);
        contentValues.put(m.updated, f.updated);
        db.update(m.member_Table, contentValues, m.No + " =?", new String[]{f.No});
        return true;
    }

    public ArrayList<member> getupdatedmember() {
        ArrayList<member> array_list = new ArrayList<member>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + m.member_Table + " Where " + m.updated + " =1", null);
        res.moveToFirst();
        while (res.isAfterLast() == false) {
            member f = new member();
            f.No = res.getString(res.getColumnIndex(m.No));
            f.Name = res.getString(res.getColumnIndex(m.Name));
            f.E_Mail = res.getString(res.getColumnIndex(m.E_Mail));
            f.Gender = res.getInt(res.getColumnIndex(m.Gender));
            f.Group = res.getString(res.getColumnIndex(m.Group));
            f.Phone_No = res.getString(res.getColumnIndex(m.Phone_No));
            f.Un_allocated_Funds = res.getDouble(res.getColumnIndex(m.Un_allocated_Funds));
            f.Outstanding_Balance = res.getDouble(res.getColumnIndex(m.Outstanding_Balance));
            f.Repayment = res.getDouble(res.getColumnIndex(m.Repayment));
            f.ID_No = res.getString(res.getColumnIndex(m.ID_No));
            f.updated = (res.getInt(res.getColumnIndex(m.updated)) == 0 ? false : true);
            res.moveToNext();
            array_list.add(f);
        }
        res.close();
        return array_list;
    }

    public member getmember(String mm) {
        member f = null;
        SQLiteDatabase db = this.getReadableDatabase();
        //  Cursor res = db.rawQuery("select * from " + m.member_Table + " Where " + m.updated + " =1", null );
        Cursor res = db.rawQuery("select * from " + m.member_Table + " Where " + m.No + " =?", new String[]{mm + ""});
        if (res.getCount() > 0) {
            res.moveToFirst();
            f = new member();
            f.No = res.getString(res.getColumnIndex(m.No));
            f.Name = res.getString(res.getColumnIndex(m.Name));
            f.E_Mail = res.getString(res.getColumnIndex(m.E_Mail));
            f.Gender = res.getInt(res.getColumnIndex(m.Gender));
            f.Group = res.getString(res.getColumnIndex(m.Group));
            f.Phone_No = res.getString(res.getColumnIndex(m.Phone_No));
            f.Un_allocated_Funds = res.getDouble(res.getColumnIndex(m.Un_allocated_Funds));
            f.Outstanding_Balance = res.getDouble(res.getColumnIndex(m.Outstanding_Balance));
            f.Repayment = res.getDouble(res.getColumnIndex(m.Repayment));
            f.ID_No = res.getString(res.getColumnIndex(m.ID_No));
            f.updated = (res.getInt(res.getColumnIndex(m.updated)) == 0 ? false : true);
        }
        res.close();
        return f;
    }

    public ArrayList<member> getmembers() {
        ArrayList<member> ff = new ArrayList();
        SQLiteDatabase db = this.getReadableDatabase();
        //  Cursor res = db.rawQuery("select * from " + m.member_Table + " Where " + m.updated + " =1", null );
        Cursor res = db.rawQuery("select * from " + m.member_Table, null);

        res.moveToFirst();

        while (res.isAfterLast() == false) {


            member f = new member();
            f.No = res.getString(res.getColumnIndex(m.No));
            f.Name = res.getString(res.getColumnIndex(m.Name));
            f.E_Mail = res.getString(res.getColumnIndex(m.E_Mail));
            f.Gender = res.getInt(res.getColumnIndex(m.Gender));
            f.Group = res.getString(res.getColumnIndex(m.Group));
            f.Phone_No = res.getString(res.getColumnIndex(m.Phone_No));
            f.Un_allocated_Funds = res.getDouble(res.getColumnIndex(m.Un_allocated_Funds));
            f.Outstanding_Balance = res.getDouble(res.getColumnIndex(m.Outstanding_Balance));
            f.Repayment = res.getDouble(res.getColumnIndex(m.Repayment));
            f.ID_No = res.getString(res.getColumnIndex(m.ID_No));
            f.updated = (res.getInt(res.getColumnIndex(m.updated)) != 0);
            ff.add(f);
            res.moveToNext();
        }
        res.close();
        return ff;
    }

    public member getmemberbyid(String mm) {
        member f = null;
        SQLiteDatabase db = this.getReadableDatabase();
        //  Cursor res = db.rawQuery("select * from " + m.member_Table + " Where " + m.updated + " =1", null );
        Cursor res = db.rawQuery("select * from " + m.member_Table + " Where " + m.ID_No + " =?", new String[]{mm + ""});
        if (res.getCount() > 0) {
            res.moveToFirst();
            f = new member();
            f.No = res.getString(res.getColumnIndex(m.No));
            f.Name = res.getString(res.getColumnIndex(m.Name));
            f.E_Mail = res.getString(res.getColumnIndex(m.E_Mail));
            f.Gender = res.getInt(res.getColumnIndex(m.Gender));
            f.Group = res.getString(res.getColumnIndex(m.Group));
            f.Phone_No = res.getString(res.getColumnIndex(m.Phone_No));
            f.Un_allocated_Funds = res.getDouble(res.getColumnIndex(m.Un_allocated_Funds));
            f.Outstanding_Balance = res.getDouble(res.getColumnIndex(m.Outstanding_Balance));
            f.Repayment = res.getDouble(res.getColumnIndex(m.Repayment));
            f.ID_No = res.getString(res.getColumnIndex(m.ID_No));
            f.updated = (res.getInt(res.getColumnIndex(m.updated)) == 0 ? false : true);
        }
        res.close();
        return f;
    }

    public boolean insergroup(group f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(g.groupCode, f.Group_No);
        contentValues.put(g.groupName, f.Description);

        db.insertWithOnConflict(g.group_Table, null, contentValues, SQLiteDatabase.CONFLICT_REPLACE);
        return true;
    }

    public boolean updategroup(group f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(g.groupCode, f.Group_No);
        contentValues.put(g.groupName, f.Description);
        db.update(a.agent_Table, contentValues, g.groupCode + " = ? ", new String[]{f.Group_No});
        return true;
    }

    public group getgroup(String mm) {
        group f = null;
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + g.group_Table + " Where " + g.groupCode + " =?", new String[]{mm + ""});
        if (res.getCount() > 0) {
            res.moveToFirst();
            f = new group();
            f.Group_No = res.getString(res.getColumnIndex(g.groupCode));
            f.Description = res.getString(res.getColumnIndex(g.groupName));

        }
        res.close();
        return f;
    }

    public ArrayList<group> getgroups() {
        ArrayList<group> array_list = new ArrayList<group>();

        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + g.group_Table, null);
        res.moveToFirst();

        while (res.isAfterLast() == false) {
            group f = new group();
            f.Group_No = res.getString(res.getColumnIndex(g.groupCode));
            f.Description = res.getString(res.getColumnIndex(g.groupName));

            res.moveToNext();
            array_list.add(f);
        }

        res.close();
        return array_list;
    }


    public boolean inservehicles(vehicles f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        if (f.Vehicle_Number != null) {
            f.Code = f.Vehicle_Number.replace(" ", "").toUpperCase();

        }
        db.insertWithOnConflict(v.vehicles_Table, null, v.values(f), SQLiteDatabase.CONFLICT_REPLACE);

        return true;
    }

    public boolean updatevehicles(vehicles f) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.update(v.vehicles_Table, v.values(f), g.groupCode + " = ? ", new String[]{f.Code});
        return true;
    }

    public ArrayList<vehicles> getvehicles() {
        ArrayList<vehicles> array_list = new ArrayList<vehicles>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + v.vehicles_Table, null);
        res.moveToFirst();
        while (res.isAfterLast() == false) {
            if (res.getString(res.getColumnIndex(v.Code))!=null) {
                vehicles f = new vehicles();
                f.Code = res.getString(res.getColumnIndex(v.Code));
                f.Vehicle_Number = res.getString(res.getColumnIndex(v.Vehicle_Number));
                f.vehicle_type = res.getInt(res.getColumnIndex(v.vehicle_type));
                f.Start_Date = res.getString(res.getColumnIndex(v.Start_Date));
                f.Id_Number = res.getString(res.getColumnIndex(v.Id_Number));
                f.Daily_Contribution = res.getDouble(res.getColumnIndex(v.Daily_Contribution));

                array_list.add(f);
            }   res.moveToNext();
        }

        res.close();
        return array_list;
    }

    public void deletevehicles() {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(v.vehicles_Table, null, null);
    }

    public ArrayList<vehicles> getcustomervehicles(String c) {
        ArrayList<vehicles> array_list = new ArrayList<vehicles>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + v.vehicles_Table + " where " + v.Id_Number + "='" + c + "'", null);
        res.moveToFirst();
        while (res.isAfterLast() == false) {
            if (res.getString(res.getColumnIndex(v.Code))!=null){
            vehicles f = new vehicles();
            f.Code = res.getString(res.getColumnIndex(v.Code));
            f.Vehicle_Number = res.getString(res.getColumnIndex(v.Vehicle_Number));
            f.vehicle_type = res.getInt(res.getColumnIndex(v.vehicle_type));
            f.Start_Date = res.getString(res.getColumnIndex(v.Start_Date));
            f.Id_Number = res.getString(res.getColumnIndex(v.Id_Number));
            f.Daily_Contribution = res.getDouble(res.getColumnIndex(v.Daily_Contribution));

            array_list.add(f);
            } res.moveToNext();
        }

        res.close();
        return array_list;
    }

    public vehicles getvehicle(String c) {
        SQLiteDatabase db = this.getReadableDatabase();
        vehicles f = null;

        c = c.replace(" ", "").toUpperCase();
        Log.i("V", c);

        Cursor res = db.rawQuery("select * from " + v.vehicles_Table + " where " + v.Code + "= '" + c + "'", null);

        if (res.getCount() > 0) {
            res.moveToFirst();
            f = new vehicles();
            f.Code = res.getString(res.getColumnIndex(v.Code));
            f.Vehicle_Number = res.getString(res.getColumnIndex(v.Vehicle_Number));
            f.vehicle_type = res.getInt(res.getColumnIndex(v.vehicle_type));
            f.Start_Date = res.getString(res.getColumnIndex(v.Start_Date));
            f.Id_Number = res.getString(res.getColumnIndex(v.Id_Number));
            f.Daily_Contribution = res.getDouble(res.getColumnIndex(v.Daily_Contribution));
            res.close();
        }
        return f;
    }


    public boolean inserloans(loan ll) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        db.insertWithOnConflict(l.Loanstable, null, l.values(ll), SQLiteDatabase.CONFLICT_REPLACE);
        return true;
    }

    public boolean updateloans(loan f) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.update(l.Loanstable, l.values(f), l.Credit_Number + " = ? ", new String[]{f.Credit_Number});
        return true;
    }

    public ArrayList<loan> getloans() {
        ArrayList<loan> array_list = new ArrayList<loan>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + l.Loanstable, null);
        res.moveToFirst();
        while (res.isAfterLast() == false) {
            loan f = new loan();
            f.Credit_Number = res.getString(res.getColumnIndex(l.Credit_Number));
            f.Client_Code = res.getString(res.getColumnIndex(l.Client_Code));
            f.Client_Name = res.getString(res.getColumnIndex(l.Client_Name));
            f.Client_ID_Number = res.getString(res.getColumnIndex(l.Client_ID_Number));
            f.Loan = res.getString(res.getColumnIndex(f.Loan));
            res.moveToNext();
            array_list.add(f);
        }

        res.close();
        return array_list;
    }

    public Integer deleteloans() {
        SQLiteDatabase db = this.getWritableDatabase();
        return db.delete(l.Loanstable, null, null);
    }

    public ArrayList<loan> getcustomerloans(String c) {
        ArrayList<loan> array_list = new ArrayList<loan>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + l.Loanstable + " where " + l.Client_Code + "='" + c + "'", null);
        res.moveToFirst();
        while (res.isAfterLast() == false) {
            loan f = new loan();
            f.Credit_Number = res.getString(res.getColumnIndex(l.Credit_Number));
            f.Client_Code = res.getString(res.getColumnIndex(l.Client_Code));
            f.Client_Name = res.getString(res.getColumnIndex(l.Client_Name));
            f.Client_ID_Number = res.getString(res.getColumnIndex(l.Client_ID_Number));
            f.Loan = res.getString(res.getColumnIndex(l.Loan));
            res.moveToNext();
            array_list.add(f);
        }
        res.close();
        return array_list;
    }

    public boolean inserttype(types f) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.insertWithOnConflict(tt.Types_Table, null, tt.values(f), SQLiteDatabase.CONFLICT_REPLACE);

        return true;
    }

    public boolean updatetypes(types f) {
        SQLiteDatabase db = this.getWritableDatabase();

        db.update(tt.Types_Table, tt.values(f), g.groupCode + " = ? ", new String[]{f.Code});
        return true;
    }

    public ArrayList<types> gettypes() {
        ArrayList<types> array_list = new ArrayList<types>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + tt.Types_Table + " where Code <>'' order by lOrder", null);
        Log.i("typerows", String.valueOf(res.getCount()));
        res.moveToFirst();
        while (res.isAfterLast() == false) {
            types f = new types();
            f.Code = res.getString(res.getColumnIndex(tt.Code));
            f.Name = res.getString(res.getColumnIndex(tt.Name));
            f.Active = (res.getInt(res.getColumnIndex(tt.Active)) == 0 ? false : true);
            f.Attach_to_vehicle = (res.getInt(res.getColumnIndex(tt.Attach_to_vehicle)) == 0 ? false : true);
            f.Order = res.getInt(res.getColumnIndex(tt.Order)) ;
            res.moveToNext();

            array_list.add(f);
        }
        Log.i("type", String.valueOf(array_list.size()));
        res.close();
        return array_list;
    }

    public types gettype(String Code) {

        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + tt.Types_Table + " where " + tt.Code + " = '" + Code + "'", null);
        types f=null;
        if(res.getCount()>0){
            res.moveToFirst();
            f = new types();
        f.Code = res.getString(res.getColumnIndex(tt.Code));
        f.Name = res.getString(res.getColumnIndex(tt.Name));
        f.Active = (res.getInt(res.getColumnIndex(tt.Active)) == 0 ? false : true);
        f.Attach_to_vehicle = (res.getInt(res.getColumnIndex(tt.Attach_to_vehicle)) == 0 ? false : true);
        f.Order = res.getInt(res.getColumnIndex(tt.Order)) ;
        res.close();}
        return f;
    }

    public Integer deleteAlltypes() {
        SQLiteDatabase db = this.getWritableDatabase();
        return db.delete(tt.Types_Table, null, null);
    }
}

