package com.example.m_saccoagency;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.bluetooth.BluetoothSocket;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.io.IOException;
import java.io.OutputStream;
import java.lang.reflect.Type;

public class AgencyListActivity extends Activity {
    public static Transaction trans;
    byte FONT_TYPE;
    public static BluetoothSocket btsocket;
    public static OutputStream btoutputstream;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_agency_list);
        final ListView AgencyListView = (ListView) findViewById(R.id.AgencyList);
       final ListAdapter c = new BindMenu(this, com.example.m_saccoagency.Menu.ITEMS);
connect();
        AgencyListView.setAdapter(c);
        AgencyListView.setOnItemClickListener(new OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
                try {
                    trans = new Transaction();
                    trans.status = Transaction.Status.Pending;
                    trans.agent = Login.agent;
                    Intent intent = null;
                     switch (position) {

                        case 0:   trans.transactiontype = Transaction.Transtype.MemberRegistration;
                            intent = new Intent(AgencyListActivity.this,
                                    MemberRegistration.class);
                            break;


                        case 1:
                            trans.transactiontype = Transaction.Transtype.Share_Variation;
                            intent = new Intent(AgencyListActivity.this,
                                    Sharevariation.class);

                            break;
                        case 2:
                            trans.transactiontype = Transaction.Transtype.Memberactivation;
                            intent = new Intent(AgencyListActivity.this, AccountActivationActivity.class);
                            break;


                        case 3:
                            trans.transactiontype = Transaction.Transtype.Registration;
                            intent = new Intent(AgencyListActivity.this,
                                    AccountOpening.class);
                            misc.cactivity = AccountOpening.class;
                            break;

                        case 4:
                            trans.transactiontype = Transaction.Transtype.Withdrawal;
                            intent = new Intent(AgencyListActivity.this,
                                    CashWithdraw.class);
                            break;

                        case 5:  trans.transactiontype = Transaction.Transtype.Deposit;
                            intent = new Intent(AgencyListActivity.this,
                                    CashDeposit.class);
                            break;

                        case 6: trans.transactiontype = Transaction.Transtype.LoanRepayment;
                            intent = new Intent(AgencyListActivity.this,
                                    LoanRepayment.class);
                            break;

                        case 7: trans.transactiontype = Transaction.Transtype.Loan_Applications;
                            intent = new Intent(AgencyListActivity.this,
                                    loanapplication.class);
                            break;

                        case 8: trans.transactiontype = Transaction.Transtype.Transfer;
                            intent = new Intent(AgencyListActivity.this,
                                    CashTransfer.class);
                            break;

                        case 9: trans.transactiontype = Transaction.Transtype.Sharedeposit;
                            intent = new Intent(AgencyListActivity.this,
                                    ShareDeposit.class);
                            break;

                        case 10:  trans.transactiontype = Transaction.Transtype.Balance;
                            intent = new Intent(AgencyListActivity.this,
                                    BalanceEnquiry.class);
                            break;

                        case 11:
                            trans.transactiontype = Transaction.Transtype.Ministatment;
                            intent = new Intent(AgencyListActivity.this,
                                    Ministatement.class);
                            break;

                        case 12:
                            trans.transactiontype = Transaction.Transtype.Changepin;
                            intent = new Intent(AgencyListActivity.this,
                                    ChangeClientPin.class);
                            break;
                        // add more if you have more items in listview
                        // 0 is the first item 1 second and so on...
                    }
                    startActivity(intent);
                } catch (Exception ex) {
                    ex.printStackTrace();
                    misc.tost(AgencyListActivity.this, "Unable to complete the transaction");
                }
            }
        });
    }

    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_two, menu);
        return true;
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
                                System.exit(0);

                            }

                        }).setNegativeButton("No", null).show();
    }

    public boolean onOptionsItemSelected(MenuItem item) {


        switch (item.getItemId()) {

            case R.id.change_password:
                loadChangePinPrompt();
                break;
            case R.id.log_out:
                finish();
                break;
            case R.id.Settings:
               Intent intent = new Intent(this,Settings.class);
                startActivity(intent);
                break;

        }

        return true;
    }

    public void loadChangePinPrompt() {
        LayoutInflater li = LayoutInflater.from(AgencyListActivity.this);
        View promptsView = li.inflate(R.layout.prompts_change_pin, null);
        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
                AgencyListActivity.this);

        alertDialogBuilder.setView(promptsView);

        final EditText EtCurrentPin = (EditText) promptsView
                .findViewById(R.id.txtcpin);
        final EditText EtNewPin = (EditText) promptsView
                .findViewById(R.id.txtnpin);
        final EditText EtConfirmNewPin = (EditText) promptsView
                .findViewById(R.id.txtconpin);

        // set dialog message
        alertDialogBuilder
                .setCancelable(false)
                .setTitle("Change Client Pin")
                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        // get user input and set it to result
                        // edit text

                    }
                })
                .setNegativeButton("Cancel",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                dialog.cancel();
                            }
                        });

        // create alert dialog
        AlertDialog alertDialog = alertDialogBuilder.create();

        // show it
        alertDialog.show();
        alertDialog.getButton(AlertDialog.BUTTON_POSITIVE).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String currentpin = EtCurrentPin.getText().toString();
                String newPin = EtNewPin.getText().toString();
                String cpin = EtConfirmNewPin.getText().toString();
                if (currentpin.equals("") || currentpin == null) {
                    EtCurrentPin.setError(getString(R.string.emptyfield));
                    EtCurrentPin.requestFocus();
                } else if (newPin.equals("") || newPin == null) {
                    EtNewPin.setError(getString(R.string.emptyfield));
                    EtNewPin.requestFocus();
                } else if (cpin.equals("") || cpin == null) {
                    EtConfirmNewPin.setError(getString(R.string.emptyfield));
                    EtConfirmNewPin.requestFocus();
                } else if (!Login.agent.pin.equals(currentpin)) {
                    EtCurrentPin.setError("Invalid current pin");
                    EtCurrentPin.requestFocus();
                } else if (!newPin.equals(cpin)) {
                    EtConfirmNewPin.setError("Invalid pin confirmation");
                    EtConfirmNewPin.requestFocus();
                } else {
                    Login.agent.new_pin = newPin;
                    new UserLoginTask(Login.agent).execute();
                }
                //else dialog stays open. Make sure you have an obvious way to close the dialog especially if you set cancellable to false.
            }
        });
    }
    public void Toast(String message) {

        Toast.makeText(getApplicationContext(), message, Toast.LENGTH_LONG)
                .show();

    }

    public class UserLoginTask extends AsyncTask<Agent, Void, Agent> {
        private final ProgressDialog dialog = new ProgressDialog(AgencyListActivity.this);
        private Agent magent;

        UserLoginTask(Agent paramAgent) {
            this.magent = paramAgent;
        }

        protected void onPreExecute() {
            this.dialog.setMessage("Signing in...");
            this.dialog.show();
        }

        @Override
        protected Agent doInBackground(Agent... params) {
            try {
                String myagent;
                Gson g = new Gson();
                Login.agent.message = null;
                myagent = g.toJson(this.magent);
                myagent = JsonParser.SendHttpPost(AgencyListActivity.this, "Changepass", myagent,
                        "login");

                Log.d("Agent Json", myagent);

                Type localType = new TypeToken<Agent>() {
                }.getType();
                this.magent = ((Agent) new Gson().fromJson(myagent, localType));

            } catch (Exception ex) {
                Log.e("Error.... sd", ex.toString());
                // ex.printStackTrace();
                if (!ex.getMessage().contains("Connection to")) {
                    this.magent.message = "No Connection, make sure that your mobile data is enabled, or you are on a wifi.";
                }

            }

            return magent;

        }

        protected void onPostExecute(Agent magent) {

            if (this.dialog.isShowing()) {
                this.dialog.dismiss();
            }
            try {
                if (magent.logged_in) {
                    misc.tost(AgencyListActivity.this, "Pin successfully changed");

                } else
                    misc.tost(AgencyListActivity.this, "Unable to change your pin");


            } catch (Exception ex) {
                ex.printStackTrace();

            }
        }

    }

    protected void connect() {
        if(btsocket == null){
            Intent BTIntent = new Intent(getApplicationContext(), BTDeviceList.class);
            this.startActivityForResult(BTIntent, BTDeviceList.REQUEST_CONNECT_BT);
        }
        else{

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
    protected void onDestroy() {
        super.onDestroy();
        try {
            if(btsocket!= null){
                btoutputstream.close();
                btsocket.close();
                btsocket = null;
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        try {
            btsocket = BTDeviceList.getSocket();
            if(btsocket != null){

            }

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
