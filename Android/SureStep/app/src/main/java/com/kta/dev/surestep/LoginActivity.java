package com.kta.dev.surestep;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;

/**
 * A login screen that offers login via email/password.
 */
public class LoginActivity extends Activity {

    public static final String KEY_HAS_LOGGED_IN = "is_previously_started";
    public static final String KEY_USERNAME = "username";
    public static final String KEY_EMAIL = "email";
    private static final String URL = "http://myjobseye.co.ke/mjeapp/api/";
    private static final String FORGOT_URL = "http://www.myjobseye.com/forgot.html";
    private static final String TAG_USER_NAME = "user";
    private static final String TAG_USER_EMAIL = "email";
    EditText textName, textPass;

    Button buttonLogin,btnLog;
    SharedPreferences mPreferences;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        //rem to move this to splashactivity
        mPreferences = PreferenceManager.getDefaultSharedPreferences(LoginActivity.this);
        boolean hasLoggedIn = mPreferences.getBoolean(LoginActivity.KEY_HAS_LOGGED_IN, false);
        if (hasLoggedIn) {
            Intent intent = new Intent(getApplicationContext(), ContactsActivity.class);

            intent.putExtra(KEY_USERNAME, mPreferences.getString(KEY_USERNAME, ""));
            intent.putExtra(KEY_EMAIL, mPreferences.getString(KEY_EMAIL, ""));

            startActivity(intent);
        }

        textName = (EditText) findViewById(R.id.txtLoginName);
        textPass = (EditText) findViewById(R.id.txtPassword);
        btnLog=(Button)findViewById(R.id.btnLog);
        btnLog.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent= new Intent(getApplicationContext(),ContactsActivity.class);
                startActivity(intent);
            }
        });


        buttonLogin = (Button) findViewById(R.id.btnLogin);
        buttonLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                if (textName.length() == 0 || textPass.length() == 0) {
                    Toast.makeText(getApplicationContext(), "Please enter name and password",
                            Toast.LENGTH_SHORT).show();
                } else {
                    Map<String, String> params = new HashMap<>();
                    params.put("token", "LOGIN");
                    params.put("username", textName.getText().toString());
                    params.put("password", textPass.getText().toString());

                    CustomJsonObjectRequest request = new CustomJsonObjectRequest(Request.Method.POST, URL, params,
                            new Response.Listener<JSONObject>() {
                                @Override
                                public void onResponse(JSONObject response) {
                                    Log.d("Response: ", response.toString());
                                    try {
                                        String status = response.getString("status");
                                        if (status.equalsIgnoreCase("fail")) {
                                            Toast.makeText(LoginActivity.this, "Login failed", Toast.LENGTH_SHORT).show();
                                        } else {

                                            JSONArray jsonArray = response.getJSONArray("profile");

                                            JSONObject person = jsonArray.getJSONObject(0);

                                            String userName = person.getString(TAG_USER_NAME);
                                            String userEmail = person.getString(TAG_USER_EMAIL);


                                            //change activity here and pass profile info
                                            Intent intent = new Intent(getApplicationContext(), ContactsActivity.class);
                                            intent.putExtra("username", userName);
                                            intent.putExtra("email", userEmail);


                                            //Store login details
                                            SharedPreferences.Editor editor = mPreferences.edit();
                                            editor.putBoolean(KEY_HAS_LOGGED_IN, true);

                                            editor.putString(KEY_USERNAME, userName);
                                            editor.putString(KEY_EMAIL, userEmail);

                                            editor.apply();

                                            startActivity(intent);
                                        }
                                    } catch (JSONException e) {
                                        e.printStackTrace();
                                        Toast.makeText(getApplicationContext(),
                                                "Error: " + e.getMessage(),
                                                Toast.LENGTH_LONG).show();
                                    }
                                }
                            },
                            new Response.ErrorListener() {
                                @Override
                                public void onErrorResponse(VolleyError error) {
                                    //...
                                }
                            });
                    AppController.getInstance().addToRequestQueue(request);
                }
            }

        });


    }

}
