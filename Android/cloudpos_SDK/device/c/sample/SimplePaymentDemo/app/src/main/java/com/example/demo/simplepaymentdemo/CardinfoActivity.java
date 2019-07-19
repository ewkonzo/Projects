
package com.example.demo.simplepaymentdemo;


import android.content.Intent;
import android.os.Bundle;
import android.text.method.ScrollingMovementMethod;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;


public class CardinfoActivity extends BaseActivity {


    private TextView tvmessagecardinfo;
    private TextView tvinfo;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cardinfo);
        tvmessagecardinfo = (TextView) findViewById(R.id.UserCardInfo);
        tvinfo = (TextView) findViewById(R.id.information);
        tvmessagecardinfo.setMovementMethod(ScrollingMovementMethod.getInstance());
        tvinfo.setText("Please confirm card information");

        Intent intent = getIntent();
        //GetIntent retrieves the original intent contained in the project,assigning the retrieved intent to a variable Intent of type intent
        Bundle bundle = intent.getExtras();
        //.getExtras () gets additional data attached to intent
        String cardnum = bundle.getString("strNO");
        //.getString() Returns the value of the specified key
        String year = bundle.getString("stryear");
        String mounth = bundle.getString("strmounth");
        tvmessagecardinfo.setText("\n      Card NO:" + cardnum + "\n" + "\n      Card validity:" + year + "/" + mounth);//Show the card information
        //Click Cancel event
        Button btn = (Button) findViewById(R.id.cancel);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                goBack();
            }
        });
        //Click ok event
        Button btn1 = (Button) findViewById(R.id.ok);
        btn1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                gotoInputAmount();
            }
        });
    }

    /**
     * Jump to the amount input activity
     */
    private void gotoInputAmount() {
        Intent intent = new Intent(CardinfoActivity.this, AmountKeyBoardActivity.class);
        startActivity(intent);
    }

    private void goBack() {
        //Jump to the first swipe interface
        Intent intent = new Intent(this, SwipeCardActivity.class);
        startActivity(intent);
    }

    /**
     * Rewrite backspace key method
     */
    @Override
    public void onBackPressed() {

        goBack();
    }

}








