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
    addItem(new DummyItem(0, "Registration",  R.drawable.registration,"Register new members"));
    addItem(new DummyItem(1, "Share Variation",  R.drawable.edit,"Review the amount of share contribution through check off"));
    addItem(new DummyItem(2, "Account Activation", R.drawable.activation,"Sends customer agency pin"));
    addItem(new DummyItem(3, "Open FOSA",  R.drawable.user_male_add,"Open Fosa accounts"));
    addItem(new DummyItem(4, "Cash WithDraw",  R.drawable.dollars,"Get cash from your account through the agent"));
    addItem(new DummyItem(5, "Cash Deposit",  R.drawable.cashdeposits,"Deposit cash to your account through the agent"));
    addItem(new DummyItem(6, "Pay loan",  R.drawable.payment,"Choose and pay your outstanding loans"));
    addItem(new DummyItem(7, "Apply for loan", R.drawable.loan ,"Apply for different kind of loans"));
    addItem(new DummyItem(8, "Transfer Funds",  R.drawable.money_bills,"Transfer funds to other FOSA accounts"));
    addItem(new DummyItem(9, "Share Deposit/Capital",  R.drawable.sharedeposit,"Boost your share deposit"));
    addItem(new DummyItem(10, "Balance Enquiry",  R.drawable.dollars,"Send a balance to the customer via sms"));
    addItem(new DummyItem(11, "Mini statement",  R.drawable.ministatement,"Send/Print last five transactions"));
    addItem(new DummyItem(12, "Change Client pin",  R.drawable.key,"Allow customers to change their pin"));
  }
  
  private static void addItem(DummyItem paramDummyItem)
  {
    ITEMS.add(paramDummyItem);
    ITEM_MAP.put(String.valueOf(paramDummyItem.id), paramDummyItem);
  }
  
  public static class DummyItem
  {
    public String content;
    public int id;
    public int image;
    public  String desc;
    public DummyItem(int paramString1, String paramString2, int paramInt,String des)
    {
      this.id = paramString1;
      this.content = paramString2;
      this.image = paramInt;
      this.desc = des;
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