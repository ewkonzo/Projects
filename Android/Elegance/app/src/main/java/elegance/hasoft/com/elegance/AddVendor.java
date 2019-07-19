package elegance.hasoft.com.elegance;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.GridView;
import android.widget.Spinner;

import java.util.ArrayList;
import java.util.HashMap;

import floatt.FloatingActionButton;


public class AddVendor extends ActionBarActivity {
    Toolbar toolbar;
    GridView grid;
    ActionBar ab;
    String userid,usertoken,usercategory,type,itemm,vendor;
    String [] menu,items;
    Resources res;
    AppBasics basic;
    NetDetector cd;
    Boolean netpresent=false;
    ServerCalls sc;
    SharedPreferences app;
    SharedPreferences.Editor edit;
    ArrayList<HashMap<String,String>> trendlist;
    ServiceHandler mServiceHandler;
    Constants con;
    DataManager dm;
    Spinner prod,countries;
    String product,country,name,email,phone,state,market;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_add_vendor);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.white);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setTitle(Html.fromHtml("<font color='white'>Add Vendor</font>"));
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
        res=getResources();
        menu=res.getStringArray(R.array.countries);

        ArrayList<String> trendlist8=new ArrayList<>();
        trendlist8=dm.getConstants("item",null);
        prod =(Spinner)findViewById(R.id.speccat);
        countries =(Spinner)findViewById(R.id.speccountry);
        setUpSpinner(prod,null,trendlist8);
        setUpSpinner(countries,menu,null);
        setup();
    }


    public void setUpSpinner(Spinner spfun,String [] menu,ArrayList<String> trendlist){
        ArrayAdapter adapter2;
        if(trendlist==null){
            adapter2=new ArrayAdapter(AddVendor.this,R.layout.support_simple_spinner_dropdown_item,menu);
        }else{
            adapter2=new ArrayAdapter(AddVendor.this,R.layout.support_simple_spinner_dropdown_item,trendlist);
        }

        spfun.setAdapter(adapter2);

    }


    public void setup(){

        prod.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item != null) {
                    product = item.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });

        countries.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item != null) {
                    country = item.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });

        final RoundedImage imgc=(RoundedImage)findViewById(R.id.vimage);
        FloatingActionButton mp=(FloatingActionButton)findViewById(R.id.add);
        mp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                add();

            }
        });
        FloatingActionButton mpr=(FloatingActionButton)findViewById(R.id.proceed);
        mpr.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                addVendor();

            }
        });

        FloatingActionButton hp=(FloatingActionButton)findViewById(R.id.photo);
        hp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                basic.handlePhotos(imgc);
            }
        });
    }


    public void add(){
        Intent c=new Intent(AddVendor.this,NewProducts.class);
        startActivity(c);
    }
    public void proceed(){
        final View.OnClickListener add=new View.OnClickListener(){

            @Override
            public void onClick(View v) {
                Intent c=new Intent(AddVendor.this,Home.class);
                startActivity(c);

            }
        };

        View.OnClickListener notnow=new View.OnClickListener(){

            @Override
            public void onClick(View v) {
              //senddetails
            }
        };

        basic.showDetailedAlert("CONFIRM VENDOR","Please confirm that you want to add this vendor","ADD",notnow,"CANCEL",add);

    }

    public void addVendor(){
        basic.showAlert(basic.getImageString());
        if(name!=null&&phone!=null&&email!=null&&state!=null&&market!=null){
            if(name.trim().isEmpty()||phone.trim().isEmpty()||email.trim().isEmpty()||market.trim().isEmpty()){
            proceed();
            }else{
              basic.showAlert("Enter all details please");
            }
        }else{
              basic.showAlert("Enter all details please");
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_add_vendor, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_main) {
            Intent c=new Intent(AddVendor.this,Home.class);
            startActivity(c);
            return true;
        }
        if (id == R.id.action_view) {
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
}
