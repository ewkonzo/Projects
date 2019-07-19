package info.msacco.tabsswipe;

import info.msacco.utils.CheckInternetConnection;
import info.msacco.utils.Configuration;

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
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import com.msacco.safaricom_sacco.R;

@SuppressLint("SimpleDateFormat")
public class MyLnsLoanRepaymentFragment extends Fragment implements
		OnItemSelectedListener, OnClickListener {
	private static final String SOAP_ACTION_ACCOUNTS = "http://tempuri.org/GetActiveFOSAAccounts";
	private static final String OPERATION_NAME_ACCOUNTS = "GetActiveFOSAAccounts";

	private static final String SOAP_ACTION = "http://tempuri.org/GetActiveLoans";
	private static final String OPERATION_NAME = "GetActiveLoans";

	private static final String SECOND_SOAP_ACTION = "http://tempuri.org/RepayLoan";
	private static final String SECOND_OPERATION_NAME = "RepayLoan";

	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = null;
	private boolean internetConnectionStatus = false;

	private String strTelephoneNo = null;
	private EditText repaymentAmt;
	private String repaymentAmount;
	private String repaymentDate = null;
	private String selectedLoanName = "";

	private Button onRepaymentBtnClicked;
	private Spinner spinner;

	List<String> loanTypesArrList;
	String selectedLoanType = null;

	List<String> loanNumbersArrList;
	List<String> loanNamesArrList;

	List<String> AccountFromServerList;

	List<String> FOSAAccountsList;
	List<String> FOSAAccountNamesList;

	// Store split data from Server
	private String[][] fosaAccountsArray;

	String selectedFOSAaccFrom = "";
	String selectedFOSAaccNameFrom = "";
	private Spinner accFromspinner;
	private String[][] loansArray;

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		View rootView = inflater.inflate(R.layout.my_loans_repayment_fragment,
				container, false);

		Configuration cfg = new Configuration();
		strTelephoneNo = cfg.getTelephoneNo();
		SOAP_ADDRESS = Configuration.getURL();

		AccountFromServerList = new ArrayList<String>();
		FOSAAccountsList = new ArrayList<String>();
		FOSAAccountNamesList = new ArrayList<String>();
		loanNamesArrList = new ArrayList<String>();
		loanNumbersArrList = new ArrayList<String>();

		loanTypesArrList = new ArrayList<String>();
		spinner = (Spinner) rootView.findViewById(R.id.myLnsRepaymentSpinner);
		accFromspinner = (Spinner) rootView
				.findViewById(R.id.myLnsRepaymentAccountSpinner);

		repaymentAmt = (EditText) rootView
				.findViewById(R.id.myLnsRepaymentAmtEdtxt);
		onRepaymentBtnClicked = (Button) rootView
				.findViewById(R.id.myLnsRepaymentSendBtn);

		onRepaymentBtnClicked.setOnClickListener(this);

		return rootView;
	}

	@Override
	public void onActivityCreated(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onActivityCreated(savedInstanceState);

		// get accounts
		new getMyFOSAAccounts().execute(new String[] { strTelephoneNo });

		// Function get loan types
		new getActiveLoanTypes().execute(new String[] { strTelephoneNo });

	}

	public void setSpinnerData(List<String> loansList) {
		// Create an ArrayAdapter using the string array and a default spinner
		// layout
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(getActivity()
				.getApplicationContext(),
				R.layout.spinner_selected_item_template, loansList);

		// Specify the layout to use when the list of choices appears
		adapter.setDropDownViewResource(R.layout.spinner_items_template);

		// Apply the adapter to the spinner
		spinner.setAdapter(adapter);

		spinner.setOnItemSelectedListener(this);
	}

	public void onItemSelected(AdapterView<?> parent, View view, int pos,
			long id) {

		String loan = spinner.getSelectedItem().toString();
		String[] split = loan.split(":");
		selectedLoanType = split[1];
		selectedLoanName = split[0];
	}

	public void onNothingSelected(AdapterView<?> parent) {
		// Another interface callback
	}

	// Get All FOSA accounts for this user on a separate thread
	private class getMyFOSAAccounts extends AsyncTask<String, Void, SoapObject> {
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
						OPERATION_NAME_ACCOUNTS);
				request.addProperty("strTelephoneNo", urls[0].toString());

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);

				httpTransport.call(SOAP_ACTION_ACCOUNTS, envelope);

				result = (SoapObject) envelope.getResponse();

				return result;
			} catch (Exception e) {
				// e.getMessage().toString();
			}
			return result;
		}

		@Override
		protected void onPostExecute(SoapObject res) {
			try {
				if (res.getPropertyCount() > 0) {
					for (int i = 0; i < res.getPropertyCount(); i++) {
						AccountFromServerList
								.add(res.getProperty(i).toString());
					}
					splitArray(AccountFromServerList);
					// setSpinnerData();
				}
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

	private void splitArray(List<String> fOSAAccountFromArrList) {
		// Format the Amount returned
		fosaAccountsArray = new String[AccountFromServerList.size()][2];
		for (int i = 0; i < AccountFromServerList.size(); i++) {
			fosaAccountsArray[i] = (AccountFromServerList.get(i)).split(":::");

			FOSAAccountNamesList.add(fosaAccountsArray[i][0] + ": "
					+ fosaAccountsArray[i][1]);
		}
		setAccFromSpinnerData(FOSAAccountNamesList);
	}

	private void splitLoanArray(List<String> loansArr) {
		// Format the Amount returned
		loansArray = new String[loansArr.size()][2];
		for (int i = 0; i < loansArr.size(); i++) {
			loansArray[i] = (loansArr.get(i)).split(":");

			loanNamesArrList.add(loansArray[i][0] + ": " + loansArray[i][1]);
		}
		setSpinnerData(loanNamesArrList);
	}

	public void setAccFromSpinnerData(List<String> accountFrom) {

		ArrayAdapter<String> accFROMadapter = new ArrayAdapter<String>(
				getActivity().getApplicationContext(),
				R.layout.spinner_selected_item_template, accountFrom);

		// Specify the layout to use when the list of choices appears
		accFROMadapter
				.setDropDownViewResource(R.layout.spinner_items_template);

		// Apply the adapter to the spinner
		accFromspinner.setAdapter(accFROMadapter);

		accFromspinner.setOnItemSelectedListener(new OnItemSelectedListener() {
			public void onItemSelected(AdapterView<?> parent, View view,
					int position, long id) {

				String acc = accFromspinner.getSelectedItem().toString();
				String[] split = acc.split(":");
				// An item was selected. You can retrieve the selected item
				// using
				selectedFOSAaccFrom = split[1];
				selectedFOSAaccNameFrom = split[0];
			}

			public void onNothingSelected(AdapterView<?> parent) {
			}
		});
	}

	// Get Loan Types on a separate thread
	private class getActiveLoanTypes extends
			AsyncTask<String, Void, SoapObject> {
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
				splitLoanArray(loanTypesArrList);
				// setSpinnerData();

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

	// Put all data for Applying a loan into an arrayList.
	public ArrayList<String> setRequestParameters() {
		Calendar c = Calendar.getInstance();
		// SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM/dd-hh.mm.ss");
		// repaymentDate = sdf.format(c.getTime());
		repaymentAmount = repaymentAmt.getText().toString();

		ArrayList<String> requestData = new ArrayList<String>();
		requestData.add(strTelephoneNo);
		requestData.add(selectedLoanName);
		requestData.add(selectedLoanType);
		requestData.add(selectedFOSAaccFrom);
		requestData.add(repaymentAmount);
		return requestData;
	}

	// Send Loan Request on a separate thread
	private class repayLoan extends AsyncTask<ArrayList<String>, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(getActivity());

		@Override
		protected void onPreExecute() {

			this.dialog.setMessage("Please wait...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(ArrayList<String>... params) {
			//

			String result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						SECOND_OPERATION_NAME);
				request.addProperty("strTelephoneNo", params[0].get(0).trim());
				request.addProperty("loanProdType", params[0].get(1).trim());
				request.addProperty("loanNo", params[0].get(2).trim());
				request.addProperty("account", params[0].get(3).trim());
				request.addProperty("repaymentAmount", params[0].get(4).trim());

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

					if (String.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equalsIgnoreCase("true")) {

						result = "OK";

					} else {
						result = "Request not sent.Error connecting to the server.";
						alert(result);
					}
					return result;
				}
			} catch (Exception e) {
				e.getMessage().toString();
			}
			return result;
		}

		@Override
		protected void onPostExecute(String res) {
			try {

				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
				}

				if (res.toLowerCase().trim().equalsIgnoreCase("OK")) {
					alert();
					repaymentAmt.getText().clear();
				} else {
					alert("Request not send.A server error has occurred");
				}

			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();
				else {
				}
			}
		}
	}

	@SuppressWarnings("unchecked")
	@SuppressLint("SimpleDateFormat")
	@Override
	public void onClick(View view) {
		if (repaymentAmt.getText().toString().equals("")
				|| repaymentAmt.getText().toString() == null) {
			alert("Please enter repayment amount.");
		} else {

			DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface dialog, int which) {
					switch (which) {
					case DialogInterface.BUTTON_POSITIVE:
						// Yes button clicked
						internetConnectionStatus = new CheckInternetConnection(
								getActivity()).isConnectingToInternet();
						if (internetConnectionStatus) {
							try {
								new repayLoan().execute(setRequestParameters());
							} catch (Exception e) {
								e.printStackTrace();
							}
						} else {
							alert("No internet connection!");
						}

						break;

					case DialogInterface.BUTTON_NEGATIVE:
						// No button clicked
						// do nothing
						break;
					}
				}
			};

			AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
			builder.setMessage(
					"Send " + "KES " + repaymentAmt.getText().toString()
							+ " as repayment for " + selectedLoanName + "?")
					.setPositiveButton("Yes", dialogClickListener)
					.setNegativeButton("No", dialogClickListener).show();
		}
	}

	public void alert(String text) {
		Toast.makeText(getActivity().getApplicationContext(), text,
				Toast.LENGTH_LONG).show();
	}

	public void alert() {
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				getActivity());

		alertDialogBuilder
				.setMessage("Your request has been received and is being processed");
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
