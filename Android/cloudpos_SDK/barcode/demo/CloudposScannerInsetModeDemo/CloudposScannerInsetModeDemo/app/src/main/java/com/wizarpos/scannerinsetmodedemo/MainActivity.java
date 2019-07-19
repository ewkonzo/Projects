package com.wizarpos.scannerinsetmodedemo;

import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

/**
 * 针对之前的扫码服务UI不够灵活，无法满足客户UI要求，现对扫码服务增加一种嵌入模式，客户可以自己定制扫码框外的UI，扫码框此时是一个悬浮窗口，
 * 客户可以同时操作扫码框和自己的界面
 *
 * 此项目为演示使用扫码服务的悬浮窗模式
 *
 * 悬浮窗和activity的出现无法同步，效果不太理想，还要更换解决方案
 */
public class MainActivity extends AppCompatActivity {


    private Context mContext;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        mContext = this;
        initView();
    }

    private void initView() {
        TextView title = (TextView) findViewById(R.id.bar_title);
        ImageView back = (ImageView) findViewById(R.id.bar_back);
        Button scan = (Button) findViewById(R.id.btn_scan);
        RelativeLayout titleBar = (RelativeLayout) findViewById(R.id.titlebar);

        title.setText("InsetModeDemo");
        back.setVisibility(View.GONE);
        titleBar.setBackgroundColor(Color.rgb(0x56, 0xab, 0xe4));
        scan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(mContext, ScanActivity.class);
                startActivityForResult(intent, 1);
            }
        });
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (resultCode == 2) {
            CharSequence result = data.getCharSequenceExtra("result");
            Toast.makeText(mContext, result, Toast.LENGTH_LONG).show();
        }
    }
}
