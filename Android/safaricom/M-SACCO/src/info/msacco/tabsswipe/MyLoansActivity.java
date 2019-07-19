package info.msacco.tabsswipe;

import info.msacco.tabsswipe.adapter.MyLoansTabsPagerAdapter;
import info.msacco.utils.Configuration;
import android.app.ActionBar;
import android.app.ActionBar.Tab;
import android.app.ActionBar.TabListener;
import android.app.FragmentTransaction;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.view.ViewPager;

import com.msacco.safaricom_sacco.R;

public class MyLoansActivity extends FragmentActivity implements TabListener {

	private ViewPager viewPager;
	private MyLoansTabsPagerAdapter mAdapter;
	private ActionBar actionBar;;

	// Tab titles
	private String[] tabs = { "Request", "Repayment", "Status" };
	private String msisdn = null;
	private String soap_url = null;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.my_loans_activity);

		Configuration cfg = new Configuration();
		msisdn = cfg.getTelephoneNo();
		soap_url = Configuration.getURL();

		// Initialization
		viewPager = (ViewPager) findViewById(R.id.myLoansPager);
		actionBar = getActionBar();
		mAdapter = new MyLoansTabsPagerAdapter(getSupportFragmentManager());

		viewPager.setAdapter(mAdapter);
		// actionBar.setHomeButtonEnabled(false);
		actionBar.setNavigationMode(ActionBar.NAVIGATION_MODE_TABS);

		// Adding Tabs
		for (String tab_name : tabs) {
			actionBar.addTab(actionBar.newTab().setText(tab_name)
					.setTabListener(this));
		}
		/**
		 * on swiping the viewpager make respective tab selected
		 * */
		viewPager.setOnPageChangeListener(new ViewPager.OnPageChangeListener() {

			@Override
			public void onPageSelected(int position) {
				// on changing the page
				// make respected tab selected
				actionBar.setSelectedNavigationItem(position);
			}

			@Override
			public void onPageScrolled(int arg0, float arg1, int arg2) {
			}

			@Override
			public void onPageScrollStateChanged(int arg0) {
			}
		});

	}

	@Override
	public void onTabReselected(Tab tab, FragmentTransaction ft) {
		// TODO Auto-generated method stub

	}

	@Override
	public void onTabSelected(Tab tab, FragmentTransaction ft) {

		// on tab selected
		// show respected fragment view
		viewPager.setCurrentItem(tab.getPosition());

	}

	@Override
	public void onTabUnselected(Tab arg0, FragmentTransaction arg1) {
		// TODO Auto-generated method stub

	}
}
