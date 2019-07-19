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

public class CashDeposit extends Activity  {
	
	private Button BtnCancel, BtnConfirm;
	private EditText EtAccountNo, EtAmount,EtDepositorName, EtTelephoneNo;
	private TextView tvAccountName;
	private boolean internetConnectionStatus = false;
	
	private static final String SOAP_ACTION = "http://tempuri.org/GetAccountName";
	private static final String OPERATION = "GetAccountName";
	
	private static final String SOAP_ACTION_DEPOSIT = "http://tempuri.org/CashDeposit";
	private static final String OPERATION_DEPOSIT = "CashDeposit";
	
	private static String SOAP_ADDRESS = "";
	private static String SOAP_ADDRESS_TWO = "";
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
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
		
		SOAP_ADDRESS = Configuration.getURL();
		SOAP_ADDRESS_TWO = Configuration.getURL_TWO();
		
		EtAccountNo.setOnFocusChangeListener(new View.OnFocusChangeListener() {
			
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				// TODO Auto-generated method stub
				String accNo = EtAccountNo.getText().toString();
				if (accNo.equals("") || accNo == null) {
					//EtNationalID.setError("Field cannot be null");
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							CashDeposit.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						new GetAccountName()
								.execute(new String[] { accNo });

					} else {

						DialogBox("Internet Connection",
								"Sorry you have no internet connection");
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

						// generate a 4 digit integer 1000 <10000
						int myNo = (int) (Math.random() * 9000) + 1000;

						Log.d("Random No", String.valueOf(myNo));
						String smstxt = "Deposit CODE: " + String.valueOf(myNo);
						//SendSms.SendAgentSms(PhoneNo, smstxt);
						// DialogBox("", "Success");
						ConfirmationBox(AccNo, "Cash Deposit", PhoneNo,
								myNo, Amount);

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
				Intent intent = new Intent(CashDeposit.this,
						AgencyListActivity.class);
				startActivity(intent);
			}
		});
		
	}

	public void ConfirmationBox(final String accountNo, String TransType,
			final String PhoneNo, final int RandomNo, final String Amount) {

		LayoutInflater li = LayoutInflater.from(CashDeposit.this);
		View promptsView = li.inflate(R.layout.confirmation_box, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				CashDeposit.this);

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
						new DepositCash().execute(new String[] {
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
	

	private class GetAccountName extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(
				CashDeposit.this);

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
				request.addProperty("AccNo", params[0].toString());

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
				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
				}
				String result = null;
				int c = res.getPropertyCount();
				// Log.d("onPostExecute", res);
				if (c > 0) {
					result = String.valueOf(res.getProperty(c - 1));
				} else {
					tvAccountName.setError("No such account");
				}
				balEnquiryArray = result.split(":::");
				
				// balEnquiryArray = new String[1][2];
			
				tvAccountName.setText(balEnquiryArray[0]);
				PhoneNo = balEnquiryArray[1];
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
	
	private class DepositCash extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				CashDeposit.this);

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
				
				MemberPhoneNo = params[1].toString();
				Log.d(MemberPhoneNo, MemberPhoneNo);
				MemberAccountNo = params[0].toString();
				Log.d(MemberAccountNo, MemberAccountNo);
				DepositAmount = params[5].toString();

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

				String smstext = "Cash Deposit completed. \n Account: "
						+ MemberAccountNo + " \n Amount: " + DepositAmount;
				SendSms.SendAgentSms(MemberPhoneNo, smstext);
			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {
					// DialogBox("errorr.. ", ex.getMessage());
					Log.e(ex.getMessage(), ex.getMessage());
				}
			}
			DialogBoxWithRefresh("Cash Deposit", "Transaction successfull!");
			}			
			else {
				DialogBox("Deposit Failed", "Cash deposit failed! System is down");
			}

		}
	}
	
}
