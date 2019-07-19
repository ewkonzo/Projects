package com.example.paul.datacollector;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;

import java.io.IOException;
import java.util.List;

public class farmercollection extends AppCompatActivity {
    EditText farmerno;
    ListView farmerreport;
    DB db = null;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_farmercollection);
        db = new DB(this);
        farmerno = (EditText)findViewById(R.id.txtfarmerno);
        Button find = (Button)findViewById(R.id.find);
        Button print = (Button)findViewById(R.id.print);
      print.setOnClickListener(new View.OnClickListener() {
          @Override
          public void onClick(View v) {

              if (farmerno.getText().equals("")){

                  farmerno.setError("Farmer no required");
                  return;
              }
             // printcoll(db.getcustomercollection(farmerno.getText().toString()));
          }
      });
        farmerreport  = (ListView)findViewById(R.id.listfarmerreport);
        farmerno.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if(!hasFocus){
getcustomercollection();

                }
            }
        });

        find.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
getcustomercollection();
            }
        });

    }
    private  void getcustomercollection(){

        if (farmerno.getText().equals("")){

            farmerno.setError("Farmer no required");
            return;
        }
        ListAdapter fc = new farmerreport(this,db.getcustomercollection(farmerno.getText().toString()));
            farmerreport.setAdapter(fc);

    }
//    public void printcoll(List<Collection> t) {
//        try {
//
//            String head;
//            head = "     MILK DELIVERY RECIEPT\n";
//            String data = "";
//            data = "--------------------------------\n";
//            data += "Member No:  " + t.get(0).Farmers_Number + "\n";
//            data += "Member Name:" + t.get(0).Farmers_Name + "\n";
//            data += "--------------------------------\n";
//            for (Collection c:t
//                    ) {
//                data +=  c.Collection_Number + " | "+c.Date +" "+c.Time +" | "+c.Kg_Collected.toString()+"\n";
//                          }
//
//            data += "--------------------------------\n";
//
//            data += "Served by:  " + login.Transporter.Name + "\n\n\n";
//
//
//            try {
//                Thread.sleep(1000);
//            } catch (InterruptedException e) {
//                e.printStackTrace();
//            }
//            if (MainActivity. btsocket != null) {
//                MainActivity. btoutputstream = MainActivity. btsocket.getOutputStream();
//                byte[] arrayOfByte1 = {27, 33, 0};
//                byte[] format = {27, 33, 0};
//
//                MainActivity.  btoutputstream.write(format);
//                String msg = head;
//                MainActivity.   btoutputstream.write(msg.getBytes());
//                byte[] printformat = {27, 33, 0};
//                MainActivity.   btoutputstream.write(printformat);
//                msg = data;
//                MainActivity.   btoutputstream.write(msg.getBytes());
//                MainActivity.   btoutputstream.write(0x0D);
//                MainActivity.   btoutputstream.write(0x0D);
//                MainActivity.   btoutputstream.write(0x0D);
//                MainActivity.  btoutputstream.flush();
//            }
//
//
//        } catch (IOException e) {
//            e.printStackTrace();
//        }
//
//    }


}

