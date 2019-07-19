package com.example.paul.m_branch;

import android.bluetooth.BluetoothDevice;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.media.AudioAttributes;
import android.media.MediaPlayer;
import android.media.audiofx.BassBoost;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Handler;
import android.os.Message;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.ExpandableListView;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;
import java.util.List;

public class menu extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener
{
    Button  cash,paymentstatus;
    DB db;
    CheckBox printer;
    SharedPreferences preferences;
    private summaries.printer p = new summaries.printer();
    summaries.Printerthread sp;
    private updatemembers membersupdate;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        cash = (Button) findViewById(R.id.CashReceipt);
        paymentstatus = (Button) findViewById(R.id.Paymentstatus);
        db = new DB(this);
        printer = (CheckBox) findViewById(R.id.printer);
        preferences = getSharedPreferences("Settings", MODE_PRIVATE);
        JsonParser.preferences = preferences;
        summaries.mHandler = mHandler;
        sp = new summaries.Printerthread(preferences);
        sp.start();
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();
        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);
        membersupdate = new updatemembers();
        membersupdate.start();

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB) {
            new Getmembers().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
            new Gettypes().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
            new Getloans().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
        } else {
            new Getmembers().execute();
            new Getloans().execute();
            new Getloans().execute();
        }
        cash.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(menu.this, cashreceipt.class));
            }
        });
        paymentstatus.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(menu.this, status.class));
            }
        });
        IntentFilter filter = new IntentFilter(BluetoothDevice.ACTION_ACL_DISCONNECTED);
        registerReceiver(mReceiver, filter);
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {


        switch (item.getItemId()) {

            case R.id.settings: {
                Intent summary = new Intent(menu.this, Settings.class);
                startActivity(summary);
                return true;
            }

        }
        return super.onOptionsItemSelected(item);
    }
    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        Intent i = null;
        int id = item.getItemId();
        if (id == R.id.nav_settings) {
            i = new Intent(this, Settings.class);
        } else if (id == R.id.summary) {
            i= new Intent(this,summary.class);
        } else if (id == R.id.vehicle_collection) {
            i= new Intent(this,vehiclereport.class);
        }else if (id == R.id.receipts) {
            i= new Intent(this,receiptreport.class);
        }
        if (i != null)
            startActivity(i);
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }
    @Override
    protected void onDestroy() {
        super.onDestroy();
        try {
            if (p.printersock != null) {
                p.printerout.close();
                p.printersock.close();
                p.printersock = null;
                sp.cancel();
                Log.i("disconnect","bluetooth");
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    private class Gettypes extends AsyncTask<Void, String, List<types>> {
        @Override
        protected void onPreExecute() {

        }


        protected void onProgressUpdate(String... progress) {
            Toast.makeText(getApplicationContext(), progress[0], Toast.LENGTH_LONG).show();
        }

        @Override
        protected List<types> doInBackground(Void... params) {
            //publishProgress("Getting transaction types");
            List<types> results = null;
            String result = null;
            try {
                Gson g = new Gson();

                result = JsonParser.postjson("Transtypes", null, null);
                Type localType = new TypeToken<List<types>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
                if (results != null) {
                    try {
                       db.deleteAlltypes();
                        //publishProgress("Updating transaction types");
                        for (types f : results
                                ) {
                            db.inserttype(f);
                        }
                    } catch (Exception ex) {
                       // publishProgress("Unable to get transaction types");
                        ex.printStackTrace();
                    }
                }
            } catch (Exception e) {
                publishProgress("Unable to get transaction types");
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<types> res) {
            try {
                //if (res != null)
                    //Toast.makeText(getApplicationContext(), "Transaction types updated", Toast.LENGTH_LONG).show();


            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
    private class Getloans extends AsyncTask<Void, String, List<loan>> {
        @Override
        protected void onPreExecute() {

        }


        protected void onProgressUpdate(String... progress) {
            Toast.makeText(getApplicationContext(), progress[0], Toast.LENGTH_LONG).show();
        }

        @Override
        protected List<loan> doInBackground(Void... params) {
           // publishProgress("Getting Credits");
            List<loan> results = null;
            String result = null;
            try {
                Gson g = new Gson();

                result = JsonParser.postjson("loans", null, null);
                Type localType = new TypeToken<List<loan>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
                if (results != null) {
                    try {
                        db.deleteloans();
                       // publishProgress("Updating Credits");
                        for (loan f : results
                                ) {
                            db.inserloans(f);
                        }
                    } catch (Exception ex) {
                        publishProgress("Unable to get Credits");
                        ex.printStackTrace();
                    }
                }
            } catch (Exception e) {
                publishProgress("Unable to get Credits");
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<loan> res) {
            try {
//                if (res != null)
//                    Toast.makeText(getApplicationContext(), "Credits updated", Toast.LENGTH_LONG).show();


            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
    private class Getmembers extends AsyncTask<Void, String, List<member>> {
        @Override
        protected void onPreExecute() {

        }
        protected void onProgressUpdate(String... progress) {
            Toast.makeText(getApplicationContext(), progress[0], Toast.LENGTH_SHORT).show();
        }
        @Override
        protected List<member> doInBackground(Void... params) {

            List<member> results = null;
            String result = null;
            try {
//                ArrayList<Constituency> con = db.getconstituencies();
//                for (Constituency v : con
//                        ) {
                   // publishProgress("Getting members" );
                    try {
                        Gson g = new Gson();
                        result = JsonParser.postjson("members", null,null);
                        Type localType = new TypeToken<List<member>>() {
                        }.getType();

                        results = new Gson().fromJson(result, localType);

                        if (results != null) {
                            //Log.i("nosss", String.valueOf(results .size()));
                           // publishProgress("Updating members for: " + login.CurrentAgent.Constituency);
                            for (member f : results
                                    ) {
                                db.insertmember(f);
                            }
                        }
                        // publishProgress(results.size()+  " Members updated");
                    } catch (Exception ex) {
                        publishProgress("Unable to get members ");
                        ex.printStackTrace();
                    }

                //}
            } catch (Exception e) {
                publishProgress("Unable to get members");
                e.printStackTrace();
            }
            return results;
        }
        @Override
        protected void onPostExecute(List<member> res) {
            try {
                // if (res!=null)
                // Toast.makeText(getApplicationContext(),res.size()+  " Members updated",Toast.LENGTH_LONG).show();
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
    private class updatemembers extends Thread {
        public updatemembers() {
            Log.i("Sending..", "Sending Started");
        }
        public void run() {
            try {
                while (true) {
                    //new updatemember(db.getupdatedmember()).execute();
                    new collections(db.getunsenttrans()).execute();

//                   Calendar cdt = Calendar.getInstance();
//                    SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
//                    final String formattedDate = df.format(cdt.getTime());
//
//                    summaries.getdata g = new summaries.getdata();
//                    g.firstdate=formattedDate;
//                    g.user = login.CurrentAgent.Agent_Code;
//
//                    new getcollections(g).execute();

                    this.sleep(20000);
                }
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
    private String mConnectedDeviceName = null;
    private class collections extends AsyncTask<List<transaction>, Void, List<transaction>> {
        List<transaction> c = null;
        collections(List<transaction> ff) {
            c = ff;
        }
        @Override
        protected void onPreExecute() {

        }
        @Override
        protected List<transaction> doInBackground(List<transaction>... params) {
            List<transaction> results = null;
            String result = null;
            try {
                for (transaction cc : c
                        ) {
                    transaction res = null;
                    Gson g = new Gson();
                    result = g.toJson(cc);
                    result = JsonParser.postjson("Collections", "data", result);
                    Type localType = new TypeToken<transaction>() {
                    }.getType();
                    res = new Gson().fromJson(result, localType);
                    if (res != null) {
                        res.sent = true;
                        db.updatetransstatus(res);
                    }
                }
            } catch (Exception e) {
                e.printStackTrace();
                results = c;
            }
            return results;
        }
        @Override
        protected void onPostExecute(List<transaction> res) {
            try {

            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }

    private class getcollections extends AsyncTask<summaries.getdata, Void, List<transaction>> {
       summaries.getdata c = null;
        getcollections(summaries.getdata ff) {
            c = ff;
        }
        @Override
        protected void onPreExecute() {
        }
        @Override
        protected  List<transaction> doInBackground(summaries.getdata... params) {
            List<transaction> results = null;
            String result = null;
            try {
                     Gson g = new Gson();
                    result = g.toJson(c);
                    result = JsonParser.postjson("GetCollections", "data", result);
                    Type localType = new TypeToken<List<transaction>>() {
                    }.getType();
                    results = new Gson().fromJson(result, localType);
                    if (results != null) {
                        for (transaction f : results
                                ) {
                        f.sent = true;
                        db.inserttrans(f);
                    }
                    }

            } catch (Exception e) {
                e.printStackTrace();

            }
            return results;
        }
        @Override
        protected void onPostExecute(List<transaction> res) {
            try {

            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
    private final Handler mHandler = new Handler() {
        @Override
        public void handleMessage(Message msg) {
            switch (msg.what) {
//                case Constants.MESSAGE_STATE_CHANGE:
//                    switch (msg.arg1) {
//                        case BluetoothChatService.STATE_CONNECTED:
//                            setStatus(getString(R.string.title_connected_to, mConnectedDeviceName));
//                            mConversationArrayAdapter.clear();
//                            break;
//                        case BluetoothChatService.STATE_CONNECTING:
//                            setStatus("Connecting");
//                            break;
//                        case BluetoothChatService.STATE_LISTEN:
//                        case BluetoothChatService.STATE_NONE:
//                            setStatus("Not connected");
//                            break;
//
//                    }
//                    break;
                case Constants.MESSAGE_WRITE:
                    byte[] writeBuf = (byte[]) msg.obj;
                    // construct a string from the buffer
                    String writeMessage = new String(writeBuf);

                    break;

                case Constants.PRINTER_CONNECTED:
                    Toast.makeText(getApplicationContext(), "Printer connected", Toast.LENGTH_LONG).show();
                    printer.setChecked(true);
                    break;

                case Constants.PRINTER_DISCONNECTED:
                    Toast.makeText(getApplicationContext(), "Printer Disconnected", Toast.LENGTH_LONG).show();
                    printer.setChecked(false);
                    break;

                case Constants.PRINTER_MESSAGE_READ:
                    byte[] preadBuf = (byte[]) msg.obj;
                    // construct a string from the valid bytes in the buffer
                    String preadMessage = new String(preadBuf, 0, msg.arg1);
                    Log.i("Printer Data Recieved", preadMessage);
                    String[] pread = preadMessage.split("\n");
                    break;
                case Constants.MESSAGE_DEVICE_NAME:
                    // save the connected device's name
                    mConnectedDeviceName = msg.getData().getString(Constants.DEVICE_NAME);
                    if (null != getApplicationContext()) {
                        Toast.makeText(getApplicationContext(), "Connected to "
                                + mConnectedDeviceName, Toast.LENGTH_SHORT).show();
                    }
                    break;
                case Constants.MESSAGE_TOAST:
                    if (null != getApplicationContext()) {
                        Toast.makeText(getApplicationContext(), msg.getData().getString(Constants.TOAST),
                                Toast.LENGTH_LONG).show();
                    }
                    break;
            }
        }
    };
    private final BroadcastReceiver mReceiver = new BroadcastReceiver() {
        @Override
        public void onReceive(Context context, Intent intent) {
            String action = intent.getAction();
            if (BluetoothDevice.ACTION_ACL_DISCONNECTED.equals(action)) {
                try {
                    BluetoothDevice device = intent
                            .getParcelableExtra(BluetoothDevice.EXTRA_DEVICE);
                    if (summaries.printer.printerdevice.equals(device)) {
                        p.printersock .close();
                        p.printerout.close();
                        mHandler.obtainMessage(Constants.PRINTER_DISCONNECTED).sendToTarget();

                    }
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
            }
        }
    };
}
