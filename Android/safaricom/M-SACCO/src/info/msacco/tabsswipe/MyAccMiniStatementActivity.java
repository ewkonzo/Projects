package info.msacco.tabsswipe;

import info.msacco.actionbar.model.MyAccMiniStatementDataModel;
import info.msacco.tabsswipe.adapter.MyAccMiniStatementListAdapter;
import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

import java.util.ArrayList;
import java.util.List;

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
import android.widget.ListView;
import android.widget.TextView;

import com.msacco.safaricom_sacco.R;

public class MyAccMiniStatementActivity extends Activity {

	/** Called when the activity is first created. */
	private static final String SOAP_ACTION = "http://tempuri.org/GetMinistatement";
	private static final String OPERATION_NAME = "GetMinistatement";
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = null;
	private boolean internetConnectionStatus = false;

	// Store split data from Server
	private String[][] miniStmtArray;

	private String strTelephoneNo = null;
	private HomeActivity home;
	private List<String> miniStmtFromServer;
	private ListView miniStmtListv;
	private List<String> miniStmtDate;
	private List<String> miniStmtDesc;
	private List<String> MiniStmtAmt;

	TextView date, desc, amount;

	private MyAccMiniStatementListAdapter adapter;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.mini_statement_fragment);
		// getActionBar().setTitle("Mini Statement");
		miniStmtFromServer = new ArrayList<String>();

		Configuration cfg = new Configuration();
		cfg.setTelephoneNo(getMyPhoneNO());
		strTelephoneNo = cfg.getTelephoneNo();
		SOAP_ADDRESS = cfg.getURL();

		date = (TextView) findViewById(R.id.dateTitle);
		desc = (TextView) findViewById(R.id.DescTitle);
		amount = (TextView) findViewById(R.id.amountTitle);

		// Call to function that initiates a getMinistatement asynchronous task.

		internetConnectionStatus = new CheckInternetConnection(
				MyAccMiniStatementActivity.this).isConnectingToInternet();
		if (internetConnectionStatus) {
			try {
				new getMiniStatement().execute(strTelephoneNo);
			} catch (Exception e) {
				// noInternetConnAlert("Internet connection lost!");
			}
		} else {
			// noInternetConnAlert("No internet connection!");
		}
	}

	// Split data returned from Server
	public void splitArray(List<String> stmt) {
		// Format the Amount returned

		miniStmtDate = new ArrayList<String>();
		miniStmtDesc = new ArrayList<String>();
		MiniStmtAmt = new ArrayList<String>();

		miniStmtArray = new String[miniStmtFromServer.size()][3];
		for (int i = 0; i < miniStmtFromServer.size(); i++) {
			miniStmtArray[i] = (miniStmtFromServer.get(i)).split(":::");
			miniStmtDate.add(miniStmtArray[i][0]);
			miniStmtDesc.add(miniStmtArray[i][1]);

			/*
			 * if(Double.parseDouble(miniStmtArray[i][2])<0.0) { Double
			 * minstmt=Double.parseDouble(miniStmtArray[i][2])*-1;
			 * MiniStmtAmt.add(minstmt.toString()); } else {
			 */
			MiniStmtAmt.add(miniStmtArray[i][2]);
			// }
		}

		// Call Method to insert the data into local database.
		displayMiniStatemment();
	}

	// Put data returned from Server into a listView.
	public void displayMiniStatemment() {
		if (!miniStmtFromServer.isEmpty()) {
			date.setText("DATE");
			desc.setText("DESCRIPTION");
			amount.setText("AMOUNT");
		}

		miniStmtListv = (ListView) findViewById(R.id.myAccMiniStatementList);

		ArrayList<MyAccMiniStatementDataModel> miniStmtDatModel = new ArrayList<MyAccMiniStatementDataModel>();
		for (int i = 0; i < miniStmtFromServer.size(); i++) {

			MyAccMiniStatementDataModel mdl = new MyAccMiniStatementDataModel(
					miniStmtDate.get(i), miniStmtDesc.get(i),
					MiniStmtAmt.get(i));
			miniStmtDatModel.add(mdl);
		}
		adapter = new MyAccMiniStatementListAdapter(this, miniStmtDatModel);
		miniStmtListv.setAdapter(adapter);

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
	private class getMiniStatement extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(
				MyAccMiniStatementActivity.this);
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
				// connTimeout = true;
			}
			return result;
		}

		@Override
		protected void onPostExecute(SoapObject res) {

			if (res == null) {
				noInternetConnAlert("Sorry,an error occured while connecting to the server.");
			} else if (res.getPropertyCount() > 0) {
				if(res.getPropertyCount()==1 && res.getProperty(0).toString().equals("00"))
				{
					noInternetConnAlert("Sorry,you have insufficient funds to use this service");
				}
				else{
				for (int i = 0; i < res.getPropertyCount(); i++) {
					miniStmtFromServer.add(res.getProperty(i).toString());
				}
				// display Member infomation in a listView.
				splitArray(miniStmtFromServer);
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
				.getDefaultSharedPreferences(MyAccMiniStatementActivity.this);
		String yourNumber = preferences.getString("telephoneKey", "");
		return yourNumber;
	}
}
