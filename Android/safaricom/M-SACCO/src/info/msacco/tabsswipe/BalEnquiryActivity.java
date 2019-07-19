package info.msacco.tabsswipe;

import info.msacco.actionbar.model.AccBalEnquiryDataModel;
import info.msacco.tabsswipe.adapter.AccBalEnquiryListAdapter;
import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.TimeoutException;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

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
import android.widget.ListView;
import android.widget.TextView;

import com.msacco.safaricom_sacco.R;

public class BalEnquiryActivity extends Activity {

	/** Called when the activity is first created. */
	private static final String SOAP_ACTION = "http://tempuri.org/GetAccountBalanceSAFARICOM";
	private static final String OPERATION_NAME = "GetAccountBalanceSAFARICOM";
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = null;
	private boolean internetConnectionStatus = false;

	// Store split data from Server
	private String[][] accountsArray;

	private String strTelephoneNo = null;
	private List<String> accountsFromServer;
	private ListView accountsListv;
	private List<String> accountDescription;
	private List<String> accountNumber;
	private List<String> Balance;

	TextView desc, ballabel, amount;

	private AccBalEnquiryListAdapter adapter;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.acc_accts_bal);
		accountsFromServer = new ArrayList<String>();

		Configuration cfg = new Configuration();
		cfg.setTelephoneNo(getMyPhoneNO());
		strTelephoneNo = cfg.getTelephoneNo();
		SOAP_ADDRESS = Configuration.getURL();

		desc = (TextView) findViewById(R.id.b_account_name);
		ballabel = (TextView) findViewById(R.id.b_account_balance_label);
		amount = (TextView) findViewById(R.id.b_account_balance_value);

		internetConnectionStatus = new CheckInternetConnection(
				BalEnquiryActivity.this).isConnectingToInternet();
		if (internetConnectionStatus) {
			try {
				new getBalance().execute(strTelephoneNo);
			} catch (Exception e) {
				e.printStackTrace();
			}
		} else {
			noInternetConnAlert("No internet connection!");
		}
		accountDescription = new ArrayList<String>();
		accountNumber = new ArrayList<String>();
		Balance = new ArrayList<String>();

	}

	// Split data returned from Server
	public void splitArray(List<String> stmt) {
		// Format the Amount returned

		accountsArray = new String[accountsFromServer.size()][2];
		for (int i = 0; i < accountsFromServer.size(); i++) {
			accountsArray[i] = (accountsFromServer.get(i)).split(":::");
			accountDescription.add(accountsArray[i][0]);
			Balance.add(accountsArray[i][1]);
		}
		displayBalance();
	}

	// Put data returned from Server into a listView.
	public void displayBalance() {
		if (!accountsFromServer.isEmpty()) {
			// desc.setText("Item");
			// amount.setText("Balance");
		}

		accountsListv = (ListView) findViewById(R.id.list);

		ArrayList<AccBalEnquiryDataModel> dataModel = new ArrayList<AccBalEnquiryDataModel>();

		for (int i = 0; i < accountsFromServer.size(); i++) {

			AccBalEnquiryDataModel mdl = new AccBalEnquiryDataModel(
					accountDescription.get(i), "Balance:", Balance.get(i));
			dataModel.add(mdl);
		}
		adapter = new AccBalEnquiryListAdapter(this, dataModel);
		accountsListv.setAdapter(adapter);

	}

	@SuppressWarnings("deprecation")
	public void noInternetConnAlert(String text) {
		try {
			AlertDialog ad = new AlertDialog.Builder(this).create();
			ad.setCancelable(false);
			ad.setMessage(text);
			ad.setButton("OK", new DialogInterface.OnClickListener() {
				public void onClick(final DialogInterface dialog,
						final int which) {
					dialog.dismiss();
					Intent intent;
					intent = new Intent(getApplicationContext(),
							HomeActivity.class);
					// Close all views before launching Dashboard
					intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
					startActivity(intent);
				}
			});
			ad.show();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	// get Mini Statement on a separate thread
	private class getBalance extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(
				BalEnquiryActivity.this);
		private boolean connTimeout = false;

		@Override
		protected void onPreExecute() {

			this.dialog.setMessage("Please wait...");
			this.dialog.show();
		}

		@Override
		protected SoapObject doInBackground(String... urls) {
			//

			SoapObject result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION_NAME);
				request.addProperty("strTelephoneNo", urls[0].toString());

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
				connTimeout = true;
			}
			return result;
		}

		@Override
		protected void onPostExecute(SoapObject res) {

			if (connTimeout) {
				noInternetConnAlert("Connection timeout");
			} else if (res == null) {
				noInternetConnAlert("Sorry,an error occured while connecting to the server.");
			} else if (res.getPropertyCount() > 0) {
				if(res.getPropertyCount()==1 && res.getProperty(0).toString().equals("00"))
				{
					noInternetConnAlert("Sorry,you have insufficient funds to use this service");
				}
				else{
					for (int i = 0; i < res.getPropertyCount(); i++) {
						accountsFromServer.add(res.getProperty(i).toString());
					}
					// display Member infomation in a listView.
					splitArray(accountsFromServer);
				}
			} else {
				noInternetConnAlert("No data found");
			}

			if (this.dialog.isShowing()) {
				this.dialog.dismiss();
			}
		}
	}

	private String getMyPhoneNO() {
		SharedPreferences preferences = PreferenceManager
				.getDefaultSharedPreferences(BalEnquiryActivity.this);
		String yourNumber = preferences.getString("telephoneKey", "");
		return yourNumber;
	}
}
