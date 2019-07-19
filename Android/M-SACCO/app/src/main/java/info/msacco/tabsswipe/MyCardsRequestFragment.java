package info.msacco.tabsswipe;

import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

import java.util.ArrayList;
import java.util.List;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
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
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;

import com.msacco.safaricom_sacco.R;

public class MyCardsRequestFragment extends Fragment implements
		OnItemSelectedListener, OnClickListener {
	private static final String SOAP_ACTION = "http://tempuri.org/RequestCard";
	private static final String OPERATION_NAME = "RequestCard";
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = "";

	private String strTelephoneNo = "";

	private List<String> branch_array;
	private String selected_branch;
	private Spinner spinner;
	private CheckInternetConnection conn;

	private Button sendbtn;

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		View rootView = inflater.inflate(R.layout.my_cards_request_fragment,
				container, false);
		sendbtn = (Button) rootView.findViewById(R.id.myCardsRequestBtn);
		sendbtn.setOnClickListener(this);

		conn = new CheckInternetConnection(getActivity());
		Configuration cfg = new Configuration();
		strTelephoneNo = cfg.getTelephoneNo();
		SOAP_ADDRESS = Configuration.getURL();

		spinner = (Spinner) rootView.findViewById(R.id.branch_spinner);
		branch_array = new ArrayList<String>();
		branch_array.add("JCC");
		branch_array.add("SCC");

		ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(
				getActivity(), android.R.layout.simple_spinner_item,
				branch_array);

		// Specify the layout to use when the list of choices appears
		dataAdapter
				.setDropDownViewResource(R.layout.spinner_items_template_white);

		// Apply the adapter to the spinner
		spinner.setAdapter(dataAdapter);

		spinner.setOnItemSelectedListener(this);

		return rootView;
	}

	public void onItemSelected(AdapterView<?> parent, View view, int pos,
			long id) {
		selected_branch = spinner.getSelectedItem().toString();
	}

	public void onNothingSelected(AdapterView<?> parent) {
		// Another interface callback
	}

	@Override
	public void onClick(View v) {
		alert();

	}

	// Send request for card
	private class requestCard extends AsyncTask<String, Integer, String> {
		private final ProgressDialog dialog = new ProgressDialog(getActivity());

		@Override
		protected void onPreExecute() {

			this.dialog.setMessage("Sending request...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(String... urls) {
			String ress = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION_NAME);
				request.addProperty("strTelephoneNo", urls[0].toString());
				request.addProperty("branch", urls[1].toString());
				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;
				envelope.setOutputSoapObject(request);
				HttpTransportSE androidHttpTransport = new HttpTransportSE(
						SOAP_ADDRESS);

				androidHttpTransport.call(SOAP_ACTION, envelope);

				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;

				} else {
					SoapObject resultsRequestSOAP = (SoapObject) envelope.bodyIn;

					int n = resultsRequestSOAP.getPropertyCount();

					if (String.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equalsIgnoreCase("pending")) {
						ress = "pending";
					} else if (String
							.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equalsIgnoreCase("sent")) {
						ress = "sent";
					} else {
						ress = "Request failed, please try again";
					}
					return ress;
				}
			} catch (Exception e) {
				if (e.getMessage() == null) {
					e.printStackTrace();
					ress = "error... Unable to connect to server";
				} else {
				}
			}
			return ress;
		}

		@Override
		protected void onPostExecute(String result) {
			try {
				if (this.dialog.isShowing()) {
					this.dialog.dismiss();

				}
				if (result.toLowerCase().trim().equalsIgnoreCase("sent")) {
					// Show user notification
					String res = "Dear Customer, your request for ATM card has been received and is being processed.";
					finished(res);
				}
				if (result.toLowerCase().trim().equalsIgnoreCase("pending")) {
					// Show user notification
					String txt = "Dear Customer, you have a pending request ,"
							+ "you will receive a notification once your request has been processed.";
					finished(txt);
				} else {
					Toast.makeText(getActivity(),
							"Request not sent,please try again",
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

	public void alert() {
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				getActivity());
		alertDialogBuilder.setTitle("Please Accept Terms & Conditions");
		alertDialogBuilder.setPositiveButton("Accept",
				new DialogInterface.OnClickListener() {
					@Override
					public void onClick(DialogInterface arg0, int arg1) {
						try {
							if (conn.isConnectingToInternet()) {
								new requestCard().execute(strTelephoneNo,
										selected_branch);
							} else {
								Toast.makeText(getActivity(),
										"No Internet Connection!",
										Toast.LENGTH_LONG).show();
							}
						} catch (Exception e) {
							// TODO: handle exception
						}
					}
				});
		alertDialogBuilder.setNegativeButton("Reject",
				new DialogInterface.OnClickListener() {
					@Override
					public void onClick(DialogInterface dialog, int which) {
					}
				});

		AlertDialog alertDialog = alertDialogBuilder.create();
		alertDialog.show();

	}

	public void finished(String text) {
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				getActivity());

		alertDialogBuilder.setMessage(text);
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
}