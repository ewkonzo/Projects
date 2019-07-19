package com.example.paul.a_sacco;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class Splash
  extends ActionBarActivity
{
  Database db = null;
  
  protected void onCreate(Bundle paramBundle)
  {
    super.onCreate(paramBundle);
    setContentView(2130903077);
    this.db = new Database(this);
    new GetDataTask().execute(new Void[0]);
  }
  
  public boolean onCreateOptionsMenu(Menu paramMenu)
  {
    getMenuInflater().inflate(2131623943, paramMenu);
    return true;
  }
  
  public boolean onOptionsItemSelected(MenuItem paramMenuItem)
  {
    if (paramMenuItem.getItemId() == 2131296384) {
      return true;
    }
    return super.onOptionsItemSelected(paramMenuItem);
  }
  
  public class GetDataTask
    extends AsyncTask<Void, Void, Boolean>
  {
    public GetDataTask() {}
    
    protected Boolean doInBackground(Void... paramVarArgs)
    {
      try
      {
        paramVarArgs = JsonParser.getJSONFromUrl(Splash.this, "Getsocieties");
        Object localObject = new TypeToken() {}.getType();
        new ArrayList();
        paramVarArgs = ((List)new Gson().fromJson(paramVarArgs, (Type)localObject)).iterator();
        while (paramVarArgs.hasNext())
        {
          localObject = (Societies)paramVarArgs.next();
          Societies.AddSociety(Splash.this.db, (Societies)localObject);
        }
        return Boolean.valueOf(true);
      }
      catch (Exception paramVarArgs)
      {
        try
        {
          paramVarArgs.printStackTrace();
          return Boolean.valueOf(true);
        }
        catch (Exception paramVarArgs)
        {
          paramVarArgs.printStackTrace();
        }
      }
      return Boolean.valueOf(false);
    }
    
    protected void onCancelled() {}
    
    protected void onPostExecute(Boolean paramBoolean)
    {
      paramBoolean = new Intent(Splash.this, Login.class);
      Splash.this.startActivity(paramBoolean);
    }
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\Splash.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */