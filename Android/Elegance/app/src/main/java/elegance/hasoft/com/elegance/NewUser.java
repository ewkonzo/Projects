package elegance.hasoft.com.elegance;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.provider.MediaStore;
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
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.Toast;

import java.io.ByteArrayOutputStream;
import java.util.ArrayList;
import java.util.HashMap;

import floatt.FloatingActionButton;


public class NewUser extends ActionBarActivity {
    Toolbar toolbar;
    GridView grid;
    ActionBar ab;
    String userid,usertoken,usercategory,itemm;
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
    EditText efname,esname,eemail,ephone,eaddress;
    String usergroup,fname,sname,phone,address,email,image_str,temp;
    Bitmap bm;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTheme(R.style.Theme_AppCompat_Light);
        setContentView(R.layout.activity_new_user);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        efname=(EditText)findViewById(R.id.editfname);
        esname=(EditText)findViewById(R.id.editsname);
        eemail=(EditText)findViewById(R.id.editemail);
        ephone=(EditText)findViewById(R.id.editphone);
        eaddress=(EditText)findViewById(R.id.editaddress);
        toolbar.setBackgroundResource(R.color.white);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setTitle(Html.fromHtml("<font color='black'>New User</font>"));
        ab.setDisplayHomeAsUpEnabled(true);
        app=getSharedPreferences("settings",MODE_PRIVATE);
        userid=app.getString("username", null);
        usertoken=app.getString("usertoken",null);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        res=getResources();
        menu=res.getStringArray(R.array.items);
        items=res.getStringArray(R.array.groups);

        Spinner spfun=(Spinner)findViewById(R.id.specgroup);
        ArrayAdapter adapter2=new ArrayAdapter(NewUser.this,R.layout.support_simple_spinner_dropdown_item,items);
        spfun.setAdapter(adapter2);
        spfun.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Object item = parent.getItemAtPosition(position);
                if (item!= null){
                    usergroup=item.toString();
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
                // TODO Auto-generated method stub

            }
        });

        com.gc.materialdesign.views.ButtonRectangle btn=(com.gc.materialdesign.views.ButtonRectangle)findViewById(R.id.adduser);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                add();
            }
        });

        FloatingActionButton mp=(FloatingActionButton)findViewById(R.id.photodialog);
        mp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                View.OnClickListener take=new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        takephoto(v);
                    }
                };

                View.OnClickListener pick=new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        pickphoto(v);
                    }
                };
                basic.showDetailedAlert(null,"Choose user photo by?","GALLERY",pick,"CAMERA",take);

            }
        });
    }





    public void takephoto(View v){
        Intent takepicc=new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        startActivityForResult(takepicc,1);
    }

    public void pickphoto(View v){
        Intent takepicc=new Intent(Intent.ACTION_PICK, MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
        startActivityForResult(Intent.createChooser(takepicc, "Choose user photo"),0);
    }


    @Override
    protected void onActivityResult(int requestCode,int resultCode,Intent data){
        if(resultCode==RESULT_OK){
            ImageView img=(ImageView)findViewById(R.id.userimage);
            if(requestCode==1){
                super.onActivityResult(requestCode, resultCode, data);
                bm=(Bitmap)data.getExtras().get("data");
                img.setImageBitmap(bm);
                ByteArrayOutputStream stream = new ByteArrayOutputStream();
                bm.compress(Bitmap.CompressFormat.JPEG, 100, stream);
                byte [] byte_arr = stream.toByteArray();
                image_str = Base64.encodeBytes(byte_arr);
            }else{
                Uri selected=data.getData();
                temp=getPath(selected,NewUser.this);
                BitmapFactory.Options boptions=new BitmapFactory.Options();
                bm=BitmapFactory.decodeFile(temp,boptions);
                img.setImageBitmap(bm);
                ByteArrayOutputStream stream = new ByteArrayOutputStream();
                bm.compress(Bitmap.CompressFormat.JPEG, 100, stream);
                byte [] byte_arr = stream.toByteArray();
                image_str = Base64.encodeBytes(byte_arr);
            }
        }else{
            Toast.makeText(getApplicationContext(), "Could not get a photo to use", Toast.LENGTH_SHORT).show();
        }
    }

    public String getPath(Uri uri,Activity activity){
        String[] projection={MediaStore.MediaColumns.DATA};
        Cursor cursor=activity.managedQuery(uri, projection, null, null, null);
        int column_index=cursor.getColumnIndexOrThrow(MediaStore.MediaColumns.DATA);
        cursor.moveToFirst();
        return cursor.getString(column_index);
    }


    public void add(){
        fname=efname.getText().toString().trim();
        sname=esname.getText().toString().trim();
        email=eemail.getText().toString().trim();
        phone=ephone.getText().toString().trim();
        address=eaddress.getText().toString().trim();
        if(fname.isEmpty()||sname.isEmpty()||email.isEmpty()||phone.isEmpty()){
            basic.showAlert("All fields marked * are mandatory");
        }else{
            if(image_str==null){
                basic.showAlert("Please insert user photo");
            }else {
                sc.adduser(fname, sname, phone, email, address, usergroup,image_str);
            }
        }

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        //getMenuInflater().inflate(R.menu.menu_new_user, menu);
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
