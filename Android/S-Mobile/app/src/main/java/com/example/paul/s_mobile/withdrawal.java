package com.example.paul.s_mobile;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.Toast;


public class withdrawal extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_withdrawal);
        try {
            common.sourceaccount = (Spinner) findViewById(R.id.selectaccount);
            common.amount = (EditText) findViewById(R.id.amount);
            common.self = (RadioButton) findViewById(R.id.self);
            common.other = (RadioButton) findViewById(R.id.other);
            common.sendtono = (EditText) findViewById(R.id.sendtono);
            common.sendto = (RadioGroup) findViewById(R.id.sendto);
            common.sendto.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener() {
                public void onCheckedChanged(RadioGroup rGroup, int checkedId) {
                    // This will get the radiobutton that has changed in its check state
                    RadioButton checkedRadioButton = (RadioButton) rGroup.findViewById(checkedId);
                    // This puts the value (true/false) into the variable
                    boolean checked = checkedRadioButton.isChecked();
                    // If the radiobutton that has changed in check state is now checked...
                    try {
                        switch (checkedRadioButton.getId()) {
                            case R.id.self:
                                if (checked) {
                                    common.other.setChecked(false);
                                    common.sendtono.setVisibility(View.GONE);
                                }
                                break;
                            case R.id.other:
                                if (checked) {
                                    common.self.setChecked(false);
                                    common.sendtono.setVisibility(View.VISIBLE);
                                    common.sendtono.requestFocus();
                                }
                                break;
                        }
                    } catch (Exception ex) {
                        ex.printStackTrace();
                        Log.e(ex.getMessage(), ex.getMessage());
                    }
                }
            });
            // Check which radio button was clicked
            FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
            fab.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    common.amount.setError(null);
                    Toast.makeText(getApplicationContext(), "Replace with your own action", Toast.LENGTH_LONG)
                            .show();
                }
            });
        } catch (Exception ex) {
            ex.printStackTrace();
            Log.e(ex.getMessage(), ex.getMessage());
        }
    }

}
