package com.example.paul.datacollector;

import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.util.List;

public class changepassword extends AppCompatActivity {
EditText oldpass,newpass,confirmpass;
    Button change;
    DB db;
    SharedPreferences preferences;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_changepassword);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        oldpass = (EditText)findViewById(R.id.oldpass);
        newpass = (EditText)findViewById(R.id.newpass);
        confirmpass = (EditText)findViewById(R.id.confirmpass);
        preferences = getSharedPreferences("Settings", MODE_PRIVATE);
        db = new DB(this);
        oldpass.setError(null);
        newpass.setError(null);
        confirmpass.setError(null);

        oldpass.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {


            }
        });

        change = (Button)findViewById(R.id.changepass);
        change.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (oldpass.getText().equals(""))
                {
                    oldpass.setError("Nothing entered");
                    return;
                } if (newpass.getText().equals(""))
                {
                    newpass.setError("Nothing entered");
                    return;
                } if (confirmpass.getText().equals(""))
                {
                    oldpass.setError("Nothing entered");
                    return;
                }
                user u = new user();
                u.User =  getpreferences("User");
                Log.i("user", u.User);
                u = db.getuser(u);
                if (!u.Password.equals(oldpass.getText().toString()))
                {
                    oldpass.setError("Invalid current password");
                    return;
                }
                if (!newpass.getText().toString().equals(confirmpass.getText().toString()))
                {
                   // newpass.setError("Password confirmation error");
                    confirmpass.setError("Password confirmation error");
                    return;
                }
                u.Password = newpass.getText().toString();
                u.Password_Changed = true;
                db.updateuser(u);
                new updateuser(u).execute();
                Toast.makeText(getApplicationContext(),"Password Change successfully",Toast.LENGTH_LONG).show();
                finish();

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
    private class updateuser extends AsyncTask<user, Void, user> {
        user f = null;

        updateuser(user ff) {
            f = ff;
        }

        @Override
        protected void onPreExecute() {
        }


        @Override
        protected user doInBackground(user... params) {
            //
            user results = null;
            String result = null;
            try {
                Gson g = new Gson();
                result = g.toJson(this.f);
                result = JsonParser.postjson("updateUsers", "data", result);
                Type localType = new TypeToken<user>() {
                }.getType();
                results = new Gson().fromJson(result, localType);

            } catch (Exception e) {
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(user res) {
            try {
    if (res ==null)
    new updateuser(f).execute();


            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
}
