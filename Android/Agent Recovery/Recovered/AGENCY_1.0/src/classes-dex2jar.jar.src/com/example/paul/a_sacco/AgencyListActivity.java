package com.example.paul.a_sacco;

import android.app.AlertDialog;
import android.app.AlertDialog.Builder;
import android.content.Context;
import android.content.DialogInterface;
import android.content.DialogInterface.OnClickListener;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import java.lang.reflect.Type;

public class AgencyListActivity
  extends FragmentActivity
  implements AgencyListFragment.Callbacks
{
  private boolean mTwoPane;
  
  protected void onCreate(Bundle paramBundle)
  {
    super.onCreate(paramBundle);
    setContentView(2130903066);
    if (findViewById(2131296319) != null)
    {
      this.mTwoPane = true;
      ((AgencyListFragment)getSupportFragmentManager().findFragmentById(2131296320)).setActivateOnItemClick(true);
    }
  }
  
  public boolean onCreateOptionsMenu(Menu paramMenu)
  {
    getMenuInflater().inflate(2131623940, paramMenu);
    super.onCreateOptionsMenu(paramMenu);
    return true;
  }
  
  public void onItemSelected(String paramString)
  {
    if (this.mTwoPane)
    {
      localObject = new Bundle();
      ((Bundle)localObject).putString("item_id", paramString);
      ((Bundle)localObject).putBoolean("Pane", this.mTwoPane);
      paramString = new AgencyDetailFragment();
      paramString.setArguments((Bundle)localObject);
      getSupportFragmentManager().beginTransaction().replace(2131296319, paramString).commit();
      return;
    }
    Object localObject = new Intent(this, AgencyDetailActivity.class);
    ((Intent)localObject).putExtra("item_id", paramString);
    ((Intent)localObject).putExtra("Pane", this.mTwoPane);
    startActivity((Intent)localObject);
  }
  
  public boolean onOptionsItemSelected(MenuItem paramMenuItem)
  {
    switch (paramMenuItem.getItemId())
    {
    }
    for (;;)
    {
      return super.onOptionsItemSelected(paramMenuItem);
      startActivity(new Intent(getApplicationContext(), SettingsActivity.class));
      continue;
      new Changepassword().changepin(this);
    }
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
        paramVarArgs = new Gson().toJson(this.magent);
        paramVarArgs = JsonParser.SendHttpPost(AgencyListActivity.this, "Changepass", paramVarArgs, "login");
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
      if (paramAgent.new_pin == null) {
        Toast.makeText(AgencyListActivity.this.getApplicationContext(), "Password successfully changed.", 1).show();
      }
    }
    
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
      AlertDialog.Builder localBuilder = new AlertDialog.Builder(AgencyListActivity.this);
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
          if (!paramAnonymousView.equals(Login.agent.pin))
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
          AgencyListActivity.Changepassword.this.changed = true;
          AgencyListActivity.Changepassword.this.New_password = str1;
          Login.agent.new_pin = str1;
          localObject.dismiss();
          new AgencyListActivity.ChangepassTask(AgencyListActivity.this, Login.agent).execute(new Void[] { (Void)null });
        }
      });
      ((AlertDialog)localObject).getButton(-2).setOnClickListener(new View.OnClickListener()
      {
        public void onClick(View paramAnonymousView)
        {
          AgencyListActivity.Changepassword.this.changed = false;
          localObject.dismiss();
        }
      });
    }
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\AgencyListActivity.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */