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

import java.io.BufferedOutputStream;
import java.io.BufferedWriter;
import java.io.PrintStream;
import java.io.PrintWriter;
import java.util.List;

public class trans
        extends BaseAdapter {
    ViewHolder holder;
    LayoutInflater inflater;
    ImageView thumb_image;
    List<transaction> coll;
    SharedPreferences pr;
    DB db;

    public trans() {
    }

    public trans(Activity paramActivity, List<transaction> paramList, DB db) {
        this.coll = paramList;
        this.db = db;
        this.inflater = ((LayoutInflater) paramActivity.getSystemService(Context.LAYOUT_INFLATER_SERVICE));
        //this.pr = p;
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
        view = this.inflater.inflate(R.layout.trans, paramViewGroup, false);

        TextView collno = view
                .findViewById(R.id.transtype);
        if (!coll.get(paramInt).Loan_No.equals(""))
            collno.setText(db.gettype(coll.get(paramInt).Type).Name + (coll.get(paramInt).Type.contains("LOAN") ? "\n(" + coll.get(paramInt).Ward + "(" +coll.get(paramInt).Loan_No + "))" : "\n(" + coll.get(paramInt).Loan_No + ")"));
        else
            collno.setText(db.gettype(coll.get(paramInt).Type).Name);
        TextView datecol = view
                .findViewById(R.id.amount);
        datecol.setText(coll.get(paramInt).Amount.toString());
        ImageView delete = view.findViewById(R.id.delete);
        delete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try{
                db.deletetrans(coll.get(paramInt).Document_No);
                coll.remove(paramInt);
                notifyDataSetChanged();}
                catch (Exception e){
                    e.printStackTrace(new PrintWriter(new BufferedWriter(logs.outputfile())));
                }
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