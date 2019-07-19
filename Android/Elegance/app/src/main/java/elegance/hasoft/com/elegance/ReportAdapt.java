package elegance.hasoft.com.elegance;

/**
 * Created by User on Jun-07.
 */

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Created by User on May-30.
 */
public class ReportAdapt extends BaseAdapter {
    private ArrayList<HashMap<String, String>> trendlist;
    private ArrayList<HashMap<String, String>> trendlist2;
    private LayoutInflater layoutInflater;
    Context c;
    private int columnWidth;
    Activity act;

    public ReportAdapt(Activity activity, ArrayList<HashMap<String, String>> list){
        layoutInflater = activity.getLayoutInflater();
        trendlist = list;
        trendlist2=new ArrayList<HashMap<String, String>>();
        c=activity;
        act=activity;
        trendlist2.addAll(trendlist);
    }

    @Override
    public int getCount() {
        return 4;
    }

    @Override
    public Object getItem(int position) {
        return null;
    }

    @Override
    public long getItemId(int position) {
        return 0;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        convertView=layoutInflater.inflate(R.layout.report_layout,null);
        TextView name=(TextView)convertView.findViewById(R.id.reportname);
        TextView cash=(TextView)convertView.findViewById(R.id.reportcash);

if(trendlist.size()!=0) {
    cash.setText("KES " + trendlist.get(+position).get("name"));
}else{
    cash.setText("KES 0");
}
        if(position==0){
            name.setText("Total Sales");

        }


        if(position==1){
            name.setText("Total Purchases");

        }


        if(position==2){
            name.setText("Total Expenses");

        }


        if(position==3){
            name.setText("Net Profit");

        }




        return convertView;
    }
}
