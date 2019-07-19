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
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;


public class Home extends ActionBarActivity {
    Toolbar toolbar;
    GridView grid;
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
        setContentView(R.layout.activity_home);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        grid=(GridView)findViewById(R.id.gridView);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        app=getSharedPreferences("settings",MODE_PRIVATE);
        ab.setTitle("Hi, "+app.getString("names",null));
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        res=getResources();
        menu=res.getStringArray(R.array.menu);
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

        RoundedLetterView s=(RoundedLetterView)findViewById(R.id.imageView);

        s.setTitleText(usercategory.substring(0,1).toUpperCase());
        loadnotes();

    }


    public void loadnotes(){
        sc.getnotes();
    }

    public boolean isAdmin(){
        if(usercategory.equalsIgnoreCase("admin")){
            return true;
        }else{
            return false;
        }
    }


    public void displaySwitch(){
        final MaterialDialog alert=new MaterialDialog(Home.this);
        alert.setMessage("You do not have administrative rights to perform this action.Enable this by switching to Admin");
        alert.setNegativeButton("Switch User",new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                alert.dismiss();
            }
        });
        alert.setPositiveButton("Cancel", new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                alert.dismiss();
            }
        });

        alert.show();
    }

    public void click(String name){
        switch (name){
            case "Purchase":
                if(isAdmin()){
                    sc.getconstants(false);
               }
                else {
                    displaySwitch();
                }
                break;

            case "Sales":
                Intent cvw=new Intent(Home.this,Sale.class);
                startActivity(cvw);
                break;

            case "Inventory":
                Intent cv=new Intent(Home.this,Search.class);
                startActivity(cv);
                break;

            case "Reports":
                if(isAdmin()){
                    Intent cvVw=new Intent(Home.this,Reports.class);
                    cvVw.putExtra("type","reports");
                    startActivity(cvVw);}
                else {
                    displaySwitch();
                }
                break;

            case "New":
                if(isAdmin()) {
                    Intent c = new Intent(Home.this, NewItems.class);
                    startActivity(c);
                }else{
                    displaySwitch();
                }
                break;
            case "Extras":
                Intent cw=new Intent(Home.this,Extras.class);
                startActivity(cw);
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
            LayoutInflater li=Home.this.getLayoutInflater();
            convertView= li.inflate(R.layout.gridlayout,null);
            String name=trendlist.get(+position).get("name");
            TextView t=(TextView)convertView.findViewById(R.id.menutext);
            ImageView s=(ImageView)convertView.findViewById(R.id.menuimage);
            image(name,s);
            t.setText(name);
            return convertView;
        }
    };


    public void image(String name,ImageView img){
        switch (name){
            case "Purchase":
            img.setImageResource(R.drawable.purchase);
                break;

            case "Sales":
                img.setImageResource(R.drawable.sales);
                break;

            case "Inventory":
                img.setImageResource(R.mipmap.extras);
                break;

            case "Reports":
                img.setImageResource(R.drawable.reports);
                break;

            case "New":
                img.setImageResource(R.mipmap.rounded54);
                break;
            case "Extras":
                img.setImageResource(R.drawable.extras);
                break;
            default:;
                break;


        }

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_home, menu);
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
            Intent cvwd=new Intent(Home.this,SwitchUser.class);
            startActivity(cvwd);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
