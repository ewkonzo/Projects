package com.example.paul.datacollector;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.Spinner;
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
    public static Farmer Transporter;
    public DB db;
    EditText code = null;
    EditText pass = null;
    Spinner route = null;
    ProgressBar loginp ;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        code = (EditText) findViewById(R.id.tcode);
        pass = (EditText) findViewById(R.id.pass);
        route = (Spinner) findViewById(R.id.spnroute);
        loginp = (ProgressBar)findViewById(R.id.loginp);
        db = new DB(this);
        new GetRoutes(null).execute();

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                code.setError(null);
                pass.setError(null);
                if (code.getText().toString().equals("")) {
                    code.setError("Code Required");
                    code.requestFocus();
                    return;
                }
                loginp.setVisibility(View.VISIBLE);
                Transporter = new Farmer();
                Transporter.No = code.getText().toString();
                new Getvendors(Transporter).execute();
                //TODO ccomment below
                Farmer fa = db.getFarmer(Transporter.No);
                if (fa!=null) {
                    if (fa.Creditor_Type == 2) {

                        Transporter = fa;
                        new Getfarmers(Transporter).execute();
                        Log.i(fa.No, String.valueOf(fa.Cummulative_Collected));
                        loginp.setVisibility(View.GONE);
                        Intent intent = new Intent(login.this, MainActivity.class);
                        startActivity(intent);
                    }
                }
                else
                {
                    loginp.setVisibility(View.GONE);
                    Toast.makeText(getApplicationContext(),"Invalid Transporter",Toast.LENGTH_LONG).show();

                }



            }
        });
    }

    private class GetRoutes extends AsyncTask<List<Routes>, Void, List<Routes>> {
        Routes f = null;

        GetRoutes(Routes ff) {
            f = ff;
        }

        @Override
        protected void onPreExecute() {
        }

        @Override
        protected List<Routes> doInBackground(List<Routes>... params) {
            List<Routes> results = null;
            String result = null;
            try {
                Gson g = new Gson();
                result = g.toJson(this.f);
                result = JsonParser.getwithoutparams("Route", "data");
                Type localType = new TypeToken<List<Routes>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
            } catch (Exception e) {
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<Routes> res) {
            try {
                if (res != null) {
                    if (res.size()>0)
                        db.deleteAllRoute();
                    for (Routes r : res) {
                        try {
                            db.insertRoute(r);
                        } catch (Exception ex) {
                            ex.printStackTrace();
                        }
                    }
                }
                final ArrayAdapter<Routes> dataAdapter;
                dataAdapter = new ArrayAdapter<Routes>(login.this,
                        android.R.layout.simple_spinner_item, db.getAllRoutes());
                dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                route.setAdapter(dataAdapter);
                route.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> adapterView, View view,
                                               int position, long id) {
                        // Here you get the current item (a User object) that is selected by its position
                        Routes user = dataAdapter.getItem(position);
                        // Here you can do the action you want to...
                        Routes.currentroute = user;

                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> adapter) {
                    }
                });

            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
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
                result = JsonParser.getXmlFromUrl("Transporters", "data", result);
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


                //farmername.setTextColor(Color.RED);
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
    private class Getfarmers extends AsyncTask<List<Farmer>, Void, List<Farmer>> {
        Farmer f = null;

        Getfarmers(Farmer ff) {
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
                result = JsonParser.postjson("Farmers", "data", result);
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

                //farmername.setTextColor(Color.RED);
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
}
