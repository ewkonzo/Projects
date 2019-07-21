package com.example.paul.m_branch;

import android.app.ProgressDialog;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.ExpandableListView;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class vehiclereport extends AppCompatActivity {
    Vehicleadapter listAdapter;
    List<summaries.collectiondates> listDataHeader;
    HashMap<summaries.collectiondates, List<transaction>> listDataChild;
    ExpandableListView report;
    DB db = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_summary);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        toolbar.setTitle("Summary Report");
        report = findViewById(R.id.summuryreport);
        db = new DB(this);
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
        listDataHeader = new ArrayList<summaries.collectiondates>();
        listDataChild = new HashMap<summaries.collectiondates, List<transaction>>();
        listDataHeader = db.getcollectiondates();
        for (summaries.collectiondates c : listDataHeader
                ) {

            List<transaction> t = db.gettransbydate(c.date);
            c.Count = t.size();

            double total = 0.0;
            c.MemberNo = t.get(0).Account_No;
            c.MemberName = t.get(0).Account_Name;
            for (transaction tt : t
                    ) {
                c.date = tt.Date;
                tt.typename = db.gettype(tt.Type).Name;
                total += tt.Amount;
            }
            c.Total = total;
            listDataChild.put(c, t);
        }
    }

    private class loaddata extends AsyncTask<Void, Void, Void> {
        private ProgressDialog progress;
        int i = 1;

        @Override
        protected void onPreExecute() {
            progress = new ProgressDialog(vehiclereport.this);
            progress.setMessage("Loading report");
            progress.setProgressStyle(ProgressDialog.STYLE_HORIZONTAL);
            progress.setIndeterminate(true);
            progress.setProgress(0);
            progress.show();
        }

        @Override
        protected void onProgressUpdate(Void... prog) {

            progress.setProgress(i);

        }

        @Override
        protected Void doInBackground(Void... params) {

            try {

                listDataHeader = new ArrayList<summaries.collectiondates>();
                listDataChild = new HashMap<summaries.collectiondates, List<transaction>>();
                listDataHeader = db.getcollectiondates();
                progress.setMax(listDataHeader.size());

                for (summaries.collectiondates c : listDataHeader
                        ) {
                    publishProgress();

                    List<transaction> t = db.gettransbydate(c.date);
                    c.Count = t.size();

                    double total = 0.0;
                    c.MemberNo = t.get(0).Account_No;
                    c.MemberName = t.get(0).Account_Name;
                    for (transaction tt : t
                            ) {
                        c.date = tt.Date;
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
                listAdapter = new Vehicleadapter(vehiclereport.this, listDataHeader, listDataChild);
                report.setAdapter(listAdapter);
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
}
