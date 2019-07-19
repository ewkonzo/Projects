package elegance.hasoft.com.elegance;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.BaseAdapter;
import android.widget.GridView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;


public class NewItems extends ActionBarActivity {
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
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_new_items);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.white);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setTitle(Html.fromHtml("<font color='black'>Add New Item</font>"));
        ab.setDisplayHomeAsUpEnabled(true);
        app=getSharedPreferences("settings",MODE_PRIVATE);
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        res=getResources();
        menu=res.getStringArray(R.array.newitems);
        Arrays.sort(menu);
        grid=(GridView)findViewById(R.id.gridView);
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
                String name=trendlist.get(+position).get("name");
                click(name);
            }
        });

    }


    public void click(String name){
        switch (name){

            case "User":
                Intent cvw=new Intent(NewItems.this,NewUser.class);
                startActivity(cvw);
                break;

            case "Vendor":
                Intent cv=new Intent(NewItems.this,AddVendor.class);
                startActivity(cv);
                break;

            case "Product":
                Intent cvb=new Intent(NewItems.this,NewProducts.class);
                startActivity(cvb);
                break;

            case "Group":
                Intent cvc=new Intent(NewItems.this,NewGroup.class);
                startActivity(cvc);
                break;

            case "Notes":
                Intent c=new Intent(NewItems.this,Notes.class);
                startActivity(c);
                break;

            default:
                Intent v=new Intent(NewItems.this,New.class);
                v.putExtra("type",name);
                startActivity(v);
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
            LayoutInflater li=NewItems.this.getLayoutInflater();
            convertView= li.inflate(R.layout.grid_round,null);
            String name=trendlist.get(+position).get("name");
            TextView t=(TextView)convertView.findViewById(R.id.menutext);
            t.setText(name);
            RoundedLetterView s=(RoundedLetterView)convertView.findViewById(R.id.menuimage);
            s.setTitleText((trendlist.get(+position).get("name").substring(0,1).toUpperCase()));
            s.setBackgroundColor(getResources().getColor(R.color.orange));
            return convertView;
        }
    };

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_new_items, menu);
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
