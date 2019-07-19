package com.example.paul.datacollector;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.os.Handler;
import android.os.ParcelUuid;
import android.os.Parcelable;
import android.util.Log;
import android.widget.CheckBox;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.lang.reflect.Method;
import java.security.spec.ECField;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import static android.content.Context.MODE_PRIVATE;
import static com.example.paul.datacollector.Summaries.printer.printThread;
import static com.example.paul.datacollector.Summaries.printer.printerdevice;
import static com.example.paul.datacollector.Summaries.printer.printerin;
import static com.example.paul.datacollector.Summaries.printer.printerout;
import static com.example.paul.datacollector.Summaries.printer.printersock;
import static com.example.paul.datacollector.Summaries.scale.scaleThread;
import static com.example.paul.datacollector.Summaries.scale.scaledevice;
import static com.example.paul.datacollector.Summaries.scale.scalein;
import static com.example.paul.datacollector.Summaries.scale.scaleout;
import static com.example.paul.datacollector.Summaries.scale.scalesock;

/**
 * Created by Paul on 09-Oct-16.
 */

public class Summaries {

    public static class Bydate {
        public String Date;
        public Double Total;
    }
    public static class Months {
        public String Month;
        public String date;
        public String toString() {
            return this.Month;
        }
    }
    public  static class getdata{
        public  String firstdate;
        public  String LastDate;
        public String route;

    }


    static Handler mHandler = null;


    public static boolean createBond(BluetoothDevice btDevice)
            throws Exception {
        Class class1 = Class.forName("android.bluetooth.BluetoothDevice");
        Method createBondMethod = class1.getMethod("createBond");
        Boolean returnValue = (Boolean) createBondMethod.invoke(btDevice);
        return returnValue.booleanValue();
    }

    public static class Scalethread extends Thread {

        private BluetoothSocket mmSocket;
        SharedPreferences preferences;

        public Scalethread(SharedPreferences s) {
            try {
                preferences = s;
                scaleThread = this;
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
        public void run() {

            byte[] buffer = new byte[1024];
            int bytes = 0;
            int begin = 0;
            ParcelUuid[] pu;
            // Make a connection to the BluetoothSocket
           while (true) {
            try {
                Log.i("Connecting", "Attempting to connect to scale");
                String value = preferences.getString("SCALE", "");
                if (!value.equals("")) {
                    BluetoothAdapter ad = BluetoothAdapter.getDefaultAdapter();
                    if (ad != null) {
                        if (!ad.isEnabled())
                            ad.enable();
                        BluetoothDevice zee = ad.getRemoteDevice(value);
                        scaledevice = zee;
                        if (zee.getBondState() == BluetoothDevice.BOND_NONE) {
                            createBond(zee);
                        }
                        pu = zee.getUuids();
                        ad.cancelDiscovery();
                        BluetoothSocket tmp = null;
                        // Get a BluetoothSocket to connect with the given BluetoothDevice
                        try {
                            // MY_UUID is the app's UUID string, also used by the server code
                            tmp = zee.createRfcommSocketToServiceRecord(UUID.fromString("8ce255c0-200a-11e0-ac64-0800200c9a66"));
                            scalesock = tmp;
                            Thread.sleep(1000);
                            if (!scalesock.isConnected())
                                scalesock.connect();
                            Log.i("connection 1", "Connected");
                        } catch (Exception ex) {
                            ex.printStackTrace();
                            try {
                                scalesock.close();
                                Method m = zee.getClass().getMethod("createRfcommSocket",
                                        new Class[]{int.class});
                                scalesock = (BluetoothSocket) m.invoke(zee, Integer.valueOf(1));
                                Thread.sleep(1000);
                                if (!scalesock.isConnected())
                                    scalesock.connect();
                            } catch (Exception e) {
                                scalesock.close();
                                e.printStackTrace();
                                BluetoothConnector bc;
                                List<UUID> ids = new ArrayList<>();
                                for (ParcelUuid p : pu
                                        ) {
                                    Log.i("uuids", p.getUuid().toString());
                                    ids.add(p.getUuid());
                                }
//                                final UUID MY_UUID_SECURE =
//                                        UUID.fromString("fa87c0d0-afac-11de-8a39-0800200c9a66");
//                                List<UUID> ids = new ArrayList<>();
//                                UUID id = MY_UUID_SECURE;
//                                ids.add(ids);
                                bc = new BluetoothConnector(zee, true, ad, ids);
                                Thread.sleep(1000);
                                if (!scalesock.isConnected())
                                    scalesock = bc.connect();
                            }
                        }
                        mHandler.obtainMessage(Constants.SCALE_CONNECTED, true).sendToTarget();
                        mmSocket = scalesock;
                        scalein = mmSocket.getInputStream();
                        scaleout = mmSocket.getOutputStream();
                        try {
                            while (true) {
                                if ((mmSocket.isConnected())) {
                                    Log.i("Reading data", "Data reading");
                                    bytes += scalein.read(buffer, bytes, buffer.length - bytes);
                                    Log.i("Readin data", new String(buffer));
                                    mHandler.obtainMessage(Constants.MESSAGE_READ, 0, 0, buffer).sendToTarget();
                                    for (int i = begin; i < bytes; i++) {
                                        Log.i("Read data", new String(buffer, 0, begin));
                                        if (buffer[i] == "\n".getBytes()[0]) {
                                            mHandler.obtainMessage(Constants.MESSAGE_READ, begin, i, buffer).sendToTarget();
                                            begin = i + 1;
                                            if (i == bytes - 1) {
                                                bytes = 0;
                                                begin = 0;
                                            }
                                        }
                                    }
                                } else
                                    mHandler.obtainMessage(Constants.SCALE_DISCONNECTED, true).sendToTarget();
                            }
                        } catch (IOException e) {
                            e.printStackTrace();
                            mHandler.obtainMessage(Constants.MESSAGE_TOAST, e.getMessage()).sendToTarget();
                        }
                    } else
                        mHandler.obtainMessage(Constants.MESSAGE_TOAST, "Bluetooth not found").sendToTarget();
                    Thread.sleep(3000);

                } else
                    return;
            } catch (Exception ex) {
                ex.printStackTrace();
                mHandler.obtainMessage(Constants.MESSAGE_TOAST, ex.getMessage()).sendToTarget();
            }
           }
            // Reset the ConnectThread because we're done
            // Start the connected thread
        }

        public void write(byte[] buffer) {
            try {
                scaleout.write(buffer);

            } catch (IOException e) {
                e.printStackTrace();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

        public void cancel() {
            try {
                mmSocket.close();
                scalein.close();
                scaleout.close();
            } catch (IOException e) {

            }
        }
    }

    //    public static class Scalethread extends Thread {
//        private BluetoothSocket mmSocket;
//        SharedPreferences preferences;
//
//        public Scalethread(SharedPreferences s) {
//            try {
//                preferences = s;
//                scaleThread = this;
//            } catch (Exception ex) {
//                ex.printStackTrace();
//            }
//        }
//
//        public void run() {
//
//            byte[] buffer = new byte[1024];
//            int bytes = 0;
//            int begin = 0;
//            ParcelUuid[] pu;
//            // Make a connection to the BluetoothSocket
//            while (true) {
//                try {
//                    Log.i("Connecting","Attempting to connect to scale");
//                    String value = preferences.getString("SCALE", "");
//                    if (!value.equals("")) {
//                        BluetoothAdapter ad = BluetoothAdapter.getDefaultAdapter();
//                        if (ad != null) {
//                            if (!ad.isEnabled())
//                                ad.enable();
//                            BluetoothDevice zee = ad.getRemoteDevice(value);
//                            scaledevice = zee;
//                            if (zee.getBondState() == BluetoothDevice.BOND_NONE) {
//                                createBond(zee);
//                            }
//                            pu = zee.getUuids();
//                            Method m = zee.getClass().getMethod("createRfcommSocket",
//                                    new Class[]{int.class});
//
//                            scalesock = (BluetoothSocket) m.invoke(zee, Integer.valueOf(1));
//
//                            try {
//                                scalesock.connect();
//                                Log.i("connection 1","Connected");
//                            } catch (IOException ex) {
//                                BluetoothConnector bc;
//
//                                List<UUID> ids = new ArrayList<>();
//
//                                for (ParcelUuid p:pu
//                                     ) {
//                                    Log.i("uuids",p.getUuid().toString());
//                                    ids.add(p.getUuid());
//                                }
////                                final UUID MY_UUID_SECURE =
////                                        UUID.fromString("fa87c0d0-afac-11de-8a39-0800200c9a66");
////                                List<UUID> ids = new ArrayList<>();
////                                UUID id = MY_UUID_SECURE;
////                                ids.add(ids);
//                                bc = new BluetoothConnector(zee, true, ad, ids);
//                                scalesock = bc.connect();
//                            }
//                            mHandler.obtainMessage(Constants.SCALE_CONNECTED, true).sendToTarget();
//
//
//                            mmSocket = scalesock;
//                            scalein = mmSocket.getInputStream();
//                            scaleout = mmSocket.getOutputStream();
//
//                            try {
//                                while (true) {
//                                    if ((mmSocket.isConnected())) {
//                                        Log.i("Reading data","Data reading");
//                                        bytes += scalein.read(buffer, bytes, buffer.length - bytes);
//                                        Log.i("Readin data",new String(buffer));
//                                        mHandler.obtainMessage(Constants.MESSAGE_READ,0,0, buffer).sendToTarget();
//
//                                        for (int i = begin; i < bytes; i++) {
//                                            Log.i("Read data",new String(buffer, 0, begin));
//                                            if (buffer[i] == "\n".getBytes()[0]) {
//                                                mHandler.obtainMessage(Constants.MESSAGE_READ, begin, i, buffer).sendToTarget();
//                                                begin = i + 1;
//                                                if (i == bytes - 1) {
//                                                    bytes = 0;
//                                                    begin = 0;
//                                                }
//                                            }
//                                        }
//                                    } else
//                                        mHandler.obtainMessage(Constants.SCALE_DISCONNECTED, true).sendToTarget();
//                                }
//                            } catch (IOException e) {
//                                e.printStackTrace();
//                                mHandler.obtainMessage(Constants.MESSAGE_TOAST, e.getMessage()).sendToTarget();
//                            }
//                        } else
//                            mHandler.obtainMessage(Constants.MESSAGE_TOAST, "Bluetooth not found").sendToTarget();
//                        Thread.sleep(3000);
//
//                    } else
//                        return;
//                } catch (Exception ex) {
//                    ex.printStackTrace();
//                    mHandler.obtainMessage(Constants.MESSAGE_TOAST, ex.getMessage()).sendToTarget();
//
//
//                }
//            }
//            // Reset the ConnectThread because we're done
//
//
//            // Start the connected thread
//        }
//
//        public void write(byte[] buffer) {
//            try {
//                scaleout.write(buffer);
//
//            } catch (IOException e) {
//                e.printStackTrace();
//            } catch (Exception e) {
//                e.printStackTrace();
//            }
//        }
//
//        public void cancel() {
//            try {
//                mmSocket.close();
//                scalein.close();
//                scaleout.close();
//            } catch (IOException e) {
//
//            }
//        }
//    }
    public static class scale {
        public static BluetoothSocket scalesock;
        public static InputStream scalein;
        public static OutputStream scaleout;
        public static Scalethread scaleThread;
        public static BluetoothDevice scaledevice;

        public void writetoscale(byte[] out) {
            // Create temporary object
            Scalethread r;
            // Synchronize a copy of the ConnectedThread
            synchronized (this) {

                r = scaleThread;
            }
            // Perform the write unsynchronized
            r.write(out);
        }


    }

    public static class Printerthread extends Thread {
        private BluetoothSocket pSocket;
        SharedPreferences preferences;

        public Printerthread(SharedPreferences s) {
            try {
                preferences = s;
                printThread = this;
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }

        public void run() {
            byte[] pbuffer = new byte[1024];
            int pbytes = 0;
            int pbegin = 0;
            // Make a connection to the BluetoothSocket
            while (true) {
                try {
                    String value = preferences.getString("PRINTER", "");
//                BluetoothDevice prnt = BluetoothAdapter.getDefaultAdapter().                        getRemoteDevice("00:02:0A:02:60:10");
                    if (!value.equals("")) {
                        BluetoothAdapter ad = BluetoothAdapter.getDefaultAdapter();
                        if (ad != null) {
                            if (!ad.isEnabled())
                                ad.enable();
                            BluetoothDevice prnt = ad.getRemoteDevice(value);
                            ParcelUuid[] uuds = prnt.getUuids();
                            if (uuds != null)
                                for (ParcelUuid u : uuds
                                        ) {
                                    UUID pa = u.getUuid();
                                    Log.i("Device uuid", pa.toString());
                                }
                            printerdevice = prnt;
                            Method m = prnt.getClass().getMethod("createRfcommSocket",
                                    new Class[]{int.class});
                            printersock = (BluetoothSocket) m.invoke(prnt, Integer.valueOf(1));
                            try {
                                Thread.sleep(1000);
                                printersock.connect();
                            } catch (IOException ex) {
                                BluetoothConnector bc;
                                final UUID MY_UUID_SECURE =
                                        UUID.fromString("fa87c0d0-afac-11de-8a39-0800200c9a66");
                                List<UUID> ids = new ArrayList<>();
                                UUID id = MY_UUID_SECURE;
                                ids.add(id);
                                bc = new BluetoothConnector(prnt, true, ad, ids);
                                Thread.sleep(1000);
                                printersock = bc.connect();
                            }
                            mHandler.obtainMessage(Constants.PRINTER_CONNECTED, true).sendToTarget();
                            pSocket = printersock;
                            printerin = pSocket.getInputStream();
                            printerout = pSocket.getOutputStream();

                            try {
                                while (true) {
                                    if ((pSocket.isConnected())) {
                                        pbytes += printerin.read(pbuffer, pbytes, pbuffer.length - pbytes);
                                        for (int i = pbegin; i < pbytes; i++) {
                                            if (pbuffer[i] == "\n".getBytes()[0]) {
                                                mHandler.obtainMessage(Constants.PRINTER_MESSAGE_READ, pbegin, i, pbuffer).sendToTarget();
                                                pbegin = i + 1;
                                                if (i == pbytes - 1) {
                                                    pbytes = 0;
                                                    pbegin = 0;
                                                }
                                            }
                                        }
                                    } else {
                                        mHandler.obtainMessage(Constants.SCALE_DISCONNECTED, true).sendToTarget();
                                    }
                                }
                            } catch (IOException e) {
                                e.printStackTrace();
                            }
                        } else
                            mHandler.obtainMessage(Constants.MESSAGE_TOAST, "No bluetooth found").sendToTarget();

                    } else return;
                } catch (Exception ex) {
                    ex.printStackTrace();

                }

            }
            // Reset the ConnectThread because we're done


            // Start the connected thread
        }

        public void write(byte[] buffer) {
            try {
                printerout.write(buffer);

            } catch (IOException e) {
                e.printStackTrace();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

        public void write(int buffer) {
            try {
                printerout.write(buffer);

            } catch (IOException e) {
                e.printStackTrace();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

        public void flush() {
            try {
                printerout.flush();

            } catch (IOException e) {
                e.printStackTrace();
            } catch (Exception e) {
                e.printStackTrace();
            }

        }

        public void cancel() {
            try {
                pSocket.close();
                printerin.close();
                printerout.close();
            } catch (IOException e) {

            }
        }
    }

    //    public static class Printerthread extends Thread {
//        private BluetoothSocket pSocket;
//        SharedPreferences preferences;
//
//        public Printerthread(SharedPreferences s) {
//            try {
//                preferences = s;
//                printThread = this;
//            } catch (Exception ex) {
//                ex.printStackTrace();
//            }
//        }
//
//        public void run() {
//
//            byte[] pbuffer = new byte[1024];
//            int pbytes = 0;
//            int pbegin = 0;
//            // Make a connection to the BluetoothSocket
//            while (true) {
//                try {
//
//                    String value = preferences.getString("PRINTER", "");
////                BluetoothDevice prnt = BluetoothAdapter.getDefaultAdapter().                        getRemoteDevice("00:02:0A:02:60:10");
//                    if (!value.equals("")) {
//                        BluetoothAdapter ad = BluetoothAdapter.getDefaultAdapter();
//                        if (ad != null) {
//                            if (!ad.isEnabled())
//                                ad.enable();
//
//                            BluetoothDevice prnt = ad.getRemoteDevice(value);
//                            printerdevice = prnt;
//                            Method m = prnt.getClass().getMethod("createRfcommSocket",
//                                    new Class[]{int.class});
//
//                            printersock = (BluetoothSocket) m.invoke(prnt, Integer.valueOf(1));
//
//
//                            try {
//                                printersock.connect();
//                            } catch (IOException ex) {
//                                BluetoothConnector bc;
//                                final UUID MY_UUID_SECURE =
//                                        UUID.fromString("fa87c0d0-afac-11de-8a39-0800200c9a66");
//                                List<UUID> ids = new ArrayList<>();
//                                UUID id = MY_UUID_SECURE;
//                                ids.add(id);
//                                bc = new BluetoothConnector(prnt, true, ad, ids);
//                                printersock = bc.connect();
//                            }
//                            mHandler.obtainMessage(Constants.PRINTER_CONNECTED, true).sendToTarget();
//
//                            pSocket = printersock;
//
//                            printerin = pSocket.getInputStream();
//                            printerout = pSocket.getOutputStream();
//
//                            try {
//                                while (true) {
//                                    if ((pSocket.isConnected())) {
//                                        pbytes += printerin.read(pbuffer, pbytes, pbuffer.length - pbytes);
//                                        for (int i = pbegin; i < pbytes; i++) {
//                                            if (pbuffer[i] == "\n".getBytes()[0]) {
//                                                mHandler.obtainMessage(Constants.PRINTER_MESSAGE_READ, pbegin, i, pbuffer).sendToTarget();
//                                                pbegin = i + 1;
//                                                if (i == pbytes - 1) {
//                                                    pbytes = 0;
//                                                    pbegin = 0;
//                                                }
//                                            }
//                                        }
//                                    } else {
//                                        mHandler.obtainMessage(Constants.SCALE_DISCONNECTED, true).sendToTarget();
//                                    }
//                                }
//                            } catch (IOException e) {
//                                e.printStackTrace();
//                            }
//                        } else
//                            mHandler.obtainMessage(Constants.MESSAGE_TOAST, "No bluetooth found").sendToTarget();
//
//                    } else return;
//                } catch (Exception ex) {
//                    ex.printStackTrace();
//
//                }
//
//            }
//            // Reset the ConnectThread because we're done
//
//
//            // Start the connected thread
//        }
//
//        public void write(byte[] buffer) {
//            try {
//                printerout.write(buffer);
//
//            } catch (IOException e) {
//                e.printStackTrace();
//            } catch (Exception e) {
//                e.printStackTrace();
//            }
//        }
//
//        public void write(int buffer) {
//            try {
//                printerout.write(buffer);
//
//            } catch (IOException e) {
//                e.printStackTrace();
//            } catch (Exception e) {
//                e.printStackTrace();
//            }
//        }
//
//        public void flush() {
//            try {
//                printerout.flush();
//
//            } catch (IOException e) {
//                e.printStackTrace();
//            } catch (Exception e) {
//                e.printStackTrace();
//            }
//
//        }
//
//        public void cancel() {
//            try {
//                pSocket.close();
//                printerin.close();
//                printerout.close();
//            } catch (IOException e) {
//
//            }
//        }
//    }
    public static class printer {

        public static BluetoothSocket printersock;
        public static InputStream printerin;
        public static OutputStream printerout;
        public static Printerthread printThread;
        public static BluetoothDevice printerdevice;


        public void writetoprinter(byte[] out) {
            // Create temporary object
            Printerthread r;
            // Synchronize a copy of the ConnectedThread
            synchronized (this) {

                r = printThread;
            }
            // Perform the write unsynchronized
            r.write(out);
        }

        public void writetoprinter(int out) {
            // Create temporary object
            Printerthread r;
            // Synchronize a copy of the ConnectedThread
            synchronized (this) {

                r = printThread;
            }
            // Perform the write unsynchronized
            r.write(out);
        }

        public void flushprinter() {
            // Create temporary object
            Printerthread r;
            // Synchronize a copy of the ConnectedThread
            synchronized (this) {

                r = printThread;
            }
            // Perform the write unsynchronized
            r.flush();
        }

        public void printcollection(SharedPreferences s, Collection t) {
            try {
                String head;
                head = "   "+ getpreferences(s,"TransporterName").toUpperCase() +"\n\n";
                head += "     MILK DELIVERY RECIEPT\n";
                head += "            (COPY) \n";

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
                if (printersock != null) {

                    byte[] arrayOfByte1 = {27, 33, 0};
                    byte[] format = {27, 33, 0};

                    printerout.write(format);
                    String msg = head;
                    printerout.write(msg.getBytes());
                    byte[] printformat = {27, 33, 0};
                    printerout.write(printformat);
                    msg = data;
                    printerout.write(msg.getBytes());
                    printerout.write(0x0D);
                    printerout.write(0x0D);
                    printerout.write(0x0D);
                    printerout.flush();
                }


            } catch (IOException e) {
                e.printStackTrace();
            }

        }
        private String getpreferences(SharedPreferences s, String key) {
            String pref = "";
            String value = s.getString(key, "");

            if (value != null || value != "") {
                pref = value;
            }
            return pref;
        }
        public void printcoll(SharedPreferences s, List<Collection> t,Farmer f) {
            try {


                String head;
                head = "   "+ getpreferences(s,"TransporterName").toUpperCase() +"\n";
                head += "     Collection Slip\n";
                String data = "";
                data = "--------------------------------\n";

                data += "Member No:  " + t.get(0).Farmers_Number + "\n";
                data += "Member Name:" + t.get(0).Farmers_Name + "\n";
                data += "Member Cum: " + String.format("%.2f",f.Cummulative) + "\n";
                data += "--------------------------------\n";
                double Total = 0.0;
                for (Collection c : t
                        ) {
                    data += c.Date + " " + c.Time + "     " + c.Kg_Collected.toString() + "\n";
                    Total += c.Kg_Collected;
                }

                data += "--------------------------------\n";
                data += "TOTAL                 " + String.format("%.2f", Total) + "\n\n";

                data += "Served by: " + t.get(0).Collected_by + "\n\n\n";


                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                if (printersock != null) {

                    byte[] arrayOfByte1 = {27, 33, 0};
                    byte[] format = {27, 33, 0};

                    printerout.write(format);
                    String msg = head;
                    printerout.write(msg.getBytes());
                    byte[] printformat = {27, 33, 0};
                    printerout.write(printformat);
                    msg = data;
                    printerout.write(msg.getBytes());
                    printerout.write(0x0D);
                    printerout.write(0x0D);
                    printerout.write(0x0D);
                    printerout.flush();
                }


            } catch (Exception e) {
                e.printStackTrace();
            }

        }

    }
}
