package info.msacco.tabsswipe;


import com.msacco.safaricom_sacco.R;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.Window;

public class Main_Splash_Screen extends Activity
{
	
	private static final int splash_duration = 3000;
	private Handler myhandler;
	private boolean backbtnpress;
		
	@Override
	protected void onCreate(Bundle savedInstanceState) 
	{
		
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);		
			
		setContentView(R.layout.main_splash);
			
		myhandler = new Handler();
		myhandler.postDelayed(new Runnable() 
		{
		
	    @Override
		public void run() {
				
		Intent i = new Intent(Main_Splash_Screen.this, LoginActivity.class);
        startActivity(i);
				// TODO Auto-generated method stub
		finish();
				
			}
		},splash_duration);		
	}
	
	@Override
	public void onBackPressed() 
	{
		// TODO Auto-generated method stub
		super.onBackPressed();
	}

}
