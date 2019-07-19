package com.example.m_saccoagency;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import com.example.utils.Configuration;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TableRow;
import android.widget.TextView;

import java.io.IOException;
import java.lang.reflect.Type;
import java.text.SimpleDateFormat;
import java.util.Calendar;

import static com.example.m_saccoagency.AgencyListActivity.btoutputstream;
import static com.example.m_saccoagency.AgencyListActivity.btsocket;
import static com.example.m_saccoagency.AgencyListActivity.trans;

public class AccountOpening extends Activity {
	private EditText EtAccName, EtNationalID, EtTelNo, EtSociety, EtMemberNo, EtAmount;
	private Button BtnCancel, BtnConfirm;
	String AccName, NationaID, TelNo, Society,MemberNo,Amount;
		protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.account_opening);
		
		EtAccName = (EditText)findViewById(R.id.aotxtaccountname);
		EtNationalID = (EditText)findViewById(R.id.aotxtnationalid);
		EtTelNo = (EditText)findViewById(R.id.aotxtphoneno);
		EtSociety = (EditText)findViewById(R.id.aotxtsociety);
		EtMemberNo = (EditText)findViewById(R.id.aotxtsocietyno);
		EtAmount = (EditText)findViewById(R.id.aotxtamount);
		BtnCancel = (Button)findViewById(R.id.aoCancel);
		BtnConfirm = (Button)findViewById(R.id.aoConfirm);

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
				AccName = EtAccName.getText().toString().trim();
				NationaID = EtNationalID.getText().toString().trim();
				TelNo = EtTelNo.getText().toString().trim();
				Society = EtSociety.getText().toString().trim();
				MemberNo = EtMemberNo.getText().toString().trim();
				Amount = EtAmount.getText().toString().trim();
				
				if(AccName.equals("")|| AccName == null) {
					EtAccName.setError(getString(R.string.emptyfield));
					EtAccName.requestFocus();
				} else if(NationaID.equals("")|| NationaID == null){
					EtNationalID.setError( getString(R.string.emptyfield));
					EtNationalID.requestFocus();
				}else if(TelNo.equals("")|| TelNo == null){
					EtTelNo.setError(getString(R.string.emptyfield));
					EtTelNo.requestFocus();
				}else if(Amount.equals("")||Amount == null){
					EtAmount.setError(getString(R.string.emptyfield));
					EtAmount.requestFocus();
				}else {
					trans.status= Transaction.Status.Pending;
					trans.amount = Double.valueOf(Amount).doubleValue();
					Member member = new Member();
					member.id_no = NationaID;
					member.telephone = TelNo;
					member.name = AccName;
					trans.member_1 = member;
					new  Transsync(trans).execute();
				}
			}
		});
	}
	private class Transsync extends AsyncTask<Transaction, Void, Transaction> {
		private final ProgressDialog dialog = new ProgressDialog(
				AccountOpening.this);
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
				result = JsonParser.SendHttpPost(AccountOpening.this, "Transactions", result,
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
		LayoutInflater li = LayoutInflater.from(AccountOpening.this);
		View promptsView = li.inflate(R.layout.confirmation_box, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				AccountOpening.this);
		alertDialogBuilder.setView(promptsView);
		final TableRow trpin = (TableRow)promptsView.findViewById(R.id.trpin);
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
		tvAccNo.setText(t.member_1.name);
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

		LayoutInflater li = LayoutInflater.from(AccountOpening.this);
		View promptsView = li.inflate(R.layout.activity_results, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				AccountOpening.this);

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
						{Calendar c = Calendar.getInstance();
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
