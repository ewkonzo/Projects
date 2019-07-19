package com.example.m_saccoagency;

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

import org.ksoap2.SoapEnvelope;
import org.ksoap2.SoapFault;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import java.lang.reflect.Type;

import static com.example.m_saccoagency.AgencyListActivity.trans;

public class Login extends Activity implements OnClickListener {

   public static Agent agent;
   public String Pass, AgentCode;
    Intent intent = null;
    SharedPreferences sharedpreferences;
    private EditText ETAgentCode, ETPassword;
    private Button BtnLogin, BtnCancel;
    private boolean internetConnectionStatus = false;

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
                agent.agent_code= AgentCode;
                agent.pin = Pass;
                new UserLoginTask(agent).execute();
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

//        Intent intent = null;
//        switch (item.getItemId()) {
//            case R.id.action_settings:
//                intent = new Intent(Login.this, Settings.class);
//                break;
//        }
//        startActivity(intent);
        return true;
    }

    public void Toast(String message) {

        Toast.makeText(getApplicationContext(), message, Toast.LENGTH_LONG)
                .show();

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
    public class UserLoginTask extends AsyncTask<Agent, Void, Agent> {
        private final ProgressDialog dialog = new ProgressDialog(Login.this);
        private Agent magent;

        UserLoginTask(Agent paramAgent) {
            this.magent = paramAgent;
        }

        protected void onPreExecute() {
            this.dialog.setMessage("Signing in...");
            this.dialog.show();
        }

        @Override
        protected Agent doInBackground(Agent... params) {
            try {
                String myagent;
                Gson g = new Gson();
                Login.agent.message = null;
                myagent = g.toJson(this.magent);
                myagent = JsonParser.SendHttpPost(Login.this, "Login", myagent,
                        "login");

                Log.d("Agent Json", myagent);

                Type localType = new TypeToken<Agent>() {
                }.getType();
                this.magent = ((Agent) new Gson().fromJson(myagent, localType));

            } catch (Exception ex) {
                Log.e("Error.... sd", ex.toString());
                // ex.printStackTrace();
                if (!ex.getMessage().contains("Connection to")) {
                    this.magent.message = "No Connection, make sure that your mobile data is enabled, or you are on a wifi.";
                }

            }

            return magent;

        }

        protected void onPostExecute(Agent magent) {

            if (this.dialog.isShowing()) {
                this.dialog.dismiss();
            }
            try {
                if (magent.logged_in) {
                    ETPassword.setText("");
                    Login.agent = magent;
                    if (!Login.agent.Pin_changed)
                        loadChangePinPrompt();
                    else {
                        Login.this.intent = new Intent(Login.this,
                                AgencyListActivity.class);
                        Login.this.startActivity(Login.this.intent);
                        return;
                    }
                } else
                    ETPassword.setError(magent.message);
                    ETPassword.requestFocus();
                if (magent.message != null) {
                    Toast.makeText(Login.this.getApplicationContext(),
                            magent.message, Toast.LENGTH_LONG).show();
                    return;
                }
                          }
            catch (Exception ex)
            {
                ex.printStackTrace();
                misc.tost(Login.this ,getString(R.string.Unabletologin));
            }
        }

        public void loadChangePinPrompt() {
            LayoutInflater li = LayoutInflater.from(Login.this);
            View promptsView = li.inflate(R.layout.prompts_change_pin, null);
            AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
                    Login.this);

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
                        @Override
                        public void onClick(DialogInterface dialog, int id) {
                            // get user input and set it to result
                            // edit text

                        }
                    })
                    .setNegativeButton("Cancel",
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    dialog.cancel();
                                }
                            });





            AlertDialog alertDialog = alertDialogBuilder.create();

            // show it
            alertDialog.show();

            alertDialog.getButton(AlertDialog.BUTTON_POSITIVE).setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {

                    String currentpin = EtCurrentPin.getText().toString();
                    String newPin = EtNewPin.getText().toString();
                    String cpin= EtConfirmNewPin.getText().toString();
                    if (currentpin.equals("") || currentpin == null) {
                        EtCurrentPin.setError(getString(R.string.emptyfield));
                        EtCurrentPin.requestFocus();
                    } else if (newPin.equals("") || newPin == null) {
                        EtNewPin.setError(getString(R.string.emptyfield));
                        EtNewPin.requestFocus();
                    }  else if (cpin.equals("") || cpin == null) {
                        EtConfirmNewPin.setError(getString(R.string.emptyfield));
                        EtConfirmNewPin.requestFocus();
                    }
                    else if (!Login.agent.pin.equals(currentpin)) {
                        EtCurrentPin.setError("Invalid current pin");
                        EtCurrentPin.requestFocus();
                    }
                    else if (!newPin.equals(cpin)) {
                        EtConfirmNewPin.setError("Invalid pin confirmation");
                        EtConfirmNewPin.requestFocus();
                    }
                    else {
                        Login.agent.new_pin= newPin;
                        new ChangepassTask(Login.agent).execute();
                    }


                    //else dialog stays open. Make sure you have an obvious way to close the dialog especially if you set cancellable to false.
                }
            });
        }

    }
    public class ChangepassTask extends AsyncTask<Agent, Void, Agent> {
        private final ProgressDialog dialog = new ProgressDialog(Login.this);
        private Agent magent;

        ChangepassTask(Agent paramAgent) {
            this.magent = paramAgent;
        }

        protected void onPreExecute() {
            this.dialog.setMessage("Signing in...");
            this.dialog.show();
        }

        @Override
        protected Agent doInBackground(Agent... params) {
            try {
                String myagent;
                Gson g = new Gson();
                Login.agent.message = null;
                myagent = g.toJson(this.magent);
                myagent = JsonParser.SendHttpPost(Login.this, "Changepass", myagent,
                        "login");

                Log.d("Agent Json", myagent);

                Type localType = new TypeToken<Agent>() {
                }.getType();
                this.magent = ((Agent) new Gson().fromJson(myagent, localType));

            } catch (Exception ex) {
                Log.e("Error.... sd", ex.toString());
                // ex.printStackTrace();
                if (!ex.getMessage().contains("Connection to")) {
                    this.magent.message = "No Connection, make sure that your mobile data is enabled, or you are on a wifi.";
                }

            }

            return magent;

        }

        protected void onPostExecute(Agent magent) {

            if (this.dialog.isShowing()) {
                this.dialog.dismiss();
            }
            try {
                if (magent.logged_in) {
                    Login.this.intent = new Intent(Login.this,
                            AgencyListActivity.class);
                    Login.this.startActivity(Login.this.intent);
                } else
                    misc.tost(Login.this, "Unable to change your pin");
            }
            catch (Exception ex)
            {
                ex.printStackTrace();

            }
        }

    }
}
