package com.example.m_saccoagency;

import java.lang.reflect.Type;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.text.TextUtils;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.utils.CheckInternetConnection;
import com.example.utils.Configuration;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

public class Login extends Activity implements OnClickListener {

	private EditText ETAgentCode, ETPassword;
	private Button BtnLogin, BtnCancel;
	public String Pass, AgentCode;
	Intent intent = null;
	public static Agent agent;

	private static final String SOAP_ACTION = "http://tempuri.org/Login";
	private static final String OPERATION = "Login";

	private static final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
	private static String SOAP_ADDRESS = "";

	private boolean internetConnectionStatus = false;
	SharedPreferences sharedpreferences;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.login_activity);

		agent = new Agent();
		ETAgentCode = (EditText) findViewById(R.id.txtusername);
		ETPassword = (EditText) findViewById(R.id.txtpassword);
		BtnLogin = (Button) findViewById(R.id.Login);
		BtnCancel = (Button) findViewById(R.id.loginCancel);

		SharedPreferences preferences = PreferenceManager
				.getDefaultSharedPreferences(this);
		String storedAgentCode = preferences.getString("agentKey", "");
		if (storedAgentCode != null || storedAgentCode != "") {
			ETAgentCode.setText(storedAgentCode);
		}
		// Confi
		Configuration cfg = new Configuration();
		SOAP_ADDRESS = Configuration.getURL();

		BtnLogin.setOnClickListener(this);
		BtnCancel.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				new AlertDialog.Builder(Login.this)
						// .setIcon(android.R.drawable.ic_dialog_alert)
						.setTitle("Exit")
						.setMessage("Are you sure you want to exit?")
						.setPositiveButton("Yes",
								new DialogInterface.OnClickListener() {
									@Override
									public void onClick(DialogInterface dialog,
											int which) {
										finish();
									}

								}).setNegativeButton("No", null).show();
			}
		});
	}

	@Override
	public void onClick(View v) {
		// TODO Auto-generated method stub
		Pass = ETPassword.getText().toString();
		AgentCode = ETAgentCode.getText().toString();

		this.ETAgentCode.setError(null);
		this.ETPassword.setError(null);
		// Log.e("Got here", "yehhhhs");
		if (AgentCode.equals("") || AgentCode == null) {

			// Toast("Please Enter Agent Code");
			this.ETAgentCode.setError("Please enter Agent Code");

		} else if (Pass.equals("") || Pass == null) {

			this.ETPassword.setError("Please enter Password");
			// Toast("Please Enter password");

		} else {
			internetConnectionStatus = new CheckInternetConnection(Login.this)
					.isConnectingToInternet();
			if (internetConnectionStatus) {
				savePreferences("agentKey", AgentCode);
				new LoginTask().execute(new String[] { AgentCode, Pass });
			} else {

				DialogBox("Internet Connection",
						"Sorry you have no internet connection");
			}
		}
	}

	private void savePreferences(String key, String value) {

		SharedPreferences sharedPreferences = PreferenceManager
				.getDefaultSharedPreferences(this);
		Editor editor = sharedPreferences.edit();
		editor.clear();
		editor.putString(key, value);
		editor.commit();
		// Log.i("Saved shared preference", key+""+value);

	}

	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	public boolean onOptionsItemSelected(MenuItem item) {

		Intent intent = null;
		switch (item.getItemId()) {
		case R.id.action_settings:
			intent = new Intent(Login.this, Settings.class);
			break;
		}
		startActivity(intent);
		return true;
	}

	public void Toast(String message) {

		Toast.makeText(getApplicationContext(), message, Toast.LENGTH_LONG)
				.show();

	}

	public class Changepassword {
		public String New_password;
		public String Old_password;
		public boolean changed;

		public Changepassword() {
		}

		public void changepin(final Context paramContext) {
			LayoutInflater localObject = LayoutInflater.from(Login.this);
			View promptsView = localObject.inflate(R.layout.prompts_change_pin,
					null);
			final EditText localEditText1 = (EditText) ((View) promptsView)
					.findViewById(R.id.txtcpin);
			final EditText localEditText2 = (EditText) ((View) promptsView)
					.findViewById(R.id.txtnpin);
			final EditText localEditText3 = (EditText) ((View) promptsView)
					.findViewById(R.id.txtconpin);
			AlertDialog.Builder localBuilder = new AlertDialog.Builder(
					Login.this);
			localBuilder.setTitle("Client Change Pin");
			localBuilder.setView((View) promptsView);
			localBuilder.setPositiveButton("Ok",
					new DialogInterface.OnClickListener() {
						public void onClick(
								DialogInterface paramAnonymousDialogInterface,
								int paramAnonymousInt) {
							String pv = localEditText1.getText().toString();
							String str1 = localEditText2.getText().toString();
							String str2 = localEditText3.getText().toString();
							if (TextUtils.isEmpty(pv)) {
								localEditText1.setError(paramContext
										.getString(R.string.error_field_required));
								localEditText1.requestFocus();
								return;
							}
							if (TextUtils.isEmpty(str1)) {
								localEditText2.setError(paramContext
										.getString(R.string.error_field_required));
								localEditText2.requestFocus();
								return;
							}
							if (TextUtils.isEmpty(str2)) {
								localEditText3.setError(paramContext
										.getString(R.string.error_field_required));
								localEditText3.requestFocus();
								return;
							}
							if (!localEditText2
									.equals(Login.Changepassword.this.Old_password)) {
								localEditText2.setError(paramContext
										.getString(R.string.error_same_password));
								localEditText2.requestFocus();
								return;
							}
							if (!str1.equals(str2)) {
								localEditText3.setError(paramContext
										.getString(R.string.error_confirmation_error));
								localEditText3.requestFocus();
								return;
							}
							Login.Changepassword.this.changed = true;
							Login.Changepassword.this.New_password = str1;
							Login.agent.new_pin = str1;
							if (Login.this.intent != null) {
								Login.this.startActivity(Login.this.intent);
							}
							// new ChangepassTask(agent).execute();
							// new UserLoginTask(agent).execute();
							// new ChangepassTask(Login.this,
							// Login.agent).execute();
						}
					});
			localBuilder.setNegativeButton("Cancel",
					new DialogInterface.OnClickListener() {
						public void onClick(
								DialogInterface paramAnonymousDialogInterface,
								int paramAnonymousInt) {
							paramAnonymousDialogInterface.cancel();
						}
					});

			AlertDialog alertDialog = localBuilder.create();
			alertDialog.show();

		}
	}

	private class LoginTask extends AsyncTask<String, Void, String> {
		private final ProgressDialog dialog = new ProgressDialog(Login.this);

		@Override
		protected void onPreExecute() {
			// Log.d("got here point 2", "yes");
			this.dialog.setMessage("Signing in...");
			this.dialog.show();
		}

		@Override
		protected String doInBackground(String... params) {
			//

			String result = null;
			try {

				SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,
						OPERATION);
				request.addProperty("AgentCode", params[0].toString());
				request.addProperty("Pin", params[1].toString());

				SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
						SoapEnvelope.VER11);
				envelope.dotNet = true;

				envelope.setOutputSoapObject(request);

				HttpTransportSE httpTransport = new HttpTransportSE(
						SOAP_ADDRESS);
				Log.d("SOAP_ADDRESS", SOAP_ADDRESS);
				Log.d("My  request", request.toString());
				httpTransport.call(SOAP_ACTION, envelope);
				if (envelope.bodyIn instanceof SoapFault) {
					String str = ((SoapFault) envelope.bodyIn).faultstring;
					Log.i("Sent Request", str);
				} else {
					SoapObject resultsRequestSOAP = (SoapObject) envelope.bodyIn;
					// Log.d("WS", String.valueOf(resultsRequestSOAP));

					int n = resultsRequestSOAP.getPropertyCount();
					Log.d("Count", String.valueOf(n));
					Log.d("Returned Value", String.valueOf(resultsRequestSOAP
							.getProperty(n - 1)));

					if (n > 0) {
						result = String.valueOf(resultsRequestSOAP
								.getProperty(n - 1));
					} else {
						result = "Request not sent.Please check your internet connection.";
					}
					Log.d("result", result);
					// return result;
				}
			} catch (Exception e) {
				Log.e("Erorr....", e.getMessage().toString());
			}
			return result;

		}

		@Override
		protected void onPostExecute(String res) {
			try {

				Log.d("onPostExecute", res);

				if (this.dialog.isShowing()) {
					this.dialog.dismiss();
				}
				if (res.equalsIgnoreCase("true")) {

					if (!Pass.equals("") || Pass != null) {
						Configuration config = new Configuration();
						config.setAgentPin(Pass);
						Log.d("Pass :", Pass);
					}
					Intent intent = new Intent(getApplicationContext(),
							AgencyListActivity.class);
					// Close all views before launching Dashboard
					intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
					// HomeScreen.putExtras(bundle);
					startActivity(intent);
				} else if (res.equalsIgnoreCase("false")) {

					DialogBox("", "Sorry, Incorrect Login credentials");
				} else if (res.equalsIgnoreCase("Inactive account")) {

					DialogBox("", res);

				}

				// DialogBoxWithRefresh("", res);

			} catch (Exception ex) {

				if (ex.getMessage() == null)
					ex.printStackTrace();

				else {
					// DialogBox("errorr.. ", ex.getMessage());
					Log.i(ex.getMessage(), ex.getMessage());
				}
			}

			// new getMyBeneficiaries().execute(new String[] { strTelephoneNo
			// });
		}
	}

	public class UserLoginTask extends AsyncTask<Agent, Void, Void> {
		private final ProgressDialog dialog = new ProgressDialog(Login.this);
		private Agent magent;

		protected void onPreExecute() {
			this.dialog.setMessage("Signing in...");
			this.dialog.show();
		}

		UserLoginTask(Agent paramAgent) {
			this.magent = paramAgent;
		}

		@Override
		protected Void doInBackground(Agent... params) {
			try {
				String myagent;
				Gson g = new Gson();
				Login.agent.message = null;
				myagent = g.toJson(this.magent);
				myagent = JsonParser.SendHttpPost(Login.this, "Login", myagent,
						"Login");

				Log.d("Agent Json", myagent);

				Type localType = new TypeToken<Agent>() {
				}.getType();
				this.magent = ((Agent) new Gson().fromJson(myagent, localType));
				Log.d("magent ", magent.toString());
			} catch (Exception ex) {
				Log.e("Error.... sd", ex.toString());
				// ex.printStackTrace();
				if (!ex.getMessage().contains("Connection to")) {
					this.magent.message = "No Connection, make sure that your mobile data is enabled, or you are on a wifi.";
				}

			}
			Log.d("got here test", "Test");
			Log.d("Login status", String.valueOf(magent.logged_in));
			if (this.dialog.isShowing()) {
				this.dialog.dismiss();
			}
			if (magent.logged_in) {
				Login.agent = magent;
				Login.this.intent = new Intent(Login.this,
						AgencyListActivity.class);
				Login.this.startActivity(Login.this.intent);
			}
			return null;

		}

		protected void onPostExecute() {
			Log.d("got here test", "Test 2");
			if (this.dialog.isShowing()) {
				this.dialog.dismiss();
			}

			if (magent.logged_in) {
				Login.agent = magent;
				Login.this.intent = new Intent(Login.this,
						AgencyListActivity.class);
				/*
				 * if (!paramAgent.Pin_changed) { Login.Changepassword
				 * localChangepassword = new Login.Changepassword();
				 * localChangepassword.Old_password = paramAgent.pin;
				 * localChangepassword.changepin(Login.this); if
				 * (localChangepassword.changed) { paramAgent.new_pin =
				 * localChangepassword.New_password; } return; }
				 */
				Login.this.startActivity(Login.this.intent);
				return;
			}
			if (magent.message != null) {
				Toast.makeText(Login.this.getApplicationContext(),
						magent.message, 1).show();
				return;
			}
			// Login.this.agentpin.setError(Login.this.getString(2131492892));
		}

	}

	public void DialogBox(String title, String text) {
		try {
			AlertDialog ad = new AlertDialog.Builder(this).create();
			ad.setCancelable(false);
			ad.setTitle(title);
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
	public void onBackPressed() {
		new AlertDialog.Builder(this)
				// .setIcon(android.R.drawable.ic_dialog_alert)
				.setTitle("Exit")
				.setMessage("Are you sure you want to exit?")
				.setPositiveButton("Yes",
						new DialogInterface.OnClickListener() {
							@Override
							public void onClick(DialogInterface dialog,
									int which) {
								finish();
							}

						}).setNegativeButton("No", null).show();
	}
}
