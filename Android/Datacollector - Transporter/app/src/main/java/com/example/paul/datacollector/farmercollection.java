package com.example.paul.datacollector;

import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.io.IOException;
import java.lang.reflect.Type;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.StringTokenizer;

public class farmercollection extends AppCompatActivity {
    EditText farmerno;
    ListView farmerreport;
    TextView farmername;
    Summaries.Months month = null;
    static ArrayAdapter<Summaries.Months> dataAdapter = null;
    Spinner dat;
    DB db = null;
    SharedPreferences pr;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_farmercollection);
        db = new DB(this);
        farmerno = (EditText) findViewById(R.id.txtfarmerno);
        farmername = (TextView) findViewById(R.id.farmername);
        pr = getSharedPreferences("Settings", MODE_PRIVATE);
        ImageButton find = (ImageButton) findViewById(R.id.find);
        ImageButton print = (ImageButton) findViewById(R.id.print);
        print.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (farmerno.getText().equals("")) {
                    farmerno.setError("Farmer no required");
                    return;
                }
                Summaries.printer p = new Summaries.printer();
                p.printcoll(pr, db.getcustomercollection(farmerno.getText().toString(), month),db.getFarmer(farmerno.getText().toString()));
            }
        });

        farmerreport = (ListView) findViewById(R.id.listfarmerreport);
        farmerno.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    getcustomercollection();
                }
            }
        });
        farmerno.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {

                new getmonth(farmerno.getText().toString()).execute();
            }
        });
        dat = (Spinner) findViewById(R.id.txtmonth);
        Calendar cdt = Calendar.getInstance();
        SimpleDateFormat df = new SimpleDateFormat("MM-yyyy");
        final String formattedDate = df.format(cdt.getTime());
        List<Summaries.Months> mm = new ArrayList<>();
        Summaries.Months m = new Summaries.Months();
        m.date = "";
        m.Month = "All";
        mm.add(m);
        m = new Summaries.Months();
        m.date = "";
        m.Month = formattedDate;
        mm.add(m);

        dataAdapter = new ArrayAdapter<Summaries.Months>(farmercollection.this, android.R.layout.simple_spinner_item, mm);
        dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        dat.setAdapter(dataAdapter);
        dat.setSelection(0);
        dat.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view,
                                       int position, long id) {
                month = dataAdapter.getItem(position);
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapter) {
            }
        });


        find.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                getcustomercollection();
            }
        });

    }

    private void getcustomercollection() {

        if (farmerno.getText().equals("")) {
            farmerno.setError("Farmer no required");
            return;
        }
        List<Collection> cc = db.getcustomercollection(farmerno.getText().toString(), month);
        if (cc.size() > 0)
            farmername.setText(cc.get(0).Farmers_Name);
        ListAdapter fc = new farmerreport(this, cc, pr);
        farmerreport.setAdapter(fc);
    }

    private class getmonth extends AsyncTask<String, Void, List<Summaries.Months>> {
        String c = null;

        getmonth(String ff) {
            c = ff;
        }

        @Override
        protected void onPreExecute() {
        }

        @Override
        protected List<Summaries.Months> doInBackground(String... params) {
            List<Summaries.Months> dates = new ArrayList<Summaries.Months>();

            String result = null;
            try {
                List<Summaries.Bydate> d = db.getfarmerdates(c);
                Log.i("looking for farmerdates", c);

                for (Summaries.Bydate b : d
                        ) {
                    Date dd = Calendar.getInstance().getTime();
                    try {
                        SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy"); // here set the pattern as you date in string was containing like date/month/year
                        dd = sdf.parse(b.Date);
                    } catch (ParseException ex) {
                    }
                    SimpleDateFormat datef = new SimpleDateFormat("MM-yyyy");
                    final String formattedDate = datef.format(dd.getTime());
                    Summaries.Months m = new Summaries.Months();
                    m.date = b.Date;
                    m.Month = formattedDate;
                    if (!dateexist(m.Month, dates))
                        dates.add(m);
                }


            } catch (Exception e) {
                e.printStackTrace();

            }
            return dates;
        }

        private boolean dateexist(String date, List<Summaries.Months> mm) {
            Boolean e = false;
            for (Summaries.Months m : mm
                    ) {
                if (m.Month.equalsIgnoreCase(date)) {
                    e = true;
                    break;
                }
            }
            return e;

        }

        @Override
        protected void onPostExecute(List<Summaries.Months> res) {
            try {
                List<Summaries.Months> s = new ArrayList<>();
                Summaries.Months m = new Summaries.Months();
                m.date = "";
                m.Month = "All";

                s.add(m);
                s.add(m);
                s.addAll(res);

                dataAdapter = new ArrayAdapter<Summaries.Months>(farmercollection.this, android.R.layout.simple_spinner_item, s);
                dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                dat.setAdapter(dataAdapter);

            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }


}

