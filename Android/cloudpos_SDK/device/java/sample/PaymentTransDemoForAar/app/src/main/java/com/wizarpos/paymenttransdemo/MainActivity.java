
package com.wizarpos.paymenttransdemo;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.RadioButton;
import android.widget.RadioGroup;

public class MainActivity extends Activity {

    public static final String PAY_TYPE = "PAYTYPE";
    public static final int TYPE_CONTACTLESS = 0;
    public static final int TYPE_MSR = 1;
    public static final int TYPE_IC = 2;

    Button btnSubmit;
    RadioGroup rdoPayType;
    RadioButton rdoChecked;
    Intent intent;
    Context context;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        initParameters();
        initViews();
    }

    private void initViews() {
        rdoPayType = (RadioGroup) findViewById(R.id.rdoGroup);
        btnSubmit = (Button) findViewById(R.id.btn_0);
        btnSubmit.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                switch (rdoPayType.getCheckedRadioButtonId()) {
                    case R.id.rdo_btn_0:
                        intent.putExtra(PAY_TYPE, TYPE_CONTACTLESS);
                        break;
                    case R.id.rdo_btn_1:
                        intent.putExtra(PAY_TYPE, TYPE_MSR);
                        break;
                    case R.id.rdo_btn_2:
                        intent.putExtra(PAY_TYPE, TYPE_IC);
                        break;

                    default:
                        break;
                }
                context.startActivity(intent);
            }
        });
    }

    private void initParameters() {
        context = MainActivity.this;
        intent = new Intent();
        intent.setClass(context, CardManagerActivity.class);
    }

}
