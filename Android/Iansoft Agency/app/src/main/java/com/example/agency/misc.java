package com.example.agency;

import android.app.Activity;
import android.util.Log;
import android.widget.Toast;

/**
 * Created by Paul on 1/14/2016.
 */
public class misc {
    public static Class<?> cactivity;
    public  static void debug(String info){
        Log.d("debug",info);
    }
    public static void tost(Activity a, String s) {
        Toast.makeText(a.getApplicationContext(),s,Toast.LENGTH_LONG).show();
    }
}
