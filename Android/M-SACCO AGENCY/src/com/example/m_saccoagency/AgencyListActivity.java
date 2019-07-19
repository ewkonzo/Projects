package com.example.m_saccoagency;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class AgencyListActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_agency_list);

		String[] listArray = { "Account Activation", "Account Opening",
				"Member Registration", "Cash Withdraw", "Cash Deposit",
				"Loan Repayment", "Cash Transfer", "Share Deposit",
				"Balance Enquiry", "Mini Statement", "Change Client Pin" };
		ListView AgencyListView = (ListView) findViewById(R.id.AgencyList);
		/*
		 * ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
		 * android.R.layout.simple_list_item_1,listArray);
		 * AgencyListView.setAdapter(adapter);
		 */

		ArrayAdapter<String> ad = new ArrayAdapter<String>(this,
				R.layout.custom_lv_layout, R.id.textItem, listArray);
		AgencyListView.setAdapter(ad);

		AgencyListView.setOnItemClickListener(new OnItemClickListener() {
			@Override
			public void onItemClick(AdapterView<?> parent, View view,
					int position, long id) {

				Intent intent = null;
				switch (position) {
				case 0:
					intent = new Intent(AgencyListActivity.this,
							AccountActivationActivity.class);
					break;
				case 1:
					intent = new Intent(AgencyListActivity.this,
							AccountOpening.class);
					break;
				case 2:
					intent = new Intent(AgencyListActivity.this,
							MemberRegistration.class);
					break;

				case 3:
					intent = new Intent(AgencyListActivity.this,
							CashWithdraw.class);
					break;
				case 4:
					intent = new Intent(AgencyListActivity.this,
							CashDeposit.class);
					break;
				case 5:
					intent = new Intent(AgencyListActivity.this,
							LoanRepayment.class);
					break;
				case 6:
					intent = new Intent(AgencyListActivity.this,
							CashTransfer.class);
					break;
				case 7:
					intent = new Intent(AgencyListActivity.this,
							ShareDeposit.class);
					break;
				case 8:
					intent = new Intent(AgencyListActivity.this,
							BalanceEnquiry.class);
					break;
				case 9:
					intent = new Intent(AgencyListActivity.this,
							Ministatement.class);
					break;
				case 10:
					intent = new Intent(AgencyListActivity.this,
							ChangeClientPin.class);
					break;
				// add more if you have more items in listview
				// 0 is the first item 1 second and so on...
				}
				startActivity(intent);

			}
		});
	}

	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.menu_two, menu);
		return true;
	}

	public boolean onOptionsItemSelected(MenuItem item) {

		Intent intent;
		switch (item.getItemId()) {
		case R.id.settings:
			intent = new Intent(AgencyListActivity.this, Settings.class);
			startActivity(intent);
			break;
		case R.id.change_password:
			loadChangePinPrompt();
			break;
		case R.id.log_out:
			intent = new Intent(AgencyListActivity.this, Login.class);
			startActivity(intent);
			break;

		}

		return true;
	}

	public void loadChangePinPrompt() {
		LayoutInflater li = LayoutInflater.from(AgencyListActivity.this);
		View promptsView = li.inflate(R.layout.prompts_change_pin, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				AgencyListActivity.this);

		alertDialogBuilder.setView(promptsView);

		final EditText EtCurrentPin = (EditText) promptsView
				.findViewById(R.id.txtcpin);
		final EditText EtNewPin = (EditText) promptsView
				.findViewById(R.id.txtnpin);
		final EditText EtConfirmNewPin = (EditText) promptsView
				.findViewById(R.id.txtconpin);

		// set dialog message
		alertDialogBuilder
				.setCancelable(false)
				.setTitle("Change Client Pin")
				.setPositiveButton("OK", new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int id) {
						// get user input and set it to result
						// edit text
						String currentpin = EtCurrentPin.getText().toString();
						String newPin = EtNewPin.getText().toString();
						if (currentpin.equals("") || currentpin == null) {
							Toast("Please enter current pin");
							//EtCurrentPin.setError("Field cannot be null");
						} else if (newPin.equals("") || newPin == null) {
							EtNewPin.setError("Field cannot be null");
						} else {
							Toast("Current pin: " + currentpin);
						}
					}
				})
				.setNegativeButton("Cancel",
						new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog, int id) {
								dialog.cancel();
							}
						});

		// create alert dialog
		AlertDialog alertDialog = alertDialogBuilder.create();

		// show it
		alertDialog.show();
	}

	public void Toast(String message) {

		Toast.makeText(getApplicationContext(), message, Toast.LENGTH_LONG)
				.show();

	}

}
