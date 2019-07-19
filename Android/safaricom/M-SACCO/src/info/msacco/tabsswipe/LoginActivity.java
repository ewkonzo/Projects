package info.msacco.tabsswipe;

import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

import java.io.InputStream;
import java.util.List;

import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.telephony.SmsManager;
import android.telephony.TelephonyManager;
import android.text.Html;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.msacco.safaricom_sacco.R;

public class LoginActivity extends Activity {
	Button btnLogin;
	Button btnLinkToRegister;
	EditText inputMobile;
	EditText inputPin;
	TextView loginErrorMsg;
	String mPhoneNumber;
	SharedPreferences app_preferences;
	HttpPost httppost;
	HttpClient httpclient;
	List<NameValuePair> nameValuePairs;
	HttpResponse response;
	InputStream inputStream;
	StringBuffer buffer;
	byte[] data;
	public static final String imeipref = "imeiKey";
	SharedPreferences sharedpreferences;
	public static final String MyPREFERENCES = "MyPrefs";
	private boolean internetConnectionStatus = false;

	String msisdn;
	String pin;
	String strCorporateNo;
	String message;
	String strTelephoneNo;
	String IMEI;
	String CorporateNo;

	String NAMESPACE = "http://tempuri.org/";
	String URL = "";
	/*
	 * String SOAP_ACTION_LOGIN =
	 * "http://tempuri.org/AuthenticateUserSAFTesting"; String METHOD_NAME_LOGIN
	 * = "AuthenticateUserSAFTesting";
	 */

	String SOAP_ACTION_LOGIN = "http://tempuri.org/Login";
	String METHOD_NAME_LOGIN = "Login";

	String SOAP_ACTION_VERIFY = "http://tempuri.org/VerifyTelNo";
	String METHOD_NAME_VERIFY = "VerifyTelNo";

	String SOAP_ACTION_CORPORATE = "http://tempuri.org/GetCorporateNo";
	String METHOD_NAME_CORPORATE = "GetCorporateNo";

	String SOAP_ACTION_TELEPHONENO = "http://tempuri.org/GetTelephoneNo";
	String METHOD_NAME_TELEPHONENO = "GetTelephoneNo";

	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.login);

		setTitle(Html.fromHtml("<b>  LOGIN    </b>"));
		URL = Configuration.getURL();

		Configuration config = new Configuration();
		config.setTelephoneNo(getMyPhoneNO());
		URL = Configuration.getURL();
		CorporateNo = Configuration.getCorporateNo();
		
		// Shared preferences
		SharedPreferences preferences = PreferenceManager
				.getDefaultSharedPreferences(this);
		String restoredimeiKey = preferences.getString("imeiKey", "");
		String termsKey = preferences.getString("termsKey", "");
		String registrationKey = preferences.getString("registrationKey", "");
		String verificationKey = preferences.getString("verificationcodeKey",
				"");

		if (termsKey == null || termsKey == "") {
			Intent StartPageScreen = new Intent(getApplicationContext(),
					StartPage.class);
			StartPageScreen.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(StartPageScreen);
			finish();
		} else if (registrationKey == null || registrationKey == "") {
			Intent StartPageScreen = new Intent(getApplicationContext(),
					Line_Registration.class);
			StartPageScreen.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(StartPageScreen);
			finish();
		} else if (verificationKey == null || verificationKey == "") {
			Intent StartPageScreen = new Intent(getApplicationContext(),
					ConfirmSMS.class);
			StartPageScreen.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(StartPageScreen);
			finish();
		}

		inputPin = (EditText) findViewById(R.id.loginPassword);
	}

	// Function Login
	public void FuncLogin(View view) {

		btnLogin = (Button) findViewById(R.id.btnLogin);
		pin = inputPin.getText().toString();

		if (pin.equals("") || pin == null) {
			Toast.makeText(LoginActivity.this, "Enter your PIN",
					Toast.LENGTH_LONG).show();
		} else {
			msisdn = getMyPhoneNO();

			// ************ set PIN and Phone to session ********//

			SharedPreferences preferences = PreferenceManager
					.getDefaultSharedPreferences(LoginActivity.this);
			SharedPreferences.Editor editor = preferences.edit();
			editor.putString("pinKey", pin);
			editor.putString("phoneKey", msisdn);
			editor.commit();

			// ************ set PIN to session ********//

			internetConnectionStatus = new CheckInternetConnection(
					LoginActivity.this).isConnectingToInternet();
			if (internetConnectionStatus) {
				// call verify method
				new VerifyPhone().execute(new String[] { msisdn, CorporateNo });
			} else {
				DialogBox("Internet Connection", "No internet connection!");
			}
		}
	}

		// GetCorporateNo
	private class GetCorporateNo extends AsyncTask<String, Integer, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				LoginActivity.this);

		@Override
		protected void onPreExecute() {

			this.dialog.setMessage("Getting your account details...");
			this.dialog.show();

		}

		@Override
		protected String doInBackground(String... urls) {
			String ress = null;

			SoapObject request = new SoapObject(NAMESPACE,
					METHOD_NAME_CORPORATE);
			request.addProperty("strTelephoneNo", msisdn);

			SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
					SoapEnvelope.VER11);

			envelope.dotNet = true;
			envelope.setOutputSoapObject(request);
			HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);

			try {
				androidHttpTransport.call(SOAP_ACTION_CORPORATE, envelope);

				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;

				} else {
					SoapObject resultsRequestSOAP = (SoapObject) envelope.bodyIn;

					int n = resultsRequestSOAP.getPropertyCount();

					strCorporateNo = String.valueOf(
							resultsRequestSOAP.getProperty(n - 1)).trim();

					return strCorporateNo;
				}
			} catch (Exception e) {
				if (e.getMessage() == null) {
					e.printStackTrace();
					ress = "Error... Unable to acquire details.";
				} else {
					ress = "Error..." + e.getMessage();
				}
			}

			// Load List

			return strCorporateNo;
		}

		@Override
		protected void onPostExecute(String result) {
			try {
				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
				}

				strCorporateNo = result;

				Configuration config = new Configuration();
				config.setTelephoneNo(msisdn);
				config.setCorporateNo(strCorporateNo);
				config.setPin(pin);

				// new GetTelephoneNo().execute(new String[] { IMEI, "" });
				// new GetCorporateNo().execute(new String[] { msisdn, "" });

				// Launch Home Screen
				Intent HomeScreen = new Intent(getApplicationContext(),
						HomeActivity.class);
				// Close all views before launching Dashboard
				HomeScreen.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
				// HomeScreen.putExtras(bundle);
				startActivity(HomeScreen);
				// Close Login Screen
				finish();

			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {

				}
			}
		}
	}

	// GetTelephoneNo
	private class GetTelephoneNo extends AsyncTask<String, Integer, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				LoginActivity.this);

		@Override
		protected void onPreExecute() {

			// this.dialog.setMessage("Getting Account Details...");
			// this.dialog.show();

			this.dialog.setMessage("Verifying your PIN...");
			this.dialog.show();

		}

		@Override
		protected String doInBackground(String... urls) {
			String ress = null;

			// String IMEI=getIMEI();

			SoapObject request = new SoapObject(NAMESPACE,
					METHOD_NAME_TELEPHONENO);
			request.addProperty("strIMEI", IMEI);

			SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
					SoapEnvelope.VER11);

			envelope.dotNet = true;
			envelope.setOutputSoapObject(request);
			HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);

			try {
				androidHttpTransport.call(SOAP_ACTION_TELEPHONENO, envelope);
				// SoapObject resultsRequestSOAP = (SoapObject) envelope.bodyIn;

				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;

				} else {
					SoapObject resultsRequestSOAP = (SoapObject) envelope.bodyIn;

					int n = resultsRequestSOAP.getPropertyCount();

					strTelephoneNo = String.valueOf(
							resultsRequestSOAP.getProperty(n - 1)).trim();

					return strTelephoneNo;
				}
			} catch (Exception e) {
				if (e.getMessage() == null) {
					e.printStackTrace();
					ress = "Error... Unable to acquire details.";
				} else {

					ress = "Error..." + e.getMessage();
				}
			}

			// Load List

			return strTelephoneNo;
		}

		@Override
		protected void onPostExecute(String result) {
			try {
				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
				}

				msisdn = result;

			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {

				}
			}
		}
	}

	public String getMobileNumber() {

		TelephonyManager telephonyManager = (TelephonyManager) this
				.getSystemService(Context.TELEPHONY_SERVICE);

		String strMobileNumber = telephonyManager.getLine1Number();

		// Note : If the phone is dual sim, get the second number using :

		// String strMobileNumber = telephonyManager.getSimState();

		return strMobileNumber;
	}
	
	private String getMyPhoneNO() {
		SharedPreferences preferences = PreferenceManager
				.getDefaultSharedPreferences(LoginActivity.this);
		String yourNumber = preferences.getString("telephoneKey", "");
		return yourNumber;
	}
	
	private class VerifyPhone extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				LoginActivity.this);

		@Override
		protected void onPreExecute() {

			this.dialog.setMessage("Verifying Phone Details...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(String... params) {
			//
			SoapObject resultsRequestSOAP = null;
			String result = null;
			try {

				SoapObject request = new SoapObject(NAMESPACE,
						METHOD_NAME_VERIFY);
				request.addProperty("strTelephoneNo", params[0].toString());
				request.addProperty("CorporateNo", params[1].toString());

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(URL);

				httpTransport.call(SOAP_ACTION_VERIFY, envelope);
				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;

				} else {
					resultsRequestSOAP = (SoapObject) envelope.bodyIn;

					int n = resultsRequestSOAP.getPropertyCount();
					result = resultsRequestSOAP.getProperty(n - 1).toString();

					// return result;
				}

			} catch (Exception e) {

			}
			return result;

		}

		@Override
		protected void onPostExecute(String res) {
			if (this.dialog.isShowing()) {
				this.dialog.dismiss();
			}
			String myresult = res;
			if (myresult.equalsIgnoreCase("true")) {
				try {

					// Shared preferences
					SharedPreferences preferences = PreferenceManager
							.getDefaultSharedPreferences(LoginActivity.this);
					String restoredPhoneKey = preferences.getString("phoneKey",
							"");
					String restoredPINNo = preferences.getString("pinKey", "");

					new LoginTask().execute(new String[] { restoredPhoneKey,
							restoredPINNo });

				} catch (Exception ex) {

					if (ex.getMessage() == null)
						ex.printStackTrace();
					else {
					}
				}
			} else {
				DialogBox(
						"Phone No Failed",
						"Sorry, we do not recognize your phone number. Register for M-sacco in our offices");
			}

		}
	}

	private class LoginTask extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				LoginActivity.this);

		@Override
		protected void onPreExecute() {
			this.dialog.setMessage("Verifying your PIN...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(String... params) {
			//
			SoapObject resultsRequestSOAP = null;
			String result = null;
			try {

				SoapObject request = new SoapObject(NAMESPACE,
						METHOD_NAME_LOGIN);
				request.addProperty("strTelephoneNo", params[0].toString());
				request.addProperty("strPassword", params[1].toString());

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(URL);
				httpTransport.call(SOAP_ACTION_LOGIN, envelope);
				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;

				} else {
					resultsRequestSOAP = (SoapObject) envelope.bodyIn;

					int n = resultsRequestSOAP.getPropertyCount();

					result = resultsRequestSOAP.getProperty(n - 1).toString();
					resultsRequestSOAP = (SoapObject) resultsRequestSOAP
							.getProperty(n - 1);
					// return result;
				}

			} catch (Exception e) {
			}
			return result;

		}

		@Override
		protected void onPostExecute(String res) {

			if (this.dialog.isShowing()) {
				this.dialog.dismiss();
			}

			String myresult = res;

			if (myresult.equalsIgnoreCase("true")) {
				try {

					Intent HomeScreen = new Intent(getApplicationContext(),
							HomeActivity.class);
					// Close all views before launching Dashboard
					HomeScreen.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
					// HomeScreen.putExtras(bundle);
					startActivity(HomeScreen);
					// Close Login Screen
					finish();

					// new GetTelephoneNo().execute(new String[] { IMEI, "" });
				} catch (Exception ex) {

					if (ex.getMessage() == null)
						ex.printStackTrace();
					else {
					}
				}
			} else if (myresult.equalsIgnoreCase("wrongpin")) {
				DialogBox("Login Failed",
						"Verification Failed. Please ensure you input correct PIN");
			} else {
				DialogBox("Login Failed",
						"System error, please try again later");
			}
		}
	}

	@SuppressWarnings("deprecation")
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

	private void savePreferences(String key, String value) {
		SharedPreferences sharedPreferences = PreferenceManager
				.getDefaultSharedPreferences(this);
		Editor editor = sharedPreferences.edit();
		editor.putString(key, value);
		editor.commit();
	}

}
