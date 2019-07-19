package android.support.v7.app;

import android.content.Context;
import android.support.v7.internal.view.ActionModeWrapper;
import android.support.v7.internal.view.ActionModeWrapper.CallbackWrapper;
import android.support.v7.internal.view.ActionModeWrapperJB;
import android.support.v7.internal.view.ActionModeWrapperJB.CallbackWrapper;
import android.support.v7.view.ActionMode.Callback;
import android.view.ActionMode;

class ActionBarActivityDelegateJB
  extends ActionBarActivityDelegateICS
{
  ActionBarActivityDelegateJB(ActionBarActivity paramActionBarActivity)
  {
    super(paramActionBarActivity);
  }
  
  ActionModeWrapper.CallbackWrapper createActionModeCallbackWrapper(Context paramContext, ActionMode.Callback paramCallback)
  {
    return new ActionModeWrapperJB.CallbackWrapper(paramContext, paramCallback);
  }
  
  ActionModeWrapper createActionModeWrapper(Context paramContext, ActionMode paramActionMode)
  {
    return new ActionModeWrapperJB(paramContext, paramActionMode);
  }
  
  public ActionBar createSupportActionBar()
  {
    return new ActionBarImplJB(this.mActivity, this.mActivity);
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\android\support\v7\app\ActionBarActivityDelegateJB.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */