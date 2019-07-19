package info.msacco.tabsswipe;

import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;
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
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import com.msacco.safaricom_sacco.R;

public class MyAccTransactWithdrawActivity extends Activity implements
		OnItemSelectedListener, OnClickListener {

	private Button onWithdrawToMyPhoneBtnClicked;
	private Spinner spinner;
	private static String SOAP_ADDRESS = null;
	private String strTelephoneNo = null;

	private static final String SOAP_ACTION = "http://tempuri.org/GetMyFOSAAccounts";
	private static final String OPERATION_NAME = "GetMyFOSAAccounts";

	private static final String SECOND_SOAP_ACTION = "http://tempuri.org/WithdrawCash";
	private static final String SECOND_OPERATION_NAME = "WithdrawCash";

	private static final String THIRD_SOAP_ACTION = "http://tempuri.org/WithdrawStatus";
	private static final String THIRD_OPERATION_NAME = "WithdrawStatus";

	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private boolean internetConnectionStatus = false;
	private EditText WithdrawAmount;
	private String AmountToWithdraw;
	private String SelectedAccount;

	private String requestDate = null;

	List<String> AccountsArrayList;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.withdraw);

		AccountsArrayList = new ArrayList<String>();
		spinner = (Spinner) findViewById(R.id.myAccTransactWithdrawMyPhoneSelAccSpinner);
		WithdrawAmount = (EditText) findViewById(R.id.myAccTransactWithdrawToMyPhoneAmtEdtxt);

		Configuration cfg = new Configuration();
		cfg.setTelephoneNo(getMyPhoneNO());
		strTelephoneNo = cfg.getTelephoneNo();
		SOAP_ADDRESS = Configuration.getURL();

		new getMyAccounts().execute(new String[] { strTelephoneNo });

		onWithdrawToMyPhoneBtnClicked = (Button) findViewById(R.id.myAccTransactWithdrawToMyPhoneBtn);

		onWithdrawToMyPhoneBtnClicked.setOnClickListener(this);

		spinner.setOnItemSelectedListener(this);

	}

	public void setSpinnerData() {
		// Create an ArrayAdapter using the string array and a default spinner
		// layout
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
				R.layout.spinner_selected_item_template, AccountsArrayList);

		// Specify the layout to use when the list of choices appears
		adapter.setDropDownViewResource(R.layout.spinner_items_template);

		// Apply the adapter to the spinner
		spinner.setAdapter(adapter);

		spinner.setOnItemSelectedListener(this);
	}

	private class getMyAccounts extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(
				MyAccTransactWithdrawActivity.this);

		@Override
		protected void onPreExecute() {
			/*
			 * this.dialog.setMessage("Sending Message..."); this.dialog.show();
			 */
		}

		@Override
		protected SoapObject doInBackground(String... urls) {
			//

			SoapObject result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION_NAME);
				request.addProperty("strTelephoneNo", strTelephoneNo);
				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);

				httpTransport.call(SOAP_ACTION, envelope);

				result = (SoapObject) envelope.getResponse();
				return result;
			} catch (Exception e) {
				e.getMessage().toString();
			}
			return result;
		}

		@Override
		protected void onPostExecute(SoapObject res) {
			try {

				for (int i = 0; i < res.getPropertyCount(); i++) {
					AccountsArrayList.add(res.getProperty(i).toString());
				}

				setSpinnerData();

			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {
					Toast.makeText(MyAccTransactWithdrawActivity.this,
							"Error....: " + ex.getMessage(), Toast.LENGTH_LONG)
							.show();
				}
			}
		}
	}

	public void onItemSelected(AdapterView<?> parent, View view, int pos,
			long id) {
		SelectedAccount = spinner.getSelectedItem().toString();
	}

	public void onNothingSelected(AdapterView<?> parent) {
		// Another interface callback
	}

	@SuppressWarnings("unchecked")
	@Override
	public void onClick(View view) {
		if (WithdrawAmount.getText().toString().equals("")
				|| WithdrawAmount.getText().toString() == null) {
			alert("Please enter amount.");
		} else {

			DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface dialog, int which) {
					switch (which) {
					case DialogInterface.BUTTON_POSITIVE:
						// Yes button clicked
						internetConnectionStatus = new CheckInternetConnection(
								MyAccTransactWithdrawActivity.this)
								.isConnectingToInternet();
						if (internetConnectionStatus) {

							try {

								new WithdrawCash()
										.execute(setRequestParameters());
							} catch (Exception e) {
								alert("Error while connecting to server!");
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

			AlertDialog.Builder builder = new AlertDialog.Builder(this);
			builder.setMessage(
					"Withdraw ksh " + WithdrawAmount.getText().toString()
							+ " ?")
					.setPositiveButton("Yes", dialogClickListener)
					.setNegativeButton("No", dialogClickListener).show();

		}
	}

	@SuppressWarnings("unchecked")
	public void CallWithdrawClass() {

		try {
			new WithdrawCash().execute(setRequestParameters()).get(5000,
					TimeUnit.MILLISECONDS);
		} catch (Exception e) {
			alert("An error has occured while processing your request!");
			e.printStackTrace();
		}
	}

	// Put all data for requesting a loan into an arrayList.
	public ArrayList<String> setRequestParameters() {
		Calendar c = Calendar.getInstance();
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM/dd-hh.mm.ss");
		requestDate = sdf.format(c.getTime());
		AmountToWithdraw = WithdrawAmount.getText().toString();

		ArrayList<String> requestData = new ArrayList<String>();
		requestData.add(strTelephoneNo);
		requestData.add(AmountToWithdraw);
		requestData.add(requestDate);
		requestData.add(SelectedAccount);
		return requestData;
	}

	// Withdraw cash class
	private class WithdrawCash extends
			AsyncTask<ArrayList<String>, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				MyAccTransactWithdrawActivity.this);

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
						SECOND_OPERATION_NAME);
				request.addProperty("strTelephoneNo", params[0].get(0));
				request.addProperty("AmountToWithdraw", params[0].get(1));
				request.addProperty("requestDate", params[0].get(2));
				request.addProperty("SelectedAccount", params[0].get(3));

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);

				httpTransport.call(SECOND_SOAP_ACTION, envelope);
				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;

				} else {

					SoapObject resultsRequestSOAP = (SoapObject) envelope.bodyIn;

					int n = resultsRequestSOAP.getPropertyCount();

					if (String.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equalsIgnoreCase("true")) {

						result = "OK";

					} else if (String
							.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equalsIgnoreCase("pending")) {

						result = "Pending";

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
					statusAlert();
					WithdrawAmount.getText().clear();
				} else if (res.trim().equalsIgnoreCase("Pending")) {

					alert("Sorry, you have a pending withdraw transaction");
					WithdrawAmount.getText().clear();

				} else {
					Toast.makeText(
							MyAccTransactWithdrawActivity.this,
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

	private class WithdrawStatus extends
			AsyncTask<ArrayList<String>, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(
				MyAccTransactWithdrawActivity.this);

		@Override
		protected void onPreExecute() {

			this.dialog.setMessage("Sending Request ...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(ArrayList<String>... params) {
			//

			String result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						THIRD_OPERATION_NAME);
				request.addProperty("strTelephoneNo", params[0].get(0));
				request.addProperty("SelectedAccount", params[0].get(3));

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);

				httpTransport.call(THIRD_SOAP_ACTION, envelope);
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

		@SuppressWarnings("unchecked")
		@SuppressLint("DefaultLocale")
		@Override
		protected void onPostExecute(String res) {
			try {

				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
				}

				if (!res.toLowerCase().trim().equalsIgnoreCase("OK")) {

					new WithdrawCash().execute(setRequestParameters());

				} else {

					Toast.makeText(
							MyAccTransactWithdrawActivity.this,
							"Withdraw failed! You have a pending withdraw transaction",
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

	public void alert(String text) {
		Toast.makeText(MyAccTransactWithdrawActivity.this, text,
				Toast.LENGTH_LONG).show();
	}

	public void statusAlert() {
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				MyAccTransactWithdrawActivity.this);

		alertDialogBuilder
				.setMessage("Dear Customer,your request to withdraw KES :"
						+ AmountToWithdraw + " from Account "
						+ SelectedAccount
						+ " has been received and is being processed.");
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

	private String getMyPhoneNO() {
		SharedPreferences preferences = PreferenceManager
				.getDefaultSharedPreferences(MyAccTransactWithdrawActivity.this);
		String yourNumber = preferences.getString("telephoneKey", "");
		return yourNumber;
	}

}
