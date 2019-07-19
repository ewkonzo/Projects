package elegance.hasoft.com.elegance;

import android.content.SharedPreferences;
import android.content.res.Resources;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.Spinner;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;

import floatt.FloatingActionButton;


public class New extends ActionBarActivity {
    Toolbar toolbar;
    GridView grid;
    ActionBar ab;
    String userid,usertoken,usercategory,type,itemm;
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
    DataManager dm;
    ArrayList<String> trendlist2;
    Bundle extras;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_new);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.white);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setDisplayHomeAsUpEnabled(true);
        app=getSharedPreferences("settings",MODE_PRIVATE);
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        res=getResources();
        dm=new DataManager(this,1);
        menu=res.getStringArray(R.array.items);
        trendlist2=new ArrayList<>();
        trendlist2=dm.getConstants("item", null);
        trendlist2.add("All");
        name=(EditText)findViewById(R.id.name);
        extras=getIntent().getExtras();
        if(extras!=null){
            TextView tc=(TextView)findViewById(R.id.textView1);
            TextView tv=(TextView)findViewById(R.id.textView2);
            type=extras.getString("type");
            ab.setTitle(Html.fromHtml("<font color='black'>Add New "+type+"</font>"));
            tc.setText("Enter The Name Of New "+type);
            tv.setText("Select The Category For This New "+type);
        }

        Spinner spfun2=(Spinner)findViewById(R.id.speccat);
        ArrayAdapter adapter22=new ArrayAdapter(New.this,R.layout.support_simple_spinner_dropdown_item,trendlist2);
        spfun2.setAdapter(adapter22);
        spfun2.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);
                if (item!= null){
                    itemm=item.toString();
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }
        });

        FloatingActionButton btn=(FloatingActionButton)findViewById(R.id.add);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                add(v);
            }
        });
    }

    public void add (View v){
        netpresent=cd.isConnectingToInternet();
        String ename=name.getText().toString();
        if(ename.trim().isEmpty()) {
            basic.showAlert("Please enter name of new item");
        }else{
            if(netpresent)
            sc.addnewitem(type,ename,itemm);
            else
            basic.showAlert("Check Internet Connection");
        }
    }



    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        //getMenuInflater().inflate(R.menu.menu_new, menu);
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
