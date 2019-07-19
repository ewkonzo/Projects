package com.example.paul.datacollector;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import java.io.IOException;
import java.util.List;

import static android.content.Context.MODE_PRIVATE;

public class farmerreport
        extends BaseAdapter {
    ViewHolder holder;
    LayoutInflater inflater;
    ImageView thumb_image;
    List<Collection> coll;
    SharedPreferences pr ;
    public farmerreport() {
    }

    public farmerreport(Activity paramActivity, List<Collection> paramList, SharedPreferences p) {
        this.coll = paramList;
        this.inflater = ((LayoutInflater) paramActivity.getSystemService(Context.LAYOUT_INFLATER_SERVICE));
   this.pr = p;
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
        datecol.setText(coll.get(paramInt).Date );

        TextView kgcol = (TextView) view
                .findViewById(R.id.Kgcollected);
        kgcol.setText( coll.get(paramInt).Kg_Collected.toString());

        TextView time = (TextView) view
                .findViewById(R.id.time);
        time.setText( coll.get(paramInt).Time.toString());

        TextView collby = (TextView) view
                .findViewById(R.id.collectby);
        collby.setText( coll.get(paramInt).Collected_by.toString());

        ImageView status = (ImageView) view
                .findViewById(R.id.status);

        if (coll.get(paramInt).sent==true )
            status.setImageResource(R.drawable.sent);
        else
            status.setImageResource(R.drawable.dialog_close);


        ImageButton print  = (ImageButton)view.findViewById(R.id.printsingle);
        print.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Summaries.printer p = new Summaries.printer();

                p.printcollection(pr,coll.get(paramInt));

            }
        });
        return view;
    }


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