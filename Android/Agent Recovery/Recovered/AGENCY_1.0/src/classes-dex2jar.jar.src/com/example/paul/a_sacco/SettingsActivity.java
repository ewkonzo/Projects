package com.example.paul.a_sacco;

import android.annotation.TargetApi;
import android.content.Context;
import android.content.SharedPreferences;
import android.content.res.Configuration;
import android.content.res.Resources;
import android.media.Ringtone;
import android.media.RingtoneManager;
import android.net.Uri;
import android.os.Build.VERSION;
import android.os.Bundle;
import android.preference.ListPreference;
import android.preference.Preference;
import android.preference.Preference.OnPreferenceChangeListener;
import android.preference.PreferenceActivity;
import android.preference.PreferenceActivity.Header;
import android.preference.PreferenceFragment;
import android.preference.PreferenceManager;
import android.preference.RingtonePreference;
import android.text.TextUtils;
import java.util.List;

public class SettingsActivity
  extends PreferenceActivity
{
  private static final boolean ALWAYS_SIMPLE_PREFS = false;
  private static Preference.OnPreferenceChangeListener sBindPreferenceSummaryToValueListener = new Preference.OnPreferenceChangeListener()
  {
    public boolean onPreferenceChange(Preference paramAnonymousPreference, Object paramAnonymousObject)
    {
      paramAnonymousObject = paramAnonymousObject.toString();
      if ((paramAnonymousPreference instanceof ListPreference))
      {
        ListPreference localListPreference = (ListPreference)paramAnonymousPreference;
        int i = localListPreference.findIndexOfValue((String)paramAnonymousObject);
        if (i >= 0)
        {
          paramAnonymousObject = localListPreference.getEntries()[i];
          paramAnonymousPreference.setSummary((CharSequence)paramAnonymousObject);
        }
      }
      for (;;)
      {
        return true;
        paramAnonymousObject = null;
        break;
        if ((paramAnonymousPreference instanceof RingtonePreference))
        {
          if (TextUtils.isEmpty((CharSequence)paramAnonymousObject))
          {
            paramAnonymousPreference.setSummary(2131492907);
          }
          else
          {
            paramAnonymousObject = RingtoneManager.getRingtone(paramAnonymousPreference.getContext(), Uri.parse((String)paramAnonymousObject));
            if (paramAnonymousObject == null) {
              paramAnonymousPreference.setSummary(null);
            }
            for (;;)
            {
              break;
              paramAnonymousPreference.setSummary(((Ringtone)paramAnonymousObject).getTitle(paramAnonymousPreference.getContext()));
            }
          }
        }
        else {
          paramAnonymousPreference.setSummary((CharSequence)paramAnonymousObject);
        }
      }
    }
  };
  
  private static void bindPreferenceSummaryToValue(Preference paramPreference)
  {
    paramPreference.setOnPreferenceChangeListener(sBindPreferenceSummaryToValueListener);
    sBindPreferenceSummaryToValueListener.onPreferenceChange(paramPreference, PreferenceManager.getDefaultSharedPreferences(paramPreference.getContext()).getString(paramPreference.getKey(), ""));
  }
  
  private static boolean isSimplePreferences(Context paramContext)
  {
    if ((Build.VERSION.SDK_INT < 11) || (!isXLargeTablet(paramContext))) {}
    for (boolean bool = true;; bool = false) {
      return bool;
    }
  }
  
  private static boolean isXLargeTablet(Context paramContext)
  {
    if ((paramContext.getResources().getConfiguration().screenLayout & 0xF) >= 4) {}
    for (boolean bool = true;; bool = false) {
      return bool;
    }
  }
  
  private void setupSimplePreferencesScreen()
  {
    if (!isSimplePreferences(this)) {
      return;
    }
    addPreferencesFromResource(2131034113);
    bindPreferenceSummaryToValue(findPreference("Agency_Code"));
  }
  
  @TargetApi(11)
  public void onBuildHeaders(List<PreferenceActivity.Header> paramList)
  {
    if (!isSimplePreferences(this)) {
      loadHeadersFromResource(2131034114, paramList);
    }
  }
  
  public boolean onIsMultiPane()
  {
    if ((isXLargeTablet(this)) && (!isSimplePreferences(this))) {}
    for (boolean bool = true;; bool = false) {
      return bool;
    }
  }
  
  protected void onPostCreate(Bundle paramBundle)
  {
    super.onPostCreate(paramBundle);
    setupSimplePreferencesScreen();
  }
  
  @TargetApi(11)
  public static class DataSyncPreferenceFragment
    extends PreferenceFragment
  {
    public void onCreate(Bundle paramBundle)
    {
      super.onCreate(paramBundle);
      addPreferencesFromResource(2131034112);
      SettingsActivity.bindPreferenceSummaryToValue(findPreference("sync_frequency"));
    }
  }
  
  @TargetApi(11)
  public static class GeneralPreferenceFragment
    extends PreferenceFragment
  {
    public void onCreate(Bundle paramBundle)
    {
      super.onCreate(paramBundle);
      addPreferencesFromResource(2131034113);
      SettingsActivity.bindPreferenceSummaryToValue(findPreference("example_text"));
      SettingsActivity.bindPreferenceSummaryToValue(findPreference("example_list"));
    }
  }
  
  @TargetApi(11)
  public static class NotificationPreferenceFragment
    extends PreferenceFragment
  {
    public void onCreate(Bundle paramBundle)
    {
      super.onCreate(paramBundle);
      addPreferencesFromResource(2131034115);
      SettingsActivity.bindPreferenceSummaryToValue(findPreference("notifications_new_message_ringtone"));
    }
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\SettingsActivity.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */