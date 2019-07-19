package com.example.paul.datacollector;

import android.app.Activity;
import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import java.io.IOException;
import java.util.List;

public class farmerreport
        extends BaseAdapter {
    ViewHolder holder;
    LayoutInflater inflater;
    ImageView thumb_image;
    List<Collection> coll;

    public farmerreport() {
    }

    public farmerreport(Activity paramActivity, List<Collection> paramList) {
        this.coll = paramList;
        this.inflater = ((LayoutInflater) paramActivity.getSystemService(Context.LAYOUT_INFLATER_SERVICE));
    }

    public int getCount() {
        return this.coll.size();
    }

    public Object getItem(int paramInt) {
        return null;
    }

    public long getItemId(int paramInt) {
        return 0L;
    }

    public View getView(final int paramInt, View paramView, ViewGroup paramViewGroup) {
        View view;

        view = this.inflater.inflate(R.layout.farmerreport, paramViewGroup, false);

        TextView collno = (TextView) view
                .findViewById(R.id.collectionid);
        collno.setText(coll.get(paramInt).Collection_Number);

        TextView datecol = (TextView) view
                .findViewById(R.id.Datetime);
        datecol.setText(coll.get(paramInt).Date + " "+ coll.get(paramInt).Time);

        TextView kgcol = (TextView) view
                .findViewById(R.id.Kgcollected);
        kgcol.setText( coll.get(paramInt).Kg_Collected.toString());

        Button print  = (Button)view.findViewById(R.id.printsingle);
        print.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                //print_bt(coll.get(paramInt));

            }
        });
        return view;
    }
//    public void print_bt(Collection t) {
//        try {
//
//            String head;
//            head = "     MILK DELIVERY RECIEPT\n";
//            String data = "";
//            data = "--------------------------------\n";
//            data += "Coll. No:   " + t.Collection_Number + "\n";
//            data += "Member No:  " + t.Farmers_Number + "\n";
//            data += "Member Name:" + t.Farmers_Name + "\n";
//            data += "Coll. Date: " + t.Date + "\n";
//            data += "Coll. Time: " + t.Time + "\n";
//            data += "Kg Coll:    " + t.Kg_Collected.toString() + "\n";
//            data += "--------------------------------\n";
//            data += "Cum Kg:     " + String.format("%.2f", t.Cumm) + "\n\n";
//            data += "Served by:  " + login.Transporter.Name + "\n\n\n";
//
//
//            try {
//                Thread.sleep(1000);
//            } catch (InterruptedException e) {
//                e.printStackTrace();
//            }
//            if (MainActivity.btsocket != null) {
//                MainActivity.btoutputstream = MainActivity.btsocket.getOutputStream();
//                byte[] arrayOfByte1 = {27, 33, 0};
//                byte[] format = {27, 33, 0};
//
//                MainActivity. btoutputstream.write(format);
//                String msg = head;
//                MainActivity. btoutputstream.write(msg.getBytes());
//                byte[] printformat = {27, 33, 0};
//                MainActivity.btoutputstream.write(printformat);
//                msg = data;
//                MainActivity. btoutputstream.write(msg.getBytes());
//                MainActivity. btoutputstream.write(0x0D);
//                MainActivity. btoutputstream.write(0x0D);
//                MainActivity. btoutputstream.write(0x0D);
//                MainActivity. btoutputstream.flush();
//            }
//
//
//        } catch (IOException e) {
//            e.printStackTrace();
//        }
//
//    }

    static class ViewHolder {
        TextView gtotal;
        TextView id;
        TextView tvDesc;
        TextView tvName;
        ImageView tvdelete;
        TextView tvitems;
        TextView tvtotal;
    }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\BindMenu.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */