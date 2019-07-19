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
import android.widget.AbsListView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.example.utils.CheckInternetConnection;
import com.example.utils.Configuration;
import com.example.utils.SendSms;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import java.lang.reflect.Type;

import static com.example.m_saccoagency.AgencyListActivity.trans;

public class CashWithdraw extends Activity {
    Member member = null;
    String PhoneNo = "", AccountNo, AcctBal;
    String MemberPhoneNo = "", MemberAccountNo = "", AccName = "", WithdrawAmount = "";
    String nationalID = "";
    ProgressBar pb;
    private EditText EtNationalID, EtAmount;
    private TextView tvAccountNo, tvAccountName, tvAccountBal;
    private Button BtnCancel;
    private Button BtnConfirm;
    private boolean internetConnectionStatus = false;
    private String[] balEnquiryArray;

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cash_withdraw);

        member = new Member();
        pb = (ProgressBar) findViewById(R.id.paccdetails);
        EtNationalID = (EditText) findViewById(R.id.cwtxtnationalid);
        EtAmount = (EditText) findViewById(R.id.cwtxtamount);
        tvAccountNo = (TextView) findViewById(R.id.cwtxtaccountno);
        tvAccountName = (TextView) findViewById(R.id.cwtxtaccountname);
        tvAccountBal = (TextView) findViewById(R.id.cwAccountBalance);


        BtnCancel = (Button) findViewById(R.id.cwBtnCancel);
        BtnConfirm = (Button) findViewById(R.id.cwBtnConfirm);


        EtNationalID.setOnFocusChangeListener(new View.OnFocusChangeListener() {

            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    String nationalID = EtNationalID.getText().toString();
                    if (nationalID.equals("") || nationalID == null) {
                        EtNationalID.setError("Field cannot be null");
                    } else {
                        internetConnectionStatus = new CheckInternetConnection(
                                CashWithdraw.this).isConnectingToInternet();
                        if (internetConnectionStatus) {
                            member.id_no = nationalID;
                            trans.member_1 = member;
                            trans.status = Transaction.Status.Pending;
                            pb.setVisibility(View.VISIBLE);
                            new GetAccounts(trans).execute();
                        } else {
                            Toast.makeText(getApplicationContext(), "Sorry you have no internet connection", Toast.LENGTH_LONG).show();
                        }
                    }
                }
            }
        });
        BtnConfirm.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                // TODO Auto-generated method stub
                nationalID = EtNationalID.getText().toString();
                misc.debug( nationalID);
                double Amount = Double.parseDouble(EtAmount.getText().toString());
                          misc.debug( trans.member_1.id_no);
               if ((trans!=null) && (trans.member_1!= null )&& (nationalID.equals(trans.member_1.id_no))) {
                    if (nationalID.equals("") || nationalID == null) {
                        EtNationalID.setError(getString(R.string.emptyfield));
                        EtNationalID.requestFocus();
                    } else if (Amount < 1) {
                        EtAmount.setError(getString(R.string.emptyfield));
                        EtAmount.requestFocus();
                    } else {
                        internetConnectionStatus = new CheckInternetConnection(
                                CashWithdraw.this).isConnectingToInternet();
                        if (internetConnectionStatus) {
                            trans.amount = Amount;
                            trans.status = Transaction.Status.Pending;
                            new WithdrawCash(trans).execute();
                        } else {
                            misc.tost(CashWithdraw.this, getString(R.string.nointernet));
                        }
                    }
                }else
                   EtNationalID .clearFocus();
            }
        });

        BtnCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // TODO Auto-generated method stub
                finish();            }
        });
    }
    public void ConfirmationBox(Transaction t) {
        final String ref = t.code;
        LayoutInflater li = LayoutInflater.from(CashWithdraw.this);
        View promptsView = li.inflate(R.layout.confirmation_box, null);
        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
                CashWithdraw.this);

        alertDialogBuilder.setView(promptsView);

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
        /*
		 * tvAmount.setVisibility(View.GONE);
		 * tvAmount2.setVisibility(View.INVISIBLE);
		 */
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
        final AlertDialog adialog = alertDialogBuilder.create();
        adialog.getWindow().setSoftInputMode(
                WindowManager.LayoutParams.SOFT_INPUT_ADJUST_RESIZE);
        adialog.show();

        adialog.getButton(AlertDialog.BUTTON_POSITIVE).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String cnfCode = EtAC.getText().toString().trim();
                String agentPin = EtAgentPin.getText().toString()
                        .trim();
                misc.debug(ref);
                misc.debug(cnfCode);
                if (cnfCode.equalsIgnoreCase(ref)) {
                    // Toast("Correct code");
                    misc.debug("here");
                    if (trans.member_1.pin.equals(agentPin)) {
                        misc.debug("here");
                        new WithdrawCash(trans).execute();
                        adialog.dismiss();
                    } else {
                        EtAgentPin.setError("Incorect customer Pin ");
                        EtAgentPin.requestFocus();
                    }
                } else {
                    // Log.d("AC", cnfCode);
                    EtAC.setError("Incorrect authentication code");
                    EtAC.requestFocus();

                }


                //else dialog stays open. Make sure you have an obvious way to close the dialog especially if you set cancellable to false.
            }
        });


    }
    public void ResultsBox(final Transaction t) {
        LayoutInflater li = LayoutInflater.from(CashWithdraw.this);
        View promptsView = li.inflate(R.layout.activity_results, null);
        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
                CashWithdraw.this);
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
                        if (t.status == Transaction.Status.Successful)
                            finish();
                    }
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
                CashWithdraw.this);
        private Transaction t;

        GetAccounts(Transaction paramAgent) {
            this.t = paramAgent;
        }

        @Override
        protected void onPreExecute() {
            // Log.d("got here point 2", "yes");
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
                result = JsonParser.SendHttpPost(CashWithdraw.this, "Accounts", result,
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
                    EtNationalID.setError(trans.message);  tvAccountNo.setText("");
                    tvAccountName.setText("");
                    EtNationalID.requestFocus(); tvAccountNo.setText("");
                    tvAccountName.setText("");

                } else {
                    switch (trans.member_1.accounts.size()) {
                        case 1:
                            tvAccountNo.setText(trans.member_1.accounts.get(0).Account_No);
                            tvAccountName.setText(trans.member_1.accounts.get(0).Account_Name);
                            trans.account_1 = trans.member_1.accounts.get(0);
                            break;
                        case 0:
                            tvAccountNo.setText("");
                            tvAccountName.setText("");
                            EtNationalID.setError(getString(R.string.noactiveaccount));
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
            pb.setVisibility(View.INVISIBLE);
        }

        private void SelectAcc(Member paramMember) {
            AlertDialog.Builder localBuilder = new AlertDialog.Builder(CashWithdraw.this);
            localBuilder.setTitle("Accounts");
            localBuilder.setMessage("Select Account to use");
            ListView localListView = new ListView(CashWithdraw.this);
            localListView.setChoiceMode(AbsListView.CHOICE_MODE_SINGLE);
            localListView.setAdapter(new BindAccounts(CashWithdraw.this, paramMember.accounts));
            localBuilder.setView(localListView);
            localBuilder.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {
                    trans.account_1 = BindAccounts.outdata;
                    if (trans.account_1 != null) {
                        tvAccountNo.setText(BindAccounts.outdata.Account_No);
                        tvAccountName.setText(BindAccounts.outdata.Account_Name);

                    }
                }
            });
            localBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {
                    trans.account_1 = null;
                    tvAccountNo.setText("");
                    tvAccountName.setText("");
                }
            });
            localBuilder.show();
        }
    }
    private class WithdrawCash extends AsyncTask<Transaction, Void, Transaction> {
        private final ProgressDialog dialog = new ProgressDialog(
                CashWithdraw.this);
        Transaction t;

        public WithdrawCash(Transaction trans) {
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
                result = JsonParser.SendHttpPost(CashWithdraw.this, "Transactions", result,
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
