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
import android.app.ProgressDialog;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import com.msacco.safaricom_sacco.R;

@SuppressLint({ "SimpleDateFormat", "DefaultLocale" })
public class MyLnsLoanRequestFragment extends Fragment implements
		OnItemSelectedListener, OnClickListener {
	private static final String SOAP_ACTION = "http://tempuri.org/GetLoanTypes";
	private static final String OPERATION_NAME = "GetLoanTypes";

	private static final String SECOND_SOAP_ACTION = "http://tempuri.org/RequestLoan";
	private static final String SECOND_OPERATION_NAME = "RequestLoan";

	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = null;

	private boolean internetConnectionStatus = false;
	private String strTelephoneNo = null;
	private EditText requestedAmt;
	private String requestedAmount;
	private String requestDate = null;

	private Button onRequestLoanClicked;
	private Spinner spinner;

	List<String> loanTypesArrList;
	String selectedLoanType = null;

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		View rootView = inflater.inflate(R.layout.my_loans_request_fragment,
				container, false);

		Configuration cfg = new Configuration();
		strTelephoneNo = cfg.getTelephoneNo();
		SOAP_ADDRESS = Configuration.getURL();

		loanTypesArrList = new ArrayList<String>();
		spinner = (Spinner) rootView.findViewById(R.id.myLnsRequestSpinner);

		requestedAmt = (EditText) rootView
				.findViewById(R.id.myLnsRequestAmtEdtxt);
		onRequestLoanClicked = (Button) rootView
				.findViewById(R.id.myLnsRequestApplyLoanBtn);

		onRequestLoanClicked.setOnClickListener(this);

		return rootView;
	}

	@Override
	public void onActivityCreated(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onActivityCreated(savedInstanceState);
		// Function get member Info
		new getLoanTypes().execute(new String[] { strTelephoneNo });
	}

	public void setSpinnerData() {
		// Create an ArrayAdapter using the string array and a default spinner
		// layout
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(getActivity()
				.getApplicationContext(),
				R.layout.spinner_selected_item_template, loanTypesArrList);

		// Specify the layout to use when the list of choices appears
		adapter.setDropDownViewResource(R.layout.spinner_items_template);

		// Apply the adapter to the spinner
		spinner.setAdapter(adapter);

		spinner.setOnItemSelectedListener(this);
	}

	public void onItemSelected(AdapterView<?> parent, View view, int pos,
			long id) {
		// An item was selected. You can retrieve the selected item using
		selectedLoanType = spinner.getSelectedItem().toString();
	}

	public void onNothingSelected(AdapterView<?> parent) {
		// Another interface callback
	}

	// Get Loan Types on a separate thread
	private class getLoanTypes extends AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(getActivity());

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
				request.addProperty("strTelephoneNo", urls[0].toString());
				// Log.e("PHONE NO: ", urls[0].toString());

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);

				httpTransport.call(SOAP_ACTION, envelope);

				result = (SoapObject) envelope.getResponse();
				// Log.e("RESULT", String.valueOf(result));
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
					loanTypesArrList.add(res.getProperty(i).toString());
				}

				setSpinnerData();

			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {
					Toast.makeText(getActivity().getApplicationContext(),
							"Error....: " + ex.getMessage(), Toast.LENGTH_LONG)
							.show();
				}
			}
		}
	}

	// Put all data for requesting a loan into an arrayList.
	public ArrayList<String> setRequestParameters() {
		Calendar c = Calendar.getInstance();
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM/dd-hh.mm.ss");
		requestDate = sdf.format(c.getTime());
		requestedAmount = requestedAmt.getText().toString();

		ArrayList<String> requestData = new ArrayList<String>();
		requestData.add(strTelephoneNo);
		requestData.add(selectedLoanType);
		requestData.add(requestedAmount);
		requestData.add(requestDate);
		return requestData;
	}

	// Send Loan Request on a separate thread
	private class requestLoan extends
			AsyncTask<ArrayList<String>, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(getActivity());

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
				request.addProperty("loanProdType", params[0].get(1));
				request.addProperty("requestedAmount", params[0].get(2));

				request.addProperty("dateRequested", params[0].get(3));

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

					// Log.e("SendRequest Value", String
					// .valueOf(resultsRequestSOAP.getProperty(n - 1)));

					if (String.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equalsIgnoreCase("true")) {

						result = "OK";
						//Log.e("Result", result);

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
					Toast.makeText(getActivity().getApplicationContext(),
							"Request sent", Toast.LENGTH_LONG).show();
					requestedAmt.getText().clear();
				} else {
					Toast.makeText(
							getActivity().getApplicationContext(),
							"Request not Sent, Please check your internet connection.",
							Toast.LENGTH_LONG).show();
				}

			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {
					//Log.i(ex.getMessage(), ex.getMessage());
				}
			}
		}
	}

	@SuppressWarnings("unchecked")
	@SuppressLint("SimpleDateFormat")
	@Override
	public void onClick(View view) {
		if (requestedAmt.getText().toString().equals("")
				|| requestedAmt.getText().toString() == null) {
			alert("Please enter amount.");
		} else {

			internetConnectionStatus = new CheckInternetConnection(
					getActivity()).isConnectingToInternet();
			if (internetConnectionStatus) {
				try {
					new requestLoan().execute(setRequestParameters()).get(5000,
							TimeUnit.MILLISECONDS);
				} catch (InterruptedException e) {
					alert("Internet connection lost!");
				} catch (ExecutionException e) {
					alert("An error has occured while processing your request!");
					e.printStackTrace();
				} catch (TimeoutException e) {
					e.printStackTrace();
				}
			} else {
				alert("Check your internet connection and try again");
			}
		}
	}

	public void alert(String text) {
		Toast.makeText(getActivity().getApplicationContext(), text,
				Toast.LENGTH_LONG).show();
	}

}
