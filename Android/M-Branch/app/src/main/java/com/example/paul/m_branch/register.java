package com.example.paul.m_branch;

import android.database.sqlite.SQLiteDatabaseLockedException;
import android.support.design.widget.CoordinatorLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import java.security.acl.Group;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;

public class register extends AppCompatActivity {
    EditText rname, rid, rtelephone, rward, rmemberno;
    Spinner rgender, rmaritalstatus, rconstituency;
    AutoCompleteTextView txtgroup;
    Button create, cancel;
    Constituency c = null;
    DB db;
    transaction.gender selgender;
    transaction.marital selmarital;
    static ArrayList<group> groups;

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register1);
        db = new DB(this);
        rname = (EditText) findViewById(R.id.name);
        rid = (EditText) findViewById(R.id.ID);
        rconstituency = (Spinner) findViewById(R.id.constituency);
        rtelephone = (EditText) findViewById(R.id.Telephone);
        rward = (EditText) findViewById(R.id.ward);
        rmemberno = (EditText) findViewById(R.id.memno);
        rgender = (Spinner) findViewById(R.id.gender);
        txtgroup = (AutoCompleteTextView) findViewById(R.id.txgroup);
        rmaritalstatus = (Spinner) findViewById(R.id.marital);
        rgender.setAdapter(new ArrayAdapter<transaction.gender>(this, android.R.layout.simple_spinner_dropdown_item, transaction.gender.values()));
        rgender.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                selgender = transaction.gender.values()[position];
            }
            @Override
            public void onNothingSelected(AdapterView<?> parent) {
           }
        });
        rmaritalstatus.setAdapter(new ArrayAdapter<transaction.marital>(this, android.R.layout.simple_spinner_dropdown_item, transaction.marital.values()));
        rmaritalstatus.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                selmarital = transaction.marital.values()[position];
            }
            @Override
            public void onNothingSelected(AdapterView<?> parent) {
            }
        });
        final ArrayAdapter<Constituency> dataAdapter;
        dataAdapter = new ArrayAdapter<Constituency>(register.this,
                android.R.layout.simple_spinner_item, db.getconstituencies());
        dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        rconstituency.setAdapter(dataAdapter);
        rconstituency.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view,
                                       int position, long id) {
                c = dataAdapter.getItem(position);
            }
            @Override
            public void onNothingSelected(AdapterView<?> adapter) {
            }
        });
        groups = db.getgroups();
        ArrayList<String> g = new ArrayList<>();
        for (group gg :groups
             ) {
            if (gg.Group_No!=null)
            g.add(gg.Group_No);
        }
        ArrayAdapter<String> adapter = new ArrayAdapter<>
                (this, android.R.layout.simple_list_item_1, g);
        txtgroup.setAdapter(adapter);
        txtgroup.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    if (db.getgroup(txtgroup.getText().toString())==null) {
                        txtgroup.setText("");
                        txtgroup.setError("Invalid group.");
                    }
             }
            }
        });
        create = (Button) findViewById(R.id.create);
        cancel = (Button) findViewById(R.id.cancel);
        create.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    rname.setError(null);
                    rid.setError(null);
                    rtelephone.setError(null);
                    rward.setError(null);
                    if (rmemberno.getText().toString().equals("")) {
                        rmemberno.setError("No is required");
                        rmemberno.requestFocus();
                        return;
                    }
                    if (rmemberno.getText().toString().equals("HBCWS-")) {
                        rmemberno.setError("No is required");
                        rmemberno.requestFocus();
                        return;
                    }
                    member m = db.getmember(rmemberno.getText().toString());
                    if (m != null) {
                        rmemberno.setError("Member No is already exist");
                        rmemberno.requestFocus();
                        return;
                    }
                    if (rname.getText().toString().equals("")) {
                        rname.setError("Description is required");
                        rname.requestFocus();
                        return;
                    }
                    if (rid.getText().toString().equals("")) {
                        rid.setError("ID is required");
                        rid.requestFocus();
                        return;
                    }
                    if (rtelephone.getText().toString().equals("")) {
                        rtelephone.setError("Telephone is required");
                        rtelephone.requestFocus();
                        return;
                    }
                    if (c == null) {
                        Toast.makeText(getApplicationContext(), "Constituency is required", Toast.LENGTH_LONG).show();
                        rconstituency.requestFocus();
                        return;
                    }
//                    if (selgender == transaction.gender._blank_) {
//                        Toast.makeText(getApplicationContext(), "Please select gender", Toast.LENGTH_LONG).show();
//                        return;
//                    }
                    if (selmarital == transaction.marital._blank_) {
                        Toast.makeText(getApplicationContext(), "Please select Marital status", Toast.LENGTH_LONG).show();
                        return;
                    }
                    transaction T = new transaction();
                    Calendar cdt = Calendar.getInstance();
                    SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
                    final String formattedDate = df.format(cdt.getTime());
                    df = new SimpleDateFormat("HH:mm:ss");
                    final String formattedtime = df.format(cdt.getTime());
                    df = new SimpleDateFormat("yyyyMMddhhmmss");
                    final String Doc =  df.format(cdt.getTime());
                    SimpleDateFormat batch = new SimpleDateFormat("yyyyMMddhhmm");
                    String Batch =  batch.format(cdt.getTime());
                    T = new transaction();
                    T.Date = formattedDate;
                    T.Time = formattedtime;
                    T.Account_No = rmemberno.getText().toString();
                    T.Document_No = Doc;
                    T.Amount = 0.0;
                    T.Account_Name = rname.getText().toString();
                    T.Agent_Code = login.CurrentAgent.Agent_Code;
                    T.Id_No = rid.getText().toString();
                    T.Telephone = rtelephone.getText().toString();
                    T.Transaction_Type = transaction.T_Type.Registration.ordinal();
                    T.OTTN = Batch;
                    T.sent = false;
                    T.Constituency = c.No;
                    T.Ward = rward.getText().toString();
                    T.Gender = selgender.ordinal();
                    T.Marital = selmarital.ordinal();
                    T.Group = txtgroup.getText().toString();
                    T.Type= "REGISTRATION";
                    db.inserttrans(T);
                    finish();
                } catch (SQLiteDatabaseLockedException ex) {
                    ex.printStackTrace();
                    Toast.makeText(getApplicationContext(), "Database busy, try again", Toast.LENGTH_LONG).show();
                } catch (Exception ex) {
                    ex.printStackTrace();
                    Toast.makeText(getApplicationContext(), "Can't save try again", Toast.LENGTH_LONG).show();
                }
            }
        });


    }
}
