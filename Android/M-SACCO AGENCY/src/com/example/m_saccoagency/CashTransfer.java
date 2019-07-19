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

public class CashTransfer extends Activity {
	
	private EditText EtNationalId, EtToAccNo, EtAmount;
	private TextView tvFromAccNo, tvFromAccName, tvToAccName, tvAccountBal;
	private Button btnCancel, btnConfirm;
	private boolean internetConnectionStatus = false;
	private static String SOAP_ADDRESS = "";
	private static final String SOAP_ACTION = "http://tempuri.org/GetAccountsWithBalance";
	private static final String OPERATION = "GetAccountsWithBalance";
	
	private static final String SOAP_ACTION_TRANSFER = "http://tempuri.org/CashTransfer";
	private static final String OPERATION_TRANSFER = "CashTransfer";
	
	private static final String SOAP_ACTION_ACCNAME = "http://tempuri.org/GetAccountName";
	private static final String OPERATION_ACCNAME = "GetAccountName";

	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	
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
		
		SOAP_ADDRESS = Configuration.getURL();
		EtNationalId.setOnFocusChangeListener(new View.OnFocusChangeListener() {
			
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				// TODO Auto-generated method stub
				String nationalID = EtNationalId.getText().toString();
				if (nationalID.equals("") || nationalID == null) {
					// EtNationalID.setError("Field cannot be null");
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							CashTransfer.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						new GetAccounts().execute(new String[] { nationalID });

					} else {

						DialogBox("Internet Connection",
								"Sorry you have no internet connection");
					}
				}
			}
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
						new GetAccountName()
								.execute(new String[] { accNo });

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
				nationalID = EtNationalId.getText().toString().trim();
				 Amount = EtAmount.getText().toString().trim();
				 AccTo = EtToAccNo.getText().toString().trim();
				
				if(nationalID.equals("") || nationalID == null){
					EtNationalId.setError("this field cannot be null");
				} else if(Amount.equals("")|| Amount == null){
					EtAmount.setError("this field cannot be null");
				} else if(AccTo.equals("")|| AccTo == null) {
					EtToAccNo.setError("this field cannot be null");
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							CashTransfer.this).isConnectingToInternet();
					if (internetConnectionStatus) {

						// generate a 4 digit integer 1000 <10000
						int myNo = (int) (Math.random() * 9000) + 1000;

						Log.d("Random No", String.valueOf(myNo));
						String smstxt = "Cash Transfer CODE: " + String.valueOf(myNo);
						Log.d("Phone No.", PhoneNo);
						Log.d("sms", smstxt);
						SendSms.SendAgentSms(PhoneNo, smstxt);
						// DialogBox("", "Success");
						ConfirmationBox(AccTo,AccFrom, "Transfer", PhoneNo,
								myNo, Amount);

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
				Intent intent = new Intent(CashTransfer.this,
						AgencyListActivity.class);
				startActivity(intent);
			}
		});
	}

	public void ConfirmationBox(final String accTo, final String accFrom, String TransType,final String PhoneNo, final int RandomNo, final String Amount) {

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

		tvTranType.setText(TransType);
		tvAccNo.setText(accFrom +" to "+accTo);
		tvAmount2.setText(Amount);
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
								
								// RecepientPhone
								new TransferCash().execute(new String[] {
										accFrom,accTo, PhoneNo,storedAgentCode, FromAccName, nationalID, Amount });
								
							} else {
								DialogBox("", "Incorect agent Pin ");
							}

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

	private class TransferCash extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				CashTransfer.this);

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
						OPERATION_TRANSFER);
				request.addProperty("accFrom", params[0].toString());
				request.addProperty("accTo", params[1].toString());
				request.addProperty("telNo", params[2].toString());				
				request.addProperty("Agentcode", params[3].toString());
				request.addProperty("accName", params[4].toString());
				request.addProperty("idNo", params[5].toString());
				request.addProperty("amount", params[6].toString());			
					
				
				/*MemberPhoneNo = params[1].toString();
				Log.d(MemberPhoneNo, MemberPhoneNo);
				MemberAccountNo = params[0].toString();
				Log.d(MemberAccountNo, MemberAccountNo);
				WithdrawAmount = params[5].toString();
*/
				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);
				Log.d("SOAP_ADDRESS", SOAP_ADDRESS);
				Log.d("My  request", request.toString());
				httpTransport.call(SOAP_ACTION_TRANSFER, envelope);
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

				String smstext = "Cash Transfer completed. \n From : "
						+ AccFrom +" To: "+AccTo+ " \n Amount: " + Amount;
				SendSms.SendAgentSms(PhoneNo, smstext);
				// Message to recepient account
				
				String recepientSms = Amount+" has been credited to your account: "+AccTo+" from account: "+AccFrom;
				SendSms.SendAgentSms(RecepientPhone, recepientSms);
				DialogBoxWithRefresh("Cash Transfer", "Transaction successfull!");
				
			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {
					// DialogBox("errorr.. ", ex.getMessage());
					Log.e(ex.getMessage(), ex.getMessage());
				}
			}
			
			} else if(myresult.equalsIgnoreCase("No")){
				DialogBox("Transfer failed", "You are attempting to transfer more than your account balance!");
			}
			
			else {
				DialogBox("Failed", "Cash transfer failed! System is down");
			}

		}
	}
	private class GetAccounts extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(
				CashTransfer.this);

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
			String accountNo = "";

			try {
				String result = null;
				int c = res.getPropertyCount();
				// Log.d("onPostExecute", res);
				if (c > 0) {
					result = String.valueOf(res.getProperty(c - 1));
				} else {
					EtNationalId.setError("No active accounts");
				}

				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
				}

				// balEnquiryArray = new String[1][2];
				balEnquiryArray = result.split(":::");
				accountNo = balEnquiryArray[0];
				PhoneNo = balEnquiryArray[2];
				AccFrom = balEnquiryArray[0];
				FromAccName = balEnquiryArray[1];
				tvFromAccNo.setText(balEnquiryArray[0]);
				tvFromAccName.setText(balEnquiryArray[1]);
				tvAccountBal.setText(balEnquiryArray[3]);
				// DialogBoxWithRefresh("", res);

			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();

				else {
					// DialogBox("errorr.. ", ex.getMessage());
					Log.e(ex.getMessage(), ex.getMessage());
				}
			}

		}
	}

	private class GetAccountName extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(
				CashTransfer.this);

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
						OPERATION_ACCNAME);
				request.addProperty("AccNo", params[0].toString());

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);
				Log.d("SOAP_ADDRESS", SOAP_ADDRESS);
				Log.d("My  request", request.toString());
				httpTransport.call(SOAP_ACTION_ACCNAME, envelope);
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
					tvToAccName.setError("No such account");
				}
				balEnquiryArray = result.split(":::");
				
				// balEnquiryArray = new String[1][2];
			
				tvToAccName.setText(balEnquiryArray[0]);
				RecepientPhone = balEnquiryArray[1];
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
	
}
