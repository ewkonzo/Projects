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

public class FTransFOSAtoBOSAFragment extends Fragment implements
		OnClickListener {
	private static final String SOAP_ACTION = "http://tempuri.org/GetActiveFOSAAccounts";
	private static final String OPERATION_NAME = "GetActiveFOSAAccounts";

	private static final String SOAP_ACTION_TRANS_FUNDS = "http://tempuri.org/FundsTransfer";
	private static final String OPERATION_TRANS_FUNDS = "FundsTransfer";

	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = "";

	String strTelephoneNo = "";
	private EditText AmountToBOSAaccEdtxt;
	private Button FOSAtoBOSATransBtnClicked;
	private Spinner acc_from_spinner, acc_to_spinner;
	HomeActivity home;

	List<String> FOSAAccountFromArrList;
	List<String> BOSAAccountToArrList;
	String selectedFOSAacc = "";
	String selectedBosaAcc = "";
	String fosaAccFrom = "";

	List<String> FOSAAccountsList;
	List<String> FOSAAccountNamesList;

	double amountToTransfer = 0.0;
	public String myAccBalance = "";
	private CheckInternetConnection conn;
	private String[][] fosaAccountsArray;
	protected String selectedFOSAaccName;

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		View rootView = inflater
				.inflate(R.layout.funds_transfer_fosa_to_bosa_fragment,
						container, false);
		conn = new CheckInternetConnection(getActivity());
		FOSAAccountFromArrList = new ArrayList<String>();
		BOSAAccountToArrList = new ArrayList<String>();
		BOSAAccountToArrList.add("Shares");
		BOSAAccountToArrList.add("Deposits");
		FOSAAccountsList = new ArrayList<String>();
		FOSAAccountNamesList = new ArrayList<String>();

		acc_from_spinner = (Spinner) rootView.findViewById(R.id.fundsTransFosaToBosaFromAccSpinner);
		acc_to_spinner = (Spinner) rootView.findViewById(R.id.fundsTransFosaToBosaToAccSpinner);

		Configuration cfg = new Configuration();
		cfg.setTelephoneNo(getMyPhoneNO());
		strTelephoneNo = cfg.getTelephoneNo();		
		
		SOAP_ADDRESS = Configuration.getURL();
		AmountToBOSAaccEdtxt = (EditText) rootView
				.findViewById(R.id.fundsTransFosaToBosaAmtEdtxt);
		FOSAtoBOSATransBtnClicked = (Button) rootView
				.findViewById(R.id.fundsTransFOSAtoBOSAACCBtn);

		FOSAtoBOSATransBtnClicked.setOnClickListener(this);
		setAccToSpinnerData();
		return rootView;
	}

	@Override
	public void onActivityCreated(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onActivityCreated(savedInstanceState);
		// Function get member Info
		new getMyFOSAAccounts().execute(new String[] { strTelephoneNo });

	}

	public void setAccToSpinnerData() {

		ArrayAdapter<String> bosa_acc_adapter = new ArrayAdapter<String>(
				getActivity().getApplicationContext(),
				R.layout.spinner_selected_item_template, BOSAAccountToArrList);

		// Specify the layout to use when the list of choices appears
		bosa_acc_adapter
				.setDropDownViewResource(R.layout.spinner_items_template);

		// Apply the adapter to the acc_to_spinner
		acc_to_spinner.setAdapter(bosa_acc_adapter);
		acc_to_spinner.setOnItemSelectedListener(new OnItemSelectedListener() {
			public void onItemSelected(AdapterView<?> parent, View view,
					int position, long id) {
				selectedBosaAcc = acc_to_spinner.getSelectedItem().toString();
			}

			public void onNothingSelected(AdapterView<?> parent) {
			}
		});
	}

	public void setAccFromSpinnerData(List<String> array_of_accounts) {
		ArrayAdapter<String> fosa_acc_adapter = new ArrayAdapter<String>(
				getActivity().getApplicationContext(),
				R.layout.spinner_selected_item_template, array_of_accounts);

		// Specify the layout to use when the list of choices appears
		fosa_acc_adapter
				.setDropDownViewResource(R.layout.spinner_items_template);

		// Apply the adapter to the acc_from_spinner
		acc_from_spinner.setAdapter(fosa_acc_adapter);
		acc_from_spinner
				.setOnItemSelectedListener(new OnItemSelectedListener() {
					public void onItemSelected(AdapterView<?> parent,
							View view, int position, long id) {

						String acc = acc_from_spinner.getSelectedItem()
								.toString();
						String[] split = acc.split(":");

						selectedFOSAacc = split[1];
						selectedFOSAaccName = split[0];

					}

					public void onNothingSelected(AdapterView<?> parent) {
					}
				});
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

				for (int i = 0; i < res.getPropertyCount(); i++) {
					FOSAAccountFromArrList.add(res.getProperty(i).toString());
				}
				splitArray(FOSAAccountFromArrList);
				// setAccFromSpinnerData();

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

	public ArrayList<String> setRequestParameters() {
		amountToTransfer = Double.parseDouble(AmountToBOSAaccEdtxt.getText()
				.toString());

		ArrayList<String> requestData = new ArrayList<String>();
		requestData.add(strTelephoneNo);
		requestData.add(selectedFOSAacc);
		requestData.add(selectedBosaAcc.substring(0, 1));
		requestData.add(String.valueOf(amountToTransfer));
		return requestData;
	}

	public void splitArray(List<String> fOSAAccountFromArrList2) {
		// Format the Amount returned
		fosaAccountsArray = new String[fOSAAccountFromArrList2.size()][2];
		for (int i = 0; i < fOSAAccountFromArrList2.size(); i++) {
			fosaAccountsArray[i] = (fOSAAccountFromArrList2.get(i))
					.split(":::");

			FOSAAccountNamesList.add(fosaAccountsArray[i][0] + ": "
					+ fosaAccountsArray[i][1]);
		}
		setAccFromSpinnerData(FOSAAccountNamesList);

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
				request.addProperty("strReference", "FB");
				request.addProperty("AccFrom", params[0].get(1).toString()
						.trim());
				request.addProperty("AccTo", params[0].get(2).toString().trim());
				request.addProperty("AmountToTransfer", params[0].get(3).trim());
				request.addProperty("transactionType", "2");
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

					} else {
						result = "Request not sent.Please check your internet connection.";
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
					// Toast.makeText(getActivity().getApplicationContext(),
					// "Request sent", Toast.LENGTH_LONG).show();
					// no
					AmountToBOSAaccEdtxt.getText().clear();
				} else {
					Toast.makeText(
							getActivity().getApplicationContext(),
							"Request not Sent, Pease check your internet connection.",
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

	@SuppressLint("DefaultLocale")
	public void alert() {
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				getActivity());

		alertDialogBuilder
				.setMessage("Dear Customer,your request to transfer KES :"
						+ amountToTransfer + " from Account "
						+ selectedFOSAaccName + " to "
						+ selectedBosaAcc.toUpperCase()
						+ " Account has been received and is being processed.");
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

		if (selectedFOSAacc == null || selectedFOSAacc.equals("")) {
			Toast.makeText(getActivity(), "Please select FOSA account from",
					Toast.LENGTH_LONG).show();
		} else if (AmountToBOSAaccEdtxt.getText().toString() == null
				|| AmountToBOSAaccEdtxt.getText().toString().equals("")) {
			Toast.makeText(getActivity(), "Please enter amount",
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
