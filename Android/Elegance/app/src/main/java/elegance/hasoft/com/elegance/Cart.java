package elegance.hasoft.com.elegance;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
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
import android.widget.EditText;
import android.widget.GridView;
import android.widget.ListView;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;

import floatt.FloatingActionButton;


public class Cart extends ActionBarActivity {
    Toolbar toolbar;
    GridView grid;
    ActionBar ab;
    String userid,usertoken,usercategory,itemm,query;
    String [] menu,items;
    Resources res;
    AppBasics basic;
    NetDetector cd;
    Boolean netpresent=false;
    ServerCalls sc;
    SharedPreferences app;
    ServiceHandler mServiceHandler;
    Constants con;
    EditText name;
    ListView list;
    Bundle extras;
    String item,subitem,type;
    DataManager dm;
    TextView cartstatus;
    TextView carttotal;
    ArrayList<HashMap<String,String>> trendlist;
    String productsarray;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cart);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setDisplayHomeAsUpEnabled(true);
        ab.setTitle(Html.fromHtml("<font color='white'>Cart</font>"));
        app=getSharedPreferences("settings",MODE_PRIVATE);
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        list=(ListView)findViewById(R.id.listSearch);
        extras=getIntent().getExtras();
        dm=new DataManager(this,1);
        cartstatus=(TextView)findViewById(R.id.cartstatus);
        carttotal=(TextView)findViewById(R.id.carttotal);
        basic.updateCart(cartstatus,carttotal);

        if(dm.checkCartNumber()>0){
            loadcart();
        }else{
            basic.showAlert("No item in cart currently");
        }

        FloatingActionButton mp=(FloatingActionButton)findViewById(R.id.viewcart);
        mp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent x=new Intent(Cart.this,Cart.class);
                startActivity(x);
            }
        });

        FloatingActionButton r=(FloatingActionButton)findViewById(R.id.clearcart);
        r.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                final MaterialDialog alert=new MaterialDialog(Cart.this);
                alert.setTitle("CLEAR CART");
                alert.setMessage("Are you sure you want to clear the current cart?");
                alert.setPositiveButton("Ok",new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        dm.clearCart();
                        basic.updateCart(cartstatus,carttotal);
                        alert.dismiss();
                        basic.showAlert("Cart successfully cleared");
                    }
                });

                alert.setNegativeButton("CANCEL",new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        alert.dismiss();
                    }
                });
                alert.show();

            }
        });

    }

    public void loadcart(){
            sc.loadCart(list,cartstatus,carttotal);
    }


    public void submit(){
        trendlist=new ArrayList<HashMap<String,String>>();
        trendlist=dm.getCart();
        JSONObject main=new JSONObject();
        JSONArray array=new JSONArray();
        for (int i=0;i<trendlist.size();i++){
            JSONObject object=new JSONObject();
            try {
                object.put("inventory_id",trendlist.get(i).get("inventory_id"));
                object.put("quantity",trendlist.get(i).get("quantity"));
                object.put("total",trendlist.get(i).get("total"));
                object.put("selling_price",trendlist.get(i).get("sellingprice"));
            } catch (JSONException e) {
                e.printStackTrace();
            }
            array.put(object);
        }

        try {
            main.put("products",array);
        } catch (JSONException e) {
            e.printStackTrace();
        }

        productsarray=main.toString();
        basic.showAlert(productsarray);
        sc.makeSale(productsarray,"56");

    }




    public void customercode(){
        AlertDialog.Builder alertb = new AlertDialog.Builder(Cart.this, AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
        alertb.setMessage("Enter Customer Code");
        final EditText input=new EditText(Cart.this);
        input.setEnabled(false);
        alertb.setView(input);
        alertb.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                String value = input.getText().toString();
                if(value.trim().isEmpty()){
addThisCustomer();
                }else{
loadCustomer(value);
                }
            }
        });
        AlertDialog c=alertb.create();
        c.show();
    }

    public void loadCustomer(String code){

    }



    public void addThisCustomer(){
View.OnClickListener add=new View.OnClickListener(){

    @Override
    public void onClick(View v) {
        /*Intent c=new Intent(Cart.this,Add_Customer.class);
        startActivity(c);
        */
    }
};

        View.OnClickListener notnow=new View.OnClickListener(){

            @Override
            public void onClick(View v) {
                Intent c=new Intent(Cart.this,Submit_Sales.class);
                startActivity(c);
            }
        };

        basic.showDetailedAlert("ADD CUSTOMER","Add this customer?","ADD",add,"SKIP",notnow);

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_cart, menu);
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
            if(dm.checkCartNumber()>0){
                customercode();
            }else {
                basic.showAlert("Nothing in cart currently");
            }
           ; return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
