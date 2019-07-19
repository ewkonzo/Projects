package com.example.paul.m_branch;

import android.app.DatePickerDialog;
import android.app.ProgressDialog;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.support.annotation.IntegerRes;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.ExpandableListView;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Text;

import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.Stream;
import java.util.stream.StreamSupport;

public class receiptreport extends AppCompatActivity implements
        View.OnClickListener {
    Receipts listAdapter;
    List<summaries.Receipts> listDataHeader;
    HashMap<summaries.Receipts, List<transaction>> listDataChild;
    ExpandableListView report;
    ProgressDialog progress;
    private int mYear, mMonth, mDay, mHour, mMinute;
    DB db = null;
    Button setdate;
    String date;
TextView total ;
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
        progress.setIndeterminate(false);
        progress.setProgress(0);
        //progress.setMax( db.getcollectionreceipts().size());
        report = (ExpandableListView) findViewById(R.id.summuryreport);
total = (TextView)findViewById(R.id.total);

        //datepicker

        final Calendar c = Calendar.getInstance();
        DecimalFormat mFormat= new DecimalFormat("00");

        mYear = c.get(Calendar.YEAR);
        mMonth = c.get(Calendar.MONTH);
        mDay = c.get(Calendar.DAY_OF_MONTH);

        date = mFormat.format(Double.valueOf(mDay)) + "-" + (mFormat.format(Double.valueOf(mMonth+ 1)) ) + "-" + mYear;
        setdate = (Button) findViewById(R.id.Date);

        setdate.setOnClickListener(this);
        setdate.setText(date);

        //datepicker

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB)
            new loaddata(date).executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
        else
            new loaddata(date).execute();

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

    @Override
    public void onClick(View v) {
        // Get Current Date


        DatePickerDialog datePickerDialog = new DatePickerDialog(this,
                new DatePickerDialog.OnDateSetListener() {
                    @Override
                    public void onDateSet(DatePicker view, int year,
                                          int monthOfYear, int dayOfMonth) {
//dd-MM-yyyy
                        DecimalFormat mFormat = new DecimalFormat("00");
                        date = mFormat.format(Double.valueOf(dayOfMonth)) + "-" + mFormat.format(Double.valueOf(monthOfYear + 1)) + "-" + year;
                        setdate.setText(date);
                        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB)
                            new loaddata(date).executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
                        else
                            new loaddata(date).execute();

                    }
                }, mYear, mMonth, mDay);
        datePickerDialog.show();
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
                if (!tt.Type.equals("PENALTY CHARGED"))
                total += tt.Amount;
            }
            c.Total = total;
            listDataChild.put(c, t);
        }
    }

    private class loaddata extends AsyncTask<String, Integer, Void> {

        int i = 1;
        String d;

        loaddata(String dd) {
            d = dd;
        }

        @Override
        protected void onPreExecute() {

            progress.show();
        }

        @Override
        protected void onProgressUpdate(Integer... prog) {
            // Log.i("progress", prog[0].toString());
            progress.setProgress(prog[0]);
        }

        @Override
        protected Void doInBackground(String... params) {

            try {

                listDataHeader = new ArrayList<summaries.Receipts>();
                listDataChild = new HashMap<summaries.Receipts, List<transaction>>();
                Log.i("Start", "Start");
                listDataHeader = db.getcollectionreceiptsbydate(d);
                Log.i("end", "end");
                List<types> typ = db.gettypes();
                List<transaction> trns = db.gettransallbydate(date);
double globaltotal =0;
                progress.setMax(listDataHeader.size());
                for (summaries.Receipts c : listDataHeader
                        ) {
                    publishProgress(i);
                    // Log.i("Startchild", "Start");
                    List<transaction> t = trns.stream().filter(p -> p.OTTN.contentEquals(c.receipt)).collect(Collectors.toList());
                    //List<transaction> t = db.gettransbyottn(c.receipt);
                    //Log.i("stopchild", "Start");
                    c.Count = t.size();

                    double total = 0.0;
                    for (transaction tt : t
                            ) {
                        c.date = tt.Date;
                        c.No = tt.Account_No;
                        c.Name = tt.Account_Name;
                        c.user = tt.Agent_Code;
                        //Log.i("type1",tt.Type);
                        //Log.i("type1",String.valueOf((typ.size())));
                        //List<types> ty = typ.removeIf(p-> p.Code !=tt.Type);
                       // List<types> ty = typ.stream().filter(p -> p.Code.contentEquals(tt.Type)).collect(Collectors.toList());

                        //Log.i("typeafter",ty.get(0).Code);
//                        if (ty.size() > 0)
//                            tt.typename = ty.get(0).Name;
//
//                        if (!tt.Type.equals("PENALTY CHARGED"))
                        total += tt.Amount;

                    }
                    c.Total = total;
                    globaltotal += total;
                    listDataChild.put(c, t);
                    i++;
                }
                total.setText(String.format("%,.2f",globaltotal));
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
