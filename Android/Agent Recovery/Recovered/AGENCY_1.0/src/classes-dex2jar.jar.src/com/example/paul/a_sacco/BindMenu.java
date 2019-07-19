package com.example.paul.a_sacco;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;
import com.example.paul.a_sacco.dummy.Menu.DummyItem;
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
    this.inflater = ((LayoutInflater)paramActivity.getSystemService("layout_inflater"));
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
  
  public View getView(int paramInt, View paramView, ViewGroup paramViewGroup)
  {
    paramViewGroup = paramView;
    if (paramView == null)
    {
      paramViewGroup = this.inflater.inflate(2130903083, null);
      this.holder = new ViewHolder();
      this.holder.tvName = ((TextView)paramViewGroup.findViewById(2131296383));
      this.holder.tvdelete = ((ImageView)paramViewGroup.findViewById(2131296382));
      paramViewGroup.setTag(this.holder);
    }
    for (;;)
    {
      this.holder.tvName.setText(((Menu.DummyItem)this.weatherDataCollection.get(paramInt)).content);
      this.holder.tvdelete.setImageResource(((Menu.DummyItem)this.weatherDataCollection.get(paramInt)).image);
      return paramViewGroup;
      this.holder = ((ViewHolder)paramViewGroup.getTag());
    }
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