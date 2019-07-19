package com.example.agency;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.SharedPreferences;
import android.os.Handler;
import android.os.ParcelUuid;
import android.util.Log;
import android.widget.Switch;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.lang.reflect.Method;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;
import java.util.UUID;


import static com.example.agency.Summaries.printer.printThread;
import static com.example.agency.Summaries.printer.printerdevice;
import static com.example.agency.Summaries.printer.printerin;
import static com.example.agency.Summaries.printer.printerout;
import static com.example.agency.Summaries.printer.printersock;


/**
 * Created by Paul on 09-Oct-16.
 */

public class Summaries {


    public static class Bydate {
        public String Date;
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
//                            Method m = prnt.getClass().getMethod("createRfcommSocket",
//                                    new Class[]{int.class});
//                            printersock = (BluetoothSocket) m.invoke(prnt, Integer.valueOf(1));
                            try {
                                boolean gotuuid = printerdevice
                                        .fetchUuidsWithSdp();
                                ParcelUuid[] uuids = printerdevice.getUuids();
                                UUID uuid = null;
                                if (uuids != null)
                                    uuid = uuids[0].getUuid();
                                else
                                    uuid = UUID.fromString("fa87c0d0-afac-11de-8a39-0800200c9a66");
                                printersock = printerdevice
                                        .createRfcommSocketToServiceRecord(uuid);

                                Thread.sleep(1000);
                                printersock.connect();
                            } catch (IOException ex) {
                                BluetoothConnector bc;
                                final UUID MY_UUID_SECURE =
                                        UUID.fromString("fa87c0d0-afac-11de-8a39-0800200c9a66");
                                List<UUID> ids = new ArrayList<UUID>();
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

        public void printTransaction(Transaction t) {
            try {
                Calendar c = Calendar.getInstance();
                System.out.println("Current time => " + c.getTime());
                SimpleDateFormat df = new SimpleDateFormat("dd-MMM-yyyy");
                final String formattedDate = df.format(c.getTime());
                df = new SimpleDateFormat("hh:mm:ss");
                final String formattedtime = df.format(c.getTime());

                String head;
                head = "       " + Login.agent.agent_Name.toUpperCase() + "\n";
                String data = "";
                data = "--------------------------------\n";
                data += "TR. No:   " + t.reference + "\n\n";
                data += "Date:     " + formattedDate + "\n\n";
                data += "Time:     " + formattedtime + "\n\n";
                data += "Amount:   " + t.amount + "\n\n";
                data += "TR. type: " + t.transactiontype.toString() + "\n\n";


                switch (t.transactiontype) {
                    default:
                        data += "Acc.:     " + t.account_1.Account_No + "\n\n";
                        data += "Name:     " + t.account_1.Account_Name + "\n\n";
                        break;
                    case Transfer:
                        data += "Acc.:     " + t.account_1.Account_No + "\n\n";
                        data += "Name:     " + t.account_1.Account_Name + "\n\n";
                        data += "     TO \n";
                        data += "Acc.:     " + t.account_2.Account_No + "\n\n";
                        data += "Name:     " + t.account_2.Account_Name + "\n\n";
                        break;
                    case Ministatment:
                        data += "Acc.:     " + t.account_1.Account_No + "\n\n";
                        data += "Name:     " + t.account_1.Account_Name + "\n\n";
                        data += "\n     MINISTATEMENT \n";
                        data += t.message;
                        break;
                    case Balance:
                        data += "Acc.:     " + t.account_1.Account_No + "\n\n";
                        data += "Name:     " + t.account_1.Account_Name + "\n\n";
                        data += "\n     BALANCE \n";
                        data += "Available Balance: " + t.account_1.Account_Balance + "\n";
                        break;
                    case LoanRepayment:
                        data += "Loan type:     " + t.loan_no.Loan_Type_Name + "\n\n";
                        data += "Loan No:     " + t.loan_no.Loan_No + "\n\n";
                        break;
                }
                data += "--------------------------------\n\n\n";



                try {
                    try {
                        Thread.sleep(1000);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
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
                } catch (IOException e) {
                    e.printStackTrace();
                }
            } catch (Exception e) {
                e.printStackTrace();
            }


        }
    }
}
