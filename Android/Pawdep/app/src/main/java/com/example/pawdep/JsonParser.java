package com.example.pawdep;

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
    public static String WEBSERVICE_URL = "/Collect.asmx";



    public static String postjson(String Method, String param, String json) {
        StringBuilder result = new StringBuilder();
        try {

           // String value = preferences.getString("IP", "");

           //URL url = new URL("Http://" + value + WEBSERVICE_URL + "/" + Method);
            URL url = new URL("Http://192.168.30.51:405" + WEBSERVICE_URL + "/" + Method);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            String urlParameters = param + "=" + json;
            connection.setInstanceFollowRedirects(true);
            connection.setRequestMethod("POST");
            connection.setRequestProperty("USER-AGENT", "Mozilla/5.0");
            connection.setRequestProperty("ACCEPT-LANGUAGE", "en-US,en;0.5");
            connection.setDoOutput(true);
            connection.setConnectTimeout(600000);
            connection.setReadTimeout(600000);

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
            e.printStackTrace();
            try {
                throw new Exception(e);
            } catch (Exception ex) {
            }
        } finally {

        }

        Log.i("data", result.toString());
        return result.toString();
    }


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


}
