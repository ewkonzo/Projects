package com.example.paul.m_branch;

import android.Manifest;
import android.annotation.TargetApi;
import android.app.AlertDialog;
import android.bluetooth.BluetoothDevice;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.media.Image;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.support.annotation.NonNull;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.telephony.TelephonyManager;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
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

import static android.Manifest.permission.READ_EXTERNAL_STORAGE;
import static android.Manifest.permission.WRITE_EXTERNAL_STORAGE;

public class cashreceipt extends AppCompatActivity {
    EditText amount;
    AutoCompleteTextView memberno;
    TextView membername, id, totalrec, penalty, loanbalance, operationcost;
    ImageButton find, clear;
    Spinner ttypes, tvehicles, tloans;
    String type;
    Button addtrans, postnew, reprint;
    ProgressBar findmember;
    Calendar cdt;
    transaction T;
    DB db = null;
    member f;
    List<vehicles> mvehicles = new ArrayList<>();
    SimpleDateFormat batch;
    static String Batch, lastbatch;
    types t;
    vehicles vv ;
    ListView ttrans;
    SharedPreferences preferences;
    private summaries.printer p = new summaries.printer();
    static ArrayAdapter<loan> loanAdapter;
    static ArrayAdapter<vehicles> vehicleAdapter;
    String selectedvalue;
    String selectedtext = "";
    String selectedvehicle = "";
    String selectedloan = "";
    vehicles currentvehcle;

    final static int MY_PERMISSIONS_REQUEST_READ_CONTACTS = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cashreceipt);
        preferences = getSharedPreferences("Settings", MODE_PRIVATE);
        db = new DB(this);
        ttrans = (ListView) (findViewById(R.id.ttrans));
        ttypes = (Spinner) findViewById(R.id.ttype);
        tvehicles = (Spinner) findViewById(R.id.tvehicles);
        tloans = (Spinner) findViewById(R.id.tloans);
        permissions();


//                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB)
//            new getclients().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
//        else
//        new getclients().execute();
//write permission

        final ArrayAdapter<types> dataAdapter;
        dataAdapter = new ArrayAdapter<types>(this,
                android.R.layout.simple_spinner_item, db.gettypes());
        dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        ttypes.setAdapter(dataAdapter);

        ttypes.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                try {
                    t = dataAdapter.getItem(position);
                    selectedvalue = "";
                    selectedtext = "";
                    selectedloan = "";
                    type = "";
                    if (t.Code != null)
                        if (t.Attach_to_vehicle) {
                            tvehicles.setVisibility(View.VISIBLE);
                            vehicleAdapter = new ArrayAdapter<vehicles>(cashreceipt.this,
                                    android.R.layout.simple_spinner_item, mvehicles);
                            vehicleAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

                            tvehicles.setAdapter(vehicleAdapter);
                            if (!selectedvehicle.equals("")) {
                                tvehicles.setSelection(getIndex(tvehicles, selectedvehicle));
                            }
                        }
                    if (t.Code.equals("LOAN")) {
                        tloans.setVisibility(View.VISIBLE);
                        loanAdapter = new ArrayAdapter<loan>(cashreceipt.this,
                                android.R.layout.simple_spinner_item, db.getcustomerloans(f.No));
                        loanAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                        tloans.setAdapter(loanAdapter);
                    } else
                        tloans.setVisibility(View.GONE);
                    //if (vv!=null){
                    switch (t.Code)
                    {
                        case "SERVICE FEE":
                        {
                            amount.setText(String.valueOf(vv.Daily_Contribution));
                        }
                        case "COURT":
                        {
                            amount.setText(String.valueOf(vv.Daily_Court_Bond));
                        }
                        case "WELFARE":
                        {
                            amount.setText(String.valueOf(vv.Daily_Welfare));
                        }
                        case "SACCO":
                        {
                            amount.setText(String.valueOf(vv.Daily_Shares));
                        }
                        default:
                        {amount.setText("");}
                    }
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
            }
        });
        tvehicles.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                selectedvalue = vehicleAdapter.getItem(position).Vehicle_Number;
vv = vehicleAdapter.getItem(position);
//                if (t.Code.equals("SERVICE FEE"))
//                    amount.setText(String.valueOf(vehicleAdapter.getItem(position).Daily_Contribution));
//                else

                amount.setSelection(0, amount.getText().length());
            }


            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });
        tloans.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                selectedloan = loanAdapter.getItem(position).Credit_Number;
                selectedtext = loanAdapter.getItem(position).Loan;
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });
        cdt = Calendar.getInstance();
        batch = new SimpleDateFormat("yyyyMMddHHmmss");
        Batch = batch.format(cdt.getTime());
        memberno = (AutoCompleteTextView) findViewById(R.id.memberno);
        memberno.setSelection(memberno.getText().length());
        amount = (EditText) findViewById(R.id.tamount);
        membername = (TextView) findViewById(R.id.name);
        id = (TextView) findViewById(R.id.id);
        operationcost = (TextView) findViewById(R.id.operation);
        loanbalance = (TextView) findViewById(R.id.LoanBalance);
        penalty = (TextView) findViewById(R.id.Penalty);
        memberno.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long iid) {
                f = null;
                membername.setText("");
                id.setText("");
                loanbalance.setText("");
                penalty.setText("");
                operationcost.setText("");

                selectedvehicle = "";
                Toast.makeText(getApplicationContext(), memberno.getText().toString(), Toast.LENGTH_LONG).show();
                vehicles veh = db.getvehicle(memberno.getText().toString());
                if (veh != null) {
                    vv= veh;
                    selectedvehicle = veh.Vehicle_Number;
                    Log.i("v1", veh.Code);
                    f = db.getmemberbyid(veh.Code);
                    Log.i("arrears", String.valueOf(veh.Arrears));
                    penalty.setText("Penalty: " + String.valueOf(veh.Penalty));

                    operationcost.setText("Operation: " + String.valueOf(veh.Arrears));
                }
                if (f == null) {
                    f = db.getmember(memberno.getText().toString());
                }
                if (f == null) {
                    f = db.getmember(memberno.getText().toString());
                }
                if (f == null) {
                    f = db.getmember(String.format("%4s", memberno.getText().toString()).replace(' ', '0'));
                }
                if (f == null) {
                    memberno.setError("Member/vehicle no not found");
                    memberno.selectAll();
                    memberno.requestFocus();
                    return;
                }

                amount.requestFocus();
                ttypes.setAdapter(dataAdapter);
                membername.setText(f.Name);
                id.setText(f.No);
                loanbalance.setText("Loan Balance: " + String.valueOf(f.Loan_Balances));

                ttypes.setSelection(0, true);
                tvehicles.setAdapter(null);
                mvehicles = db.getcustomervehicles(f.No);
            }
        });
        ArrayList<String> clients = new ArrayList<>();
        String result = null;
        try {
            for (vehicles v : db.getvehicles()
                    ) {
                if (v.Vehicle_Number != null) {
                    clients.add(v.Vehicle_Number);

                }
            }
            for (member m : db.getmembers()
                    ) {
                if (m.No != null) {
                    clients.add(m.No);
                    Log.i("Member", m.No);
                }
            }

        } catch (Exception e) {
            Log.i("autocomplete", e.getMessage());
            e.printStackTrace();
        }
        Myvariables.vehs = clients;

        AutoSuggestAdapter adapter = new AutoSuggestAdapter(cashreceipt.this, android.R.layout.simple_list_item_1, Myvariables.vehs);
        memberno.setAdapter(adapter);
        totalrec = (TextView) findViewById(R.id.totalreceipt);
        clear = (ImageButton) findViewById(R.id.clear);
        clear.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                memberno.setText("");
            }
        });
        find = (ImageButton) findViewById(R.id.find);
        find.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                f = null;
                membername.setText("");
                id.setText("");
                loanbalance.setText("");
                penalty.setText("");
                operationcost.setText("");
                if (memberno.getText().toString().equals("")) {
                    memberno.setError("Member no required");
                    memberno.requestFocus();
                    return;
                }
                selectedvehicle = "";
                vehicles veh = db.getvehicle(memberno.getText().toString());
                if (veh != null) {
                    vv=veh;
                    selectedvehicle = veh.Vehicle_Number;
                    f = db.getmemberbyid(veh.Code);
                    Log.i("arrears", String.valueOf(veh.Arrears));
                    penalty.setText("Penalty: " + String.valueOf(veh.Penalty));

                    operationcost.setText("Operation: " + String.valueOf(veh.Arrears));
                }
                if (f == null) {
                    f = db.getmember(memberno.getText().toString());
                }
                if (f == null) {
                    f = db.getmember(memberno.getText().toString());
                }
                if (f == null) {
                    f = db.getmember(String.format("%4s", memberno.getText().toString()).replace(' ', '0'));
                }
                if (f == null) {
                    memberno.setError("Member/vehicle no not found");
                    memberno.selectAll();
                    memberno.requestFocus();
                    return;
                }

                amount.requestFocus();
                ttypes.setAdapter(dataAdapter);
                membername.setText(f.Name);
                id.setText(f.No);
                loanbalance.setText("Loan Balance: " + String.valueOf(f.Loan_Balances));

                ttypes.setSelection(0, true);
                tvehicles.setAdapter(null);
                mvehicles = db.getcustomervehicles(f.ID_No);

            }
        });

        reprint = (Button) findViewById(R.id.reprint);
        reprint.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Bitmap b = BitmapFactory.decodeResource(getResources(), R.mipmap.logo);
                p.printcollectioncopy(b, db.gettransbybatch(lastbatch));
            }
        });
        postnew = (Button) findViewById(R.id.postnew);
        postnew.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    if (T != null) {
                        db.post(T);
                        Bitmap b = BitmapFactory.decodeResource(getResources(), R.mipmap.logo);
                        p.printcollection(b, db.gettransbybatch(Batch));
                        clearfarmer();
                        cleartrans();
                        lastbatch = Batch;
                        T = new transaction();
                        cdt = Calendar.getInstance();
                        batch = new SimpleDateFormat("yyyyMMddHHmmss");
                        Batch = batch.format(cdt.getTime());
                        memberno.requestFocus();
                    }
                } catch (Exception ex) {
                    ex.printStackTrace();
                    Toast.makeText(getApplicationContext(), "Unable to save, try again", Toast.LENGTH_LONG).show();
                }
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
                    if (f == null) {
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
                    cdt = Calendar.getInstance();
                    SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
                    final String formattedDate = df.format(cdt.getTime());
                    df = new SimpleDateFormat("HH:mm:ss");
                    final String formattedtime = df.format(cdt.getTime());
                    TelephonyManager mngr = (TelephonyManager) getSystemService(Context.TELEPHONY_SERVICE);
                    String iidd = mngr.getDeviceId();
                    df = new SimpleDateFormat("yyyyMMddHHmmss");
                    final String Doc = df.format(cdt.getTime());
                    T = new transaction();
                    T.Date = formattedDate;
                    T.Time = formattedtime;
                    T.Account_No = f.No;
                    T.Document_No = iidd.substring(iidd.length() - 5) + Doc;
                    T.Amount = (Double.parseDouble(amount.getText().toString()));
                    T.Account_Name = f.Name;
                    T.Agent_Code = Myvariables.CurrentAgent.Agent_Code;// login.CurrentAgent.Agent_Code;
                    T.Telephone = f.Phone_No;
                    T.Transaction_Type = transaction.T_Type._blank_.ordinal();
                    T.OTTN = Batch;
                    T.sent = true;
                    T.Type = t.Code;
                    T.typename = t.Name;
                    T.Loan_No = selectedvehicle;
                    T.Ward = selectedtext;
                    T.Id_No = selectedloan;
                    final transaction ttt = T;
                    ArrayList<transaction> list = db.gettransbytype(T.Date, T.Loan_No, T.Type);
                    if (list.size() > 0) {
                        new AlertDialog.Builder(cashreceipt.this)
                                .setTitle("Duplicate Transaction")
                                .setMessage(T.Loan_No + " " + T.typename + " of " + list.get(0).Amount + " has been paid Today. Do you want to Pay again.")
                                .setIcon(android.R.drawable.ic_dialog_alert)
                                .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog, int which) {
                                        db.inserttrans(ttt);
                                        ArrayList<transaction> tt = db.gettransbybatch(ttt.OTTN);
                                        double totalr = 0;
                                        for (transaction tr : tt
                                                ) {
                                            totalr += tr.Amount;
                                        }
                                        totalrec.setText(String.valueOf(totalr));
                                        ListAdapter fc = new trans(cashreceipt.this, tt, db);
                                        ttrans.setAdapter(fc);
                                    }
                                })
                                .setNegativeButton(android.R.string.no, new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialog, int whichButton) {

                                        Toast.makeText(getApplicationContext(), "Transaction cancelled.", Toast.LENGTH_LONG).show();
                                        return;
                                    }
                                }).show();
                    } else
                        db.inserttrans(T);

                    Savefile(T);
                    ArrayList<transaction> tt = db.gettransbybatch(Batch);
                    double totalr = 0;
                    for (transaction tr : tt
                            ) {
                        totalr += tr.Amount;
                    }
                    totalrec.setText(String.valueOf(totalr));
                    ListAdapter fc = new trans(cashreceipt.this, tt, db);
                    ttrans.setAdapter(fc);
                    cleartrans();
                } catch (Exception ex) {
                    ex.printStackTrace();
                    Toast.makeText(getApplicationContext(), ex.getMessage(), Toast.LENGTH_LONG).show();
                }
            }
        });
    }
    private static final int PERMISSION_REQUEST_CODE = 200;
    private  boolean checkPermission(transaction c) {

        return ContextCompat.checkSelfPermission(this, WRITE_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED
                && ContextCompat.checkSelfPermission(this, READ_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED
                ;
    }

    private void requestPermissionAndContinue(transaction c) {
        if (ContextCompat.checkSelfPermission(this, WRITE_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED
                && ContextCompat.checkSelfPermission(this, READ_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED) {

            if (ActivityCompat.shouldShowRequestPermissionRationale(this, WRITE_EXTERNAL_STORAGE)
                    && ActivityCompat.shouldShowRequestPermissionRationale(this, READ_EXTERNAL_STORAGE)) {
                AlertDialog.Builder alertBuilder = new AlertDialog.Builder(this);
                alertBuilder.setCancelable(true);
                alertBuilder.setTitle("Required Permission");
                alertBuilder.setMessage("Application requires access rights");
                alertBuilder.setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                    @TargetApi(Build.VERSION_CODES.JELLY_BEAN)
                    public void onClick(DialogInterface dialog, int which) {
                        ActivityCompat.requestPermissions(cashreceipt.this, new String[]{WRITE_EXTERNAL_STORAGE
                                , READ_EXTERNAL_STORAGE}, PERMISSION_REQUEST_CODE);
                    }
                });
                AlertDialog alert = alertBuilder.create();
                alert.show();
                Log.e("", "permission denied, show dialog");
            } else {
                ActivityCompat.requestPermissions(cashreceipt.this, new String[]{WRITE_EXTERNAL_STORAGE,
                        READ_EXTERNAL_STORAGE}, PERMISSION_REQUEST_CODE);
            }
        } else {
            createfile(c);
        }
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {

        if (requestCode == PERMISSION_REQUEST_CODE) {
            if (permissions.length > 0 && grantResults.length > 0) {

                boolean flag = true;
                for (int i = 0; i < grantResults.length; i++) {
                    if (grantResults[i] != PackageManager.PERMISSION_GRANTED) {
                        flag = false;
                    }
                }

            } else {

            }
        } else {
            super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }


    @Override
    public void onResume(){
        super.onResume();
        String pref ="";
        String value = preferences.getString("User", "");
        if (value != null || value != "") {
            Log.i("User",value);
            Myvariables.CurrentAgent = db.getagent(value.toUpperCase());
            if (Myvariables.CurrentAgent !=null){
                Log.i("User","Found User"+ Myvariables.CurrentAgent.Name);
            }
        }

    }

    public void permissions() {
        int permissionCheck = ContextCompat.checkSelfPermission(this, Manifest.permission.READ_PHONE_STATE);
        if (permissionCheck != PackageManager.PERMISSION_GRANTED) {
            if (ActivityCompat.shouldShowRequestPermissionRationale(this,
                    Manifest.permission.READ_PHONE_STATE)) {

                // Show an explanation to the user *asynchronously* -- don't block
                // this thread waiting for the user's response! After the user
// sees the explanation, try again to request the permission.

            } else {

// No explanation needed, we can request the permission.

                ActivityCompat.requestPermissions(this,
                        new String[]{Manifest.permission.READ_PHONE_STATE},
                        MY_PERMISSIONS_REQUEST_READ_CONTACTS);

                // MY_PERMISSIONS_REQUEST_READ_CONTACTS is an
                // app-defined int constant. The callback method gets the
                // result of the request.
            }


        }
    }



    private int getIndex(Spinner spinner, String myString) {
        int index = 0;

        for (int i = 0; i < spinner.getCount(); i++) {
            if (((vehicles) spinner.getItemAtPosition(i)).Code.toString().equalsIgnoreCase(myString)) {
                index = i;
                break;
            }
        }
        return index;
    }
public static void createfile(transaction c)
{
    try {
    Log.i("File","Saving file");
    File root;
    if (android.os.Environment.getExternalStorageState().equals(
            android.os.Environment.MEDIA_MOUNTED)) {
        root = new File(Environment.getExternalStorageDirectory(), "Mbranch/");
    } else
        root = new File("/data/Mbranch/");
    String data = c.Date + " " + c.Time + "," + c.OTTN + "," + c.Document_No + "," + c.Type + "," + c.Amount + "," + c.Account_No + "," + c.Agent_Code + "\n";
    if (!root.exists()) {
        root.mkdirs();
    }
    File gpxfile = new File(root, c.Date);
    FileWriter writer = new FileWriter(gpxfile, true);
    writer.append(data);
    writer.flush();
    writer.close();

    }
    catch (IOException e) {
        e.printStackTrace();
    }catch (Exception ex) {
        ex.printStackTrace();
    }
}

    public  void Savefile(transaction c) {
        try {
            if (!checkPermission(c)) {
               createfile(c);
            } else {
                if (checkPermission(c)) {
                    requestPermissionAndContinue(c);
                } else {
                    createfile(c);
                }
            }



        }catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    private void clearfarmer() {
        memberno.setText("");
        memberno.setSelection(memberno.getText().length());
        membername.setText("");
        id.setText("");

        f = null;
        totalrec.setText("");
        ttrans.setAdapter(null);
    }

    private void cleartrans() {
        amount.setText("");
        ttypes.setSelection(0);
        selectedvalue = "";
        selectedtext = "";
        selectedloan = "";
        //t = null;
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);

        return true;
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
                for (member m : db.getmembers()
                        ) {
                    if (m.No != null) {
                        clients.add(m.No);
                        Log.i("Member", m.No);
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
