package elegance.hasoft.com.elegance;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.GridView;
import android.widget.Spinner;
import android.widget.TextView;

import java.util.ArrayList;

import floatt.FloatingActionButton;


public class Buy extends ActionBarActivity {
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
    ArrayList<String> trendlist;
    ServiceHandler mServiceHandler;
    Constants con;
    DataManager dm;
    Spinner ven;
    VendorDialog vendorDialog;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_buy);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.white);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setTitle(Html.fromHtml("<font color='white'>Choose Vendor</font>"));
        ab.setDisplayHomeAsUpEnabled(true);
        app=getSharedPreferences("settings",MODE_PRIVATE);
        edit=app.edit();
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        dm=new DataManager(this,1);
        trendlist=new ArrayList<>();
        trendlist=dm.getConstants("Vendor",null);
        if(trendlist.size()==0){

        View.OnClickListener add=new View.OnClickListener(){

                @Override
                public void onClick(View v) {
        Intent c=new Intent(Buy.this,Home.class);
        startActivity(c);

                }
            };

            View.OnClickListener notnow=new View.OnClickListener(){

                @Override
                public void onClick(View v) {
                    Intent c=new Intent(Buy.this,SetUp.class);
                    startActivity(c);
                }
            };

            basic.showDetailedAlert("SETUP INCOMPLETE","Seems like set up did not complete successfully.No vendors available.Click + to add new vendor","SET UP",notnow,"CANCEL",add);


        }else{
            grid.setAdapter(gridadapter);
            grid.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                @Override
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                    vendor= trendlist.get(+position);


                    gridadapter.notifyDataSetChanged();
                }
            });
           setup();
        }
    }


    BaseAdapter gridadapter=new BaseAdapter() {
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
            LayoutInflater li=Buy.this.getLayoutInflater();
            convertView= li.inflate(R.layout.grid_round,null);
            String name=trendlist.get(+position);
            TextView t=(TextView)convertView.findViewById(R.id.menutext);
            t.setText(name);
            RoundedLetterView s=(RoundedLetterView)convertView.findViewById(R.id.menuimage);
            s.setTitleText((trendlist.get(+position).substring(0,1).toUpperCase()));
            if(vendor!=null) {
                if (vendor.equalsIgnoreCase(trendlist.get(+position))) {
                    s.setBackgroundColor(getResources().getColor(R.color.green));
                } else {
                    s.setBackgroundColor(getResources().getColor(R.color.orange));
                }
            }else{
                s.setBackgroundColor(getResources().getColor(R.color.orange));
            }
            return convertView;
        }
    };


    public void setup(){
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
                proceed();

            }
        });
    }


    public void setUpSpinner(Spinner spfun,String [] menu,ArrayList<String> trendlist){
        ArrayAdapter adapter2;
        if(trendlist==null){
            adapter2=new ArrayAdapter(Buy.this,R.layout.support_simple_spinner_dropdown_item,menu);
        }else{
            adapter2=new ArrayAdapter(Buy.this,R.layout.support_simple_spinner_dropdown_item,trendlist);
        }

        spfun.setAdapter(adapter2);

    }

    public void add(){
        Intent c=new Intent(Buy.this,AddVendor.class);
        startActivity(c);
    }
    public void proceed(){
        if(vendor==null||vendor.equalsIgnoreCase("")){
            basic.showAlert("No vendor selected.Click the add button to add a new vendor");
        }else{
            long time=System.currentTimeMillis();
            edit.putString(time+"vendor",vendor);
            edit.putString("currentcart",time+"");
            edit.commit();
            Intent c=new Intent(Buy.this,Buy_Category.class);
            c.putExtra("id",time);
            startActivity(c);
        }

    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
       getMenuInflater().inflate(R.menu.menu_buy, menu);
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

        if (id == R.id.action_cartstatus) {
            basic.displayPurchase();
            return true;
        }

        if (id == R.id.action_viewcart) {
            Intent c=new Intent(Buy.this,Purchase_Cart.class);
            startActivity(c);
            return true;
        }


        if (id == R.id.action_home) {
            Intent c=new Intent(Buy.this,Home.class);
            startActivity(c);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
