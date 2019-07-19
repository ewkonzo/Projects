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
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import java.lang.reflect.Type;

import static com.example.m_saccoagency.AgencyListActivity.trans;

public class CashTransfer extends Activity {
	
	private EditText EtNationalId, EtToAccNo, EtAmount;
	private TextView tvFromAccNo, tvFromAccName, tvToAccName, tvAccountBal;
	private Button btnCancel, btnConfirm;
	private int accsource = 0;
	private ProgressBar psource,pdestination;
	private boolean internetConnectionStatus = false;
	private String[] balEnquiryArray;
	String PhoneNo = "", RecepientPhone="", AccFrom = "",AccTo="", FromAccName = "", Amount="";
	String nationalID = "";
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.cash_transfer);

		EtNationalId  = (EditText)findViewById(R.id.cttxtnationalid);
		EtToAccNo = (EditText)findViewById(R.id.ctTotxtDaccountNo);
		EtAmount = (EditText)findViewById(R.id.cttxtamount);
		tvFromAccName = (TextView)findViewById(R.id.cttxtaccountname);
		tvFromAccNo = (TextView)findViewById(R.id.cttvtxtaccountno);
		tvAccountBal = (TextView)findViewById(R.id.ctAccountBalance);
		tvToAccName = (TextView)findViewById(R.id.ctTotxtDaccountname);
		btnCancel = (Button)findViewById(R.id.ctBtnCancel);
		btnConfirm = (Button)findViewById(R.id.ctBtnConfirm);
		psource= (ProgressBar)findViewById(R.id.paccdetails);
		pdestination= (ProgressBar)findViewById(R.id.pacc2details);

		EtNationalId.setOnFocusChangeListener(new View.OnFocusChangeListener() {
			
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				// TODO Auto-generated method stub
				if (!hasFocus){
				String nationalID = EtNationalId.getText().toString();
				if (nationalID.equals("") || nationalID == null) {

				} else {
					internetConnectionStatus = new CheckInternetConnection(
							CashTransfer.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						Member member = new Member();
						member.id_no = nationalID;
						trans.member_1 = member;
						trans.status = Transaction.Status.Pending;
						psource.setVisibility(View.VISIBLE);
						accsource=0;
						new GetAccounts(trans).execute();

					} else {
						misc.tost(CashTransfer.this	, getString(R.string.nointernet));
					}
				}
			}}
		});
		EtToAccNo.setOnFocusChangeListener(new View.OnFocusChangeListener() {
			
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				// TODO Auto-generated method stub
				String accNo = EtToAccNo.getText().toString();
				if (accNo.equals("") || accNo == null) {
					//EtNationalID.setError("Field cannot be null");
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							CashTransfer.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						Account acc = new Account();
						acc.Account_No= accNo;
						trans.account_2= acc;
						accsource=1;
						pdestination.setVisibility(View.VISIBLE);
						new GetAccounts2(trans).execute();
					} else {
						misc.tost(CashTransfer.this,getString(R.string.nointernet));
					}
				}
			}
		});
		
		btnConfirm.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				nationalID = EtNationalId.getText().toString().trim();
				 Amount = EtAmount.getText().toString().trim();
				 AccTo = EtToAccNo.getText().toString().trim();
				if ((trans!=null) && (trans.member_1!= null )&& (nationalID.equals(trans.member_1.id_no))) {
					if ((trans!=null) && (trans.account_2!= null )&& (AccTo.equals(trans.account_2.Account_No))) {
						if(nationalID.equals("") || nationalID == null){
					EtNationalId.setError(getString(R.string.emptyfield));
					EtNationalId.requestFocus();
				} else if(Amount.equals("")|| Amount == null){
					EtAmount.setError(getString(R.string.emptyfield));
					EtAmount.requestFocus();
				} else if(AccTo.equals("")|| AccTo == null) {
					EtToAccNo.setError(getString(R.string.emptyfield));
					EtToAccNo.requestFocus();
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							CashTransfer.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						trans.status= Transaction.Status.Pending;
						trans.amount = Double.parseDouble(Amount);
						if(trans.account_2==null){
							EtToAccNo.setError("Invalid account");
							EtToAccNo.requestFocus();
						}else if (!trans.account_2.Account_ok)
						{EtToAccNo.setError(trans.account_2.Message);
							EtToAccNo.requestFocus(); }
						else {

							new Transsync(trans).execute();
						}

					} else {

						misc.tost(CashTransfer.this,getString(R.string.nointernet));
					}
				}}else EtToAccNo.clearFocus();}else
					EtNationalId.clearFocus();
			}
		});
		btnCancel.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				finish();
			}
		});
	}

	public void ConfirmationBox(Transaction t) {
		final String ref = t.code;
		LayoutInflater li = LayoutInflater.from(CashTransfer.this);
		View promptsView = li.inflate(R.layout.confirmation_box, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				CashTransfer.this);

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
		LayoutInflater li = LayoutInflater.from(CashTransfer.this);
		View promptsView = li.inflate(R.layout.activity_results, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				CashTransfer.this);
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
				CashTransfer.this);
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
				result = JsonParser.SendHttpPost(CashTransfer.this, "Accounts", result,
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
					tvFromAccNo.setText("");
					tvFromAccName.setText("");
					EtNationalId.setText("");
					EtNationalId.setError(trans.message);
					EtNationalId.requestFocus();


				} else {

					switch (trans.member_1.accounts.size()) {
						case 1:
							tvFromAccNo.setText(trans.member_1.accounts.get(0).Account_No);
							tvFromAccName.setText(trans.member_1.accounts.get(0).Account_Name);
							trans.account_1 = trans.member_1.accounts.get(0);
							break;
						case 0:
							tvFromAccNo.setText("");
							tvFromAccName.setText("");
							EtNationalId.setError(getString(R.string.noactiveaccount));
							Toast.makeText(getApplicationContext(), R.string.noactiveaccount, Toast.LENGTH_LONG).show();
							break;
						default:
							SelectAcc(trans.member_1);
							break;
					}

				}
				psource.setVisibility(View.INVISIBLE);
				pdestination.setVisibility(View.INVISIBLE);
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
			AlertDialog.Builder localBuilder = new AlertDialog.Builder(CashTransfer.this);
			localBuilder.setTitle("Accounts");
			localBuilder.setMessage("Select Account to use");
			ListView localListView = new ListView(CashTransfer.this);
			localListView.setChoiceMode(1);
			localListView.setAdapter(new BindAccounts(CashTransfer.this, paramMember.accounts));
			localBuilder.setView(localListView);
			localBuilder.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {
					trans.account_1 = BindAccounts.outdata;
					if (trans.account_1 != null) {
						tvFromAccNo.setText(BindAccounts.outdata.Account_No);
						tvFromAccName.setText(BindAccounts.outdata.Account_Name);
					}
				}
			});
			localBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {
					trans.account_1 = null;
					tvFromAccNo.setText("");
					tvFromAccName.setText("");
				}
			});
			localBuilder.show();
		}
	}
	private class GetAccounts2 extends AsyncTask<Transaction, Void, Transaction> {
		private final ProgressDialog dialog = new ProgressDialog(
				CashTransfer.this);
		private Transaction t;

		GetAccounts2(Transaction paramAgent) {
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
				result = JsonParser.SendHttpPost(CashTransfer.this, "Accounts", result,
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
					tvToAccName.setText("");
					EtNationalId.setError(trans.message);
					EtNationalId.requestFocus();

				} else {

					if (trans.account_2 != null) {
						if (trans.account_2.Account_ok) {
							tvToAccName.setText(trans.account_2.Account_Name);
						} else {
							tvToAccName.setText("");
							EtToAccNo.setError(trans.account_2.Message);
							EtToAccNo.requestFocus();
							tvToAccName.setText("");
							misc.tost(CashTransfer.this, trans.account_2.Message);
						}
					}
				}
				psource.setVisibility(View.INVISIBLE);
				pdestination.setVisibility(View.INVISIBLE);
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
			AlertDialog.Builder localBuilder = new AlertDialog.Builder(CashTransfer.this);
			localBuilder.setTitle("Accounts");
			localBuilder.setMessage("Select Account to use");
			ListView localListView = new ListView(CashTransfer.this);
			localListView.setChoiceMode(1);
			localListView.setAdapter(new BindAccounts(CashTransfer.this, paramMember.accounts));
			localBuilder.setView(localListView);
			localBuilder.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {
					trans.account_1 = BindAccounts.outdata;
					if (trans.account_1 != null) {
						tvFromAccNo.setText(BindAccounts.outdata.Account_No);
						tvFromAccName.setText(BindAccounts.outdata.Account_Name);
					}
				}
			});
			localBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {
					trans.account_1 = null;
					tvFromAccNo.setText("");
					tvFromAccName.setText("");
				}
			});
			localBuilder.show();
		}
	}
	private class Transsync extends AsyncTask<Transaction, Void, Transaction> {
		private final ProgressDialog dialog = new ProgressDialog(
				CashTransfer.this);
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
				result = JsonParser.SendHttpPost(CashTransfer.this, "Transactions", result,
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
