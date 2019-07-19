package com.example.paul.m_branch;

import android.bluetooth.BluetoothDevice;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.media.AudioAttributes;
import android.media.MediaPlayer;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Handler;
import android.os.Message;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.ExpandableListView;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class menu extends AppCompatActivity {
    Button register, cash;
    ExpandableListView report;
    DB db;
    CheckBox printer;
    ExpandableListAdapter listAdapter;
    List<String> listDataHeader;
    HashMap<String, List<String>> listDataChild;
    SharedPreferences preferences;
    private summaries.printer p = new summaries.printer();
    private updatemembers membersupdate;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);
        register = (Button) findViewById(R.id.Register);
        cash = (Button) findViewById(R.id.CashReceipt);
        report = (ExpandableListView) findViewById(R.id.report);
        db = new DB(this);
        printer = (CheckBox) findViewById(R.id.printer);
        preferences = getSharedPreferences("Settings", MODE_PRIVATE);
        summaries.mHandler = mHandler;
        summaries.Printerthread sp = new summaries.Printerthread(preferences);
        sp.start();
        membersupdate = new updatemembers();
        membersupdate.start();
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB) {
            new Gettypes().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
            new Getmpesa().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
            new Getgroups().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
            new Getmembers().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);


        } else {
            new Gettypes().execute();
            new Getmpesa().execute();
            new Getgroups().execute();
            new Getmembers().execute();

        }
        cash.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(menu.this, cashreceipt.class));
            }
        });
        register.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(menu.this, com.example.paul.m_branch.register.class));
            }
        });
        prepareListData();
        listAdapter = new ExpandableListAdapter(this, listDataHeader, listDataChild);
        // setting list adapter
        report.setAdapter(listAdapter);
        report.setOnChildClickListener(new ExpandableListView.OnChildClickListener() {
            @Override
            public boolean onChildClick(ExpandableListView parent, View v,
                                        int groupPosition, int childPosition, long id) {
                // TODO Auto-generated method stub
                Intent i = new Intent(menu.this, reports.class);
                i.putExtra("report", listDataChild.get(
                        listDataHeader.get(groupPosition)).get(
                        childPosition).toString());
                startActivity(i);
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
        IntentFilter filter = new IntentFilter(BluetoothDevice.ACTION_ACL_DISCONNECTED);
        registerReceiver(mReceiver, filter);
    }
    private class Getgroups extends AsyncTask<Void, String, List<group>> {
        @Override
        protected void onPreExecute() {

        }


        protected void onProgressUpdate(String... progress) {
            Toast.makeText(getApplicationContext(), progress[0], Toast.LENGTH_LONG).show();
        }

        @Override
        protected List<group> doInBackground(Void... params) {
            publishProgress("Getting groups");
            List<group> results = null;
            String result = null;
            try {
                Gson g = new Gson();

                result = JsonParser.postjson("groups", null, null);
                Type localType = new TypeToken<List<group>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
                if (results != null) {
                    try {
                        publishProgress("Updating groups");
                        for (group f : results
                                ) {
                            db.insergroup(f);
                        }
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
                }
            } catch (Exception e) {
                publishProgress("Unable to get groups");
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<group> res) {
            try {
                if (res != null)
                    Toast.makeText(getApplicationContext(), "Groups updated", Toast.LENGTH_LONG).show();


            } catch (Exception ex) {
                ex.printStackTrace();
            }
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
            publishProgress("Getting transaction types");
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
                        publishProgress("Updating transaction types");
                        for (types f : results
                                ) {
                            db.inserttype(f);
                        }
                    } catch (Exception ex) {
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
                if (res != null)
                    Toast.makeText(getApplicationContext(), "Groups updated", Toast.LENGTH_LONG).show();


            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
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
            publishProgress("Getting transaction Mpesa");
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

                        publishProgress("Updating transaction Mpesa");
                        for (mpesa f : results
                        ) {
                            db.insermpesa(f);
                        }
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
                }
            } catch (Exception e) {
                publishProgress("Unable to get transaction mpesa");
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<mpesa> res) {
            try {
                if (res != null)
                    Toast.makeText(getApplicationContext(), "MPesa transactions updated", Toast.LENGTH_LONG).show();


            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }

    private class m{
    public String key= null;
    public String division=login.CurrentAgent.Constituency;
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
                publishProgress("Getting members for: " + login.CurrentAgent.Constituency);
                try {
                    m n = new m();
                    while (true) {
                        Gson g = new Gson();
                        String l = g.toJson(n);
                        result = JsonParser.postjson("memberss", "division", l);
                        Type localType = new TypeToken<List<member>>() {
                        }.getType();
                        results = new Gson().fromJson(result, localType);
                        Log.i("size", String.valueOf(results.size()));
                        if (results != null) {
                            publishProgress("Updating members for: " + login.CurrentAgent.Constituency);
                            for (member f : results) {
                                db.insertmember(f);
                                n.key = f.Key;
                            }
                        }
                        if (results.size() == 0) {
                            Log.i("Members", "No members");
                            break;
                        }
                    }
                } catch (Exception ex) {
                    publishProgress("Unable to get members for: " + login.CurrentAgent.Constituency);
                    ex.printStackTrace();
                }
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
    private void prepareListData() {
        listDataHeader = new ArrayList<String>();
        listDataChild = new HashMap<String, List<String>>();
        // Adding child data
        listDataHeader.add("REPORTS");
        // Adding child data
        List<String> reports = new ArrayList<String>();
        reports.add("Daily Receipts");
        reports.add("Transaction receipts");
        reports.add("Member receipts");


        listDataChild.put(listDataHeader.get(0), reports); // Header, Child data

    }

    private class updatemembers extends Thread {
        public updatemembers() {
            Log.i("Sending..", "Sending Started");
        }

        public void run() {

            try {
                while (true) {

                    new updatemember(db.getupdatedmember()).execute();

                    new collections(db.getunsenttrans()).execute();

                    this.sleep(20000);
                }
            } catch (Exception ex) {
                ex.printStackTrace();

            }
            // Reset the ConnectThread because we're done
            // Start the connected thread
        }
    }

    private String mConnectedDeviceName = null;

    private class updatemember extends AsyncTask<List<member>, Void, List<member>> {
        List<member> c = null;

        updatemember(List<member> ff) {
            c = ff;
        }

        @Override
        protected void onPreExecute() {

        }

        @Override
        protected List<member> doInBackground(List<member>... params) {
            //
            List<member> results = null;
            String result = null;
            try {
                Log.i("Not sent...", String.valueOf(c.size()));
                for (member cc : c
                        ) {
                    member res = null;
                    Gson g = new Gson();
                    result = g.toJson(cc);
                    result = JsonParser.postjson("updatemembers", "data", result);
                    Type localType = new TypeToken<member>() {
                    }.getType();
                    res = new Gson().fromJson(result, localType);
                    if (res != null) {
                        res.updated = false;
                        db.updatemember(res);
                    }
                }
            } catch (Exception e) {
                e.printStackTrace();
                results = c;
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<member> res) {
            try {

            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }

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
            //
            List<transaction> results = null;
            String result = null;
            try {
                Log.i("Not sent...", String.valueOf(c.size()));
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
                        p.printersock.close();
                        p.printerout.close();
                        p.printerin.close();
                        mHandler.obtainMessage(Constants.PRINTER_DISCONNECTED).sendToTarget();
                    }
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
            }
        }
    };
}
