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

public class BindLoanproducts
  extends BaseAdapter
{
  public static Products outdata;
  List<Products> DataCollection;
  ViewHolder holder;
  LayoutInflater inflater;
  private int mSelectedPosition = -1;
  private RadioButton mSelectedRB;
  ImageView thumb_image;

  public BindLoanproducts() {}

  public BindLoanproducts(Activity paramActivity, List<Products> paramList)
  {
    this.DataCollection = paramList;
    this.inflater = ((LayoutInflater)paramActivity.getSystemService(Context.LAYOUT_INFLATER_SERVICE));
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
    if (paramView == null)
    {
      paramView = this.inflater.inflate(R.layout.products, null);
      this.holder = new ViewHolder();
      this.holder.maxloan = ((TextView)paramView.findViewById(R.id.tvloanmax));
      this.holder.Type = ((TextView)paramView.findViewById(R.id.tvloancode));
      this.holder.radio = ((RadioButton)paramView.findViewById(R.id.radio));
      paramView.setTag(this.holder);
      this.holder.maxloan.setText(String.valueOf (((Products)this.DataCollection.get(paramInt)).Max_Loan_Amount));
      this.holder.Type.setText(((Products)this.DataCollection.get(paramInt)).Product_Description);
      this.holder.radio.setOnClickListener(new OnClickListener()
      {
        public void onClick(View paramAnonymousView)
        {
          if ((paramInt != BindLoanproducts.this.mSelectedPosition) && (BindLoanproducts.this.mSelectedRB != null)) {
            BindLoanproducts.this.mSelectedRB.setChecked(false);
          }
//          BindLoans.access$002(BindLoans.this, paramInt);
//          BindLoans.access$102(BindLoans.this, (RadioButton)paramAnonymousView);
          BindLoanproducts.outdata = (Products)BindLoanproducts.this.DataCollection.get(paramInt);
        }
      });
      if (this.mSelectedPosition == paramInt) {
        this.holder.radio.setChecked(false);
      }
    }

      this.holder = ((ViewHolder)paramView.getTag());

      //this.holder.radio.setChecked(true);
      if ((this.mSelectedRB != null) && (this.holder.radio != this.mSelectedRB)) {
        this.mSelectedRB = this.holder.radio;
      }

    return paramView;
  }
  
  static class ViewHolder
  {
    TextView Balance;
    TextView maxloan;
    TextView Type;
    RadioButton radio;
    TextView source;
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\BindLoans.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */