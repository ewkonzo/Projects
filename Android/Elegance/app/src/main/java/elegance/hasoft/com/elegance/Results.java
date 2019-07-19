package elegance.hasoft.com.elegance;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.HashMap;


public class Results extends ActionBarActivity {
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
    ArrayList<HashMap<String,String>> trendlist;
    ServiceHandler mServiceHandler;
    Constants con;
    EditText name;
    ListView list;
    Bundle extras;
    String item,subitem,type;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_results);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.white);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();

        app=getSharedPreferences("settings",MODE_PRIVATE);
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        list=(ListView)findViewById(R.id.listSearch);
        extras=getIntent().getExtras();
        if(extras!=null){
           type=extras.getString("type");
           item=extras.getString("item");
           subitem=extras.getString("subitem");
            if(type.equalsIgnoreCase("search")) {
                ab.setTitle(Html.fromHtml("<font color='black'>Search Results ("+item+")</font>"));
                getfromsearch();
            }else {
                if (type.equalsIgnoreCase("subitem"))
                    ab.setTitle(Html.fromHtml("<font color='black'>"+item+" > "+subitem+"</font>"));
                    getfromsubitem();
            }
        }

    }

    public void getfromsubitem(){
        netpresent=cd.isConnectingToInternet();
            if (netpresent) {
                sc.getitemfromsubitem(item,list,subitem);
            } else {
                basic.showToast("Check your connection");
            }
    }

    public void getfromsearch(){
        netpresent=cd.isConnectingToInternet();
        if (netpresent) {
            sc.getitemfromsearch(item,list);
        } else {
            basic.showToast("Check your connection");
        }
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
       getMenuInflater().inflate(R.menu.menu_results, menu);
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
            Intent c=new Intent(Results.this,Search.class);
            startActivity(c);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
