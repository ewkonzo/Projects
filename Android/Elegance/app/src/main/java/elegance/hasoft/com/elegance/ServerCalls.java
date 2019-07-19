package elegance.hasoft.com.elegance;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.Typeface;
import android.os.AsyncTask;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.BaseAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * Geekboy did this
 */
public class  ServerCalls {
    AsyncTask<String, String, String> task;
    AsyncTask<String, Integer, String> uploadtask;
    Context c;
    com.gc.materialdesign.widgets.ProgressDialog pd2;
    ProgressDialog pd;
    JSONHandler jh;
    Constants con;
    ServiceHandler mServiceHandler;
    String mServiceCallResponse,url,userid,token;
    Activity act;
    SharedPreferences app;
    SharedPreferences.Editor edit;
    ArrayList<HashMap<String,String>> trendlist;
    ArrayList<String> arrayList;
    final String userid_con="user_id";
    final String token_con="token";
    DataManager dm;
    int quantity=0;
    AppBasics basic;
    public ServerCalls(Activity activity){
        c=activity;
        act=activity;
       // pd=new ProgressDialog(activity,ProgressDialog.THEME_DEVICE_DEFAULT_LIGHT);
        jh=new JSONHandler(activity);
        con=new Constants();
        app=activity.getSharedPreferences("settings", activity.MODE_PRIVATE);
        edit=app.edit();
        basic=new AppBasics(act);
        if(app.contains("userid")){
            userid=app.getString("userid",null);
            token=app.getString("userkey",null);
        }else{
            userid="jnvfnv";
            token="gvhb";
        }

    }

    public void login(final String username, final String pass){
        task = new AsyncTask<String, String, String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Logging in...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"auth/login";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair("username",username));
                pairs.add(new BasicNameValuePair("password", pass));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                jh.handleLogin(s, username, pass);
            }
        };
        task.execute();
    }



    public void loadreports(final String type,final String month,final ListView list){
        task = new AsyncTask<String, String, String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Loading...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"general/reports";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("type", URLEncoder.encode(type)));
                pairs.add(new BasicNameValuePair("period", URLEncoder.encode(month)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                trendlist=new ArrayList<HashMap<String,String>>();
                trendlist=jh.handleReports(s);
                ReportAdapt ra=new ReportAdapt(act,trendlist);
                list.setAdapter(ra);
                list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                        if(position==0){
                            Intent c=new Intent(act,Reports.class);
                            c.putExtra("type","reports");
                            c.putExtra("reporttype","Sales");
                            act.startActivity(c);
                        }

                        if(position==1){
                            Intent c=new Intent(act,Reports.class);
                            c.putExtra("type","reports");
                            c.putExtra("reporttype","Purchases");
                            act.startActivity(c);

                        }

                        if(position==2){
                            Intent c=new Intent(act,Reports.class);
                            c.putExtra("type","reports");
                            c.putExtra("reporttype","Expenses");
                            act.startActivity(c);

                        }

                    }
                });

            }
        };
        task.execute();
    }





    public void adduser(final String fname, final String sname, final String phone, final String email, final String address, final String group, final String photo){
        task = new AsyncTask<String, String, String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Adding user...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"auth/adduser";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("fname", URLEncoder.encode(fname)));
                pairs.add(new BasicNameValuePair("sname", URLEncoder.encode(sname)));
                pairs.add(new BasicNameValuePair("email", URLEncoder.encode(email)));
                pairs.add(new BasicNameValuePair("address", URLEncoder.encode(address)));
                pairs.add(new BasicNameValuePair("group", URLEncoder.encode(group)));
                pairs.add(new BasicNameValuePair("phone", URLEncoder.encode(phone)));
                pairs.add(new BasicNameValuePair("photo", URLEncoder.encode(photo)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                jh.handleGeneralResponse(s);
            }
        };
        task.execute();
    }


    public void addcustomer(final String name,final String phone,final String email){
        task = new AsyncTask<String, String, String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Adding customer...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"auth/login";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("name", URLEncoder.encode(name)));
                pairs.add(new BasicNameValuePair("phone", URLEncoder.encode(phone)));
                pairs.add(new BasicNameValuePair("email", URLEncoder.encode(email)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                jh.handleGeneralResponse(s);
            }
        };
        task.execute();
    }



    public void purchase(
            final String quan,
            final String vendor,
            final String item, final String itemcategory,
            final String brand, final String color, final String size,
            final String pattern, final String consumergroup, final String gendergroup,
            final String fabric, final String unitprice, final String discount,
            final String total
    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd.setMessage("Adding to store...Please wait");
                pd.setCancelable(false);
                pd.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"commerce/purchase";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("vendor", URLEncoder.encode(vendor)));
                pairs.add(new BasicNameValuePair("item", URLEncoder.encode(item)));
                pairs.add(new BasicNameValuePair("subitem", URLEncoder.encode(itemcategory)));
                pairs.add(new BasicNameValuePair("brand", URLEncoder.encode(brand)));
                pairs.add(new BasicNameValuePair("color", URLEncoder.encode(color)));
                pairs.add(new BasicNameValuePair("size", URLEncoder.encode(size)));
                pairs.add(new BasicNameValuePair("pattern", URLEncoder.encode(pattern)));
                pairs.add(new BasicNameValuePair("age_group", URLEncoder.encode(consumergroup)));
                pairs.add(new BasicNameValuePair("sex", URLEncoder.encode(gendergroup)));
                pairs.add(new BasicNameValuePair("material", URLEncoder.encode(fabric)));
                pairs.add(new BasicNameValuePair("total", URLEncoder.encode(total)));
                pairs.add(new BasicNameValuePair("price", URLEncoder.encode(unitprice)));
                pairs.add(new BasicNameValuePair("discount", URLEncoder.encode(discount)));
                pairs.add(new BasicNameValuePair("quantity", URLEncoder.encode(quan)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd.dismiss();
                jh.handlePurchases(s);
            }
        };
        task.execute();
    }

    public void getitemfromcode(
           final String itemcode,final ListView list,final TextView status,final TextView ttotal
    ){

        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Loading...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"products/item";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("itemcode", URLEncoder.encode(itemcode)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                trendlist=new ArrayList<HashMap<String,String>>();
                trendlist=jh.handleItems(s,list,"sale");
                final ItemAdapter sa=new ItemAdapter(act,trendlist);
                list.setAdapter(sa);
                list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view,final int position, long id) {
                        AlertDialog.Builder alert=new AlertDialog.Builder(act,AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
                        alert.setNegativeButton("ADD TO CART", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {

                                AlertDialog.Builder alertb = new AlertDialog.Builder(act, AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
                                alertb.setMessage("Enter Quantity");
                                final EditText input=new EditText(act);
                                alertb.setView(input);
                                alertb.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog, int which) {
                                        String value = input.getText().toString();
                                        if (value.trim().isEmpty()) {
                                            Toast.makeText(c, "Enter quantity", Toast.LENGTH_LONG).show();
                                        } else {
                                            try {
                                                quantity = Integer.parseInt(value);
                                                AlertDialog.Builder alertb = new AlertDialog.Builder(act, AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
                                                alertb.setMessage("Enter Discount(%)");
                                                final EditText input=new EditText(act);
                                                int discount=0;
                                                if (app.contains("discount")) {
                                                    discount = app.getInt("discount", 0);
                                                } else {
                                                    discount = 0;
                                                }

                                                input.setText(discount+"");
                                                alertb.setView(input);
                                                alertb.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                                                    @Override
                                                    public void onClick(DialogInterface dialog, int which) {
                                                       final String value = input.getText().toString();
                                                        if (value.trim().isEmpty()) {
                                                            Toast.makeText(c, "Enter Discount(%)", Toast.LENGTH_LONG).show();
                                                        } else {
                                                            try {
                                                              int dis=Integer.parseInt(value);
                                                              addtocart(position,trendlist,dis,status,ttotal);

                                                            } catch (NumberFormatException e) {
                                                                basic.showToast("Enter a number");
                                                            }
                                                        }
                                                    }
                                                });


                                                AlertDialog x=alertb.create();
                                                x.show();
                                            } catch (NumberFormatException e) {
                                                basic.showToast("Enter a number");
                                            }
                                        }
                                    }
                                });

                                AlertDialog x=alertb.create();
                                x.show();

                            }
                        });
                        alert.setPositiveButton("BROWSE ITEM",new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                browseitem(trendlist,position);
                            }
                        });

                        AlertDialog c=alert.create();
                        c.show();
                    }
                });
            }
        };
        task.execute();
    }

    public void getitemfromsubitem(
            final String item, final ListView list,final String subitem
    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Searching...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"general/subitem";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("item", URLEncoder.encode(item)));
                pairs.add(new BasicNameValuePair("subitem", URLEncoder.encode(subitem)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                trendlist=new ArrayList<HashMap<String,String>>();
                trendlist=jh.handleItems(s,list,"sale");
                final ItemAdapter sa=new ItemAdapter(act,trendlist);
                list.setAdapter(sa);
                list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view,final int position, long id) {
                        AlertDialog.Builder alert=new AlertDialog.Builder(act,AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
                        alert.setNegativeButton("ADD TO CART", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {

                                AlertDialog.Builder alertb = new AlertDialog.Builder(act, AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
                                alertb.setMessage("Enter Quantity");
                                final EditText input=new EditText(act);
                                alertb.setView(input);
                                alertb.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog, int which) {
                                        String value = input.getText().toString();
                                        if (value.trim().isEmpty()) {
                                            Toast.makeText(c, "Enter quantity", Toast.LENGTH_LONG).show();
                                        } else {
                                            try {
                                                quantity = Integer.parseInt(value);
                                                AlertDialog.Builder alertb = new AlertDialog.Builder(act, AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
                                                alertb.setMessage("Enter Discount(%)");
                                                final EditText input2=new EditText(act);
                                                int discount=0;
                                                if (app.contains("discount")) {
                                                    discount = app.getInt("discount", 0);
                                                } else {
                                                    discount = 0;
                                                }
                                                input2.setText(discount+"");
                                                alertb.setView(input2);
                                                alertb.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                                                    @Override
                                                    public void onClick(DialogInterface dialog, int which) {
                                                        final String value = input2.getText().toString();

                                                        if (value.trim().isEmpty()) {
                                                            Toast.makeText(c, "Enter Discount", Toast.LENGTH_LONG).show();
                                                        } else {

                                                            try {
                                                                int dis=Integer.parseInt(value.trim());
                                                                addtocart(position,trendlist,dis,null,null);
                                                            } catch (NumberFormatException e) {
                                                                basic.showAlert("error"+value);
                                                                basic.showToast("Enter a number " + e.getMessage());
                                                            }
                                                        }
                                                    }
                                                });


                                                AlertDialog x=alertb.create();
                                                x.show();
                                            } catch (NumberFormatException e) {
                                                basic.showToast("Enter a number");
                                            }
                                        }
                                    }
                                });

                                AlertDialog x=alertb.create();
                                x.show();

                            }
                        });
                        alert.setPositiveButton("BROWSE ITEM",new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                browseitem(trendlist, position);
                            }
                        });

                        AlertDialog c=alert.create();
                        c.show();
                    }
                });
            }
        };
        task.execute();
    }


    public void getitemfromsearch(
            final String query, final ListView list
    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Searching...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"general/search";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("keyword", URLEncoder.encode(query)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                trendlist=new ArrayList<HashMap<String,String>>();
                trendlist=jh.handleItems(s,list,"sale");
                final ItemAdapter sa=new ItemAdapter(act,trendlist);
                list.setAdapter(sa);
                list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view,final int position, long id) {
                        AlertDialog.Builder alert=new AlertDialog.Builder(act,AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
                        alert.setNegativeButton("ADD TO CART", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {

                                AlertDialog.Builder alertb = new AlertDialog.Builder(act, AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
                                alertb.setMessage("Enter Quantity");
                                final EditText input=new EditText(act);
                                alertb.setView(input);
                                alertb.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog, int which) {
                                        String value = input.getText().toString();
                                        if (value.trim().isEmpty()) {
                                            Toast.makeText(c, "Enter quantity", Toast.LENGTH_LONG).show();
                                        } else {
                                            try {
                                                quantity = Integer.parseInt(value);
                                                AlertDialog.Builder alertb = new AlertDialog.Builder(act, AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
                                                alertb.setMessage("Enter Discount");
                                                final EditText input=new EditText(act);
                                                int discount=0;
                                                if (app.contains("discount")) {
                                                    discount = app.getInt("discount", 0);
                                                } else {
                                                    discount = 0;
                                                }

                                                input.setText(discount+"");
                                                alertb.setView(input);
                                                alertb.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                                                    @Override
                                                    public void onClick(DialogInterface dialog, int which) {
                                                        final String value = input.getText().toString();
                                                        if (value.trim().isEmpty()) {
                                                            Toast.makeText(c, "Enter Discount", Toast.LENGTH_LONG).show();
                                                        } else {
                                                            try {
                                                                int dis=Integer.parseInt(value.trim());
                                                                addtocart(position,trendlist,dis,null,null);

                                                            } catch (NumberFormatException e) {
                                                                basic.showToast("Enter a number");
                                                            }
                                                        }
                                                    }
                                                });


                                                AlertDialog x=alertb.create();
                                                x.show();
                                            } catch (NumberFormatException e) {
                                                basic.showToast("Enter a number");
                                            }
                                        }
                                    }
                                });

                                AlertDialog x=alertb.create();
                                x.show();

                            }
                        });
                        alert.setPositiveButton("BROWSE ITEM",new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                               browseitem(trendlist,position);
                            }
                        });

                        AlertDialog c=alert.create();
                        c.show();
                    }
                });

            }
        };
        task.execute();
    }



    public void gettransactions(
            final ListView list
    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Loading...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"transactions/all";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                jh.handleTransactions(s);
            }
        };
        task.execute();
    }



    public ArrayList<HashMap<String,String>> getusers(
            final ListView list
    ){


        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Loading...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"usr/fetch";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                trendlist=process(s);
            }
        };
        task.execute();
        return trendlist;
    }


    public ArrayList<HashMap<String,String>> process(String s){
        trendlist=new ArrayList<>();
        trendlist=jh.handleUsers(s);
        return trendlist;

    }


    public void getexpenses(
           final ListView list
    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Loading...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"expenses/fetch";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                trendlist=new ArrayList<HashMap<String,String>>();
                trendlist=jh.handleExpenses(s);
                list.setAdapter(expenseadapt);

            }
        };
        task.execute();
    }



    public void getreportexpenses(
            final ListView list
    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Loading...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"expenses/fetch_expenses";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                trendlist=new ArrayList<HashMap<String,String>>();
                trendlist=jh.handleExpenses(s);
                list.setAdapter(expenseadapt);

            }
        };
        task.execute();
    }



    public void getreportsales(
            final ListView list
    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Loading...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"expenses/fetch_sales";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                trendlist=new ArrayList<HashMap<String,String>>();
                trendlist=jh.handleSalesReport(s);
                list.setAdapter(salesadapt);

            }
        };
        task.execute();
    }




    BaseAdapter salesadapt=new BaseAdapter() {
        @Override
        public int getCount() {
            return trendlist.size();
        }

        @Override
        public Object getItem(int position) {
            return null;
        }

        @Override
        public long getItemId(int position) {
            return 0;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            LayoutInflater li=act.getLayoutInflater();
            convertView= li.inflate(R.layout.notes_layout,null);
            String name=trendlist.get(+position).get("amount");
            TextView t=(TextView)convertView.findViewById(R.id.itemname);
            t.setTypeface(Typeface.DEFAULT_BOLD);
            TextView tdes=(TextView)convertView.findViewById(R.id.itemdes);
            RoundedLetterView s=(RoundedLetterView)convertView.findViewById(R.id.imageView);
            s.setTitleText((trendlist.get(+position).get("user").substring(0, 1).toUpperCase()));
            t.setText("KES "+name);
            t.setTextColor(Color.BLACK);
            tdes.setText("Sold by "+trendlist.get(+position).get("user")+"\n\nOn "+trendlist.get(+position).get("date"));
            return convertView;
        }
    };



    public void getreportpurchases(
            final ListView list
    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Loading...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"expenses/fetch_purchases";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                trendlist=new ArrayList<HashMap<String,String>>();
                trendlist=jh.handleItems(s,list,"sale");
                final ItemAdapter sa=new ItemAdapter(act,trendlist);
                list.setAdapter(sa);

            }
        };
        task.execute();
    }


    BaseAdapter expenseadapt=new BaseAdapter() {
        @Override
        public int getCount() {
            return trendlist.size();
        }

        @Override
        public Object getItem(int position) {
            return null;
        }

        @Override
        public long getItemId(int position) {
            return 0;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            LayoutInflater li=act.getLayoutInflater();
            convertView= li.inflate(R.layout.notes_layout,null);
            String name=trendlist.get(+position).get("amount");
            TextView t=(TextView)convertView.findViewById(R.id.itemname);
            t.setTypeface(Typeface.DEFAULT_BOLD);
            TextView tdes=(TextView)convertView.findViewById(R.id.itemdes);
            RoundedLetterView s=(RoundedLetterView)convertView.findViewById(R.id.imageView);
            s.setTitleText((trendlist.get(+position).get("type").substring(0, 1).toUpperCase()));
            t.setText("USD "+name);
            t.setTextColor(Color.BLACK);
            tdes.setText("Spent by "+trendlist.get(+position).get("user")+" on "+trendlist.get(+position).get("type")+"\n\n("+trendlist.get(+position).get("des")+")\n\nOn "+trendlist.get(+position).get("date"));
            return convertView;
        }
    };



    public void getnotes(

    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();

            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"notes/fetch";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
               // pd2.dismiss();
                jh.handleNotes(s);
            }
        };
        task.execute();
    }



    public void assignnotes(
            final String user,final String title,final String des
    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Assigning...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"notes/post";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("note_title", title));
                pairs.add(new BasicNameValuePair("send_to", user));
                pairs.add(new BasicNameValuePair("message",des));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                jh.handleGeneralResponse(s);
            }
        };
        task.execute();
    }



    public void addexpense(
            final String title,final String des,final String amount
    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Adding...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"expenses/add";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("expense_title", title));
                pairs.add(new BasicNameValuePair("expense_des", des));
                pairs.add(new BasicNameValuePair("expense_amount", amount));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                jh.handleGeneralResponse(s);
            }
        };
        task.execute();
    }


    public void addproduct(
            final String title,final String des
    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Adding product...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"notes/fetch";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("product_title", URLEncoder.encode(title)));
                pairs.add(new BasicNameValuePair("product_des", URLEncoder.encode(des)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                jh.handleTransactions(s);
            }
        };
        task.execute();
    }



    public void fetchproduct(
            final String title,final String des
    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Fetching product...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"notes/fetch";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                jh.handleTransactions(s);
            }
        };
        task.execute();
    }

    public void addnewitem(
            final String type,final String name,final String item
    ){
        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Adding...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                //Toast.makeText(act,item,Toast.LENGTH_LONG).show();
                url = con.URL+"admin/addconst";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("name", name));
                pairs.add(new BasicNameValuePair("type",type));
                pairs.add(new BasicNameValuePair("item_category", item));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                jh.handleNewItems(s,type);
            }
        };
        task.execute();
    }

    public void getconstants(final boolean gohome){
        task = new AsyncTask<String, String, String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Synchronizing...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"general/constants";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                jh.handleConstants(s,gohome);
            }
        };
        task.execute();
    }


    public void makeSale(final String array,final String total){
        task = new AsyncTask<String, String, String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Processing...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"commerce/sell";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("paymentmethod", URLEncoder.encode(total)));
                pairs.add(new BasicNameValuePair("products", array));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                jh.handleSales(s);
            }
        };
        task.execute();
    }



    public void makePurchase(final String array){
        task = new AsyncTask<String, String, String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(act,"Processing...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"commerce/purchase";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("products", array));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                jh.handlePurchases(s);
            }
        };
        task.execute();
    }



    public void loadCart(ListView list,final TextView status,final TextView ttotal

    ){          dm=new DataManager(act,1);
                trendlist=new ArrayList<HashMap<String,String>>();
                trendlist=dm.getCart();
                final ItemAdapter sa=new ItemAdapter(act,trendlist);
                list.setAdapter(sa);
                list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                 @Override
                  public void onItemClick(AdapterView<?> parent, View view, final int position, long id) {
                AlertDialog.Builder alert=new AlertDialog.Builder(act,AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
                alert.setNegativeButton("REMOVE FROM CART", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dm.removeItem(trendlist.get(+position).get("itemcode"));
                        basic.updateCart(status, ttotal);
                        Intent c = new Intent(act, Cart.class);
                        act.startActivity(c);
                    }
                });
                alert.setPositiveButton("BROWSE ITEM",new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {

                        browseitem(trendlist, position);

                    }
                });

                AlertDialog c=alert.create();
                c.show();
            }
        });

    }



    public void loadPurchaseCart(ListView list

    ){
        dm=new DataManager(act,1);
        trendlist=new ArrayList<>();
        trendlist=dm.getPurchaseCart();
        final ItemAdapter sa=new ItemAdapter(act,trendlist);
        list.setAdapter(sa);
        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, final int position, long id) {
                AlertDialog.Builder alert=new AlertDialog.Builder(act,AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
                alert.setNegativeButton("REMOVE FROM CART", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dm.removePurchaseItem(trendlist.get(+position).get("id"));

                        Intent c = new Intent(act, Purchase_Cart.class);
                        act.startActivity(c);
                    }
                });
                alert.setPositiveButton("BROWSE ITEM",new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        browseitem(trendlist, position);
                    }
                });

                AlertDialog c=alert.create();
                c.show();
            }
        });

    }


    public void addtocart(final int position,ArrayList<HashMap<String,String>> trendlist,int discount,TextView status,TextView ttotal) {

        dm=new DataManager(act,1);
      if(status!=null){
              status=status;
      }

        if(ttotal!=null){
         ttotal=ttotal;
        }
        if (app.contains("discount")) {
            discount = app.getInt("discount", 0);
        } else {
            discount = 0;
        }


        String s=trendlist.get(+position).get("unitprice");
        String [] parts=s.split("\\.");
        String prices=parts[0];

        int price = Integer.parseInt(prices);
        int np=100-discount;
        double dec=np*0.01;
        double newprice = price * dec;
        double total = newprice * quantity;

       String itemcode=trendlist.get(+position).get("itemcode");
       int q=Integer.parseInt(trendlist.get(+position).get("quantity"));

        if(q<quantity){
            basic.showAlert("There are not enough items to in store to buy "+quantity+" more items.You have so far added "+dm.getTotalQuantity(itemcode)+" items."+"Current quantity in store is "+q);
        }else {

            long h = dm.insertCart(trendlist.get(+position).get("inventory_id"),
                    trendlist.get(+position).get("itemcode"),
                    trendlist.get(+position).get("item"),
                    quantity + "",
                    trendlist.get(+position).get("unitprice"),
                    discount + "",
                    newprice + "",
                    total + "",
                    trendlist.get(+position).get("brand"),
                    trendlist.get(+position).get("color"),
                    trendlist.get(+position).get("size"),
                    trendlist.get(+position).get("pattern"),
                    trendlist.get(+position).get("consumergroup"),
                    trendlist.get(+position).get("gendergroup"),
                    trendlist.get(+position).get("fabric"),
                    trendlist.get(+position).get("itemcategory")
                    );
            basic.showAlert("Item successfully added to cart");
            if (status != null) {
                basic.updateCart(status, ttotal);
            }
        }

    }


    public void browseitem(final ArrayList<HashMap<String,String>> trendlist,final int position){

        Intent c=new Intent(act,Browse.class);
        c.putExtra("type","item");
        c.putExtra("itemid",trendlist.get(+position).get("itemcode"));
        c.putExtra("itemname",trendlist.get(+position).get("item"));
        c.putExtra("subitem",trendlist.get(+position).get("itemcategory"));
        c.putExtra("photo",trendlist.get(+position).get("photo"));
        c.putExtra("color",trendlist.get(+position).get("color"));
        c.putExtra("size",trendlist.get(+position).get("size"));
        c.putExtra("pattern",trendlist.get(+position).get("pattern"));
        c.putExtra("consumergroup",trendlist.get(+position).get("conumsergroup"));
        c.putExtra("gendergroup",trendlist.get(+position).get("gendergroup"));
        c.putExtra("fabric",trendlist.get(+position).get("fabric"));
        c.putExtra("unitprice",trendlist.get(+position).get("unitprice"));
        c.putExtra("quantity",trendlist.get(+position).get("quantity"));
        c.putExtra("total",trendlist.get(+position).get("total"));
        c.putExtra("brand",trendlist.get(+position).get("brand"));
        c.putExtra("array",trendlist);
        act.startActivity(c);
    }


}
