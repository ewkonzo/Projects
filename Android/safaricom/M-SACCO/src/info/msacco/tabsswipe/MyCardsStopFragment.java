package info.msacco.tabsswipe;

import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

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
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.msacco.safaricom_sacco.R;

public class MyCardsStopFragment extends Fragment implements OnClickListener {
	private static final String SOAP_ACTION = "http://tempuri.org/StopCard";
	private static final String OPERATION_NAME = "StopCard";
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = "";

	private String strTelephoneNo = "";
	private CheckInternetConnection conn;
	private Button sendbtn;
	EditText idNo;

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		View rootView = inflater.inflate(R.layout.my_cards_stop_fragment,
				container, false);
		idNo = (EditText) rootView.findViewById(R.id.myCardsStopIDEdtxt);
		sendbtn = (Button) rootView.findViewById(R.id.myCardsStopBtn);
		sendbtn.setOnClickListener(this);

		conn = new CheckInternetConnection(getActivity());
		Configuration cfg = new Configuration();
		strTelephoneNo = cfg.getTelephoneNo();
		SOAP_ADDRESS = Configuration.getURL();

		return rootView;
	}

	@Override
	public void onClick(View v) {
		String id = idNo.getText().toString();
		if (id == null || id.equals("")) {
			Toast.makeText(getActivity(), "Please enter your ID number.",
					Toast.LENGTH_LONG).show();
		} else {
			alert(id);
		}

	}

	// Send request for card
	private class stopCard extends AsyncTask<String, Integer, String> {
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
				request.addProperty("idNo", urls[1].toString());
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
							.trim().substring(0, 1).equalsIgnoreCase("N")) {
						ress = String.valueOf(
								resultsRequestSOAP.getProperty(n - 1)).trim();
					} else if (String
							.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equals("P")) {
						ress = "P";
					} else if (String
							.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equals("R")) {
						ress = "R";
					} else if (String
							.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equals("F")) {
						ress = "F";
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
				if (result.trim().substring(0, 1).equals("N")) {
					// Show user notification
					String cardNo = result;
					String notify = "Request to block ATM card(Card " + cardNo
							+ ") has been received and is being processed.";
					finished(notify);
				} else if (result.toLowerCase().trim().equalsIgnoreCase("P")) {
					// Show user notification
					String cardNo = result.trim();
					String notify = "Dear Customer, your have a similar request being processed,"
							+ "you will receive a notification upon completion.";
					finished(notify);
				} else if (result.toLowerCase().trim().equalsIgnoreCase("R")
						|| result.toLowerCase().trim().equalsIgnoreCase("F")) {
					// Show user notification
					String cardNo = result.trim();
					String notify = "Dear Customer, currently you do not have any cards issued, "
							+ "please open the Card request Tab to request for one.";
					finished(notify);
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

	public void alert(final String id_no) {
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				getActivity());
		alertDialogBuilder
				.setMessage("Are you sure you want to block this card?");
		alertDialogBuilder.setPositiveButton("Accept",
				new DialogInterface.OnClickListener() {
					@Override
					public void onClick(DialogInterface arg0, int arg1) {
						try {
							if (conn.isConnectingToInternet()) {
								new stopCard().execute(strTelephoneNo, id_no);
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

	public void finished(String txt) {
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				getActivity());

		alertDialogBuilder.setMessage(txt);
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