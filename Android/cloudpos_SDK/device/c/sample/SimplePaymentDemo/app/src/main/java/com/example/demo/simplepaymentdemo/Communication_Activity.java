package com.example.demo.simplepaymentdemo;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;

import com.cloudpos.jniinterface.PINPadInterface;

import java.util.Timer;
import java.util.TimerTask;

/**
 * Analog communication process
 */

public class Communication_Activity extends BaseActivity {


    private ProgressDialog waitingDialog;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_communication);
    }

    @Override
    protected void onResume() {
        super.onResume();
        Timer showDialog = new Timer();
        Timer closeDialog = new Timer();
        showDialog.schedule(new TimerTask() {
            @Override
            public void run() {
                runOnUiThread(new Runnable() {//Show waitingdialog it is communicating
                    @Override
                    public void run() {
                        waitingDialog = new ProgressDialog(Communication_Activity.this);
                        waitingDialog.setMessage("Communication, please wait a moment...");
                        waitingDialog.setIndeterminate(true);//Progress bar dynamics
                        waitingDialog.setCancelable(false);// set to cannot cancel
                        waitingDialog.show();//show waitingdialog
                    }
                });
            }
        }, 200);

        closeDialog.schedule(new TimerTask() {// Four seconds later close waitingdialog
            @Override
            public void run() {
                PINPadInterface.close();
                waitingDialog.dismiss();
                Intent intent = new Intent(Communication_Activity.this, PrintActivity.class);
                startActivity(intent);
            }
        }, 4000);
    }


}

