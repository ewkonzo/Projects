package com.example.paulo.sms;

import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        new balances().execute();
    }
    @Override
    public void onResume() {
        super.onResume();  // Always call the superclass method first
        new balances().execute();
    }
        private class balances extends AsyncTask<Void, String, List<Sms>> {
        @Override
        protected void onPreExecute() {
        }

        protected void onProgressUpdate(String... progress) {
            Toast.makeText(getApplicationContext(), progress[0], Toast.LENGTH_LONG).show();
        }

        @Override
        protected List<Sms> doInBackground(Void... params) {
            //publishProgress("Getting logins");
            List<Sms> results = null;
            String result = null;
            try {
                Gson g = new Gson();
                result = JsonParser.postjson("balances", null, null);
                Type localType = new TypeToken<List<Sms>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);

            } catch (Exception e) {
                publishProgress("Unable to get logins");
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<Sms> res) {
            try {
                 if (res != null)
                 {
                     ListView l ;
                     l = (ListView)findViewById(R.id.sms) ;
                     ListAdapter fc = new trans(MainActivity.this, res);
                     l.setAdapter(fc);

                 }
                 else
                    Toast.makeText(getApplicationContext(), "No data", Toast.LENGTH_LONG).show();
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }



}
