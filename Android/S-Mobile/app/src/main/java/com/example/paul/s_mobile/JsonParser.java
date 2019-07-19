package com.example.paul.s_mobile;

import android.app.Activity;
import android.util.Log;



import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.net.ssl.HttpsURLConnection;

public class JsonParser {

	private static final String TAG = "HttpClient";
	static InputStream iStream = null;
	static String jarray = null;
	static String json = "";
	//public static String WEBSERVICE_URL = "http://192.168.43.146:35051/Agency.asmx/";
	public static String WEBSERVICE_URL = "http://41.72.203.234:35051/Agency.asmx/";

	/* Error */
	public static String SendHttpPost(Activity paramActivity,
			String MethodName, String myagent, String MethodParam) {
		Log.d("URL", WEBSERVICE_URL + MethodName);
		Log.d("Data", myagent);

		URL url;
		String response = "";
		try {


			url = new URL(WEBSERVICE_URL + MethodName);

			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setReadTimeout(15000);
			conn.setConnectTimeout(15000);
			conn.setRequestMethod("POST");
			conn.setDoInput(true);
			conn.setDoOutput(true);


			OutputStream os = conn.getOutputStream();
			BufferedWriter writer = new BufferedWriter(
					new OutputStreamWriter(os, "UTF-8"));
HashMap<String,String> h= new HashMap<String,String >();
			h.put(MethodParam,myagent);

 			writer.write(getPostDataString(h));

			writer.flush();
			writer.close();
			os.close();
			int responseCode=conn.getResponseCode();

			if (responseCode == HttpsURLConnection.HTTP_OK) {
				String line;
				BufferedReader br=new BufferedReader(new InputStreamReader(conn.getInputStream()));
				while ((line=br.readLine()) != null) {
					json+=line;
				}
			}
			else {
				json="";

			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return json;
	}
	private static String getPostDataString(HashMap<String, String> params) throws UnsupportedEncodingException{
		StringBuilder result = new StringBuilder();
		boolean first = true;
		for(Map.Entry<String, String> entry : params.entrySet()){
			if (first)
				first = false;
			else
				result.append("&");

			result.append(URLEncoder.encode(entry.getKey(), "UTF-8"));
			result.append("=");
			result.append(URLEncoder.encode(entry.getValue(), "UTF-8"));
		}

		return result.toString();
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
