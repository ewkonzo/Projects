package com.example.paul.m_branch;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.List;
import java.util.Map;



public class Settings extends Activity {
    SharedPreferences sharedPreferences;
    EditText Scale;
    EditText printer;
    EditText ip,copies;
    Button save;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.settings);

        printer = (EditText) findViewById(R.id.setprinter);
        copies =(EditText)findViewById(R.id.copiestoprint);
        ip = (EditText) findViewById(R.id.setip);
        sharedPreferences = getSharedPreferences("Settings",MODE_PRIVATE);
        Map<String,?> keys = sharedPreferences.getAll();

        for(Map.Entry<String,?> entry : keys.entrySet()){
            Log.d("map values",entry.getKey() + ": " +
                    entry.getValue().toString());
        }
        save = (Button)findViewById(R.id.savesetttings);
        save.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                savePreferences("IP", ip.getText().toString());
                savePreferences("PRINTER", printer.getText().toString());
                savePreferences("COPIES", copies.getText().toString());
                Toast.makeText(getApplicationContext(),"Settings saved successfully",Toast.LENGTH_LONG).show();
                finish();
            }
        });
        printer.setText(getpreferences("PRINTER"));
        ip.setText(getpreferences("IP"));

       ip.setOnFocusChangeListener(new View.OnFocusChangeListener() {
           @Override
           public void onFocusChange(View v, boolean hasFocus) {
               if (!hasFocus)
               {
                   savePreferences("IP", ip.getText().toString());
               }
           }
       });

        printer.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus)
                {

                }
            }
        });
        printer.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent BT = new Intent(Settings.this, DeviceListActivity.class);
                BT.putExtra("SP", "P");
                startActivityForResult(BT, DeviceListActivity.REQUEST_CONNECT_BT);

            }
        });

        DB db = new DB(this);


    }


    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        try {
            switch (requestCode) {
                case DeviceListActivity.REQUEST_CONNECT_BT:
                    if (resultCode == RESULT_OK) {
                        String sp = data.getExtras().get("SP").toString();
                        String extra = data.getExtras().get("device_address").toString();
                        if (sp.equals("S")) {
                            Scale.setText(extra);
                            savePreferences("SCALE", extra);

                        } else if (sp.equals("P")) {
                            printer.setText(extra);
                            savePreferences("PRINTER", extra);
                        }
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
