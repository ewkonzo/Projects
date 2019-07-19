package com.unionpay.msrdemoforsdk;

import android.app.Activity;
import android.content.Context;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;

import com.cloudpos.DeviceException;
import com.cloudpos.OperationListener;
import com.cloudpos.OperationResult;
import com.cloudpos.POSTerminal;
import com.cloudpos.msr.MSRDevice;
import com.cloudpos.msr.MSROperationResult;
import com.cloudpos.msr.MSRTrackData;

public class MainActivity extends Activity {

    private Button btnOpen;
    private Button btnClose;
    private MSRDevice msrDevice;
    private String str = "";
    private TextView txt;
    private Context context = MainActivity.this;
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        msrDevice = (MSRDevice) POSTerminal.getInstance(getApplicationContext()).getDevice("cloudpos.device.msr");
        btnOpen = (Button) findViewById(R.id.btnOpen);
        btnClose = (Button) findViewById(R.id.btnClose);
        btnOpen.setOnClickListener(openClickListener);
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

    OnClickListener openClickListener = new OnClickListener() {

        @Override
        public void onClick(View v) {
            try {
                str = context.getString(R.string.openingMSR)+"\n";
                handler.post(myRunnable);
                msrDevice.open();
                str += context.getString(R.string.MSRisOpenSuc)+"\n";
                handler.post(myRunnable);
                try {
                    msrDevice.listenForSwipe(new OperationListener() {

                        @Override
                        public void handleResult(OperationResult result) {
                            // TODO Auto-generated method stub
                            if (result.getResultCode() == result.SUCCESS) {
                                MSROperationResult msrOperationResult = (MSROperationResult) result;
                                MSRTrackData tarckData = msrOperationResult.getMSRTrackData();
                                if (tarckData.getTrackError(0) == MSRTrackData.NO_ERROR) {
                                    if (tarckData.getTrackData(0) != null) {
                                        String track1Data = new String(tarckData.getTrackData(0));
                                        str += context.getString(R.string.track1Info) + track1Data + "\n";
                                        handler.post(myRunnable);
                                        Log.i("", context.getString(R.string.track1Info) + track1Data);
                                    }
                                } else {
                                    if (tarckData.getTrackData(0) == null) {
                                        str += context.getString(R.string.track1Info)+"\n";
                                        handler.post(myRunnable);
                                        Log.i("", context.getString(R.string.track1Info));
                                    }
                                }
                                if (tarckData.getTrackError(1) == MSRTrackData.NO_ERROR) {
                                    if (tarckData.getTrackData(1) != null) {
                                        String track2Data = new String(tarckData.getTrackData(1));
                                        str += context.getString(R.string.track2Info)+ track2Data + "\n";
                                        handler.post(myRunnable);
                                        Log.i("", context.getString(R.string.track2Info) + track2Data);
                                    }
                                } else {
                                    if (tarckData.getTrackData(1) == null) {
                                        str += context.getString(R.string.track2Info)+"\n";
                                        handler.post(myRunnable);
                                        Log.i("", context.getString(R.string.track2Info));
                                    }
                                }
                                if (tarckData.getTrackError(2) == MSRTrackData.NO_ERROR) {
                                    if (tarckData.getTrackData(2) != null) {
                                        String track3Data = new String(tarckData.getTrackData(2));
                                        str += context.getString(R.string.track3Info)+ track3Data + "\n";
                                        handler.post(myRunnable);
                                        Log.i("", context.getString(R.string.track3Info)+ track3Data);
                                    }
                                } else {
                                    if (tarckData.getTrackData(2) == null) {
                                        str += context.getString(R.string.track3Info)+"\n";
                                        handler.post(myRunnable);
                                        Log.i("", context.getString(R.string.track3Info));
                                    }
                                }
                            } else if (result.getResultCode() == result.ERR_TIMEOUT) {
                                str += context.getString(R.string.readTrackTimeout)+"\n";
                                handler.post(myRunnable);
                            } else {
                                str += context.getString(R.string.readTrackFailed)+"\n";
                                handler.post(myRunnable);
                            }
                        }
                    }, 20000);

                } catch (DeviceException de) {
                    str += context.getString(R.string.readTrackFailed)+"\n";
                    handler.post(myRunnable);
                }
            } catch (DeviceException e1) {
                // TODO Auto-generated catch block
                e1.printStackTrace();
                str += context.getString(R.string.MSROpenFailed)+"\n";
                handler.post(myRunnable);
            }
        }

    };

    OnClickListener closeClickListener = new OnClickListener() {
        @Override
        public void onClick(View v) {
            try {
                msrDevice.close();
                str += context.getString(R.string.MSRCloseSuc)+"\n";
                handler.post(myRunnable);
            } catch (DeviceException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
                str += context.getString(R.string.MSRCloseFad)+"\n";
                handler.post(myRunnable);
            }
        }
    };
}
