package com.example.paul.a_sacco;

import android.app.Activity;
import android.os.Bundle;
import android.support.v4.app.ListFragment;
import android.view.View;
import android.widget.ListView;
import com.example.paul.a_sacco.dummy.Menu;
import com.example.paul.a_sacco.dummy.Menu.DummyItem;
import java.util.List;

public class AgencyListFragment
  extends ListFragment
{
  private static final String STATE_ACTIVATED_POSITION = "activated_position";
  private static Callbacks sDummyCallbacks = new Callbacks()
  {
    public void onItemSelected(String paramAnonymousString) {}
  };
  private int mActivatedPosition = -1;
  private Callbacks mCallbacks = sDummyCallbacks;
  
  private void setActivatedPosition(int paramInt)
  {
    if (paramInt == -1) {
      getListView().setItemChecked(this.mActivatedPosition, false);
    }
    for (;;)
    {
      this.mActivatedPosition = paramInt;
      return;
      getListView().setItemChecked(paramInt, true);
    }
  }
  
  public void onAttach(Activity paramActivity)
  {
    super.onAttach(paramActivity);
    if (!(paramActivity instanceof Callbacks)) {
      throw new IllegalStateException("Activity must implement fragment's callbacks.");
    }
    this.mCallbacks = ((Callbacks)paramActivity);
  }
  
  public void onCreate(Bundle paramBundle)
  {
    super.onCreate(paramBundle);
    paramBundle = getActivity();
    new Menu();
    setListAdapter(new BindMenu(paramBundle, Menu.ITEMS));
  }
  
  public void onDetach()
  {
    super.onDetach();
    this.mCallbacks = sDummyCallbacks;
  }
  
  public void onListItemClick(ListView paramListView, View paramView, int paramInt, long paramLong)
  {
    super.onListItemClick(paramListView, paramView, paramInt, paramLong);
    this.mCallbacks.onItemSelected(((Menu.DummyItem)Menu.ITEMS.get(paramInt)).id);
  }
  
  public void onSaveInstanceState(Bundle paramBundle)
  {
    super.onSaveInstanceState(paramBundle);
    if (this.mActivatedPosition != -1) {
      paramBundle.putInt("activated_position", this.mActivatedPosition);
    }
  }
  
  public void onViewCreated(View paramView, Bundle paramBundle)
  {
    super.onViewCreated(paramView, paramBundle);
    if ((paramBundle != null) && (paramBundle.containsKey("activated_position"))) {
      setActivatedPosition(paramBundle.getInt("activated_position"));
    }
  }
  
  public void setActivateOnItemClick(boolean paramBoolean)
  {
    ListView localListView = getListView();
    if (paramBoolean) {}
    for (int i = 1;; i = 0)
    {
      localListView.setChoiceMode(i);
      return;
    }
  }
  
  public static abstract interface Callbacks
  {
    public abstract void onItemSelected(String paramString);
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\AgencyListFragment.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */