package com.example.agency;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

public class BindMenu
  extends BaseAdapter
{
  ViewHolder holder;
  LayoutInflater inflater;
  ImageView thumb_image;
  List<Menu.DummyItem> weatherDataCollection;
  
  public BindMenu() {}
  
  public BindMenu(Activity paramActivity, List<Menu.DummyItem> paramList)
  {
    this.weatherDataCollection = paramList;
    this.inflater = ((LayoutInflater)paramActivity.getSystemService( Context.LAYOUT_INFLATER_SERVICE));
  }
  
  public int getCount()
  {
    return this.weatherDataCollection.size();
  }
  
  public Object getItem(int paramInt)
  {
    return null;
  }
  
  public long getItemId(int paramInt)
  {
    return 0L;
  }
  
  public View getView(int paramInt, View paramView, ViewGroup paramViewGroup) {
    View view;
    view = this.inflater.inflate(R.layout.orders_row, paramViewGroup, false);
    this.holder = new ViewHolder();
    this.holder.tvName = ((TextView) view.findViewById(R.id.tvitemname));
    this.holder.tvdelete = ((ImageView) view.findViewById(R.id.list_delete));
    this.holder.tvDesc = ((TextView) view.findViewById(R.id.tvitemDesc));

    view.setTag(this.holder);


    this.holder.tvName.setText(this.weatherDataCollection.get(paramInt).content);
    this.holder.tvdelete.setImageResource(this.weatherDataCollection.get(paramInt).image);
    this.holder.tvDesc.setText(this.weatherDataCollection.get(paramInt).desc);
    this.holder = ((ViewHolder) view.getTag());
    return view;
  }
  
  static class ViewHolder
  {
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