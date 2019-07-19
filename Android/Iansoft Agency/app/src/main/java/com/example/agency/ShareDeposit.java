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
import android.widget.ListView;
import android.widget.TextView;

import java.lang.reflect.Type;
import java.text.SimpleDateFormat;
import java.util.Calendar;

import static com.example.agency.AgencyListActivity.*;

public class ShareDeposit extends Activity {

	private EditText EtNationaID, EtAmount;
	private TextView tvAccNo, tvAccName;
	private Button btnCancel, btnConfirm;

	String accountNo = "", PhoneNo = "", AccName = "",nationalID = "", amount="" ;
	private boolean internetConnectionStatus = false;

	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.share_deposit);

		EtNationaID = (EditText) findViewById(R.id.sdtxtnationalid);
		EtAmount = (EditText) findViewById(R.id.sdtxtamount);
		tvAccNo = (TextView) findViewById(R.id.sdtxtaccountno);
		tvAccName = (TextView) findViewById(R.id.sdtxtaccountname);
		btnConfirm = (Button) findViewById(R.id.sdConfirm);
		btnCancel = (Button) findViewById(R.id.sdCancel);

		EtNationaID.setOnFocusChangeListener(new View.OnFocusChangeListener() {

			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				// TODO Auto-generated method stub
				if (!hasFocus){
				String nationalID = EtNationaID.getText().toString();
				if (nationalID.equals("") || nationalID == null) {
					// EtNationalID.setError("Field cannot be null");
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							ShareDeposit.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						Member member = new Member();
						member.id_no = nationalID;
						trans.member_1 = member;
						trans.status = Transaction.Status.Pending;

						new GetAccounts(trans).execute();

					} else {

					misc.tost(ShareDeposit.this	,getString(R.string.nointernet));
					}
				}
			}}
		});

		btnConfirm.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				 nationalID = EtNationaID.getText().toString().trim();
				 amount = EtAmount.getText().toString().trim();
				if ((trans!=null) && (trans.member_1!= null )&& (nationalID.equals(trans.member_1.id_no))) {
					if (nationalID.equals("") || nationalID == null) {
					EtNationaID.setError(getString(R.string.emptyfield));
					EtNationaID.requestFocus();
				} else if (amount.equals("") || amount == null) {
					EtAmount.setError(getString(R.string.emptyfield));
					EtAmount.requestFocus();
					} else {
					internetConnectionStatus = new CheckInternetConnection(
							ShareDeposit.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						trans.amount = Double.parseDouble(amount);
						trans.status= Transaction.Status.Pending;
						new Transsync(trans).execute();
					} else {

						misc.tost(ShareDeposit.this, getString(R.string.nointernet));
					}
				}
			}else
			EtNationaID.clearFocus();}
		});

		btnCancel.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
		finish();
			}
		});
	}
	private class GetAccounts extends AsyncTask<Transaction, Void, Transaction> {
		private final ProgressDialog dialog = new ProgressDialog(
				ShareDeposit.this);
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
				result = JsonParser.SendHttpPost(ShareDeposit.this, "Accounts", result,
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
					EtNationaID.setText("");
					EtNationaID.setError(trans.message);
					EtNationaID.requestFocus();	tvAccNo.setText("");
					tvAccName.setText("");
					misc.tost(ShareDeposit.this, trans.message);
				} else {
					switch (trans.member_1.accounts.size()) {
						case 1:
							tvAccNo.setText(trans.member_1.accounts.get(0).Account_No);
							tvAccName.setText(trans.member_1.accounts.get(0).Account_Name);
							trans.account_1 = trans.member_1.accounts.get(0);
							break;
						case 0:
							tvAccNo.setText("");
							tvAccName.setText("");
							EtNationaID.setError(getString(R.string.noactiveaccount));
							tvAccNo.setText("");
							tvAccName.setText("");
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

		}
		private void SelectAcc(Member paramMember) {
			AlertDialog.Builder localBuilder = new AlertDialog.Builder(ShareDeposit.this);
			localBuilder.setTitle("Accounts");
			localBuilder.setMessage("Select Account to use");
			ListView localListView = new ListView(ShareDeposit.this);
			localListView.setChoiceMode(1);
			localListView.setAdapter(new BindAccounts(ShareDeposit.this, paramMember.accounts));
			localBuilder.setView(localListView);
			localBuilder.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {
					trans.account_1 = BindAccounts.outdata;
					if (trans.account_1 != null) {
						tvAccNo.setText(BindAccounts.outdata.Account_No);
						tvAccName.setText(BindAccounts.outdata.Account_Name);

					}
				}
			});
			localBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {
					trans.account_1 = null;
					tvAccNo.setText("");
					tvAccName.setText("");
				}
			});
			localBuilder.show();
		}

	}
	private class Transsync extends AsyncTask<Transaction, Void, Transaction> {
		private final ProgressDialog dialog = new ProgressDialog(
				ShareDeposit.this);
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
				result = JsonParser.SendHttpPost(ShareDeposit.this, "Transactions", result,
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
						DB db = new DB(ShareDeposit. this);
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
		LayoutInflater li = LayoutInflater.from(ShareDeposit.this);
		View promptsView = li.inflate(R.layout.confirmation_box, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				ShareDeposit.this);

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

		LayoutInflater li = LayoutInflater.from(ShareDeposit.this);
		View promptsView = li.inflate(R.layout.activity_results, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				ShareDeposit.this);

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
						{
							p.printTransaction(t);
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