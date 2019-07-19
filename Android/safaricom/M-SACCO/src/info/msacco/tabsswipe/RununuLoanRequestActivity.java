package info.msacco.tabsswipe;

import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

import java.util.ArrayList;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.TimeoutException;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.msacco.safaricom_sacco.R;

@SuppressLint({ "SimpleDateFormat", "DefaultLocale" })
public class RununuLoanRequestActivity extends Activity implements
		OnClickListener {
	private static final String SOAP_ACTION_RUNUNU_LOAN = "http://tempuri.org/MsaccoLoanRequest";
	private static final String OPERATION__RUNUNU_LOAN = "MsaccoLoanRequest";

	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = null;

	private boolean internetConnectionStatus = false;
	private String strTelephoneNo = null;
	private EditText requestedAmt;
	private String requestedAmount;

	private Button onRequestLoanClicked;

	@Override
	public void onCreate(Bundle savedInstanceState) 
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.rununu_loans_request);

		Configuration cfg = new Configuration();
		cfg.setTelephoneNo(getMyPhoneNO());
		strTelephoneNo = cfg.getTelephoneNo();
		SOAP_ADDRESS = Configuration.getURL();

		requestedAmt = (EditText) findViewById(R.id.myLnsRequestAmtEdtxt);
		onRequestLoanClicked = (Button) findViewById(R.id.myLnsRequestApplyLoanBtn);

		onRequestLoanClicked.setOnClickListener(this);
	}

	// Put all data for requesting a loan into an arrayList.
	public ArrayList<String> setRequestParameters() {

		requestedAmount = requestedAmt.getText().toString();

		ArrayList<String> requestData = new ArrayList<String>();
		requestData.add(strTelephoneNo);
		requestData.add(requestedAmount);

		return requestData;
	}

	// Send Loan Request on a separate thread
	private class requestLoan extends
			AsyncTask<ArrayList<String>, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				RununuLoanRequestActivity.this);

		@Override
		protected void onPreExecute() {

			this.dialog.setMessage("Sending Request...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(ArrayList<String>... params) {
			//

			String result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION__RUNUNU_LOAN);
				request.addProperty("strTelephoneNo", params[0].get(0)
						.toString().trim());
				request.addProperty("requestedAmount", params[0].get(1)
						.toString().trim());

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);

				httpTransport.call(SOAP_ACTION_RUNUNU_LOAN, envelope);
				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;

				} else {
					SoapObject resultsRequestSOAP = (SoapObject) envelope.bodyIn;

					int n = resultsRequestSOAP.getPropertyCount();

					if (String.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equalsIgnoreCase("true")) {

						result = "OK";

					} else {
						alert("Request not send.A server error has occurred");
					}
					return result;
				}
			} catch (Exception e) {
				e.getMessage().toString();
			}
			return result;
		}

		@SuppressLint("DefaultLocale")
		@Override
		protected void onPostExecute(String res) {
			try {

				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
				}

				if (res.toLowerCase().trim().equalsIgnoreCase("OK")) {
					alert();
					requestedAmt.getText().clear();
				} else {
					Toast.makeText(
							RununuLoanRequestActivity.this,
							"Request not Sent, Please check your internet connection.",
							Toast.LENGTH_LONG).show();
				}

			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {

				}
			}
		}
	}

	@SuppressWarnings("unchecked")
	@SuppressLint("SimpleDateFormat")
	@Override
	public void onClick(View view) {
		if (requestedAmt.getText().toString().equals("")
				|| requestedAmt.getText().toString() == null) {
			alert("Please enter amount.");
		} else {

			DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface dialog, int which) {
					switch (which) {
					case DialogInterface.BUTTON_POSITIVE:
						// Yes button clicked
						internetConnectionStatus = new CheckInternetConnection(
								RununuLoanRequestActivity.this)
								.isConnectingToInternet();
						if (internetConnectionStatus) {
							try {
								new requestLoan().execute(
										setRequestParameters());
							} catch (Exception e) {
								e.printStackTrace();
							}
						} else {
							alert("Check your internet connection and try again");
						}

						break;

					case DialogInterface.BUTTON_NEGATIVE:
						// No button clicked
						// do nothing

						break;
					}
				}
			};

			AlertDialog.Builder builder = new AlertDialog.Builder(
					RununuLoanRequestActivity.this);
			builder.setMessage(
					"Request for RUNUNU Advance of KSH "
							+ requestedAmt.getText().toString() + " ?")
					.setPositiveButton("Yes", dialogClickListener)
					.setNegativeButton("No", dialogClickListener).show();
		}
	}

	public void alert(String text) {
		Toast.makeText(RununuLoanRequestActivity.this, text, Toast.LENGTH_LONG)
				.show();
	}

	public void alert() {
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				RununuLoanRequestActivity.this);

		alertDialogBuilder
				.setMessage("Dear Customer,your loan request has been received and is being processed.");
		// set negative button: No message
		alertDialogBuilder.setNegativeButton("OK",
				new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int id) {
						// cancel the alert box and put a Toast to the user
						dialog.cancel();
					}
				});
		AlertDialog alertDialog = alertDialogBuilder.create();
		// show alert
		alertDialog.show();
	}
	
	private String getMyPhoneNO() 
	{
		SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(RununuLoanRequestActivity.this);
		String yourNumber = preferences.getString("telephoneKey", "");
		return yourNumber;
	}
}
