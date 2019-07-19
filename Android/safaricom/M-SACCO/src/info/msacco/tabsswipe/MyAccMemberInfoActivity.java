package info.msacco.tabsswipe;

import info.msacco.actionbar.model.MyAccMemberInfoDataModel;
import info.msacco.tabsswipe.adapter.MSACCOLocalDb;
import info.msacco.tabsswipe.adapter.MyAccMemberInfoListAdapter;
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
import android.util.Log;
import android.widget.ListView;

import com.msacco.safaricom_sacco.R;

/**
 * @author joe
 * 
 */
public class MyAccMemberInfoActivity extends Activity {

	// Called when the activity is first created.

	private static final String SOAP_ACTION = "http://tempuri.org/GetMemberInfo";
	private static final String OPERATION_NAME = "GetMemberInfo";
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = "";

	private String strTelephoneNo = "";
	private MSACCOLocalDb db;
	private ListView memInfoListV;
	private List<String> info, testList;
	private boolean internetConnectionStatus = false;

	private MyAccMemberInfoListAdapter adapter;

	String[] infoLabels = { "MEMBER NO:", "NAME:", "ID NO:", "GENDER:",
			"ADDRESS:", "DATE OF BIRTH:", "E-MAIL:", "REGISTRATION DATE:",
			"EMPLOYER:", "MONTHLY CONTRIBUTION:" };

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.member_info);

		db = new MSACCOLocalDb(getApplicationContext());

		Configuration cfg = new Configuration();
		cfg.setTelephoneNo(getMyPhoneNO());
		strTelephoneNo = cfg.getTelephoneNo();
		SOAP_ADDRESS = Configuration.getURL();

		info = new ArrayList<String>();
		testList = new ArrayList<String>();

		internetConnectionStatus = new CheckInternetConnection(
				MyAccMemberInfoActivity.this).isConnectingToInternet();
		if (internetConnectionStatus) {
			try {
				new getMemeberInfo().execute(new String[] { strTelephoneNo });
			} catch (Exception e) {
				// noInternetConnAlert("Internet connection lost!");
			}
		} else if (!testList.isEmpty()) {
			//displaymemberInfo();
		} else {
			// noInternetConnAlert("No data found,please ensure that you have internet connection!");
		}
	}

	public void insertIntoLocalDb(List<String> inf) {
		try {
			// Inserting Member Info from server into local database.
			db.addMemberInfoFromServer(inf);
		} catch (Exception e) {
			e.printStackTrace();
		}
		displaymemberInfo();
	}

	// Diplay member info from local database.
	public void displaymemberInfo() {

		List<String> memberInformation = new ArrayList<String>();
		memberInformation = db.getMemberInfo();

		memInfoListV = (ListView) findViewById(R.id.myAccMemberInfoList);

		ArrayList<MyAccMemberInfoDataModel> memberInforModel = new ArrayList<MyAccMemberInfoDataModel>();		
		
		for (int i = 0; i < memberInformation.size(); i++) {

			MyAccMemberInfoDataModel mdl = new MyAccMemberInfoDataModel(
					infoLabels[i], 
					memberInformation.get(i));
			memberInforModel.add(mdl);
		}
		adapter = new MyAccMemberInfoListAdapter(this, memberInforModel);
		memInfoListV.setAdapter(adapter);
	}

	// Fetch member Info on a separate thread
	private class getMemeberInfo extends AsyncTask<String, Void, SoapObject> {
		private boolean connTimeout = false;
		private final ProgressDialog dialog = new ProgressDialog(
				MyAccMemberInfoActivity.this);

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
				e.printStackTrace();
			}
			return result;
		}

		@Override
		protected void onPostExecute(SoapObject res) {
			try {
				if(res==null)
				{
					noInternetConnAlert("Sorry,an error occured while connecting to the server.");
				}else if (res.getPropertyCount() > 0) {
					for (int i = 0; i < res.getPropertyCount(); i++) {
						info.add(res.getProperty(i).toString());
					}

					// Insert data into local database.
					insertIntoLocalDb(info);
				}if (this.dialog.isShowing()) {

					this.dialog.dismiss();
				}
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}

	}
	
	private String getMyPhoneNO() 
	{
		SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(MyAccMemberInfoActivity.this);
		String yourNumber = preferences.getString("telephoneKey", "");
		return yourNumber;
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
}
