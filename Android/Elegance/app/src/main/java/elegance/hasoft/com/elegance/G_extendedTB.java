package elegance.hasoft.com.elegance;

import android.content.Context;
import android.content.res.Resources;
import android.support.v7.widget.Toolbar;
import android.util.DisplayMetrics;
import android.view.LayoutInflater;
import android.view.View;
import android.view.animation.DecelerateInterpolator;
import android.widget.AbsListView;
import android.widget.GridView;
import android.widget.ListView;
import android.widget.ScrollView;
import android.widget.TextView;
import android.widget.Toast;

import com.nineoldandroids.animation.ObjectAnimator;

import floatt.FloatingActionButton;

/**
 * Created by @geek_nat on Jun-29.
 * @author geek_nat
 * @version 1.0.1
 */
public class G_extendedTB implements AbsListView.OnScrollListener{
    ListView listView;
    FloatingActionButton mFab;
    Toolbar toolbar;
    GridView gridView;
    ScrollView scrollView;
    View mContainerHeader;
    ObjectAnimator fade;
    Context mContext;
    Resources res;
    String title,subtitle;
    boolean showFab=false;
    TextView tTitle,tSub;

    public G_extendedTB(Context context,Toolbar toolBar,ListView list,FloatingActionButton fab,Boolean showFab){
       this.toolbar=toolBar;
       this.mContext=context;
       this.listView=list;
       this.res=this.mContext.getResources();
       this.showFab=showFab;
       this.mFab=fab;
       setup();
    }

    public G_extendedTB(Context context,Toolbar toolBar,ListView list){
        this.toolbar=toolBar;
        this.mContext=context;
        this.listView=list;
        this.res=this.mContext.getResources();
        setup();
    }

    public void addTitle(String title){
       this.title=title;
        if (title != null) {
            tTitle.setText(title);
        }
    }

    public void addSubTitle(String subtitle){
        this.subtitle=subtitle;
        if (subtitle != null) {
            tSub.setText(subtitle);
        }
    }

    public void setup(){
        if(listView!=null) {
            View headerView = LayoutInflater.from(this.mContext)
                    .inflate(R.layout.header_file, listView, false);
            mContainerHeader = headerView.findViewById(R.id.container);
            tTitle = (TextView) headerView.findViewById(R.id.title);
            tSub = (TextView) headerView.findViewById(R.id.subtitle);
            listView.addHeaderView(headerView);
            fade = ObjectAnimator.ofFloat(mContainerHeader, "alpha", 0f, 1f);
            fade.setInterpolator(new DecelerateInterpolator());
            fade.setDuration(200);
            listView.setOnScrollListener(this);
        }else{
            Toast.makeText(this.mContext,"No scrollable view",Toast.LENGTH_LONG).show();
        }
    }


    public void attachScrollView(){

    }

    public void attachGridView(){

    }

    private void toggleHeader(boolean visible, boolean force) {
        if ((force && visible) || (visible && mContainerHeader.getAlpha() == 0f)) {
            fade.setFloatValues(mContainerHeader.getAlpha(), 1f);
            fade.start();
            toolbar.setTitle("");
        } else if (force || (!visible && mContainerHeader.getAlpha() == 1f)){
            fade.setFloatValues(mContainerHeader.getAlpha(), 0f);
            fade.start();
            if(title!=null) {
                toolbar.setTitle(title);
            }
        }
        // Toggle the visibility of the title.

    }



    @Override
    public void onScrollStateChanged(AbsListView view, int scrollState) {

    }

    public void onScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount) {
        if (view != null && view.getChildCount() > 0 && firstVisibleItem == 0) {
         if(showFab) {
             // we calculate the FAB's Y position
             int translation = view.getChildAt(0).getHeight() + view.getChildAt(0).getTop();
             if(mFab!=null){
             mFab.setTranslationY(translation > 0 ? translation : 0);}
         }
            // basic.showAlert("Top Position:"+view.getChildAt(0).getTop());
            // if we scrolled more than 16dps, we hide the content and display the title
            if (view.getChildAt(0).getTop() < -dpToPx(126)) {
                toggleHeader(false, false);
            } else {
                toggleHeader(true, true);
            }
        } else {
            toggleHeader(false, false);
        }
    }


    public int dpToPx(int dp) {
        DisplayMetrics displayMetrics = res.getDisplayMetrics();
        return (int)(dp * (displayMetrics.densityDpi / 160f));
    }

}
