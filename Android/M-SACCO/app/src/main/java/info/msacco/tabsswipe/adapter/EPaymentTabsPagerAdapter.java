package info.msacco.tabsswipe.adapter;

import info.msacco.tabsswipe.EPayBuyGoodsFragment;
import info.msacco.tabsswipe.EPayOnlinePaymentFragment;
import info.msacco.tabsswipe.EPayPayBillFragment;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

public class EPaymentTabsPagerAdapter extends FragmentPagerAdapter {

	private static final int NO_OF_TABS = 3;

	public EPaymentTabsPagerAdapter(FragmentManager fm) {
		super(fm);
	}

	@Override
	public Fragment getItem(int index) {

		switch (index) {
		case 0:
			// MobilebWithdraw fragment activity
			return new EPayBuyGoodsFragment();
		case 1:
			// AGENT Withdraw activity
			return new EPayPayBillFragment();
		case 2:
			// ATM Withdraw fragment activity
			return new EPayOnlinePaymentFragment();
		}

		return null;
	}

	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return NO_OF_TABS;
	}

}
