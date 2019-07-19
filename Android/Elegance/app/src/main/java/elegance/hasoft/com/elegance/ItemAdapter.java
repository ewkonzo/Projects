package elegance.hasoft.com.elegance;

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
public class ItemAdapter extends BaseAdapter {
    private ArrayList<HashMap<String, String>> trendlist;
    private ArrayList<HashMap<String, String>> trendlist2;
    private LayoutInflater layoutInflater;
    Context c;
    private int columnWidth;
    Activity act;

    public ItemAdapter(Activity activity, ArrayList<HashMap<String, String>> list){
        layoutInflater = activity.getLayoutInflater();
        trendlist = list;
        trendlist2=new ArrayList<HashMap<String, String>>();
        c=activity;
        act=activity;
        trendlist2.addAll(trendlist);
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
        convertView=layoutInflater.inflate(R.layout.item_layout,null);
        TextView title=(TextView)convertView.findViewById(R.id.itemname);
        TextView brandt=(TextView)convertView.findViewById(R.id.itembrand);
        TextView itemprice=(TextView)convertView.findViewById(R.id.itemprice);
        TextView quantity=(TextView)convertView.findViewById(R.id.itemquantity);

        String color=trendlist.get(+position).get("color")+" ";
        String fab=trendlist.get(+position).get("fabric")+" ";
        String item=trendlist.get(+position).get("item");
        String itemcode=trendlist.get(+position).get("itemcode");

        String itemcat=trendlist.get(+position).get("itemcategory")+" ";

if(itemcode==null){
    title.setText(item+"|"+color+"|"+fab+"|"+itemcat);
}else{
    title.setText("Code:"+itemcode+"\n\n"+item+"|"+color+"|"+fab+"|"+itemcat);
}

        brandt.setText("Brand: " + trendlist.get(+position).get("brand"));
        itemprice.setText("Unit Price:USD " + trendlist.get(+position).get("unitprice"));
        quantity.setText("Quantity: " + trendlist.get(+position).get("quantity"));

        RoundedLetterView s=(RoundedLetterView)convertView.findViewById(R.id.imageView);

        s.setTitleText((trendlist.get(+position).get("item").substring(0,1).toUpperCase()));




        return convertView;
    }
}
