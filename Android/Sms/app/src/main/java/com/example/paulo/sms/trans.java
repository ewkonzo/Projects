package com.example.paulo.sms;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.List;

public class trans
        extends BaseAdapter {
    ViewHolder holder;
    LayoutInflater inflater;
    ImageView thumb_image;
    List<Sms> coll;
    SharedPreferences pr ;
    Activity c;
public static String client ="Client";
    public trans() {
    }

    public trans(Activity paramActivity, List<Sms> paramList) {
        this.coll = paramList;
c= paramActivity;
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

        TextView collno = (TextView) view.findViewById(R.id.client);

        collno.setText(coll.get(paramInt).client);

        TextView datecol = (TextView) view.findViewById(R.id.amount);

        datecol.setText(String.valueOf( coll.get(paramInt).balance ));

        TextView senttoday = (TextView) view.findViewById(R.id.senttoday);

        senttoday.setText(String.valueOf( coll.get(paramInt).SentToday ));

        ImageView add  = (ImageView) view.findViewById(R.id.add);
        add.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent intent = new Intent(c, editsms.class);
                intent.putExtra(client, coll.get(paramInt).client);
                c.startActivity(intent);
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