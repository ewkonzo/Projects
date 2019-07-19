package com.example.m_saccoagency;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Menu
{
  public static List<DummyItem> ITEMS = new ArrayList();
  public static Map<String, DummyItem> ITEM_MAP = new HashMap();

    static
  {
    addItem(new DummyItem("11", "Account Activation", R.drawable.user_male_add));
    addItem(new DummyItem("1", "Account Opening",  R.drawable.user_male_add));
    addItem(new DummyItem("12", "Member Registration",  R.drawable.user_male_add));
    addItem(new DummyItem("2", "Cash WithDraw",  R.drawable.dollars));
    addItem(new DummyItem("3", "Cash Deposit",  R.drawable.cashdeposits));
    addItem(new DummyItem("4", "Loan Repayment",  R.drawable.payment));
    addItem(new DummyItem("5", "Cash Transfer",  R.drawable.money_bills));
    addItem(new DummyItem("6", "Share Deposit",  R.drawable.sharedeposit));
    addItem(new DummyItem("7", "Balance Enquiry",  R.drawable.dollars));
    addItem(new DummyItem("8", "Mini statement",  R.drawable.ministatement));
    addItem(new DummyItem("10", "Change Client pin",  R.drawable.key));
  }
  
  private static void addItem(DummyItem paramDummyItem)
  {
    ITEMS.add(paramDummyItem);
    ITEM_MAP.put(String.valueOf(paramDummyItem.id), paramDummyItem);
  }
  
  public static class DummyItem
  {
    public String content;
    public String id;
    public int image;
    
    public DummyItem(String paramString1, String paramString2, int paramInt)
    {
      this.id = paramString1;
      this.content = paramString2;
      this.image = paramInt;
    }
    
    public String toString()
    {
      return this.content;
    }
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\dummy\Menu.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */