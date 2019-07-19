package info.msacco.tabsswipe;

import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;

import org.ksoap2.SoapEnvelope;
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
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;

import com.msacco.safaricom_sacco.R;

@SuppressLint("SimpleDateFormat")
public class MyLnsLoanStatusFragment extends Fragment implements
		OnItemSelectedListener, OnClickListener {
	private static final String SOAP_ACTION = "http://tempuri.org/GetActiveLoans";
	private static final String OPERATION_NAME = "GetActiveLoans";

	private static final String SECOND_SOAP_ACTION = "http://tempuri.org/GetLoanStatus";
	private static final String SECOND_OPERATION_NAME = "GetLoanStatus";

	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = null;

	String strTelephoneNo = null;

	private Button onStatusRequestBtnClicked;
	private Spinner spinner;
	private String appliedAmt = null;
	private boolean internetConnectionStatus = false;
	private String Status = null;
	private String dateApplied = null;
	private String OutstandingBal = null;
	private String OutstandingInterest = null;
	private String LoanProductTypeName = null;

	List<String> loanTypesArrList;
	String selectedLoanType = null;
	private HomeActivity home;

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		View rootView = inflater.inflate(R.layout.my_loans_status_fragment,
				container, false);

		Configuration cfg = new Configuration();
		strTelephoneNo = cfg.getTelephoneNo();
		SOAP_ADDRESS = Configuration.getURL();

		loanTypesArrList = new ArrayList<String>();
		spinner = (Spinner) rootView.findViewById(R.id.myLnsStatusSpinner);

		onStatusRequestBtnClicked = (Button) rootView
				.findViewById(R.id.myLnsStatusViewBtn);
		onStatusRequestBtnClicked.setOnClickListener(this);

		return rootView;
	}

	@Override
	public void onActivityCreated(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onActivityCreated(savedInstanceState);
		// Function get member Info
		new getActiveLoanTypes().execute(new String[] { strTelephoneNo });

	}

	public void setSpinnerData() {
		// Create an ArrayAdapter using the string array and a default spinner
		// layout
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(getActivity()
				.getApplicationContext(),
				R.layout.spinner_selected_item_template, loanTypesArrList);

		// Specify the layout to use when the list of choices appears
		adapter.setDropDownViewResource(R.layout.spinner_items_template_white);

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
	private class getActiveLoanTypes extends
			AsyncTask<String, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(getActivity()
				.getApplicationContext());

		@Override
		protected void onPreExecute() {

			// this.dialog.setMessage("please wait...");
			// this.dialog.show();

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
		ArrayList<String> requestData = new ArrayList<String>();

		// extract loan number
		String loan = selectedLoanType;
		String[] split = loan.split(":");
		selectedLoanType = split[1];
		// selectedLoanName = split[0];

		requestData.add(selectedLoanType);
		requestData.add(strTelephoneNo);
		return requestData;
	}

	// Send Loan Request on a separate thread
	private class requestLoanStatus extends
			AsyncTask<ArrayList<String>, Void, SoapObject> {
		private final ProgressDialog dialog = new ProgressDialog(getActivity());

		@Override
		protected void onPreExecute() {

			this.dialog.setMessage("Please wait...");
			this.dialog.show();
		}

		@Override
		protected SoapObject doInBackground(ArrayList<String>... params) {
			//

			SoapObject result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						SECOND_OPERATION_NAME);
				request.addProperty("LoanNo", params[0].get(0));
				request.addProperty("strTelephoneNo", params[0].get(1));

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);

				httpTransport.call(SECOND_SOAP_ACTION, envelope);

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

				DecimalFormat df = new DecimalFormat("#.####");

				OutstandingBal = res.getProperty(3).toString();

				OutstandingInterest = res.getProperty(4).toString();

				LoanProductTypeName = res.getProperty(0).toString();
				Status = res.getProperty(1).toString();
				display(OutstandingBal, OutstandingInterest, Status,
						LoanProductTypeName, selectedLoanType);

			} catch (Exception e) {
				// TODO: handle exception
				Toast.makeText(getActivity(), e.getMessage(),
						Toast.LENGTH_SHORT).show();
			}
			if (this.dialog.isShowing()) {

				this.dialog.dismiss();
			}

		}

	}

	@SuppressWarnings("deprecation")
	public void display(String OutstandingBal, String OustandingInterest,
			String Status, String LoanProdTypeName, String selectedLoanType) {
		if (!OutstandingBal.equals(null) || !OustandingInterest.equals(null)
				|| !Status.equals(null)) {
			AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
					getActivity());
			alertDialogBuilder.setPositiveButton("OK",
					new DialogInterface.OnClickListener() {

						@Override
						public void onClick(DialogInterface dialog, int arg1) {
							dialog.dismiss();
						}
					});

			alertDialogBuilder.setMessage("PROD TYPE: " + LoanProdTypeName
					+ "\n" + "LOAN NO: " + selectedLoanType + "\n"
					+ " OUTSTANDING BAL: " + "" + OutstandingBal + "\n"
					+ "OUTSTANDING INTEREST:" + OustandingInterest + "\n"
					+ "STATUS :" + Status);
			/*
			 * alertDialogBuilder.setMessage("LOAN PROD TYPE: " +
			 * selectedLoanType + "\n" + " DATE APPLIED: " + "" + dateApplied +
			 * "\n" + "AMOUNT REQUESTED :" + appliedAmt + "\n" + "STATUS :" +
			 * Status);
			 */
			AlertDialog alertDialog = alertDialogBuilder.create();
			alertDialog.show();
		} else {
			AlertDialog ad = new AlertDialog.Builder(getActivity()).create();
			ad.setCancelable(false);
			ad.setTitle("No data was found");
			ad.setButton("OK", new DialogInterface.OnClickListener() {
				public void onClick(final DialogInterface dialog,
						final int which) {
					dialog.dismiss();
				}
			});
			ad.show();
		}

	}

	@SuppressWarnings("unchecked")
	@SuppressLint("SimpleDateFormat")
	@Override
	public void onClick(View view) {
		// Check internet Connection before making a server Request.
		internetConnectionStatus = new CheckInternetConnection(getActivity())
				.isConnectingToInternet();
		if (internetConnectionStatus) {
			try {
				new requestLoanStatus().execute(setRequestParameters());
			} catch (Exception e) {
				// TODO: handle exception
			}
		}

	}

	public void alert(String text) {
		Toast.makeText(getActivity().getApplicationContext(), text,
				Toast.LENGTH_LONG).show();
	}

}
