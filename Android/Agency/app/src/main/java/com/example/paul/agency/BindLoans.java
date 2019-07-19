package com.example.paul.agency;

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

public class BindLoans
  extends BaseAdapter
{
  public static Loans outdata;
  List<Loans> DataCollection;
  ViewHolder holder;
  LayoutInflater inflater;
  private int mSelectedPosition = -1;
  private RadioButton mSelectedRB;
  ImageView thumb_image;
  
  public BindLoans() {}
  
  public BindLoans(Activity paramActivity, List<Loans> paramList)
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
      paramViewGroup = this.inflater.inflate(2130903081, null);
      this.holder = new ViewHolder();
      this.holder.Loan_no = ((TextView)paramViewGroup.findViewById(2131296380));
      this.holder.Type = ((TextView)paramViewGroup.findViewById(2131296379));
      this.holder.radio = ((RadioButton)paramViewGroup.findViewById(2131296303));
      paramViewGroup.setTag(this.holder);
      this.holder.Loan_no.setText(((Loans)this.DataCollection.get(paramInt)).Loan_No);
      this.holder.Type.setText(((Loans)this.DataCollection.get(paramInt)).Loan_Type_Name);
      this.holder.radio.setOnClickListener(new OnClickListener()
      {
        public void onClick(View paramAnonymousView)
        {
          if ((paramInt != BindLoans.this.mSelectedPosition) && (BindLoans.this.mSelectedRB != null)) {
            BindLoans.this.mSelectedRB.setChecked(false);
          }
          BindLoans.access$002(BindLoans.this, paramInt);
          BindLoans.access$102(BindLoans.this, (RadioButton)paramAnonymousView);
          BindLoans.outdata = (Loans)BindLoans.this.DataCollection.get(paramInt);
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
    TextView Balance;
    TextView Loan_no;
    TextView Type;
    RadioButton radio;
    TextView source;
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\BindLoans.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */