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
import android.widget.EditText;
import android.widget.GridView;
import android.widget.ListView;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;


public class Purchase_Cart extends ActionBarActivity {
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
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_purchase__cart);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
       // ab.setDisplayHomeAsUpEnabled(true);
        ab.setTitle(Html.fromHtml("<font color='white'>My Cart</font>"));
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
        if(dm.checkPurchaseCartNumber()>0){
            loadcart();
        }else{
            basic.showAlert("No items in cart currently");
        }
    }

    public void loadcart(){
        sc.loadPurchaseCart(list);
    }

    public String sex(String s){
       String sex;

       if(s.equalsIgnoreCase("Men")||s.equalsIgnoreCase("Boys")){
         sex="Male";
       }else{
         sex="Female";
       }
        return sex;
    }

    public void submit(){
        trendlist=new ArrayList<HashMap<String,String>>();
        trendlist=dm.getPurchaseCart();
        JSONObject main=new JSONObject();
        JSONArray array=new JSONArray();
        for (int i=0;i<trendlist.size();i++){
            JSONObject object=new JSONObject();
            try {
                object.put("vendor",trendlist.get(i).get("vendor"));
                object.put("item",trendlist.get(i).get("item"));
                object.put("subitem",trendlist.get(i).get("itemcategory"));
                object.put("brand",trendlist.get(i).get("brand"));
                object.put("color",trendlist.get(i).get("color"));
                object.put("size",trendlist.get(i).get("size"));
                object.put("pattern",trendlist.get(i).get("pattern"));
                object.put("age_group",trendlist.get(i).get("gendergroup"));
                object.put("material",trendlist.get(i).get("fabric"));
                object.put("price",trendlist.get(i).get("unitprice"));
               // object.put("discount",trendlist.get(i).get("discount"));
                object.put("quantity",trendlist.get(i).get("quantity"));
                object.put("sex",sex(trendlist.get(i).get("gendergroup")));


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

        productsarray=array.toString();
        basic.showAlert(productsarray);

        basic.showAlert(trendlist+"");
        sc.makePurchase(productsarray);

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_purchase__cart, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_main) {
            Intent c=new Intent(Purchase_Cart.this,Home.class);
            startActivity(c);
            return true;
        }

        if (id == R.id.action_add) {
            Intent c=new Intent(Purchase_Cart.this,Buy.class);
            startActivity(c);
            return true;
        }

        if (id == R.id.action_submit) {
            submit();
            return true;
        }
        if (id == R.id.action_clear) {
            dm.clearPurchaseCart();
            basic.showToast("Your cart has been cleared");
            Intent c=new Intent(Purchase_Cart.this,Home.class);
            startActivity(c);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
