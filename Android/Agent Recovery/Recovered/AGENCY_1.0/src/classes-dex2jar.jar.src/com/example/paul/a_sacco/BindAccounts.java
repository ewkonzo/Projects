package com.example.paul.a_sacco;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.TextView;
import java.util.List;

public class BindAccounts
  extends BaseAdapter
{
  public static Account outdata;
  List<Account> DataCollection;
  ViewHolder holder;
  LayoutInflater inflater;
  private int mSelectedPosition = -1;
  private RadioButton mSelectedRB;
  ImageView thumb_image;
  
  public BindAccounts() {}
  
  public BindAccounts(Activity paramActivity, List<Account> paramList)
  {
    this.DataCollection = paramList;
    this.inflater = ((LayoutInflater)paramActivity.getSystemService("layout_inflater"));
  }
  
  public int getCount()
  {
    return this.DataCollection.size();
  }
  
  public Object getItem(int paramInt)
  {
    return null;
  }
  
  public long getItemId(int paramInt)
  {
    return 0L;
  }
  
  public View getView(final int paramInt, View paramView, ViewGroup paramViewGroup)
  {
    paramViewGroup = paramView;
    getItemViewType(paramInt);
    if (paramView == null)
    {
      paramViewGroup = this.inflater.inflate(2130903064, null);
      this.holder = new ViewHolder();
      this.holder.Account = ((TextView)paramViewGroup.findViewById(2131296317));
      this.holder.Type = ((TextView)paramViewGroup.findViewById(2131296318));
      this.holder.radio = ((RadioButton)paramViewGroup.findViewById(2131296303));
      paramViewGroup.setTag(this.holder);
      this.holder.Account.setText(((Account)this.DataCollection.get(paramInt)).Account_No);
      this.holder.Type.setText(((Account)this.DataCollection.get(paramInt)).Account_type);
      this.holder.radio.setOnClickListener(new View.OnClickListener()
      {
        public void onClick(View paramAnonymousView)
        {
          if ((paramInt != BindAccounts.this.mSelectedPosition) && (BindAccounts.this.mSelectedRB != null)) {
            BindAccounts.this.mSelectedRB.setChecked(false);
          }
          BindAccounts.access$002(BindAccounts.this, paramInt);
          BindAccounts.access$102(BindAccounts.this, (RadioButton)paramAnonymousView);
          BindAccounts.outdata = (Account)BindAccounts.this.DataCollection.get(paramInt);
        }
      });
      if (this.mSelectedPosition == paramInt) {
        break label196;
      }
      this.holder.radio.setChecked(false);
    }
    for (;;)
    {
      return paramViewGroup;
      this.holder = ((ViewHolder)paramViewGroup.getTag());
      break;
      label196:
      this.holder.radio.setChecked(true);
      if ((this.mSelectedRB != null) && (this.holder.radio != this.mSelectedRB)) {
        this.mSelectedRB = this.holder.radio;
      }
    }
  }
  
  static class ViewHolder
  {
    TextView Account;
    TextView Type;
    RadioButton radio;
    TextView tvName;
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\BindAccounts.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */