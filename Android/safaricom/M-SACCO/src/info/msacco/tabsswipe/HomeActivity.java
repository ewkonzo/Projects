package info.msacco.tabsswipe;

/**

 */

import info.msacco.actionbar.model.MledgerDepWithdByAccTypeDataModel;
import info.msacco.actionbar.model.MledgerDepWithdDatabaseModel;
import info.msacco.tabsswipe.adapter.MSACCOLocalDb;
import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

import java.util.ArrayList;
import java.util.List;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.app.ActionBar;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewConfiguration;
import android.widget.ImageButton;

import com.msacco.safaricom_sacco.R;

public class HomeActivity extends DashBoardActivity implements
		ActionBar.OnNavigationListener {

	/** Called when the activity is first created. */
	private static final String SOAP_ACTION = "http://tempuri.org/GetDashBoardData";
	private static final String OPERATION_NAME = "GetDashBoardData";
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = null;

	private String msisdn = null;
	private String soap_url = null;
	int last_entry;
	private String l_entry = "";

	ImageButton onByAccTypeButtonClicked, onByTransactionTypeButtonClicked,
			onByTimeButtonClicked;
	// Store split data from Server
	private String[][] analysisByAccountTypeArray;
	// For holding a list of data elements from web service
	List<String> analysisByAccTypeList;
	// Reference to the local Database Class
	private String strTelephoneNo = null;
	private MSACCOLocalDb db;

	private List<MledgerDepWithdByAccTypeDataModel> testList;
	private boolean internetConnectionStatus = false;
	private boolean dashboard_tes = false;

	// action bar
	private ActionBar actionBar;

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.main);
		setHeader(getString(R.string.HomeActivityTitle), false, true);

		try {
			ViewConfiguration config = ViewConfiguration.get(this);
			java.lang.reflect.Field menuKeyField = ViewConfiguration.class
					.getDeclaredField("sHasPermanentMenuKey");
			if (menuKeyField != null) {
				menuKeyField.setAccessible(true);
				menuKeyField.setBoolean(config, false);
			}
		} catch (Exception ex) {
			// Ignore
		}

		Configuration cfg = new Configuration();
		strTelephoneNo = cfg.getTelephoneNo();
		cfg.setTelephoneNo(getMyPhoneNO());
		SOAP_ADDRESS = Configuration.getURL();

	}

	public void loadData() {
		// Instantiate Lists.
		analysisByAccTypeList = new ArrayList<String>();

		// Instantiate Local DB
		db = new MSACCOLocalDb(this);

		// Get The last Entry on the database
		last_entry = db.getMledgerLastEntry();

		// Get account data from local db.
		testList = db.getDepositAndWithdByAccType();

		internetConnectionStatus = new CheckInternetConnection(
				HomeActivity.this).isConnectingToInternet();
		if (internetConnectionStatus) {
			try {
				new getAnalysisInfoByAccountType().execute(new String[] {
						strTelephoneNo, String.valueOf(last_entry) });
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		} else if (analysisByAccTypeList.size() < 0
				|| !internetConnectionStatus) {
			noInternetConnAlert("No data found, please ensure you have internet connection!");
		}
	}

	public String getMsisdn() {
		return msisdn;
	}

	public String getSOAP_URL() {
		return soap_url;
	}

	// Split data returned from web service into a two dimensional array
	public void splitArray(List<String> arr) {
		analysisByAccountTypeArray = new String[arr.size()][11];
		for (int i = 0; i < arr.size(); i++) {
			try {
				analysisByAccountTypeArray[i] = (arr.get(i)).split(":::");
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}

		// Call Method to insert the data into local database.
		insertIntLocalDb();
	}

	public void insertIntLocalDb() {
		db.deleteOldData();
		for (int i = 0; i < analysisByAccTypeList.size(); i++) {
			try {
				if (!((analysisByAccountTypeArray[i][0]) == "entry")) {
					db.addDashBoardDataFromWebService(new MledgerDepWithdDatabaseModel(
							(Integer.parseInt(analysisByAccountTypeArray[i][0])),
							analysisByAccountTypeArray[i][1],
							analysisByAccountTypeArray[i][2],
							analysisByAccountTypeArray[i][3],
							analysisByAccountTypeArray[i][4],
							(Double.parseDouble(analysisByAccountTypeArray[i][5])),
							(Double.parseDouble(analysisByAccountTypeArray[i][6])),
							(Double.parseDouble(analysisByAccountTypeArray[i][7])),
							analysisByAccountTypeArray[i][8],
							analysisByAccountTypeArray[i][9],
							analysisByAccountTypeArray[i][10]));

				}
				// Load More Data
				if (!((analysisByAccountTypeArray[i][0]) == "entry")) {
					// loadData();
				}
			} catch (NumberFormatException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		// Open dashboard
		Intent intent;
		intent = new Intent(this, MLedgerActivity.class);
		// Close all views before launching Dashboard
		intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
		startActivity(intent);

	}

	// Fetch Analysis data from Web service on a separate thread
	private class getAnalysisInfoByAccountType extends
			AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(
				HomeActivity.this);

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
				request.addProperty("latest_entry",
						Integer.parseInt(urls[1].toString()));

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

				if (res == null) {
					noInternetConnAlert("Sorry,an error occured while connecting to the server.");
				} else if (res.getPropertyCount() > 0) {
					if (res.getPropertyCount() == 1
							&& res.getProperty(0).toString().equals("00")) {
						noInternetConnAlert("Sorry,you have insufficient funds to use this service");
					} else {
						for (int i = 0; i < res.getPropertyCount(); i++) {
							analysisByAccTypeList.add(res.getProperty(i)
									.toString());

							// Calling method for separating returned data
							splitArray(analysisByAccTypeList);
						}
					}
				}

			} catch (Exception e) {
				Boolean isConnected = new CheckInternetConnection(
						getApplicationContext()).isConnectingToInternet();
				if (isConnected) {
					// noInternetConnAlert("Connection Timeout!");
				} else {
					noInternetConnAlert("No internet connection!");
				}
			}

			if (this.dialog.isShowing()) {

				this.dialog.dismiss();
			}
		}
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
				}
			});
			ad.show();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.home_menu, menu);
		
		return super.onCreateOptionsMenu(menu);
	}

	/**
	 * On selecting action bar icons
	 * */
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Take appropriate action for each action item click
		switch (item.getItemId()) {
		case R.id.btnLogout:

			// Launch Login Screen
			Intent LoginScreen = new Intent(getApplicationContext(),
					LoginActivity.class);
			// Close all views before launching Login
			LoginScreen.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(LoginScreen);
			// Close Login Screen
			finish();

			return true;
			
		default:
			return super.onOptionsItemSelected(item);
		}
	}

	/**
	 * Button click handler on Main activity
	 * 
	 * @param v
	 */

	public void onButtonClicker(View v) {
		Intent intent;
		switch (v.getId()) {
		case R.id.member_info_btn:
			intent = new Intent(this, MyAccountActivity.class);
			// Close all views before launching Dashboard
			intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(intent);
			break;

		case R.id.funds_transfer_btn:
			intent = new Intent(this, FundsTransferActivity.class);
			// Close all views before launching Dashboard
			intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(intent);
			break;

		case R.id.account_bal_btn:
			intent = new Intent(this, BalEnquiryActivity.class);
			// Close all views before launching Dashboard
			intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(intent);
			break;

		case R.id.transact_btn:
			intent = new Intent(this, MyAccTransactActivity.class);
			// Close all views before launching Dashboard
			intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(intent);
			break;

		/*
		 * case R.id.my_cards_btn: intent = new Intent(this,
		 * MyCardsActivity.class); // Close all views before launching Dashboard
		 * intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
		 * startActivity(intent); break;
		 */

		case R.id.rununu_advance_btn:
			intent = new Intent(this, RununuLoanRequestActivity.class);
			// Close all views before launching Dashboard
			intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(intent);
			break;
		case R.id.ministm_btn:
			intent = new Intent(this, MyAccMiniStatementActivity.class);
			// Close all views before launching Dashboard
			intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(intent);
			break;

		/*
		 * case R.id.e_pay_btn: intent = new Intent(this,
		 * EPaymentsActivity.class); // Close all views before launching
		 * Dashboard intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
		 * startActivity(intent); break;
		 */
		case R.id.dashbd_btn:
			loadData();

			break;

		case R.id.fosa_loans_btn:
			intent = new Intent(this, MyLoansRepaymentActivity.class);
			// Close all views before launching Dashboard
			intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(intent);
			break;

		case R.id.loan_cal_btn:
			intent = new Intent(this, LoanCalActivity.class);
			// Close all views before launching Dashboard
			intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(intent);
			break;

		/*
		 * case R.id.customer_service_btn: intent = new Intent(this,
		 * CustomerServiceActivity.class); // Close all views before launching
		 * Dashboard intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
		 * startActivity(intent); break;
		 */
		default:
			break;
		}
	}

	private String getMyPhoneNO() {
		SharedPreferences preferences = PreferenceManager
				.getDefaultSharedPreferences(HomeActivity.this);
		String yourNumber = preferences.getString("telephoneKey", "");
		return yourNumber;
	}

	@Override
	public boolean onNavigationItemSelected(int arg0, long arg1) {
		// TODO Auto-generated method stub
		return false;
	}
}
