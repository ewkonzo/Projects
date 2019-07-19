package com.wizarpos.homebtn.demo;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class MainActivity extends Activity {

	private static final String TAG = "DEBUG";

	protected static boolean isSuccessReturn = false;
	protected static boolean isSuccessMenu = false;

	private Button btn1_return = null;
	private Button btn2_menu = null;
	private Button btn3_back = null;
	private Button btn4_home = null;

	@SuppressLint("NewApi")
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		getWindow().getDecorView().setSystemUiVisibility(View.SYSTEM_UI_FLAG_HIDE_NAVIGATION);
		setContentView(R.layout.activity_main);
		btn1_return = ResourceManager.getBtnReturnFromMainActivity(this);
		btn2_menu = ResourceManager.getBtnMenuFromMainActivity(this);
		btn3_back = ResourceManager.getBtnExitFromMainActivity(this);
		
		btn4_home = (Button)this.findViewById(R.id.btn4_home) ;
		btn3_back.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				MainActivity.this.finish();
			}
		});
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		// getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	public boolean onKeyDown(int keyCode, KeyEvent event) { // 监听物理键
	    
		if (keyCode == KeyEvent.KEYCODE_HOME) {// home键
			// 相关响应代码
			Log.e("DEBUG", "KEYCODE_HOME");
			// 写要执行的动作或者任务
//			android.os.Process.killProcess(android.os.Process.myPid());
			btn4_home.setBackgroundColor(Color.GREEN);
			return true;
		}
		if (keyCode == KeyEvent.KEYCODE_BACK) {// 返回键
			btn1_return.setBackgroundColor(Color.GREEN);

			// 相关响应代码
			Log.e(TAG, "KEYCODE_BACK");
			isSuccessReturn = true;
			return true;
		}
		if (keyCode == KeyEvent.KEYCODE_MENU) {
			btn2_menu.setBackgroundColor(Color.GREEN);
			Log.e(TAG, "KEYCODE_MENU");
			isSuccessMenu = true;
			return true;
		}
		return super.onKeyDown(keyCode, event);
	}

}
