package com.example.paul.a_sacco;

import android.app.AlertDialog;
import android.app.AlertDialog.Builder;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.DialogInterface.OnClickListener;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.v7.app.ActionBarActivity;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import java.lang.reflect.Type;

public class Login
  extends ActionBarActivity
{
  public static Agent agent;
  EditText agentcode = null;
  EditText agentpin = null;
  Button cancel = null;
  Intent intent = null;
  Button login = null;
  
  private boolean isPasswordValid(String paramString)
  {
    if (paramString.length() > 3) {}
    for (boolean bool = true;; bool = false) {
      return bool;
    }
  }
  
  public void attemptLogin()
  {
    this.agentcode.setError(null);
    this.agentpin.setError(null);
    String str1 = this.agentcode.getText().toString();
    String str2 = this.agentpin.getText().toString();
    int j = 0;
    int i = j;
    if (!TextUtils.isEmpty(str2))
    {
      i = j;
      if (!isPasswordValid(str2))
      {
        this.agentpin.setError(getString(2131492894));
        i = 1;
      }
    }
    if (TextUtils.isEmpty(str1))
    {
      this.agentcode.setError(getString(2131492891));
      i = 1;
    }
    if (i != 0) {
      return;
    }
    agent.agent_code = str1;
    agent.pin = str2;
    new UserLoginTask(agent).execute(new Void[] { (Void)null });
  }
  
  protected void onCreate(Bundle paramBundle)
  {
    super.onCreate(paramBundle);
    setContentView(2130903072);
    this.agentcode = ((EditText)findViewById(2131296356));
    this.agentpin = ((EditText)findViewById(2131296358));
    this.login = ((Button)findViewById(2131296359));
    this.cancel = ((Button)findViewById(2131296331));
    this.login.setOnClickListener(new View.OnClickListener()
    {
      public void onClick(View paramAnonymousView)
      {
        Login.this.attemptLogin();
      }
    });
    agent = new Agent();
    paramBundle = PreferenceManager.getDefaultSharedPreferences(this).getString("Agency_Code", "");
    if (!paramBundle.equals("")) {
      this.agentcode.setText(paramBundle);
    }
  }
  
  public boolean onCreateOptionsMenu(Menu paramMenu)
  {
    getMenuInflater().inflate(2131623939, paramMenu);
    return true;
  }
  
  public boolean onOptionsItemSelected(MenuItem paramMenuItem)
  {
    if (paramMenuItem.getItemId() == 2131296384)
    {
      startActivity(new Intent(getApplicationContext(), SettingsActivity.class));
      return true;
    }
    return super.onOptionsItemSelected(paramMenuItem);
  }
  
  public class ChangepassTask
    extends AsyncTask<Void, Void, Agent>
  {
    private Agent magent;
    
    ChangepassTask(Agent paramAgent)
    {
      this.magent = paramAgent;
    }
    
    protected Agent doInBackground(Void... paramVarArgs)
    {
      try
      {
        paramVarArgs = new Gson();
        Login.agent.message = null;
        paramVarArgs = paramVarArgs.toJson(this.magent);
        paramVarArgs = JsonParser.SendHttpPost(Login.this, "Changepass", paramVarArgs, "login");
        Type localType = new TypeToken() {}.getType();
        this.magent = ((Agent)new Gson().fromJson(paramVarArgs, localType));
        paramVarArgs = this.magent;
        return paramVarArgs;
      }
      catch (Exception paramVarArgs)
      {
        paramVarArgs.printStackTrace();
        if (!paramVarArgs.getMessage().contains("Connection to")) {}
      }
      for (this.magent.message = "No Connection, make sure that your mobile data is enabled, or you are on a wifi.";; this.magent.message = paramVarArgs.getMessage()) {
        return this.magent;
      }
    }
    
    protected void onCancelled() {}
    
    protected void onPostExecute(Agent paramAgent) {}
    
    protected void onPreExecute() {}
  }
  
  public class Changepassword
  {
    public String New_password;
    public String Old_password;
    public boolean changed;
    
    public Changepassword() {}
    
    public void changepin(final Context paramContext)
    {
      final Object localObject = LayoutInflater.from(paramContext).inflate(2130903073, null);
      final EditText localEditText1 = (EditText)((View)localObject).findViewById(2131296360);
      final EditText localEditText2 = (EditText)((View)localObject).findViewById(2131296361);
      final EditText localEditText3 = (EditText)((View)localObject).findViewById(2131296362);
      AlertDialog.Builder localBuilder = new AlertDialog.Builder(Login.this);
      localBuilder.setTitle("Client Change Pin");
      localBuilder.setView((View)localObject);
      localBuilder.setPositiveButton("Ok", new DialogInterface.OnClickListener()
      {
        public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {}
      });
      localBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener()
      {
        public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {}
      });
      localObject = localBuilder.create();
      ((AlertDialog)localObject).show();
      ((AlertDialog)localObject).getButton(-1).setOnClickListener(new View.OnClickListener()
      {
        public void onClick(View paramAnonymousView)
        {
          paramAnonymousView = localEditText1.getText().toString();
          String str1 = localEditText2.getText().toString();
          String str2 = localEditText3.getText().toString();
          if (TextUtils.isEmpty(paramAnonymousView))
          {
            localEditText1.setError(paramContext.getString(2131492891));
            localEditText1.requestFocus();
            return;
          }
          if (TextUtils.isEmpty(str1))
          {
            localEditText2.setError(paramContext.getString(2131492891));
            localEditText2.requestFocus();
            return;
          }
          if (TextUtils.isEmpty(str2))
          {
            localEditText3.setError(paramContext.getString(2131492891));
            localEditText3.requestFocus();
            return;
          }
          if (!paramAnonymousView.equals(Login.Changepassword.this.Old_password))
          {
            localEditText1.setError(paramContext.getString(2131492890));
            localEditText1.requestFocus();
            return;
          }
          if (!str1.equals(str2))
          {
            localEditText3.setError(paramContext.getString(2131492889));
            localEditText3.requestFocus();
            return;
          }
          Login.Changepassword.this.changed = true;
          Login.Changepassword.this.New_password = str1;
          Login.agent.new_pin = str1;
          localObject.dismiss();
          if (Login.this.intent != null) {
            Login.this.startActivity(Login.this.intent);
          }
          new Login.ChangepassTask(Login.this, Login.agent).execute(new Void[] { (Void)null });
        }
      });
      ((AlertDialog)localObject).getButton(-2).setOnClickListener(new View.OnClickListener()
      {
        public void onClick(View paramAnonymousView)
        {
          Login.Changepassword.this.changed = false;
          localObject.dismiss();
        }
      });
    }
  }
  
  public class UserLoginTask
    extends AsyncTask<Void, Void, Agent>
  {
    private final ProgressDialog dialog = new ProgressDialog(Login.this);
    private Agent magent;
    
    UserLoginTask(Agent paramAgent)
    {
      this.magent = paramAgent;
    }
    
    protected Agent doInBackground(Void... paramVarArgs)
    {
      try
      {
        paramVarArgs = new Gson();
        Login.agent.message = null;
        paramVarArgs = paramVarArgs.toJson(this.magent);
        paramVarArgs = JsonParser.SendHttpPost(Login.this, "Login", paramVarArgs, "Login");
        Type localType = new TypeToken() {}.getType();
        this.magent = ((Agent)new Gson().fromJson(paramVarArgs, localType));
        paramVarArgs = this.magent;
        return paramVarArgs;
      }
      catch (Exception paramVarArgs)
      {
        paramVarArgs.printStackTrace();
        if (!paramVarArgs.getMessage().contains("Connection to")) {}
      }
      for (this.magent.message = "No Connection, make sure that your mobile data is enabled, or you are on a wifi.";; this.magent.message = paramVarArgs.getMessage()) {
        return this.magent;
      }
    }
    
    protected void onCancelled() {}
    
    protected void onPostExecute(Agent paramAgent)
    {
      if (this.dialog.isShowing()) {
        this.dialog.dismiss();
      }
      if (paramAgent.logged_in)
      {
        Login.agent = paramAgent;
        Login.this.intent = new Intent(Login.this, AgencyListActivity.class);
        if (!paramAgent.Pin_changed)
        {
          Login.Changepassword localChangepassword = new Login.Changepassword(Login.this);
          localChangepassword.Old_password = paramAgent.pin;
          localChangepassword.changepin(Login.this);
          if (localChangepassword.changed) {
            paramAgent.new_pin = localChangepassword.New_password;
          }
          return;
        }
        Login.this.startActivity(Login.this.intent);
        return;
      }
      if (paramAgent.message != null)
      {
        Toast.makeText(Login.this.getApplicationContext(), paramAgent.message, 1).show();
        return;
      }
      Login.this.agentpin.setError(Login.this.getString(2131492892));
    }
    
    protected void onPreExecute()
    {
      this.dialog.setMessage("Signing in...");
      this.dialog.show();
    }
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\Login.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */