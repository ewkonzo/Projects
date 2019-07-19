package com.wizarpos.test.activity;

import java.util.Hashtable;

import com.google.zxing.BarcodeFormat;
import com.google.zxing.EncodeHintType;
import com.google.zxing.MultiFormatWriter;
import com.google.zxing.WriterException;
import com.google.zxing.common.BitMatrix;
import com.wizarpos.log.activity.R;
import com.wizarpos.util.TextViewUtil;

import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.text.method.ScrollingMovementMethod;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends ConstantActivity implements OnClickListener{
	public static final String TAG = "MainActivity";

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		Button btn_run3 = (Button) this.findViewById(R.id.btn_run3);
		Button btn_run4 = (Button) this.findViewById(R.id.btn_run4);
		Button btn_run5 = (Button) this.findViewById(R.id.btn_run5);
//		Button btn_run6 = (Button) this.findViewById(R.id.btn_run6);
		log_text = (TextView) this.findViewById(R.id.text_result);
		log_text.setMovementMethod(ScrollingMovementMethod.getInstance());

		findViewById(R.id.settings).setOnClickListener(this);
		btn_run3.setOnClickListener(this);
		btn_run4.setOnClickListener(this);
		btn_run5.setOnClickListener(this);
//		btn_run6.setOnClickListener(this);

		mHandler = new Handler() {
			@Override
			public void handleMessage(Message msg) {
				if (msg.what == DEFAULT_LOG) {
					log_text.append("\t" + msg.obj + "\n");
				} else if (msg.what == SUCCESS_LOG) {
					String str = "\t" + msg.obj + "\n";
					TextViewUtil.infoBlueTextView(log_text, str);
				} else if (msg.what == FAILED_LOG) {
					String str = "\t" + msg.obj + "\n";
					TextViewUtil.infoRedTextView(log_text, str);
				} else if (msg.what == CLEAR_LOG) {
					log_text.setText("");
				}
			}
		};
	}

    @Override  
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {  
        super.onActivityResult(requestCode, resultCode, data);
    }

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
	
	@Override
	public void onClick(View arg0) {
		int index = arg0.getId();
		if (index == R.id.btn_run3) {
			test();
		}else if (index == R.id.btn_run4) {
		
		}else if (index == R.id.btn_run5) {
			
		}/*else if (index == R.id.btn_run6) {
			
		}*/else if (index == R.id.settings) {
			log_text.setText("");
		}
	}
	
	private void test() {
		try {
			Bitmap bitmap = createQRCode(Build.SERIAL, 100);
			writerInLog("bitmap:" + bitmap);
		} catch (WriterException e) {
			e.printStackTrace();
		}
	}
	   public static Bitmap createQRCode(String str, int widthAndHeight)  
	           throws WriterException {  
	       Hashtable<EncodeHintType, String> hints = new Hashtable<EncodeHintType, String>();  
	       hints.put(EncodeHintType.CHARACTER_SET, "utf-8");  
	       BitMatrix matrix = new MultiFormatWriter().encode(str, BarcodeFormat.QR_CODE, widthAndHeight, widthAndHeight);  
	       int width = matrix.getWidth();  
	       int height = matrix.getHeight();  
	       int[] pixels = new int[width * height];  
	 
	       for (int y = 0; y < height; y++) {  
	           for (int x = 0; x < width; x++) {  
	               if (matrix.get(x, y)) {  
	                   pixels[y * width + x] = 0xff000000;  
	               } else {
	                   pixels[y * width + x] = 0xffffffff;
	               }
	           }  
	       }  
	       Bitmap bitmap = Bitmap.createBitmap(width, height,  
	               Bitmap.Config.ARGB_8888);  
	       bitmap.setPixels(pixels, 0, width, 0, 0, width, height);  
	       return bitmap;  
	   }  

	@Override
	public void onResume() {
		super.onResume();
	}

	public void onDestory() {
		super.onDestroy();
	}

}
