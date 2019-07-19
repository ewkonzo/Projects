package com.example.paul.barcode;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class Database extends SQLiteOpenHelper {

    // Database Version
    private static final int DATABASE_VERSION = 5;
    // Database Name
    private static final String DATABASE_NAME = "Products";

    public Database(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        // SQL statement to create book table
        String CREATE_BOOK_TABLE = "CREATE TABLE "+Products.Table +"( " +
                Products.colid + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                Products.colProductName + " TEXT, "+
                Products.colProductCode + " TEXT, "+
                Products.colsize + " TEXT, "+
                Products.colsource + " TEXT, "+
                Products.colManufacturer + " TEXT, "+
                Products.colExpiryDateTime+ " TEXT, "+
                Products.colManufactureDateTime + " TEXT )";


        // create books table
        db.execSQL(CREATE_BOOK_TABLE);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // Drop older books table if existed
        db.execSQL("DROP TABLE IF EXISTS "+Products.Table +"");

        // create fresh books table
        this.onCreate(db);
    }

}
