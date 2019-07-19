package com.example.paul.datacollector;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.DatabaseUtils;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.support.v4.database.DatabaseUtilsCompat;
import android.text.TextUtils;
import android.util.Log;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;

public class DB extends SQLiteOpenHelper {

    public static final String DATABASE_NAME = "MyDBName.db";

    public static final String FARMERS_TABLE_NAME = "Farmer";
    public static final String tmpFARMERS_TABLE_NAME = "tmpFarmer";
    public static final String No = "No";
    public static final String Name = "Name";
    public static final String Phone_No = "Phone_No";
    public static final String Creditor_Type = "Creditor_Type";
    public static final String routes = "routes";
    public static final String Cummulative = "Cummulative";
    public static final String Transpoter = "Transpoter";
    public static final String Cummulative_Collected = "Cummulative_Collected";

    public static final String ROUTE_TABLE_NAME = "Routes";
    public static final String tmpROUTE_TABLE_NAME = "tmpRoutes";
    public static final String Code = "Code";
    public static final String Description = "Description";

    public static final String Collection_TABLE_NAME = "Collection";
    public static final String tmpCollection_TABLE_NAME = "tmpCollection";

    public static final String Farmers_Number = "Farmers_Number";
    public static final String Farmers_Name = "Farmers_Name";
    public static final String Collection_Number = "Collection_Number";
    public static final String Kg_Collected= "Kg_Collected";
    public static final String Transporter = "Transporter";
    public static final String Cumm = "Cumm";
    public static final String kgcollected = "kgcollected";
    public static final String Factory = "Factory";
    public static final String sent = "Sent";
    public static final String Collections_Date = "Collections_Date";
    public static final String Can = "Can";
    public static final String Collection_time = "Collection_time";
    public static final String status="status";


    private HashMap hp;

    public DB(Context context) {
        super(context, DATABASE_NAME, null, 22);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        // TODO Auto-generated method stub
        db.execSQL(
                "create table " + FARMERS_TABLE_NAME + "" +
                        "(" + No + " text primary key," +
                        Name + " text," +
                        Phone_No + " text," +
                        Creditor_Type + " Integer," +
                        Cummulative + " float," +
                        Transpoter + " text," +
                        Cummulative_Collected + " float," +
                        routes + " text )"
        );

        db.execSQL(
                "create table " + ROUTE_TABLE_NAME + "" +
                        "(" + Code + " text primary key," +
                        Description + " text)"
        );

        db.execSQL(
                "create table " + Collection_TABLE_NAME + "" +
                        "(" + Collection_Number + " text primary key," +
                        Farmers_Number + " text," +
                        Farmers_Name + " text," +
                        Kg_Collected + " float," +
                        Cumm + " float," +
                        kgcollected + " float," +
                        Factory + " text," +
                        Transporter + " text," +
                        Collections_Date + " text," +
                        Collection_time + " text," +
                        Can + " text," +
                        status + " text," +
                        sent + " Bool)"
        );
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // TODO Auto-generated method stub
       try{
           Log.i("Db","Updating db");


        Cursor res = db.query(FARMERS_TABLE_NAME, null, null, null, null, null, null);
        String[] cols = res.getColumnNames();
        List<String> fcols = new ArrayList<String>(Arrays.asList(cols));

        res = db.query(ROUTE_TABLE_NAME, null, null, null, null, null, null);
         cols = res.getColumnNames();
        List<String> rcols = new ArrayList<String>(Arrays.asList(cols));

        res = db.query(Collection_TABLE_NAME, null, null, null, null, null, null);
        cols = res.getColumnNames();
        List<String> ccols = new ArrayList<String>(Arrays.asList(cols));

           db.execSQL("Drop table if exists "+ tmpFARMERS_TABLE_NAME);
           db.execSQL("Drop table if exists "+ tmpROUTE_TABLE_NAME);
           db.execSQL("Drop table if exists "+ tmpCollection_TABLE_NAME);
        db.execSQL("ALTER table " + FARMERS_TABLE_NAME + " RENAME TO '"+ tmpFARMERS_TABLE_NAME +"'");
        db.execSQL("ALTER table " + ROUTE_TABLE_NAME + " RENAME TO '" + tmpROUTE_TABLE_NAME +"'");
        db.execSQL("ALTER table " + Collection_TABLE_NAME + " RENAME TO '"  + tmpCollection_TABLE_NAME +"'");

        onCreate(db);

        String fcol = TextUtils.join(",",fcols);
        String rcol = TextUtils.join(",",rcols);
        String ccol = TextUtils.join(",",ccols);

        db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s",FARMERS_TABLE_NAME, fcol, fcol, tmpFARMERS_TABLE_NAME));
        db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s",ROUTE_TABLE_NAME, rcol, rcol, tmpROUTE_TABLE_NAME));
        db.execSQL(String.format("INSERT INTO %s (%s) SELECT %s from %s",Collection_TABLE_NAME, ccol, ccol, tmpCollection_TABLE_NAME));

        db.execSQL(" DROP table '" + tmpFARMERS_TABLE_NAME +"'");
        db.execSQL(" DROP table '" + tmpROUTE_TABLE_NAME +"'");
        db.execSQL(" DROP table '" + tmpCollection_TABLE_NAME +"'");
           Log.i("Db update","Database updated");
    }
    catch (Exception ex){
                ex.printStackTrace();
    throw ex ;
    }

    }

    public boolean insertfarmer(Farmer f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(No, f.No);
        contentValues.put(Name, f.Name);
        contentValues.put(Phone_No, f.Phone_No);
        contentValues.put(Creditor_Type, f.Creditor_Type);
        contentValues.put(routes, f.routes);
        contentValues.put(Cummulative, f.Cummulative);
        contentValues.put(Transpoter, f.Transpoter);

        contentValues.put(Cummulative_Collected, f.Cummulative_Collected);

        db.insertWithOnConflict(FARMERS_TABLE_NAME, null, contentValues, SQLiteDatabase.CONFLICT_REPLACE);
        return true;
    }

    public int Totalfarmers() {
        SQLiteDatabase db = this.getReadableDatabase();
        int numRows = (int) DatabaseUtils.queryNumEntries(db, FARMERS_TABLE_NAME);
        return numRows;
    }

    public boolean updateFarmer(Farmer f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(No, f.No);
        contentValues.put(Name, f.Name);
        contentValues.put(Phone_No, f.Phone_No);
        contentValues.put(Creditor_Type, f.Creditor_Type);
        contentValues.put(routes, f.routes);
        contentValues.put(Cummulative, f.Cummulative);
        contentValues.put(Transpoter, f.Transpoter);
        contentValues.put(Cummulative_Collected, f.Cummulative_Collected);
        db.update(FARMERS_TABLE_NAME, contentValues, No + " = ? ", new String[]{f.No});
        return true;
    }

    public Integer deleteFarmer(Farmer f) {
        SQLiteDatabase db = this.getWritableDatabase();
        return db.delete(FARMERS_TABLE_NAME,
                No + " = ? ",
                new String[]{f.No});
    }

    public Integer deleteFarmers() {
        SQLiteDatabase db = this.getWritableDatabase();
        return db.delete(FARMERS_TABLE_NAME,
                null, null);
    }

    public Farmer getFarmer(String no) {
        Farmer f = null;
        //hp = new HashMap();
        SQLiteDatabase db = this.getReadableDatabase();
        Log.i("farmer", no);
        Cursor res = db.rawQuery("select * from " + FARMERS_TABLE_NAME + " Where " + No + " =?", new String[]{no + ""});

        if (res.getCount() > 0) {
            res.moveToFirst();

            f = new Farmer();
            f.No = res.getString(res.getColumnIndex(No));
            f.Name = res.getString(res.getColumnIndex(Name));
            f.Phone_No = res.getString(res.getColumnIndex(Phone_No));
            f.Creditor_Type = res.getInt(res.getColumnIndex(Creditor_Type));
            f.Cummulative = res.getFloat(res.getColumnIndex(Cummulative));
            f.Cummulative_Collected = res.getFloat(res.getColumnIndex(Cummulative_Collected));
            //f.routes = getAllRoutes(). res.getString(res.getColumnIndex(routes));
        }


        res.close();
        return f;
    }

    public ArrayList<Farmer> getAllFarmers() {
        ArrayList<Farmer> array_list = new ArrayList<Farmer>();
        //hp = new HashMap();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + FARMERS_TABLE_NAME, null);
        res.moveToFirst();

        while (res.isAfterLast() == false) {
            Farmer f = new Farmer();
            f.No = res.getString(res.getColumnIndex(No));
            f.Name = res.getString(res.getColumnIndex(Name));
            f.Phone_No = res.getString(res.getColumnIndex(Phone_No));
            f.Creditor_Type = res.getInt(res.getColumnIndex(Creditor_Type));
            f.Cummulative = res.getFloat(res.getColumnIndex(Cummulative));
            f.Cummulative_Collected = res.getFloat(res.getColumnIndex(Cummulative_Collected));
            //f.routes = getAllRoutes(). res.getString(res.getColumnIndex(routes));
            array_list.add(f);
            res.moveToNext();
        }
        res.close();
        return array_list;
    }

    public boolean insertRoute(Routes f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(Code, f.Code);
        contentValues.put(Description, f.Description);
        db.insertWithOnConflict(ROUTE_TABLE_NAME, null, contentValues, SQLiteDatabase.CONFLICT_REPLACE);
        return true;
    }

    public int TotalRoute() {
        SQLiteDatabase db = this.getReadableDatabase();
        int numRows = (int) DatabaseUtils.queryNumEntries(db, ROUTE_TABLE_NAME);
        return numRows;
    }

    public boolean updateRoute(Routes f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(Code, f.Code);
        contentValues.put(Description, f.Description);
        db.update(ROUTE_TABLE_NAME, contentValues, No + " = ? ", new String[]{f.Code});
        return true;
    }

    public Integer deleteRoute(Routes f) {
        SQLiteDatabase db = this.getWritableDatabase();
        return db.delete(ROUTE_TABLE_NAME,
                Code + " = ? ",
                new String[]{f.Code});
    }

    public Integer deleteAllRoute() {
        SQLiteDatabase db = this.getWritableDatabase();
        return db.delete(ROUTE_TABLE_NAME, null, null);
    }

    public ArrayList<Routes> getAllRoutes() {
        ArrayList<Routes> array_list = new ArrayList<Routes>();
        //hp = new HashMap();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + ROUTE_TABLE_NAME, null);
        res.moveToFirst();

        while (res.isAfterLast() == false) {
            Routes f = new Routes();
            f.Code = res.getString(res.getColumnIndex(Code));
            f.Description = res.getString(res.getColumnIndex(Description));
            array_list.add(f);
            res.moveToNext();
        }
        res.close();
        return array_list;
    }
    public Long insertCollection(Collection f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(Factory, f.Factory);
        contentValues.put(Farmers_Name, f.Farmers_Name);
        contentValues.put(Farmers_Number, f.Farmers_Number);
        contentValues.put(Transporter, f.Transporter);
        contentValues.put(Collection_Number, f.Collection_Number);
        contentValues.put(Kg_Collected, f.Kg_Collected);
        contentValues.put(kgcollected, f.kgcollected);
        contentValues.put(Cumm, f.Cumm);
        contentValues.put(sent, f.sent);
        contentValues.put(Can, f.Can);
        contentValues.put(Collections_Date, f.Date);
        contentValues.put(Collection_time, f.Time);
        contentValues.put(status, f.status);
        long dd=   db.insertWithOnConflict(Collection_TABLE_NAME, null, contentValues, SQLiteDatabase.CONFLICT_REPLACE);

        return dd;
    }

    public int TotalCollection() {
        SQLiteDatabase db = this.getReadableDatabase();
        int numRows = (int) DatabaseUtils.queryNumEntries(db, Collection_TABLE_NAME);
        return numRows;
    }
    public boolean updateCollection(Collection f) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(Factory, f.Factory);
        contentValues.put(Farmers_Name, f.Farmers_Name);
        contentValues.put(Farmers_Number, f.Farmers_Number);
        contentValues.put(Transporter, f.Transporter);
        contentValues.put(Collection_Number, f.Collection_Number);
        contentValues.put(Kg_Collected, f.Kg_Collected);
        contentValues.put(kgcollected, f.kgcollected);
        contentValues.put(Cumm, f.Cumm);
        contentValues.put(sent, f.sent);
        contentValues.put(Collections_Date, f.Date);
        contentValues.put(Collection_time, f.Time);
        contentValues.put(status, f.status);
      db.update(Collection_TABLE_NAME, contentValues, Collection_Number + " = ? ", new String[]{f.Collection_Number});
        return true;
    }
    public Integer deleteCollection(Collection f) {
        SQLiteDatabase db = this.getWritableDatabase();
        return db.delete(Collection_TABLE_NAME,
                Collection_Number + " = ? ",
                new String[]{f.Collection_Number});
    }
    public ArrayList<Collection> getAllCollection() {
        ArrayList<Collection> array_list = new ArrayList<Collection>();
        //hp = new HashMap();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + Collection_TABLE_NAME, null);
        res.moveToFirst();

        while (res.isAfterLast() == false) {
            Collection f = new Collection();
            f.Collection_Number = res.getString(res.getColumnIndex(Collection_Number));
            f.Factory = res.getString(res.getColumnIndex(Factory));
            f.Farmers_Name = res.getString(res.getColumnIndex(Farmers_Name));
            f.Farmers_Number = res.getString(res.getColumnIndex(Farmers_Number));
            f.Transporter = res.getString(res.getColumnIndex(Transporter));
            f.kgcollected = res.getDouble(res.getColumnIndex(kgcollected));
            f.Kg_Collected = res.getDouble(res.getColumnIndex(Kg_Collected));
            f.Cumm = res.getDouble(res.getColumnIndex(Cumm));
            f.sent = Boolean.valueOf(res.getString(res.getColumnIndex(sent)));
            f.Date = (res.getString(res.getColumnIndex(Collections_Date)));
            f.Time = (res.getString(res.getColumnIndex(Collection_time)));
            f.status = (res.getString(res.getColumnIndex(status)));
            array_list.add(f);
            res.moveToNext();
        }
        res.close();
        return array_list;
    }
    public ArrayList<Collection> getpendingCollection() {
        ArrayList<Collection> array_list = new ArrayList<Collection>();
        //hp = new HashMap();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + Collection_TABLE_NAME + " where sent = 0", null);
        res.moveToFirst();

        while (res.isAfterLast() == false) {
            Collection f = new Collection();
            f.Collection_Number = res.getString(res.getColumnIndex(Collection_Number));
            f.Factory = res.getString(res.getColumnIndex(Factory));
            f.Farmers_Name = res.getString(res.getColumnIndex(Farmers_Name));
            f.Farmers_Number = res.getString(res.getColumnIndex(Farmers_Number));
            f.Transporter = res.getString(res.getColumnIndex(Transporter));
            f.kgcollected = res.getDouble(res.getColumnIndex(kgcollected));
            f.Kg_Collected = res.getDouble(res.getColumnIndex(Kg_Collected));
            f.Cumm = res.getDouble(res.getColumnIndex(Cumm));
            f.sent = Boolean.valueOf(res.getString(res.getColumnIndex(sent)));
            f.Date = res.getString(res.getColumnIndex(Collections_Date));
            f.Time = res.getString(res.getColumnIndex(Collection_time));
            f.status = res.getString(res.getColumnIndex(status));
            array_list.add(f);
            res.moveToNext();
        }
        res.close();
        return array_list;
    }
    public ArrayList<Summaries.Bydate> getdates() {
        ArrayList<Summaries.Bydate> array_list = new ArrayList<Summaries.Bydate>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.query (true,Collection_TABLE_NAME,new String[] {Collections_Date},null,null,null,null,Collection_Number + " DESC",null);
        res.moveToFirst();

        while (res.isAfterLast() == false) {
            Summaries.Bydate f = new Summaries.Bydate();
            f.Date =  res.getString(res.getColumnIndex(Collections_Date));

            array_list.add(f);
            res.moveToNext();
        }
        res.close();
        return array_list;
    }
    public ArrayList<Collection> getbydates(String date) {
        ArrayList<Collection> array_list = new ArrayList<Collection>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + Collection_TABLE_NAME + " where Collections_Date = '"+ date+"'" , null);

        for (String s:res.getColumnNames()
             ) {
            Log.i("column",s);
        }
        res.moveToFirst();
        while (res.isAfterLast() == false) {
            Collection f = new Collection();
            f.Collection_Number = res.getString(res.getColumnIndex(Collection_Number));
            f.Factory = res.getString(res.getColumnIndex(Factory));
            f.Farmers_Name = res.getString(res.getColumnIndex(Farmers_Name));
            f.Farmers_Number = res.getString(res.getColumnIndex(Farmers_Number));
            f.Transporter = res.getString(res.getColumnIndex(Transporter));
            f.kgcollected = res.getDouble(res.getColumnIndex(kgcollected));
            f.Kg_Collected = res.getDouble(res.getColumnIndex(Kg_Collected));
            f.Cumm = res.getDouble(res.getColumnIndex(Cumm));
            f.sent = Boolean.valueOf(res.getString(res.getColumnIndex(sent)));
            f.Date = res.getString(res.getColumnIndex(Collections_Date));
            f.Time = res.getString(res.getColumnIndex(Collection_time));
            f.status = res.getString(res.getColumnIndex(status));
            array_list.add(f);
            res.moveToNext();
        }
        res.close();
        return array_list;
    }

    public ArrayList<Collection> getcustomercollection(String cust) {
        ArrayList<Collection> array_list = new ArrayList<Collection>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res = db.rawQuery("select * from " + Collection_TABLE_NAME + " where Farmers_Number = '"+ cust+"'" , null);
        res.moveToFirst();
        while (res.isAfterLast() == false) {
            Collection f = new Collection();
            f.Collection_Number = res.getString(res.getColumnIndex(Collection_Number));
            f.Factory = res.getString(res.getColumnIndex(Factory));
            f.Farmers_Name = res.getString(res.getColumnIndex(Farmers_Name));
            f.Farmers_Number = res.getString(res.getColumnIndex(Farmers_Number));
            f.Transporter = res.getString(res.getColumnIndex(Transporter));
            f.kgcollected = res.getDouble(res.getColumnIndex(kgcollected));
            f.Kg_Collected = res.getDouble(res.getColumnIndex(Kg_Collected));
            f.Cumm = res.getDouble(res.getColumnIndex(Cumm));
            f.sent = Boolean.valueOf(res.getString(res.getColumnIndex(sent)));
            f.Date = res.getString(res.getColumnIndex(Collections_Date));
            f.Time = res.getString(res.getColumnIndex(Collection_time));
            f.status = res.getString(res.getColumnIndex(status));
            array_list.add(f);
            res.moveToNext();
        }
        res.close();
        return array_list;
    }
}

