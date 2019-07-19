package com.example.paul.agency;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteQuery;
import android.util.Log;
import java.util.ArrayList;
import java.util.List;

public class Societies
{
  static final String Table = "Societies";
  static final String colcode = "Code";
  static final String colname = "Name";
  public String code;
  public String memberid = null;
  public String name;
  
  public static Societies AddSociety(Database paramDatabase, Societies paramSocieties)
  {
    SQLiteDatabase db = paramDatabase.getWritableDatabase();

    ContentValues localContentValues = new ContentValues();
    localContentValues.put("Code", paramSocieties.code);
    localContentValues.put("Name", paramSocieties.name);
    db.insertWithOnConflict("Societies", "Code", localContentValues, 5);
    db.close();
    return paramSocieties;
  }
  
  public static List<Societies> getSocieties(Database paramDatabase)
  {
    ArrayList localArrayList = new ArrayList();
    try
    {
     Cursor c= paramDatabase.getWritableDatabase().query("Societies", new String[] { "*" }, null, null, null, null, null);

      c.moveToFirst();
      boolean bool;
      do
      {
        Societies localSocieties = new Societies();
        localSocieties.code = c.getString(c.getColumnIndex("Code"));
        localSocieties.name = c.getString(c.getColumnIndex("Name"));
        localArrayList.add(localSocieties);
        bool = c.moveToNext();
      } while (bool);
    }
    catch (Exception c)
    {
      for (;;)
      {
        c.printStackTrace();
        if (c.getMessage() == null) {
          c.printStackTrace();
        } else {
          Log.i(c.getMessage(), c.getMessage());
        }
      }
    }
    return localArrayList;
  }
  
  public String toString()
  {
    return this.name;
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\Societies.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */