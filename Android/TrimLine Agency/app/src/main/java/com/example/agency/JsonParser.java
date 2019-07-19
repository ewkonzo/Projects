package com.example.agency;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;

import android.app.Activity;
import android.content.SharedPreferences;
import android.util.Log;

public class JsonParser {
	private static final String TAG = "HttpClient";
	static InputStream iStream = null;
	static String jarray = null;
	static String json = "";
	public static String WEBSERVICE_URL = "http://192.168.43.146:35051/Agency.asmx/";
	public static SharedPreferences preferences;
	/* Error */
	public static String SendHttpPost(Activity paramActivity,
			String MethodName, String myagent, String MethodParam) {

		String value = preferences.getString("Endpoint", "");
		WEBSERVICE_URL = "http://"+value +":3000/Agency.asmx/";

		Log.d("URL",  WEBSERVICE_URL + MethodName);Log.d("Data",  myagent);
		// Creating HTTP client
		HttpClient httpClient = new DefaultHttpClient();

		// Creating HTTP Post
		HttpPost httpPost = new HttpPost(
				WEBSERVICE_URL + MethodName);
		List<NameValuePair> nameValuePair = new ArrayList<NameValuePair>(2);
		nameValuePair.add(new BasicNameValuePair(MethodParam, myagent));
		try {
			httpPost.setEntity(new UrlEncodedFormEntity(nameValuePair));
		} catch (UnsupportedEncodingException e) {
			// writing error to Log
			e.printStackTrace();
		}
		// Making HTTP Request
		try {
			HttpResponse response = httpClient.execute(httpPost);
			if (response.getStatusLine().getStatusCode() == 200)
			{
				HttpEntity entity = response.getEntity();
				json = EntityUtils.toString(entity);
			}
			// writing response to log
			Log.d("Http Response:", json);
		} catch (ClientProtocolException e) {
			// writing exception to log
			e.printStackTrace();
		} catch (IOException e) {
			// writing exception to log
			e.printStackTrace();
		}
		return json;
	}
	private static String convertStreamToString(InputStream paramInputStream) {
		BufferedReader localBufferedReader = new BufferedReader(
				new InputStreamReader(paramInputStream));
		StringBuilder localStringBuilder = new StringBuilder();
		for (;;) {
			try {
				String str = localBufferedReader.readLine();
				if (str != null) {
					localStringBuilder.append(str + "\n");
					continue;
				}
			} catch (IOException localIOException) {
				localIOException = localIOException;
				localIOException.printStackTrace();
				try {
					paramInputStream.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
				continue;
			} finally {
			}
			try {
				paramInputStream.close();
				return localStringBuilder.toString();
			} catch (IOException ex) {
				ex.printStackTrace();
			}
		}
		/*
		 * try { paramInputStream.close(); throw (""); } catch (IOException exc)
		 * { for (;;) { exc.printStackTrace(); }
		 */
	}

	
	//This method is to handle response
    private static String convertStreamToStrings(InputStream is) {
        /*
         * To convert the InputStream to String we use the BufferedReader.readLine()
         * method. We iterate until the BufferedReader return null which means
         * there's no more data to read. Each line will appended to a StringBuilder
         * and returned as String.
         */
        BufferedReader reader = new BufferedReader(new InputStreamReader(is));
        StringBuilder sb = new StringBuilder();

        String line = null;
        try {
            while ((line = reader.readLine()) != null) {
                sb.append(line + "\n");
            }
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                is.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        return sb.toString();
    }
	/* Error */
	public static String getJSONFromUrl(Activity paramActivity,
			String paramString) {
		String result = "";

		return result;
	}
}
