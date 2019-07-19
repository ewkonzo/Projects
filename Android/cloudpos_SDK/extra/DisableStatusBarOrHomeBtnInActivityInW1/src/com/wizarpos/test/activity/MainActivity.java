package com.wizarpos.test.activity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.text.method.ScrollingMovementMethod;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;

import com.wizarpos.log.activity.R;
import com.wizarpos.util.TextViewUtil;

public class MainActivity extends ConstantActivity implements OnClickListener {
    
    
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.customer_activity_main);
		
		Button btn_run3 = (Button) this.findViewById(R.id.btn_run3);
		Button btn_run4 = (Button) this.findViewById(R.id.btn_run4);
		log_text = (TextView) this.findViewById(R.id.text_result);
		log_text.setMovementMethod(ScrollingMovementMethod.getInstance());
		
		findViewById(R.id.clean_log).setOnClickListener(this);
		btn_run3.setOnClickListener(this);
		btn_run4.setOnClickListener(this);
		
		mHandler = new Handler() {
			@Override
			public void handleMessage(Message msg) {
				if (msg.what == DEFAULT_LOG) {
					log_text.append("\t" + msg.obj + "\n");
				}else if (msg.what == SUCCESS_LOG) {
					String str = "\n\t" + msg.obj;
					TextViewUtil.infoBlueTextView(log_text, str);
				}else if (msg.what == FAILED_LOG) {
					String str = "\n\t" + msg.obj;
					TextViewUtil.infoRedTextView(log_text, str);
				}else if(msg.what == CLEAR_LOG){
					log_text.setText("");
				}
			}
		};
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public void onClick(View arg0) {
		int index = arg0.getId();
		if (index == R.id.btn_run3) {
//			
			Intent intent = new Intent(MainActivity.this, BtnpressActivity.class);
			this.startActivity(intent);
		} else if (index == R.id.btn_run4) {
			
		}else if (index==R.id.clean_log) {
			log_text.setText("");
		}
	}

	@Override
	public void onResume() {
		super.onResume();
	}

	public void onDestory() {
		super.onDestroy();
	}

	
}
