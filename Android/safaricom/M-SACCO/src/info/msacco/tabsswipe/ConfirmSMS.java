package info.msacco.tabsswipe;

import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import com.msacco.safaricom_sacco.R;

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

public class ConfirmSMS extends Activity
{

	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	String METHOD_NAME_VERIFYCODE = "VerifySMSCode";
	String SOAP_ACTION_VERIFYCODE = "http://tempuri.org/VerifySMSCode";
	String verification_code ;
	EditText verification_textbox;
	String URL = "", CorporateNo = "", IMEI="";
	private boolean internetConnectionStatus = false;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) 
	{
		// TODO Auto-generated method stub
		URL = Configuration.getURL();
		CorporateNo = Configuration.getCorporateNo();
		IMEI = getIMEI();
		
		super.onCreate(savedInstanceState);		
		setTitle(Html.fromHtml("<b>  CODE VERIFICATION    </b>"));
		setContentView(R.layout.activity_confirm_sms);
		setTitle("SMS VERIFICATION");
			
	}
	
	@Override
	public void onBackPressed() 
	{
		// TODO Auto-generated method stub
		super.onBackPressed();
	}
		
	public void FuncVerification(View view) 
	{
	
		verification_textbox = (EditText) findViewById(R.id.verify);		
		verification_code = verification_textbox.getText().toString();		
		
		if(verification_code == null || verification_code == "")
		{
			Toast.makeText(ConfirmSMS.this, "Enter Verification Code",
					Toast.LENGTH_LONG).show();
		}		
		else if(verification_code.length() < 4)
		{
			Toast.makeText(ConfirmSMS.this, "Invalid Verification Code",
					Toast.LENGTH_LONG).show();
		}
		else
		{
			// retrieve phone number from session
			SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(ConfirmSMS.this);
			String restoredphoneNo = preferences.getString("telephoneKey", "");
			
			internetConnectionStatus = new CheckInternetConnection(ConfirmSMS .this).isConnectingToInternet();
			
			if (internetConnectionStatus) 
			{
			    new verifyCode().execute(new String[] { verification_code,restoredphoneNo, CorporateNo });	
			}
			else
			{
				DialogBox("Internet Connection", "No internet connection!");
			}
		}		
	}
		
	private class verifyCode extends AsyncTask<String, Void, String>
	{
		private final ProgressDialog dialog = new ProgressDialog(
				ConfirmSMS.this);
		
		@Override
		protected void onPreExecute() {
			this.dialog.setMessage(" Verifying Code...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(String... params) {
			
			SoapObject resultsRequestSOAP = null;
			String result = null;

			try 
			{

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,	METHOD_NAME_VERIFYCODE);
				request.addProperty("strSMSCode", params[0].toString());
				request.addProperty("strTelephoneNo", params[1].toString());
				request.addProperty("CorporateNo", params[2].toString());
							
				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);
				HttpTransportSE httpTransport = new HttpTransportSE(URL);
				
				httpTransport.call(SOAP_ACTION_VERIFYCODE, envelope);
				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;
				}
				else 
				{
					resultsRequestSOAP = (SoapObject) envelope.bodyIn;
					int n = resultsRequestSOAP.getPropertyCount();
					result = resultsRequestSOAP.getProperty(n - 1).toString();
				}
			}
			catch (Exception e)
			{
				
			}
									
			return result;			
				
		}
		
		@Override
		protected void onPostExecute(String res) {

			String myresult = res;
							if (myresult.equalsIgnoreCase("true")) {
				try 
				{
					//save IMEI TO preferences
					SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(ConfirmSMS.this);
					SharedPreferences.Editor editor = preferences.edit();
					editor.putString("imeiKeys", IMEI);
					editor.commit();
					//save IMEI TO preferences
					
					savePreferences("verificationcodeKey", "Code verified succesfully");
					
					Intent HomeScreen = new Intent(getApplicationContext(),	LoginActivity.class);
					HomeScreen.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
					startActivity(HomeScreen);
					finish();
					
				}
				catch(Exception ex)
				{
					
				}
			}	
			else
			{
				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
				}
				
				
				DialogBox
				(
						"VERIFICATION",
						"Invalid Code Entered");
			}
		}		
	}
	
	public String getIMEI() {
		TelephonyManager mngr = (TelephonyManager) this
				.getSystemService(Context.TELEPHONY_SERVICE);
		String imei = mngr.getDeviceId();
		return imei;
	}
	
	
	private void savePreferences(String key, String value) {

		SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(this);
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
