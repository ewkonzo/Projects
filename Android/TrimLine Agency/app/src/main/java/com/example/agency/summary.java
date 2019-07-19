package com.example.agency;

import android.app.Activity;

import android.os.Bundle;
import android.view.View;
import android.widget.ExpandableListView;
import android.widget.Toast;

import java.util.HashMap;
import java.util.List;

public class summary extends Activity {
    ExpandableListAdapter listAdapter;
    ExpandableListView expListView;
    List<Summaries.Bydate> listDataHeader;
    HashMap<Summaries.Bydate, List<Transaction>> listDataChild;
    DB db =null;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.summary);
        expListView = (ExpandableListView) findViewById(R.id.summary);
        db = new DB(this);
        prepareListData();

        listAdapter = new ExpandableListAdapter(this, listDataHeader, listDataChild);
        expListView.setAdapter(listAdapter);
        // setting list adapter
        expListView.setOnGroupClickListener(new ExpandableListView.OnGroupClickListener() {

            @Override
            public boolean onGroupClick(ExpandableListView parent, View v,
                                        int groupPosition, long id) {
                // Toast.makeText(getApplicationContext(),
                // "Group Clicked " + listDataHeader.get(groupPosition),
                // Toast.LENGTH_SHORT).show();
                return false;
            }
        });
    }
    private void prepareListData() {
        listDataHeader = db.getdates();
        Toast.makeText(getApplicationContext(),String.valueOf(listDataHeader.size()),Toast.LENGTH_LONG).show();
        listDataChild = new HashMap<Summaries.Bydate, List<Transaction>>();
        for (Summaries.Bydate s:listDataHeader
                ) {
            double total =0.0;
            List<Transaction> det = db.getTransbydate(s.Date);
            Toast.makeText(getApplicationContext(),String.valueOf(det.size()),Toast.LENGTH_LONG).show();

            for (Transaction c:det
                    ) {
                total+=c.amount;
            }
            s.Total = total;

            listDataChild.put(s,det);
        }
    }
}
