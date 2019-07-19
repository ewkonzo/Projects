package elegance.hasoft.com.elegance;

import android.content.SharedPreferences;
import android.content.res.Resources;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.EditText;

import java.util.ArrayList;

import floatt.FloatingActionButton;


public class Add_Customer extends ActionBarActivity {
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
    String item,name,phone,email;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_add__customer);
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

        FloatingActionButton mpr=(FloatingActionButton)findViewById(R.id.proceed);
        mpr.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                proceed();

            }
        });
    }


    public void proceed(){
        netpresent=cd.isConnectingToInternet();
        EditText ename=(EditText)findViewById(R.id.editname);
        EditText eemail=(EditText)findViewById(R.id.editemail);
        EditText ephone=(EditText)findViewById(R.id.editphone);

        name=ename.getText().toString();
        email=eemail.getText().toString();
        phone=ephone.getText().toString();
        if(name.trim().isEmpty()||email.trim().isEmpty()||phone.trim().isEmpty()){
            basic.showAlert("Enter all details");
        }else{
            sc.addcustomer(name,phone,email);
        }


    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_add__customer, menu);
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
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
