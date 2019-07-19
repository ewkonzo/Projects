package com.example.paul.datacollector;

import android.app.ActionBar;
import android.app.Activity;
import android.app.AlertDialog;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.WindowManager;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.lang.reflect.Type;
import java.security.spec.ECField;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.List;

import static com.example.paul.datacollector.BTDeviceList.REQUEST_CONNECT_BT;

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

    public boolean sending = false;
    EditText farmerno = null;
    TextView farmername = null;
    EditText kg = null;
    TextView kgcollected = null;
    TextView kg2 = null;
    Collection c = null;
    ProgressBar farmernameprogress;
    byte FONT_TYPE;
    Thread workerThread;
    DB db;
    byte[] readBuffer;
    int readBufferPosition;
    int counter;
    Calendar cdt;
    volatile boolean stopWorker;
    FloatingActionButton fab;
    private ListView mConversationView;
    private String mConnectedDeviceName = null;
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
    private BluetoothChatService mChatService = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        db = new DB(this);


        //mConversationView = (ListView) findViewById(R.id.in);
        farmerno = (EditText) findViewById(R.id.farmerno);
        farmername = (TextView) findViewById(R.id.farmername);
        kg = (EditText) findViewById(R.id.Kg);
        kg2 = (TextView) findViewById(R.id.kg2);

        kgcollected = (TextView) findViewById(R.id.Kgcollected);
        kgcollected.setText(String.format("%.2f", login.Transporter.Cummulative_Collected));
        farmernameprogress = (ProgressBar) findViewById(R.id.getfarmername);
        Toast.makeText(getApplicationContext(), String.format("Total farmers %s", db.Totalfarmers()), Toast.LENGTH_LONG).show();
        fab = (FloatingActionButton) findViewById(R.id.fab);

        mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
        if (mBluetoothAdapter == null) {
            Toast.makeText(getApplicationContext(), "Bluetooth is not available", Toast.LENGTH_LONG).show();

        }

        //findBT("BCM4330B1 37.4 MHz Class 1.5 NoExtLNA WLBGA ANT PLUS DS");
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                kg.setError(null);
                try {
                    if (farmers == null)
                        getfarmer();
                    if (farmers != null) {
                        if (!kg.getText().toString().equals("")) {
                            cdt = Calendar.getInstance();
                            fab.setVisibility(View.GONE);
                            SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
                            final String formattedDate = df.format(cdt.getTime());
                            df = new SimpleDateFormat("HH:mm:ss");
                            final String formattedtime = df.format(cdt.getTime());
                            c = new Collection();
                            c.Date = formattedDate;
                            c.Time = formattedtime;
                            c.Farmers_Number = farmers.No;
                            c.Farmers_Name = farmers.Name;
                            c.Kg_Collected = Double.parseDouble(kg.getText().toString());
                            c.Transporter = login.Transporter.No;
                            SimpleDateFormat dff = new SimpleDateFormat("yyMMdd");
                            final String formatteddate = dff.format(cdt.getTime());
                            dff = new SimpleDateFormat("HHmmss");
                            final String formattedt = dff.format(cdt.getTime());
                            c.Collection_Number = String.format("%s%s%s", c.Farmers_Number, formatteddate, formattedt);
                            c.sent = false;
                            c.status = "Pending";
                            if (Routes.currentroute != null)
                                c.Factory = Routes.currentroute.Code;

                            db.insertCollection(c);
                            farmerno.setText("");
                            farmername.setText("");
                            kg.setText("");
                            fab.setVisibility(View.VISIBLE);
                            login.Transporter.Cummulative_Collected += c.Kg_Collected;
                            farmers.Cummulative += c.Kg_Collected;
                            db.updateFarmer(farmers);
                            db.updateFarmer(login.Transporter);
                            kgcollected.setText(String.format("%.2f", login.Transporter.Cummulative_Collected));
                            sendMessage("zero");
                            ResultsBox(c);
                            // new sendcollection(c).execute();
                            new sendpendingcollection(db.getpendingCollection()).execute();
                        } else {
                            kg.setError("No Kgs");
                        }
                    }
                } catch (Exception ex) {
                    fab.setVisibility(View.VISIBLE);
                    ex.printStackTrace();
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

    private void getfarmer() {
        farmerno.setError(null);
        if (!farmerno.getText().toString().equals("")) {
            farmers = new Farmer();
            farmers.No = farmerno.getText().toString();
            farmernameprogress.setVisibility(View.VISIBLE);
            farmers = db.getFarmer(farmers.No);

            if (farmers != null) {
                farmername.setText(farmers.Name);
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
//    void findBT(String devicename) {
//        mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
//        if (mBluetoothAdapter == null) {
//            Toast.makeText(getApplicationContext(), "No bluetooth adapter available", Toast.LENGTH_LONG).show();
//        }
//        if (!mBluetoothAdapter.isEnabled()) {
//            Intent enableBluetooth = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
//            startActivityForResult(enableBluetooth, 0);
//        }
//        Set<BluetoothDevice> pairedDevices = mBluetoothAdapter.getBondedDevices();
//        if (pairedDevices.size() > 0) {
//            for (BluetoothDevice device : pairedDevices) {
//                String dn = device.getName();
//                if (device.getName().equals(devicename)) {
//                    mmDevice = device;
//                    break;
//                }
//            }
//        }
//        if (mmDevice != null) {
//            Toast.makeText(getApplicationContext(), "Bluetooth Device Found", Toast.LENGTH_LONG).show();
//            try {
//                openBT();
//            } catch (Exception ex) {
//                ex.printStackTrace();
//            }
//        }
//
//    }
//
//    void openBT() throws IOException {
//
//        try {
//            UUID uuid = UUID.fromString("00001101-0000-1000-8000-00805f9b34fb"); //Standard SerialPortService ID
//            //btsocket =(BluetoothSocket) mmDevice.getClass().getMethod("createRfcommSocket", new Class[] {int.class}).invoke(mmDevice,1);
//
//            btsocket = mmDevice.createInsecureRfcommSocketToServiceRecord(uuid);
//            btsocket.connect();
//            btoutputstream = btsocket.getOutputStream();
//            btinputstream = btsocket.getInputStream();
//            beginListenForData();
//
//            Toast.makeText(getApplicationContext(), "Bluetooth Opened", Toast.LENGTH_LONG).show();
//        } catch (Exception ex) {
//            ex.printStackTrace();
//        }
//    }
//
//    void beginListenForData() {
//        final Handler handler = new Handler();
//        final byte delimiter = 10; //This is the ASCII code for a newline character
//
//        stopWorker = false;
//        readBufferPosition = 0;
//        readBuffer = new byte[1024];
//        workerThread = new Thread(new Runnable() {
//            public void run() {
//                while (!Thread.currentThread().isInterrupted() && !stopWorker) {
//                    try {
//                        int bytesAvailable = btinputstream.available();
//                        if (bytesAvailable > 0) {
//                            byte[] packetBytes = new byte[bytesAvailable];
//                            btinputstream.read(packetBytes);
//                            for (int i = 0; i < bytesAvailable; i++) {
//                                byte b = packetBytes[i];
//                                if (b == delimiter) {
//                                    byte[] encodedBytes = new byte[readBufferPosition];
//                                    System.arraycopy(readBuffer, 0, encodedBytes, 0, encodedBytes.length);
//                                    final String data = new String(encodedBytes, "US-ASCII");
//                                    readBufferPosition = 0;
//
//                                    handler.post(new Runnable() {
//                                        public void run() {
//                                            kg.setText(data);
//                                        }
//                                    });
//                                } else {
//                                    readBuffer[readBufferPosition++] = b;
//                                }
//                            }
//                        }
//                    } catch (IOException ex) {
//                        stopWorker = true;
//                    }
//                }
//            }
//        });
//
//        workerThread.start();
//    }

    @Override
    public void onStart() {
        super.onStart();
        // If BT is not on, request that it be enabled.
        // setupChat() will then be called during onActivityResult
        if (!mBluetoothAdapter.isEnabled()) {
            Intent enableIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
            startActivityForResult(enableIntent, REQUEST_ENABLE_BT);
            // Otherwise, setup the chat session
        } else if (mChatService == null) {
            setupChat();
        }
    }

    protected void connect() {
        if (btsocket == null) {
            Intent BTIntent = new Intent(this, BTDeviceList.class);
            this.startActivityForResult(BTIntent, REQUEST_CONNECT_BT);
        } else {

            OutputStream opstream = null;
            try {
                opstream = btsocket.getOutputStream();
            } catch (IOException e) {
                e.printStackTrace();
            }
            btoutputstream = opstream;
        }
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
            case R.id.connectweigh: {
                // Launch the DeviceListActivity to see devices and do scan
                Intent serverIntent = new Intent(getApplicationContext(), DeviceListActivity.class);
                startActivityForResult(serverIntent, REQUEST_CONNECT_DEVICE_SECURE);
                return true;
            }
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
            case R.id.Connectprinter: {
                connect();
                return true;
            }
            case R.id.settings: {
                Intent intent = new Intent(getApplicationContext(), SettingsActivity.class);
                startActivity(intent);

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
        if (mChatService != null) {
            // Only if the state is STATE_NONE, do we know that we haven't started already
            if (mChatService.getState() == BluetoothChatService.STATE_NONE) {
                // Start the Bluetooth chat services
                mChatService.start();
            }
        }
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        try {
            if (btsocket != null) {
                btoutputstream.close();
                btsocket.close();
                btsocket = null;
            }
            if (mChatService != null) {
                mChatService.stop();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void connectDevice(Intent data, boolean secure) {
        // Get the device MAC address
        String address = data.getExtras()
                .getString(DeviceListActivity.EXTRA_DEVICE_ADDRESS);
        // Get the BluetoothDevice object
        BluetoothDevice device = mBluetoothAdapter.getRemoteDevice(address);
        // Attempt to connect to the device
        mChatService.connect(device, secure);
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
                    connectDevice(data, true);
                }
                break;
            case REQUEST_CONNECT_DEVICE_INSECURE:
                // When DeviceListActivity returns with a device to connect
                if (resultCode == Activity.RESULT_OK) {
                    connectDevice(data, false);
                }
                break;
            case REQUEST_ENABLE_BT:
                // When the request to enable Bluetooth returns
                if (resultCode == Activity.RESULT_OK) {
                    // Bluetooth is now enabled, so set up a chat session
                    setupChat();
                } else {
                    // User did not enable Bluetooth or an error occurred
                    Log.d("Bt", "BT not enabled");
                    Toast.makeText(getApplicationContext(), R.string.bt_not_enabled_leaving,
                            Toast.LENGTH_SHORT).show();
                    finish();
                }
        }
    }

    private void sendMessage(String message) {
        // Check that we're actually connected before trying anything
        if (mChatService.getState() != BluetoothChatService.STATE_CONNECTED) {
            Toast.makeText(this, R.string.not_connected, Toast.LENGTH_SHORT).show();
            return;
        }

        // Check that there's actually something to send
        if (message.length() > 0) {
            // Get the message bytes and tell the BluetoothChatService to write
            byte[] send = message.getBytes();
            mChatService.write(send);

            // Reset out string buffer to zero and clear the edit text field
            mOutStringBuffer.setLength(0);

        }
    }

    private void setupChat() {


        // Initialize the array adapter for the conversation thread
        mConversationArrayAdapter = new ArrayAdapter<String>(getApplicationContext(), R.layout.message);

        // mConversationView.setAdapter(mConversationArrayAdapter);

        // Initialize the compose field with a listener for the return key
        //mOutEditText.setOnEditorActionListener(mWriteListener);

        // Initialize the send button with a listener that for click events
//        mSendButton.setOnClickListener(new View.OnClickListener() {
//            public void onClick(View v) {
//                // Send a message using content of the edit text widget
//                View view = getView();
//                if (null != view) {
//                    TextView textView = (TextView) view.findViewById(R.id.edit_text_out);
//                    String message = textView.getText().toString();
//                    sendMessage(message);
//                }
//            }
//        });

        // Initialize the BluetoothChatService to perform bluetooth connections
        mChatService = new BluetoothChatService(getApplicationContext(), mHandler);

        // Initialize the buffer for outgoing messages
        mOutStringBuffer = new StringBuffer("");
    }

    private void setStatus(CharSequence subTitle) {

        if (null == getApplicationContext()) {
            return;
        }
        final ActionBar actionBar = getActionBar();
        if (null == actionBar) {
            return;
        }
        actionBar.setSubtitle(subTitle);
    }

    private static boolean isExternalStorageReadOnly() {
        String extStorageState = Environment.getExternalStorageState();
        if (Environment.MEDIA_MOUNTED_READ_ONLY.equals(extStorageState)) {
            return true;
        }
        return false;
    }

    private static boolean isExternalStorageAvailable() {
        String extStorageState = Environment.getExternalStorageState();
        if (Environment.MEDIA_MOUNTED.equals(extStorageState)) {
            return true;
        }
        return false;
    }

    private Boolean writetofile(Collection c) {
        boolean wrote = false;
        try {
            String filename = c.Date + ".txt";
            String filepath = "Collection";
            File myExternalFile;


            if (!isExternalStorageAvailable() || isExternalStorageReadOnly()) {
                Toast.makeText(getApplicationContext(), "Unable to write to external storage", Toast.LENGTH_LONG).show();
            } else {
                myExternalFile = new File(getExternalFilesDir(Environment.DIRECTORY_DOWNLOADS).getAbsolutePath(), filename);
                FileOutputStream fos = new FileOutputStream(myExternalFile);
                fos.write(String.format("%s:%s;%s", c.Collection_Number, c.Farmers_Number, c.Kg_Collected).getBytes());
                fos.close();
                wrote = true;
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return wrote;
    }

    private class Getvendors extends AsyncTask<Farmer, Void, Farmer> {
        Farmer f = null;

        Getvendors(Farmer ff) {
            f = ff;
        }

        @Override
        protected void onPreExecute() {
        }

        @Override
        protected Farmer doInBackground(Farmer... params) {
            //
            Farmer results = null;
            String result = null;
            try {
                List<Farmer> fff = db.getAllFarmers();
                for (Farmer far : fff
                        ) {
                    if (far.No.equals(f.No)) {

                        return far;
                    }
                }
                Gson g = new Gson();
                result = g.toJson(this.f);
                result = JsonParser.getXmlFromUrl("GetFarmer", "data", result);
                Type localType = new TypeToken<Farmer>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
            } catch (Exception e) {
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(Farmer res) {
            try {
                farmernameprogress.setVisibility(View.GONE);
                farmers = res;
                if (farmers != null)

                    farmername.setText(farmers.Name);
                else
                    farmername.setText("No farmer record found");
                //farmername.setTextColor(Color.RED);
            } catch (Exception ex) {
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

//                Calendar c = Calendar.getInstance();
//                System.out.println("Current time => " + c.getTime());
//                SimpleDateFormat df = new SimpleDateFormat("dd-MMM-yyyy");
//                final String formattedDate = df.format(c.getTime());
//                df = new SimpleDateFormat("hh:mm:ss");
//                final String formattedtime = df.format(c.getTime());

            collno.setText(t.Collection_Number);
            membno.setText(t.Farmers_Number);
            membername.setText(t.Farmers_Name);
            datecoo.setText(t.Date);
            timecoll.setText(t.Time);
            kgcoll.setText(t.Kg_Collected.toString());
            cummkg.setText(String.format("%.2f", farmers.Cummulative));
            alertDialogBuilder
                    .setCancelable(false)
                    //.setTitle("Transaction Results")
                    .setPositiveButton("Print", new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int id) {
                            try {
                                String head;
                                head = "     MILK DELIVERY RECIEPT\n";
                                String data = "";
                                data = "--------------------------------\n";
                                data += "Coll. No:   " + t.Collection_Number + "\n";
                                data += "Member No:  " + t.Farmers_Number + "\n";
                                data += "Member Name:" + t.Farmers_Name + "\n";
                                data += "Coll. Date: " + t.Date + "\n";
                                data += "Coll. Time: " + t.Time + "\n";
                                data += "Kg Coll:    " + t.Kg_Collected.toString() + "\n";
                                data += "--------------------------------\n";
                                data += "Cum Kg:     " + String.format("%.2f", farmers.Cummulative) + "\n\n";
                                data += "Served by:  " + login.Transporter.Name + "\n\n\n";


                                try {
                                    Thread.sleep(1000);
                                } catch (InterruptedException e) {
                                    e.printStackTrace();
                                }
                                if (btsocket != null) {
                                    btoutputstream = btsocket.getOutputStream();
                                    byte[] arrayOfByte1 = {27, 33, 0};
                                    byte[] format = {27, 33, 0};

                                    btoutputstream.write(format);
                                    String msg = head;
                                    btoutputstream.write(msg.getBytes());
                                    byte[] printformat = {27, 33, 0};
                                    btoutputstream.write(printformat);
                                    msg = data;
                                    btoutputstream.write(msg.getBytes());
                                    btoutputstream.write(0x0D);
                                    btoutputstream.write(0x0D);
                                    btoutputstream.write(0x0D);
                                    btoutputstream.flush();
                                } else
                                    Toast.makeText(getApplicationContext(), "Unable to print, printer not available", Toast.LENGTH_LONG).show();

                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                            sending = false;
                        }
                    })
                    .setNegativeButton("Reverse", new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int id) {
                            c.status = "Reversed";
                            db.updateCollection(c);

                            Toast.makeText(getApplicationContext(), String.format("Collection %s reversed", c.Collection_Number), Toast.LENGTH_LONG).show();
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

    private class sendcollection extends AsyncTask<Collection, Void, Collection> {
        Collection c = null;

        sendcollection(Collection ff) {
            c = ff;
        }

        @Override
        protected void onPreExecute() {
        }

        @Override
        protected Collection doInBackground(Collection... params) {
            Collection results = null;
            String result = null;
            try {
                Gson g = new Gson();
                result = g.toJson(this.c);
                result = JsonParser.postjson("Collections", "data", result);
                Type localType = new TypeToken<Collection>() {
                }.getType();
                results = new Gson().fromJson(result, localType);

            } catch (Exception e) {
                e.printStackTrace();
                results = c;
            }
            return results;
        }

        @Override
        protected void onPostExecute(Collection res) {
            try {
                if (res != null) {
                    c = res;
                    c.sent = true;
                    c.kgcollected = c.kgcollected + c.Kg_Collected;
                    c.Cumm += c.Kg_Collected;
                    Log.i("sent", "ok");
                    farmerno.setText("");
                    farmername.setText("");
                    kg.setText("");
                } else {
                    Log.i("sent", "No");
                    c.sent = false;
                    farmerno.setText("");
                    farmername.setText("");
                    kg.setText("");
                }


            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }


    }

    private class sendpendingcollection extends AsyncTask<List<Collection>, Void, List<Collection>> {
        List<Collection> c = null;

        sendpendingcollection(List<Collection> ff) {
            c = ff;
        }

        @Override
        protected void onPreExecute() {
        }

        @Override
        protected List<Collection> doInBackground(List<Collection>... params) {
            //
            List<Collection> results = null;
            String result = null;
            try {
                Log.i("Notsent", String.valueOf(c.size()));
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
            }
            return results;
        }

        @Override
        protected void onPostExecute(List<Collection> res) {
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
                case Constants.MESSAGE_STATE_CHANGE:
                    switch (msg.arg1) {
                        case BluetoothChatService.STATE_CONNECTED:
                            setStatus(getString(R.string.title_connected_to, mConnectedDeviceName));
                            mConversationArrayAdapter.clear();
                            break;
                        case BluetoothChatService.STATE_CONNECTING:
                            setStatus("Connecting");
                            break;
                        case BluetoothChatService.STATE_LISTEN:
                        case BluetoothChatService.STATE_NONE:
                            setStatus("Not connected");
                            break;
                    }
                    break;
                case Constants.MESSAGE_WRITE:
                    byte[] writeBuf = (byte[]) msg.obj;
                    // construct a string from the buffer
                    String writeMessage = new String(writeBuf);
                    mConversationArrayAdapter.add("Me:  " + writeMessage);
                    break;
                case Constants.MESSAGE_READ:
                    byte[] readBuf = (byte[]) msg.obj;
                    // construct a string from the valid bytes in the buffer
                    String readMessage = new String(readBuf, 0, msg.arg1);
                    Log.i("Data Recieved", readMessage);
                    String[] read = readMessage.split("\n");
                    try {
                        if (read[0].contains("ST,GS"))
                            kg.setText(read[0].replace("ST,GS,", "").replace("KG", "").replace(" ", "").trim());
                        Log.i("Weight", read[0]);
//                    if (readMessage.length() > 5 && readMessage.contains("KG")) {
//                        String read = readMessage.replace("S", "").replace("G", "").replace(",", "").replace("K", "").replace("-", "").replace("T", "").replace("U", "").replace(" ", "");
//                        if (!read.trim().equals(""))
//                            //if (!read.startsWith(".") && read.contains(".")&& !read.endsWith("."))
//                            kg.setText(read.trim());
//
//                    }
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
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
                                Toast.LENGTH_SHORT).show();
                    }
                    break;
            }
        }
    };

}
