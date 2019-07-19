package elegance.hasoft.com.elegance;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

/**
 GeekBoy did this
 */
public class DatabaseCreator extends SQLiteOpenHelper {
    private static final int DATABASE_VERSION = 1;
    private static final String DATABASE_NAME = "ADAN";
    Context context;

   //store
    public final String COLUMN_ID = "id";


    public final String CREATE_TABLE_NOTES="CREATE TABLE notes (noteid TEXT,title TEXT,des TEXT,time TEXT,status TEXT,user TEXT)";
    public final String CREATE_TABLE_CONSTANTS="CREATE TABLE constants (title TEXT,type TEXT,name TEXT)";
    public final String CREATE_TABLE_CART="CREATE TABLE cart (itemcat TEXT,brand TEXT,color TEXT,size TEXT,pattern TEXT,consumergroup TEXT,gendergroup TEXT,fabric TEXT,inventory_id TEXT,item_code TEXT,item_name TEXT,quantity TEXT,unit_price TEXT,discount TEXT,selling_price TEXT,total TEXT)";
    public final String CREATE_TABLE_PUR_CART="CREATE TABLE purchase (vendor TEXT,id TEXT,itemcat TEXT,brand TEXT,color TEXT,size TEXT,pattern TEXT,gendergroup TEXT,fabric TEXT,item_name TEXT,quantity TEXT,unit_price TEXT,discount TEXT,total TEXT)";
   // public final String CREATE_TABLE_WISHLIST="CREATE TABLE wishlist (vendor TEXT,id TEXT,itemcat TEXT,brand TEXT,color TEXT,size TEXT,pattern TEXT,gendergroup TEXT,fabric TEXT,item_name TEXT,quantity TEXT,unit_price TEXT,discount TEXT,total TEXT)";





    public DatabaseCreator(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
        this.context = context;
    }

    
    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(CREATE_TABLE_CART);
        db.execSQL(CREATE_TABLE_CONSTANTS);
        db.execSQL(CREATE_TABLE_NOTES);
        db.execSQL(CREATE_TABLE_PUR_CART);
       // db.execSQL(CREATE_TABLE_WISHLIST);
        Log.d("TABLE","craete table");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS contants");
        db.execSQL(CREATE_TABLE_CONSTANTS);
        db.execSQL("DROP TABLE IF EXISTS cart");
        db.execSQL(CREATE_TABLE_CART);
        db.execSQL("DROP TABLE IF EXISTS notes");
        db.execSQL(CREATE_TABLE_NOTES);
        db.execSQL("DROP TABLE IF EXISTS purchase");
        db.execSQL(CREATE_TABLE_PUR_CART);
        //db.execSQL("DROP TABLE IF EXISTS wishlist");
       // db.execSQL(CREATE_TABLE_WISHLIST);
        Log.d("onup", "look");
    }
}
