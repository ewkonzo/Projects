package com.example.m_saccoagency;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import com.example.utils.CheckInternetConnection;
import com.example.utils.Configuration;
import com.example.utils.SendSms;

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
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class AccountActivationActivity extends Activity {

	private EditText EtNationalID;
	private TextView TvAccNo, TvAccName;
	private Button BtnCancel, BtnConfirm;
	private static final String SOAP_ACTION = "http://tempuri.org/GetAccounts";
	private static final String OPERATION = "GetAccounts";

	private static final String SOAP_ACTION_ACTIVATE = "http://tempuri.org/AccountActivation";
	private static final String OPERATION_ACTIVATE = "AccountActivation";
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = "";
	private String[] returnedArray;
	String accountNo = "", AccName = "", PhoneNo = "", nationalID = "",
			pin = "";
	private boolean internetConnectionStatus = false;
	SharedPreferences sharedpreferences;

	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.account_activation);

		EtNationalID = (EditText) findViewById(R.id.aatxtnationalid);
		TvAccName = (TextView) findViewById(R.id.aatxtaccountname);
		TvAccNo = (TextView) findViewById(R.id.aatxtaccountno);
		BtnCancel = (Button) findViewById(R.id.aaCancel);
		BtnConfirm = (Button) findViewById(R.id.aaConfirm);
		SOAP_ADDRESS = Configuration.getURL();
		BtnCancel.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(AccountActivationActivity.this,
						AgencyListActivity.class);
				startActivity(intent);
			}
		});
		BtnConfirm.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				nationalID = EtNationalID.getText().toString();
				if (nationalID.equals("") || nationalID == null) {
					EtNationalID.setError("Field cannot be null");
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							AccountActivationActivity.this)
							.isConnectingToInternet();
					if (internetConnectionStatus) {
						new GetAccountDetails()
								.execute(new String[] { nationalID });

					} else {

						DialogBox("Internet Connection",
								"Sorry you have no internet connection");
					}
				}

			}
		});
	}

	private class GetAccountDetails extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(
				AccountActivationActivity.this);

		@Override
		protected void onPreExecute() {
			// Log.d("got here point 2", "yes");
			this.dialog.setMessage("Please wait...");
			this.dialog.show();
		}

		@Override
		protected SoapObject doInBackground(String... params) {
			//
			SoapObject resultsRequestSOAP = null;
			String result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION);
				request.addProperty("IdNumber", params[0].toString());

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);
				Log.d("SOAP_ADDRESS", SOAP_ADDRESS);
				Log.d("My  request", request.toString());
				httpTransport.call(SOAP_ACTION, envelope);
				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;
					Log.i("Sent Request", str);
				} else {
					resultsRequestSOAP = (SoapObject) envelope.bodyIn;
					Log.d("WS", String.valueOf(resultsRequestSOAP));

					int n = resultsRequestSOAP.getPropertyCount();
					Log.d("Count", String.valueOf(n));
					Log.d("Returned Value", String.valueOf(resultsRequestSOAP
							.getProperty(n - 1)));

					// return result;
				}
			} catch (Exception e) {
				Log.e("Erorr....", e.getMessage().toString());
			}
			// Log.d("result", result);
			return resultsRequestSOAP;

		}

		@Override
		protected void onPostExecute(SoapObject res) {

			try {
				String result = null;
				int c = res.getPropertyCount();
				// Log.d("onPostExecute", res);
				if (c > 0) {
					result = String.valueOf(res.getProperty(c - 1));

					if (result.equalsIgnoreCase("none")) {

						EtNationalID.setError("No such account");
					} else {
						returnedArray = result.split(":::");
						accountNo = returnedArray[0];
						AccName = returnedArray[1];
						Log.d("accountNo", accountNo);
						PhoneNo = returnedArray[2];
						TvAccNo.setText(returnedArray[0]);
						TvAccName.setText(returnedArray[1]);

						// generate a 4 digit integer 1000 <10000
						int myNo = (int) (Math.random() * 9000) + 1000;

						Log.d("Random No", String.valueOf(myNo));
						String smstxt = "Account Activation CODE: "
								+ String.valueOf(myNo);
						SendSms.SendAgentSms(PhoneNo, smstxt);
						// new SendMySms().execute(new String[] { PhoneNo,smstxt
						// });
						GetConfirmationBox(accountNo, "Account activation",
								PhoneNo, myNo);
					}

				} else {
					EtNationalID.setError("Error, system is down");
				}

				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
				}

				// balEnquiryArray = new String[1][2];

				// DialogBoxWithRefresh("", res);

			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();

				else {
					// DialogBox("errorr.. ", ex.getMessage());
					Log.i(ex.getMessage(), ex.getMessage());
				}
			}

			// new getMyBeneficiaries().execute(new String[] { strTelephoneNo
			// });
		}
	}

	public void GetConfirmationBox(final String accountNo, String TransType,
			final String PhoneNo, final int RandomNo) {

		LayoutInflater li = LayoutInflater.from(AccountActivationActivity.this);
		View promptsView = li.inflate(R.layout.confirmation_box, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				AccountActivationActivity.this);

		alertDialogBuilder.setView(promptsView);

		final TextView tvTranType = (TextView) promptsView
				.findViewById(R.id.cbtxttranstype);
		final TextView tvAccNo = (TextView) promptsView
				.findViewById(R.id.cbtxtaccountno);
		final TextView tvAmount = (TextView) promptsView
				.findViewById(R.id.cbmyamount);
		final TextView tvAmount2 = (TextView) promptsView
				.findViewById(R.id.cbtxtamount);		
		final TextView tvpin = (TextView) promptsView
				.findViewById(R.id.cbtvPin);

		final EditText EtAC = (EditText) promptsView
				.findViewById(R.id.cbtxtcode);
		final EditText EtAgentPin = (EditText) promptsView
				.findViewById(R.id.cbtxtpin);

		SharedPreferences preferences = PreferenceManager
				.getDefaultSharedPreferences(this);
		final String storedAgentCode = preferences.getString("agentKey", "");

		tvTranType.setText(TransType);
		tvAccNo.setText(accountNo);
		tvAmount.setVisibility(View.GONE);
		tvAmount2.setVisibility(View.INVISIBLE);
		EtAgentPin.setVisibility(View.INVISIBLE);
		tvpin.setVisibility(View.INVISIBLE);
	
		// set dialog message
		alertDialogBuilder
				.setCancelable(false)
				.setTitle("Client Confirmation")
				.setPositiveButton("OK", new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int id) {
						// get user input and set it to result
						// edit text
						String cnfCode = EtAC.getText().toString().trim();

						int c = Integer.parseInt(cnfCode);
						if (c == RandomNo) {

							int x = (int) (Math.random() * 9000) + 1000;
							pin = String.valueOf(x);
							new ActivateAccount().execute(new String[] {
									accountNo, PhoneNo, storedAgentCode,
									AccName, nationalID, pin });

						} else {
							// Log.d("AC", cnfCode);
							DialogBox("",
									"Sorry, Incorrect authentication code");
						}
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

	public void DialogBoxWithRefresh(String title, String text) {
		try {
			AlertDialog ad = new AlertDialog.Builder(this).create();
			ad.setCancelable(false);
			ad.setTitle(title);
			ad.setMessage(text);
			ad.setButton("OK", new DialogInterface.OnClickListener() {
				public void onClick(final DialogInterface dialog,
						final int which) {
					dialog.dismiss();

					finish();
					startActivity(getIntent());

				}
			});
			ad.show();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	private class ActivateAccount extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				AccountActivationActivity.this);

		@Override
		protected void onPreExecute() {
			// Log.d("got here point 2", "yes");
			this.dialog.setMessage("Processing request...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(String... params) {
			//
			SoapObject resultsRequestSOAP = null;
			String result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION_ACTIVATE);
				request.addProperty("acctNo", params[0].toString());
				request.addProperty("Agentcode", params[2].toString());
				request.addProperty("telNo", params[1].toString());
				request.addProperty("accName", params[3].toString());
				request.addProperty("idNo", params[4].toString());
				request.addProperty("pin", params[5].toString());

				Log.d("Agent Code", params[2].toString());
				Log.d("accName", params[3].toString());
				Log.d("idNo", params[4].toString());

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);
				Log.d("SOAP_ADDRESS", SOAP_ADDRESS);
				Log.d("My  request", request.toString());
				httpTransport.call(SOAP_ACTION_ACTIVATE, envelope);
				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;
					Log.d("Sent Request", str);

				} else {
					resultsRequestSOAP = (SoapObject) envelope.bodyIn;
					Log.d("WS", String.valueOf(resultsRequestSOAP));

					int n = resultsRequestSOAP.getPropertyCount();

					Log.d("Count", String.valueOf(n));
					Log.d("Returned Value", String.valueOf(resultsRequestSOAP
							.getProperty(n - 1)));
					result = resultsRequestSOAP.getProperty(n - 1).toString();
					resultsRequestSOAP = (SoapObject) resultsRequestSOAP
							.getProperty(n - 1);
					// return result;
				}

			} catch (Exception e) {
				Log.e("Erorr....", e.getMessage().toString());
			}
			Log.d("result", String.valueOf(resultsRequestSOAP));
			return result;

		}

		@Override
		protected void onPostExecute(String res) {
			if (this.dialog.isShowing()) {
				this.dialog.dismiss();
			}
			String myresult = res;
			Log.d("Myresult", myresult);
			if (myresult.equalsIgnoreCase("true")) {
				try {

					String smstext = "You have successfully been activated to use MY-CASH Mobile Money Service. "
							+ "Your start pin is " + pin;
					SendSms.SendAgentSms(PhoneNo, smstext);
					DialogBoxWithRefresh("Account activation",
							"Transaction successfull!");
				} catch (Exception ex) {

					if (ex.getMessage() == null)
						ex.printStackTrace();
					else {
						// DialogBox("errorr.. ", ex.getMessage());
						Log.e(ex.getMessage(), ex.getMessage());
					}
				}

			} else if (myresult.equalsIgnoreCase("activated")) {
				DialogBox("Account activation",
						"Sorry, Member is already activated");
			}

			else {
				DialogBox("Account activation",
						"System error, please try again later.");
			}

		}
	}

}
