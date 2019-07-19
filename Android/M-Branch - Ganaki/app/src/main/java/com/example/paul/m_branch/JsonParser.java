package com.example.paul.m_branch;

import android.app.Activity;
import android.content.SharedPreferences;
import android.util.Log;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class JsonParser {
    private static final String TAG = "HttpClient";
    static InputStream iStream = null;
    static String jarray = null;
    static String json = "";
    public static SharedPreferences preferences;
    //public static String WEBSERVICE_URL = "http://192.168.0.12:4000/Collect.asmx";
    //public static String WEBSERVICE_URL = ":4000/Collect.asmx";
    public static String WEBSERVICE_URL = ":4000/Collect.asmx";

    public static String getXmlFromUrl(String method, String param, String json) {
        StringBuilder result = new StringBuilder();
        HttpURLConnection conn = null;
        try {
            String value = preferences.getString("IP", "");

            URL url = new URL("Http://" + value + WEBSERVICE_URL + "/" + method + "?" + param + "=" + json);

            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestProperty("User-Agent", "Mozilla/5.0 ( compatible ) ");
            conn.setRequestProperty("Accept", "*/*");

            Log.i("dat", json);
            Log.i("res", String.valueOf(conn.getResponseCode()));
            Log.i("res", conn.getResponseMessage());

            InputStream in = new BufferedInputStream(conn.getInputStream());
            BufferedReader reader = new BufferedReader(new InputStreamReader(in));
            String line;
            while ((line = reader.readLine()) != null) {
                result.append(line);
            }

        } catch (Exception e) {
            e.printStackTrace();
            try {
                throw new Exception(e);
            } catch (Exception ex) {
            }
        } finally {
            conn.disconnect();
        }

        Log.i("data", result.toString());
        return result.toString();
    }

    public static String postjson(String Method, String param, String json) {
        StringBuilder result = new StringBuilder();
        try {
            //URL url = new URL("http://192.168.43.106:4000/collect.asmx/Collections");
            String value = preferences.getString("IP", "");
            //URL url = new URL("Http://"+ value + WEBSERVICE_URL +"/"+ Method+ "?"+param + "="+ json);
            URL url = new URL("Http://" + value + WEBSERVICE_URL + "/" + Method);
            Log.i("url", url.toString());
            //URL url = new URL("Http://197.232.39.99:" + WEBSERVICE_URL + "/" + Method);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            String urlParameters = param + "=" + json;
            connection.setInstanceFollowRedirects(true);
            connection.setRequestMethod("POST");
            connection.setRequestProperty("USER-AGENT", "Mozilla/5.0");
            connection.setRequestProperty("ACCEPT-LANGUAGE", "en-US,en;0.5");
            connection.setDoOutput(true);
            connection.setConnectTimeout(30000);
            connection.setReadTimeout(30000);

            DataOutputStream dStream = new DataOutputStream(connection.getOutputStream());
            dStream.writeBytes(urlParameters);
            dStream.flush();
            dStream.close();

            int responseCode = connection.getResponseCode();
            System.out.println("\nSending 'POST' request to URL : " + url);
            System.out.println("Post parameters : " + urlParameters);
            System.out.println("Response Group_No : " + responseCode);

            final StringBuilder output = new StringBuilder("Request URL " + url);
            output.append(System.getProperty("line.separator") + "Request Parameters " + urlParameters);
            output.append(System.getProperty("line.separator") + "Response Group_No " + responseCode);
            output.append(System.getProperty("line.separator") + "Type " + "POST");
            BufferedReader br = new BufferedReader(new InputStreamReader(connection.getInputStream()));
            String line = "";
            StringBuilder responseOutput = new StringBuilder();
            System.out.println("output===============" + br);
            while ((line = br.readLine()) != null) {
                responseOutput.append(line);
            }
            br.close();
            output.append(System.getProperty("line.separator") + "Response " + System.getProperty("line.separator") + System.getProperty("line.separator") + responseOutput.toString());
            result = responseOutput;
        } catch (Exception e) {
            Log.e("error","errors here");
            e.printStackTrace();
            try {
                throw new Exception(e);
            } catch (Exception ex) {
                Log.e("error",ex.getStackTrace().toString());
            }
        } finally {

        }

        Log.i("data", result.toString());
        return result.toString();
    }

    //	public static String SendHttpPost(Activity paramActivity,
//			String MethodName, String myagent, String MethodParam) {
//		Log.d("URL", WEBSERVICE_URL + MethodName);
//		Log.d("Data", myagent);
//		// Creating HTTP client
//		try{
//		URL url =new URL( WEBSERVICE_URL + MethodName);
//		HttpURLConnection httpClient = (HttpURLConnection) url.openConnection();
//		// Creating HTTP Post
//		HttpPost httpPost = new HttpPost(
//				WEBSERVICE_URL + MethodName);
//		List<NameValuePair> nameValuePair = new ArrayList<NameValuePair>(2);
//		nameValuePair.add(new BasicNameValuePair(MethodParam, myagent));
//		try {
//			httpPost.setEntity(new UrlEncodedFormEntity(nameValuePair));
//		} catch (UnsupportedEncodingException e) {
//			// writing error to Log
//			e.printStackTrace();
//		}
//
//		// Making HTTP Request
//		try {
//			HttpResponse response = httpClient.execute(httpPost);
//			if (response.getStatusLine().getStatusCode() == 200)
//			{
//				HttpEntity entity = response.getEntity();
//				json = EntityUtils.toString(entity);
//			}
//			// writing response to log
//			Log.d("Http Response:", json);
//		} catch (ClientProtocolException e) {
//			// writing exception to log
//			e.printStackTrace();
//		} catch (IOException e) {
//			// writing exception to log
//			e.printStackTrace();
//		}}catch (Exception ex){}
//		return json;
//	}
    private static String convertStreamToString(InputStream paramInputStream) {
        BufferedReader localBufferedReader = new BufferedReader(
                new InputStreamReader(paramInputStream));
        StringBuilder localStringBuilder = new StringBuilder();
        for (; ; ) {
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
