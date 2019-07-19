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
import android.widget.BaseAdapter;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.ListView;
import android.widget.TextView;

import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.HashMap;


public class Search extends ActionBarActivity {
    Toolbar toolbar;
    GridView grid;
    ActionBar ab;
    String userid,usertoken,usercategory,type,itemm,query;
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
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_search);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
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
        grid=(GridView)findViewById(R.id.gridView);
        res=getResources();
        menu=res.getStringArray(R.array.itemscats);
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
                Intent cv=new Intent(Search.this,SubItem.class);
                cv.putExtra("item",trendlist.get(+position).get("name"));
                startActivity(cv);
            }
        });
    }


    public void search(View v){
        netpresent=cd.isConnectingToInternet();
        EditText ed=(EditText)findViewById(R.id.search);
        query=ed.getText().toString();
        if(query.trim().isEmpty()){
            basic.showAlert("Please enter something to search");
        }else {
            if (netpresent) {
                query= URLEncoder.encode(query.trim());
                Intent cv=new Intent(Search.this,Results.class);
                cv.putExtra("subitem","");
                cv.putExtra("item",query);
                cv.putExtra("type","search");
                startActivity(cv);
            } else {
                basic.showAlert("Check your connection");
            }
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
            LayoutInflater li=Search.this.getLayoutInflater();
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
       // getMenuInflater().inflate(R.menu.menu_search, menu);
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
