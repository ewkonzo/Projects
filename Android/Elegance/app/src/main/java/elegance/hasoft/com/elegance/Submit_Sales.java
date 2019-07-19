package elegance.hasoft.com.elegance;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
import android.text.Editable;
import android.text.Html;
import android.text.TextWatcher;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;

import floatt.FloatingActionButton;


public class Submit_Sales extends ActionBarActivity {
    Toolbar toolbar;
    GridView grid;
    ActionBar ab;
    String userid,usertoken,usercategory,itemm,query;
    String [] menu,items;
    Resources res;
    AppBasics basic;
    NetDetector cd;
    Boolean netpresent=false;
    ServerCalls sc;
    SharedPreferences app;
    ServiceHandler mServiceHandler;
    Constants con;
    EditText name;
    ListView list;
    Bundle extras;
    String item,subitem,type;
    DataManager dm;
    TextView cartstatus;
    TextView carttotal;
    ArrayList<HashMap<String,String>> trendlist;
    String productsarray,payment,amountincash,amountincredit,loyaltycode;
    double amount;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_submit__sales);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.blue);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
       // ab.setDisplayHomeAsUpEnabled(true);
        ab.setTitle(Html.fromHtml("<font color='white'>Shopping Details</font>"));
        app=getSharedPreferences("settings",MODE_PRIVATE);
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        extras=getIntent().getExtras();
        dm=new DataManager(this,1);
        res=getResources();
        menu=res.getStringArray(R.array.paymentmethods);
        int rate=app.getInt("rate",100);
        TextView t=(TextView)findViewById(R.id.textname);
        amount=dm.getCartTotal()*rate;
        t.setText("KES "+amount);

        FloatingActionButton mpr=(FloatingActionButton)findViewById(R.id.proceed);
        mpr.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                check();

            }
        });

        Spinner itemsp=(Spinner)findViewById(R.id.specpayment);
        setUpSpinner(itemsp, menu, null);
        itemsp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object itemx = parent.getItemAtPosition(position);

                if (itemx != null) {
                    payment = itemx.toString();
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });

        setup();
    }


    public void setup(){
       if(extras!=null){

       } else{

       }
    }


    public void setUpSpinner(Spinner spfun,String [] menu,ArrayList<String> trendlist){
        ArrayAdapter adapter2;
        if(trendlist==null){
            adapter2=new ArrayAdapter(Submit_Sales.this,R.layout.support_simple_spinner_dropdown_item,menu);
        }else{
            adapter2=new ArrayAdapter(Submit_Sales.this,R.layout.support_simple_spinner_dropdown_item,trendlist);
        }

        spfun.setAdapter(adapter2);

    }


    public void check(){
        if(payment==null){
            basic.showAlert("Choose payment method");
        }else {
            if (payment.equalsIgnoreCase("Cash and Debit Card")) {
                if (amountincash == null || amountincredit == null) {
                    creditAmount();
                } else {
                    submit();
                }
            } else {


                if (payment.equalsIgnoreCase("Cash and Loyalty Card")) {
                    if (amountincash == null || amountincredit == null) {
                        basic.showAlert("Upgrade ongoing!Service not available at the moment.You will be notified once the upgrade is completed");
                    } else {
                        basic.showAlert("Upgrade ongoing!Service not available at the moment.You will be notified once the upgrade is completed");
                    }
                }else {


                    if (payment.equalsIgnoreCase("Loyalty Card")) {
                        if (amountincash == null || amountincredit == null) {
                            basic.showAlert("Upgrade ongoing!Service not available at the moment.You will be notified once the upgrade is completed");
                        } else {
                            basic.showAlert("Upgrade ongoing!Service not available at the moment.You will be notified once the upgrade is completed");
                        }
                    }else{
                        submit();
                    }
                }

            }

        }
    }

    public void submit(){
        trendlist=new ArrayList<HashMap<String,String>>();
        trendlist=dm.getCart();
        JSONObject main=new JSONObject();
        JSONArray array=new JSONArray();
        for (int i=0;i<trendlist.size();i++){
            JSONObject object=new JSONObject();
            try {
                object.put("inventory_id",trendlist.get(i).get("itemcode"));
                object.put("quantity",trendlist.get(i).get("quantity"));
                object.put("total",trendlist.get(i).get("total"));
                object.put("selling_price",trendlist.get(i).get("sellingprice"));
            } catch (JSONException e) {
                e.printStackTrace();
            }
            array.put(object);
        }

        try {
            main.put("products",array);                    
        } catch (JSONException e) {
            e.printStackTrace();
        }

        productsarray=array.toString();
        basic.showAlert(productsarray);
        sc.makeSale(productsarray,payment);

    }



    public void  creditAmount(){
            final AlertDialog.Builder alertb = new AlertDialog.Builder(Submit_Sales.this, AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
            alertb.setTitle("Enter Split Amounts");

            LinearLayout c=new LinearLayout(Submit_Sales.this);
            c.setOrientation(LinearLayout.VERTICAL);
            TextView t=new TextView(Submit_Sales.this);
            t.setText("Amount in cash");
            c.addView(t);
            final EditText input=new EditText(Submit_Sales.this);
            input.setHint("Cash Amount:");
            c.addView(input);
            TextView t2=new TextView(Submit_Sales.this);
            t2.setText("Amount in card");
            c.addView(t2);
            final EditText input2=new EditText(Submit_Sales.this);
            input2.setHint("Card Amount:");
            c.addView(input2);

            input.addTextChangedListener(new TextWatcher() {
                @Override
                public void beforeTextChanged(CharSequence s, int start, int count, int after) {

                }

                @Override
                public void onTextChanged(CharSequence s, int start, int before, int count) {

                }

                @Override
                public void afterTextChanged(Editable s) {
                    String card = input.getText().toString();
                    if(!card.trim().isEmpty()){
                        try {
                            int x = Integer.parseInt(card);
                            if(x>amount){
                                input2.setText(0+"");
                            }else {
                                double bal = amount - x;
                                input2.setText(bal + "");
                            }
                        }catch(NumberFormatException e){
                           basic.showToast("Amount should be a number");
                        }
                    }else{
                        input2.setText(amount + "");
                    }
                }
            });
            alertb.setView(c);
            alertb.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    String cash = input.getText().toString();
                    String card = input2.getText().toString();
                    if(card.trim().isEmpty()||cash.trim().isEmpty()){
                        basic.showToast("Enter both amounts");
                    }else{
                        amountincash=cash;
                        amountincredit=card;
                    }
                    dialog.dismiss();
                }
            });
            AlertDialog cs=alertb.create();
            cs.show();
    }


    public void  LoyaltyCard(){
        AlertDialog.Builder alertb = new AlertDialog.Builder(Submit_Sales.this, AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
        alertb.setTitle("Enter Card Number");

        LinearLayout c=new LinearLayout(Submit_Sales.this);
        c.setOrientation(LinearLayout.VERTICAL);
        final EditText input2=new EditText(Submit_Sales.this);
        input2.setHint("Card Number:");
        c.addView(input2);

        alertb.setView(c);
        alertb.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                String cash = input2.getText().toString();
                if(cash.trim().isEmpty()){
                    basic.showToast("Enter card number");
                }else{
                    basic.showAlert("Upgrade ongoing!Service not available at the moment.You will be notified once the upgrade is completed");
                }
            }
        });
        AlertDialog cs=alertb.create();
        cs.show();
    }





    public void updateboth(EditText card,EditText cash){
        String ecard=card.getText().toString();
        String ecash=cash.getText().toString();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        //Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_submit__sales, menu);
        return true;
    }



    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            Intent c=new Intent(Submit_Sales.this,Home.class);
            startActivity(c);
            return true;
        }

        if (id == R.id.action_new) {
            Intent c=new Intent(Submit_Sales.this,Sale.class);
            startActivity(c);
            return true;
        }
        if (id == R.id.action_cart) {
            Intent c=new Intent(Submit_Sales.this,Cart.class);
            startActivity(c);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
