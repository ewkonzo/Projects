package elegance.hasoft.com.elegance;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.graphics.Color;
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
import android.widget.BaseAdapter;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;


public class Extras extends ActionBarActivity {
    Toolbar toolbar;
    ListView list;
    ActionBar ab;
    String userid,usertoken,usercategory;
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
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_extras);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.green);
        list=(ListView)findViewById(R.id.listSearch);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setTitle("EXTRAS");
        ab.setDisplayHomeAsUpEnabled(true);
        app=getSharedPreferences("settings",MODE_PRIVATE);
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        res=getResources();
        menu=res.getStringArray(R.array.extras);
        trendlist=new ArrayList<HashMap<String,String>>();
        for(int i=0;i<menu.length;i++) {
            HashMap <String,String> contact;
            contact = new HashMap<String,String>();
            contact.put("name", menu[i]);
            trendlist.add(contact);
        }
        list.setAdapter(gridadapter);
        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                String name = trendlist.get(+position).get("name");
                click(name);
            }
        });

    }


    public void click(String name){
        switch (name){
            case "Switch User":
                Intent cvwd=new Intent(Extras.this,SwitchUser.class);
                startActivity(cvwd);
                break;

            case "Sync App":
                Intent cvw=new Intent(Extras.this,SetUp.class);
                startActivity(cvw);
                break;

            case "Update Discount":
                Intent c=new Intent(Extras.this,Discount.class);
                startActivity(c);
                break;


            case "Exchange Rate":
                Intent cc=new Intent(Extras.this,ExchangeRate.class);
                startActivity(cc);
                break;

            case "Manage Users":
                Intent cvVw=new Intent(Extras.this,Users.class);
                cvVw.putExtra("type","users");
                startActivity(cvVw);
                break;
            case "Notes":
                Intent e=new Intent(Extras.this,Notes.class);
                startActivity(e);
                break;

            case "View Customers":
                Intent ca=new Intent(Extras.this,Reports.class);
                ca.putExtra("type","customers");
                startActivity(ca);
                break;

            case "Expenses":
                Intent cae=new Intent(Extras.this,Expenses.class);
                startActivity(cae);
                break;

            default:;
                break;


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
            LayoutInflater li=Extras.this.getLayoutInflater();
            convertView= li.inflate(R.layout.itemlist,null);
            String name=trendlist.get(+position).get("name");
            TextView t=(TextView)convertView.findViewById(R.id.textView2);
            RoundedLetterView s=(RoundedLetterView)convertView.findViewById(R.id.imageView);
            s.setBackgroundColor(getResources().getColor(R.color.green));
            s.setTitleText((trendlist.get(+position).get("name").substring(0, 1).toUpperCase()));
            t.setText(name);
            t.setTextColor(Color.BLACK);
            return convertView;
        }
    };





    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
       // getMenuInflater().inflate(R.menu.menu_extras, menu);
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
