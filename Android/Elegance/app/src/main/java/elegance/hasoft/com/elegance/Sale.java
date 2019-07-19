package elegance.hasoft.com.elegance;

import android.app.AlertDialog;
import android.content.ActivityNotFoundException;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.net.Uri;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;

import floatt.FloatingActionButton;


public class Sale extends ActionBarActivity {
    Toolbar toolbar;
    ListView list;
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
    DataManager dm;
    TextView cartstatus;
    TextView carttotal;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_sale);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.white);
        list=(ListView)findViewById(R.id.listSearch);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setDisplayHomeAsUpEnabled(true);
        ab.setTitle(Html.fromHtml("<font color='black'>Product Code</font>"));
        app=getSharedPreferences("settings",MODE_PRIVATE);
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        dm=new DataManager(this,1);


        cartstatus=(TextView)findViewById(R.id.cartstatus);
        carttotal=(TextView)findViewById(R.id.carttotal);
        basic.updateCart(cartstatus,carttotal);

        ImageButton search=(ImageButton)findViewById(R.id.imageButton);
        search.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
            search(v);
            }
        });

        FloatingActionButton mp=(FloatingActionButton)findViewById(R.id.viewcart);
        mp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
               Intent x=new Intent(Sale.this,Cart.class);
               startActivity(x);
            }
        });

        FloatingActionButton r=(FloatingActionButton)findViewById(R.id.clearcart);
        r.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                final MaterialDialog alert=new MaterialDialog(Sale.this);
                alert.setTitle("CLEAR CART");
                alert.setMessage("Are you sure you want to clear the current cart?");
                alert.setPositiveButton("Ok",new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        dm.clearCart();
                        basic.updateCart(cartstatus,carttotal);
                        alert.dismiss();
                    }
                });

                alert.setNegativeButton("CANCEL", new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        alert.dismiss();
                    }
                });
                alert.show();

            }
        });
      chooseMethod();

    }


    //product barcode mode

    public void scanBar() {
        final String ACTION_SCAN = "com.google.zxing.client.android.SCAN";
        try {

            //start the scanning activity from the com.google.zxing.client.android.SCAN intent

            Intent intent = new Intent(ACTION_SCAN);

            intent.putExtra("SCAN_MODE", "PRODUCT_MODE");

            startActivityForResult(intent, 0);

        } catch (ActivityNotFoundException anfe) {

            //on catch, show the download dialog
              View.OnClickListener yes=new View.OnClickListener() {
                     @Override
                       public void onClick(View v) {
                         Uri uri = Uri.parse("market://search?q=pname:" + "com.google.zxing.client.android");

                         Intent intent = new Intent(Intent.ACTION_VIEW, uri);

                         try {

                             startActivity(intent);

                         } catch (ActivityNotFoundException anfe) {
                          basic.showAlert("Please install Play Store to download this app");


                         }
                        }
                      };

            View.OnClickListener no=new View.OnClickListener() {
                @Override
                public void onClick(View v) {
  Intent c=new Intent(Sale.this,Sale.class);
  startActivity(c);
                }
            };

basic.showDetailedAlert("NO SCANNER","No scanner found.Do you want to download a scanner now?","YES",yes,"NOT NOW",no);

        }

    }

    public void onActivityResult(int requestCode, int resultCode, Intent intent) {

        if (requestCode == 0) {

            if (resultCode == RESULT_OK) {

                //get the extras that are returned from the intent

                String contents = intent.getStringExtra("SCAN_RESULT");

                String format = intent.getStringExtra("SCAN_RESULT_FORMAT");

if(contents!=null){
    if(!contents.equalsIgnoreCase("")){
        EditText ed=(EditText)findViewById(R.id.pcode);
        ed.setText(contents);
        searchCode(contents);
    }else{
        basic.showAlert("No code found.Try again");
    }
}else {
    basic.showAlert("No code found.Try again");
}


            }

        }

    }


    public void chooseMethod(){
        AlertDialog.Builder alert=new AlertDialog.Builder(Sale.this,AlertDialog.THEME_DEVICE_DEFAULT_LIGHT);
        alert.setCancelable(true);
        alert.setNegativeButton("USE BARCODE", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                   scanBar();
            }
        });
        alert.setPositiveButton("MANUAL ENTRY",new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                      dialog.dismiss();
            }
        });

        AlertDialog c=alert.create();
        c.show();
    }

    public void search(View v){
        netpresent=cd.isConnectingToInternet();
        EditText ed=(EditText)findViewById(R.id.pcode);
        String query=ed.getText().toString();
        if(query.trim().isEmpty()){
            basic.showAlert("Enter Product Code");
        }else {
            if (netpresent) {
                sc.getitemfromcode(query,list,cartstatus,carttotal);
            } else {
                basic.showToast("Check your connection");
            }
        }
    }


    public void searchCode(String x){
            netpresent=cd.isConnectingToInternet();
            if (netpresent) {
                sc.getitemfromcode(x,list,cartstatus,carttotal);
            } else {
                basic.showToast("Check your connection");
            }

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_sale, menu);
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
            chooseMethod();
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
