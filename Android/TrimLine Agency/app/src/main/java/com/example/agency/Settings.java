package com.example.agency;

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

EditText endpoint;
	SharedPreferences sharedPreferences;
	EditText printer;
	@Override
	protected void onCreate(final Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.settings);
		sharedPreferences = getSharedPreferences("Settings",MODE_PRIVATE);
		endpoint =(EditText)findViewById(R.id.endpoint);

				endpoint.setOnFocusChangeListener(new View.OnFocusChangeListener() {
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				if(!hasFocus)
					if (!endpoint.getText().equals(""))
					savePreferences("Endpoint",endpoint.getText().toString());
			}
		});
		endpoint.setText(getpreferences("Endpoint"));
		printer = (EditText)findViewById(R.id.printer);
		printer.setText(getpreferences("PRINTER"));
		printer.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				Intent BT = new Intent(getApplicationContext(), DeviceListActivity.class);
				BT.putExtra("SP", "P");
				startActivityForResult(BT, DeviceListActivity.REQUEST_CONNECT_BT);

			}
		});
	}

	public void Toast(String message) {

		Toast.makeText(getApplicationContext(), message, Toast.LENGTH_LONG)
				.show();

	}



	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		super.onActivityResult(requestCode, resultCode, data);
		try {
			switch (requestCode) {
				case DeviceListActivity. REQUEST_CONNECT_BT:
					if (resultCode == RESULT_OK) {
						String sp = data.getExtras().get("SP").toString();
						String extra = data.getExtras().get("device_address").toString();
						printer.setText(extra);
							savePreferences("PRINTER", extra);

					}
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	private String getpreferences(String key) {
		String pref = "";
		String value = sharedPreferences.getString(key, "");

		if (value != null || value != "") {
			pref = value;
		}
		return pref;
	}

	private void savePreferences(String key, String value) {

		Editor editor = sharedPreferences.edit();
		editor.putString(key, value);
		editor.commit();

		// Log.i("Saved shared preference", key+""+value);

	}


}
