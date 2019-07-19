package info.msacco.tabsswipe.adapter;

import info.msacco.tabsswipe.MyCardsRequestFragment;
import info.msacco.tabsswipe.MyCardsStopFragment;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

public class MyCardsTabsPagerAdapter extends FragmentPagerAdapter {

	private static final int NO_OF_TABS = 2;

	public MyCardsTabsPagerAdapter(FragmentManager fm) {
		super(fm);
	}

	@Override
	public Fragment getItem(int index) {

		switch (index) {
		case 0:
			// Deposit Fragment
			return new MyCardsRequestFragment();
		case 1:
			// Account balance Fragment
			return new MyCardsStopFragment();
			// case 2:
			// Deposit Fragment
			// return new MyCardsATMLocatorFragment();
		}

		return null;
	}

	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return NO_OF_TABS;
	}

}
