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
import android.view.View;
import android.widget.EditText;
import android.widget.GridView;

import java.util.ArrayList;
import java.util.HashMap;

import floatt.FloatingActionButton;

public class NewProducts extends ActionBarActivity {
    Toolbar toolbar;
    GridView grid;
    ActionBar ab;
    String userid,usertoken,usercategory,type,itemm;
    String [] menu,items;
    Resources res;
    AppBasics basic;
    NetDetector cd;
    Boolean netpresent=false;
    SharedPreferences app;
    ArrayList<HashMap<String,String>> trendlist;
    ServiceHandler mServiceHandler;
    Constants con;
    FloatingActionButton done,addnew;
    ServerCalls sc;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_new_products);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.blue);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setTitle(Html.fromHtml("<font color='white'>Add New Product</font>"));
        ab.setDisplayHomeAsUpEnabled(true);
        sc=new ServerCalls(this);
        done=(FloatingActionButton)findViewById(R.id.save);
        done.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                addnote();

            }
        });
    }


    public void addnote(){
        EditText title=(EditText)findViewById(R.id.productname);
        EditText des=(EditText)findViewById(R.id.productdes);

        String nott=title.getText().toString();
        String notdes=des.getText().toString();
        if(nott!=null&&notdes!=null) {
            if (nott.trim().isEmpty() || notdes.trim().isEmpty()) {
                basic.showAlert("Please add a product");
            } else {
                sc.addnewitem("item", nott, "");
            }
        }else{
                basic.showAlert("Please add a product");
        }

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_new_products, menu);
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
            Intent c=new Intent(NewProducts.this,Home.class);
            startActivity(c);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
