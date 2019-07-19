package com.example.paul.m_branch;

import android.app.ProgressDialog;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.support.annotation.IntegerRes;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.ExpandableListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class receiptreport extends AppCompatActivity {
    Receipts listAdapter;
    List<summaries.Receipts> listDataHeader;
    HashMap<summaries.Receipts, List<transaction>> listDataChild;
    ExpandableListView report;
    ProgressDialog progress;
    DB db = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_summary);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        toolbar.setTitle("Summary Report");
        db = new DB(this);
        progress = new ProgressDialog(receiptreport.this);
        progress.setMessage("Loading report");
        progress.setProgressStyle(ProgressDialog.STYLE_HORIZONTAL);
        progress.setIndeterminate(true);
        progress.setProgress(0);
        progress.setMax( db.getcollectionreceipts().size());
        report = (ExpandableListView) findViewById(R.id.summuryreport);

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB)
            new loaddata().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
        else
            new loaddata().execute();
        report.setOnGroupClickListener(new ExpandableListView.OnGroupClickListener() {

            @Override
            public boolean onGroupClick(ExpandableListView parent, View v,
                                        int groupPosition, long id) {
                // Toast.makeText(getApplicationContext(),
                // "Group Clicked " + listDataHeader.get(groupPosition),
                // Toast.LENGTH_SHORT).show();
                return false;
            }
        });
        report.setOnChildClickListener(new ExpandableListView.OnChildClickListener() {
            @Override
            public boolean onChildClick(ExpandableListView parent, View v,
                                        int groupPosition, int childPosition, long id) {

                return false;
            }
        });
        report.setOnGroupExpandListener(new ExpandableListView.OnGroupExpandListener() {
            @Override
            public void onGroupExpand(int groupPosition) {
                //rl.setVisibility(View.VISIBLE);
            }
        });
        // Listview Group collasped listener
        report.setOnGroupCollapseListener(new ExpandableListView.OnGroupCollapseListener() {
            @Override
            public void onGroupCollapse(int groupPosition) {

            }
        });
    }

    private void expandAll() {
        int count = listAdapter.getGroupCount();
        for (int i = 0; i < count; i++) {
            report.expandGroup(i);
        }
    }

    private void DateCollection() {
        listDataHeader = new ArrayList<summaries.Receipts>();
        listDataChild = new HashMap<summaries.Receipts, List<transaction>>();
        listDataHeader = db.getcollectionreceipts();
        for (summaries.Receipts c : listDataHeader
                ) {
            List<transaction> t = db.gettransbyottn(c.receipt);
            c.Count = t.size();

            double total = 0.0;
            for (transaction tt : t
                    ) {
                c.date = tt.Date;
                c.No = tt.Account_No;
                c.Name = tt.Account_Name;
                c.user = tt.Agent_Code;
                tt.typename = db.gettype(tt.Type).Name;
                total += tt.Amount;
            }
            c.Total = total;
            listDataChild.put(c, t);
        }
    }

    private class loaddata extends AsyncTask<Void, Integer, Void> {

        int i = 1;

        @Override
        protected void onPreExecute() {

            progress.show();
        }
        @Override
        protected void onProgressUpdate(Integer... prog) {
            Log.i("progress", prog[0].toString());
            progress.setProgress(prog[0]);
        }

        @Override
        protected Void doInBackground(Void... params) {

            try {

                listDataHeader = new ArrayList<summaries.Receipts>();
                listDataChild = new HashMap<summaries.Receipts, List<transaction>>();
                listDataHeader = db.getcollectionreceipts();


                for (summaries.Receipts c : listDataHeader
                        ) {
                    publishProgress(i);
                    List<transaction> t = db.gettransbyottn(c.receipt);
                    c.Count = t.size();

                    double total = 0.0;
                    for (transaction tt : t
                            ) {
                        c.date = tt.Date;
                        c.No = tt.Account_No;
                        c.Name = tt.Account_Name;
                        c.user = tt.Agent_Code;
                        tt.typename = db.gettype(tt.Type).Name;
                        total += tt.Amount;

                    }
                    c.Total = total;
                    listDataChild.put(c, t);
                    i++;
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
            return null;
        }

        @Override
        protected void onPostExecute(Void res) {
            try {
                if (progress.isShowing())
                    progress.dismiss();
                listAdapter = new Receipts(receiptreport.this, listDataHeader, listDataChild, db);
                report.setAdapter(listAdapter);
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
}
