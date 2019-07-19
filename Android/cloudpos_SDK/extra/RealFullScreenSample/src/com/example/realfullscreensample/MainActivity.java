package com.example.realfullscreensample;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;

public class MainActivity extends Activity implements OnClickListener{

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		findViewById(R.id.hide_status).setOnClickListener(this);
		findViewById(R.id.hide_nav).setOnClickListener(this);
		findViewById(R.id.full_screen).setOnClickListener(this);
	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.hide_status:
			startActivity(new Intent(this, HideStatusActivity.class));
			break;
		case R.id.hide_nav:
			startActivity(new Intent(this, HideNavActivity.class));
			break;
		default:
			startActivity(new Intent(this, FullScreenActivity.class));
			break;
		}
	}
}
