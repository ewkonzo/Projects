package com.example.agency;

import java.util.ArrayList;
import java.util.HashMap;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends Activity implements OnClickListener {

	private EditText ETAgentCode, ETPassword;
	private Button BtnLogin;
	public String Pass, AgentCode;
	Intent intent = null;
	public static Agent agent;

	private ProgressDialog pDialog;
	// {"pin":"112014","agent_code":"AGN1","logged_in":false,"account_balance":0.0,"Pin_changed":false}
	// URL to get contacts JSON
	private static String url = "http://localhost:35051/Agency.asmx?op=Login";
	String pin ="112014";
	String agentCode = "AGN1";
	Boolean logged_in = false;
	Boolean pin_changed = false;
	double acc_bal = 0.0;
	final String body = String.format(
			"{\"pin\": \"%s\", \"agent_code\": \"%s\", \"logged_in\": \"%s\",\"account_balance\": \"%s\", \"Pin_changed\": \"%s\" }", pin,agentCode,logged_in,acc_bal, pin_changed );
	// myarray =
	// "{\"pin\":\"112014\",\"Telephone":"254723308410","agent_Account":"0101-001-00005","agent_Name":"SACCO NKUBU AGENCY","agent_code":"AGN1","logged_in":true,"account_balance":44502.0,"Pin_changed":true}"
	// contacts JSONArray
	JSONArray contacts = null;
	private static final String SOAP_ACTION = "http://tempuri.org/Login";
	private static final String OPERATION = "Login";

	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = "http://192.168.43.72:35051/Agency.asmx";
	
	// Hashmap for ListView
	ArrayList<HashMap<String, String>> contactList;
	ArrayList<String> myarray;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		ETAgentCode = (EditText) findViewById(R.id.et_agent_code);
		ETPassword = (EditText) findViewById(R.id.et_password);
		BtnLogin = (Button) findViewById(R.id.btn_login);

		contactList = new ArrayList<HashMap<String, String>>();
		myarray = new ArrayList<String>();
		BtnLogin.setOnClickListener(this);

		// myarray =
		// "{\"pin\":\"112014\",\"Telephone":"254723308410","agent_Account":"0101-001-00005","agent_Name":"SACCO NKUBU AGENCY","agent_code":"AGN1","logged_in":true,"account_balance":44502.0,"Pin_changed":true}"
		/*
		 * savedInstanceState.getBundle(PreferenceManager.
		 * getDefaultSharedPreferences(this).getString("Agency_Code", ""));
		 * if(!savedInstanceState.equals("")){
		 * 
		 * this.ETAgentCode.setText(savedInstanceState.toString()); }
		 */
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	public boolean onOptionsItemSelected(MenuItem item) {

//		Intent intent = null;
//		switch (item.getItemId()) {
//		case R.id.action_settings:
//			intent = new Intent(MainActivity.this, Settings.class);
//			break;
//
//		}
//		startActivity(intent);
		return true;
	}

	@Override
	public void onClick(View v) {
		// TODO Auto-generated method stub
		Pass = ETPassword.getText().toString();
		AgentCode = ETAgentCode.getText().toString();

		this.ETAgentCode.setError(null);
		this.ETPassword.setError(null);
		Log.e("Got here", "yehhhhs");
		if (AgentCode.equals("") || AgentCode == null) {

			// Toast("Please Enter Agent Code");
			this.ETAgentCode.setError("This cannot be null");

		} else if (Pass.equals("") || Pass == null) {

			this.ETPassword.setError("Please enter password");
			// Toast("Please Enter password");

		} else {

			//new UserLogin(agent).execute();
			// Intent intent = new Intent(this,AgencyListActivity.class);
			// startActivity(intent);
			Log.e("Got here ", "yes");
			//new AgencyLogin().execute(new String[] { body });
		}

	}

	public void Toast(String message) {

		Toast.makeText(getApplicationContext(), message, Toast.LENGTH_LONG)
				.show();

	}
	

	private class AgencyLogin extends
			AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				MainActivity.this);

		@Override
		protected void onPreExecute() {
			// Log.d("got here point 2", "yes");
			this.dialog.setMessage("Please wait...");
			this.dialog.show();
		}
 
		@Override
		protected String doInBackground(String... params) {
			//

			String result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION);
				request.addProperty("login", params[0].toString());
				
				
				Log.d("login",params[0].toString());				

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;  

				envelope.setOutputSoapObject(request);
				//Log.d("request 1", request.toString());
				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);
				Log.d("request ", request.toString());
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
				Toast(res);
				//DialogBox("", res);

			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {
					Log.i(ex.getMessage(), ex.getMessage());
				}
			}
		}
	}


	/**
	 * Async task class to get json by making HTTP call
	 * */
	private class UserLogin extends AsyncTask<Void, Void, Void> {

		public UserLogin(Agent agent) {
			// TODO Auto-generated constructor stub
		}

		@Override
		protected void onPreExecute() {
			super.onPreExecute();
			// Showing progress dialog
			pDialog = new ProgressDialog(MainActivity.this);
			pDialog.setMessage("Please wait...");
			pDialog.setCancelable(false);
			pDialog.show();

		}

		@Override
		protected Void doInBackground(Void... arg0) {
			// Creating service handler class instance
			ServiceHandler sh = new ServiceHandler();

			// Making a request to url and getting response
			String jsonStr = sh.makeServiceCall(url, ServiceHandler.GET);

			Log.d("Response: ", "> " + jsonStr);

			if (jsonStr != null) {
				try {
					JSONObject jsonObj = new JSONObject(jsonStr);

					// Getting JSON Array node
					// contacts = jsonObj.getJSONArray(TAG_CONTACTS);

					// looping through All Contacts
					for (int i = 0; i < contacts.length(); i++) {
						JSONObject c = contacts.getJSONObject(i);

						// tmp hashmap for single contact
						HashMap<String, String> contact = new HashMap<String, String>();

						// adding each child node to HashMap key => value

						// adding contact to contact list
						contactList.add(contact);
					}
				} catch (JSONException e) {
					e.printStackTrace();
				}
			} else {
				Log.e("ServiceHandler", "Couldn't get any data from the url");
			}

			return null;
		}

		@Override
		protected void onPostExecute(Void result) {
			super.onPostExecute(result);
			// Dismiss the progress dialog
			if (pDialog.isShowing())
				pDialog.dismiss();
			/**
			 * Updating parsed JSON data into ListView
			 * */
		}

	}
}
