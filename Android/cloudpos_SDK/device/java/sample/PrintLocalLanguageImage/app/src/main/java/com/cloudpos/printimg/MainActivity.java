package com.cloudpos.printimg;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.text.Format;

import android.app.Activity;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Picture;
import android.net.http.SslError;
import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.util.Log;
import android.view.View;
import android.webkit.SslErrorHandler;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.Button;

import com.cloudpos.DeviceException;
import com.cloudpos.POSTerminal;
import com.cloudpos.printer.PrinterDevice;
import com.cloudpos.printer.PrinterDevice;
import com.cloudpos.DeviceException;
import com.wizarpos.html2image.R;

public class MainActivity extends Activity {

	private WebView webView = null;
	private Button printBtn = null;
	private File imageFile = null;
	private Handler handler = new Handler();
	private PrinterDevice printerDevice;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		webView = (WebView) findViewById(R.id.wv);
		printBtn = (Button) findViewById(R.id.printImage);
		webView.getSettings().setCacheMode(WebSettings.LOAD_NO_CACHE);
		webView.setDrawingCacheEnabled(false);
		webView.getSettings().setLoadWithOverviewMode(true);
		webView.clearCache(true);
		
		imageFile = new File(Environment.getExternalStorageDirectory(), "qrcode.png");
		
		initWebView();
		
		printBtn.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				printImage();
			}
		});
	}

	private void printImage() {
		printerDevice = (PrinterDevice) POSTerminal.getInstance(getApplicationContext()).getDevice(
				"cloudpos.device.printer");
	    savePicture();
		final Bitmap bm = BitmapFactory.decodeFile(imageFile.getAbsolutePath());
		try {
			printerDevice.open();
			if (printerDevice.queryStatus() == 1) {

				Thread thread = new Thread(new Runnable() {

					@Override
					public void run() {
						// TODO Auto-generated method stub
						try {

							printerDevice.printBitmap(bm);

						} catch (DeviceException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();

						} finally {
							closePrinter();
						}
					}
				});
				thread.start();
			}
		}catch (Exception e){
			e.printStackTrace();
			closePrinter();
		}

	}

	private void closePrinter() {
		try {
			printerDevice.close();
		} catch (DeviceException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	private void initWebView() {
		try {
			WebSettings settings = webView.getSettings();
			settings.setSupportZoom(true);
			settings.setBuiltInZoomControls(true);
			settings.setJavaScriptEnabled(true);
			webView.setWebViewClient(new WebViewClient() {
				@Override
				public boolean shouldOverrideUrlLoading(WebView view, String url) {
					view.loadUrl(url);
					return true;
				}

				@Override
				public void onPageFinished(final WebView view, String url) {
					System.out.println("page finished....");
//					savePicture();
				}

				@Override
				public void onReceivedSslError(WebView view, SslErrorHandler handler, SslError error) {
					handler.proceed();
				}
			});
			InputStream inStream = getAssets().open("template.html");
			String html = inputStream2String(inStream);
			
			try {
				webView.removeAllViews();
				webView.loadDataWithBaseURL(null, html, "text/html", "utf-8", null);
//				webView.loadUrl("http://bidkaboss.com/erp_ram/operators/pos_create_voucher?id=86");
			} catch (Exception e) {
				e.printStackTrace();
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	private void savePicture() {
		webView.refreshDrawableState();
		Picture picture = webView.capturePicture();
		// View picture = this.getWindow().getDecorView();
		int width = picture.getWidth();
		int height = picture.getHeight();
		System.out.println("width: " + width + ", height: " + height);
		if (width > 0 && height > 0) {
			// create bitmap image
			Bitmap bitmap = Bitmap.createBitmap(width, height, Bitmap.Config.ARGB_8888);
			// create Canvas
			Canvas canvas = new Canvas(bitmap);
			// draw webview to canvas
			picture.draw(canvas);
			try {
				FileOutputStream fos = new FileOutputStream(imageFile);
				// 压缩bitmap到输出流中
				bitmap.compress(Bitmap.CompressFormat.PNG, 100, fos);
				fos.close();
			} catch (Exception e) {
				Log.e("create picture", e.getMessage());
			} finally {
				webView.clearHistory();
			}
		} else {
			// if saved failure, wait 100ms to save
			handler.postDelayed(new Runnable() {
				public void run() {
					savePicture();
				}
			}, 100L);
		}
	}
	
	private String inputStream2String(InputStream inStream) throws IOException {
		InputStreamReader reader = new InputStreamReader(inStream);
		StringBuilder sb = new StringBuilder();
		char[] cs = new char[1024];
		int len = -1;
		while ((len = reader.read(cs)) != -1) {
			sb.append(cs, 0, len);
		}
		reader.close();
		return sb.toString();
	}

	
}
