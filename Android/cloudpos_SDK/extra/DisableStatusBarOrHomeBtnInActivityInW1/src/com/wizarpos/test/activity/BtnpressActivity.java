package com.wizarpos.test.activity;

import android.app.Activity;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.TextView;

import com.wizarpos.log.activity.R;

public class BtnpressActivity extends Activity implements OnClickListener {

	private String TAG = "BtnpressActivity";

	@Override
	protected void onCreate(Bundle bundle) {
		setContentView(R.layout.btnpress_activity);
		super.onCreate(bundle);
		
		Button text = (Button ) this.findViewById(R.id.cancelBtn);
		text.setOnClickListener(this);
		Button exit = (Button ) this.findViewById(R.id.okBtn);
		exit.setOnClickListener(this);

	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) { // 监听物理键
		TextView text = (TextView ) this.findViewById(R.id.content);
		text.append("\nkeyCode = " + keyCode);
		if (keyCode == KeyEvent.KEYCODE_HOME) {// home键
			// 相关响应代码
			Log.e("DEBUG", "KEYCODE_HOME");
			// 写要执行的动作或者任务
//			textview_home.setBackgroundColor(Color.GREEN);
			return true;
		} else if (keyCode == KeyEvent.KEYCODE_BACK) {// 返回键
//			textView_back.setBackgroundColor(Color.GREEN);
			// 相关响应代码
			Log.e(TAG, "KEYCODE_BACK");
			// isSuccessReturn = true;
			return true;
		} else if (keyCode == KeyEvent.KEYCODE_MENU) {
//			textview_menu.setBackgroundColor(Color.GREEN);
			Log.e(TAG, "KEYCODE_MENU");
			// isSuccessMenu = true;
			return true;
		} else {
			return super.onKeyDown(keyCode, event);
		}
	}

	// 本方法加上权限，在本activity里实现了屏蔽home的功能
	// Activity中有getWindow().setType(WindowManager.LayoutParams.TYPE_KEYGUARD)之类的代码;
	@Override
	public void onAttachedToWindow() {
		super.onAttachedToWindow();
		try {
			this.getWindow().setType(WindowManager.LayoutParams.TYPE_KEYGUARD);
		} catch (Throwable e) {
			e.printStackTrace();
		}

	}

	@Override
	protected void onDestroy() {
		super.onDestroy();
	}

	@Override
	public void onClick(View v) {
		if(v.getId() == R.id.cancelBtn){
			TextView text = (TextView ) this.findViewById(R.id.content);
			text.setText("");
		}else{
			this.finish();
		}
	}
}
