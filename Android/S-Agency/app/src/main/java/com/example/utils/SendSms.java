package com.example.utils;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;

public class SendSms extends Activity  {
	private static final String SOAP_ACTION_SMS = "http://tempuri.org/sendSms";
	private static final String OPERATION_SMS = "sendSms";
	
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	
	
	private static String SOAP_ADDRESS_TWO = Configuration.getURL_TWO();
	
	
	public static Void SendAgentSms(String PhoneNo, String Text)
	{
		
		new SendMySms().execute(new String[] { PhoneNo,Text });
		return null;		
		
	}
	
	private static class SendMySms extends AsyncTask<String, Void, Void> {
		//private final ProgressDialog dialog = new ProgressDialog();

		@Override
		protected void onPreExecute() {
			// Log.d("got here point 2", "yes");
			//this.dialog.setMessage("Please wait...");
			//this.dialog.show();
		}

		@Override
		protected Void doInBackground(String... params) {
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
					//Log.d("WS", String.valueOf(resultsRequestSOAP));

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
			return null;

		}

		@Override
		protected void onPostExecute(Void res) {
				
			try {				

						

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
}
