package elegance.hasoft.com.elegance;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteDatabaseLockedException;
import android.util.Log;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * GeekBoy did this
 */
public class DataManager {
    DatabaseCreator dbaseHelper;
    private SQLiteDatabase currDbase;
    Context context;
    int request;
    Cursor cursor;
    int direction;
    String strSender,strReceiver,strMessage,strId,strMedia,strTime;


    public DataManager(Context context, int request) {
        this.context = context;
        this.request = request;
        dbaseHelper = new DatabaseCreator(context);


        switch (request){
            case 0:
                currDbase = dbaseHelper.getReadableDatabase();
                Log.d("my code>>", " a readonly database has been picked! Catn write into this database.");
                break;
            case 1:
                try {
                    currDbase = dbaseHelper.getWritableDatabase();
                }catch(SQLiteDatabaseLockedException e){
                    Log.d("fhbdhfd",e.getMessage());
                    Toast.makeText(context,e.getMessage(),Toast.LENGTH_LONG).show();
                }
                Log.d("my code>>", " a write only database has been picked! Cant read this database.");
                break;

        }

    }

    public void removeItem(String inventoryid){
        currDbase.delete("cart", "item_code='"+inventoryid+"'", null);
    }

    public void removePurchaseItem(String inventoryid){
        currDbase.delete("purchase", "id='"+inventoryid+"'", null);
    }




    public void removeNote(String noteid){
        currDbase.delete("notes", "noteid='"+noteid+"'", null);
    }

    public void clearCart(){
        currDbase.delete("cart", "item_name!=''", null);
    }

    public void clearPurchaseCart(){
        currDbase.delete("purchase", "item_name!=''", null);
    }


    public void clearConstants(){
        currDbase.delete("constants", "name!=''", null);
    }
  
    public void updateCart(String invenid,String quantity){
        ContentValues values = new ContentValues();
        values.put("quantity",quantity);
        currDbase.update("cart", values, "inventory_id=?", new String[]{invenid});
        // Log.d("updatemsg", "updating quetsion to "+ state +" with id "+qid);
    }

    public void updatePurchaseCart(String invenid,String quantity){
        ContentValues values = new ContentValues();
        values.put("quantity",quantity);
        currDbase.update("purchase", values, "id=?", new String[]{invenid});
        // Log.d("updatemsg", "updating quetsion to "+ state +" with id "+qid);
    }


    public void markAsDone(String noteid){
        ContentValues values = new ContentValues();
        values.put("status","done");
        currDbase.update("notes", values, "noteid=?", new String[]{noteid});
        // Log.d("updatemsg", "updating quetsion to "+ state +" with id "+qid);
    }








    public long insertCart(String id,String itemcode,
                                              String item_name,String item_quantity,
                                              String unitprice,String discount,
                                              String selling_price,String subtotal,
                                              String brand,String color,
                                              String size,String pattern,
                                              String cg,String gg,
                                              String fabric,String cat){

        ContentValues values = new ContentValues();
        values.put("inventory_id",id);
        values.put("item_code",itemcode);
        values.put("item_name",item_name);
        values.put("quantity",item_quantity);
        values.put("unit_price",unitprice);
        values.put("discount",discount);
        values.put("selling_price",selling_price);
        values.put("total",subtotal);
        values.put("brand",brand);
        values.put("color",color);
        values.put("size",size);
        values.put("pattern",pattern);
        values.put("consumergroup",cg);
        values.put("gendergroup",gg);
        values.put("fabric",fabric);
        values.put("itemcat",cat);
        long insertId =this.currDbase.insert("cart", null, values);
        Log.d("cursor", insertId + " is the insert id");
        return insertId;
    }

    public long insertPurchaseCart(String id,
                           String item_name,String item_quantity,
                           String unitprice,String discount,
                           String subtotal,
                           String brand,String color,
                           String size,String pattern,
                           String gg,
                           String fabric,String cat,String vendor){

        ContentValues values = new ContentValues();
        values.put("id",id);
        values.put("item_name",item_name);
        values.put("quantity",item_quantity);
        values.put("unit_price",unitprice);
        values.put("discount",discount);
        values.put("total",subtotal);
        values.put("brand",brand);
        values.put("color",color);
        values.put("size",size);
        values.put("pattern",pattern);
        values.put("gendergroup",gg);
        values.put("fabric",fabric);
        values.put("itemcat",cat);
        values.put("vendor",vendor);
        long insertId =this.currDbase.insert("purchase", null, values);
        Log.d("cursor", insertId + " is the insert id");
        return insertId;
    }






    public long insertNotes(String title,String des,
                           String time,String user,String status,String noteid){

        ContentValues values = new ContentValues();
        values.put("title",title);
        values.put("des",des);
        values.put("time",time);
        values.put("user",user);
        values.put("status",status);
        values.put("noteid",noteid);
        long insertId =this.currDbase.insert("notes", null, values);

        Log.d("cursor", values + " is the insert id");
        return insertId;
    }


    public int checkCartNumber(){
        String sql="SELECT * FROM cart";
        Cursor cursor=currDbase.rawQuery(sql, null);
        return cursor.getCount();

            //PLEASE ANSWER ALL

    }

    public int checkPurchaseCartNumber(){
        String sql="SELECT * FROM purchase";
        Cursor cursor=currDbase.rawQuery(sql, null);
        return cursor.getCount();
        //PLEASE ANSWER ALL

    }



    public int checkNotes(){
        String sql="SELECT * FROM notes";
        Cursor cursor=currDbase.rawQuery(sql, null);
        return cursor.getCount();
        //PLEASE ANSWER ALL

    }

    public ArrayList<HashMap<String, String>> getCart(){
        ArrayList<HashMap<String, String>> trendlist=new ArrayList<HashMap<String, String>>();
        String sql="SELECT * FROM cart";

        Cursor cursor=currDbase.rawQuery(sql, null);
        cursor.moveToFirst();
        while (!cursor.isAfterLast()) {
            HashMap<String, String> _message = cursorToQ(cursor);
            trendlist.add(_message);
            cursor.moveToNext();
            Log.d("ghet",""+_message);
        }
        cursor.close();
        return trendlist;
    }

    public ArrayList<HashMap<String, String>> getPurchaseCart(){
        ArrayList<HashMap<String, String>> trendlist=new ArrayList<HashMap<String, String>>();
        String sql="SELECT * FROM purchase";

        Cursor cursor=currDbase.rawQuery(sql, null);
        cursor.moveToFirst();
        while (!cursor.isAfterLast()) {
            HashMap<String, String> _message = cursorToPurchase(cursor);
            trendlist.add(_message);
            cursor.moveToNext();
            Log.d("ghet",""+_message);
        }
        cursor.close();
        return trendlist;
    }

    public ArrayList<HashMap<String, String>> getNotes(){
        ArrayList<HashMap<String, String>> trendlist=new ArrayList<HashMap<String, String>>();
        String sql="SELECT * FROM notes order by time desc";

        Cursor cursor=currDbase.rawQuery(sql, null);
        cursor.moveToFirst();
        while (!cursor.isAfterLast()) {
            HashMap<String, String> name=cursorToNote(cursor);
            trendlist.add(name);
            cursor.moveToNext();
        }
        cursor.close();
        return trendlist;
    }



    public ArrayList<String> getConstants(String type,String title){
        ArrayList<String> trendlist=new ArrayList<String>();
        String sql;
        if(title==null){
            sql="SELECT * FROM constants WHERE type='"+type+"' or type='All' order by name";
        }else{
            sql="SELECT * FROM constants WHERE type='"+type+"' or type='All' and title='"+title+"' order by name";
        }


        Cursor cursor=currDbase.rawQuery(sql, null);
        cursor.moveToFirst();
        while (!cursor.isAfterLast()) {
            String name=cursorToName(cursor);
            trendlist.add(name);
            cursor.moveToNext();

        }
        cursor.close();
        return trendlist;
    }

    public ArrayList<String> getAllConstants(String type){
        ArrayList<String> trendlist=new ArrayList<String>();
        String sql="SELECT * FROM constants WHERE type='"+type+"'";

        Cursor cursor=currDbase.rawQuery(sql, null);
        cursor.moveToFirst();
        while (!cursor.isAfterLast()) {
           String name=cursorToName(cursor);
           trendlist.add(name);
           cursor.moveToNext();
        }
        cursor.close();
        return trendlist;
    }

    public double getCartTotal(){
        ArrayList<String> trendlist=new ArrayList<String>();
        String sql="SELECT SUM(total) FROM cart";
        Cursor cursor=currDbase.rawQuery(sql, null);
        if(cursor.moveToFirst()) {
            return cursor.getInt(0);
        }
        return 0;
    }

    public int getPurchaseTotal(){
        ArrayList<String> trendlist=new ArrayList<String>();
        String sql="SELECT SUM(total) FROM purchase";
        Cursor cursor=currDbase.rawQuery(sql, null);
        if(cursor.moveToFirst()) {
            return cursor.getInt(0);
        }
        return 0;
    }

    public int getTotalQuantity(String itemcode){
        ArrayList<String> trendlist=new ArrayList<String>();
        String sql="SELECT SUM(quantity) FROM cart where item_code='"+itemcode+"'";
        Cursor cursor=currDbase.rawQuery(sql, null);
        if(cursor.moveToFirst()) {
            return cursor.getInt(0);
        }

        return 0;
    }


    public long insertConstant(String item,String type,String name){
        ContentValues values = new ContentValues();
        values.put("type",type);
        values.put("title",item);
        values.put("name",name);
        long insertId =this.currDbase.insert("constants", null, values);
        Log.d("cursor", insertId + " is the insert id");
        return insertId;
    }


    private HashMap<String, String> cursorToQ(Cursor cursor){
        HashMap<String, String> contact=new HashMap<String,String>();
        contact.put("inventory_id", cursor.getString(cursor.getColumnIndex("inventory_id")));
        contact.put("itemcode", cursor.getString(cursor.getColumnIndex("item_code")));
        contact.put("item", cursor.getString(cursor.getColumnIndex("item_name")));
        contact.put("quantity", cursor.getString(cursor.getColumnIndex("quantity")));
        contact.put("unitprice", cursor.getString(cursor.getColumnIndex("unit_price")));
        contact.put("discount", cursor.getString(cursor.getColumnIndex("discount")));
        contact.put("sellingprice", cursor.getString(cursor.getColumnIndex("selling_price")));
        contact.put("total", cursor.getString(cursor.getColumnIndex("total")));
        contact.put("brand", cursor.getString(cursor.getColumnIndex("brand")));
        contact.put("color", cursor.getString(cursor.getColumnIndex("color")));
        contact.put("size", cursor.getString(cursor.getColumnIndex("size")));
        contact.put("pattern", cursor.getString(cursor.getColumnIndex("pattern")));
        contact.put("consumergroup", cursor.getString(cursor.getColumnIndex("consumergroup")));
        contact.put("gendergroup", cursor.getString(cursor.getColumnIndex("gendergroup")));
        contact.put("fabric", cursor.getString(cursor.getColumnIndex("fabric")));
        contact.put("itemcategory", cursor.getString(cursor.getColumnIndex("itemcat")));
        return contact;
    }


    private HashMap<String, String> cursorToPurchase(Cursor cursor){
        HashMap<String, String> contact=new HashMap<String,String>();
        contact.put("id", cursor.getString(cursor.getColumnIndex("id")));
        contact.put("item", cursor.getString(cursor.getColumnIndex("item_name")));
        contact.put("quantity", cursor.getString(cursor.getColumnIndex("quantity")));
        contact.put("unitprice", cursor.getString(cursor.getColumnIndex("unit_price")));
        contact.put("discount", cursor.getString(cursor.getColumnIndex("discount")));
        contact.put("total", cursor.getString(cursor.getColumnIndex("total")));
        contact.put("brand", cursor.getString(cursor.getColumnIndex("brand")));
        contact.put("color", cursor.getString(cursor.getColumnIndex("color")));
        contact.put("size", cursor.getString(cursor.getColumnIndex("size")));
        contact.put("pattern", cursor.getString(cursor.getColumnIndex("pattern")));
        contact.put("gendergroup", cursor.getString(cursor.getColumnIndex("gendergroup")));
        contact.put("fabric", cursor.getString(cursor.getColumnIndex("fabric")));
        contact.put("itemcategory", cursor.getString(cursor.getColumnIndex("itemcat")));
        contact.put("vendor", cursor.getString(cursor.getColumnIndex("vendor")));
        return contact;
    }




    private HashMap<String, String> cursorToNote(Cursor cursor){
        HashMap<String, String> contact=new HashMap<String,String>();
        contact.put("noteid", cursor.getString(cursor.getColumnIndex("noteid")));
        contact.put("title", cursor.getString(cursor.getColumnIndex("title")));
        contact.put("des", cursor.getString(cursor.getColumnIndex("des")));
        contact.put("time", cursor.getString(cursor.getColumnIndex("time")));
        contact.put("status", cursor.getString(cursor.getColumnIndex("status")));
        contact.put("user", cursor.getString(cursor.getColumnIndex("user")));
        return contact;
    }


    private String cursorToName(Cursor cursor){
        String name=cursor.getString(cursor.getColumnIndex("name"));
        return name;
    }

   


}
