package com.example.paul.s_mobile;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;

public class Main extends AppCompatActivity {
Button withdrawal,deposit,balance,ministatement,airtime,transfer;
    LinearLayout l;
    LinearLayout selectaccount;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
//        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
//        setSupportActionBar(toolbar);
//        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
//        fab.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
//                        .setAction("Action", null).show();
//            }
//        });

        withdrawal= (Button)findViewById(R.id.btn_Withdraw);
        deposit= (Button)findViewById(R.id.btn_Deposit);
        airtime= (Button)findViewById(R.id.btn_Airtime);
        transfer= (Button)findViewById(R.id.btn_Transfer);
        balance= (Button)findViewById(R.id.btn_Balance);
        ministatement= (Button)findViewById(R.id.btn_Ministatement);

       Intent intent = new Intent(Main.this,
                withdrawal.class);
        startActivity(intent);
    }
    public void onClick(View v) {
        Intent i= null;
       switch(v.getId()) {
           case R.id.btn_Withdraw:
               i = new Intent(Main.this, com.example.paul.s_mobile.withdrawal.class);
           case R.id.btn_Deposit:
               i = new Intent(Main.this, com.example.paul.s_mobile.deposit.class);
           case R.id.btn_Transfer:
               i = new Intent(Main.this, com.example.paul.s_mobile.withdrawal.class);
//           case R.id.btn_Transfer:
//               i = new Intent(Main.this, com.example.paul.s_mobile.Main.class);
//           case R.id.btn_Withdraw:
//               i = new Intent(Main.this, com.example.paul.s_mobile.Main.class);
//           case R.id.btn_Withdraw:
//               i = new Intent(Main.this, com.example.paul.s_mobile.Main.class);

       }  startActivity(i);
    }
}
