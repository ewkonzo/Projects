package info.msacco.tabsswipe;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import com.msacco.safaricom_sacco.R;
import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

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
import android.telephony.TelephonyManager;
import android.text.Html;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

public class Line_Registration extends Activity {

	EditText phone;
	String mobileNumber;
	private boolean internetConnectionStatus = false;
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	String METHOD_NAME_VERIFY = "VerifyTelNo";
	String METHOD_NAME_SMS = "SMSNotification";
	String METHOD_NAME_SMSCODE = "SaveSMSCode";
	String METHOD_NAME_SETIMEI = "setIMEI";
	String SOAP_ACTION_VERIFY = "http://tempuri.org/VerifyTelNo";
	String SOAP_ACTION_SMS = "http://tempuri.org/SMSNotification";
	String SOAP_ACTION_IMEI = "http://tempuri.org/setIMEI";
	String SOAP_ACTION_SMSCODE = "http://tempuri.org/SaveSMSCode";

	String URL = "", CorporateNo = "";
	String IMEI;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setTitle(Html.fromHtml("<b>  REGISTRATION    </b>"));
		setContentView(R.layout.activity_line_registration);
		Configuration config = new Configuration();

		URL = Configuration.getURL();
		CorporateNo = Configuration.getCorporateNo();

	}

	@Override
	public void onBackPressed() {
		// TODO Auto-generated method stub
		super.onBackPressed();
	}

	// function register phone number
	public void FuncRegister(View view) {

		phone = (EditText) findViewById(R.id.phoneNo);
		mobileNumber = phone.getText().toString();

		if (mobileNumber == null || mobileNumber == "") {
			Toast.makeText(Line_Registration.this, "Enter your Phone No",
					Toast.LENGTH_LONG).show();
		} else if (mobileNumber.length() < 10) {
			Toast.makeText(Line_Registration.this,
					"Phone No entered is incomplete", Toast.LENGTH_LONG).show();
		} else if (mobileNumber.startsWith("254")) {
			Toast.makeText(Line_Registration.this,
					"Please enter the correct format", Toast.LENGTH_LONG)
					.show();
		} else {
			internetConnectionStatus = new CheckInternetConnection(
					Line_Registration.this).isConnectingToInternet();
			if (internetConnectionStatus) {
				// verify if phone number is registered for MSACCO
				new VerifyPhone().execute(new String[] { mobileNumber,
						CorporateNo });

			} else {
				DialogBox("Internet Connection", "No internet connection!");
			}
		}
	}

	private class SendSMSNotification extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				Line_Registration.this);

		@Override
		protected void onPreExecute() {
			this.dialog.setMessage("Processing request...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(String... params) {

			SoapObject resultsRequestSOAP = null;
			String result = null;

			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						METHOD_NAME_SMS);
				request.addProperty("strTelephoneNo", params[0].toString());
				request.addProperty("message", params[1].toString());
				request.addProperty("corporateNO", params[2].toString());

				// ************ set phone number and IMEI to session ********//

				SharedPreferences preferences = PreferenceManager
						.getDefaultSharedPreferences(Line_Registration.this);
				SharedPreferences.Editor editor = preferences.edit();
				editor.putString("telephoneKey", "+254"
						+ params[0].toString().substring(1, 10));
				editor.putString("imeiKey", IMEI);
				editor.commit();

				// ************ set phone number and IMEI to session ********//

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);
				HttpTransportSE httpTransport = new HttpTransportSE(URL);

				httpTransport.call(SOAP_ACTION_SMS, envelope);
				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;
				} else {
					resultsRequestSOAP = (SoapObject) envelope.bodyIn;
					int n = resultsRequestSOAP.getPropertyCount();
					result = resultsRequestSOAP.getProperty(n - 1).toString();
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

					savePreferences("registrationKey", "Verification Code Sent");

					Intent HomeScreen = new Intent(getApplicationContext(),
							ConfirmSMS.class);
					HomeScreen.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
					startActivity(HomeScreen);
					finish();

				} catch (Exception ex) {
					DialogBox("ERROR", ex.toString());
				}

			} else {
				DialogBox("VERIFICATION",
						"Verification code not sent. Please try again");
			}
		}
	}

	private class VerifyPhone extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				Line_Registration.this);

		@Override
		protected void onPreExecute() {

			this.dialog.setMessage("Processing request...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(String... params) {

			SoapObject resultsRequestSOAP = null;
			String result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						METHOD_NAME_VERIFY);
				request.addProperty("strTelephoneNo", params[0].toString());
				request.addProperty("CorporateNo", params[1].toString());

				// ************ set phone number and IMEI to session ********//

				SharedPreferences preferences = PreferenceManager
						.getDefaultSharedPreferences(Line_Registration.this);
				SharedPreferences.Editor editor = preferences.edit();
				editor.putString("telephoneKey", params[0].toString());
				editor.putString("imeiKey", IMEI);
				editor.commit();

				// ************ set phone number and IMEI to session ********//

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

				}

			} catch (Exception e) {
			}
			return result;

		}

		@Override
		protected void onPostExecute(String res) {

			String myresult = res;

			if (myresult.equalsIgnoreCase("true")) {
				try {
					// Shared preferences
					SharedPreferences preferences = PreferenceManager
							.getDefaultSharedPreferences(Line_Registration.this);
					String restoredimeiKey = preferences.getString("imeiKey",
							"");
					String restoredphoneNo = preferences.getString(
							"telephoneKey", "");

					// SMS Verification Confirmation
					// generate a 4 digit integer 1000 <10000
					int myNo = (int) (Math.random() * 9000) + 1234;

					if (String.valueOf(myNo).length() > 4) {
						myNo = (int) (Math.random() * 9000);
					}

					SharedPreferences.Editor editor = preferences.edit();
					editor.putString("codeKey", String.valueOf(myNo));
					editor.commit();

					try {
						// SaveSMSCode
						new SaveSMSCode().execute(new String[] {
								String.valueOf(myNo), restoredphoneNo,
								CorporateNo });
					} catch (Exception ex) {
						DialogBox("VERIFICATION", ex.toString());
					}
				} catch (Exception ex) {

				}
			} else {
				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
				}

				DialogBox(
						"NOT REGISTERED",
						"Sorry, we do not recognize your phone number. Register for M-Sacco in our offices");
			}
		}
	}

	private class SaveSMSCode extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				Line_Registration.this);

		@Override
		protected void onPreExecute() {
			this.dialog.setMessage("Processing request...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(String... params) {

			SoapObject resultsRequestSOAP = null;
			String result = null;

			try {
				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						METHOD_NAME_SMSCODE);
				request.addProperty("strSMSCode", params[0].toString());
				request.addProperty("strTelephoneNo", params[1].toString());
				request.addProperty("CorporateNo", CorporateNo);

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);
				HttpTransportSE httpTransport = new HttpTransportSE(URL);

				httpTransport.call(SOAP_ACTION_SMSCODE, envelope);
				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;

				} else {
					resultsRequestSOAP = (SoapObject) envelope.bodyIn;
					int n = resultsRequestSOAP.getPropertyCount();
					result = resultsRequestSOAP.getProperty(n - 1).toString();
				}
			} catch (Exception e) {

			}

			return result;
		}

		@Override
		protected void onPostExecute(String result) {

			SharedPreferences preferences = PreferenceManager
					.getDefaultSharedPreferences(Line_Registration.this);
			String codeKey = preferences.getString("codeKey", "");
			String restoredphoneNo = preferences.getString("telephoneKey", "");

			String smsmessage = "Your Verification Code for Safaricom Sacco Mobile APP is "
					+ codeKey;

			new SendSMSNotification().execute(new String[] { restoredphoneNo,
					smsmessage, CorporateNo });

		}
	}

	private class RegisterIMEI extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				Line_Registration.this);

		@Override
		protected void onPreExecute() {
			this.dialog.setMessage("Processing request...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(String... params) {
			SoapObject resultsRequestSOAP = null;
			String result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						METHOD_NAME_SETIMEI);
				request.addProperty("strTelephoneNo", params[0].toString());
				request.addProperty("IMEI", params[1].toString());

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);

				envelope.dotNet = true;
				envelope.setOutputSoapObject(request);
				HttpTransportSE httpTransport = new HttpTransportSE(URL);

				httpTransport.call(SOAP_ACTION_IMEI, envelope);

				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;

				} else {
					resultsRequestSOAP = (SoapObject) envelope.bodyIn;

					int n = resultsRequestSOAP.getPropertyCount();
					result = resultsRequestSOAP.getProperty(n - 1).toString();

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
							LoginActivity.class);

					HomeScreen.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
					startActivity(HomeScreen);
					finish();
				} catch (Exception ex) {

					Toast.makeText(Line_Registration.this, ex.toString(),
							Toast.LENGTH_LONG).show();

				}
			} else {
				DialogBox("REGISTRATION",
						"Sorry, Phone no registration failed. Please contact our offices ");
			}
		}
	}

	public String getIMEI() {
		TelephonyManager mngr = (TelephonyManager) this
				.getSystemService(Context.TELEPHONY_SERVICE);
		String imei = mngr.getDeviceId();
		return imei;
	}

	public String replace(String str, int index, char replace) {
		if (str == null) {
			return str;
		} else if (index < 0 || index >= str.length()) {
			return str;
		}
		char[] chars = str.toCharArray();
		chars[index] = replace;
		return String.valueOf(chars);
	}

	private void savePreferences(String key, String value) {

		SharedPreferences sharedPreferences = PreferenceManager
				.getDefaultSharedPreferences(this);
		Editor editor = sharedPreferences.edit();
		editor.putString(key, value);
		editor.commit();

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

}
