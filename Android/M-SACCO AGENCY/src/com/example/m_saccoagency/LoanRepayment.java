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

public class LoanRepayment extends Activity {

	private EditText EtNationalId, EtAmount;
	private TextView TvLoanNo, TvLoantype;
	private Button BtnCancel, BtnConfirm;
	private static String SOAP_ADDRESS = "";
	private boolean internetConnectionStatus = false;

	private static final String SOAP_ACTION = "http://tempuri.org/GetLoanDetails";
	private static final String OPERATION = "GetLoanDetails";
	
	private static final String SOAP_ACTION_LOAN = "http://tempuri.org/LoanRepayment";
	private static final String OPERATION_LOAN = "LoanRepayment";
	
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private String[] loanArray;
	String PhoneNo = "", IdNo = "", LoanNo = "", LoanType = "", Amount="";
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.loan_repayment);
		
		EtNationalId = (EditText)findViewById(R.id.lptxtnationalid);
		EtAmount = (EditText)findViewById(R.id.lptxtamount);
		TvLoanNo = (TextView)findViewById(R.id.lptxtloanno);
		TvLoantype = (TextView)findViewById(R.id.lptxtloantype);
		
		BtnCancel = (Button)findViewById(R.id.lpCancel);
		BtnConfirm = (Button)findViewById(R.id.lpConfirm);
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
							LoanRepayment.this).isConnectingToInternet();
					if (internetConnectionStatus) {
						new GetLoanDetails().execute(new String[] { nationalID });

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
				String NationalId = EtNationalId.getText().toString();
				Amount = EtAmount.getText().toString();
				
				
				if(NationalId.equals("") || NationalId == null){
					EtNationalId.setError("this field cannot be null");
				} else if(Amount.equals("")|| Amount == null){
					EtAmount.setError("this field cannot be null");
				} else {
					internetConnectionStatus = new CheckInternetConnection(
							LoanRepayment.this).isConnectingToInternet();
					if (internetConnectionStatus) {

						
						ConfirmationBox("Loan Repayment", PhoneNo, Amount);

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
				Intent intent = new Intent(LoanRepayment.this,
						AgencyListActivity.class);
				startActivity(intent);
			}
		});

	}
	public void ConfirmationBox(String TransType,
			final String PhoneNo, final String Amount) {

		LayoutInflater li = LayoutInflater.from(LoanRepayment.this);
		View promptsView = li.inflate(R.layout.confirmation_box, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				LoanRepayment.this);

		alertDialogBuilder.setView(promptsView);

		final TextView tvTranType = (TextView) promptsView
				.findViewById(R.id.cbtxttranstype);
		final TextView tvAccNo = (TextView) promptsView
				.findViewById(R.id.cbtxtaccountno);
		final TextView lblAccNo = (TextView) promptsView
				.findViewById(R.id.cblabelaccno);
		
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
		tvAccNo.setText(LoanNo);
		tvAmount2.setText(Amount);
		lblAccNo.setText("Loan No.");
		
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

	
		// set dialog message
		alertDialogBuilder
				.setCancelable(false)
				.setTitle("Client Confirmation")
				.setPositiveButton("OK", new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int id) {
						new RepayLoan().execute(new String[] {Amount,LoanNo, 
								 storedAgentCode,PhoneNo, IdNo  });
						
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

	private class GetLoanDetails extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(
				LoanRepayment.this);

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
					
					if(result.equalsIgnoreCase("none")){
						EtNationalId.setError("No active loans");
					} else {
						loanArray = result.split(":::");
						
						TvLoanNo.setText(loanArray[0]);
						LoanNo = loanArray[0];
						LoanType = loanArray[1];
						TvLoantype.setText(loanArray[1]);
						PhoneNo = loanArray[2];
						IdNo = loanArray[3];
						Log.d("More details", PhoneNo+" "+IdNo);
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

	private class RepayLoan extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				LoanRepayment.this);

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
						OPERATION_LOAN);
				request.addProperty("amount", params[0].toString());
				request.addProperty("LoanNo", params[1].toString());
				request.addProperty("Agentcode", params[2].toString());
				request.addProperty("telNo", params[3].toString());
				request.addProperty("idNo", params[4].toString());				
				
			
				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);
				Log.d("SOAP_ADDRESS", SOAP_ADDRESS);
				Log.d("My  request", request.toString());
				httpTransport.call(SOAP_ACTION_LOAN, envelope);
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
					//resultsRequestSOAP =  (SoapObject) resultsRequestSOAP.getProperty(n - 1);
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
			String myresult =res;
			Log.d("Myresult", myresult);
			if(myresult.equalsIgnoreCase("true")){
			try {

				String smstext = "Loan Repayment completed. \n Loan No: "
						+ LoanNo + " \n Amount: " + Amount;
				SendSms.SendAgentSms(PhoneNo, smstext);				
				DialogBoxWithRefresh("Loan Repayment", "Transaction successfull!");
			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {
					// DialogBox("errorr.. ", ex.getMessage());
					Log.e(ex.getMessage(), ex.getMessage());
				}
			}
			
			}				
			else {
				DialogBox("Failed!", "Loan Repayment failed! System is down");
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
