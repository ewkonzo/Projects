package elegance.hasoft.com.elegance;

import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.graphics.Typeface;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Created by User on Jun-05.
 */
public class UserAdapter extends BaseAdapter {
    private ArrayList<HashMap<String, String>> trendlist;
    private LayoutInflater layoutInflater;
    Context c;
    private int columnWidth;
    Activity act;

    public UserAdapter(Activity activity, ArrayList<HashMap<String, String>> list){
        layoutInflater = activity.getLayoutInflater();
        trendlist = list;
        c=activity;
        act=activity;
    }

    @Override
    public int getCount() {
        return trendlist.size();
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
        convertView=layoutInflater.inflate(R.layout.notes_layout,null);
        String name=trendlist.get(+position).get("name");
        TextView t=(TextView)convertView.findViewById(R.id.itemname);
        TextView tdes=(TextView)convertView.findViewById(R.id.itemdes);
        RoundedLetterView s=(RoundedLetterView)convertView.findViewById(R.id.imageView);
        s.setTitleText((trendlist.get(+position).get("name").substring(0, 1).toUpperCase()));
        t.setText(name);
        t.setTextColor(Color.BLACK);
        tdes.setTypeface(Typeface.DEFAULT_BOLD);
        tdes.setText(trendlist.get(+position).get("category"));
        return convertView;
    }
}
