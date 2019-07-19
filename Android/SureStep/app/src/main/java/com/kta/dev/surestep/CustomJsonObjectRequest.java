package com.kta.dev.surestep;

/**
 * Created by mikie on 2/17/15.
 */

import com.android.volley.NetworkResponse;
import com.android.volley.ParseError;
import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.Response.ErrorListener;
import com.android.volley.Response.Listener;
import com.android.volley.toolbox.HttpHeaderParser;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.UnsupportedEncodingException;
import java.util.Map;

public class CustomJsonObjectRequest extends Request<JSONObject> {

    private Listener<JSONObject> mListener;
    private Map<String, String> mParams;

    public CustomJsonObjectRequest(String url, Map<String, String> params,
                                   Listener<JSONObject> listener,
                                   ErrorListener errorListener) {
        super(Method.GET, url, errorListener);
        mListener = listener;
        mParams = params;
    }

    public CustomJsonObjectRequest(int method, String url, Map<String, String> params,
                                   Listener<JSONObject> listener,
                                   ErrorListener errorListener) {
        super(method, url, errorListener);
        mListener = listener;
        mParams = params;
    }

    protected Map<String, String> getParams()
            throws com.android.volley.AuthFailureError {
        return mParams;
    }

    @Override
    protected Response<JSONObject> parseNetworkResponse(NetworkResponse response) {
        try {
            String jsonString = new String(response.data,
                    HttpHeaderParser.parseCharset(response.headers));
            return Response.success(new JSONObject(jsonString),
                    HttpHeaderParser.parseCacheHeaders(response));
        } catch (UnsupportedEncodingException e) {
            return Response.error(new ParseError(e));
        } catch (JSONException je) {
            return Response.error(new ParseError(je));
        }
    }

    @Override
    protected void deliverResponse(JSONObject response) {
        // TODO Auto-generated method stub
        mListener.onResponse(response);
    }
}