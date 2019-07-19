package info.msacco.tabsswipe;

import android.app.Activity;
import android.app.PendingIntent;
import android.app.ProgressDialog;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.telephony.SmsManager;
import android.telephony.TelephonyManager;
import android.text.Html;
import android.view.View;

import com.msacco.safaricom_sacco.R;

public class StartPage extends Activity {

	public static final String imeipref = "imeiKey";
	SharedPreferences sharedpreferences;
	private Object dialog;

	public void onCreate(Bundle savedInstanceState) 
	{
		super.onCreate(savedInstanceState);
		setTitle(Html.fromHtml("<b>  TERMS AND CONDITIONS    </b>"));
		setContentView(R.layout.startpage);
	}

	// Function Login
	public void FuncTerms(View view) 
	{

		// terms and conditions accepted		
		savePreferences("termsKey", "Terms Accepted");
		
		
		Intent LoginScreen = new Intent(getApplicationContext(),Line_Registration.class);
		LoginScreen.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
		startActivity(LoginScreen);
		finish();

	}

	
	public String getIMEI() {
		TelephonyManager mngr = (TelephonyManager) this
				.getSystemService(Context.TELEPHONY_SERVICE);
		String imei = mngr.getDeviceId();
		return imei;
	}

	private void savePreferences(String key, String value) {

		SharedPreferences sharedPreferences = PreferenceManager
				.getDefaultSharedPreferences(this);
		Editor editor = sharedPreferences.edit();
		editor.clear();
		editor.putString(key, value);
		editor.commit();

	}

}
