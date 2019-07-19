package com.example.paul.m_branch;

import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AutoCompleteTextView;
import android.widget.ImageButton;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class status extends AppCompatActivity {
    DB db = null;
    AutoCompleteTextView vehno;
    ImageButton search;
    ProgressBar p;
    ListView sl;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_status);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        db = new DB(this);
        vehno = (AutoCompleteTextView) findViewById(R.id.searchno);
        p = (ProgressBar) findViewById(R.id.searchprogress);
        sl = (ListView) findViewById(R.id.statuslist);
        search = (ImageButton) findViewById(R.id.findveh);
        search.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Search();
            }
        });
        vehno.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Search();
            }
        });
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB)
            new getclients().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
        else
            new getclients().execute();
    }

    private void Search() {
        if (vehno.getText().toString().equals("")) {
            vehno.setError("Vehicle no should not be blank");
            return;
        }
        p.setVisibility(View.VISIBLE);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB)
            new getcollections(vehno.getText().toString()).executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
        else
            new getcollections(vehno.getText().toString()).execute();
    }

    private class getclients extends AsyncTask<Void, String, ArrayList<String>> {
        @Override
        protected void onPreExecute() {

        }

        protected void onProgressUpdate(String... progress) {
            Toast.makeText(getApplicationContext(), progress[0], Toast.LENGTH_SHORT).show();
        }

        @Override
        protected ArrayList<String> doInBackground(Void... params) {
            ArrayList<String> clients = new ArrayList<>();
            String result = null;
            try {
                for (vehicles v : db.getvehicles()
                        ) {
                    if (v.Vehicle_Number != null) {
                        clients.add(v.Vehicle_Number);
                    }
                }

            } catch (Exception e) {
                publishProgress(e.getMessage());
                e.printStackTrace();
            }
            return clients;
        }

        @Override
        protected void onPostExecute(ArrayList<String> res) {
            try {
                AutoSuggestAdapter adapter = new AutoSuggestAdapter(status.this, android.R.layout.simple_list_item_1, res);
                vehno.setAdapter(adapter);
                //  Toast.makeText(getApplicationContext(), res.size() + " Members attached", Toast.LENGTH_LONG).show();
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }

    private class getcollections extends AsyncTask<String, Void, List<transaction>> {
        String c = null;

        getcollections(String ff) {
            c = ff;
        }

        @Override
        protected void onPreExecute() {
        }

        @Override
        protected List<transaction> doInBackground(String... params) {
            List<transaction> results = null;
            String result = null;
            try {
                Calendar cdt = Calendar.getInstance();
                SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
                final String formattedDate = df.format(cdt.getTime());

                summaries.getdata gt = new summaries.getdata();
                gt.firstdate = formattedDate;
                gt.user = c;

                Gson g = new Gson();
                result = g.toJson(gt);
                result = JsonParser.postjson("GetCollections", "data", result);
                Type localType = new TypeToken<List<transaction>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
            } catch (Exception e) {
                e.printStackTrace();

            }
            return results;
        }

        @Override
        protected void onPostExecute(List<transaction> res) {
            try {
                p.setVisibility(View.GONE);
                sl.setAdapter(null);
                if (res != null)
                    if (res.size() > 0) {

                        ListAdapter fc = new transstatus(status.this, res, db);
                        sl.setAdapter(fc);
                    } else
                        Toast.makeText(getApplicationContext(), "No payment for Vehicle " + vehno.getText().toString() + " today", Toast.LENGTH_LONG).show();
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
}
