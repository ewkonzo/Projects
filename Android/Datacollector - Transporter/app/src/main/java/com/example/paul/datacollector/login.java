package com.example.paul.datacollector;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Configuration;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.text.InputFilter;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ProgressBar;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.List;
import java.util.Locale;

public class login extends AppCompatActivity {
    //public static Farmer Transporter;
    public static user currentuser;
    public DB db;
    EditText code = null;
    EditText pass = null;
    Spinner route = null;
    TextView routespn = null;
    ProgressBar loginp;
    SharedPreferences preferences;
    ImageButton changeroute;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        code = (EditText) findViewById(R.id.tcode);
        pass = (EditText) findViewById(R.id.pass);
        code.setFilters(new InputFilter[] {new InputFilter.AllCaps()});

        loginp = (ProgressBar) findViewById(R.id.loginp);
        preferences = getSharedPreferences("Settings", MODE_PRIVATE);
        db = new DB(this);
        JsonParser.preferences = getSharedPreferences("Settings", MODE_PRIVATE);
        Log.i("Route",getpreferences("Route"));
        new GetRoutes(null).execute();
        new Gettransporters().execute();
        new Getusers(getpreferences("Route")).execute();


        Log.i("T",getpreferences("Transporter"));

//        if ((getpreferences("Route").equals("")) || getpreferences("Transporter").equals(""))
//            startActivity(new Intent(login.this, Settings.class));
//        final Farmer fa = db.getFarmer(getpreferences("Transporter"));
        String us = getpreferences("User");
        if (!us.toString().equals("")){
        code.setText(getpreferences("User"));
        pass.requestFocus();
        }

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                code.setError(null);
                pass.setError(null);
                if (code.getText().toString().equals("")) {
                    code.setError("User name Required");
                    code.requestFocus();
                    return;
                }
                if (pass.getText().toString().equals("")) {
                    pass.setError("Password Required");
                    pass.requestFocus();
                    return;
                }
                loginp.setVisibility(View.VISIBLE);
                //new Getvendors(fa).execute();
                 user u = new user();
                u.User = code.getText().toString();
                u.Password = pass.getText().toString();
                u = db.getuser(u);
//                if ((u!=null) &&(pass.getText().toString().equals(u.Password ))) {
//                    savePreferences("User", u.User);
//                    if (u.Password_Changed == false)
//                        startActivity(new Intent(login.this, changepassword.class));
//                    else{
//                        currentuser = u;
//                        startActivity(new Intent(login.this, MainActivity.class));
//                    }
//                }
//          else {
//                    loginp.setVisibility(View.GONE);
//                    Toast.makeText(getApplicationContext(), "Invalid User", Toast.LENGTH_LONG).show();
//                }
                startActivity(new Intent(login.this, MainActivity.class));

            }
        });
    }
    private String getpreferences(String key) {
        String pref = "";
        String value = preferences.getString(key, "");
        if (value != null || value != "") {
            pref = value;
        }
        return pref;
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.settings, menu);
        return true;
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        switch (item.getItemId()) {
            case R.id.summaryreport: {
                Intent summary = new Intent(getApplicationContext(), com.example.paul.datacollector.summary.class);
                startActivity(summary);
                return true;
            }
            case R.id.farmercollection: {

                Intent summary = new Intent(getApplicationContext(), com.example.paul.datacollector.farmercollection.class);
                startActivity(summary);

                return true;
            }
            case R.id.settings: {
                Intent intent = new Intent(getApplicationContext(), Settings.class);
                startActivity(intent);

            }
        }
        return super.onOptionsItemSelected(item);
    }
    private class GetRoutes extends AsyncTask<List<TRoutes>, Void, List<TRoutes>> {
        TRoutes f = null;

        GetRoutes(TRoutes ff) {
            f = ff;
        }

        @Override
        protected void onPreExecute() {
        }
        @Override
        protected List<TRoutes> doInBackground(List<TRoutes>... params) {
            List<TRoutes> results = null;
            String result = null;
            try {
                Gson g = new Gson();
                result = g.toJson(this.f);
                result = JsonParser.postjson("TRoute", "data", result);
                Type localType = new TypeToken<List<TRoutes>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
            } catch (Exception e) {
                e.printStackTrace();

            }
            return results;
        }

        @Override
        protected void onPostExecute(List<TRoutes> res) {
            try {
                if (res != null) {
                    if (res.size() > 0)
                        db.deleteAllTRoute();
                    for (TRoutes r : res) {
                        try {
                            db.inserttRoute(r);

                        } catch (Exception ex) {
                            ex.printStackTrace();
                        }
                    }  Toast.makeText(getApplicationContext(),"Routes Updated",Toast.LENGTH_LONG).show();

                }


            } catch (Exception ex) {
                ex.printStackTrace();
                Toast.makeText(getApplicationContext(),ex.getMessage(),Toast.LENGTH_LONG).show();
            }
        }
    }
    private class Getusers extends AsyncTask<String, Void, List<user>> {
        String f = null;

        Getusers(String ff) {
            f = ff;
        }

        @Override
        protected void onPreExecute() {
        }

        @Override
        protected List<user> doInBackground(String... params) {
            List<user> results = null;
            String result = null;
            try {
                Gson g = new Gson();
                //result = g.toJson(this.f);
                result = JsonParser.postjson("Users", "factory", f);
                Type localType = new TypeToken<List<user>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
            } catch (Exception e) {
                e.printStackTrace();
            }
            return results;
        }
        @Override
        protected void onPostExecute(List<user> res) {
            try {
                if (res != null) {
                    for (user r : res) {
                        try {
                            db.insertuser(r);
                        } catch (Exception ex) {
                            ex.printStackTrace();
                        }
                    }
                }
//                else
//                {
//                    new Getusers(getpreferences("Route")).execute();}
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
    private void savePreferences(String key, String value) {

        SharedPreferences.Editor editor = preferences.edit();
        editor.putString(key, value);
        editor.commit();

        // Log.i("Saved shared preference", key+""+value);

    }
    private class Getvendors extends AsyncTask<List<Farmer>, Void, List<Farmer>> {
        Farmer f = null;

        Getvendors(Farmer ff) {
            f = ff;
        }

        @Override
        protected void onPreExecute() {
        }


        @Override
        protected List<Farmer> doInBackground(List<Farmer>... params) {
            //
            List<Farmer> results = null;
            String result = null;
            try {
                Gson g = new Gson();
                result = g.toJson(this.f);
                result = JsonParser.postjson("Transporters", "data", result);
                Type localType = new TypeToken<List<Farmer>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
                if (results != null) {
                    try {

                        for (Farmer f : results
                                ) {
                            db.insertfarmer(f);
                        }
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
            return results;
        }
        @Override
        protected void onPostExecute(List<Farmer> res) {
            try {



            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
    private class Gettransporters extends AsyncTask<Void, Void, List<Farmer>> {
        Gettransporters() {
        }
        @Override
        protected void onPreExecute() {
        }
        @Override
        protected List<Farmer> doInBackground(Void... params) {
            List<Farmer> results = null;
            String result = null;
            try {
                Gson g = new Gson();

                result = JsonParser.postjson("Transporter", null, null);
                Type localType = new TypeToken<List<Farmer>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
                if (results != null) {
                    try {
                        for (Farmer f : results
                                ) {
                            db.insertfarmer(f);
                        }
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
            return results ;
        }
        @Override
        protected void onPostExecute(List<Farmer> res) {
            try {

                //farmername.setTextColor(Color.RED);
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
}
