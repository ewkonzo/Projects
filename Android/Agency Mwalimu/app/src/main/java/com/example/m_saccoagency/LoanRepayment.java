package com.example.m_saccoagency;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;
import com.example.utils.CheckInternetConnection;
import com.example.utils.Configuration;
import com.example.utils.SendSms;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

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
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.io.IOException;
import java.lang.reflect.Type;
import java.text.SimpleDateFormat;
import java.util.Calendar;

import static com.example.m_saccoagency.AgencyListActivity.btoutputstream;
import static com.example.m_saccoagency.AgencyListActivity.btsocket;
import static com.example.m_saccoagency.AgencyListActivity.trans;

public class LoanRepayment extends Activity {
	private EditText EtNationalId, EtAmount;
	private TextView TvLoanNo, TvLoantype;
	private Button BtnCancel, BtnConfirm;
	private static String SOAP_ADDRESS = "";
	private boolean internetConnectionStatus = false;
	String PhoneNo = "", IdNo = "", LoanNo = "", LoanType = "", Amount="";
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.loan_repayment);
		
		EtNationalId = (EditText)findViewById(R.id.lptxtnationalid);
		EtAmount = (EditText)findViewById(R.id.lptxtamount);
		TvLoanNo = (TextView)findViewById(R.id.lptxtloanno);
		TvLoantype = (TextView)findViewById(R.id.lptxtloantype);
		
		BtnCancel = (Button)findViewById(R.id.lpCancel);
		BtnConfirm = (Button)findViewById(R.id.lpConfirm);
		SOAP_ADDRESS = Configuration.getURL();
		EtNationalId.setOnFocusChangeListener(new View.OnFocusChangeListener() {
			
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				// TODO Auto-generated method stub
				if (!hasFocus){
				String nationalID = EtNationalId.getText().toString();
				if (nationalID.equals("") || nationalID == null) {
					// EtNationalID.setError("Field cannot be null");
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							LoanRepayment.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						Member	member = new Member();
						member.id_no = nationalID;
						trans.member_1 = member;
						trans.status = Transaction.Status.Pending;
						new GetAccounts(trans).execute();

					} else {
						misc.tost(LoanRepayment.this,"Sorry you have no internet connection");
					}
				}
				}

			}
		});
		
		BtnConfirm.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				String NationalId = EtNationalId.getText().toString();
				Amount = EtAmount.getText().toString();
				if ((trans!=null) && (trans.member_1!= null )&& (NationalId.equals(trans.member_1.id_no))) {

					if(NationalId.equals("") || NationalId == null){
					EtNationalId.setError(getString(R.string.emptyfield));
					EtNationalId.requestFocus();
				} else if(Amount.equals("")|| Amount == null){
					EtAmount.setError(getString(R.string.emptyfield));
					EtAmount.requestFocus();
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							LoanRepayment.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						trans.status = Transaction.Status.Pending;
						trans.amount = Double.parseDouble(Amount);
						new Transsync(trans).execute();
					} else {

						misc.tost(LoanRepayment.this, getString(R.string.nointernet));
					}
				}
			}else
			EtNationalId.clearFocus();}
		});
		BtnCancel.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
	finish();
			}
		});

	}
	private class GetAccounts extends AsyncTask<Transaction, Void, Transaction> {
		private final ProgressDialog dialog = new ProgressDialog(
				LoanRepayment.this);
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
				result = JsonParser.SendHttpPost(LoanRepayment.this, "Accounts", result,
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
					EtNationalId.setText("");
					EtNationalId.setError(trans.message);
					EtNationalId.requestFocus();TvLoanNo.setText("");
					TvLoantype.setText("");
					misc.tost(LoanRepayment.this, trans.message);
				} else {
					switch (trans.member_1.loans.size()) {
						case 1:
							TvLoanNo.setText(trans.member_1.loans.get(0).Loan_No);
							TvLoantype.setText(trans.member_1.loans.get(0).Loan_Type);
							trans.account_1 = trans.member_1.accounts.get(0);
							trans.loan_no= trans.member_1.loans.get(0);
							break;
						case 0:
							TvLoanNo.setText("");
							TvLoantype.setText("");
							EtNationalId.setError(getString(R.string.noloans));
							misc.tost(LoanRepayment.this, getString(R.string.noloans));
							break;
						default:
							Selectloan(trans.member_1);
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
		private void Selectloan(Member paramMember) {
			AlertDialog.Builder localBuilder = new AlertDialog.Builder(LoanRepayment.this);
			localBuilder.setTitle("Accounts");
			localBuilder.setMessage("Select Account to use");
			ListView localListView = new ListView(LoanRepayment.this);
			localListView.setChoiceMode(1);
			localListView.setAdapter(new BindLoans(LoanRepayment.this, paramMember.loans));
			localBuilder.setView(localListView);
			localBuilder.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {
					trans.loan_no = BindLoans.outdata;
					if (trans.loan_no != null) {
						TvLoanNo.setText(BindLoans.outdata.Loan_No);
						TvLoantype.setText(BindLoans.outdata.Loan_Type);

					}
				}
			});
			localBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {
					trans.account_1 = null;
					TvLoanNo.setText("");
					TvLoantype.setText("");
				}
			});
			localBuilder.show();
		}

	}
	private class Transsync extends AsyncTask<Transaction, Void, Transaction> {
		private final ProgressDialog dialog = new ProgressDialog(
				LoanRepayment.this);
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
				result = JsonParser.SendHttpPost(LoanRepayment.this, "Transactions", result,
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
	public void ConfirmationBox(Transaction t) {
		final String ref = t.code;
		LayoutInflater li = LayoutInflater.from(LoanRepayment.this);
		View promptsView = li.inflate(R.layout.confirmation_box, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				LoanRepayment.this);

		alertDialogBuilder.setView(promptsView);
		final LinearLayout confirmlayout ;
		confirmlayout = (LinearLayout)promptsView
				.findViewById(R.id.confirmlayout);
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
		tvAccNo.setText(t.loan_no.Loan_No);
		tvAmount2.setText(String.valueOf(t.amount));
		confirmlayout.setVisibility(View.INVISIBLE);
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

			/*	String cnfCode = EtAC.getText().toString().trim();
				String agentPin = EtAgentPin.getText().toString()
						.trim();
				misc.debug(ref);
				misc.debug(cnfCode);
				if (cnfCode.equalsIgnoreCase(ref)) {
					// Toast("Correct code");
					misc.debug("here");
					if (trans.member_1.pin.equals(agentPin)) {
						misc.debug("here");
						new Transsync(trans).execute();
						adialog.dismiss();
					} else {
						EtAgentPin.setError("Incorect customer Pin ");
					}
				} else {
					// Log.d("AC", cnfCode);
					EtAC.setError("Incorrect authentication code");

				}*/
				new Transsync(trans).execute();
				adialog.dismiss();


				//else dialog stays open. Make sure you have an obvious way to close the dialog especially if you set cancellable to false.
			}
		});


	}
	public void ResultsBox(final Transaction t) {

		LayoutInflater li = LayoutInflater.from(LoanRepayment.this);
		View promptsView = li.inflate(R.layout.activity_results, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				LoanRepayment.this);

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
						{	try {Calendar c = Calendar.getInstance();
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
							data += "Loan:     "+ t.loan_no.Loan_No +"\n";
							data += "Date:     "+ formattedDate +"\n";
							data += "Time:     "+ formattedtime +"\n";
							data += "Amount:   "+ t.amount +"\n";
							data += "TR. type: "+ t.transactiontype.toString() +"\n";
							data += "--------------------------------\n\n\n";


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

							finish();}
					}
				})
		;
		// create alert dialog
		AlertDialog alertDialog = alertDialogBuilder.create();
		alertDialog.getWindow().setSoftInputMode(
				WindowManager.LayoutParams.SOFT_INPUT_ADJUST_RESIZE);// show it
		alertDialog.show();
	}
	
}
