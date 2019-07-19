package com.example.paul.bttest;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.lang.reflect.Method;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        try {
            for (int i = 0; i < 3; i++) {
                test();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

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
                getRemoteDevice("00:1B:35:0B:98:26");
        Method m = zee.getClass().getMethod("createRfcommSocket",
                new Class[] { int.class });

        sock = (BluetoothSocket)m.invoke(zee, Integer.valueOf(1));
        Log.d("ZeeTest", "++++ Connecting");

        sock.connect();

        Log.d("ZeeTest", "++++ Connected");
        in = sock.getInputStream();
        out = sock.getOutputStream();
        Thread.sleep(1000);
        out.write("connected".getBytes());
        out.flush();



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

