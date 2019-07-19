package com.example.agency;

import com.example.utils.CheckInternetConnection;
import com.example.utils.Configuration;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
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
import android.widget.TextView;

import java.lang.reflect.Type;
import java.text.SimpleDateFormat;
import java.util.Calendar;

import static com.example.agency.AgencyListActivity.p;
import static com.example.agency.AgencyListActivity.trans;

public class CashDeposit extends Activity  {
	private Button BtnCancel, BtnConfirm;

	private EditText EtAccountNo, EtAmount,EtDepositorName, EtTelephoneNo;
	private TextView tvAccountName;
	private boolean internetConnectionStatus = false;
	private String[] balEnquiryArray;
	String PhoneNo = "";
	String  AccountNo;
	String MemberPhoneNo = "", MemberAccountNo = "", AccName = "", DepositAmount = "";
	String nationalID = "";

	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.cash_deposit);
		EtAccountNo = (EditText)findViewById(R.id.cdtxtaccno);
		EtAmount = (EditText)findViewById(R.id.cdtxtamount);
		EtDepositorName = (EditText)findViewById(R.id.cdtxtdepositor);
		EtTelephoneNo = (EditText)findViewById(R.id.cdtxttelephone);
		tvAccountName = (TextView)findViewById(R.id.cdtxtaccountname);

		BtnConfirm = (Button)findViewById(R.id.cdBtnConfirm);
		BtnCancel = (Button)findViewById(R.id.cdBtnCancel);

		EtAccountNo.setOnFocusChangeListener(new View.OnFocusChangeListener() {

			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				// TODO Auto-generated method
				if (!hasFocus) {
					String accNo = EtAccountNo.getText().toString();
					if (accNo.equals("") || accNo == null) {
						EtAccountNo.setError(getString(R.string.emptyfield));
					} else {
						internetConnectionStatus = new CheckInternetConnection(
								CashDeposit.this).isConnectingToInternet();
						if (internetConnectionStatus) {
							com.example.agency.Account acc = new com.example.agency.Account();
							acc.Account_No= accNo;
													trans.account_1= acc;

							new GetAccounts(trans)
									.execute();
						} else {
							DialogBox("Internet Connection",
									"Sorry you have no internet connection");
						}
					}
				}
			}
		});
		BtnConfirm.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				String AccNo = EtAccountNo.getText().toString();
				String Amount = EtAmount.getText().toString();
				String Depositor = EtDepositorName.getText().toString();
				String TelNo = EtTelephoneNo.getText().toString();
				if ((trans!=null) && (trans.account_1!= null )&& (AccNo.equals(trans.account_1.Account_No))) {
					if(AccNo.equals("")|| AccNo == null){
					EtAccountNo.setError("Field cannot be null");
				} else if(Amount.equals("")|| Amount == null){
					EtAmount.setError("Field cannot be null");
				}else if(Depositor.equals("")|| Depositor == null){
					EtDepositorName.setError("Field cannot be null");
				} else if(TelNo.equals("")||TelNo == null){
					EtTelephoneNo.setError("Field cannot be null");
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							CashDeposit.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						trans.status= Transaction.Status.Pending;
						trans.amount = Double.valueOf(Amount).doubleValue();
						trans.Telephone_No = TelNo;
						trans.Depositor_Name = Depositor;
						new Transsync(trans).execute();

					} else {

						DialogBox("Internet Connection",
								"Sorry you have no internet connection");
					}
				}}else
					EtAccountNo.clearFocus();
			}
		});
		BtnCancel.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
		finish();
			}
		});

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
	private class GetAccounts extends AsyncTask<Transaction, Void, Transaction> {
		private final ProgressDialog dialog = new ProgressDialog(
				CashDeposit.this);
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
				result = JsonParser.SendHttpPost(CashDeposit.this, "Accounts", result,
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
					tvAccountName.setText("");	EtAccountNo.setText("");
					EtAccountNo.setError(trans.message);
					EtAccountNo.requestFocus();
					misc.tost(CashDeposit.this, trans.message);
				} else {
					if (trans.account_1 != null) {
						if (trans.account_1.Account_ok){
						tvAccountName.setText(trans.account_1.Account_Name);

					} else {
							tvAccountName.setText("");
							EtAccountNo.setError(trans.account_1.Message);
							EtAccountNo.requestFocus();
							misc.tost(CashDeposit.this,trans.account_1.Message);

						}
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


	}
	private class Transsync extends AsyncTask<Transaction, Void, Transaction> {
		private final ProgressDialog dialog = new ProgressDialog(
				CashDeposit.this);
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
				result = JsonParser.SendHttpPost(CashDeposit.this, "Transactions", result,
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
					try{
						DB db = new DB(CashDeposit. this);
						Calendar cdt = Calendar.getInstance();
						SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
						final String formattedDate = df.format(cdt.getTime());
						df = new SimpleDateFormat("HH:mm:ss");
						final String formattedtime = df.format(cdt.getTime());
						trans.Date = formattedDate;
						trans.Time = formattedtime;
						trans.Name = trans.account_1.Account_Name;
						db.insertTransaction(trans);}
					catch   (Exception ex){
						ex.printStackTrace();

					}
					ResultsBox(trans);
					break;


			}
		}
	}
	public void ConfirmationBox(Transaction t) {
		final String ref = t.code;
		LayoutInflater li = LayoutInflater.from(CashDeposit.this);
		View promptsView = li.inflate(R.layout.confirmation_box, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				CashDeposit.this);

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
		tvAccNo.setText(t.account_1.Account_No);
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

		LayoutInflater li = LayoutInflater.from(CashDeposit.this);
		View promptsView = li.inflate(R.layout.activity_results, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				CashDeposit.this);

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
						{p.printTransaction(t);
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
