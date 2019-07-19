package elegance.hasoft.com.elegance;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.graphics.Typeface;
import android.net.Uri;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;

import floatt.FloatingActionButton;


public class Browse extends ActionBarActivity {
    Toolbar toolbar;
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
    ArrayList<String> trendlist;
    ServiceHandler mServiceHandler;
    Constants con;
    DataManager dm;
    Bundle extras;
    String item,phone,email,id,title,notdes;
    TextView names,des,xtra;
    FloatingActionButton deleteN,assignN,callN,emailN;
    RelativeLayout r;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_browse);
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
        type=extras.getString("type");
        names=(TextView)findViewById(R.id.textname);
        names.setTypeface(Typeface.DEFAULT_BOLD);
        des=(TextView)findViewById(R.id.textdes);
        xtra=(TextView)findViewById(R.id.textextra);
        callN=(FloatingActionButton)findViewById(R.id.call);
        r=(RelativeLayout)findViewById(R.id.r);
        callN.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                call();

            }
        });
        emailN=(FloatingActionButton)findViewById(R.id.email);
        emailN.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                sendemail();

            }
        });


        deleteN=(FloatingActionButton)findViewById(R.id.delete);
        deleteN.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                deletenote();

            }
        });
        assignN=(FloatingActionButton)findViewById(R.id.assign);
        assignN.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                assignnote();

            }
        });

        setup();
    }


    public void call (){
        // EditText eownerphone=(EditText)findViewById(R.id.editOwnerE);
        if(phone==null){
            basic.showAlert("Cannot make this call right now.No phone number");
        }else{
            Intent phoneIntent = new Intent(Intent.ACTION_CALL);
            phoneIntent.setData(Uri.parse("tel:" + phone));
            try {
                startActivity(phoneIntent);
            } catch (android.content.ActivityNotFoundException ex) {
                basic.showAlert("Cannot make this call right now.Try again later");
            }
        }
    }



    public void deletenote(){
        if(id==null){
            basic.showAlert("A problem occured when deleting this note");
        }else{
            dm.removeNote(id);
            Intent c=new Intent(Browse.this,Notes.class);
            startActivity(c);
        }
    }


    public void assignnote(){
        if(title.trim().isEmpty()||notdes.trim().isEmpty()){
            basic.showAlert("Please add a full note");
        }else {
            Intent c = new Intent(Browse.this, Reports.class);
            c.putExtra("type", "assign");
            c.putExtra("title", title);
            c.putExtra("des", notdes);
            startActivity(c);
        }
    }


    public void sendemail(){
        if(email==null){
            basic.showAlert("Cannot make this call right now.No phone number");
        }else{
            Intent emailIntent = new Intent(Intent.ACTION_SEND);
            emailIntent.setData(Uri.parse("mailto:" + phone));
            emailIntent.setType("text/plain");
            try {
                startActivity(emailIntent);
            } catch (android.content.ActivityNotFoundException ex) {
                basic.showAlert("Cannot make this call right now.Try again later");
            }
        }
    }


    public void setup(){
        if(type.equalsIgnoreCase("user")){
            r.setBackgroundResource(R.color.orange);
            toolbar.setBackgroundResource(R.color.orange);
            callN.setVisibility(View.VISIBLE);
            emailN.setVisibility(View.VISIBLE);
        String name=extras.getString("name");
        id=extras.getString("id");
        email=extras.getString("email");
        String category=extras.getString("category");
        phone=extras.getString("phonenumber");
        names.setText(name);
        des.setText(category+"\n\n\n"+email+"\n\n"+phone);
        }


        if(type.equalsIgnoreCase("notes")){
            r.setBackgroundResource(R.color.orange);
            toolbar.setBackgroundResource(R.color.orange);
            assignN.setVisibility(View.VISIBLE);
            deleteN.setVisibility(View.VISIBLE);
            id=extras.getString("id");
            title=extras.getString("title");
            notdes=extras.getString("notdes");
            names.setText(title);
            des.setText(notdes);
            String user=extras.getString("user");
            String time=extras.getString("time");
            TimeCalculator tm=new TimeCalculator();
            xtra.setText("Added "+tm.getDuration(time));
        }


        if(type.equalsIgnoreCase("item")){
            r.setBackgroundResource(R.color.orange);
            toolbar.setBackgroundResource(R.color.orange);
            id=extras.getString("itemid");
            title=extras.getString("itemname");
            String sub=extras.getString("subitem");
            notdes=extras.getString("quantity");
            names.setText(title+" > "+sub);
            des.setText("Quantity in store : "+notdes);
            setupitem();
        }

    }



    public void setupitem(){
/*
Intent c=new Intent(act,Browse.class);
        c.putExtra("type","item");
        c.putExtra("itemid",trendlist.get(+position).get("itemcode"));
        c.putExtra("itemname",trendlist.get(+position).get("item"));
        c.putExtra("photo",trendlist.get(+position).get("photo"));
        c.putExtra("color",trendlist.get(+position).get("color"));
        c.putExtra("size",trendlist.get(+position).get("size"));
        c.putExtra("pattern",trendlist.get(+position).get("pattern"));
        c.putExtra("consumergroup",trendlist.get(+position).get("conumsergroup"));
        c.putExtra("gendergroup",trendlist.get(+position).get("gendergroup"));
        c.putExtra("fabric",trendlist.get(+position).get("fabric"));
        c.putExtra("unitprice",trendlist.get(+position).get("unitprice"));
        c.putExtra("quantity",trendlist.get(+position).get("quantity"));
        c.putExtra("total",trendlist.get(+position).get("total"));
        c.putExtra("brand",trendlist.get(+position).get("brand"));
 */
        ArrayList<HashMap<String,String>> itemprops=(ArrayList<HashMap<String,String>>)getIntent().getSerializableExtra("array");

        ArrayList<String> it=new ArrayList<>();
        it.add(0,extras.getString("size"));
        it.add(1,extras.getString("pattern"));
        it.add(2,extras.getString("fabric"));
        it.add(3,extras.getString("color"));
        it.add(4,extras.getString("brand"));
        LinearLayout x=(LinearLayout)findViewById(R.id.lay);

        for(int i=0;i<it.size();i++){
            String name=it.get(i);
            String w=null;
            if(i==0){
               w= "Size";
            }
            if(i==1){
                w= "Pattern";
            }
            if(i==2){
                w= "Fabric";
            }
            if(i==3){
                w= "Color";
            }
            if(i==4){
                w= "Brand";
            }

            LinearLayout card=new LinearLayout(Browse.this);
            card.setOrientation(LinearLayout.VERTICAL);
            card.setBackgroundResource(R.drawable.card_orange);
            card.setMinimumHeight(60);
            TextView ttype=new TextView(Browse.this);
            ttype.setText(w);
            ttype.setTextColor(getResources().getColor(R.color.white));
            ttype.setTypeface(Typeface.DEFAULT_BOLD);
            card.addView(ttype);
            TextView tdes=new TextView(Browse.this);
            tdes.setText(name);
            tdes.setTextColor(getResources().getColor(R.color.white));
            card.addView(tdes);
            x.addView(card,new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MATCH_PARENT, LinearLayout.LayoutParams.WRAP_CONTENT));

        }









    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_browse, menu);
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
            Intent c = new Intent(Browse.this, Home.class);
            startActivity(c);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
