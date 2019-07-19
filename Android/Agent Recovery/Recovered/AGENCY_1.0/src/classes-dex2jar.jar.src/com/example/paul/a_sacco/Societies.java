package com.example.paul.a_sacco;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
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
    paramDatabase = paramDatabase.getWritableDatabase();
    ContentValues localContentValues = new ContentValues();
    localContentValues.put("Code", paramSocieties.code);
    localContentValues.put("Name", paramSocieties.name);
    paramDatabase.insertWithOnConflict("Societies", "Code", localContentValues, 5);
    paramDatabase.close();
    return paramSocieties;
  }
  
  public static List<Societies> getSocieties(Database paramDatabase)
  {
    ArrayList localArrayList = new ArrayList();
    try
    {
      paramDatabase = paramDatabase.getWritableDatabase().query("Societies", new String[] { "*" }, null, null, null, null, null);
      paramDatabase.moveToFirst();
      boolean bool;
      do
      {
        Societies localSocieties = new Societies();
        localSocieties.code = paramDatabase.getString(paramDatabase.getColumnIndex("Code"));
        localSocieties.name = paramDatabase.getString(paramDatabase.getColumnIndex("Name"));
        localArrayList.add(localSocieties);
        bool = paramDatabase.moveToNext();
      } while (bool);
    }
    catch (Exception paramDatabase)
    {
      for (;;)
      {
        paramDatabase.printStackTrace();
        if (paramDatabase.getMessage() == null) {
          paramDatabase.printStackTrace();
        } else {
          Log.i(paramDatabase.getMessage(), paramDatabase.getMessage());
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