package elegance.hasoft.com.elegance;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import java.util.ArrayList;

import floatt.FloatingActionButton;


public class Buy_More extends ActionBarActivity {
    Toolbar toolbar;
    ActionBar ab;
    String userid,usertoken,usercategory,type,itemm,category,id;
    String [] menu,items;
    Resources res;
    AppBasics basic;
    NetDetector cd;
    Boolean netpresent=false;
    ServerCalls sc;
    SharedPreferences app;
    SharedPreferences.Editor edit;
    ArrayList<String> trendlist;
    ServiceHandler mServiceHandler;
    Constants con;
    DataManager dm;
    Bundle extras;
    String item,itemcategory,brand,color,size,pattern,cg,gg,fabric,price,discount,qunatity,vendor;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_buy__more);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.blue);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setTitle("");
       // ab.setDisplayHomeAsUpEnabled(true);
        app=getSharedPreferences("settings",MODE_PRIVATE);
        edit=app.edit();
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        dm=new DataManager(this,1);
        extras=getIntent().getExtras();
        TextView t=(TextView)findViewById(R.id.textView);
        id=app.getString("currentcart",null);
        itemm=app.getString(id+"item",null);
        t.setText("Enter more details about these "+itemm.toLowerCase());
        FloatingActionButton mpr=(FloatingActionButton)findViewById(R.id.proceed);
        mpr.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                proceed();

            }
        });


        setup();

    }



    public void setup(){



        //itembrand
        ArrayList<String> trendlist2=new ArrayList<>();
        trendlist2=dm.getConstants("Brand",itemm);
        final Spinner brsp=(Spinner)findViewById(R.id.specbrand);
        setUpSpinner(brsp,null,trendlist2);
        brsp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item!= null){
                    brand = item.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });


        //itemPattern
        ArrayList<String> trendlist4=new ArrayList<>();
        trendlist4=dm.getConstants("Pattern",itemm);
        Spinner ptsp=(Spinner)findViewById(R.id.specpattern);
        setUpSpinner(ptsp,null,trendlist4);
        ptsp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item!= null){
                    pattern= item.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });


        //itemConsumer


        //itemFabric
        ArrayList<String> trendlist7=new ArrayList<>();
        trendlist7=dm.getConstants("Fabric",itemm);
        Spinner fabsp=(Spinner)findViewById(R.id.specfab);
        setUpSpinner(fabsp,null,trendlist7);
        fabsp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item!= null){
                    fabric = item.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });

    }


    public void setUpSpinner(Spinner spfun,String [] menu,ArrayList<String> trendlist){
        ArrayAdapter adapter2;
        if(trendlist==null){
            adapter2=new ArrayAdapter(Buy_More.this,R.layout.support_simple_spinner_dropdown_item,menu);
        }else{
            adapter2=new ArrayAdapter(Buy_More.this,R.layout.support_simple_spinner_dropdown_item,trendlist);
        }

        spfun.setAdapter(adapter2);

    }


    public void add(){
        Intent c=new Intent(Buy_More.this,New.class);
        startActivity(c);
    }
    public void proceed(){
        netpresent=cd.isConnectingToInternet();
        EditText eprice=(EditText)findViewById(R.id.editprice);
        EditText equantity=(EditText)findViewById(R.id.editquantity);
        price=eprice.getText().toString();
        qunatity=equantity.getText().toString();
        if(price.trim().isEmpty()||qunatity.trim().isEmpty()) {
            basic.showAlert("Please All Details");
        }else{

            String time=app.getString("currentcart","");
            edit.putString(time+"quantity",qunatity);
            edit.putString(time+"price",price);
            edit.putString(time+"fabric",fabric);
            edit.putString(time+"pattern",pattern);
            edit.putString(time+"brand",brand);
            edit.commit();
            Intent c=new Intent(Buy_More.this,Buy_Cards.class);
            startActivity(c);


            /*
            int total=Integer.parseInt(qunatity)*Integer.parseInt(price);
            String id=app.getString("currentcart",null);
            basic.showAlert(id+app.getString(id+"item",null));
            long x=dm.insertPurchaseCart(app.getString("currentcart",null),app.getString(id+"item",null),
                    qunatity,price,discount,total+"",brand,color,size,pattern,app.getString(id+"gendergroup",null),fabric,app.getString(id+"subitem",null),app.getString(id+"vendor",null));

            View.OnClickListener newitem=new View.OnClickListener(){

                @Override
                public void onClick(View v) {
                    Intent c=new Intent(Buy_More.this,Buy.class);
                    startActivity(c);
                }
            };

            View.OnClickListener viewcart=new View.OnClickListener(){

                @Override
                public void onClick(View v) {
                    Intent c=new Intent(Buy_More.this,Purchase_Cart.class);
                    startActivity(c);
                }
            };

            basic.showDetailedAlert("ITEM ADDED","Item successfully added to cart.Add New Item?","ADD NEW",newitem,"VIEW CART",viewcart);
*/

        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
       getMenuInflater().inflate(R.menu.menu_buy__more, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_cartstatus) {
            basic.displayPurchase();
            return true;
        }

        if (id == R.id.action_viewcart) {
            Intent c=new Intent(Buy_More.this,Purchase_Cart.class);
            startActivity(c);
            return true;
        }

        if (id == R.id.action_home) {
            Intent c=new Intent(Buy_More.this,Home.class);
            startActivity(c);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
