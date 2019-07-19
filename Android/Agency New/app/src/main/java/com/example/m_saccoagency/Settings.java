package com.example.m_saccoagency;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

public class Settings extends Activity {

	String AgentCode;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.settings);

		String[] listArray = { "Agent Code", "Host" };
		ListView SettingsListView = (ListView) findViewById(R.id.lv_settings);

		ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
				android.R.layout.simple_list_item_1, listArray);
		SettingsListView.setAdapter(adapter);

		SettingsListView.setOnItemClickListener(new OnItemClickListener() {
			@Override
			public void onItemClick(AdapterView<?> parent, View view,
					int position, long id) {

				switch (position) {
				case 0:
					loadACPrompt();
					break;
				case 1:
					loadHostPrompt();
					break;
				// add more if you have more items in listview
				// 0 is the first item 1 second and so on...
				}

			}
		});

	}

	public void Toast(String message) {

		Toast.makeText(getApplicationContext(), message, Toast.LENGTH_LONG)
				.show();

	}

	public void loadACPrompt() {
		LayoutInflater li = LayoutInflater.from(Settings.this);
		View promptsView = li.inflate(R.layout.prompts_agentcode, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				Settings.this);

		alertDialogBuilder.setView(promptsView);

		final EditText EtAC = (EditText) promptsView
				.findViewById(R.id.et_agentcode);
		// SET AC PREF
		SharedPreferences preferences = PreferenceManager
				.getDefaultSharedPreferences(this);
		String storedAgentCode = preferences.getString("ac", "");
		Log.d("AC", storedAgentCode);
		EtAC.setText(storedAgentCode);
		if (storedAgentCode != null || storedAgentCode != "") {
			EtAC.setText(storedAgentCode);
		}
		// set dialog message
		alertDialogBuilder
				.setCancelable(false)
				.setTitle("Agent Code")
				.setPositiveButton("OK", new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int id) {
						// get user input and set it to result
						// edit text
					String	AC = EtAC.getText().toString();
					if(AC != "" || AC != null){
						savePreferences("ac", AC);
					}
					Log.d("AC", AC);
						//Toast(AC);
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

	public void loadHostPrompt() {
		LayoutInflater li = LayoutInflater.from(Settings.this);
		View promptsView = li.inflate(R.layout.prompts_host, null);
		AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
				Settings.this);

		alertDialogBuilder.setView(promptsView);

		final EditText EtHost = (EditText) promptsView
				.findViewById(R.id.et_host);
		// SET HOST PREF
				SharedPreferences preferences = PreferenceManager
						.getDefaultSharedPreferences(this);
				String storedAgentCode = preferences.getString("host", "");
				Log.d("Host..", storedAgentCode);
				if (storedAgentCode != null || storedAgentCode != "") {
					EtHost.setText(storedAgentCode);
				}
		// set dialog message
		alertDialogBuilder
				.setCancelable(false)
				.setTitle("Host Ip address")
				.setPositiveButton("OK", new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int id) {
						// get user input and set it to result
						// edit text
					String	Host = EtHost.getText().toString();
					if(Host !="" || Host != null){
						savePreferences("host", Host);
					}
						//Toast(Host);
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


	private void savePreferences(String key, String value) {

		SharedPreferences sharedPreferences = PreferenceManager
				.getDefaultSharedPreferences(this);
		Editor editor = sharedPreferences.edit();
		editor.clear();
		editor.putString(key, value);
		editor.commit();

		// Log.i("Saved shared preference", key+""+value);

	}
}
