package elegance.hasoft.com.elegance;

import android.content.SharedPreferences;
import android.content.res.Resources;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;
import android.widget.GridView;

import java.util.ArrayList;
import java.util.HashMap;


public class SetUp extends ActionBarActivity {
    Toolbar toolbar;
    GridView grid;
    ActionBar ab;
    String userid,usertoken,usercategory,email,pass;
    String [] menu;
    Resources res;
    AppBasics basic;
    NetDetector cd;
    Boolean netpresent=false;
    ServerCalls sc;
    SharedPreferences app;
    ArrayList<HashMap<String,String>> trendlist;
    ServiceHandler mServiceHandler;
    Constants con;
    private EditText eemail,epass;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_set_up);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.white);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setTitle(Html.fromHtml("<font color='black'>Set Up System</font>"));
        //ab.setDisplayHomeAsUpEnabled(true);
        app=getSharedPreferences("settings",MODE_PRIVATE);
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        netpresent=cd.isConnectingToInternet();
        if(netpresent) {
            sc.getconstants(true);
        }else{
            basic.showToast("Check your connection");
        }
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_set_up, menu);
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