
package com.example.demo.simplepaymentdemo;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.widget.TextView;

import com.cloudpos.jniinterface.MSRInterface;

import static com.cloudpos.jniinterface.MSRInterface.getTrackData;
import static com.cloudpos.jniinterface.MSRInterface.getTrackDataLength;
import static com.cloudpos.jniinterface.MSRInterface.getTrackError;

public class SwipeCardActivity extends BaseActivity {

    private static final int MSGID_SHOW_MESSAGE = 0;
    private TextView tvMessage;
    public Handler handler;
    private String cardID;
    private String cardendmounth;
    private String cardendyear;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        tvMessage = (TextView) findViewById(R.id.tvSwipeCardInfo);

        handler = new Handler(new Handler.Callback() {
            //callback method
            @Override
            public boolean handleMessage(Message msg) {

                switch (msg.what) {
                    case MSGID_SHOW_MESSAGE:
                        tvMessage.setText(msg.obj.toString());//Through the back pass over the information displayed on the TextView
                        break;
                    default:
                        break;
                }
                return false;
            }
        });

        new Thread(MSRrun).start();//Start running a thread that has been defined

    }

    /**
     * The gotoCardinfoActivity Class used for Passing the data to the next Activity and jump
     *
     * @param cardID
     * @param cardendyear
     * @param cardendmounth
     */
    private void gotoCardinfoActivity(String cardID, String cardendyear, String cardendmounth) {

        Intent intent = new Intent(SwipeCardActivity.this, CardinfoActivity.class);
        intent.putExtra("strNO", cardID); // The processed data is transmitted through intent
        intent.putExtra("strmounth", cardendmounth);
        intent.putExtra("stryear", cardendyear);
        startActivity(intent);//jump to next Activity（cardinfo）

    }

    /**
     * The Thread used for the completion of the operation of the credit card and credit card data
     */
    private Runnable MSRrun = new Runnable() {
        @Override
        public void run() {
            handler.obtainMessage(MSGID_SHOW_MESSAGE, "Please Swipe Card").sendToTarget();//Prompt card
            boolean retry = true;
            while (retry) {// Create a while loop, the return value of retry for judging the condition
                retry = false;//Defaults to false
                int MSRopenresult = MSRInterface.open(); //Open the card reader

                if (MSRopenresult >= 0) {

                    try {
                        MSRInterface.waitForSwipe(60000);// wait for swipe ,timeout also go and then cycle
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    if (MSRInterface.eventID == MSRInterface.MSR_CARD_EVENT_FOUND_CARD) {
                        // Found card
                        if (!parseTrackData()) {
                            retry = true;// if parseTrackData is null，retry = ture，goto Recycle
                        } else {
                            gotoCardinfoActivity(cardID, cardendyear, cardendmounth);//Pass data to gotoCardinfoActivity
                        }
                    } else {
                        retry = true; //if not found card,going to recycle
                    }
                    MSRInterface.close();//close device
                } else {
                    String MSROpenErrorCode = Integer.toHexString(MSRopenresult);
                    String OpenfailedInfo = "Device open failed" + "Code:" + MSROpenErrorCode;
                    handler.obtainMessage(MSGID_SHOW_MESSAGE, OpenfailedInfo).sendToTarget();//Open fails to pass information through callbacks
                }
            }
        }
    };

    /**
     * To analyze the track information and its processing results
     *
     * @return
     */
    private boolean parseTrackData() {
        String Info = "Please Swipe Again!";
        String Infoerror = "This card does not support, please try again";
        String strTrackData;
        int result;
        int trackNo = 1;// index 1
        result = getTrackError(trackNo);//get track error
        if (result < 0) {
            handler.obtainMessage(MSGID_SHOW_MESSAGE, Info).sendToTarget();
            return false;
        }
        result = getTrackDataLength(trackNo);//Get length of track data
        if (result < 0) {
            handler.obtainMessage(MSGID_SHOW_MESSAGE, Info).sendToTarget();
            return false;
        }
        byte[] arryTrackData = new byte[result];
        result = getTrackData(trackNo, arryTrackData, arryTrackData.length);//Get track data.
        if (result < 0) {
            handler.obtainMessage(MSGID_SHOW_MESSAGE, Info).sendToTarget();
            return false;
        }
        //String interception with "="
        strTrackData = new String(arryTrackData);
        int flag = -1;
        for (int i = 0; i < strTrackData.length(); i++) {
            if (strTrackData.charAt(i) == '=') {
                flag = i;
                break;
            }

        }
        if(flag == -1){
            handler.obtainMessage(MSGID_SHOW_MESSAGE, Infoerror).sendToTarget();
            return false;
        }

        //String interception
        cardID = strTrackData.substring(0, flag);
        cardendyear = strTrackData.substring(flag + 1, flag + 3);
        cardendmounth = strTrackData.substring(flag + 3, flag + 5);
        return true;

    }


    /**
     * Rewrite backspace key method
     */
    @Override
    public void onBackPressed() {

        exit();
    }

    private void exit() {
        //The BaseActvity method calls, inform each Activity
        MSRInterface.close();//close device
        Intent intent = new Intent("baseActivity");//Corresponding dynamic broadcast
        intent.putExtra("closeAll", 1);//The afferent parameter is 1
        sendBroadcast(intent);// Send broadcast
    }
}











