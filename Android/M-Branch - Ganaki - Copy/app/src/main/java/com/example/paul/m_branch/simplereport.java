package com.example.paul.m_branch;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

public class simplereport
        extends BaseAdapter {
    ViewHolder holder;
    LayoutInflater inflater;
    ImageView thumb_image;
    List<transaction> coll;
    SharedPreferences pr ;
    public simplereport() {
    }
    public simplereport(Activity paramActivity, List<transaction> paramList, SharedPreferences p) {
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

        view = this.inflater.inflate(R.layout.activity_reports, paramViewGroup, false);

//        TextView collno = (TextView) view
//                .findViewById(R.id.collectionid);
//        collno.setText(coll.get(paramInt).Collection_Number);
//
//        TextView datecol = (TextView) view
//                .findViewById(R.id.Datetime);
//        datecol.setText(coll.get(paramInt).Date + " "+ coll.get(paramInt).Time);
//
//        TextView kgcol = (TextView) view
//                .findViewById(R.id.Kgcollected);
//        kgcol.setText( coll.get(paramInt).Kg_Collected.toString());
//        ImageButton print  = (ImageButton)view.findViewById(R.id.printsingle);
//        print.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                Summaries.printer p = new Summaries.printer();
//
//                p.printcollection(pr,coll.get(paramInt));
//
//            }
//        });
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