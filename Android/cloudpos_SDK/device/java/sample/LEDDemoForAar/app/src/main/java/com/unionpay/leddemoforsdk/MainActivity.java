package com.unionpay.leddemoforsdk;

import android.app.Activity;
import android.content.Context;
import android.os.Bundle;
import android.os.Handler;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;

import com.cloudpos.DeviceException;
import com.cloudpos.POSTerminal;
import com.cloudpos.led.LEDDevice;

public class MainActivity extends Activity {

    private String str;
    private TextView txt;
    private Button btnOpen;
    private Button btnClose;
    private LEDDevice device;
    private Context context = MainActivity.this;
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        device = (LEDDevice) POSTerminal.getInstance(getApplicationContext()).getDevice("cloudpos.device.led");
        btnOpen = findViewById(R.id.btnOpen);
        btnClose = findViewById(R.id.btnClose);
        btnOpen.setOnClickListener(clickListener);
        btnClose.setOnClickListener(closeClickListener);
        txt = findViewById(R.id.txt);
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

                str = context.getString(R.string.openingLed)+"\n";
                handler.post(myRunnable);
                device.open();

                str += context.getString(R.string.ledOpenSuc)+"\n";
                handler.post(myRunnable);
                try {
                    device.startBlink(1000, 1000, 100000);

                    str += context.getString(R.string.blinkSuc)+"\n";
                    handler.post(myRunnable);
                } catch (DeviceException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();

                    str += context.getString(R.string.blinkFailed)+"\n";
                    handler.post(myRunnable);
                }
            } catch (DeviceException e) {
                // TODO Auto-generated catch block

                str += context.getString(R.string.openLedFailed)+"\n";
                handler.post(myRunnable);
                e.printStackTrace();
            }
        }
    };
    OnClickListener closeClickListener = new OnClickListener() {

        @Override
        public void onClick(View v) {
            try {
                device.cancelBlink();

                str += context.getString(R.string.closeBlinkSuc)+"\n";
                handler.post(myRunnable);
            } catch (DeviceException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();

                str += context.getString(R.string.closeBlinkFailed)+"\n";
                handler.post(myRunnable);
            }
            try {
                device.close();

                str += context.getString(R.string.closeLedSuc)+"\n";
                handler.post(myRunnable);
            } catch (DeviceException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();

                str += context.getString(R.string.closeLedFaild)+"\n";
                handler.post(myRunnable);
            }
        }
    };

}
