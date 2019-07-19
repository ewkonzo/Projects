package com.example.m_saccoagency;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

import com.example.utils.CheckInternetConnection;
import com.example.utils.Configuration;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.io.IOException;
import java.lang.reflect.Type;
import java.text.SimpleDateFormat;
import java.util.Calendar;

import static com.example.m_saccoagency.AgencyListActivity.btoutputstream;
import static com.example.m_saccoagency.AgencyListActivity.btsocket;
import static com.example.m_saccoagency.AgencyListActivity.trans;

public class AccountActivationActivity extends Activity {
    String accountNo = "", AccName = "", PhoneNo = "", nationalID = "",
            pin = "";
    SharedPreferences sharedpreferences;
    private EditText EtNationalID;
    private TextView TvAccNo, TvAccName;
    private Button BtnCancel, BtnConfirm;
    private String Idchanged;
    private String[] returnedArray;
    private boolean internetConnectionStatus = false;

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.account_activation);
        EtNationalID = (EditText) findViewById(R.id.aatxtnationalid);
        TvAccName = (TextView) findViewById(R.id.aatxtaccountname);
        TvAccNo = (TextView) findViewById(R.id.aatxtaccountno);
        BtnCancel = (Button) findViewById(R.id.aaCancel);
        BtnConfirm = (Button) findViewById(R.id.aaConfirm);
        BtnCancel.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
              finish();
            }
        });
        BtnConfirm.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // TODO Auto-generated method stub
                try
                {
                nationalID = EtNationalID.getText().toString();
                if (nationalID.equals("") || nationalID == null) {
                    EtNationalID.setError(getString(R.string.emptyfield));
                    EtNationalID.requestFocus();
                } else {
                    internetConnectionStatus = new CheckInternetConnection(
                            AccountActivationActivity.this)
                            .isConnectingToInternet();
                    if (internetConnectionStatus) {
                        Idchanged = nationalID;
                        if ((trans.account_1 == null) || (!trans.member_1.id_no.equalsIgnoreCase(nationalID)) || trans.member_1.accounts.size()==0) {

                            Member member = new Member();
                            member.id_no = nationalID;
                            trans.member_1 = member;
                            trans.status = Transaction.Status.Pending;
                            new GetAccounts(trans).execute();
                        } else
                            new Transsync(trans).execute();

                    } else {

                       misc.tost(AccountActivationActivity.this,getString(R.string.nointernet));
                    }
                }

            }
                catch(Exception ex){ex.printStackTrace();}
        }});
    }

    public void DialogBox(String title, String text) {
        try {
            AlertDialog ad = new AlertDialog.Builder(this).create();
            ad.setCancelable(false);
            ad.setTitle(title);
            ad.setMessage(text);
            ad.setButton("OK", new DialogInterface.OnClickListener() {
                public void onClick(final DialogInterface dialog,
                                    final int which) {
                    dialog.dismiss();

                }
            });
            ad.show();
        } catch (Exception e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }

    public void ConfirmationBox(Transaction t) {
        final String ref = t.code;
        LayoutInflater li = LayoutInflater.from(AccountActivationActivity.this);
        View promptsView = li.inflate(R.layout.confirmation_box, null);
        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
                AccountActivationActivity.this);

        alertDialogBuilder.setView(promptsView);
        final TableRow trpin = (TableRow) promptsView.findViewById(R.id.trpin);

        final TextView tvTranType = (TextView) promptsView
                .findViewById(R.id.cbtxttranstype);
        final TextView tvAccNo = (TextView) promptsView
                .findViewById(R.id.cbtxtaccountno);
        final TextView tvAmount = (TextView) promptsView
                .findViewById(R.id.cbmyamount);
        final TextView tvAmount2 = (TextView) promptsView
                .findViewById(R.id.cbtxtamount);
        final EditText EtAC = (EditText) promptsView
                .findViewById(R.id.cbtxtcode);
        final EditText EtAgentPin = (EditText) promptsView
                .findViewById(R.id.cbtxtpin);

        tvTranType.setText(t.transactiontype.toString());
        tvAccNo.setText(t.account_1.Account_No);
        tvAmount2.setText(String.valueOf(t.amount));

        trpin.setVisibility(View.INVISIBLE);
        SharedPreferences preferences = PreferenceManager
                .getDefaultSharedPreferences(this);
        final String storedAgentCode = preferences.getString("agentKey", "");
        Configuration config = new Configuration();
        final String MyagentPin = config.getAgentPin();
        // set dialog message
        alertDialogBuilder
                .setCancelable(false)
                .setTitle("Client Confirmation")
                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int id) {

                    }
                })
                .setNegativeButton("Cancel",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                dialog.cancel();
                            }
                        });
        // create alert dialog
        final AlertDialog adialog = alertDialogBuilder.create();
        adialog.getWindow().setSoftInputMode(
                WindowManager.LayoutParams.SOFT_INPUT_ADJUST_RESIZE);
        adialog.show();

        adialog.getButton(AlertDialog.BUTTON_POSITIVE).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String cnfCode = EtAC.getText().toString().trim();

                if (cnfCode.equalsIgnoreCase(ref)) {
                    // Toast("Correct code");

                    new Transsync(trans).execute();
                    adialog.dismiss();

                } else {
                    // Log.d("AC", cnfCode);
                    EtAC.setError("Incorrect authentication code");
                    EtAC.requestFocus();

                }


            }
        });


    }

    public void ResultsBox(final Transaction t) {

        LayoutInflater li = LayoutInflater.from(AccountActivationActivity.this);
        View promptsView = li.inflate(R.layout.activity_results, null);
        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
                AccountActivationActivity.this);

        alertDialogBuilder.setView(promptsView);
        final TextView txtreference = (TextView) promptsView
                .findViewById(R.id.txtreference);
        final TextView tvTranType = (TextView) promptsView
                .findViewById(R.id.txttranstype);
        final TextView tvAccNo = (TextView) promptsView
                .findViewById(R.id.txtaccountno);
        final TextView tvAmount = (TextView) promptsView
                .findViewById(R.id.txtamount);
        final TextView tvstatus = (TextView) promptsView
                .findViewById(R.id.Info);
        final TextView tverrorinfo = (TextView) promptsView
                .findViewById(R.id.txterrors);

        txtreference.setText(t.reference);
        tvstatus.setText(t.status.toString());
        if (t.status != Transaction.Status.Successful)
            tverrorinfo.setText(t.message);
        tvTranType.setText(t.transactiontype.toString());
        tvAccNo.setText((t.account_1 == null ? "None" : t.account_1.Account_No));
        tvAmount.setText(String.valueOf(t.amount));
        alertDialogBuilder
                .setCancelable(false)
                .setTitle("Transaction Results")
                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        if (t.status == Transaction.Status.Successful) {
                            Calendar c = Calendar.getInstance();
                            System.out.println("Current time => " + c.getTime());

                            SimpleDateFormat df = new SimpleDateFormat("dd-MMM-yyyy");
                            final String formattedDate = df.format(c.getTime());

                            df = new SimpleDateFormat("hh:mm:ss");
                            final String formattedtime = df.format(c.getTime());
                            String head;
                            head  = "     MWALIMU NATIONAL SACCO\n";

                            head  +="       "+ Login.agent.agent_Name.toUpperCase() +"\n";
                            String data = "";
                            data  = "--------------------------------\n";
                            data += "TR. No:   "+ t.reference +"\n";
                            data += "Acc.:     "+ t.account_1.Account_No +"\n";
                            data += "Name:     "+ t.account_1.Account_Name +"\n";
                            data += "Date:     "+ formattedDate +"\n";
                            data += "Time:     "+ formattedtime +"\n";
                            data += "Amount:   "+ t.amount +"\n";
                            data += "TR. type: "+ t.transactiontype.toString() +"\n";
                            data += "--------------------------------\n\n\n";

                            try {
                                try {
                                    Thread.sleep(1000);
                                } catch (InterruptedException e) {
                                    e.printStackTrace();
                                }
                                btoutputstream = btsocket.getOutputStream();
                                byte[] arrayOfByte1 = { 27, 33, 0 };
                                byte[] format = { 27, 33, 0 };

                                btoutputstream.write(format);
                                String msg = head;
                                btoutputstream.write(msg.getBytes());
                                byte[] printformat = { 27, 33, 0 };
                                btoutputstream.write(printformat);
                                msg = data;
                                btoutputstream.write(msg.getBytes());
                                btoutputstream.write(0x0D);
                                btoutputstream.write(0x0D);
                                btoutputstream.write(0x0D);
                                btoutputstream.flush();
                            } catch (IOException e) {
                                e.printStackTrace();
                            }
                            finish();
                        }                   }
                })
        ;
        // create alert dialog
        AlertDialog alertDialog = alertDialogBuilder.create();
        alertDialog.getWindow().setSoftInputMode(
                WindowManager.LayoutParams.SOFT_INPUT_ADJUST_RESIZE);// show it
        alertDialog.show();
    }

    private class GetAccounts extends AsyncTask<Transaction, Void, Transaction> {
        private final ProgressDialog dialog = new ProgressDialog(
                AccountActivationActivity.this);
        private Transaction t;

        GetAccounts(Transaction paramAgent) {
            this.t = paramAgent;
        }

        @Override
        protected void onPreExecute() {
            this.dialog.setMessage("Please wait...");
            //this.dialog.show();
        }

        @Override
        protected Transaction doInBackground(Transaction... params) {
            //
            Transaction results = null;
            String result = null;
            try {
                Gson g = new Gson();
                result = g.toJson(this.t);
                result = JsonParser.SendHttpPost(AccountActivationActivity.this, "Accounts", result,
                        "data");
                Type localType = new TypeToken<Transaction>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
            } catch (Exception e) {
                e.printStackTrace();
            }
            return results;
        }

        @Override
        protected void onPostExecute(Transaction res) {
            try {
                trans = res;
                if (trans.status == Transaction.Status.Failed) {
                    EtNationalID.setText("");
                    EtNationalID.setError(trans.message);
                    EtNationalID.requestFocus(); TvAccNo.setText("");
                    TvAccName.setText("");
                    misc.tost(AccountActivationActivity.this, trans.message);
                } else {
                    switch (trans.member_1.accounts.size()) {
                        case 1:
                            TvAccNo.setText(trans.member_1.accounts.get(0).Account_No);
                            TvAccName.setText(trans.member_1.accounts.get(0).Account_Name);
                            trans.account_1 = trans.member_1.accounts.get(0);

                            break;
                        case 0:
                            TvAccNo.setText("");
                            TvAccName.setText("");
                            EtNationalID.setError(getString(R.string.noactiveaccount));
                            EtNationalID.requestFocus();

                            Toast.makeText(getApplicationContext(), R.string.noactiveaccount, Toast.LENGTH_LONG).show();
                            break;
                        default:
                            SelectAcc(trans.member_1);
                            break;
                    }
                }

            } catch (Exception ex) {

                if (ex.getMessage() == null)
                    ex.printStackTrace();

                else {
                    // DialogBox("errorr.. ", ex.getMessage());
                    Log.i(ex.getMessage(), ex.getMessage());
                }
            }
            //pb.setVisibility(View.INVISIBLE);
        }

        private void SelectAcc(Member paramMember) {
            AlertDialog.Builder localBuilder = new AlertDialog.Builder(AccountActivationActivity.this);
            localBuilder.setTitle("Accounts");
            localBuilder.setMessage("Select Account to use");
            ListView localListView = new ListView(AccountActivationActivity.this);
            localListView.setChoiceMode(1);
            localListView.setAdapter(new BindAccounts(AccountActivationActivity.this, paramMember.accounts));
            localBuilder.setView(localListView);
            localBuilder.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {
                    trans.account_1 = BindAccounts.outdata;
                    if (trans.account_1 != null) {
                        TvAccNo.setText(BindAccounts.outdata.Account_No);
                        TvAccName.setText(BindAccounts.outdata.Account_Name);
                        //new Transsync(trans).execute();
                    }
                }
            });
            localBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {
                    trans.account_1 = null;
                    TvAccNo.setText("");
                    TvAccName.setText("");
                }
            });
            localBuilder.show();
        }

    }

    private class Transsync extends AsyncTask<Transaction, Void, Transaction> {
        private final ProgressDialog dialog = new ProgressDialog(
                AccountActivationActivity.this);
        Transaction t;

        public Transsync(Transaction trans) {
            this.t = trans;
        }

        @Override
        protected void onPreExecute() {
            // Log.d("got here point 2", "yes");
            this.dialog.setMessage("Processing request...");
            this.dialog.show();
        }

        @Override
        protected Transaction doInBackground(Transaction... params) {
            //
            Transaction results = null;
            String result = null;
            try {
                Gson g = new Gson();
                result = g.toJson(this.t);
                result = JsonParser.SendHttpPost(AccountActivationActivity.this, "Transactions", result,
                        "data");
                Type localType = new TypeToken<Transaction>() {
                }.getType();
                results = new Gson().fromJson(result, localType);
            } catch (Exception e) {
                e.printStackTrace();
            }
            return results;

        }

        @Override
        protected void onPostExecute(Transaction res) {
            if (this.dialog.isShowing()) {
                this.dialog.dismiss();
            }
            trans = res;
            misc.debug(trans.status.toString());
            switch (trans.status) {
                case Confirmation: {
                    ConfirmationBox(trans);
                    break;
                }
                case Failed:
                case Successful:
                    ResultsBox(trans);
                    break;


            }
        }
    }

}
