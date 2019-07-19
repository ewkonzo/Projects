
package com.wizarpos.paymenttransdemo;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;

import com.cloudpos.OperationResult;
import com.cloudpos.POSTerminal;
import com.cloudpos.TimeConstants;
import com.cloudpos.card.ATR;
import com.cloudpos.card.CPUCard;
import com.cloudpos.card.Card;
import com.cloudpos.msr.MSRDevice;
import com.cloudpos.msr.MSROperationResult;
import com.cloudpos.msr.MSRTrackData;
import com.cloudpos.rfcardreader.RFCardReaderDevice;
import com.cloudpos.rfcardreader.RFCardReaderOperationResult;
import com.cloudpos.smartcardreader.SmartCardReaderDevice;
import com.cloudpos.smartcardreader.SmartCardReaderOperationResult;
import com.wizarpos.util.StringUtility;

public class CardManagerActivity extends Activity {

    private int payType = -1;
    TextView txtSwip;
    com.cloudpos.Device device;
    Activity activity;
    private Context context = CardManagerActivity.this;
    private static final String TAG = "CardReader";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_card_manager);
        initViews();
        initParameters();
    }

    private void initViews() {
        txtSwip = (TextView) findViewById(R.id.txt_0);
    }

    private void initParameters() {
        activity = CardManagerActivity.this;
        payType = getIntent().getIntExtra(MainActivity.PAY_TYPE, -1);
        Log.e(TAG, "payType = " + payType);
        switch (payType) {
            case MainActivity.TYPE_CONTACTLESS: {
                txtSwip.setText(context.getString(R.string.SwingCard));
                device = POSTerminal.getInstance(activity).getDevice("cloudpos.device.rfcardreader");
                Thread thread = new RFCardThread();
                thread.start();
                break;
            }
            case MainActivity.TYPE_MSR: {
                txtSwip.setText(context.getString(R.string.SwipeCard));
                device = POSTerminal.getInstance(activity).getDevice("cloudpos.device.msr");
                Thread thread = new MSRThread();
                thread.start();
                break;
            }
            case MainActivity.TYPE_IC: {
                txtSwip.setText(context.getString(R.string.InsertCard));
                device = POSTerminal.getInstance(activity).getDevice("cloudpos.device.smartcardreader");
                Thread thread = new ICCardThread();
                thread.start();
                break;
            }
            default:
                break;
        }
    }

    private class RFCardThread extends Thread {

        @Override
        public void run() {
            try {
                device.open();
                RFCardReaderOperationResult operationResult = ((RFCardReaderDevice) device)
                        .waitForCardPresent(TimeConstants.FOREVER);
                if (operationResult.getResultCode() == OperationResult.SUCCESS) {
                    byte[] cardID = operationResult.getCard().getID();
                    Log.e(TAG, "CardID = " + StringUtility.ByteArrayToString(cardID));
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
            Intent intent = new Intent();
            intent.setClass(activity, InputPINActivity.class);
            intent.putExtra(MainActivity.PAY_TYPE, payType);
            activity.startActivity(intent);
            activity.finish();
        }
    }

    private class MSRThread extends Thread {

        @Override
        public void run() {
            try {
                device.open();
                MSROperationResult operationResult = ((MSRDevice) device)
                        .waitForSwipe(TimeConstants.FOREVER);
                if (operationResult.getResultCode() == OperationResult.SUCCESS) {
                    MSRTrackData trackData = operationResult.getMSRTrackData();
                    for (int trackNo = 0; trackNo < 3; trackNo++) {
                        if (trackData.getTrackError(trackNo) != MSRTrackData.NO_ERROR) {
                            Log.e(TAG, String.format("Track(%s)", (trackNo + 1))
                                    + String.format("ErrorMessage%s", trackData.getTrackError(trackNo)));
                        } else {
                            Log.e(TAG, String.format("Track(%s)", (trackNo + 1))
                                    + String.format("TrackData%s", new String(
                                            trackData.getTrackData(trackNo))));
                        }
                    }
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
            Intent intent = new Intent();
            intent.setClass(activity, InputPINActivity.class);
            intent.putExtra(MainActivity.PAY_TYPE, payType);
            activity.startActivity(intent);
            activity.finish();
        }
    }

    private class ICCardThread extends Thread {

        @Override
        public void run() {
            try {
                device.open();
                SmartCardReaderOperationResult operationResult = ((SmartCardReaderDevice) device)
                        .waitForCardPresent(TimeConstants.FOREVER);
                if (operationResult.getResultCode() == OperationResult.SUCCESS) {
                    Card card = operationResult.getCard();
                    ATR dataATR = ((CPUCard) card).connect();
                    Log.e(TAG, "ATR = " + StringUtility.ByteArrayToString(dataATR.getBytes()));
                    ((CPUCard) card).disconnect();
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
            Intent intent = new Intent();
            intent.setClass(activity, InputPINActivity.class);
            intent.putExtra(MainActivity.PAY_TYPE, payType);
            activity.startActivity(intent);
            activity.finish();
        }
    }

}
