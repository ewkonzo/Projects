package com.example.demo.simplepaymentdemo;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;


public class BaseActivity extends AppCompatActivity {

    private CloseActivityBroadcast BroadcastCloseAll;

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //Dynamic register broadcast
        BroadcastCloseAll = new CloseActivityBroadcast();
        IntentFilter intentFilter = new IntentFilter("baseActivity");
        registerReceiver(BroadcastCloseAll, intentFilter);
    }

    //Write off the broadcast in the way of destruction
    protected void onDestroy() {
        super.onDestroy();
        unregisterReceiver(BroadcastCloseAll);//Cancellation of broadcasting
    }

    //Define a broadcast
    public class CloseActivityBroadcast extends BroadcastReceiver {

        public void onReceive(Context arg0, Intent intent) {
            //Receive and send the broadcast content
            int closeAll = intent.getIntExtra("closeAll", 0);//Broadcast instruction, default parameter is 0
            if (closeAll == 1) {
                finish();//Destroy Activity
            }
        }

    }

}
