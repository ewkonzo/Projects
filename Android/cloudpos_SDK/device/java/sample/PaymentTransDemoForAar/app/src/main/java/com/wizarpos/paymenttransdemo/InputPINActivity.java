
package com.wizarpos.paymenttransdemo;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;

import com.cloudpos.OperationResult;
import com.cloudpos.POSTerminal;
import com.cloudpos.TimeConstants;
import com.cloudpos.pinpad.KeyInfo;
import com.cloudpos.pinpad.PINPadDevice;
import com.cloudpos.pinpad.PINPadOperationResult;
import com.wizarpos.util.StringUtility;

public class InputPINActivity extends Activity {
    Activity activity;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_input_pin);
        initParameters();
    }

    private void initParameters() {
        activity = InputPINActivity.this;
        WaitForPINThread thread = new WaitForPINThread();
        thread.start();
    }

    private class WaitForPINThread extends Thread {

        @Override
        public void run() {
            PINPadDevice device = (PINPadDevice)POSTerminal.getInstance(activity).getDevice("cloudpos.device.pinpad");
            try {
                device.open();
                KeyInfo info = new KeyInfo(2, 0, 0, 5);

                PINPadOperationResult operationResult = device.waitForPinBlock(info,
                        "1234567890123456", false, TimeConstants.FOREVER);
                if (operationResult.getResultCode() == OperationResult.SUCCESS) {
                    Log.e("PINBlock", StringUtility
                            .ByteArrayToString(operationResult.getEncryptedPINBlock()));
                    Intent intent = new Intent();
                    intent.setClass(activity, PayResultPrintActivity.class);
                    intent.putExtra(MainActivity.PAY_TYPE,
                            getIntent().getIntExtra(MainActivity.PAY_TYPE, -1));
                    activity.startActivity(intent);
                    activity.finish();
                }
            } catch (Exception e) {
                e.printStackTrace();
            } finally {
                try {
                    device.close();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        }
    }

}
