package elegance.hasoft.com.elegance;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.view.View;
import android.widget.ListView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Created by GeekBoy on 10/29/2014.
 */
public class JSONHandler extends Activity{
    int success;
    JSONArray extras,choices;
    JSONObject json;
    String sender,receiver,media,message,time,messageid;
    String resp;
    int direction;
    DataManager dataManager;
    Context mContext;
    ArrayList<HashMap<String, String>> array;
    TimeCalculator mTime;
    SharedPreferences app;
    SharedPreferences.Editor edit;
    AppBasics basic;
    Activity act;
    DataManager dm;
    ServerCalls sc;
    public JSONHandler(Activity test) {
        mContext = test;
        app=test.getSharedPreferences("settings", test.MODE_PRIVATE);
        edit=app.edit();
        basic=new AppBasics(test);
        act=test;

    }

    public void handleLogin(String s,final String username,final String pass){
       //basic.showAlert(s);
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if (success == 1) {
                        String usercategory = jsonObject.getString("user_category");
                        String userkey = jsonObject.getString("token");
                        String userid = jsonObject.getString("user_id");
                        String names = jsonObject.getString("full_name");
                        edit.putString("usercategory",usercategory);
                        edit.putString("userkey",userkey);
                        edit.putString("password",pass);
                        edit.putString("userid", userid);
                        edit.putString("email", username);
                        edit.putString("names", names);
                        edit.commit();
                    View.OnClickListener yes=new View.OnClickListener() {
                          @Override
                       public void onClick(View v) {
                            edit.putString("rem", "yes");
                            edit.commit();
                            checkSetUp();
                        }

                    };
                    View.OnClickListener no=new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            edit.putString("rem","no");
                            edit.commit();
                            checkSetUp();
                        }

                    };

                basic.showDetailedAlert("REMEMBER EMAIL?","Elegance would like to remember your email next time you log in","ALLOW",yes,"NOT NOW",no);

                }else{
                    String message=jsonObject.getString("message");
                    if(message.equalsIgnoreCase("")) {
                        basic.showAlert("Please check your login details");
                    }else{
                        basic.showAlert(message);
                    }

                }

            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");

            }

        }else {
            basic.showAlert("No response from server.Try again later");


        }
    }

    public void handleNewItems(String s,final String type){
     // basic.showAlert(s);
        sc=new ServerCalls(act);
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if (success == 1) {

                        View.OnClickListener c=new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                sc.getconstants(true);
                            }
                        };



                    basic.showDetailedAlert(type+" ADDED",type+" successfully added","PROCEED",c,null,null);


                }else{
                    String message=jsonObject.getString("message");
                    basic.showAlert(message);

                }

            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");

            }

        }else {
            basic.showAlert("No response from server.Try again later");


        }
    }


    public int handlePurchases(String s){
        dm=new DataManager(act,1);
        basic.showAlert(s);
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if (success == 1) {
                    String message = jsonObject.getString("message");
                    basic.showAlert(message);
                    dm.clearPurchaseCart();
                    return 1;
                }else{
                    String message = jsonObject.getString("message");
                    basic.showAlert(message);
                    return 0;
                }

            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");
                    return 0;
            }

        }else {
            basic.showAlert("No response from server.Try again later");
            return 0;
        }
    }





    public int handleGeneralResponse(String s){
        basic.showAlert(s);
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if (success == 1) {
                    String message = jsonObject.getString("message");
                    basic.showAlert(message);
                    return 1;
                }else{
                    String message = jsonObject.getString("message");
                    basic.showAlert(message);
                    return 0;
                }

            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");
                return 0;
            }

        }else {
            basic.showAlert("No response from server.Try again later");
            return 0;
        }
    }


    public int handleSales(String s){
        basic.showAlert(s);
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if (success == 1) {
                    dm=new DataManager(act,1);
                    dm.clearCart();
                    String message = jsonObject.getString("message");
                    basic.showAlert(message);
                    return 1;
                }else{
                    String message = jsonObject.getString("message");
                    basic.showAlert(message);
                    return 0;
                }

            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");
                return 0;
            }

        }else {
            basic.showAlert("No response from server.Try again later");
            return 0;
        }
    }


    public void handleNotes(String s){
       // basic.showAlert(s);
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if (success == 1) {
                    extras=jsonObject.getJSONArray("message");
                    for(int i=0;i<extras.length();i++) {
                        json = extras.getJSONObject(i);
                        String id=json.getString("id");
                        String message=json.getString("message");
                        String title=json.getString("note_title");
                        long time=System.currentTimeMillis();
                        dm=new DataManager(act,1);
                        dm.insertNotes(title,message,time+"","d","notdone",time+"");
                        View.OnClickListener yes=new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Intent i=new Intent(act,Notes.class);
                                act.startActivity(i);
                            }

                        };
                        View.OnClickListener no=new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Intent i=new Intent(act,Home.class);
                                act.startActivity(i);
                            }

                        };

                        basic.showDetailedAlert("NEW NOTE", "You have new notes", "OPEN", yes, "NOT NOW", no);


                    }

                }else{

                }

            } catch (JSONException e) {
               basic.showToast("Connection Error.Try again later");

            }

        }else {
            basic.showToast("No response from server.Try again later");
            //return 0;
        }
    }



    public ArrayList<HashMap<String,String>> handleItems(String s,ListView list,final String type){
       //basic.showAlert(s);
        ArrayList<HashMap<String,String>> trendlist=new ArrayList<>();
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if(success==1){
                    extras=jsonObject.getJSONArray("message");
                    for(int i=0;i<extras.length();i++){
                    json=extras.getJSONObject(i);
                        String item=json.getString("item");
                        String itemcode=json.getString("inventory_id");
                        String photo="776";
                        String itemcategory=json.getString("subitem");
                        String color=json.getString("color");
                        String size=json.getString("size");
                        String pattern=json.getString("pattern");
                        String consumergroup=json.getString("age_group");
                        String gendergroup=json.getString("sex");
                        String fabric=json.getString("material");
                        String unitprice=json.getString("price");
                        String quantity=json.getString("quantity");
                        String inventoryid=json.getString("id");
                        String brand=json.getString("brand");
                        String total="78";

                        HashMap<String,String> product=new HashMap<>();
                        product.put("item",item);
                        product.put("itemcode",itemcode);
                        product.put("photo",photo);
                        product.put("itemcategory",itemcategory);
                        product.put("color",color);
                        product.put("size",size);
                        product.put("pattern",pattern);
                        product.put("consumergroup",consumergroup);
                        product.put("gendergroup",gendergroup);
                        product.put("fabric",fabric);
                        product.put("unitprice",unitprice);
                        product.put("quantity",quantity);
                        product.put("total",total);
                        product.put("inventory_id",inventoryid);
                        product.put("brand",brand);
                        trendlist.add(product);
                    }
                }else{
                    basic.showAlert("No items found currently");

                }

            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");

            }

        }else {
            basic.showAlert("No response from server.Try again later");
        }
        return trendlist;
    }



    public ArrayList<HashMap<String,String>> handleExpenses(String s){
        //basic.showAlert(s);
        ArrayList<HashMap<String,String>> trendlist=new ArrayList<>();
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if(success==1){
                    extras=jsonObject.getJSONArray("message");
                    for(int i=0;i<extras.length();i++){
                        json=extras.getJSONObject(i);
                        String id=json.getString("id");
                        String type=json.getString("type");
                        String des=json.getString("description");
                        String amount=json.getString("amount");
                        String date=json.getString("date_added");
                        String user=json.getString("username");

                        HashMap<String,String> product=new HashMap<>();
                        product.put("id",id);
                        product.put("type",type);
                        product.put("des",des);
                        product.put("amount",amount);
                        product.put("date",date);
                        product.put("user",user);
                        trendlist.add(product);
                    }
                }else{
                    basic.showAlert("No expenses found currently");

                }

            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");

            }

        }else {
            basic.showAlert("No response from server.Try again later");
        }
        return trendlist;
    }


    public ArrayList<HashMap<String,String>> handleSalesReport(String s){
        //basic.showAlert(s);
        ArrayList<HashMap<String,String>> trendlist=new ArrayList<>();
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if(success==1){
                    extras=jsonObject.getJSONArray("message");
                    for(int i=0;i<extras.length();i++){
                        json=extras.getJSONObject(i);
                        String id=json.getString("trans_id");
                        String quantity=json.getString("quantity");
                        String amount=json.getString("selling_price");
                        String date=json.getString("sale_time");
                        String user=json.getString("username");

                        HashMap<String,String> product=new HashMap<>();
                        product.put("id",id);
                        product.put("amount",amount);
                        product.put("date",date);
                        product.put("user",user);
                        product.put("quantity",quantity);
                        trendlist.add(product);
                    }
                }else{
                    basic.showAlert("No sales found currently");

                }

            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");

            }

        }else {
            basic.showAlert("No response from server.Try again later");
        }
        return trendlist;
    }






    public ArrayList<HashMap<String,String>> handleTransactions(String s){
        basic.showAlert(s);
        ArrayList<HashMap<String,String>> trendlist=new ArrayList<>();
        /*if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if(success==1){
                    extras=json.getJSONArray("message");
                    for(int i=0;i<extras.length();i++){
                        json=extras.getJSONObject(i);
                        String id=json.getString("transaction_id");
                        String type=json.getString("transaction_type");
                        String amount=json.getString("transaction_amount");
                        String user=json.getString("transaction_user_involved");
                        String time=json.getString("transaction_time");
                        String date=json.getString("transaction_date");

                        HashMap<String,String> product=new HashMap<>();
                        product.put("id",id);
                        product.put("type",type);
                        product.put("amount",amount);
                        product.put("user",user);
                        product.put("time",time);
                        product.put("date",date);
                        trendlist.add(product);
                    }
                }else{
                    basic.showAlert("No transactions found currently");
                }

            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");

            }

        }else {
            basic.showAlert("No response from server.Try again later");
        }
        */
        return trendlist;

    }


    public ArrayList<HashMap<String,String>> handleUsers(String s){
        //basic.showAlert(s);
        ArrayList<HashMap<String,String>> trendlist=new ArrayList<>();
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if(success==1){
                    extras=jsonObject.getJSONArray("message");
                    for(int i=0;i<extras.length();i++){
                        json=extras.getJSONObject(i);
                        String id=json.getString("id");
                        String firstname=json.getString("firstname");
                        String midname=json.getString("midname");
                        String phonenumber=json.getString("phone_no");
                        String email=json.getString("email");
                        String category=json.getString("category");

                        HashMap<String,String> product=new HashMap<>();
                        product.put("id",id);
                        product.put("name",firstname+" "+midname);
                        product.put("phonenumber",phonenumber);
                        product.put("email",email);
                        product.put("category",category);
                        trendlist.add(product);
                    }
                }else{
                    basic.showAlert("No users found currently");
                }

            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");

            }

        }else {
            basic.showAlert("No response from server.Try again later");
        }
          return trendlist;

    }



    public ArrayList<HashMap<String,String>> handleReports(String s){
        //basic.showAlert(s);
        ArrayList<HashMap<String,String>> trendlist=new ArrayList<>();
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                String sales=jsonObject.getString("sales");
                String expenses=jsonObject.getString("expenses");
                String purchases=jsonObject.getString("purchases");
                double profit=0,salesi=0,ei=0,purchasei=0;
                try {
                    if(sales==null){
                        salesi =0;
                    }else{
                        salesi = Double.parseDouble(sales);
                    }

                    if(expenses==null){
                        ei =0;
                    }else{
                       ei = Double.parseDouble(expenses);
                    }

                    if(purchases==null){
                        purchasei = 0;
                    }else{
                        purchasei = Double.parseDouble(purchases);
                    }



                    profit =salesi-(ei+purchasei);

                }catch(NumberFormatException c){
                    basic.showToast("Error");

                }

                HashMap<String, String> contact=new HashMap<>();
                contact.put("name",salesi+"");
                trendlist.add(contact);

                HashMap<String, String> contact1=new HashMap<>();
                contact1.put("name",purchasei+"");
                trendlist.add(contact1);

                HashMap<String, String> contact2=new HashMap<>();
                contact2.put("name",ei+"");
                trendlist.add(contact2);

                HashMap<String, String> contact3=new HashMap<>();
                contact3.put("name",profit+"");
                trendlist.add(contact3);


            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");

            }

        }else {
            basic.showAlert("No response from server.Try again later");
        }
        return trendlist;

    }


    public ArrayList<HashMap<String,String>> handleTransactionsDetails(String s){
        basic.showAlert(s);
        ArrayList<HashMap<String,String>> trendlist=new ArrayList<>();
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if(success==1){
                    extras=json.getJSONArray("message");
                    for(int i=0;i<extras.length();i++){
                        json=extras.getJSONObject(i);
                        String id=json.getString("transaction_id");
                        String type=json.getString("transaction_type");
                        String item=json.getString("item");
                        String itemcode=json.getString("item_code");
                        String photo=json.getString("photo");
                        String itemcategory=json.getString("item_category");
                        String color=json.getString("color");
                        String size=json.getString("size");
                        String pattern=json.getString("pattern");
                        String consumergroup=json.getString("consumer_group");
                        String gendergroup=json.getString("gender_group");
                        String fabric=json.getString("fabric");
                        String unitprice=json.getString("unitprice");
                        String quantity=json.getString("quanity");
                        String total=json.getString("total");

                        HashMap<String,String> product=new HashMap<>();
                        product.put("id",id);
                        product.put("type",type);
                        product.put("item",item);
                        product.put("itemcode",itemcode);
                        product.put("photo",photo);
                        product.put("itemcategory",itemcategory);
                        product.put("color",color);
                        product.put("size",size);
                        product.put("pattern",pattern);
                        product.put("consumergroup",consumergroup);
                        product.put("gendergroup",gendergroup);
                        product.put("fabric",fabric);
                        product.put("unitprice",unitprice);
                        product.put("quantity",quantity);
                        product.put("total",total);
                        trendlist.add(product);
                    }
                }else{
                    basic.showAlert("No transactions details found currently");
                }

            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");

            }

        }else {
            basic.showAlert("No response from server.Try again later");
        }
        return trendlist;
    }



    public boolean handleConstants(String s,final boolean gohome){
    // basic.showToast(s);
        dm=new DataManager(act,1);
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if(success==1){
                dm.clearConstants();
                extras=jsonObject.getJSONArray("message");
                    for(int i=0;i<extras.length();i++){
                        json=extras.getJSONObject(i);
                        String item=json.getString("item_category");
                        String type=json.getString("type");
                        String name=json.getString("name");
                       long x = dm.insertConstant(item,type,name);
                        //basic.showToast(extras.length()+"");
                      // basic.showToast(x+"");
                    }
                    edit.putString("setup","true");
                    edit.commit();
                    if(gohome) {
                        Intent id = new Intent(mContext, Home.class);
                        mContext.startActivity(id);
                    }else{
                        Intent id = new Intent(mContext, Buy.class);
                        mContext.startActivity(id);
                    }
                    return true;
                }else{
                    basic.showAlert("Set up unable to complete");
                    return false;
                }

            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");
                return false;
            }

        }else {
            basic.showAlert("No response from server.Try again later");
            return false;
        }

    }


    public boolean handleItemsDB(String s){
       // basic.showAlert(s);
        if (!(s == null)) {
            try {
                JSONObject jsonObject = new JSONObject(s);
                success = jsonObject.getInt("success");
                if(success==1){
                    extras=json.getJSONArray("message");
                    for(int i=0;i<extras.length();i++){
                        json=extras.getJSONObject(i);
                        String item=json.getString("item_name");


                        return true;
                    }
                }else{
                    basic.showAlert("Set up unable to complete!No items found currently");
                    return false;
                }

            } catch (JSONException e) {
                basic.showAlert("Connection Error.Try again later");
                return false;
            }

        }else {
            basic.showAlert("No response from server.Try again later");
            return false;
        }
        return false;
    }


    public void checkSetUp(){
        if(app.contains("setup")){
            Intent i=new Intent(mContext,Home.class);
            mContext.startActivity(i);
        }else{
            Intent i=new Intent(mContext,SetUp.class);
            mContext.startActivity(i);
        }
    }



    
    }

