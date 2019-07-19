package com.unionpay.pinpaddemoforsdk;

import android.app.Activity;
import android.content.Context;
import android.os.Bundle;
import android.os.Handler;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;

import com.cloudpos.AlgorithmConstants;
import com.cloudpos.DeviceException;
import com.cloudpos.OperationListener;
import com.cloudpos.OperationResult;
import com.cloudpos.POSTerminal;
import com.cloudpos.pinpad.KeyInfo;
import com.cloudpos.pinpad.PINPadDevice;
import com.cloudpos.pinpad.PINPadOperationResult;

public class MainActivity extends Activity {

	private Button btnOpen;
	private Button btnClose;
	private PINPadDevice device;
	private TextView txt;
	private String str;
	private Context context = MainActivity.this;
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		device = (PINPadDevice) POSTerminal.getInstance(getApplicationContext()).getDevice("cloudpos.device.pinpad");
		btnOpen = (Button) findViewById(R.id.btnOpen);
		btnOpen.setOnClickListener(clickListener);
		btnClose = (Button) findViewById(R.id.btnClose);
		btnClose.setOnClickListener(closeClickListener);
		txt = (TextView) findViewById(R.id.txt);
	}

	private Handler handler = new Handler();

	private Runnable myRunnable = new Runnable() {
		public void run() {
			txt.setText(str);
		}
	};

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.activity_main, menu);
		return true;
	}

	OnClickListener clickListener = new OnClickListener() {

		@Override
		public void onClick(View v) {
			try {
				str = context.getString(R.string.PinpadOpening)+"\n";
				handler.post(myRunnable);
				device.open();
				str += context.getString(R.string.PinpadOpenSuc)+"\n";
				handler.post(myRunnable);
				try {
					KeyInfo keyInfo = new KeyInfo(PINPadDevice.KEY_TYPE_MK_SK, 0, 0, AlgorithmConstants.ALG_3DES);
					String pan = "1234567890123456";
					device.listenForPinBlock(keyInfo, pan, true, new OperationListener() {

						@Override
						public void handleResult(OperationResult result) {
							// TODO Auto-generated method stub
							if (result.getResultCode() == result.SUCCESS) {
								PINPadOperationResult operationResult = (PINPadOperationResult) result;
								str += "pinblock:" + operationResult.getEncryptedPINBlock() + "\n";
								handler.post(myRunnable);
							} else if (result.getResultCode() == result.ERR_TIMEOUT) {
								str += context.getString(R.string.PinblockTimeout)+"\n";
								handler.post(myRunnable);
							} else {
								str += context.getString(R.string.PinblockFailed)+"\n";
								handler.post(myRunnable);
							}
						}
					}, 60 * 1000);
				} catch (DeviceException de) {
					de.printStackTrace();
					str += context.getString(R.string.PinblockFailed)+"\n";
					handler.post(myRunnable);
				}
			} catch (DeviceException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
				str = context.getString(R.string.PinpadOpenFad)+"\n";
				handler.post(myRunnable);
			}

		}

	};

	OnClickListener closeClickListener = new OnClickListener() {

		@Override
		public void onClick(View v) {
			// TODO Auto-generated method stub
			try {
				device.close();
				str += context.getString(R.string.PinpadCloseSuc)+"\n";
				handler.post(myRunnable);
			} catch (DeviceException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
				str += context.getString(R.string.PinpadCloseFad)+"\n";
				handler.post(myRunnable);
			}

		}
	};

}
