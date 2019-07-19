package com.example.paul.barcode;

import java.security.PublicKey;
import java.sql.Date;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;
import android.database.sqlite.SQLiteDatabase;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;

import android.support.annotation.NonNull;

/**
 * Created by Paul on 6/30/2015.
 */
public class Products {
    public int id;
    public String ProductCode;
    public String ProductName;
    public String size;
    public String Manufacturer;
    public String source;
    public String ManufactureDateTime;
    public String ExpiryDateTime;

    public static String Table = "Products";

    public static String colid = "_id";
    public static String colProductCode = "colProductCode";
    public static String colProductName = "colProductName";
    public static String colsize = "colsize";
    public static String colManufacturer = "colManufacturer";
    public static String colsource = "colsource";
    public static String colManufactureDateTime = "colManufactureDateTime";
    public static String colExpiryDateTime = "colExpiryDateTime";

    public static Products Addproducts(Database db, Products p) {
        try {
            SQLiteDatabase dbb = db.getWritableDatabase();
            ContentValues localContentValues = new ContentValues();
            localContentValues.put(colProductCode, p.ProductCode);
            localContentValues.put(colProductName, p.ProductName);
            localContentValues.put(colsize, p.size);
            localContentValues.put(colsource, p.source);
            localContentValues.put(colManufactureDateTime, p.ManufactureDateTime);
            //localContentValues.put(colManufactureDateTime, p.ManufactureDateTime.getTime());
            localContentValues.put(colExpiryDateTime, p.ExpiryDateTime);
            dbb.insertWithOnConflict(Table, colProductCode, localContentValues, 5);
            db.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return p;
    }

    public static Cursor allProducts(Database db) {
        return db.getReadableDatabase().query(Table, new String[]{"*"}, null, null, null, null, null);
    }

    public static Cursor getProduct(Database db, int id) {
        String query = "Select * from "+ Products.Table + " where "+ Products.colid +  " = " + id ;
        return db.getWritableDatabase().rawQuery(query, null);
    }
    public static Products getProductobject(Database db, int id) {
       Products p= new Products();
        String query = "Select * from "+ Products.Table + " where "+ Products.colid +  " = " + id ;
         Cursor c = db.getWritableDatabase().rawQuery(query, null);
        c.moveToFirst();
        p.ProductCode= c.getString(c.getColumnIndex(colProductCode));
        p.ProductName= c.getString(c.getColumnIndex(colProductName));
        p.size = c.getString(c.getColumnIndex(colsize));
        p.source=c.getString(c.getColumnIndex(colsource));
        p.Manufacturer=c.getString(c.getColumnIndex(colManufacturer));
        p.ManufactureDateTime=c.getString(c.getColumnIndex(colManufactureDateTime));
        p.ExpiryDateTime=c.getString(c.getColumnIndex(colExpiryDateTime));

        return p;
    }
    public static Cursor getProductbycode(Database db, String id) {
        String query = "Select * from "+ Products.Table + " where "+ Products.colProductCode +  " = '" + id +"'" ;
        return db.getWritableDatabase().rawQuery(query,null);

    } public static Cursor getProductbyname(Database db, String id) {
        String query = "Select * from "+ Products.Table + " where "+ Products.colProductName +  " = '" + id +"'" ;
        return db.getWritableDatabase().rawQuery(query,null);

    }
}


