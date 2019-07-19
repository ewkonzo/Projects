package info.msacco.tabsswipe;

import info.msacco.actionbar.model.CustomerServiceInboxMessageModel;
import info.msacco.tabsswipe.adapter.CustomerServiceInboxMsgListAdapter;
import info.msacco.tabsswipe.adapter.MSACCOLocalDb;
import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;
import java.util.concurrent.TimeUnit;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.msacco.safaricom_sacco.R;

/**
 * @author joe
 * 
 */
public class CustomerServiceInboxFragment extends Fragment {

	// Called when the activity is first created.

	private static final String SOAP_ACTION = "http://tempuri.org/GetInboxMessages";
	private static final String OPERATION_NAME = "GetInboxMessages";
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = "";

	private String strTelephoneNo = "";
	private ListView inboxMessageListV;

	private CustomerServiceInboxMsgListAdapter adapter;
	private MSACCOLocalDb db;
	// private Button refreshBtn;

	private List<String> messageEntryNo;
	private List<String> messageHeading;
	private List<String> messageBody;
	private List<CustomerServiceInboxMessageModel> msgList, testList;
	private String[][] messageArray;

	private Boolean isConnectedToInternet = false;

	List<String> messageArrayList;
	private int last_entry;

	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {

		View rootView = inflater.inflate(
				R.layout.customer_service_inbox_fragment, container, false);

		Configuration cfg = new Configuration();
		strTelephoneNo = cfg.getTelephoneNo();
		SOAP_ADDRESS = Configuration.getURL();

		inboxMessageListV = (ListView) rootView
				.findViewById(R.id.customerServiceInboxList);

		messageArrayList = new ArrayList<String>();

		messageEntryNo = new ArrayList<String>();
		messageHeading = new ArrayList<String>();
		messageBody = new ArrayList<String>();
		msgList = new ArrayList<CustomerServiceInboxMessageModel>();

		db = new MSACCOLocalDb(getActivity());
		testList = db.retrieveInboxMessages();
		last_entry = db.getInboxLastEntry();

		isConnectedToInternet = new CheckInternetConnection(getActivity()
				.getApplicationContext()).isConnectingToInternet();
		try {
			if (isConnectedToInternet) {
				new getInboxMessages().execute(
						new String[] { strTelephoneNo,
								String.valueOf(last_entry) }).get(1000,
						TimeUnit.MILLISECONDS);
			} else if (!isConnectedToInternet || !testList.isEmpty()) {
				displayInboxMsgs();
			} else if (!isConnectedToInternet || testList.isEmpty()) {
				noInternetConnAlert("you have no messages");
			}
		} catch (Exception e) {
		}

		return rootView;
	}

	// Split data returned from Server into a two dimensional array
	public void splitArray(List<String> msgArrL) {
		try {
			messageArray = new String[msgArrL.size()][3];
			for (int i = 0; i < msgArrL.size(); i++) {
				messageArray[i] = (msgArrL.get(i)).split(":::");
				messageEntryNo.add(messageArray[i][0]);
				messageHeading.add(messageArray[i][1]);
				messageBody.add(messageArray[i][2]);
			}
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		// Call Method to insert the data into local database.
		insertIntLocalDb();
	}

	public void insertIntLocalDb() {
		db.deleteOldMessages();
		for (int i = 0; i < messageArrayList.size(); i++) {
			try {
				SimpleDateFormat dateformat = new SimpleDateFormat("MM/dd/yy");
				Calendar cal = Calendar.getInstance();
				String date = dateformat.format(cal.getTime());
				db.addMessagesFromServer((new CustomerServiceInboxMessageModel(
						Integer.parseInt(messageArray[i][0]), date,
						messageArray[i][1], messageArray[i][2])));
			} catch (NumberFormatException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		displayInboxMsgs();
	}

	// Display Inbox Messages from web service.
	@SuppressWarnings("deprecation")
	public void displayInboxMsgs() {
		try {
			msgList = db.retrieveInboxMessages();

			ArrayList<CustomerServiceInboxMessageModel> inboxMessageModel = new ArrayList<CustomerServiceInboxMessageModel>();
			for (int i = 0; i < msgList.size(); i++) {
				CustomerServiceInboxMessageModel mdl = new CustomerServiceInboxMessageModel(
						msgList.get(i).get_entryNo(), msgList.get(i)
								.get_entryDate(), msgList.get(i)
								.get_messageHeading(), msgList.get(i)
								.get_message());
				inboxMessageModel.add(mdl);
			}
			adapter = new CustomerServiceInboxMsgListAdapter(getActivity()
					.getApplicationContext(), inboxMessageModel);
			inboxMessageListV.setAdapter(adapter);

		} catch (Exception e) {
			noInternetConnAlert("Error retrieving messages");
		}

	}

	// Retrieve Message on a separate thread
	private class getInboxMessages extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(getActivity());
		private boolean connTimeout = false;

		@Override
		protected void onPreExecute() {

			this.dialog.setMessage("Loading...");
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
				request.addProperty("lastEntry", urls[1].toString());
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

		@SuppressWarnings("deprecation")
		@Override
		protected void onPostExecute(SoapObject res) {
			if (connTimeout = true) {
				connTimeout = false;
			}
			if (this.dialog.isShowing()) {
				this.dialog.dismiss();
			}
			try {
				if (res.getPropertyCount() > 0) {
					for (int i = 0; i < res.getPropertyCount(); i++) {
						messageArrayList.add(res.getProperty(i).toString());
					}
					// display Member infomation in a listView.
					splitArray(messageArrayList);
				}
			} catch (Exception e) {
			}

		}
	}

	@SuppressWarnings("deprecation")
	public void noInternetConnAlert(String text) {
		try {
			AlertDialog ad = new AlertDialog.Builder(getActivity()).create();
			ad.setCancelable(false);
			ad.setTitle(text);
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
