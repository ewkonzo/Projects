package com.example.m_saccoagency;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class ChangeClientPin extends Activity {
	private EditText EtNationalID, EtCurrentPin, EtNewPin, EtConfirmNewPin;
	private Button BtnCancel, BtnConfirm;
	
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.change_client_pin);
		
		EtNationalID = (EditText)findViewById(R.id.cptxtnationalid);
		EtCurrentPin = (EditText)findViewById(R.id.cptxtcpin);
		EtNewPin = (EditText)findViewById(R.id.cptxtnpin);
		EtConfirmNewPin = (EditText)findViewById(R.id.cptxtconpin);
		
		BtnCancel = (Button)findViewById(R.id.cpCancel);
		BtnConfirm = (Button)findViewById(R.id.cpConfirm);
		
		BtnCancel.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(ChangeClientPin.this,
						AgencyListActivity.class);
				startActivity(intent);
			}
		});
		BtnConfirm.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				String NationalID = EtNationalID.getText().toString().trim();
				String CurrentPin = EtCurrentPin.getText().toString();
				String NewPin = EtNewPin.getText().toString();
				String ConfirmPin = EtConfirmNewPin.getText().toString();
				
				if(NationalID.equals("")|| NationalID == null){
					EtNationalID.setError("Field cannot be null");
				}else if(CurrentPin.equals("")||  CurrentPin == null){
					EtCurrentPin.setError("Field cannot be null");
				}else if(NewPin.equals("")||NewPin == null){
					EtNewPin.setError("Field cannot be null");
				}else if(ConfirmPin.equals("")|| ConfirmPin == null){
					EtConfirmNewPin.setError("Field cannot be null");
				}else {
					
					
				}
				
			}
		});
	}


}
