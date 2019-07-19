package com.example.paul.datacollector;

import android.app.ActionBar;
import android.app.Activity;
import android.app.AlertDialog;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.content.res.Configuration;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.preference.PreferenceManager;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.util.Pair;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.telephony.TelephonyManager;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;

import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.WindowManager;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.JsonObject;
import com.google.gson.reflect.TypeToken;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.lang.reflect.Method;
import java.lang.reflect.Type;
import java.nio.channels.FileChannel;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.HashMap;
import java.util.List;

import static com.example.paul.datacollector.BTDeviceList.REQUEST_CONNECT_BT;

import static java.lang.System.in;

public class MainActivity extends AppCompatActivity {
    private static final int REQUEST_CONNECT_DEVICE_SECURE = 1;
    private static final int REQUEST_CONNECT_DEVICE_INSECURE = 2;
    private static final int REQUEST_ENABLE_BT = 3;
    public static Farmer farmers = null;
    static private BluetoothAdapter mBluetoothAdapter = null;
    static private BluetoothDevice mmDevice = null;
    private static BluetoothSocket btsocket;
    private static OutputStream btoutputstream;
    private static InputStream btinputstream;
    public static boolean sending = false;
    EditText farmerno = null;
    TextView farmername = null;
    EditText kg = null;
    static String month;
    TextView kgcollected = null;
    TextView kg2 = null;
    Collection c = null;
    ProgressBar farmernameprogress;
    byte FONT_TYPE;
    Thread workerThread;
    private DB db = null;
    SharedPreferences preferences;
    Calendar cdt;
    double kgcol;
    Button fab;
    Button Zero;
    Button Tare;

    private String mConnectedDeviceName = null;


    private CheckBox scalec;


    private CheckBox printc;

    private Summaries.scale s = new Summaries.scale();
    private Summaries.printer p = new Summaries.printer();

    Button more, clear;

    private Sendthread sendThread;
    /**
     * Array adapter for the conversation thread
     */
    private ArrayAdapter<String> mConversationArrayAdapter;

    /**
     * String buffer for outgoing messages
     */
    private StringBuffer mOutStringBuffer;

    /**
     * Member object for the chat services
     */
    // private BluetoothChatService mChatService = null;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        db = new DB(this);
        preferences = getSharedPreferences("Settings", MODE_PRIVATE);
        JsonParser.preferences = preferences;
        toolbar.setTitle(getpreferences("TransporterName"));
        //mConversationView = (ListView) findViewById(R.id.in);
        cdt =  Calendar.getInstance();
     SimpleDateFormat   dff = new SimpleDateFormat("MM-yyyy");
        month = dff.format(cdt.getTime());
        farmerno = (EditText) findViewById(R.id.farmerno);
        farmerno.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }
            @Override
            public void afterTextChanged(Editable s) {
            Farmer f =     db.getFarmer(farmerno.getText().toString());
                if (f!=null)
                    farmername.setText(f.Name + ": Cumm = "+ String.format("%.2f",db.customercumm(f.No,month)));
                else
                    farmername.setText("");
//new Getfarmer(farmerno.getText().toString()).execute();
            }
        });
        //farmerno.setRawInputType(Configuration.KEYBOARD_12KEY);
        farmername = (TextView) findViewById(R.id.farmername);
        kg = (EditText) findViewById(R.id.Kg);
        kg.setRawInputType(Configuration.KEYBOARD_12KEY);
        kg2 = (TextView) findViewById(R.id.kg2);
        more = (Button) findViewById(R.id.more);
        clear = (Button) findViewById(R.id.clear);
        more.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                kg2.setText(String.valueOf(Double.parseDouble(kg2.getText().toString()) + Double.parseDouble((kg.getText().toString().equals("") ? "0" : kg.getText().toString()))));
                kg.setText("");
                if (s != null)
                    s.writetoscale("Tare".getBytes());
            }
        });
        clear.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                kg2.setText("0");
            }
        });
        new Getfarmers(db.getFarmer(getpreferences("Transporter"))).execute();
        kgcollected = (TextView) findViewById(R.id.Kgcollected);
        new Kgcollected().execute();
        farmernameprogress = (ProgressBar) findViewById(R.id.getfarmername);
        fab = (Button) findViewById(R.id.fab);
        Tare = (Button) findViewById(R.id.Tare);
        Tare.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                s.writetoscale("Tare".getBytes());
            }
        });
        Zero = (Button) findViewById(R.id.zero);
        Zero.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                s.writetoscale("Zero".getBytes());
            }
        });


        scalec = (CheckBox) findViewById(R.id.scaleconnected);
        printc = (CheckBox) findViewById(R.id.printerconnected);

        Summaries.mHandler = mHandler;


        Summaries.Printerthread sp = new Summaries.Printerthread(preferences);
        sp.start();


        Summaries.Scalethread st = new Summaries.Scalethread(preferences);
        st.start();
        //get collections
        Summaries.getdata g = getDateRange();
        g.route = login.currentuser.Transporter;
        new Getcollections(g).execute();
        sendThread = new Sendthread();
        sendThread.start();
       IntentFilter filter = new IntentFilter(BluetoothDevice.ACTION_ACL_DISCONNECTED);
        registerReceiver(mReceiver, filter);

        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                kg.setError(null);
                try {
                    SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
                    final String formattedDate = df.format(cdt.getTime());
                    df = new SimpleDateFormat("HH:mm:ss");
                    final String formattedtime = df.format(cdt.getTime());
                    df = new SimpleDateFormat("MM-yyyy");
                   month = df.format(cdt.getTime());
                    if (farmerno.getText().equals("")) {
                        farmerno.setError("Please enter farmer no");
                        return;
                    }
                    if (farmers == null)
                        getfarmer();
                    if (farmers == null) {
                        farmerno.setError("Please enter farmer no");
                        return;
                    }
                    kgcol =(Double.parseDouble(kg.getText().toString()) + Double.parseDouble(kg2.getText().toString())) ;
                    if (kgcol <= 0  ) {
                        kg.setError("Kgs cannot be equal or less to 0.");
                        return;
                    }
                    if (db.getcustcollbydates(farmerno.getText().toString(), formattedDate) != null) {
                        new AlertDialog.Builder(MainActivity.this)
                                .setTitle("Milk Delivered")
                                .setMessage(farmers.Name + ", Has delivered milk today, buy more milk for him?")
                                .setIcon(android.R.drawable.ic_dialog_alert)
                                .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog, int which) {

                                        if (farmers != null) {
                                            if (!kg.getText().toString().equals("")) {
                                                cdt = Calendar.getInstance();
                                                fab.setVisibility(View.GONE);
                                                c = new Collection();
                                                c.Collected_by = getpreferences("User");
                                                try {
                                                    TelephonyManager mngr = (TelephonyManager) getSystemService(Context.TELEPHONY_SERVICE);
                                                    c.Device_Id = mngr.getDeviceId();
                                                } catch (Exception ex) {
                                                    ex.printStackTrace();
                                                }
                                                c.Date = formattedDate;
                                                c.Time = formattedtime;
                                                c.Farmers_Number = farmers.No;
                                                c.Farmers_Name = farmers.Name;
                                                c.Kg_Collected = kgcol;
                                                c.Transporter = login.currentuser.Transporter;
                                                SimpleDateFormat dff = new SimpleDateFormat("yyMMdd");
                                                final String formatteddate = dff.format(cdt.getTime());
                                                dff = new SimpleDateFormat("HHmmss");
                                                final String formattedt = dff.format(cdt.getTime());
                                                c.Collection_Number = String.format("%s%s%s", c.Farmers_Number, formatteddate, formattedt);
                                                c.sent = false;
                                                c.status = "Pending";
                                                c.Factory = getpreferences("Route");
                                               c.Cumm = db.customercumm(c.Farmers_Number,month)+ c.Kg_Collected;
                                                db.insertCollection(c);
                                                Savefile(c);
                                                farmerno.setText("");
                                                farmername.setText("");
                                                kg.setText("");
                                                kg2.setText("0");
                                                fab.setVisibility(View.VISIBLE);
                                               // Transporter.Cummulative_Collected += c.Kg_Collected;
                                                farmers.Cummulative = db.customercumm(c.Farmers_Number,month)+ c.Kg_Collected;
                                                db.updateFarmer(farmers);
                                                //db.updateFarmer(Transporter);
                                                new Kgcollected().execute();
                                                if (s != null)
                                                    s.writetoscale("Tare".getBytes());
                                                ResultsBox(c);
                                            } else {
                                                kg.setError("No Kgs");
                                            }
                                        }
                                    }
                                })
                                .setNegativeButton(android.R.string.no, new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialog, int whichButton) {
                                        farmerno.setError("Farmer cannot sell twice a day.");
                                        farmerno.requestFocus();
                                        Toast.makeText(getApplicationContext(), "Delivery cancelled.", Toast.LENGTH_LONG).show();
                                        return;
                                    }
                                }).show();
                    }
                    else
                    {
                        if (farmers != null) {
                            if (!kg.getText().toString().equals("")) {
                                cdt = Calendar.getInstance();
                                fab.setVisibility(View.GONE);
                                c = new Collection();
                                c.Collected_by = getpreferences("User");
                                try {
                                    TelephonyManager mngr = (TelephonyManager) getSystemService(Context.TELEPHONY_SERVICE);
                                    c.Device_Id = mngr.getDeviceId();
                                } catch (Exception ex) {
                                    ex.printStackTrace();
                                }
                                c.Date = formattedDate;
                                c.Time = formattedtime;
                                c.Farmers_Number = farmers.No;
                                c.Farmers_Name = farmers.Name;
                                c.Kg_Collected = kgcol;
                                c.Transporter = login.currentuser.Transporter;
                                SimpleDateFormat dff = new SimpleDateFormat("yyMMdd");
                                final String formatteddate = dff.format(cdt.getTime());
                                dff = new SimpleDateFormat("HHmmss");
                                final String formattedt = dff.format(cdt.getTime());
                                c.Collection_Number = String.format("%s%s%s", c.Farmers_Number, formatteddate, formattedt);
                                c.sent = false;
                                c.status = "Pending";
                                c.Factory = getpreferences("Route");
                                c.Cumm = db.customercumm(c.Farmers_Number,month)+ c.Kg_Collected;
                                db.insertCollection(c);
                                Savefile(c);
                                farmerno.setText("");
                                farmername.setText("");
                                kg.setText("");
                                kg2.setText("0");
                                fab.setVisibility(View.VISIBLE);
                                //Transporter.Cummulative_Collected += c.Kg_Collected;
                                farmers.Cummulative = db.customercumm(c.Farmers_Number,month)+ c.Kg_Collected;
                                db.updateFarmer(farmers);
                                //db.updateFarmer(Transporter);
                                new Kgcollected().execute();
                                if (s != null)
                                    s.writetoscale("Tare".getBytes());
                                ResultsBox(c);
                            } else {
                                kg.setError("No Kgs");
                            }
                        }
                    }

                } catch (Exception ex) {
                    fab.setVisibility(View.VISIBLE);
                    ex.printStackTrace();
                    Toast.makeText(getApplicationContext(), ex.getMessage(), Toast.LENGTH_LONG).show();
                }
                // Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                //       .setAction("Action", null).show();
            }
        });
        farmerno.setOnFocusChangeListener(new View.OnFocusChangeListener() {

            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    getfarmer();
                }
            }
        });
    }

    private String getpreferences(String key) {
        String pref = "";
        String value = preferences.getString(key, "");

        if (value != null || value != "") {
            pref = value;
        }
        return pref;
    }

    private class Sendthread extends Thread {
        public Sendthread() {
            Log.i("Sending..", "Sending Started");
        }

        public void run() {

            try {
                while (true) {

                    if (!sending) {
                        //  Log.i("Sending..","Sending");
                        new sendpendingcollection(db.getpendingCollection()).execute();
                        this.sleep(5000);
                    }
                }
            } catch (Exception ex) {
                ex.printStackTrace();

            }
            // Reset the ConnectThread because we're done
            // Start the connected thread
        }
    }

    private void getfarmer() {
        farmerno.setError(null);
        if (!farmerno.getText().toString().equals("")) {
            farmers = new Farmer();
            farmers.No = farmerno.getText().toString();
           farmernameprogress.setVisibility(View.VISIBLE);
            farmers = db.getFarmer(farmers.No);
            if (farmers != null) {
                farmername.setText(farmers.Name  + ": Cumm - "+ String.format("%.2f",db.customercumm(farmers.No,month)));
                farmernameprogress.setVisibility(View.GONE);
            } else {
                farmername.setText("No farmer record found");
                farmernameprogress.setVisibility(View.GONE);
            }
            //new Getvendors(farmers).execute();
        } else
          farmerno.setError("Farmer Number required");
    }

    @Override
    public void onBackPressed() {
        new AlertDialog.Builder(this)
                // .setIcon(android.R.drawable.ic_dialog_alert)
                .setTitle("Exit")
                .setMessage("Are you sure you want to exit?")
                .setPositiveButton("Yes",
                        new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog,
                                                int which) {
                                try {
                                    if (btsocket != null) {
                                        btoutputstream.close();
                                        btsocket.close();
                                        btsocket = null;
                                    }
                                } catch (Exception ex) {
                                    ex.printStackTrace();
                                }
                                System.exit(0);
                            }

                        }).setNegativeButton("No", null).show();
    }

    @Override
    public void onStart() {
        super.onStart();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);

        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.

        switch (item.getItemId()) {

            case R.id.summaryreport: {

                Intent summary = new Intent(getApplicationContext(), com.example.paul.datacollector.summary.class);
                startActivity(summary);

                return true;
            }
            case R.id.farmercollection: {

                Intent summary = new Intent(getApplicationContext(), com.example.paul.datacollector.farmercollection.class);
                startActivity(summary);

                return true;
            }
            case R.id.settings: {
                Intent intent = new Intent(getApplicationContext(), Settings.class);
                startActivity(intent);
                return true;
            }
            case R.id.changepass: {
                Intent intent = new Intent(getApplicationContext(), changepassword.class);
                startActivity(intent);
                return true;
            }
            case R.id.Dispatch: {

                try {
                    SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
                    final String formattedDate = df.format(cdt.getTime());
                    String head;
                    head = "   " + getpreferences("TransporterName").toUpperCase() + "\n";
                    head += "     MILK DISPATCH RECIEPT\n";
                    String data = "";
                    data = "--------------------------------\n";
                    data += "Date Dispatched:   " + formattedDate + "\n";
                    data += "Farmers count:     " + db.getcountcollbydates(formattedDate) + "\n";
                    data += "Total KGs:         " +String.format("%.2f", db.gettotalcollbydates(formattedDate)) + "\n";
                    data += "--------------------------------\n";
                    data += "Dispatched by:     " + getpreferences("User") + "\n";

                    data +="--------------------------------\n\n\n";
                    try {
                        Thread.sleep(1000);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    if (p.printersock != null) {
                        byte[] arrayOfByte1 = {27, 33, 0};
                        byte[] format = {27, 33, 0};

                        p.writetoprinter(format);
                        String msg = head;
                        p.writetoprinter(msg.getBytes());
                        byte[] printformat = {27, 33, 0};
                        p.writetoprinter(printformat);
                        msg = data;
                        p.writetoprinter(msg.getBytes());
                        p.writetoprinter(0x0D);
                        p.writetoprinter(0x0D);
                        p.writetoprinter(0x0D);
                        p.flushprinter();
                        farmerno.requestFocus();
                        farmers = null;
                    } else
                        Toast.makeText(getApplicationContext(), "Unable to print, printer not available", Toast.LENGTH_LONG).show();

                } catch (Exception e) {
                    e.printStackTrace();
                }

                return true;
            }
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onResume() {
        super.onResume();

        // Performing this check in onResume() covers the case in which BT was
        // not enabled during onStart(), so we were paused to enable it...
        // onResume() will be called when ACTION_REQUEST_ENABLE activity returns.
//        if (mChatService != null) {
//            // Only if the state is STATE_NONE, do we know that we haven't started already
//            if (mChatService.getState() == BluetoothChatService.STATE_NONE) {
//                // Start the Bluetooth chat services
//                mChatService.start();
//            }
//        }
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        try {
            if (p.printersock != null) {
                p.printerout.close();
                p.printerin.close();
                p.printersock.close();
                p.printersock = null;
            }
            if (s.scalesock != null) {
                s.scalein.close();
                s.scalein.close();
                s.scalesock.close();
                s.scalesock = null;
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void Savefile( Collection c) {
        try {
            File root;
            if (android.os.Environment.getExternalStorageState().equals(
                    android.os.Environment.MEDIA_MOUNTED)) {
                root = new File(Environment.getExternalStorageDirectory(), "Milk/");
            } else
                root = new File("/data/Milk/" + c.Date + ".jpg");

            String data = c.Date + "," + c.Collection_Number + "," + c.Farmers_Number + "," + c.Kg_Collected + "," + c.Collected_by + "," + c.Factory + "," + c.Time + "\n";

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

    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        switch (requestCode) {
            case REQUEST_CONNECT_BT:
                try {
                    btsocket = BTDeviceList.getSocket();
                    if (btsocket != null) {

                    }

                } catch (Exception e) {
                    e.printStackTrace();
                }

            case REQUEST_CONNECT_DEVICE_SECURE:
                // When DeviceListActivity returns with a device to connect
                if (resultCode == Activity.RESULT_OK) {
                    // connectDevice(data, true);
                }
                break;
            case REQUEST_CONNECT_DEVICE_INSECURE:
                // When DeviceListActivity returns with a device to connect
                if (resultCode == Activity.RESULT_OK) {
                    //connectDevice(data, false);
                }
                break;
            case REQUEST_ENABLE_BT:
                // When the request to enable Bluetooth returns
                if (resultCode == Activity.RESULT_OK) {
                    // Bluetooth is now enabled, so set up a chat session
                    //  setupChat();
                } else {
                    // User did not enable Bluetooth or an error occurred
                    Log.d("Bt", "BT not enabled");
                    Toast.makeText(getApplicationContext(), R.string.bt_not_enabled_leaving,
                            Toast.LENGTH_SHORT).show();
                    finish();
                }
        }
    }

    private class Getfarmers extends AsyncTask<List<Farmer>, String, List<Farmer>> {
        Farmer f = null;

        Getfarmers(Farmer ff) {
            f = ff;
        }

        @Override
        protected void onPreExecute() {
        }

        protected void onProgressUpdate(String... progress) {
            Toast.makeText(getApplicationContext(), progress[0], Toast.LENGTH_SHORT).show();
        }

        @Override
        protected List<Farmer> doInBackground(List<Farmer>... params) {
            List<Farmer> results = null;
            String result = null;
            try {
                Gson g = new Gson();
                result = g.toJson(this.f);
                result = JsonParser.postjson("TFarmers", "data", result);
                Type localType = new TypeToken<List<Farmer>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
                if (results != null) {
                    try {
                        db.deleteFarmers();
                        publishProgress("Updating farmers ");
                        for (Farmer f : results
                                ) {
                            Log.i("Updating farmer", f.No);
                            db.insertfarmer(f);
                        }
                        publishProgress(results.size() + " Farmers updated");
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<Farmer> res) {
            try {

                //farmername.setTextColor(Color.RED);
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
    private class Getfarmer extends AsyncTask<String, String, Farmer> {
        String f = null;

        Getfarmer(String ff) {
            f = ff;
        }

        @Override
        protected void onPreExecute() {
        }

        protected void onProgressUpdate(String... progress) {
            Toast.makeText(getApplicationContext(), progress[0], Toast.LENGTH_SHORT).show();
        }

        @Override
        protected Farmer doInBackground(String... params) {
            Farmer results = null;

            try {
                results = db.getFarmer(f);
            } catch (Exception e) {
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(Farmer res) {
            try {
              if (res!= null)
                  farmername.setText(res.Name);
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
    private class Kgcollected extends AsyncTask<Void, Void, Double> {
        Kgcollected() {
        }

        @Override
        protected void onPreExecute() {
        }

        @Override
        protected Double doInBackground(Void... params) {
            cdt = Calendar.getInstance();
            SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
            final String formattedDate = df.format(cdt.getTime());
            Double total = 0.0;
            try {
                List<Collection> bydate = db.getbydates(formattedDate);
                for (Collection cc : bydate
                        ) {
                    if (!cc.status.equals("Reversed"))
                        total += cc.Kg_Collected;
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
            return total;
        }

        @Override
        protected void onPostExecute(Double res) {
            try {
                kgcollected.setText(String.format("%.2f", res));
                //farmername.setTextColor(Color.RED);
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
    public Summaries.getdata getDateRange() {
        Summaries.getdata dates= new Summaries.getdata();

        SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");

        {
            Calendar calendar = getCalendarForNow();
            calendar.set(Calendar.DAY_OF_MONTH,
                    calendar.getActualMinimum(Calendar.DAY_OF_MONTH));
            setTimeToBeginningOfDay(calendar);
            dates.firstdate = df.format( calendar.getTime());



        }

        {
            Calendar calendar = getCalendarForNow();
            calendar.set(Calendar.DAY_OF_MONTH,
                    calendar.getActualMaximum(Calendar.DAY_OF_MONTH));
            setTimeToEndofDay(calendar);
            dates.LastDate =  df.format( calendar.getTime());
        }
        Log.i("1st date",dates.firstdate);
        Log.i("Last date", dates.LastDate);

        return dates ;
    }

    private static Calendar getCalendarForNow() {
        Calendar calendar = GregorianCalendar.getInstance();
        calendar.setTime(new Date());
        return calendar;
    }

    private static void setTimeToBeginningOfDay(Calendar calendar) {
        calendar.set(Calendar.HOUR_OF_DAY, 0);
        calendar.set(Calendar.MINUTE, 0);
        calendar.set(Calendar.SECOND, 0);
        calendar.set(Calendar.MILLISECOND, 0);
    }

    private static void setTimeToEndofDay(Calendar calendar) {
        calendar.set(Calendar.HOUR_OF_DAY, 23);
        calendar.set(Calendar.MINUTE, 59);
        calendar.set(Calendar.SECOND, 59);
        calendar.set(Calendar.MILLISECOND, 999);
    }

    private class Getcollections extends AsyncTask<Summaries.getdata, Void, List<Collection>> {
        Summaries.getdata c = null;

        Getcollections(Summaries.getdata ff) {
            c = ff;
        }

        @Override
        protected void onPreExecute() {
        }

        @Override
        protected List<Collection> doInBackground(Summaries.getdata... params) {
            List<Collection> results = null;
            String result = null;
            try {

                Gson g = new Gson();
                result = g.toJson(this.c);
                result = JsonParser.postjson("GetCollections", "data", result);
                Type localType = new TypeToken<List<Collection>>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
                if (results != null) {
                    try {
                        for (Collection f : results
                                ) {
                            f.sent = true;
                            f.status = "Sent";
                            db.insertCollection(f);
                        }
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<Collection> res) {
            try {
                Log.i("update collections", "Updated");

            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
    public void ResultsBox(final Collection t) {
        try {
            LayoutInflater li = LayoutInflater.from(MainActivity.this);
            View promptsView = li.inflate(R.layout.activity_results, null);
            AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
                    MainActivity.this);
            alertDialogBuilder.setView(promptsView);
            final TextView membno = (TextView) promptsView
                    .findViewById(R.id.txtmemberno);
            final TextView membername = (TextView) promptsView
                    .findViewById(R.id.txtmembername);
            final TextView datecoo = (TextView) promptsView
                    .findViewById(R.id.txtcolldate);
            final TextView timecoll = (TextView) promptsView
                    .findViewById(R.id.txtcolltime);
            final TextView kgcoll = (TextView) promptsView
                    .findViewById(R.id.txtkg);
            final TextView collno = (TextView) promptsView
                    .findViewById(R.id.txtref);
            final TextView cummkg = (TextView) promptsView.findViewById(R.id.txtcummkg);
            collno.setText(t.Collection_Number);
            membno.setText(t.Farmers_Number);
            membername.setText(t.Farmers_Name);
            datecoo.setText(t.Date);
            timecoll.setText(t.Time);
            kgcoll.setText(t.Kg_Collected.toString());
            cummkg.setText(String.format("%.2f", t.Cumm));
            alertDialogBuilder
                    .setCancelable(false)
                    .setPositiveButton("Print", new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int id) {
                            try {
                                String head;
                                head = "   " + getpreferences("TransporterName").toUpperCase() + "\n\n";
                                head +="     MILK DELIVERY RECIEPT\n";
                                String data = "";
                                data = "--------------------------------\n";
                                data += "Coll. No:   " + t.Collection_Number + "\n";
                                data += "Member No:  " + t.Farmers_Number + "\n";
                                data += "Member Name:" + t.Farmers_Name + "\n";
                                data += "Coll. Date: " + t.Date + "\n";
                                data += "Coll. Time: " + t.Time + "\n";
                                data += "Kg Coll:    " + t.Kg_Collected.toString() + "\n";
                                data += "--------------------------------\n";
                                data += "Cum Kg:     " + String.format("%.2f", t.Cumm) + "\n\n";
                                data += "Served by:  " + t.Collected_by + "\n\n\n";
                                try {
                                    Thread.sleep(1000);
                                } catch (InterruptedException e) {
                                    e.printStackTrace();
                                }
                                if (p.printersock != null) {
                                    byte[] arrayOfByte1 = {27, 33, 0};
                                    byte[] format = {27, 33, 0};
                                    p.writetoprinter(format);
                                    String msg = head;
                                    p.writetoprinter(msg.getBytes());
                                    byte[] printformat = {27, 33, 0};
                                    p.writetoprinter(printformat);
                                    msg = data;
                                    p.writetoprinter(msg.getBytes());
                                    p.writetoprinter(0x0D);
                                    p.writetoprinter(0x0D);
                                    p.writetoprinter(0x0D);
                                    p.flushprinter();
                                    farmerno.requestFocus();
                                    farmers = null;
                                } else
                                    Toast.makeText(getApplicationContext(), "Unable to print, printer not available", Toast.LENGTH_LONG).show();
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                            farmers = null;
                            sending = false;
                        }
                    })
                    .setNegativeButton("Reverse", new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int id) {
                            c.status = "Reversed";
                            c.sent = true;
                            farmers.Cummulative -=c.Kg_Collected;
                            db.updateFarmer(farmers);
                            db.updateCollection(c);
                            //Transporter.Cummulative_Collected -= c.Kg_Collected;
                            //db.updateFarmer(Transporter);
                            Toast.makeText(getApplicationContext(), String.format("Collection %s reversed", c.Collection_Number), Toast.LENGTH_LONG).show();
                            new Kgcollected().execute();
                            farmerno.requestFocus();
                        }
                    });

            AlertDialog alertDialog = alertDialogBuilder.create();
            alertDialog.getWindow().setSoftInputMode(
                    WindowManager.LayoutParams.SOFT_INPUT_ADJUST_RESIZE);// show it
            alertDialog.show();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    private class sendpendingcollection extends AsyncTask<List<Collection>, Void, List<Collection>> {
        List<Collection> c = null;

        sendpendingcollection(List<Collection> ff) {
            c = ff;
        }

        @Override
        protected void onPreExecute() {
            sending = true;
        }

        @Override
        protected List<Collection> doInBackground(List<Collection>... params) {
            //
            List<Collection> results = null;
            String result = null;
            try {
                Log.i("Not sent...", String.valueOf(c.size()));
                for (Collection cc : c
                        ) {
                    Log.i("Sending...", cc.Collection_Number);
                    Collection res = null;
                    Gson g = new Gson();
                    result = g.toJson(cc);
                    result = JsonParser.postjson("Collections", "data", result);
                    Type localType = new TypeToken<Collection>() {
                    }.getType();
                    res = new Gson().fromJson(result, localType);
                    if (res != null) {
                        res.sent = true;
                        res.status = "Sent";
                        db.updateCollection(res);
                    }
                }
            } catch (Exception e) {
                e.printStackTrace();
                results = c;
                sending = false;
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<Collection> res) {
            try {
                sending = false;
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
    private final Handler mHandler = new Handler() {
        @Override
        public void handleMessage(Message msg) {
            switch (msg.what) {

                case Constants.MESSAGE_WRITE:
                    byte[] writeBuf = (byte[]) msg.obj;
                    // construct a string from the buffer
                    String writeMessage = new String(writeBuf);
                    mConversationArrayAdapter.add("Me:  " + writeMessage);
                    break;
                case Constants.SCALE_CONNECTED:
                    scalec.setChecked(true);
                    break;
                case Constants.PRINTER_CONNECTED:
                    printc.setChecked(true);
                    break;
                case Constants.SCALE_DISCONNECTED:
                    Toast.makeText(getApplicationContext(), "Connection to scale lost", Toast.LENGTH_LONG).show();
                    scalec.setChecked(false);
                    break;
                case Constants.PRINTER_DISCONNECTED:
                    Toast.makeText(getApplicationContext(), "Connection to printer lost", Toast.LENGTH_LONG).show();
                    printc.setChecked(false);
                    break;
                case Constants.MESSAGE_READ:
                    byte[] readBuf = (byte[]) msg.obj;
                    // construct a string from the valid bytes in the buffer
                    String readMessage = new String(readBuf);
                    Log.i("Data Recieved", readMessage);
                    String[] read = readMessage.split("\n");
                    try {
                        if (read[0].contains("ST")){
                            kg.setFocusable(false);
                        kg.setClickable(true);
                            kg.setText(read[0].replace("ST,GS,", "").replace("KG", "").replace("kg", "").replace(" ", "").replace("ST,NT,", "").trim());
                        Log.i("Weight", read[0]);}

                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
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
//                        Toast.makeText(getApplicationContext(), msg.getData().getString(Constants.TOAST),
//                                Toast.LENGTH_LONG).show();
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
                    if (Summaries.scale.scaledevice.equals(device)) {
                        s.scalesock.close();
                        s.scaleout.close();
                        s.scalein.close();
                        mHandler.obtainMessage(Constants.SCALE_DISCONNECTED).sendToTarget();
                    } else if (Summaries.printer.printerdevice.equals(device)) {
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
