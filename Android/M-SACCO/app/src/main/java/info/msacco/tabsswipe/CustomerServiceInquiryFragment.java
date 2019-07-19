package info.msacco.tabsswipe;

import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.annotation.SuppressLint;
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

/**
 * @author joe
 * 
 */
@SuppressLint("DefaultLocale")
public class CustomerServiceInquiryFragment extends Fragment implements
		OnClickListener {

	// Called when the activity is first created.

	private static final String SOAP_ACTION = "http://tempuri.org/submitEnquiry";
	private static final String OPERATION_NAME = "submitEnquiry";
	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = "";

	private String strTelephoneNo = "";
	private String enquirySubject = "";
	private String enquirySummary = "";
	private CheckInternetConnection conn;

	EditText subject, summary;
	Button onSubmitButtonClicked;

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {

		View rootView = inflater.inflate(
				R.layout.customer_service_queries_fragment, container, false);
		conn = new CheckInternetConnection(getActivity());
		Configuration cfg = new Configuration();
		strTelephoneNo = cfg.getTelephoneNo();
		SOAP_ADDRESS = Configuration.getURL();

		subject = (EditText) rootView
				.findViewById(R.id.customerServiceSubjectEdtxt);
		summary = (EditText) rootView
				.findViewById(R.id.customerServiceSummaryEdtxt);
		onSubmitButtonClicked = (Button) rootView
				.findViewById(R.id.customerServiceSubmitQueryBtn);
		onSubmitButtonClicked.setOnClickListener(this);

		return rootView;
	}

	// Send Enquiry on a separate thread
	private class sentEnquiries extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(getActivity());
		private boolean timeout = false;

		@Override
		protected void onPreExecute() {

			this.dialog.setMessage("Please wait...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(String... urls) {
			//

			String result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION_NAME);
				request.addProperty("enquirySubject", urls[0].toString());
				request.addProperty("enquirySummary", urls[1].toString());
				request.addProperty("strTelephoneNo", urls[2].toString());
				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);

				httpTransport.call(SOAP_ACTION, envelope);
				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;
				} else {
					SoapObject resultsRequestSOAP = (SoapObject) envelope.bodyIn;

					int n = resultsRequestSOAP.getPropertyCount();

					if (String.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equalsIgnoreCase("true")) {

						result = "OK";

					} else {
						result = "Server not found.";
					}
					return result;
				}
			} catch (Exception e) {
				timeout = true;
			}
			return result;
		}

		@Override
		protected void onPostExecute(String res) {
			if (timeout == true) {
				noInternetConnAlert("connection timeout");
			} else {
				try {

					if (this.dialog.isShowing()) {
						this.dialog.dismiss();
					}

					if (res.toLowerCase().trim().equalsIgnoreCase("OK")) {
						Toast.makeText(getActivity().getApplicationContext(),
								"Message sent", Toast.LENGTH_LONG).show();
						subject.getText().clear();
						summary.getText().clear();
					} else {
						Toast.makeText(
								getActivity().getApplicationContext(),
								"Message not Sent, Pease check your internet connection.",
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
	}

	@SuppressWarnings("deprecation")
	@Override
	public void onClick(View arg0) {
		enquirySubject = subject.getText().toString();
		enquirySummary = summary.getText().toString();
		if (enquirySubject.equals("") || enquirySubject == null
				|| enquirySummary.equals("") || enquirySummary == null) {
			Toast.makeText(getActivity(),
					"Please fill in all fields before you submit",
					Toast.LENGTH_LONG).show();
		} else {
			try {

				AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
						getActivity());
				alertDialogBuilder.setMessage("Do you want to proceed?");

				alertDialogBuilder.setPositiveButton("yes",
						new DialogInterface.OnClickListener() {
							@Override
							public void onClick(DialogInterface arg0, int arg1) {
								// Function for sending Customer Enquiries
								try {
									if (conn.isConnectingToInternet()) {
										new sentEnquiries()
												.execute(new String[] {
														enquirySubject,
														enquirySummary,
														strTelephoneNo });
									} else {
										Toast.makeText(getActivity(),
												"No Intenet Connection",
												Toast.LENGTH_LONG).show();
									}
								} catch (Exception e) {
									e.getStackTrace();
								}
							}
						});

				alertDialogBuilder.setNegativeButton("No",
						new DialogInterface.OnClickListener() {
							@Override
							public void onClick(DialogInterface dialog,
									int which) {

							}
						});
				AlertDialog alertDialog = alertDialogBuilder.create();
				alertDialog.show();

			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}

	@SuppressWarnings("deprecation")
	public void noInternetConnAlert(String text) {
		try {
			AlertDialog ad = new AlertDialog.Builder(getActivity()
					.getApplicationContext()).create();
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
