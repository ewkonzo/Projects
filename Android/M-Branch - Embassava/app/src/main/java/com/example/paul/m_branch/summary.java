package com.example.paul.m_branch;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.ExpandableListView;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

public class summary extends AppCompatActivity {
    ExpandableListAdapter listAdapter;
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
        DateCollection();
        listAdapter = new ExpandableListAdapter(this, listDataHeader, listDataChild,db);
        // setting list adapter
        report.setAdapter(listAdapter);
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
                // TODO Auto-generated method stub
//                Intent i = new Intent(summary.this, reports.class);
//                i.putExtra("report", listDataChild.get(
//                        listDataHeader.get(groupPosition)).get(
//                        childPosition).toString());
//                startActivity(i);
//                Toast.makeText(
//                        getApplicationContext(),
//                        listDataHeader.get(groupPosition)
//                                + " : "
//                                + listDataChild.get(
//                                listDataHeader.get(groupPosition)).get(
//                                childPosition).toString(), Toast.LENGTH_SHORT)
//                        .show();
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
                //rl.setVisibility(View.GONE);
            }
        });

        //expandAll();

    }
    private void expandAll() {
        int count = listAdapter.getGroupCount();
        for (int i = 0; i < count; i++){
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
            for (transaction tt : t
                    ) {
                tt.typename= db.gettype(tt.Type).Name;
                total += tt.Amount;
            }
            c.Total= total;
            listDataChild.put(c, t);
        }
    }
}
