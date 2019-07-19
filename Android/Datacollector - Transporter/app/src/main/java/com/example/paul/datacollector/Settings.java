package com.example.paul.datacollector;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.util.Log;
import android.util.Printer;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.List;
import java.util.Map;



public class Settings extends Activity {
    SharedPreferences sharedPreferences;
    EditText Scale;
    EditText printer;
    EditText ip;
   // Spinner route;
    static Routes Route = null;
    static Farmer farmer = null;
   //Spinner transporter;
    Button save;
    int tpos, rpos;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.settings);
        Scale = (EditText) findViewById(R.id.setscale);
        printer = (EditText) findViewById(R.id.setprinter);
        ip = (EditText) findViewById(R.id.setip);
        save = (Button) findViewById(R.id.settingssave);
        save.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                savePreferences("IP", ip.getText().toString());
                finish();
            }
        });
        sharedPreferences = getSharedPreferences("Settings", MODE_PRIVATE);
        Map<String, ?> keys = sharedPreferences.getAll();

        for (Map.Entry<String, ?> entry : keys.entrySet()) {
            Log.d("map values", entry.getKey() + ": " +
                    entry.getValue().toString());
        }
        Scale.setText(getpreferences("SCALE"));
        printer.setText(getpreferences("PRINTER"));
        ip.setText(getpreferences("IP"));
        tpos = getpreference("tpos");
        rpos = getpreference("rpos");
        ip.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    savePreferences("IP", ip.getText().toString());
                }
            }
        });
        Scale.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent BTIntent = new Intent(getApplicationContext(), DeviceListActivity.class);
                BTIntent.putExtra("SP", "S");
                startActivityForResult(BTIntent, DeviceListActivity.REQUEST_CONNECT_BT);

            }
        });

        printer.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent BT = new Intent(getApplicationContext(), DeviceListActivity.class);
                BT.putExtra("SP", "P");
                startActivityForResult(BT, DeviceListActivity.REQUEST_CONNECT_BT);

            }
        });
        //route = (Spinner) findViewById(R.id.setroute);
        DB db = new DB(this);

        Routes r = db.getroute(getpreferences("Route"));
        final ArrayAdapter<Routes> dataAdapter;
        dataAdapter = new ArrayAdapter<Routes>(Settings.this,
                android.R.layout.simple_spinner_item, db.getAllRoutes());
        dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
//        route.setAdapter(dataAdapter);
//        if (rpos != -1)
//            route.setSelection(rpos);
//        route.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
//            @Override
//            public void onItemSelected(AdapterView<?> adapterView, View view,
//                                       int position, long id) {
//                Route = dataAdapter.getItem(position);
//                savePreferences("rpos", position);
//                savePreferences("Route", Route.Code);
//                savePreferences("RouteName", Route.Description);
//            }
//
//            @Override
//            public void onNothingSelected(AdapterView<?> adapter) {
//            }
//        });

//        transporter = (Spinner) findViewById(R.id.settransporter);

        List<Farmer> t = db.getAllTransporters();

        final ArrayAdapter<Farmer> tAdapter;
        Farmer f = db.getFarmer(getpreferences("Transporter"));
        tAdapter = new ArrayAdapter<Farmer>(Settings.this,
                android.R.layout.simple_spinner_item, db.getAllTransporters());
        tAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
//        transporter.setAdapter(tAdapter);
//        if (tpos != -1)
//            transporter.setSelection(tpos);
//        transporter.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
//            @Override
//            public void onItemSelected(AdapterView<?> adapterView, View view,
//                                       int position, long id) {
//                // Here you get the current item (a User object) that is selected by its position
//                farmer = tAdapter.getItem(position);
//                savePreferences("tpos", position);
//                savePreferences("Transporter", farmer.No);
//                savePreferences("TransporterName", farmer.Name);
//            }
//
//            @Override
//            public void onNothingSelected(AdapterView<?> adapter) {
//            }
//        });
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
    private int getpreference(String key) {
        int pref = -1;
        int value = sharedPreferences.getInt(key, -1);

        if (value != -1) {
            pref = value;
        }
        return pref;
    }
    private void savePreferences(String key, int value) {

        Editor editor = sharedPreferences.edit();
        editor.putInt(key, value);
        editor.commit();
        // Log.i("Saved shared preference", key+""+value);
    }
    private void savePreferences(String key, String value) {
        Editor editor = sharedPreferences.edit();
        editor.putString(key, value);
        editor.commit();
        // Log.i("Saved shared preference", key+""+value);
    }
}
