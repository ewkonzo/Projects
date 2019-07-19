package com.example.paul.m_branch;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.os.Handler;
import android.os.ParcelUuid;
import android.util.Log;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.BitSet;
import java.util.List;
import java.util.UUID;

import static com.example.paul.m_branch.summaries.printer.printThread;
import static com.example.paul.m_branch.summaries.printer.printerdevice;

import static com.example.paul.m_branch.summaries.printer.printerout;
import static com.example.paul.m_branch.summaries.printer.printersock;


/**
 * Created by Paul on 09-Oct-16.
 */

public class summaries {
    public static class reportfields {
        public String field;
        public String value;

    }

    public static class collectiondates {
        public String date;
        public int Count;
        public Double Total;

        public String MemberNo;
        public String MemberName;

        public String toString() {
            return this.date;
        }
    }
    public  static class getdata{
        public  String firstdate;
        public  String LastDate;
        public String user;

    }
    public static class Receipts {
        public String date;
        public String receipt;
        public int Count;
        public Double Total;
        public String No;
        public String Name;
        public String user;

        public String toString() {
            return this.date;
        }
    }

    public static class reportheader {
        public String Name;
        public int Count;
        public Double Total;
    }

    static Handler mHandler = null;


    public static boolean createBond(BluetoothDevice btDevice)
            throws Exception {
        Class class1 = Class.forName("android.bluetooth.BluetoothDevice");
        Method createBondMethod = class1.getMethod("createBond");
        Boolean returnValue = (Boolean) createBondMethod.invoke(btDevice);
        return returnValue.booleanValue();
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
                    Log.i("thread", "running");
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
                            printerout = pSocket.getOutputStream();
                            //Log.i("thread", "printer connected");
                            //return;
                            try {
                                while (printersock.isConnected()) {
                                    Log.i("thread", "printer connected");
                                    this.sleep(2000);
                                }

                                // mHandler.obtainMessage(Constants.PRINTER_DISCONNECTED, true).sendToTarget();

                            } catch (Exception e) {
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

        public void printcollection(Bitmap logo, List<transaction> t) {
            try {

                String head;
                head =  "        GANAKI SACCO           \n";
                head += "    P.O Box 0000-100100        \n";
                head += "        Nairobi, Kenya         \n";
                head += "    Tel: 0729052421            \n";
                head += "  Email: saccoganaki@gmail.com \n";
                head += "-------------------------------\n";
                head += "         CASH RECIEPT          \n";
                String data = "";
                data = "--------------------------------\n";
                data += "Ref:   " + t.get(0).OTTN + "\n";
                data += "M. No: " + t.get(0).Account_No + "\n";
                data += "Name:  " + t.get(0).Account_Name + "\n";
                data += "Date:  " + t.get(0).Date + "\n";
                data += "Time:  " + t.get(0).Time + "\n";
                data += "--------------------------------\n\n";
                data += "Trans Type            Amount\n";
                data += "----------            ------\n";
                double total = 0.0;
                for (transaction tt : t
                        ) {
                    total += tt.Amount;
                    if (!tt.Loan_No.equals("")) {
                        data += tt.typename + "\n";
                        if (tt.Type.contains("LOAN")) {
                            data += "(" + tt.Ward + ")" + String.format("%-" + (22 - tt.Ward.length()) + "s", "") + tt.Amount.toString() + "\n";
                            data += "(" + tt.Loan_No + ")\n";//+ String.format("%-" + (22 - tt.Ward.length()) + "s", "") + tt.Amount.toString() + "\n";
                        } else
                            data += "(" + tt.Loan_No + ")" + String.format("%-" + (22 - tt.Loan_No.length()) + "s", "") + tt.Amount.toString() + "\n";
                    } else
                        data += tt.typename + ":" + String.format("%-" + (22 - tt.typename.length()) + "s", "") + tt.Amount.toString() + "\n";

                }
                data += "--------------------------------\n";
                data += "TOTAL                 " + String.format("%.2f", total) + "\n\n";
                data += "Served by:  " + Myvariables.CurrentAgent.Name + "\n\n\n\n\n";
                try {
                    Thread.sleep(100);
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

        public void printcollectioncopy(Bitmap logo, List<transaction> t) {
            try {
                String head;
                head =  "        GANAKI SACCO           \n";
                head += "    P.O Box 0000-100100        \n";
                head += "        Nairobi, Kenya         \n";
                head += "    Tel: 0729052421            \n";
                head += "  Email: saccoganaki@gmail.com \n";
                head += "-------------------------------\n";

                head += "         CASH RECIEPT          \n";
                head += "             (COPY)\n";
                String data = "";
                data = "--------------------------------\n\n";
                data += "Ref:   " + t.get(0).OTTN + "\n";
                data += "M. No: " + t.get(0).Account_No + "\n";
                data += "Name:  " + t.get(0).Account_Name + "\n";
                data += "Date:  " + t.get(0).Date + "\n";
                data += "Time:  " + t.get(0).Time + "\n";
                data += "--------------------------------\n\n";
                data += "Trans Type            Amount\n";
                data += "----------            ------\n";
                double total = 0.0;
                for (transaction tt : t
                        ) {
                    total += tt.Amount;
                    if (!tt.Loan_No.equals("")) {
                        data += tt.typename + "\n";
                        if (tt.Type.contains("LOAN")) {
                            data += "(" + tt.Ward + ")" + String.format("%-" + (22 - tt.Ward.length()) + "s", "") + tt.Amount.toString() + "\n";
                            data += "(" + tt.Loan_No + ")\n";//+ String.format("%-" + (22 - tt.Ward.length()) + "s", "") + tt.Amount.toString() + "\n";

                        } else
                            data += "(" + tt.Loan_No + ")" + String.format("%-" + (22 - tt.Loan_No.length()) + "s", "") + tt.Amount.toString() + "\n";

                    } else
                        data += tt.typename + ":" + String.format("%-" + (22 - tt.typename.length()) + "s", "") + tt.Amount.toString() + "\n";
                }
                data += "--------------------------------\n";
                data += "TOTAL                 " + String.format("%.2f", total) + "\n\n";

                data += "Served by:  " + Myvariables.CurrentAgent.Name + "\n\n\n\n\n";


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

        private void print_image(Bitmap bb) {
            try {
                Bitmap bmp = bb;
                convertBitmap(bmp);
                printerout.write(PrinterCommands.SET_LINE_SPACING_24);

                int offset = 0;
                while (offset < bmp.getHeight()) {
                    printerout.write(PrinterCommands.SELECT_BIT_IMAGE_MODE);
                    for (int x = 0; x < bmp.getWidth(); ++x) {

                        for (int k = 0; k < 3; ++k) {

                            byte slice = 0;
                            for (int b = 0; b < 8; ++b) {
                                int y = (((offset / 8) + k) * 8) + b;
                                int i = (y * bmp.getWidth()) + x;
                                boolean v = false;
                                if (i < dots.length()) {
                                    v = dots.get(i);
                                }
                                slice |= (byte) ((v ? 1 : 0) << (7 - b));
                            }
                            printerout.write(slice);
                        }
                    }
                    offset += 24;
                    printerout.write(PrinterCommands.FEED_LINE);
                    printerout.write(PrinterCommands.FEED_LINE);
                    printerout.write(PrinterCommands.FEED_LINE);
                    printerout.write(PrinterCommands.FEED_LINE);
                    printerout.write(PrinterCommands.FEED_LINE);
                    printerout.write(PrinterCommands.FEED_LINE);
                }
                printerout.write(PrinterCommands.SET_LINE_SPACING_30);


            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }

        int mWidth, mHeight;
        String mStatus;

        public String convertBitmap(Bitmap inputBitmap) {

            mWidth = inputBitmap.getWidth();
            mHeight = inputBitmap.getHeight();

            convertArgbToGrayscale(inputBitmap, mWidth, mHeight);
            mStatus = "ok";
            return mStatus;

        }

        BitSet dots;

        private void convertArgbToGrayscale(Bitmap bmpOriginal, int width,
                                            int height) {
            int pixel;
            int k = 0;
            int B = 0, G = 0, R = 0;
            dots = new BitSet();
            try {

                for (int x = 0; x < height; x++) {
                    for (int y = 0; y < width; y++) {
                        // get one pixel color
                        pixel = bmpOriginal.getPixel(y, x);

                        // retrieve color of all channels
                        R = Color.red(pixel);
                        G = Color.green(pixel);
                        B = Color.blue(pixel);
                        // take conversion up to one single value by calculating
                        // pixel intensity.
                        R = G = B = (int) (0.299 * R + 0.587 * G + 0.114 * B);
                        // set bit into bitset, by calculating the pixel's luma
                        if (R < 55) {
                            dots.set(k);//this is the bitset that i'm printing
                        }
                        k++;

                    }


                }


            } catch (Exception e) {
                // TODO: handle exception
                Log.e("TAG", e.toString());
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

    }
}
