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
    EditText amount,shares,court,welfare,loan,savings,operation,stage;
    AutoCompleteTextView memberno;
    TextView membername, id, totalrec, penalty, loanbalance, operationcost;
    ImageButton find, clear;
    Spinner ttypes, tvehicles, tloans;

    Button addtrans, postnew, reprint,distribute;
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

        permissions();


//                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB)
//            new getclients().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
//        else
//        new getclients().execute();
//write permission


        cdt = Calendar.getInstance();
        batch = new SimpleDateFormat("yyyyMMddHHmmss");
        Batch = batch.format(cdt.getTime());
        memberno = (AutoCompleteTextView) findViewById(R.id.memberno);
        memberno.setSelection(memberno.getText().length());
        amount = (EditText) findViewById(R.id.tamount);
        amount.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View view, boolean b) {
                //if (b==false)
                    //totalrec.setText(amount.getText());
            }
        });
        shares = (EditText) findViewById(R.id.eshares);

        court = (EditText) findViewById(R.id.ecourt);
        operation = (EditText) findViewById(R.id.eoperation);
        welfare = (EditText) findViewById(R.id.ewelfare);
        savings = (EditText) findViewById(R.id.esavings);
        stage = (EditText) findViewById(R.id.estage);
        loan = (EditText) findViewById(R.id.eloan);
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
                    vv = veh;
                    selectedvehicle = veh.Vehicle_Number;
                    currentvehcle = veh;
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
                membername.setText(f.Name);
                id.setText(f.No);
                loanbalance.setText("Loan Balance: " + String.valueOf(f.Loan_Balances));
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
                    vv = veh;
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

                membername.setText(f.Name);
                id.setText(f.No);
                loanbalance.setText("Loan Balance: " + String.valueOf(f.Loan_Balances));


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

                    save();


                } catch (Exception ex) {
                    ex.printStackTrace();
                    Toast.makeText(getApplicationContext(), "Unable to save, try again", Toast.LENGTH_LONG).show();
                }
            }
        });
        //add
        //distribute
        distribute = (Button) findViewById(R.id.distribute);
        distribute.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (currentvehcle != null) {
                    double am = 0;
                    if (amount.getText().toString().equals("")) {
                        amount.setError("Amount is required");
                        amount.requestFocus();
                        return;
                    }
                    am = Double.valueOf(amount.getText().toString());
                    if (am >= currentvehcle.Daily_Contribution)
                        operation.setText(String.valueOf(currentvehcle.Daily_Contribution));
                    else
                        operation.setText(String.valueOf(am));
                    am -= Double.valueOf(operation.getText().toString());

                    if (am >= currentvehcle.Daily_Welfare)
                        welfare.setText(String.valueOf(currentvehcle.Daily_Welfare));
                    else
                        welfare.setText(String.valueOf(am));
                    am -= Double.valueOf(welfare.getText().toString());

                    if (am >= currentvehcle.Daily_Court_Bond)
                        court.setText(String.valueOf(currentvehcle.Daily_Court_Bond));
                    else
                        court.setText(String.valueOf(am));
                    am -= Double.valueOf(court.getText().toString());

                    if (am >= currentvehcle.Daily_Shares)
                        shares.setText(String.valueOf(currentvehcle.Daily_Shares));
                    else
                        shares.setText(String.valueOf(am));
                    am -= Double.valueOf(shares.getText().toString());

                    if (am >= 50)
                        stage.setText("50");
                    else
                        stage.setText(String.valueOf(am));
                    am -= Double.valueOf(stage.getText().toString());

                    if (am >= 500)
                        loan.setText("500");
                    else
                        loan.setText(String.valueOf(am));
                    am -= Double.valueOf(loan.getText().toString());
                    savings.setText(String.valueOf(am));
                }
            }
        });
        View.OnFocusChangeListener focusChangeListener = new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View view, boolean b) {
                if (b=false);
                {
                    Double d = (shares.getText().toString().equals("") ? 0 : Double.valueOf(shares.getText().toString())) +
                            (welfare.getText().toString().equals("") ? 0 : Double.valueOf(welfare.getText().toString()))+
                            (savings.getText().toString().equals("") ? 0 : Double.valueOf(savings.getText().toString()))+
                            (court.getText().toString().equals("") ? 0 : Double.valueOf(court.getText().toString()))+
                            (operation.getText().toString().equals("") ? 0 : Double.valueOf(operation.getText().toString()))+
                            (stage.getText().toString().equals("") ? 0 : Double.valueOf(stage.getText().toString()))+
                            (loan.getText().toString().equals("") ? 0 : Double.valueOf(loan.getText().toString()));
                    Log.i("tt",String.valueOf(d));
                 amount.setText(String.valueOf(d));
                    totalrec.setText(amount.getText());

                }
            }
        };
        shares.setOnFocusChangeListener(focusChangeListener);
        welfare.setOnFocusChangeListener(focusChangeListener);
        savings.setOnFocusChangeListener(focusChangeListener);
        court.setOnFocusChangeListener(focusChangeListener);
        operation.setOnFocusChangeListener(focusChangeListener);
        stage.setOnFocusChangeListener(focusChangeListener);
        loan.setOnFocusChangeListener(focusChangeListener);
    }

    private void save()
    {
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
            T.Stage = Double.parseDouble( (stage.getText().toString().equals("")?"0":stage.getText().toString()));
            T.Savings = Double.parseDouble((savings.getText().toString().equals("")?"0":savings.getText().toString()));
            T.Shares = Double.parseDouble(shares.getText().toString().equals("")?"0":shares.getText().toString());
            T.Welfare = Double.parseDouble(welfare.getText().toString().equals("")?"0":welfare.getText().toString());
            T.Loan = Double.parseDouble(loan.getText().toString().equals("")?"0":loan.getText().toString());
            T.Operation = Double.parseDouble(operation.getText().toString().equals("")?"0":operation.getText().toString());
            T.Court_Bond = Double.parseDouble(court.getText().toString().equals("")?"0":court.getText().toString());
            T.Account_Name = f.Name;
            T.Agent_Code = Myvariables.CurrentAgent.Agent_Code;// login.CurrentAgent.Agent_Code;
            T.Telephone = f.Phone_No;
            T.Transaction_Type = transaction.T_Type._blank_.ordinal();
            T.OTTN = Batch;
            T.sent = true;
            //T.Type = t.Code;
            //T.typename = t.Name;
            T.Loan_No = selectedvehicle;
            T.Ward = selectedtext;
            T.Id_No = selectedloan;
            final transaction ttt = T;
            ArrayList<transaction> list = db.gettransbytype(T.Date, T.Loan_No, T.Type);
            if (list.size() > 0) {
                new AlertDialog.Builder(cashreceipt.this)
                        .setTitle("Duplicate Transaction")
                        .setMessage(T.Loan_No + " transaction of " + list.get(0).Amount + " has been paid Today. Do you want to Pay again.")
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
                                db.post(T);
                                Bitmap b = BitmapFactory.decodeResource(getResources(), R.mipmap.logo);
                                p.printcollection(b, T);
                                clearfarmer();
                                cleartrans();
                                lastbatch = Batch;
                                T = new transaction();
                                cdt = Calendar.getInstance();
                                batch = new SimpleDateFormat("yyyyMMddHHmmss");
                                Batch = batch.format(cdt.getTime());
                                memberno.requestFocus();
                            }
                        })
                        .setNegativeButton(android.R.string.no, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int whichButton) {

                                Toast.makeText(getApplicationContext(), "Transaction cancelled.", Toast.LENGTH_LONG).show();
                                return;
                            }
                        }).show();
            } else {
                db.inserttrans(T);
                ArrayList<transaction> tt = db.gettransbybatch(ttt.OTTN);
                double totalr = 0;
                for (transaction tr : tt
                ) {
                    totalr += tr.Amount;
                }
                totalrec.setText(String.valueOf(totalr));
                ListAdapter fc = new trans(cashreceipt.this, tt, db);

                db.post(T);
                Bitmap b = BitmapFactory.decodeResource(getResources(), R.mipmap.logo);
                p.printcollection(b, T);
                clearfarmer();
                cleartrans();
                lastbatch = Batch;
                T = new transaction();
                cdt = Calendar.getInstance();
                batch = new SimpleDateFormat("yyyyMMddHHmmss");
                Batch = batch.format(cdt.getTime());
                memberno.requestFocus();
            }
            Savefile(T);
            ArrayList<transaction> tt = db.gettransbybatch(Batch);
            double totalr = 0;
            for (transaction tr : tt
            ) {
                totalr += tr.Amount;
            }
            totalrec.setText(String.valueOf(totalr));
            ListAdapter fc = new trans(cashreceipt.this, tt, db);

            cleartrans();
        } catch (Exception ex) {
            ex.printStackTrace();
            Toast.makeText(getApplicationContext(), ex.getMessage(), Toast.LENGTH_LONG).show();
        }


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
    String data = c.Date + " " + c.Time + "," + c.OTTN + "," + c.Document_No + "," + c.Type + "," +
            c.Amount + "," +
            c.Shares + "," +
            c.Savings + "," +
            c.Welfare + "," +
            c.Loan + "," +
            c.Stage + "," +
            c.Operation + "," +
            c.Court_Bond + "," +
            c.Account_No + "," + c.Agent_Code + "\n";
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
        savings.setText("");
        shares  .setText("");
        stage.setText("");
        welfare.setText("");
        operation.setText("");
        court.setText("");
        loan.setText("");
        f = null;
        totalrec.setText("");

    }

    private void cleartrans() {
        amount.setText("");

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
