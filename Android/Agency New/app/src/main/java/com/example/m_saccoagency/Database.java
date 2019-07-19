package com.example.m_saccoagency;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class Database extends SQLiteOpenHelper {

	static final String dbName = "Agency";
	  
	  public Database(Context paramContext)
	  {
	    super(paramContext, "Agency", null, 1);
	  }
	  
	  public void onCreate(SQLiteDatabase paramSQLiteDatabase)
	  {
	    paramSQLiteDatabase.execSQL("CREATE TABLE Transactions (Id INTEGER PRIMARY KEY AUTOINCREMENT,Entry Text,Account_1 Text,Account_2 Text,member_1 Text,member_2 Text,Loan_No Text,Code Text,Amount decimaltransactiontype Text,agent Text,Telephone Text,Depositor Text,Maximun decimal,Minimun decimal,status Text )");
	    paramSQLiteDatabase.execSQL("CREATE TABLE Societies (id INTEGER PRIMARY KEY AUTOINCREMENT,Code Text,Name Text )");
	  }
	  
	  public void onUpgrade(SQLiteDatabase paramSQLiteDatabase, int paramInt1, int paramInt2)
	  {
	    paramSQLiteDatabase.execSQL("DROP TABLE IF EXISTS Transactions");
	    paramSQLiteDatabase.execSQL("DROP TABLE IF EXISTS Societies");
	    onCreate(paramSQLiteDatabase);
	  }
	  
	 
}
