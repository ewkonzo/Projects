package com.example.paul.bttest;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.os.Environment;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.lang.reflect.Method;
import java.nio.channels.FileChannel;
import java.util.UUID;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
//        try {
//            for (int i = 0; i < 3; i++) {
//                test();
//            }
//        } catch (Exception e) {
//            e.printStackTrace();
//        }
getdb();
    }
    private boolean connected = false;
    private BluetoothSocket sock;
    private InputStream in;
    private OutputStream out;

    public void test() throws Exception {
        if (connected) {
            return;
        }
        BluetoothDevice zee = BluetoothAdapter.getDefaultAdapter().
                getRemoteDevice("00:1B:35:0B:92:99");
        if (zee.getBondState()== BluetoothDevice.BOND_NONE)
        {
            createBond(zee);

        }
        Method m = zee.getClass().getMethod("createRfcommSocket",
                new Class[] { int.class });
        UUID MY_UUID_SECURE =
                UUID.fromString("fa87c0d0-afac-11de-8a39-0800200c9a66");
        UUID id = MY_UUID_SECURE;
     sock  =   zee.createRfcommSocketToServiceRecord(
                MY_UUID_SECURE);
       // sock = (BluetoothSocket)m.invoke(zee, Integer.valueOf(1));
        Log.d("ZeeTest", "++++ Connecting");
//connect(zee );

       // BluetoothDevice.class.getDeclaredMethod("connect", BluetoothDevice.class);

       sock.connect();

        Log.d("ZeeTest", "++++ Connected");
        in = sock.getInputStream();
        out = sock.getOutputStream();




        Log.d("ZeeTest", "++++ Sending");
        byte[] buffer = new byte[50];
        int read = 0;
        Log.d("ZeeTest", "++++ Listening...");
        try {
            while (true) {
                read = in.read(buffer);

                connected = true;
                StringBuilder buf = new StringBuilder();
                for (int i = 0; i < read; i++) {
                    int b = buffer[i] & 0xff;
                    if (b < 0x10) {
                        buf.append("0");
                    }
                    buf.append(Integer.toHexString(b)).append(" ");
                }
                Log.d("ZeeTest", "++++ Read "+ read +" bytes: "+ buf.toString());
            }
        } catch (IOException e) {e.printStackTrace();}
        Log.d("ZeeTest", "++++ Done: test()");
    }
    private  void getdb(){

        try {
            File sd = Environment.getExternalStorageDirectory();
            File data = Environment.getDataDirectory();

            if (sd.canWrite()) {
                String currentDBPath = "/data/data/com.example.paul.datacollector/databases/MyDBName.db";
                String backupDBPath = "backupnamesweet.db";
                File currentDB = new File(currentDBPath);
                File backupDB = new File(sd, backupDBPath);

                if (currentDB.exists()) {
                    FileChannel src = new FileInputStream(currentDB).getChannel();
                    FileChannel dst = new FileOutputStream(backupDB).getChannel();
                    dst.transferFrom(src, 0, src.size());
                    src.close();
                    dst.close();
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    public boolean createBond(BluetoothDevice btDevice)
            throws Exception
    {
        Class class1 = Class.forName("android.bluetooth.BluetoothDevice");
        Method createBondMethod = class1.getMethod("createBond");
        Boolean returnValue = (Boolean) createBondMethod.invoke(btDevice);
        return returnValue.booleanValue();
    }
    private Boolean connect(BluetoothDevice bdDevice) {
        Boolean bool = false;
        try {
            Log.i("Log", "service method is called ");
            Class cl = Class.forName("android.bluetooth.BluetoothDevice");
            Class[] par = {};
            Method method = cl.getMethod("connect", par);
            Object[] args = {};
            bool = (Boolean) method.invoke(bdDevice);//, args);// this invoke creates the detected devices paired.
            //Log.i("Log", "This is: "+bool.booleanValue());
            //Log.i("Log", "devicesss: "+bdDevice.getName());
        } catch (Exception e) {
            Log.i("Log", "Inside catch of serviceFromDevice Method");
            e.printStackTrace();
        }
        return bool.booleanValue();
    };
    @Override
    public void onDestroy() {
        try {
            if (in != null) {
                in.close();
            }
            if (sock != null) {
                sock.close();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        super.onDestroy();
    }
}

