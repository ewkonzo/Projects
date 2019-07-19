package com.kta.dev.surestep;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

/**
 * Created by G on 4/19/2016.
 */
public class DBHelper extends SQLiteOpenHelper {

    private static final int DATABASE_VERSION = 1;
    private static final String DATABASE_NAME = "contactsDB.db";
    private static final String TABLE_CONTACTS_TABLE = "contacts";

    public static final String COLUMN_ID = "_id";
    public static final String COLUMN_CONTACT_NAME = "contact_name";
    public static final String COLUMN_NATIONAL_ID= "national_id";
    public static final String COLUMN_PHONE_NUMBER= "phone_number";

    public DBHelper(Context context, String name,
                       SQLiteDatabase.CursorFactory factory, int version) {
        super(context, DATABASE_NAME, factory, DATABASE_VERSION);
    }
    @Override
    public void onCreate(SQLiteDatabase db) {
        String CREATE_P = "CREATE TABLE " +
                TABLE_CONTACTS_TABLE + "("
                + COLUMN_ID + " INTEGER PRIMARY KEY," + COLUMN_CONTACT_NAME
                + " TEXT KEY," + COLUMN_NATIONAL_ID + " INTEGER," + COLUMN_PHONE_NUMBER +"INTEGER" + ")";
        db.execSQL(TABLE_CONTACTS_TABLE);

    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_CONTACTS_TABLE);
        onCreate(db);

    }
//add contact
    public void addcontact(Contact contact) {

        ContentValues values = new ContentValues();
        values.put(COLUMN_CONTACT_NAME, contact.getName());
        values.put(COLUMN_NATIONAL_ID, contact.getNationalId());
        values.put(COLUMN_PHONE_NUMBER, contact.getTelephoneNumber());

        SQLiteDatabase db = this.getWritableDatabase();

        db.insert(TABLE_CONTACTS_TABLE, null, values);
        db.close();

    }
//find one contact
  public Contact findProduct(String contactName) {
        String query = "Select * FROM " + TABLE_CONTACTS_TABLE + " WHERE " + COLUMN_CONTACT_NAME + " =  \"" + contactName + "\"";

        SQLiteDatabase db = this.getWritableDatabase();

        Cursor cursor = db.rawQuery(query, null);

        Contact contact = new Contact();

        if (cursor.moveToFirst()) {
            cursor.moveToFirst();
            contact.setName(cursor.getString(0));
            contact.setNationalId(cursor.getString(1));
            contact.setTelephoneNumber(cursor.getString(2));
            cursor.close();
        } else {
            contact = null;
        }
        db.close();
        return contact;
    }
}
