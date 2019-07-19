package elegance.hasoft.com.elegance;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.os.Bundle;
import android.support.v4.widget.SwipeRefreshLayout;
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
import android.widget.ListView;
import android.widget.ScrollView;
import android.widget.Spinner;

import java.util.ArrayList;
import java.util.HashMap;

import floatt.FloatingActionButton;


public class Expenses extends ActionBarActivity {
    Toolbar toolbar;
    ListView listView;
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
    DataManager dm;
    private SwipeRefreshLayout swipeContainer;
    ScrollView scrollView;
    FloatingActionButton done,addnew;
    String expensetype;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Base_Theme_AppCompat_Light);
        setContentView(R.layout.activity_expenses);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.green);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setTitle(Html.fromHtml("<font color='white'>Expenses</font>"));
        ab.setDisplayHomeAsUpEnabled(true);
        basic=new AppBasics(this);
        dm=new DataManager(this,1);
        sc=new ServerCalls(this);
        listView=(ListView)findViewById(R.id.listnotes);
        scrollView=(ScrollView)findViewById(R.id.scrollView1);
        listView.setVisibility(View.GONE);
        trendlist=new ArrayList<HashMap<String,String>>();
        res=getResources();
        menu=res.getStringArray(R.array.expenses);
        swipeContainer = (SwipeRefreshLayout) findViewById(R.id.swipeContainer);
        swipeContainer.setOnRefreshListener(new SwipeRefreshLayout.OnRefreshListener() {

            @Override

            public void onRefresh() {
                myexpenses();
            }

        });


        addnew=(FloatingActionButton)findViewById(R.id.add);
        addnew.setBackgroundResource(R.color.green);
        addnew.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                newexpense();

            }
        });


        done=(FloatingActionButton)findViewById(R.id.save);
        done.setBackgroundResource(R.color.green);
        done.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                addexpense();

            }
        });

        done.setVisibility(View.VISIBLE);

        final Spinner brsp=(Spinner)findViewById(R.id.specexpensetype);
        setUpSpinner(brsp,menu,null);
        brsp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item!= null){
                    expensetype = item.toString();
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });
    }

    public void setUpSpinner(Spinner spfun,String [] menu,ArrayList<String> trendlist){
        ArrayAdapter adapter2;
        if(trendlist==null){
            adapter2=new ArrayAdapter(Expenses.this,R.layout.support_simple_spinner_dropdown_item,menu);
        }else{
            adapter2=new ArrayAdapter(Expenses.this,R.layout.support_simple_spinner_dropdown_item,trendlist);
        }

        spfun.setAdapter(adapter2);

    }

    public void myexpenses(){
        listView.setVisibility(View.VISIBLE);
        scrollView.setVisibility(View.GONE);
        swipeContainer.setRefreshing(false);
        addnew.setVisibility(View.VISIBLE);
        done.setVisibility(View.GONE);
        sc.getexpenses(listView);
    }


    public void newexpense(){
        listView.setVisibility(View.GONE);
        scrollView.setVisibility(View.VISIBLE);
        addnew.setVisibility(View.GONE);
        done.setVisibility(View.VISIBLE);
        EditText eamount=(EditText)findViewById(R.id.editamount);
        EditText edes=(EditText)findViewById(R.id.editdes);
        eamount.setText("");
        edes.setText("");
    }





    public void addexpense(){
        EditText eamount=(EditText)findViewById(R.id.editamount);
        EditText edes=(EditText)findViewById(R.id.editdes);

        String des=edes.getText().toString();
        String amount=eamount.getText().toString();
        if(des.trim().isEmpty()||amount.trim().isEmpty()){
            basic.showAlert("Please add an expense");
        }else{
            sc.addexpense(expensetype,des,amount);
        }

    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_expenses, menu);
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
            Intent c = new Intent(Expenses.this, Home.class);
            startActivity(c);
            return true;
        }


        if (id == R.id.action_myexpenses) {
            myexpenses();
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
