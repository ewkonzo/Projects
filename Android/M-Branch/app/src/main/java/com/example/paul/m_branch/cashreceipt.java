package com.example.paul.m_branch;

import android.app.AlertDialog;
import android.bluetooth.BluetoothDevice;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.media.Image;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.lang.reflect.Type;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;
import java.util.StringTokenizer;

public class cashreceipt extends AppCompatActivity {
    AutoCompleteTextView memberno;
    EditText  amount,grouprec;
    TextView membername, id, telephone,totalrec;
    ImageButton find;
    Spinner ttypes;
    Button addtrans, post, postnew,reprint;
    ProgressBar findmember;
    Calendar cdt;
    transaction T;
    DB db = null;
    member f;
    double totalreceipt;
    SimpleDateFormat batch;
    static String Batch,lastbatch;
    types t;
    List<mpesa> Mpesa = new ArrayList<mpesa>() ;
    EditText mpesaid;
    TextView mpesaamount;
    ListView ttrans;
    SharedPreferences preferences;
    private summaries.printer p = new summaries.printer();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cashreceipt);
        preferences = getSharedPreferences("Settings", MODE_PRIVATE);
        db = new DB(this);
        ttrans = (ListView) (findViewById(R.id.ttrans));
        ttypes = (Spinner) findViewById(R.id.ttype);
        final ArrayAdapter<types> dataAdapter;
        dataAdapter = new ArrayAdapter<types>(this,
                android.R.layout.simple_spinner_item, db.gettypes());
        dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB){
            new getclients().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
            new Getmpesa().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);}
        else{
            new getclients().execute();
        new Getmpesa().execute();}

        mpesaid = (EditText)findViewById(R.id.mpesas);
        mpesaamount = (TextView)findViewById(R.id.mpesaamount);
        mpesaid.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View view, boolean b) {
                if(!mpesaid.getText().toString().equals(""))
                {
                    mpesa mm = db.getmpesa(mpesaid.getText().toString());

                    if (mm!=null)
                        mpesaamount.setText(String.valueOf(mm.amount- mm.utilized));
                   else
                       mpesaid.setError("Transaction not found");
                }
            }
        });
        ttypes.setAdapter(dataAdapter);
        ttypes.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                t = dataAdapter.getItem(position);
            }
            @Override
            public void onNothingSelected(AdapterView<?> parent) {
            }
        });
        cdt = Calendar.getInstance();
        batch = new SimpleDateFormat("yyyyMMddhhmm");
        Batch = batch.format(cdt.getTime());
        memberno = (AutoCompleteTextView) findViewById(R.id.memberno);
        memberno.setSelection(memberno.getText().length());
        amount = (EditText) findViewById(R.id.tamount);
        grouprec = (EditText) findViewById(R.id.groupreceipt);
        membername = (TextView) findViewById(R.id.tname);
        id = (TextView) findViewById(R.id.Tid);
        telephone = (TextView) findViewById(R.id.Ttelephone);
        totalrec =(TextView) findViewById(R.id.totalreceipt);
        find = (ImageButton) findViewById(R.id.find);

        find.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
               searchmember();
            }
        });
       memberno.setOnItemClickListener(new AdapterView.OnItemClickListener() {
           @Override
           public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
               searchmember();
           }
       });
        post = (Button) findViewById(R.id.post);
        post.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
               try{ if (T != null) {
                    db.post(T);
                    Bitmap b = BitmapFactory.decodeResource(getResources(),R.drawable.logo);
                    p.printcollection(b, db.gettransbybatch(Batch));
                    finish();
                }}catch (Exception ex){ex.printStackTrace();
               Toast.makeText(getApplicationContext(),"Unable to save, try again",Toast.LENGTH_LONG).show();}
            }
        });
        reprint = (Button)findViewById(R.id.reprint);
        reprint.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Bitmap b = BitmapFactory.decodeResource(getResources(),R.drawable.logo);
                p.printcollectioncopy(b, db.gettransbybatch(lastbatch));
            }
        });
        postnew = (Button) findViewById(R.id.postnew);
        postnew.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try{ if (T != null) {
                    db.post(T);
                    Bitmap b = BitmapFactory.decodeResource(getResources(),R.drawable.logo);
                    p.printcollection(b, db.gettransbybatch(Batch));
                    clearfarmer();
                    cleartrans();
                    lastbatch = Batch;
                    T = new transaction();
                    cdt = Calendar.getInstance();
                    batch = new SimpleDateFormat("yyyyMMddhhmm");
                    Batch =  batch.format(cdt.getTime());
                    memberno.requestFocus();
                }}catch (Exception ex){ex.printStackTrace();
                    Toast.makeText(getApplicationContext(),"Unable to save, try again",Toast.LENGTH_LONG).show();}
            }
        });
        //add
        addtrans = (Button) findViewById(R.id.addtrans);
        addtrans.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    memberno.setError(null);
                    amount.setError(null);
                    if (memberno.getText().toString().equals("")) {
                        memberno.setError("Member no required");
                        memberno.requestFocus();
                        return;
                    }
                  if (f==null){
                      memberno.setError("Member not found");
                      memberno.requestFocus();
                      return;
                  }
                    if (amount.getText().toString().equals("")) {
                        amount.setError("Amount is required");
                        amount.requestFocus();
                        return;
                    }
                    if (Double.parseDouble(amount.getText().toString()) == 0) {
                        amount.setError("Amount is required");
                        amount.requestFocus();
                        return;
                    }
                    if (t == null) {
                        Toast.makeText(getApplicationContext(), "Please select transaction type", Toast.LENGTH_LONG).show();
                        return;
                    }
                    Log.i("trans", String.valueOf(1));
                    cdt = Calendar.getInstance();
                    SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
                    final String formattedDate = df.format(cdt.getTime());
                    df = new SimpleDateFormat("HH:mm:ss");
                    final String formattedtime = df.format(cdt.getTime());
                    df = new SimpleDateFormat("yyyyMMddhhmmss");
                    final String Doc =  df.format(cdt.getTime());
                    Log.i("date", formattedDate);
                    Log.i("Time", formattedtime);
                    T = new transaction();
                    T.Date = formattedDate;
                    T.Time = formattedtime;
                    T.Mpesa = mpesaid.getText().toString();
                    T.Account_No = f.No;
                    T.Loan_No =grouprec.getText().toString();
                    T.Document_No = Doc;
                    T.Amount = (Double.parseDouble(amount.getText().toString()));
                    T.Account_Name = f.Name;
                    T.Agent_Code = login.CurrentAgent.Agent_Code;
                    T.Id_No = f.ID_No;
                    T.Telephone = f.Phone_No;
                    T.Transaction_Type = transaction.T_Type._blank_.ordinal();
                    T.OTTN = Batch;
                    T.sent = false;
                    T.Type = t.Code;

                    double a =Double.valueOf(mpesaamount.getText().toString());

                    if ((totalreceipt + T.Amount)> a){
                        new AlertDialog.Builder(cashreceipt.this)
                                .setTitle("excess Transaction")
                                .setMessage("Transactions amount Exceeds Paid Mpesa Amount")
                                .setIcon(android.R.drawable.ic_dialog_alert)
                                .setPositiveButton(android.R.string.ok, new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog, int which) {
                                       return;
                                    }
                                })
                             .show();
                    } else{

                        db.inserttrans(T);
                    Savefile(T);
                    Log.i("trans", String.valueOf(db.Totaltrans()));
                    ArrayList<transaction> tt = db.gettransbybatch(Batch);
                    Log.i("trans", String.valueOf(tt.size()));
                    double totalr = 0;
                    for (transaction tr: tt
                         ) {
                        totalr += tr.Amount;
                    }
                        totalreceipt = totalr;
                    totalrec.setText(String.valueOf(totalr));
                    ListAdapter fc = new trans(cashreceipt.this, tt,db);
                    ttrans.setAdapter(fc);
                    //clearfarmer();
                    cleartrans();}
                } catch (Exception ex) {
                    ex.printStackTrace();
                    Toast.makeText(getApplicationContext(), ex.getMessage(), Toast.LENGTH_LONG).show();
                }
            }
        });
    }
    private  void searchmember(){
        if (memberno.getText().toString().equals("")) {
            memberno.setError("Member no required");
            memberno.requestFocus();
            return;
        }
        f = db.getmember(memberno.getText().toString());
        if (f == null) {
            memberno.setError("Member no not found");
            memberno.selectAll();
            memberno.requestFocus();
            return;
        }
        membername.setText(f.Name);
        id.setText(f.ID_No);
        telephone.setText(f.Phone_No);
        if (f.Phone_No == null || f.ID_No == null) {
            Intent edit = new Intent(cashreceipt.this, memberedit.class);
            edit.putExtra("member", new Gson().toJson(f));
            startActivity(edit);
        }
        else if (f.Phone_No.equals("") || f.ID_No.equals(""))
        {   Intent edit = new Intent(cashreceipt.this, memberedit.class);
            edit.putExtra("member", new Gson().toJson(f));
            startActivity(edit);}
    }
    public static void Savefile( transaction c) {
        try {
            File root;
            if (android.os.Environment.getExternalStorageState().equals(
                    android.os.Environment.MEDIA_MOUNTED)) {
                root = new File(Environment.getExternalStorageDirectory(), "Mbranch/");
            } else
                root = new File("/data/Mbranch/");

            String data = c.Date+ " " +c.Time + "," + c.OTTN + "," + c.Document_No + "," + c.Type + "," + c.Amount + "," + c.Account_No + "," + c.Agent_Code + "\n";

            if (!root.exists()) {
                root.mkdirs();
            }
            File gpxfile = new File(root, c.Date);
            FileWriter writer = new FileWriter(gpxfile,true);
            writer.append(data);
            writer.flush();
            writer.close();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    private void clearfarmer() {
        memberno.setText("HBCWS-");
        memberno.setSelection(memberno.getText().length());
        membername.setText("");
        id.setText("");
        telephone.setText("");
        f = null;
        totalrec.setText("");
        ttrans.setAdapter(null);
        totalreceipt = 0;
    }
    private void cleartrans() {
        amount.setText("");
        ttypes.setSelection(0);
        mpesaid.setText("");
        mpesaamount.setText("0");
        t=null;
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);

        return true;
 }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {


        switch (item.getItemId()) {

            case R.id.settings: {
                Intent summary = new Intent(cashreceipt.this, Settings.class);
                startActivity(summary);
                return true;
            }

        }
        return super.onOptionsItemSelected(item);
    }
    private class Getmpesa extends AsyncTask<Void, String, List<mpesa>> {
        @Override
        protected void onPreExecute() {

        }


        protected void onProgressUpdate(String... progress) {
            Toast.makeText(getApplicationContext(), progress[0], Toast.LENGTH_LONG).show();
        }

        @Override
        protected List<mpesa> doInBackground(Void... params) {
            //publishProgress("Getting transaction Mpesa");
            List<mpesa> results = null;
            String result = null;
            try {
                Gson g = new Gson();
                result = JsonParser.postjson("GetPaybill", null, null);
                Type localType = new TypeToken<List<mpesa>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
                if (results != null) {
                    try {

                       // publishProgress("Updating transaction Mpesa");
                        for (mpesa f : results
                        ) {
                            db.insermpesa(f);
                        }
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
                }
            } catch (Exception e) {
                //publishProgress("Unable to get transaction mpesa");
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<mpesa> res) {
            try {
                if (res != null){}
                    //Toast.makeText(getApplicationContext(), "MPesa transactions updated", Toast.LENGTH_LONG).show();


            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
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
                for (member v : db.getmembers()
                        ) {
                    if (v.No != null) {
                        clients.add(v.No);
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
                AutoSuggestAdapter adapter = new AutoSuggestAdapter(cashreceipt.this, android.R.layout.simple_list_item_1, res);
                memberno.setAdapter(adapter);
                //  Toast.makeText(getApplicationContext(), res.size() + " Members attached", Toast.LENGTH_LONG).show();
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }


}
