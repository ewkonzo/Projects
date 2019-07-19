package com.example.paul.m_branch;

import android.os.Environment;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintStream;
import java.text.SimpleDateFormat;
import java.util.Calendar;

/**
 * Created by Paulo on 9/26/2017.
 */

public class logs {
    public static FileWriter  outputfile() {
        FileWriter writer=null  ;
        try {

            File root;
            if (android.os.Environment.getExternalStorageState().equals(
                    android.os.Environment.MEDIA_MOUNTED)) {
                root = new File(Environment.getExternalStorageDirectory(), "Logs/");
            } else
                root = new File("/data/Logs/");
           if (!root.exists()) {
                root.mkdirs();
            }
          Calendar  cdt = Calendar.getInstance();
            SimpleDateFormat  batch = new SimpleDateFormat("yyyyMMdd");
            String d = batch.format(cdt.getTime());
            File gpxfile = new File(root, d);
             writer= new FileWriter(gpxfile, true);
          return  writer;

        } catch (IOException e) {
            e.printStackTrace();
        }
        return  writer;
    }
}
