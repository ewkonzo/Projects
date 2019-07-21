package com.example.paul.m_branch;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.support.design.widget.TextInputLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.ShareActionProvider;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.facebook.stetho.Stetho;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.util.List;

public class login extends AppCompatActivity {
    EditText username, pass;
    Button Login;
    public static agent CurrentAgent;
    DB db;
    SharedPreferences preferences;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        Stetho.initializeWithDefaults(this);
        preferences = getSharedPreferences("Settings", MODE_PRIVATE);
        JsonParser.preferences = preferences;
        db = new DB(this);
        DB.t tt = new DB.t();
        Log.i("fields", tt.toString());
        final TextInputLayout usernameWrapper = findViewById(R.id.input_layout_username);
        final TextInputLayout passwordWrapper = findViewById(R.id.input_layout_password);
        usernameWrapper.setHint("User Name");
        passwordWrapper.setHint("Pin");
        username = findViewById(R.id.username);
        pass = findViewById(R.id.password);
        new Getlogins().execute();
        new Getvehicles().execute();
        String us = getpreferences("User");
        if (!us.equals("")) {
            username.setText(getpreferences("User"));
            pass.requestFocus();
        }
        Login = findViewById(R.id.login);
        Login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                username.setError(null);
                pass.setError(null);
                if (username.getText().toString().equalsIgnoreCase("")) {
                    username.setError("username required");
                    username.requestFocus();
                    return;
                }
                Log.i("Agents", String.valueOf(db.Totalagents()));
                agent a = db.getagent(username.getText().toString().toUpperCase());
                if (a == null) {
                    Toast.makeText(getApplicationContext(), "Invalid username or password", Toast.LENGTH_LONG).show();
                    return;
                }
                if (!a.Password.equals(pass.getText().toString())) {
                    Toast.makeText(getApplicationContext(), "Invalid username or password", Toast.LENGTH_LONG).show();
                    return;
                }
                CurrentAgent = a;
                Myvariables.CurrentAgent = a;
                savePreferences("User", a.Agent_Code);
                startActivity(new Intent(login.this, menu.class));
            }
        });
    }

    private void savePreferences(String key, String value) {

        SharedPreferences.Editor editor = preferences.edit();
        editor.putString(key, value);
        editor.commit();
        // Log.i("Saved shared preference", key+""+value);
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
        switch (item.getItemId()) {
            case R.id.set: {
                Intent summary = new Intent(getApplicationContext(), Settings.class);
                startActivity(summary);
                return true;
            }
        }
        return super.onOptionsItemSelected(item);
    }

    private class Getlogins extends AsyncTask<Void, String, List<agent>> {
        @Override
        protected void onPreExecute() {
        }

        protected void onProgressUpdate(String... progress) {
            Toast.makeText(getApplicationContext(), progress[0], Toast.LENGTH_LONG).show();
        }

        @Override
        protected List<agent> doInBackground(Void... params) {
            //publishProgress("Getting logins");
            List<agent> results = null;
            String result = null;
            try {
                Gson g = new Gson();
                result = JsonParser.postjson("logins", null, null);
                Type localType = new TypeToken<List<agent>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
                if (results != null) {
                    try {
                        db.deleteagents();
                        // publishProgress("Updating logins");
                        for (agent f : results
                                ) {
                            db.insertagent(f);
                        }
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
                } else {
                    Log.i("Agents", "Empty");
                }
            } catch (Exception e) {
                publishProgress("Unable to get logins");
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<agent> res) {
            try {
//                if (res != null)
//                    Toast.makeText(getApplicationContext(), "Logins updated", Toast.LENGTH_LONG).show();
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }

    private class Getvehicles extends AsyncTask<Void, String, List<vehicles>> {
        @Override
        protected void onPreExecute() {

        }

        protected void onProgressUpdate(String... progress) {
            Toast.makeText(getApplicationContext(), progress[0], Toast.LENGTH_LONG).show();
        }

        @Override
        protected List<vehicles> doInBackground(Void... params) {
            //  publishProgress("Getting Vehicles");
            List<vehicles> results = null;
            String result = null;
            try {
                Gson g = new Gson();
                result = JsonParser.postjson("Vehicles", null, null);
                Type localType = new TypeToken<List<vehicles>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
                if (results != null) {
                    try {
                        //  publishProgress("Updating "+ results.size() +" vehicles");
                        for (vehicles f : results
                                ) {
                            db.inservehicles(f);
                        }
                    } catch (Exception ex) {
                        publishProgress("Unable to get vehicles");
                        ex.printStackTrace();
                    }
                } else {
                    Log.i("Agents", "Empty");
                }
            } catch (Exception e) {
                publishProgress("Unable to get vehicles");
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<vehicles> res) {
            try {
//                if (res != null)
//                    Toast.makeText(getApplicationContext(), "vehicles updated", Toast.LENGTH_LONG).show();


            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
}
