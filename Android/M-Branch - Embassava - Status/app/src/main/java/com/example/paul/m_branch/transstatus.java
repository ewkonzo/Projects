package com.example.paul.m_branch;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

public class transstatus
        extends BaseAdapter {
    ViewHolder holder;
    LayoutInflater inflater;
    ImageView thumb_image;
    List<transaction> coll;
    SharedPreferences pr;
    DB db;

    public transstatus() {
    }

    public transstatus(Activity paramActivity, List<transaction> paramList, DB db) {
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
        view = this.inflater.inflate(R.layout.transstatus, paramViewGroup, false);

        TextView collno = (TextView) view
                .findViewById(R.id.transtype);
        types t = db.gettype(coll.get(paramInt).Type);
        if (!coll.get(paramInt).Loan_No.equals("")) {
                    collno.setText((t==null?coll.get(paramInt).Type:t.Name) + (coll.get(paramInt).Type.contains("LOAN") ? "\n(" + coll.get(paramInt).Ward + ")\n" + coll.get(paramInt).Time + "" : "\n" + coll.get(paramInt).Time + ""));
        } else {
            collno.setText((t==null?coll.get(paramInt).Type:t.Name));
        }


        TextView datecol = (TextView) view
                .findViewById(R.id.amount);
        datecol.setText(coll.get(paramInt).Amount.toString());
        TextView user = (TextView) view
                .findViewById(R.id.agent);
        user.setText(coll.get(paramInt).Agent_Code);
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