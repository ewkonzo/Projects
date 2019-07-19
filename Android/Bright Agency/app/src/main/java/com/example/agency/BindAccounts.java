package com.example.agency;

import android.app.Activity;
import android.content.Context;
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
    this.inflater = ((LayoutInflater)paramActivity.getSystemService( Context.LAYOUT_INFLATER_SERVICE));
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

    getItemViewType(paramInt);
    if (paramView == null) {
      paramView = this.inflater.inflate(R.layout.accounts_row, null);
      this.holder = new ViewHolder();
      this.holder.Account = ((TextView) paramView.findViewById(R.id.tvaccount));
      this.holder.Type = ((TextView) paramView.findViewById(R.id.tvaccounttype));
      this.holder.radio = ((RadioButton) paramView.findViewById(R.id.radio));
      paramView.setTag(this.holder);
      this.holder.Account.setText(((Account) this.DataCollection.get(paramInt)).Account_No);
      this.holder.Type.setText(((Account) this.DataCollection.get(paramInt)).Account_type);

      this.holder.radio.setChecked(paramInt==mSelectedPosition);
      this.holder.radio.setTag(paramInt);

      this.holder.radio.setOnClickListener(new OnClickListener() {
        public void onClick(View paramAnonymousView) {
//          if ((paramInt != BindAccounts.this.mSelectedPosition) && (BindAccounts.this.mSelectedRB != null)) {
//            BindAccounts.this.mSelectedRB.setChecked(false);
//          } else {
            mSelectedPosition = paramInt;
          //  mSelectedRB = holder.radio;
            notifyDataSetChanged();
//          }
          BindAccounts.outdata = BindAccounts.this.DataCollection.get(paramInt);
        }
      });
      if (getItemId(paramInt) == this.mSelectedPosition) {
        this.holder.radio.setChecked(true);
      } else {
        this.holder.radio.setChecked(false);
      }


//    for(Account a :DataCollection)
//    {
//      if (this.mSelectedPosition == paramInt)
//        this.holder.radio.setChecked(false);
//    }
//      this.holder = ((ViewHolder)paramView.getTag());
//      //this.holder.radio.setChecked(true);
//      if ((this.mSelectedRB != null) && (this.holder.radio != this.mSelectedRB)) {
//        this.mSelectedRB = this.holder.radio;
//      }

    }

    return paramView;
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