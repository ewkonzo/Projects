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

public class ShareDeposit extends Activity {

	private EditText EtNationaID, EtAmount;
	private TextView tvAccNo, tvAccName;
	private Button btnCancel, btnConfirm;
	private static final String SOAP_ACTION = "http://tempuri.org/GetShareAccount";
	private static final String OPERATION = "GetShareAccount";
	
	private static final String SOAP_ACTION_DEPOSIT = "http://tempuri.org/ShareDeposit";
	private static final String OPERATION_DEPOSIT = "ShareDeposit";
	
	private static String SOAP_ADDRESS = "";
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private String[] balEnquiryArray;
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
		SOAP_ADDRESS = Configuration.getURL();
		EtNationaID.setOnFocusChangeListener(new View.OnFocusChangeListener() {

			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				// TODO Auto-generated method stub
				String nationalID = EtNationaID.getText().toString();
				if (nationalID.equals("") || nationalID == null) {
					// EtNationalID.setError("Field cannot be null");
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							ShareDeposit.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						new GetShareAccount()
								.execute(new String[] { nationalID });

					} else {

						DialogBox("Internet Connection",
								"Sorry you have no internet connection");
					}
				}
			}
		});

		btnConfirm.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				 nationalID = EtNationaID.getText().toString().trim();
				 amount = EtAmount.getText().toString().trim();
				if (nationalID.equals("") || nationalID == null) {
					EtNationaID.setError("Field cannot be null");
				} else if (amount.equals("") || amount == null) {
					EtAmount.setError("Field cannot be null");
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							ShareDeposit.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						// generate a 4 digit integer 1000 <10000
						int myNo = (int) (Math.random() * 9000) + 1000;

						Log.d("Random No", String.valueOf(myNo));
						String smstxt = "Share Deposit CODE: " + String.valueOf(myNo);
						//SendSms.SendAgentSms(PhoneNo, smstxt);
						// DialogBox("", "Success");
						ConfirmationBox(accountNo, "Share Deposit", PhoneNo,
								myNo, amount);
					} else {

						DialogBox("Internet Connection",
								"Sorry you have no internet connection");
					}
				}
			}
		});

		btnCancel.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(ShareDeposit.this,
						AgencyListActivity.class);
				startActivity(intent);
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


	public void ConfirmationBox(final String accountNo, String TransType,
			final String PhoneNo, final int RandomNo, final String Amount) {

		LayoutInflater li = LayoutInflater.from(ShareDeposit.this);
		View promptsView = li.inflate(R.layout.confirmation_box, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				ShareDeposit.this);

		alertDialogBuilder.setView(promptsView);

		final TextView tvTranType = (TextView) promptsView
				.findViewById(R.id.cbtxttranstype);
		final TextView tvAccNo = (TextView) promptsView
				.findViewById(R.id.cbtxtaccountno);
		final TextView tvAmount = (TextView) promptsView
				.findViewById(R.id.cbmyamount);
		final TextView tvAmount2 = (TextView) promptsView
				.findViewById(R.id.cbtxtamount);
		final TextView tvCode = (TextView)promptsView.findViewById(R.id.cbtvCode);
		final TextView tvPin = (TextView)promptsView.findViewById(R.id.cbtvPin);

		final EditText EtAC = (EditText) promptsView
				.findViewById(R.id.cbtxtcode);
		final EditText EtAgentPin = (EditText) promptsView
				.findViewById(R.id.cbtxtpin);

		tvTranType.setText(TransType);
		tvAccNo.setText(accountNo);
		tvAmount2.setText(Amount);
		
		EtAC.setVisibility(View.GONE);
		EtAgentPin.setVisibility(View.GONE);
		tvCode.setVisibility(View.GONE);
		tvPin.setVisibility(View.GONE);
		SharedPreferences preferences = PreferenceManager
				.getDefaultSharedPreferences(this);		
		final String storedAgentCode = preferences.getString("agentKey", "");
		/*
		 * tvAmount.setVisibility(View.GONE);
		 * tvAmount2.setVisibility(View.INVISIBLE);
		 */

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
						//String cnfCode = EtAC.getText().toString().trim();
						//String agentPin = EtAgentPin.getText().toString().trim();
						//int c = Integer.parseInt(cnfCode);
						new DepositShares().execute(new String[] {
								accountNo, PhoneNo,storedAgentCode, AccName, nationalID, Amount });
						
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

	private class GetShareAccount extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(
				ShareDeposit.this);

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
				result = String.valueOf(res.getProperty(c - 1));
				if (c > 0) {

					if (result.equalsIgnoreCase("none")) {
						EtNationaID.setError("No active accounts");
					} else {
						balEnquiryArray = result.split(":::");
						accountNo = balEnquiryArray[0];
						PhoneNo = balEnquiryArray[2];
						AccName = balEnquiryArray[1];
						tvAccNo.setText(balEnquiryArray[0]);
						tvAccName.setText(balEnquiryArray[1]);

					}
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

		}
	}

	private class DepositShares extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				ShareDeposit.this);

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
						OPERATION_DEPOSIT);
				request.addProperty("acctNo", params[0].toString());
				request.addProperty("Agentcode", params[2].toString());
				request.addProperty("telNo", params[1].toString());
				request.addProperty("accName", params[3].toString());
				request.addProperty("idNo", params[4].toString());
				request.addProperty("amount", params[5].toString());
				
				
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
				httpTransport.call(SOAP_ACTION_DEPOSIT, envelope);
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
					resultsRequestSOAP = (SoapObject) resultsRequestSOAP.getProperty(n - 1);
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
			if(myresult.equalsIgnoreCase("true")){
			try {

				String smstext = "Share Deposit completed. \n Account: "
						+ accountNo + " \n Amount: " + amount;
				SendSms.SendAgentSms(PhoneNo, smstext);
			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {
					// DialogBox("errorr.. ", ex.getMessage());
					Log.e(ex.getMessage(), ex.getMessage());
				}
			}
			DialogBoxWithRefresh("Share Deposit", "Transaction successfull!");
			}			
			else {
				DialogBox("Share Deposit Failed", "Share deposit failed! System is down");
			}

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
	
}
