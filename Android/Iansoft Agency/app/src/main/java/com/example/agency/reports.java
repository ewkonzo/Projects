package com.example.agency;

import android.app.Activity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;

public class reports extends Activity {
ImageView summary;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reports);
        summary =(ImageView)findViewById(R.id.summary);
     summary.setOnClickListener(new View.OnClickListener() {
         @Override
         public void onClick(View v) {
             Intent intent = new Intent(reports.this, com.example.agency.summary.class);
             startActivity(intent);
         }
     });
    }
}
