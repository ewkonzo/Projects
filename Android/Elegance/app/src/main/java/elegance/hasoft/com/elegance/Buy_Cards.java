package elegance.hasoft.com.elegance;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import com.gc.materialdesign.views.ButtonFlat;
import com.gc.materialdesign.widgets.Dialog;

import java.text.DecimalFormat;
import java.util.ArrayList;

import floatt.FloatingActionButton;


public class Buy_Cards extends ActionBarActivity {
    Toolbar toolbar;
    ActionBar ab;
    String userid,usertoken,usercategory,type,itemm,category,id;
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
    String item,itemcategory,brand,color,size,pattern,cg,gg,fabric,price,discount,qunatity,vendor;
    double subtotal,balance=0;
    TextView t;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_buy__cards);
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
        res=getResources();
        t=(TextView)findViewById(R.id.textView);
        id=app.getString("currentcart",null);
        itemm=app.getString(id+"item",null);
        String tt=app.getString(id + "quantity", "0");
        t.setText(tt+" items in batch");
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


        ArrayList<String> trendlist2=new ArrayList<>();
        trendlist2=dm.getConstants("Color",itemm);
        final Spinner brsp=(Spinner)findViewById(R.id.speccolor);
        setUpSpinner(brsp,null,trendlist2);
        brsp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
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

    }


    public void setUpSpinner(Spinner spfun,String [] menu,ArrayList<String> trendlist){
        ArrayAdapter adapter2;
        if(trendlist==null){
            adapter2=new ArrayAdapter(Buy_Cards.this,R.layout.support_simple_spinner_dropdown_item,menu);
        }else{
            adapter2=new ArrayAdapter(Buy_Cards.this,R.layout.support_simple_spinner_dropdown_item,trendlist);
        }

        spfun.setAdapter(adapter2);

    }

    public void add(){
        EditText esize=(EditText)findViewById(R.id.editsize);
        EditText equantity=(EditText)findViewById(R.id.editquantity);
        esize.setText("");
        equantity.setText("");
    }
    public void proceed(){
        netpresent=cd.isConnectingToInternet();
        EditText esize=(EditText)findViewById(R.id.editsize);
        EditText equantity=(EditText)findViewById(R.id.editquantity);

        size=esize.getText().toString();
        qunatity=equantity.getText().toString();
        if(size.trim().isEmpty()||qunatity.trim().isEmpty()) {
            basic.showAlert("Please All Details");
        }else{

            String id=app.getString("currentcart",null);
            final int price=Integer.parseInt(app.getString(id + "price", "0"));
            final int batchsize=Integer.parseInt(app.getString(id + "quantity", "0"));
            double q=Double.parseDouble(qunatity);

            DecimalFormat df=new DecimalFormat("###.##");
            DecimalFormat df2=new DecimalFormat("###");
            double c=q/batchsize;
            double total= Double.parseDouble(df.format(c * price));
            double newprice=price/batchsize;


            balance =batchsize-subtotal;



            if(q>batchsize||q>balance){
                basic.showAlert("Not enough items in batch to add "+q+" items.You have "+df2.format(balance)+" items remaining in your batch");
            }else {
            //basic.showAlert("c="+c+",,,,total:"+total+",,,,price:"+price);
                long x = dm.insertPurchaseCart(app.getString("currentcart", null), app.getString(id + "item", null),
                        qunatity, newprice + "", "0", total + "", app.getString(id + "brand", null), color, size, app.getString(id + "pattern", null), app.getString(id + "gendergroup", null), app.getString(id + "fabric", null), app.getString(id + "subitem", null), app.getString(id + "vendor", null));

                basic.showToast(x + "");

                subtotal=subtotal+q;
                balance =batchsize-subtotal;

                View.OnClickListener add = new View.OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        add();
                    }
                };


                View.OnClickListener newitem = new View.OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        Intent c = new Intent(Buy_Cards.this, Buy.class);
                        startActivity(c);
                    }
                };

                View.OnClickListener viewcart = new View.OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        Intent c = new Intent(Buy_Cards.this, Purchase_Cart.class);
                        startActivity(c);
                    }
                };
                  String v=null;
                if (subtotal == batchsize) {
                    v="This part of the batch has been added.All batch items have now been added";
                    t.setText(batchsize+" items in batch.\n\n"+subtotal+" added to cart.\n\n"+balance+" remaining in batch");

                } else {
                    v="This part of the batch has been added to cart." + balance + " items remaining in the batch";
                    t.setText(batchsize+" items in batch.\n\n"+subtotal+" added to cart.\n\n"+balance+" remaining in batch");
                }

                    final Dialog dialog = new Dialog(Buy_Cards.this,"New Items", v,"VIEW CART");
                    dialog.show();


                    ButtonFlat acceptButton = dialog.getButtonAccept();
                    acceptButton.setText("VIEW CART");
                    ButtonFlat cancelButton = dialog.getButtonCancel();
                    cancelButton.setText("PROCEED");
                    dialog.setOnCancelButtonClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            add();
                            dialog.dismiss();
                        }
                    });
                    dialog.setOnAcceptButtonClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            Intent c = new Intent(Buy_Cards.this, Purchase_Cart.class);
                            startActivity(c);
                        }
                    });

            }

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
        if (id == R.id.action_cartstatus) {
            basic.displayPurchase();
            return true;
        }

        if (id == R.id.action_viewcart) {
            Intent c=new Intent(Buy_Cards.this,Purchase_Cart.class);
            startActivity(c);
            return true;
        }

        if (id == R.id.action_home) {
            Intent c=new Intent(Buy_Cards.this,Home.class);
            startActivity(c);
            return true;
        }


        return super.onOptionsItemSelected(item);
    }
}
