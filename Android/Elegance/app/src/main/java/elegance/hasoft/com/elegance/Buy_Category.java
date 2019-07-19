package elegance.hasoft.com.elegance;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
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
import java.util.HashMap;

import floatt.FloatingActionButton;


public class Buy_Category extends ActionBarActivity {
    Toolbar toolbar;
    GridView grid;
    ActionBar ab;
    String userid,usertoken,usercategory,type,itemm,category;
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
    Bundle extras;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_buy__category);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.blue);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setTitle("");
        //ab.setDisplayHomeAsUpEnabled(true);
        app=getSharedPreferences("settings",MODE_PRIVATE);
        edit=app.edit();
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        dm=new DataManager(this,1);
        grid=(GridView)findViewById(R.id.gridView);
        extras=getIntent().getExtras();
        TextView t=(TextView)findViewById(R.id.textView);
        String time=app.getString("currentcart",null);
        t.setText("What category of products do you want to buy from "+app.getString(time+"vendor",null));
        FloatingActionButton mpr=(FloatingActionButton)findViewById(R.id.proceed);
        mpr.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                proceed();

            }
        });

        FloatingActionButton mpV=(FloatingActionButton)findViewById(R.id.add);
        mpV.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
               add();

            }
        });
        res=getResources();
        menu=res.getStringArray(R.array.gendergroup);
        trendlist=new ArrayList<HashMap<String,String>>();
        for(int i=0;i<menu.length;i++) {
            HashMap <String,String> contact;
            contact = new HashMap<String,String>();
            contact.put("name", menu[i]);
            trendlist.add(contact);
        }
        grid.setAdapter(gridadapter);
        grid.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
             category= trendlist.get(+position).get("name");
             gridadapter.notifyDataSetChanged();
            }
        });
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
            LayoutInflater li=Buy_Category.this.getLayoutInflater();
            convertView= li.inflate(R.layout.grid_round,null);
            String name=trendlist.get(+position).get("name");
            TextView t=(TextView)convertView.findViewById(R.id.menutext);
            t.setText(name);
            RoundedLetterView s=(RoundedLetterView)convertView.findViewById(R.id.menuimage);
            s.setTitleText((trendlist.get(+position).get("name").substring(0,1).toUpperCase()));
            if(category!=null) {
                if (category.equalsIgnoreCase(trendlist.get(+position).get("name"))) {
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

    public void setUpSpinner(Spinner spfun,String [] menu,ArrayList<String> trendlist){
        ArrayAdapter adapter2;
        if(trendlist==null){
            adapter2=new ArrayAdapter(Buy_Category.this,R.layout.support_simple_spinner_dropdown_item,menu);
        }else{
            adapter2=new ArrayAdapter(Buy_Category.this,R.layout.support_simple_spinner_dropdown_item,trendlist);
        }

        spfun.setAdapter(adapter2);

    }

    public void add(){
        Intent c=new Intent(Buy_Category.this,New.class);
        startActivity(c);
    }
    public void proceed(){
        if(category==null||category.equalsIgnoreCase("")){
            basic.showAlert("No category selected");
        }else{
            String time=app.getString("currentcart","");
            edit.putString(time+"gendergroup",category);
            edit.commit();
            Intent c=new Intent(Buy_Category.this,Buy_Items.class);
            c.putExtra("id",time);
            startActivity(c);
        }

    }




    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_buy__category, menu);
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
            Intent c=new Intent(Buy_Category.this,Purchase_Cart.class);
            startActivity(c);
            return true;
        }
        if (id == R.id.action_home) {
            Intent c=new Intent(Buy_Category.this,Home.class);
            startActivity(c);
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
}
