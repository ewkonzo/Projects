package elegance.hasoft.com.elegance;

import android.content.SharedPreferences;
import android.content.res.Resources;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.Spinner;

import java.util.ArrayList;
import java.util.HashMap;


public class Purchase extends ActionBarActivity {
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
    String item,itemcategory,brand,color,size,pattern,cg,gg,fabric,price,discount,qunatity,vendor;
    DataManager dm;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_purchase);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.white);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setTitle(Html.fromHtml("<font color='black'>Purchase A Product</font>"));
        ab.setDisplayHomeAsUpEnabled(true);
        app=getSharedPreferences("settings",MODE_PRIVATE);
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        dm=new DataManager(this,1);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        res=getResources();
        menu=res.getStringArray(R.array.items);
        items=res.getStringArray(R.array.itemscats);
        setup();
    }


    public void setup(){

        Spinner itemsp=(Spinner)findViewById(R.id.spectype);
        setUpSpinner(itemsp, items, null);
        itemsp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object itemx = parent.getItemAtPosition(position);

                if (itemx != null) {
                    item = itemx.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });


        //itemcategory
        ArrayList<String> trendlist=new ArrayList<>();
        trendlist=dm.getConstants("SubItem", item);
        Spinner catsp=(Spinner)findViewById(R.id.speccat);
        setUpSpinner(catsp,null,trendlist);
        catsp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item!= null){
                    itemcategory = item.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });


        //itembrand
        ArrayList<String> trendlist2=new ArrayList<>();
        trendlist2=dm.getConstants("Brand",item);
        final Spinner brsp=(Spinner)findViewById(R.id.specbrand);
        setUpSpinner(brsp,null,trendlist2);
        brsp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item!= null){
                    brand = item.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });

        //itemcolor
        ArrayList<String> trendlist3=new ArrayList<>();
        trendlist3=dm.getConstants("Color",item);
        Spinner colorsp=(Spinner)findViewById(R.id.speccolor);
        setUpSpinner(colorsp,null,trendlist3);
        colorsp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item!= null){
                    color = item.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });


        //itemPattern
        ArrayList<String> trendlist4=new ArrayList<>();
        trendlist4=dm.getConstants("Pattern",item);
        Spinner ptsp=(Spinner)findViewById(R.id.specpattern);
        setUpSpinner(ptsp,null,trendlist4);
        ptsp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item!= null){
                    pattern= item.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });


        //itemConsumer
        ArrayList<String> trendlist5=new ArrayList<>();
        trendlist5=dm.getConstants("Consumer-Group",item);
        Spinner csp=(Spinner)findViewById(R.id.speccg);
        setUpSpinner(csp,null,trendlist5);
        csp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item!= null){
                    cg = item.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });


        //itemGroup
        ArrayList<String> trendlist6=new ArrayList<>();
        trendlist6=dm.getConstants("Gender-Group",item);
        Spinner ggsp=(Spinner)findViewById(R.id.specgg);
        setUpSpinner(ggsp,null,trendlist6);
        ggsp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item!= null){
                    gg = item.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });


        //itemFabric
        ArrayList<String> trendlist7=new ArrayList<>();
        trendlist7=dm.getConstants("Fabric",item);
        Spinner fabsp=(Spinner)findViewById(R.id.specfab);
        setUpSpinner(fabsp,null,trendlist7);
        fabsp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item!= null){
                    fabric = item.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });

        //itemVendor
        ArrayList<String> trendlist8=new ArrayList<>();
        trendlist8=dm.getConstants("Vendor",item);
        Spinner ven=(Spinner)findViewById(R.id.specvendor);
        setUpSpinner(ven,null,trendlist8);
        ven.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);

                if (item!= null){
                    vendor = item.toString();

                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }


        });


        Button btn=(Button)findViewById(R.id.add);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                add(v);
            }
        });

    }

    public void add (View v){
        netpresent=cd.isConnectingToInternet();
        EditText eprice=(EditText)findViewById(R.id.editprice);
        EditText esize=(EditText)findViewById(R.id.editsize);
        EditText edis=(EditText)findViewById(R.id.editdiscount);
        EditText equantity=(EditText)findViewById(R.id.editquantity);
        price=eprice.getText().toString();
        size=esize.getText().toString();
        discount=edis.getText().toString();
        qunatity=equantity.getText().toString();
        int total=Integer.parseInt(qunatity)*Integer.parseInt(price);

        if(price.trim().isEmpty()||size.trim().isEmpty()||discount.trim().isEmpty()||qunatity.trim().isEmpty()) {
            basic.showAlert("Please All Details");
        }else{
            if(netpresent)
                sc.purchase(qunatity,vendor,item,itemcategory,brand,color,size,pattern,cg,gg,fabric,price,discount,total+"");
            else
                basic.showAlert("Check Internet Connection");
        }
    }



    public void setUpSpinner(Spinner spfun,String [] menu,ArrayList<String> trendlist){
        ArrayAdapter adapter2;
        if(trendlist==null){
          adapter2=new ArrayAdapter(Purchase.this,R.layout.support_simple_spinner_dropdown_item,menu);
        }else{
          adapter2=new ArrayAdapter(Purchase.this,R.layout.support_simple_spinner_dropdown_item,trendlist);
        }

        spfun.setAdapter(adapter2);

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
       // getMenuInflater().inflate(R.menu.menu_purchase, menu);
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
