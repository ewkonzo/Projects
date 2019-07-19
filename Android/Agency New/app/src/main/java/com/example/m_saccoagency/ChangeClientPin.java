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
import android.widget.TextView;
import android.widget.Toast;

import com.example.utils.CheckInternetConnection;
import com.example.utils.Configuration;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;

import static com.example.m_saccoagency.AgencyListActivity.trans;

public class ChangeClientPin extends Activity {
	private EditText EtNationalID, EtCurrentPin, EtNewPin, EtConfirmNewPin;
	private Button BtnCancel, BtnConfirm;
	private boolean internetConnectionStatus = false;
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.change_client_pin);
		
		EtNationalID = (EditText)findViewById(R.id.cptxtnationalid);
		EtCurrentPin = (EditText)findViewById(R.id.cptxtcpin);
		EtNewPin = (EditText)findViewById(R.id.cptxtnpin);
		EtConfirmNewPin = (EditText)findViewById(R.id.cptxtconpin);
		
		BtnCancel = (Button)findViewById(R.id.cpCancel);
		BtnConfirm = (Button)findViewById(R.id.cpConfirm);
		
		BtnCancel.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				finish();
			}
		});
		EtNationalID.setOnFocusChangeListener(new View.OnFocusChangeListener() {

			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				// TODO Auto-generated method stub
				String nationalID = EtNationalID.getText().toString();
				if (nationalID.equals("") || nationalID == null) {

				} else {
					internetConnectionStatus = new CheckInternetConnection(
							ChangeClientPin.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						Member member = new Member();
						member.id_no = nationalID;
						trans.member_1 = member;
						trans.status = Transaction.Status.Pending;

						new GetAccounts(trans).execute();

					} else {
						misc.tost(ChangeClientPin.this, getString(R.string.nointernet));
					}
				}
			}
		});
		BtnConfirm.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				String NationalID = EtNationalID.getText().toString().trim();
				String CurrentPin = EtCurrentPin.getText().toString();
				String NewPin = EtNewPin.getText().toString();
				String ConfirmPin = EtConfirmNewPin.getText().toString();
				
				if(NationalID.equals("")|| NationalID == null){
					EtNationalID.setError(getString(R.string.emptyfield));
					EtNationalID.requestFocus();
				}else if(CurrentPin.equals("")||  CurrentPin == null){
					EtCurrentPin.setError(getString(R.string.emptyfield));
					EtCurrentPin.requestFocus();
				}else if(NewPin.equals("")||NewPin == null){
					EtNewPin.setError(getString(R.string.emptyfield));
					EtNewPin.requestFocus();
				}else if(ConfirmPin.equals("")|| ConfirmPin == null){
					EtConfirmNewPin.setError(getString(R.string.emptyfield));
					EtConfirmNewPin.requestFocus();
				}else if (!CurrentPin.equals(AgencyListActivity.trans.member_1.pin)){
					EtCurrentPin.setError("Invalid current pin");
					EtCurrentPin.requestFocus();
				}else if (!NewPin.equals(ConfirmPin)){
					EtConfirmNewPin.setError("New pin and Confirm pin must be the same");
					EtConfirmNewPin.requestFocus();
				}
				else {
					trans.newpin= NewPin;
					trans.status = Transaction.Status.Pending;
					new Transsync(trans).execute();
				}
				
			}
		});
	}
	public void ConfirmationBox(Transaction t) {
		final String ref = t.code;
		LayoutInflater li = LayoutInflater.from(ChangeClientPin.this);
		View promptsView = li.inflate(R.layout.confirmation_box, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				ChangeClientPin.this);

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
		tvAccNo.setText(t.account_1.Account_No + " To " + t.account_2.Account_No);
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
						new Transsync(trans).execute();
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
		LayoutInflater li = LayoutInflater.from(ChangeClientPin.this);
		View promptsView = li.inflate(R.layout.activity_results, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				ChangeClientPin.this);
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
				ChangeClientPin.this);
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
				result = JsonParser.SendHttpPost(ChangeClientPin.this, "Accounts", result,
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
					EtNationalID.requestFocus();

				} else {

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


	}
	private class Transsync extends AsyncTask<Transaction, Void, Transaction> {
		private final ProgressDialog dialog = new ProgressDialog(
				ChangeClientPin.this);
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
				result = JsonParser.SendHttpPost(ChangeClientPin.this, "Changepin", result,
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
