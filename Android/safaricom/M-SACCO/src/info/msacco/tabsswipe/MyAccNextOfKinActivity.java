package info.msacco.tabsswipe;

import info.msacco.actionbar.model.NextOfKinDataModel;
import info.msacco.tabsswipe.adapter.NextOfKinListAdapter;
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
import android.widget.ListView;
import android.widget.TextView;

import com.msacco.safaricom_sacco.R;

public class MyAccNextOfKinActivity extends Activity {

	/** Called when the activity is first created. */
	private static final String SOAP_ACTION = "http://tempuri.org/NextofKin";
	private static final String OPERATION_NAME = "NextofKin";
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = null;
	private boolean internetConnectionStatus = false;

	// Store split data from Server
	private String[][] nxtkinArray;

	private String strTelephoneNo = "";
	private List<String> kinsFromServer;
	private ListView nextOfKinListv;

	private List<String> kin_name;
	private List<String> kin_rship;
	private List<String> kin_p_allocation;

	TextView name, relationship, allocation;

	private NextOfKinListAdapter adapter;

	@Override
	public void onCreate(Bundle savedInstanceState) 
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.next_of_kin);
		kinsFromServer = new ArrayList<String>();

		Configuration cfg = new Configuration();
		cfg.setTelephoneNo(getMyPhoneNO());
		strTelephoneNo = cfg.getTelephoneNo();
		SOAP_ADDRESS = Configuration.getURL();

		name = (TextView) findViewById(R.id.n_kin_name);
		relationship = (TextView) findViewById(R.id.n_kin_rship_value);
		allocation = (TextView) findViewById(R.id.n_kin_allocation_value);

		internetConnectionStatus = new CheckInternetConnection(
				MyAccNextOfKinActivity.this).isConnectingToInternet();
		if (internetConnectionStatus) 
		{
			try {
				new getNextOfKin().execute(strTelephoneNo);
			}
			catch (Exception e) {
				e.printStackTrace();
			}
		} else {
			noInternetConnAlert("No internet connection!");
		}
		kin_name = new ArrayList<String>();
		kin_rship = new ArrayList<String>();
		kin_p_allocation = new ArrayList<String>();

	}

	// Split data returned from Server
	public void splitArray(List<String> stmt) 
	{
		// Format the Amount returned

		nxtkinArray = new String[kinsFromServer.size()][4];
		for (int i = 0; i < kinsFromServer.size(); i++) {
			nxtkinArray[i] = (kinsFromServer.get(i)).split(":::");
			kin_name.add(nxtkinArray[i][0]);
			kin_rship.add(nxtkinArray[i][1]);
			kin_p_allocation.add(nxtkinArray[i][2]);
		}		
		displayNextofKin();
	}

	// Put data returned from Server into a listView.
	public void displayNextofKin() {
		if (!kinsFromServer.isEmpty()) {
		}

		nextOfKinListv = (ListView) findViewById(R.id.list_nkin);

		ArrayList<NextOfKinDataModel> dataModel = new ArrayList<NextOfKinDataModel>();

		for (int i = 0; i < kinsFromServer.size(); i++) {

			NextOfKinDataModel mdl = new NextOfKinDataModel(kin_name.get(i),
					kin_rship.get(i), kin_p_allocation.get(i));
			dataModel.add(mdl);
		}
		adapter = new NextOfKinListAdapter(this, dataModel);
		nextOfKinListv.setAdapter(adapter);

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
							MyAccountActivity.class);
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
	private class getNextOfKin extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(
				MyAccNextOfKinActivity.this);
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
			} else if (res.getPropertyCount() > 0) {
				for (int i = 0; i < res.getPropertyCount(); i++) {
					kinsFromServer.add(res.getProperty(i).toString());
				}
				// display Member infomation in a listView.
				splitArray(kinsFromServer);
			} else {
				noInternetConnAlert("No data found");
			}

			if (this.dialog.isShowing()) {
				this.dialog.dismiss();
			}
		}
	}
	
	private String getMyPhoneNO() 
	{
		SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(MyAccNextOfKinActivity.this);
		String yourNumber = preferences.getString("telephoneKey", "");
		return yourNumber;
	}
}
