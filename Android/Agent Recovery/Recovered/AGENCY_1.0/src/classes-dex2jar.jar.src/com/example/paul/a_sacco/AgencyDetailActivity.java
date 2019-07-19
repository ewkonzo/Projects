package com.example.paul.a_sacco;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.app.NavUtils;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.view.MenuItem;

public class AgencyDetailActivity
  extends ActionBarActivity
{
  protected void onCreate(Bundle paramBundle)
  {
    super.onCreate(paramBundle);
    setContentView(2130903065);
    getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    if (paramBundle == null)
    {
      paramBundle = new Bundle();
      paramBundle.putString("item_id", getIntent().getStringExtra("item_id"));
      AgencyDetailFragment localAgencyDetailFragment = new AgencyDetailFragment();
      localAgencyDetailFragment.setArguments(paramBundle);
      getSupportFragmentManager().beginTransaction().add(2131296319, localAgencyDetailFragment).commit();
    }
  }
  
  public boolean onOptionsItemSelected(MenuItem paramMenuItem)
  {
    if (paramMenuItem.getItemId() == 16908332)
    {
      NavUtils.navigateUpTo(this, new Intent(this, AgencyListActivity.class));
      return true;
    }
    return super.onOptionsItemSelected(paramMenuItem);
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\AgencyDetailActivity.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */