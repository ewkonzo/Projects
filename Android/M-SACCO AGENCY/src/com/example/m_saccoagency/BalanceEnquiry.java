package com.example.m_saccoagency;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

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
import android.widget.Toast;

import com.example.utils.CheckInternetConnection;
import com.example.utils.Configuration;
import com.example.utils.SendSms;

public class BalanceEnquiry extends Activity {

	private EditText EtNationalID;
	private TextView EtAccountNo;
	private TextView EtAccountName;
	private Button BtnConfirm, BtnCancel;
	private boolean internetConnectionStatus = false;
	SharedPreferences sharedpreferences;
	private static final String SOAP_ACTION = "http://tempuri.org/GetAccounts";
	private static final String OPERATION = "GetAccounts";

	private static final String SOAP_ACTION_BALANCE = "http://tempuri.org/BalanceEnquiry";
	private static final String OPERATION_BALANCE = "BalanceEnquiry";

	private static final String SOAP_ACTION_SMS = "http://tempuri.org/sendSms";
	private static final String OPERATION_SMS = "sendSms";

	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = "";

	private static String SOAP_ADDRESS_TWO = "";
	String MemberPhoneNo = "", MemberAccountNo = "", AccName = "";
	String nationalID = "";
	private String[] balEnquiryArray;

	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.balance_enquiry);

		EtNationalID = (EditText) findViewById(R.id.etblnationalid);
		EtAccountNo = (TextView) findViewById(R.id.bltxtaccountno);
		EtAccountName = (TextView) findViewById(R.id.bltxtaccountname);
		BtnConfirm = (Button) findViewById(R.id.blConfirm);
		BtnCancel = (Button) findViewById(R.id.blCancel);
		SOAP_ADDRESS = Configuration.getURL();

		SOAP_ADDRESS_TWO = Configuration.getURL_TWO();

		/*
		 * EtNationalID.setOnFocusChangeListener(new
		 * View.OnFocusChangeListener() {
		 * 
		 * @Override public void onFocusChange(View v, boolean hasFocus) { //
		 * TODO Auto-generated method stub
		 * 
		 * } });
		 */

		BtnConfirm.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				 nationalID = EtNationalID.getText().toString();
				if (nationalID.equals("") || nationalID == null) {
					EtNationalID.setError("Field cannot be null");
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							BalanceEnquiry.this).isConnectingToInternet();
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

		BtnCancel.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(BalanceEnquiry.this,
						AgencyListActivity.class);
				startActivity(intent);
			}
		});
	}

	private class GetAccountDetails extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(
				BalanceEnquiry.this);

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
			String accountNo = "", PhoneNo = "";

			try {
				String result = null;
				int c = res.getPropertyCount();
				// Log.d("onPostExecute", res);
				if (c > 0) {
					result = String.valueOf(res.getProperty(c - 1));
					if(result.equalsIgnoreCase("none")){						
						EtNationalID.setError("No such account");
					} else{
					
					balEnquiryArray = result.split(":::");
					accountNo = balEnquiryArray[0];
					AccName = balEnquiryArray[1];
					Log.d("accountNo", accountNo);
					PhoneNo = balEnquiryArray[2];
					EtAccountNo.setText(balEnquiryArray[0]);
					EtAccountName.setText(balEnquiryArray[1]);
					// generate a 4 digit integer 1000 <10000
					int myNo = (int) (Math.random() * 9000) + 1000;

					Log.d("Random No", String.valueOf(myNo));
					String smstxt = "Balance CODE: " + String.valueOf(myNo);
					SendSms.SendAgentSms(PhoneNo, smstxt);
					// new SendMySms().execute(new String[] { PhoneNo,smstxt });
					GetConfirmationBox(accountNo, "Balance Enquiry", PhoneNo, myNo);
					}
					
				} else {
					EtNationalID.setError("Error, system down");
				}

				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
				}

								
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

	private class GetBalanceEnquiry extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				BalanceEnquiry.this);

		@Override
		protected void onPreExecute() {
			// Log.d("got here point 2", "yes");
			this.dialog.setMessage("Please wait...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(String... params) {
			//
			SoapObject resultsRequestSOAP = null;
			String result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION_BALANCE);
				request.addProperty("acctNo", params[0].toString());
				request.addProperty("Agentcode", params[2].toString());
				request.addProperty("telNo", params[1].toString());
				request.addProperty("accName", params[3].toString());
				request.addProperty("idNo", params[4].toString());
				
				Log.d("Agent Code", params[2].toString());
				Log.d("accName", params[3].toString());
				Log.d("idNo", params[4].toString());				
				
				MemberPhoneNo = params[1].toString();
				Log.d(MemberPhoneNo, MemberPhoneNo);
				MemberAccountNo = params[0].toString();
				Log.d(MemberAccountNo, MemberAccountNo);

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);
				Log.d("SOAP_ADDRESS", SOAP_ADDRESS);
				Log.d("My  request", request.toString());
				httpTransport.call(SOAP_ACTION_BALANCE, envelope);
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
			try {

				String smstext = "Balance Completed. \n Account: "
						+ MemberAccountNo + " \n Amount: " + res;
				SendSms.SendAgentSms(MemberPhoneNo, smstext);
			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {
					// DialogBox("errorr.. ", ex.getMessage());
					Log.e(ex.getMessage(), ex.getMessage());
				}
			}
			DialogBox("Balance Enquiry", "Transaction successfull!");

		}
	}

	private class EnquiryBalance extends AsyncTask<String, Void, SoapObject> {

		private final ProgressDialog dialog = new ProgressDialog(
				BalanceEnquiry.this);

		@Override
		protected void onPreExecute() {
			this.dialog.setMessage("Please wait...");
			this.dialog.show();
		}

		@Override
		protected SoapObject doInBackground(String... urls) {
			//

			SoapObject result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION_BALANCE);
				request.addProperty("acctNo", urls[0].toString());
				Log.d("AccNo", urls[0].toString());
				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);

				httpTransport.call(SOAP_ACTION_BALANCE, envelope);

				result = (SoapObject) envelope.getResponse();
				return result;
			} catch (Exception e) {
				e.printStackTrace();
			}
			return result;
		}

		@Override
		protected void onPostExecute(SoapObject res) {
			int n = res.getPropertyCount();
			if (this.dialog.isShowing()) {
				this.dialog.dismiss();
			}
			if (res.getPropertyCount() > 0) {
				String result = res.toString();
				String myresult = res.getProperty(n - 1).toString();
				String sd = String.valueOf(res.getProperty(n - 1));

				
				DialogBox("Balance Enquiry", result +" "+myresult+ " "+sd);
				// display Member infomation in a listView.
				// Log.d("Before split", balEnquiryFromServer.toString());
			}

		}

	}

	private class SendMySms extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(
				BalanceEnquiry.this);

		@Override
		protected void onPreExecute() {
			// Log.d("got here point 2", "yes");
			// this.dialog.setMessage("Please wait...");
			// this.dialog.show();
		}

		@Override
		protected SoapObject doInBackground(String... params) {
			//
			SoapObject resultsRequestSOAP = null;
			String result = null;
			try {

				SoapObject myrequest = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION_SMS);
				myrequest.addProperty("PhoneNo", params[0].toString());
				myrequest.addProperty("text", params[1].toString());

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(myrequest);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS_TWO);
				Log.d("SOAP_ADDRESS", SOAP_ADDRESS_TWO);
				Log.d("My  request", myrequest.toString());
				httpTransport.call(SOAP_ACTION_SMS, envelope);
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
			String accountNo = "", PhoneNo = "";

			try {

				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
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

	public void GetConfirmationBox(final String accountNo, String TransType,
			final String PhoneNo, final int RandomNo) {

		LayoutInflater li = LayoutInflater.from(BalanceEnquiry.this);
		View promptsView = li.inflate(R.layout.confirmation_box, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				BalanceEnquiry.this);

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
		
		SharedPreferences preferences = PreferenceManager
				.getDefaultSharedPreferences(this);		
		final String storedAgentCode = preferences.getString("agentKey", "");

		tvTranType.setText(TransType);
		tvAccNo.setText(accountNo);
		tvAmount.setVisibility(View.GONE);
		tvAmount2.setVisibility(View.INVISIBLE);

		Configuration config = new Configuration();
		final String MyagentPin = config.getAgentPin();
		// set dialog message
		alertDialogBuilder
				.setCancelable(false)
				.setTitle("Client Confirmation")
				.setPositiveButton("OK", new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int id) {
						// get user input and set it to result
						// edit text
						String cnfCode = EtAC.getText().toString().trim();
						String agentPin = EtAgentPin.getText().toString()
								.trim();
						int c = Integer.parseInt(cnfCode);
						if (c == RandomNo) {
							// Toast("Correct code");
							if (Integer.parseInt(agentPin) == Integer
									.parseInt(MyagentPin)) {
							
								new GetBalanceEnquiry().execute(new String[] {
										accountNo, PhoneNo,storedAgentCode, AccName, nationalID });
								/*new EnquiryBalance().execute(new String[] {
										accountNo, PhoneNo });*/
								// Toast("Corect: "+agentPin+" "+MyagentPin);
							} else {
								Toast("Incorect agent Pin ");
							}

						} else {
							// Log.d("AC", cnfCode);
							Toast("Sorry, Incorrect authentication code");
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

	public void Toast(String message) {

		Toast.makeText(getApplicationContext(), message, Toast.LENGTH_LONG)
				.show();

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
}
