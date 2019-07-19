package com.example.paul.m_branch;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.ExpandableListView;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class reports extends AppCompatActivity {
    ExpandableListView detailreport;
    ListView singlereport;
    reportdata listAdapter;
    DB db;
    List<summaries.collectiondates> listDataHeader;
    HashMap<summaries.collectiondates, List<transaction>> listDataChild;
    String report;
    AutoCompleteTextView reportdate;
    ImageButton search;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reports);
        db = new DB(this);

        Intent in = getIntent();
        Bundle extras = in.getExtras();
        report = extras.getString("report");
        detailreport = (ExpandableListView) findViewById(R.id.detailedreport);
        detailreport.setOnGroupClickListener(new ExpandableListView.OnGroupClickListener() {
            @Override
            public boolean onGroupClick(ExpandableListView parent, View v, int groupPosition, long id) {
                Toast.makeText(getApplicationContext(),"Clicked",Toast.LENGTH_LONG).show();
                    Log.i("group","clicked");
                return false;
            }
        });
        detailreport.setOnGroupExpandListener(new ExpandableListView.OnGroupExpandListener() {

            @Override
            public void onGroupExpand(int groupPosition) {
                Toast.makeText(getApplicationContext(),
                        listDataHeader.get(groupPosition) + " Expanded",
                        Toast.LENGTH_SHORT).show();
            }
        });
        detailreport.setOnGroupCollapseListener(new ExpandableListView.OnGroupCollapseListener() {

            @Override
            public void onGroupCollapse(int groupPosition) {
                Toast.makeText(getApplicationContext(),
                        listDataHeader.get(groupPosition) + " Collapsed",
                        Toast.LENGTH_SHORT).show();
            }
        });
        // Listview on child click listener
        detailreport.setOnChildClickListener(new ExpandableListView.OnChildClickListener() {

            @Override
            public boolean onChildClick(ExpandableListView parent, View v,
                                        int groupPosition, int childPosition, long id) {
                // TODO Auto-generated method stub
                return false;
            }
        });
//        singlereport = (ListView) findViewById(R.id.simplereport);
//        reports.add("Daily Receipts");
//        reports.add("Transaction receipts");
//        reports.add("Member receipts");
//        switch (report) {
//            case "Daily Receipts":
//                reportdate = (AutoCompleteTextView) this.findViewById(R.id.reportdate);
//                reportdate.setVisibility(View.VISIBLE);
//                ArrayAdapter<summaries.collectiondates> aaStr = new ArrayAdapter<summaries.collectiondates>(this, android.R.layout.simple_dropdown_item_1line, db.getcollectiondates());
//                reportdate.setAdapter(aaStr);
//
//                break;
//            case "Transaction receipts": {
//
//                break;
//            }
//        }
        search = (ImageButton) findViewById(R.id.search);
        search.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Log.i("Report", report);
                switch (report) {
                    case "Daily Receipts":

                        DateCollection(reportdate.getText().toString());
                        listAdapter = new reportdata(reports.this, listDataHeader, listDataChild);
                        detailreport.setAdapter(listAdapter);
                        break;
                }
            }
        });
        DateCollection();
        listAdapter = new reportdata(reports.this, listDataHeader, listDataChild);
        detailreport.setAdapter(listAdapter);
    }
    private void DateCollection(String date) {
        listDataHeader = new ArrayList<summaries.collectiondates>();
        listDataChild = new HashMap<summaries.collectiondates, List<transaction>>();

        if (!date.equals("")) {
           summaries.collectiondates l = new summaries.collectiondates();
            l.date = date;
            listDataHeader.add(l);
        } else {
            listDataHeader = db.getcollectiondates();

        }
        for (summaries.collectiondates c : listDataHeader
                ) {
            if (c.date !=null)
            Log.i("dates",c.date);
            List<transaction> t = db.gettransbydate(c.date);
            c.Count = t.size();
            double total = 0.0;
            for (transaction tt : t
                    ) {
                total += tt.Amount;
            }
            c.Total= total;
            listDataChild.put(c, t);
        }
}
    private void DateCollection() {
        listDataHeader = new ArrayList<summaries.collectiondates>();
        listDataChild = new HashMap<summaries.collectiondates, List<transaction>>();


            listDataHeader = db.getcollectiondates();


        for (summaries.collectiondates c : listDataHeader
                ) {
            if (c.date !=null)
                Log.i("dates",c.date);
            List<transaction> t = db.gettransbydate(c.date);
            c.Count = t.size();
            double total = 0.0;
            for (transaction tt : t
                    ) {
                total += tt.Amount;
            }
            c.Total= total;
            listDataChild.put(c, t);
        }
    }
}
