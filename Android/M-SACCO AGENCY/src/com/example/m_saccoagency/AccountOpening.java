package com.example.m_saccoagency;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import com.example.utils.Configuration;

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
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class AccountOpening extends Activity {
	
	private EditText EtAccName, EtNationalID, EtTelNo, EtSociety, EtMemberNo, EtAmount;
	private Button BtnCancel, BtnConfirm;
	String AccName, NationaID, TelNo, Society,MemberNo,Amount;
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = "";
	private static final String SOAP_ACTION = "http://tempuri.org/AccountOpening";
	private static final String OPERATION = "AccountOpening";
	String storedAgentCode = "";
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
		SOAP_ADDRESS = Configuration.getURL();
		
		SharedPreferences preferences = PreferenceManager
				.getDefaultSharedPreferences(this);		
		 storedAgentCode = preferences.getString("agentKey", "");
		
		BtnCancel.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(AccountOpening.this,
						AgencyListActivity.class);
				startActivity(intent);
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
				
				if(AccName.equals("")|| AccName == null){
					EtAccName.setError("This field cannot be null");
				} else if(NationaID.equals("")|| NationaID == null){
					EtNationalID.setError("This field cannot be null");
				}else if(TelNo.equals("")|| TelNo == null){
					EtTelNo.setError("This field cannot be null");
				}else if(Society.equals("")|| Society== null){
					EtSociety.setError("This field cannot be null");
				}else if(MemberNo.equals("")|| MemberNo==null){
					EtMemberNo.setError("This field cannot be null");
				}else if(Amount.equals("")||Amount == null){
					EtAmount.setError("This field cannot be null");
				}else {
					new OpenAccount().execute(new String[] { AccName,NationaID,TelNo,Society,MemberNo,
						Amount, storedAgentCode});
				}
			}
		});
	}

	private class OpenAccount extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				AccountOpening.this);

		@Override
		protected void onPreExecute() {
			// Log.d("got here point 2", "yes");
			this.dialog.setMessage("Processing request...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(String... params) {
			//

			String result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION);
				request.addProperty("AccName", params[0].toString());
				request.addProperty("NationalID", params[1].toString());
				request.addProperty("TelNo", params[2].toString());
				request.addProperty("Society", params[3].toString());
				request.addProperty("MemberNo", params[4].toString());
				request.addProperty("Amount", params[5].toString());
				request.addProperty("AgentCode", params[6].toString());
				

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);
				Log.d("My  request", request.toString());
				httpTransport.call(SOAP_ACTION, envelope);
				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;
					Log.i("Sent Request", str);
				} else {
					SoapObject resultsRequestSOAP = (SoapObject) envelope.bodyIn;
					Log.d("WS", String.valueOf(resultsRequestSOAP));

					int n = resultsRequestSOAP.getPropertyCount();
					Log.d("Count", String.valueOf(n));
					Log.d("Returned Value", String.valueOf(resultsRequestSOAP
							.getProperty(n - 1)));

					if (n > 0) {
						result = String.valueOf(resultsRequestSOAP
								.getProperty(n - 1));
					} else {
						result = "Request not sent.Please check your internet connection.";
					}
					return result;
				}
			} catch (Exception e) {
				e.getMessage().toString();
			}
			return result;
		}

		@Override
		protected void onPostExecute(String res) {
			try {

				// Log.i("onPostExecute", res);

				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
				}
				if(res.equalsIgnoreCase("true")){
					DialogBoxWithRefresh("Account Opening", "Successful!");
				}else if(res.equalsIgnoreCase("false")) {
					DialogBoxWithRefresh("System Error", "Sorry, there is a system error. Please try later");
				}else {
					DialogBoxWithRefresh("Unexpected Error", res);
				}

			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {
					Log.i(ex.getMessage(), ex.getMessage());
				}
			}
			
			//new getMyBeneficiaries().execute(new String[] { strTelephoneNo });
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
