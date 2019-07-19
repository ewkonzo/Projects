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

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
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

public class FTransFOSAtoFOSAFragment extends Fragment implements
		OnItemSelectedListener, OnClickListener {
	private static final String SOAP_ACTION = "http://tempuri.org/GetActiveFOSAAccounts";
	private static final String OPERATION_NAME = "GetActiveFOSAAccounts";

	private static final String SOAP_ACTION_TRANS_FUNDS = "http://tempuri.org/FundsTransfer";
	private static final String OPERATION_TRANS_FUNDS = "FundsTransfer";

	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = "";

	private String strTelephoneNo = "";
	
	private EditText AmountToFOSAaccEdtxt, other_acc;
	private Button FOSAtoFOSATransBtnClicked;
	private Spinner accFromspinner, accTospinner;
	private CheckInternetConnection conn;

	List<String> AccountFromServerList;

	List<String> FOSAAccountsList;
	List<String> FOSAAccountNamesList;

	// Store split data from Server
	private String[][] fosaAccountsArray;

	String selectedFOSAaccFrom = "";
	String selectedFOSAaccNameFrom = "";

	String selectedFOSAaccTo = "";
	String selectedFOSAaccNameTo = "";

	double amountToTransfer = 0.0;

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		View rootView = inflater
				.inflate(R.layout.funds_transfer_fosa_to_fosa_fragment,
						container, false);

		conn = new CheckInternetConnection(getActivity());
		Configuration cfg = new Configuration();
		cfg.setTelephoneNo(getMyPhoneNO());
		strTelephoneNo = cfg.getTelephoneNo();	
		
		SOAP_ADDRESS = Configuration.getURL();

		AccountFromServerList = new ArrayList<String>();
		FOSAAccountsList = new ArrayList<String>();
		FOSAAccountNamesList = new ArrayList<String>();

		accFromspinner = (Spinner) rootView
				.findViewById(R.id.fundsTransFosaToFosaFROMSpinner);
		// accTospinner = (Spinner) rootView
		// .findViewById(R.id.fundsTransFosaToFosaTOSpinner);
		other_acc = (EditText) rootView
				.findViewById(R.id.fundsFosaToFosaACCTOEdtxt);

		AmountToFOSAaccEdtxt = (EditText) rootView
				.findViewById(R.id.fundsFosaToFosaAmtEdtxt);
		FOSAtoFOSATransBtnClicked = (Button) rootView
				.findViewById(R.id.fundsTransFosaToFosaAccBtn);

		FOSAtoFOSATransBtnClicked.setOnClickListener(this);

		return rootView;
	}

	@Override
	public void onActivityCreated(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onActivityCreated(savedInstanceState);
		// Function get accounts
		new getMyFOSAAccounts().execute(new String[] { strTelephoneNo });

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

	public void setAccToSpinnerData(List<String> accountTo) {

		ArrayAdapter<String> accTOadapter = new ArrayAdapter<String>(
				getActivity().getApplicationContext(),
				R.layout.spinner_selected_item_template, accountTo);

		// Specify the layout to use when the list of choices appears
		accTOadapter
				.setDropDownViewResource(R.layout.spinner_items_template_white);

		// Apply the adapter to the acc_to_spinner
		accTospinner.setAdapter(accTOadapter);
		accTospinner.setOnItemSelectedListener(new OnItemSelectedListener() {
			public void onItemSelected(AdapterView<?> parent, View view,
					int position, long id) {

				String acc = accTospinner.getSelectedItem().toString();
				String[] split = acc.split(":");
				// An item was selected. You can retrieve the selected item
				// using
				// selectedFOSAaccTo = split[1];
				// selectedFOSAaccNameTo = split[0];
			}

			public void onNothingSelected(AdapterView<?> parent) {
			}
		});
	}

	public void onItemSelected(AdapterView<?> parent, View view, int pos,
			long id) {

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
				// e.getMessage().toString();
			}
			return result;
		}

		@Override
		protected void onPostExecute(SoapObject res) {
			try {
				if (res.getPropertyCount() > 0) {
					for (int i = 0; i < 1; i++) {
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
		// setAccToSpinnerData(FOSAAccountNamesList);
	}

	public ArrayList<String> setRequestParameters() {
		amountToTransfer = Double.parseDouble(AmountToFOSAaccEdtxt.getText()
				.toString());

		ArrayList<String> requestData = new ArrayList<String>();
		requestData.add(strTelephoneNo);
		requestData.add(selectedFOSAaccFrom);
		requestData.add(selectedFOSAaccTo);
		requestData.add(String.valueOf(amountToTransfer));

		return requestData;
	}

	private class transferFunds extends
			AsyncTask<ArrayList<String>, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(getActivity());

		@Override
		protected void onPreExecute() {

			this.dialog.setMessage("Sending request...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(ArrayList<String>... params) {
			//

			String result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION_TRANS_FUNDS);
				request.addProperty("strTelephoneNo", params[0].get(0)
						.toString());
				request.addProperty("strReference", "FF");
				request.addProperty("AccFrom", params[0].get(1).toString()
						.trim());
				request.addProperty("AccTo", params[0].get(2).toString().trim());
				request.addProperty("AmountToTransfer", params[0].get(3).trim());
				request.addProperty("transactionType", "1");

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);

				httpTransport.call(SOAP_ACTION_TRANS_FUNDS, envelope);
				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;
				} else {
					SoapObject resultsRequestSOAP = (SoapObject) envelope.bodyIn;

					int n = resultsRequestSOAP.getPropertyCount();

					if (String.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equalsIgnoreCase("true")) {

						result = "OK";

					} else if (String
							.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equalsIgnoreCase("Pending")) {

						result = "Please wait, you have a pending transaction";

					} else if (String
							.valueOf(resultsRequestSOAP.getProperty(n - 1))
							.trim().equalsIgnoreCase("false")) {
						result = "Request could not be completed,a server error has occured.";
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
				} else {
					alertDlg(res);
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

		alertDialogBuilder
				.setMessage("Dear Customer,your request to transfer KES "
						+ amountToTransfer + " from Account "
						+ selectedFOSAaccNameFrom + " to Acc "
						+ selectedFOSAaccTo
						+ " has been received and is being processed.");
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

	public void alertDlg(String text) {
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

	@SuppressWarnings({ "unchecked", "deprecation" })
	@SuppressLint("SimpleDateFormat")
	@Override
	public void onClick(View view) {

		String sel_acc = other_acc.getText().toString().trim();

		if (selectedFOSAaccFrom == null || selectedFOSAaccFrom.equals("")) {
			Toast.makeText(getActivity(), "Please select source Account",
					Toast.LENGTH_LONG).show();
		} else if (sel_acc == null || sel_acc.equals("")) {
			Toast.makeText(getActivity(), "Please enter destination Account",
					Toast.LENGTH_LONG).show();
		} else if (sel_acc.length() < 10) {
			Toast.makeText(getActivity(),
					"Destination account must be more than 12 characters long",
					Toast.LENGTH_LONG).show();
		} else if (sel_acc.length() > 15) {
			Toast.makeText(
					getActivity(),
					"Destination account too long, must be less than 14 characters",
					Toast.LENGTH_LONG).show();
		} else if (AmountToFOSAaccEdtxt.getText().toString() == null
				|| AmountToFOSAaccEdtxt.getText().toString().equals("")) {
			Toast.makeText(getActivity(), "Please enter amount",
					Toast.LENGTH_LONG).show();
		} else if (selectedFOSAaccFrom.equals(selectedFOSAaccTo)) {
			Toast.makeText(
					getActivity(),
					"Please select a different account, you cannot transfer money to the same account",
					Toast.LENGTH_LONG).show();
		} else {
			selectedFOSAaccTo = sel_acc;
			try {
				AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
						getActivity());
				alertDialogBuilder.setMessage("Do you want to proceed?");
				alertDialogBuilder.setPositiveButton("yes",
						new DialogInterface.OnClickListener() {
							@Override
							public void onClick(DialogInterface arg0, int arg1) {
								try {
									if (conn.isConnectingToInternet()) {
										new transferFunds()
												.execute(setRequestParameters());
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
	
	private String getMyPhoneNO() 
	{
		SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(getActivity());
		String yourNumber = preferences.getString("telephoneKey", "");
		return yourNumber;
	}
}
